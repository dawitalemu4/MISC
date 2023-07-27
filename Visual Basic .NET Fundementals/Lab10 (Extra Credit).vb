Imports System.IO

Public Class Form1

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        Try
            txt_Field.Text = Integer.Parse(txt_Field.Text) + 10
        Catch ex As Exception
            MessageBox.Show("Invalid input. Please enter a valid integer.")
        End Try
    End Sub


    Private Sub btn_OpenFile_Click(sender As Object, e As EventArgs) Handles btn_OpenFile.Click

        Dim filePath As String = txt_FileLocation.Text

        If File.Exists(filePath) Then
            Dim line As String
            Using inFile As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                Using reader As StreamReader = New StreamReader(inFile)
                    line = reader.ReadLine
                End Using
            End Using
            MessageBox.Show("File found. Valid path.")
        Else
            MessageBox.Show("File not found. Please check the file path and try again.")
        End If
    End Sub



End Class
