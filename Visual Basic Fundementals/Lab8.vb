Public Class Form1

    Private con As OleDb.OleDbConnection
    Private cmd As New OleDb.OleDbCommand
    Private da As New OleDb.OleDbDataAdapter
    Private inEditMode As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setGUIProperties()
        setDatabaseConnection()
        getCustomerList()
    End Sub

    Private Sub cbx_Customers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_Customers.SelectedIndexChanged
        getCustomerData()
    End Sub

    Private Sub btn_EditOrSubmit_Click(sender As Object, e As EventArgs) Handles btn_EditOrSubmit.Click
        editOrSubmitData()
        btn_Cancel.Visible = True
    End Sub


    Private Sub btn_NewCustomer_Click(sender As Object, e As EventArgs) Handles btn_NewCustomer.Click
        createNewCustomer()
    End Sub



    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'When the user clicks this button, the original data from the customer must be reloaded and the textboxes set back to disabled
        'The "Submit" button should also be changed back to "Edit"

        'DO NOT requery the database to get the original data back! You should save the data locally first (in a variable)
        'This is so you do not overwork servers/networks/databases with unneccesary traffic/requests!

        setGUIProperties()
        setDatabaseConnection()

    End Sub















    Private Sub setGUIProperties()
        cbx_Customers.DropDownStyle = ComboBoxStyle.DropDownList
        txt_City.Enabled = False
        txt_Country.Enabled = False
        btn_Cancel.Visible = False
        inEditMode = False
        btn_EditOrSubmit.Text = "Edit"
    End Sub



    Private Sub setDatabaseConnection()
        'This database file needs to be in the *bin\Debug* directory of your project
        con = New OleDb.OleDbConnection("Data Source=Database.mdb; Provider=Microsoft.Jet.OLEDB.4.0")

        'Set the connection for our command
        cmd.Connection = con
    End Sub



    Private Sub getCustomerList()

        Dim dt As New DataTable
        Dim queryStr As String

        'Query for getting the company names
        'We are selecting CustomerID because that is the primary key (unique value) associated with a Company
        queryStr = "SELECT CustomerID, CompanyName FROM Customers"

        'Execute an SQL select command using the query 
        da.SelectCommand = New OleDb.OleDbCommand(queryStr, con)

        'Fill the data table with the results of our select query; Fill opens/closes the connectoin on its own.
        da.Fill(dt)

        'Set the combobox's display member and value member to associate the correct data
        cbx_Customers.DisplayMember = "CompanyName" 'Represents the text information displayed in the drop-down list
        cbx_Customers.ValueMember = "CustomerID" 'Represents the corresponding value of a selection (primary key)

        'Set the data source of the combobox to the data table that was filled by the data adapter
        cbx_Customers.DataSource = dt

    End Sub




    Private Sub getCustomerData()

        Dim dt As New DataTable
        Dim queryStr As String

        'For this query, we want to retrieve the customer's ID number and use that in our next query
        'This is because we don't want to write a query using the company's name, rather, use the primary key associated with them
        Dim companyID As Integer = cbx_Customers.SelectedValue

        'Now our query selects the City and Country of the customers
        queryStr = "SELECT City, Country FROM Customers WHERE CustomerID=" & companyID

        'Use this to display the SQL query which can help with debugging
        'MessageBox.Show(queryStr)

        da.SelectCommand = New OleDb.OleDbCommand(queryStr, con)
        da.Fill(dt)

        'Since we are querying a unique ID, we are expecting only one row (one result)
        'There for we are going to look at row zero of our data table
        txt_City.Text = dt.Rows(0)("City").ToString()
        txt_Country.Text = dt.Rows(0)("Country").ToString()

    End Sub






    Private Sub editOrSubmitData()
        If (Not inEditMode) Then
            'When clicking to enter the "Edit State" the textboxes should become enabled so the user can change the text
            'After clicking this button to Edit, the text should change to "Submit"
            btn_EditOrSubmit.Text = "Submit"
            txt_City.Enabled = True
            txt_Country.Enabled = True
            inEditMode = True
        Else
            'Check that textboxes are not empty before updating
            If String.IsNullOrEmpty(txt_City.Text) OrElse String.IsNullOrEmpty(txt_Country.Text) Then
                'Show an error message and exit the method
                MessageBox.Show("Both City and Country fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            'When clicking the Submit button, this should execute a query to update the contents of the database
            'The query to do so is provided below for you.
            Dim queryStr As String
            Dim cityStr As String = txt_City.Text
            Dim countryStr As String = txt_Country.Text
            Dim companyID As Integer = cbx_Customers.SelectedValue

            ' Check the length of the strings and show an error message if they are too long
            If cityStr.Length > 30 Then
                MessageBox.Show("City name is too long. Maximum length is 30 characters.")
                Return
            End If

            If countryStr.Length > 30 Then
                MessageBox.Show("Country name is too long. Maximum length is 30 characters.")
                Return
            End If

            queryStr = "UPDATE Customers SET City='" & cityStr & "', Country='" & countryStr & "' WHERE CustomerID=" & companyID

            MessageBox.Show(queryStr)

            con.Open()
            'Execute an SQL select command using the query 
            da.UpdateCommand = con.CreateCommand
            da.UpdateCommand.CommandText = queryStr
            da.UpdateCommand.ExecuteNonQuery()
            con.Close()

        End If

    End Sub




    Private Sub createNewCustomer()

        'Boolean used to determine if we need to refresh the data (list of customers)
        Dim refreshData As Boolean

        'Display a new form to add a new customer (company)
        Dim newCust = New frm_NewCustomer
        newCust.ShowDialog()

        'Get the boolean value from the other form (accessible because this data was set to Public)
        refreshData = newCust.refreshData

        If (refreshData) Then
            'Call this subprocedure to get the new list
            getCustomerList()
        End If

    End Sub



End Class
