Public Class Form1

    'String array of names
    Private names() As String = {"Liam", "olivia", "NOAH", "Emma", "Oliver", "Charolette", "JAMES", "aVa"}

    ' As soon as our program runs, this sub procedure will execute
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Populate the listbox with the contents of the string array
        lbx_ListOfWords.Items.AddRange(names)
    End Sub

    Private Sub btn_Check_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nameToFind As String = TextBox1.Text.Trim()

        ' Make sure the name is valid (2-15 characters long)
        If nameToFind.Length < 2 Or nameToFind.Length > 15 Then
            MessageBox.Show("Please enter a name between 2 and 15 characters long.")
            Return
        End If

        ' Check if the name exists in the list box
        Dim nameFound As Boolean = False
        For Each name As String In lbx_ListOfWords.Items
            If name.Equals(nameToFind, If(CheckBox1.Checked, StringComparison.Ordinal, StringComparison.OrdinalIgnoreCase)) Then
                nameFound = True
                Exit For
            End If
        Next

        ' If the name doesn't exist in the list box, add it (Extra Credit Part)
        If Not nameFound Then
            lbx_ListOfWords.Items.Add(nameToFind)
            MessageBox.Show($"The name '{nameToFind}' was added to the list.")
        Else
            MessageBox.Show($"The name '{nameToFind}' was found in the list.")
        End If
    End Sub

End Class

