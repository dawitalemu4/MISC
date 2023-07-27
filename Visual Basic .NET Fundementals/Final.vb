Imports System.IO

Public Class Form1

    Private con As OleDb.OleDbConnection
    Private cmd As New OleDb.OleDbCommand
    Private da As New OleDb.OleDbDataAdapter

    ' Global variables to save original data to revert changes
    Private originalData1 As Integer
    Private originalData2 As Integer
    Private originalData3 As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_DatabaseBrowse_Click(sender As Object, e As EventArgs) Handles btn_DatabaseBrowse.Click
        Browse("Data")
    End Sub

    Private Sub btn_InputBrowse_Click(sender As Object, e As EventArgs) Handles btn_InputBrowse.Click
        Browse("Input")
    End Sub

    'Why does the below execute TWICE?
    'YOUR CODE HERE (fix the code for this sub-procedure's event handler)
    Private Sub btn_OutputBrowse_Click(sender As Object, e As EventArgs) Handles btn_OutputBrowse.Click
        Browse("Output")
    End Sub


    Private Sub btn_Revert_Click(sender As Object, e As EventArgs) Handles btn_Revert.Click
        ReloadData()
    End Sub


    Private Sub AlteredData(sender As Object, e As EventArgs) Handles txt_Data1.KeyPress, txt_Data2.KeyPress, txt_Data3.KeyPress
        'Allow the user click the revert button since text has changed
        SubmitData()

    End Sub

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        SubmitData()
    End Sub





    Private Sub Browse(Operation As String)
        Dim strFilePath As String
        Dim ofd As New OpenFileDialog()

        ofd.InitialDirectory = Application.StartupPath()
        ofd.RestoreDirectory = True
        ofd.FilterIndex = 1
        ofd.Filter = "TXT files (*.txt*)|*.txt*|All files (*.*)|*.*"

        If (Operation.Equals("Data")) Then
            ofd.Filter = "MDB files (*.mdb*)|*.mdb*|All files (*.*)|*.*"

            If ofd.ShowDialog() = DialogResult.OK Then
                strFilePath = ofd.FileName
                txt_DatabasePath.Text = strFilePath

                SetupDatabaseConnection(strFilePath)
                btn_Revert.Enabled = False
            End If
        ElseIf (Operation.Equals("Input")) Then
            If ofd.ShowDialog() = DialogResult.OK Then
                strFilePath = ofd.FileName
                txt_InputFilePath.Text = strFilePath

                Dim LineOfData As String
                Dim DataFile As New FileStream(strFilePath, FileMode.Open, FileAccess.Read)
                Dim DataReader As New StreamReader(DataFile)

                LineOfData = DataReader.ReadLine()

                Dim Data() As String = LineOfData.Split(","c)


                'Save the data from the array into the three global variables
                'Remember, arrays start counting at index ZERO
                originalData1 = Integer.Parse(Data(0))
                originalData2 = Integer.Parse(Data(1))
                originalData3 = Integer.Parse(Data(2))


                'Put the data into the three column texboxes
                txt_Data1.Text = originalData1.ToString()
                txt_Data2.Text = originalData2.ToString()
                txt_Data3.Text = originalData3.ToString()



                'Enable the text boxes to be edited
                txt_Data1.Enabled = True
                txt_Data2.Enabled = True
                txt_Data3.Enabled = True


                ' DO NOT mess with this query
                Dim queryStr As String = "INSERT INTO TheTable VALUES (" & Integer.Parse(Data(0)) & "," &
                    Integer.Parse(Data(1)) & "," & Integer.Parse(Data(2)) & ")"


                'Open the database connection using the data adapter
                'Set the command text to the above query
                'Execute the command
                'Close the database connection

                con.Open()
                cmd.CommandText = queryStr
                cmd.ExecuteNonQuery()
                con.Close()



                DataFile.Close()
                DataReader.Close()

                btn_Revert.Enabled = True
            End If



        ElseIf (Operation.Equals("Output")) Then

            If ofd.ShowDialog() = DialogResult.OK Then
                strFilePath = ofd.FileName
                txt_OutputFilePath.Text = strFilePath

                'Enable the submit botton
                btn_Submit.Enabled = True

            End If

        Else
            MessageBox.Show("Bad argument provided in Browse(): " & Operation)
        End If

    End Sub



    Private Sub SetupDatabaseConnection(databasePath As String)
        con = New OleDb.OleDbConnection("Data Source=" & databasePath & "; Provider=Microsoft.Jet.OleDB.4.0")
        cmd.Connection = con
    End Sub






    Private Sub ReloadData()
        'You would have first crated 3 global variables for the 3 columns
        'Use the global variables to reload the original values in each textbox
        txt_Data1.Text = originalData1.ToString()
        txt_Data2.Text = originalData2.ToString()
        txt_Data3.Text = originalData3.ToString()

    End Sub





    Private Sub SubmitData()

        'Create a new FileStream using the OPEN file mode and WRITE file access
        'YOUR CODE HERE (1 line of code)

        'Create a StreamWriter and pass the FileStream you are writing to as an argument
        'YOUR CODE HERE (1 line of code)

        'Take the data from each textbox and write it to the output file
        'Each textbox gets written on its own line (there should be 3 lines written)
        'Use the WriteLine method
        'YOUR CODE HERE (3 lines of code)

        'Close the FileStream and StreamWriter
        'YOUR CODE HERE (2 lines of code)

        Dim strFilePath As String = txt_OutputFilePath.Text
        If Not String.IsNullOrEmpty(strFilePath) Then
            Try
                Dim outputFile As New StreamWriter(strFilePath)

                outputFile.WriteLine(txt_Data1.Text)
                outputFile.WriteLine(txt_Data2.Text)
                outputFile.WriteLine(txt_Data3.Text)

                outputFile.Close()

                MessageBox.Show("Data has been written to the output file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error writing to output file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub







End Class
