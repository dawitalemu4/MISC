Imports System.Data.OleDb

Public Class Form1

    Private con As OleDb.OleDbConnection
    Private cmd As New OleDb.OleDbCommand
    Private da As New OleDb.OleDbDataAdapter
    Private dataLoaded As New Boolean
    Private ClassID As Integer
    Private inEditMode As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataLoaded = False
        SetupDatabaseConnection()
        LoadCharacters()
        LoadClass()
    End Sub


    Private Sub btn_EditSubmit_Click(sender As Object, e As EventArgs) Handles btn_EditSubmit.Click

        Dim queryStr As String
        Dim str, dex, vit, nrg As Integer

        If (Not inEditMode) Then
            'Entering edit mode
            txt_Str.Enabled = True
            txt_Dex.Enabled = True
            txt_Vit.Enabled = True
            txt_Nrg.Enabled = True

            btn_EditSubmit.Text = "Submit"
            btn_Cancel.Visible = True

            inEditMode = True

        Else

            If (HasGoodData()) Then


                Try

                    str = Convert.ToInt32(txt_Str.Text)
                    dex = Convert.ToInt32(txt_Dex.Text)
                    vit = Convert.ToInt32(txt_Vit.Text)
                    nrg = Convert.ToInt32(txt_Nrg.Text)

                    'Executing query to update database
                    queryStr = "UPDATE Class SET Strength=" & str & ", Dexterity=" & dex & ", Vitality=" & vit & ", Energy=" & nrg & " WHERE ClassID=" & ClassID
                    'code to execute query here
                    MessageBox.Show("Succesfully Updated")
                    'Exiting edit mode
                    CancelEditing()
                Catch ex As Exception
                    MessageBox.Show("An error occurred while updating the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CancelEditing()
                End Try
            Else
                If (txt_Str.Text.Length > 100 Or txt_Dex.Text.Length > 100 Or txt_Vit.Text.Length > 100 Or txt_Nrg.Text.Length > 100) Then
                    MessageBox.Show("Input invalid. Attribute values cannot be longer than 100 characters. Cancelling changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CancelEditing()
                Else
                    'Data is not good, show error message box and cancel editing
                    MessageBox.Show("Input invalid. Cancelling changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CancelEditing()
                End If
            End If
        End If



    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        CancelEditing()
    End Sub



    Private Sub cbx_Char_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_Char.SelectedIndexChanged
        LoadAttributes()
    End Sub




    Private Sub SetupDatabaseConnection()
        con = New OleDb.OleDbConnection("Data Source=Quiz4.mdb; Provider=Microsoft.Jet.OleDB.4.0")
        cmd.Connection = con
    End Sub




    Private Sub LoadCharacters()
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim queryStr As String

        queryStr = "SELECT CharacterID, NameStringID FROM Characters"
        da.SelectCommand = New OleDb.OleDbCommand(queryStr, con)
        da.Fill(dt)

        cbx_Char.DataSource = dt

        dataLoaded = True

        If (dataLoaded) Then
            'Once we determine the data has been loaded, then get the attributes
            LoadAttributes()
        End If
    End Sub





    'Here is the subprocedure that loads the character's class... but why does this not work?
    Private Sub LoadClass()
        Dim queryStr As String

        If (dataLoaded) Then
            queryStr = "SELECT ClassName FROM ClassNames WHERE ClassID = " & ClassID
            cmd = New OleDbCommand(queryStr, con)

            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    txt_Class.Text = reader.GetValue(1)
                End While
            End Using
            con.Close()

        End If

    End Sub




    'This subprocedure is given to you and requires NO editing on your part.
    Private Sub LoadAttributes()
        Dim query As String

        'When the user selects a Character from the combobox, we want to user their selection
        'to query the database to find the attributes associated with that charater class

        'Only if our data has finished loading do we want this to execute
        If (dataLoaded) Then

            'Get the ClassID of our selected character
            query = "SELECT ClassID FROM Characters WHERE NameStringID = '" &
            cbx_Char.GetItemText(cbx_Char.SelectedItem) & "';"

            'Create a new command using the query string we created above
            cmd = New OleDbCommand(query, con)

            con.Open()
            'Use a data reader to read the results of our query
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    'We are only expecting one result, the ClassID of our selected character
                    ClassID = reader.GetValue(0)
                End While
            End Using
            con.Close()

            'Using the found ClassID, query the table to get the associated attributes
            query = "SELECT Strength, Dexterity, Vitality, Energy FROM Class WHERE ClassID=" & ClassID & ";"
            cmd = New OleDbCommand(query, con)

            'The query selects FOUR columns which means we will get FOUR results from the query
            ' 1st column: Strength
            ' 2nd column: Dexterity
            ' 3rd column: Vitality
            ' 4th column: Energy

            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    'We are only expecting one result, the ClassID of our selected character
                    txt_Str.Text = reader.GetValue(0) 'our first result will be strength
                    txt_Dex.Text = reader.GetValue(1) 'our second result will be dexterity
                    txt_Vit.Text = reader.GetValue(2) 'our third result will be vitality
                    txt_Nrg.Text = reader.GetValue(3) 'our fourth result will be energy
                End While
            End Using
            con.Close()

        End If

    End Sub





    'Finish implemetning for extra credit
    Private Function HasGoodData() As Boolean

        Dim valid As Boolean = True

        Try
            Dim str, dex, vit, nrg As Integer
            str = Convert.ToInt32(txt_Str.Text)
            dex = Convert.ToInt32(txt_Dex.Text)
            vit = Convert.ToInt32(txt_Vit.Text)
            nrg = Convert.ToInt32(txt_Nrg.Text)

            If (str < 0 Or str > 100 Or dex < 0 Or dex > 100 Or vit < 0 Or vit > 100 Or nrg < 0 Or nrg > 100) Then
                valid = False
            End If
        Catch ex As FormatException
            valid = False
        End Try

        Return valid

    End Function




    Private Sub CancelEditing()
        'When the user clicks this button, the original data from the customer must be reloaded
        'and the textboxes set back to disabled

        'The "Submit" button should also be changed back to "Edit"
        'Exiting edit mode
        txt_Str.Enabled = False
        txt_Dex.Enabled = False
        txt_Vit.Enabled = False
        txt_Nrg.Enabled = False

        btn_EditSubmit.Text = "Edit"
        btn_Cancel.Visible = False

        'Reloading original attribute values
        txt_Str.Text = ""
        txt_Dex.Text = ""
        txt_Vit.Text = ""
        txt_Nrg.Text = ""

        inEditMode = False
    End Sub



End Class

