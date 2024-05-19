Public Class Form1


    'When the greet button is clicked, it will take the contents of the textbox (their name)
    'And greet them using a message box
    Private Sub btn_Greet_Click() Handles btn_Greet.Click
        Dim isValidName As Boolean = False

        ' Check if the input string is too short or empty
        If txt_FirstName.Text.Trim().Length < 3 Then
            MessageBox.Show("Please enter a name that is at least 3 characters long.", "Invalid Name")
            isValidName = True
        End If

        ' Check if the input string is too long
        If txt_FirstName.Text.Trim().Length > 50 Then
            MessageBox.Show("Please enter a name that is no longer than 50 characters.", "Invalid Name")
            isValidName = True
        End If

        ' Set the boolean to false if both if statements are not true
        If Not (txt_FirstName.Text.Trim().Length < 3 OrElse txt_FirstName.Text.Trim().Length > 50) Then
            isValidName = False
        End If

        If isValidName = False Then
            Dim message As String = "Hello " & txt_FirstName.Text & "!"
            MessageBox.Show(message, "Greeting")
        End If
    End Sub

    'When the user clicks in the textbox, it will erase the default text for them
    Private Sub txt_FirstName_Click(sender As Object, e As EventArgs) Handles txt_FirstName.Click
        'Only clear the default message when string count is 0
        Static count As Integer = 0
        If count = 0 Then
            txt_FirstName.Clear()
            count += 1
        End If
    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim isValidName As Boolean = False

        ' Check if the input string is too short or empty
        If txt_FirstName.Text.Trim().Length < 3 Then
            MessageBox.Show("Please enter a name that is at least 3 characters long.", "Invalid Name")
            isValidName = True
        End If

        ' Check if the input string is too long
        If txt_FirstName.Text.Trim().Length > 50 Then
            MessageBox.Show("Please enter a name that is no longer than 50 characters.", "Invalid Name")
            isValidName = True
        End If

        ' Set the boolean to false if both if statements are not true
        If Not (txt_FirstName.Text.Trim().Length < 3 OrElse txt_FirstName.Text.Trim().Length > 50) Then
            isValidName = False
        End If

        ' Add the name to the combobox
        cbx_ListOfNames.Items.Add(txt_FirstName.Text)

        ' Auto select the first item in the list
        cbx_ListOfNames.SelectedIndex = 0

        If isValidName = False Then
            ' Tell the user the name was added 
            Dim message As String = txt_FirstName.Text & " was added."
            MessageBox.Show(message, "Confirmation")
        End If

        ' Clear the textbox for the next name
        txt_FirstName.Text = ""

    End Sub

    Private Sub btn_Apply_Click(sender As Object, e As EventArgs) Handles btn_ApplyChoices.Click

        Dim message As String = "Option #"

        'Because radio button groups can only have on option selected, we can use a Select Case
        'The select case is be set to TRUE or else it will not continue to check each case
        Select Case True
            Case rbn_Option1.Checked
                message += "1"
            Case rbn_Option2.Checked
                message += "2"
            Case rbn_Option3.Checked
                message += "3"
        End Select

        message += " is being applied."

        MessageBox.Show(message, "Applying Options")

    End Sub


    'Because check boxes allow more than one selection, we cannot use a select case
    'Instead, we use If/Then
    Private Sub btn_ApplyChoices_Click(sender As Object, e As EventArgs) Handles btn_ApplyOptions.Click

        Dim message As String = "You selected the following choice(s): "
        Dim count As Integer = 0

        'If the checkbox associated with Choice 1 is checked
        'Add 1 to the message and increase the count
        If (chk_Choice1.Checked) Then
            message += "1"
            count += 1
        End If


        'If the checkbox associated with Choice 2 is checked
        If (chk_Choice2.Checked) Then

            'If the count is 1 or more (meaning another checkbox has been checked)
            'Then we need to add a comma behind the number that proceeds it
            If (count > 0) Then
                message += ", 2"
            Else
                'If the count is not 1 or more, then 2 is the first number and requires no comma
                message += "2"
            End If

            ' Increase the count by 1
            count += 1
        End If

        'Same logic, except now for checkbox 3
        If (chk_Choice3.Checked) Then

            If (count > 0) Then
                message += ", 3"
            Else
                message += "3"
            End If

            count += 1
        End If

        'Add a period at the end of our sentence.
        message += "."

        'Tell the user wich choices were chosen.
        MessageBox.Show(message, "Applying Choices")

    End Sub

    'This code takes what is selected in the combobox and adds it to the listbox
    Private Sub btn_AddToListBox_Click(sender As Object, e As EventArgs) Handles btn_AddToListBox.Click
        Dim selectedName As String = cbx_ListOfNames.SelectedItem.ToString().ToLower()

        For Each item As String In lbx_ListOfNames.Items
            If item.ToLower() = selectedName Then
                MessageBox.Show("Duplicate names are not allowed.", "Error")
                Return
            End If
        Next

        lbx_ListOfNames.Items.Add(selectedName)
        MessageBox.Show("Name added successfully.", "Message")

    End Sub

    'This subproceudre contains code on how to determine if something already exists in the listbox
    Private Sub btn_Contains_Click(sender As Object, e As EventArgs) Handles btn_Contains.Click

        If lbx_ListOfNames.Items.Contains(cbx_ListOfNames.SelectedItem) Then
            MessageBox.Show("This name already exists.", "Error")
        Else
            MessageBox.Show("This name does NOT already exist.", "Message")
        End If

    End Sub

End Class



