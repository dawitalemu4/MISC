Imports System.IO

Public Class Form1

    Private InputPathClearCount As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_Edit.Enabled = True
        Btn_Clear.Enabled = True
        UpdateEnable()
        Txt_InputFileData.Enabled = False

    End Sub
    Private Sub Btn_BrowseDefaultDir_Click(sender As Object, e As EventArgs) Handles Btn_BrowseDefaultDir.Click
        BrowseForDirectory()
    End Sub

    Private Sub Btn_BrowseInputFile_Click(sender As Object, e As EventArgs) Handles Btn_BrowseInputFile.Click
        BrowseForFile("input")
    End Sub

    Private Sub Btn_BrowseOutputFile_Click(sender As Object, e As EventArgs) Handles Btn_BrowseOutputFile.Click
        BrowseForFile("output")
    End Sub


    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        If (Txt_InputPath.Text IsNot "" OrElse Txt_InputPath.Text IsNot "Specify input file path") Then
            Txt_InputFileData.Enabled = True
        Else
            MessageBox.Show("Please specify input file path.")
        End If
    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        Txt_DefaultDirPath.Text = ""
        Txt_InputPath.Text = ""
        Txt_OutputPath.Text = ""
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        LoadInputFile()
    End Sub

    Private Sub Btn_SaveAs_Click(sender As Object, e As EventArgs) Handles Btn_SaveAs.Click
        SaveAs()
    End Sub

    Private Sub Txt_DefaultDirPath_Click(sender As Object, e As EventArgs) Handles Txt_DefaultDirPath.Click
        ClearDefaultPath()
    End Sub

    Private Sub Txt_InputPath_Click(sender As Object, e As EventArgs) Handles Txt_InputPath.Click
        ClearInputPath()
    End Sub

    Private Sub Txt_OutputPath_Click(sender As Object, e As EventArgs) Handles Txt_OutputPath.Click
        ClearOutputPath()
    End Sub


    Private Sub UpdateEnable()
        Btn_Update.Enabled = False
        If (Txt_InputPath.Text IsNot "" OrElse Txt_InputPath.Text IsNot "Specify input file path") Then
            Btn_Update.Enabled = True
        End If
    End Sub

    Private Sub ClearDefaultPath()
        If (Txt_DefaultDirPath.Text = "" OrElse Txt_DefaultDirPath.Text = "Specify default directory") Then
            Txt_DefaultDirPath.Text = ""
        End If
    End Sub
    Private Sub ClearInputPath()
        If (Txt_InputPath.Text = "" OrElse Txt_InputPath.Text = "Specify input file path") Then
            Txt_InputPath.Text = ""
        End If
    End Sub
    Private Sub ClearOutputPath()
        If (Txt_OutputPath.Text = "" OrElse Txt_OutputPath.Text = "Specify output file path") Then
            Txt_OutputPath.Text = ""
        End If
    End Sub


    Private Sub SaveAs()
        If (Txt_OutputPath.Text = "" OrElse Txt_OutputPath.Text = "Specify output file path") Then
            MessageBox.Show("Please select an output file before saving.")
        Else
            Dim sfd As New SaveFileDialog()
            Dim strFileName As String = ""

            sfd.Title = "Save As Dialog"
            sfd.InitialDirectory = Txt_DefaultDirPath.Text
            sfd.Filter = "TXT files (*.txt*)|*.txt*|All files (*.*)|*.*"
            sfd.FilterIndex = 1
            sfd.RestoreDirectory = True

            If sfd.ShowDialog() = DialogResult.OK Then
                strFileName = sfd.FileName

                Using writer As New StreamWriter(strFileName)
                    writer.Write(Txt_InputFileData.Text)
                End Using
            End If
        End If
    End Sub


    Private Sub BrowseForDirectory()
        Dim fbd As New FolderBrowserDialog()
        Dim strFolderName As String = ""

        If (fbd.ShowDialog() = DialogResult.OK) Then
            strFolderName = fbd.SelectedPath
        End If

        Txt_DefaultDirPath.Text = strFolderName

    End Sub



    Private Sub BrowseForFile(type As String)

        Dim ofd As New OpenFileDialog()
        Dim strFileName As String = ""

        ofd.Title = "Open File Dialog"
        ofd.InitialDirectory = Txt_DefaultDirPath.Text
        'This allows two file types: TXT or ALL
        ofd.Filter = "TXT files (*.txt*)|*.txt*|All files (*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            strFileName = ofd.FileName

            If (type.Equals("input")) Then
                Txt_InputPath.Text = strFileName
                LoadInputFile()
            End If

        End If


    End Sub


    Private Sub LoadInputFile()
        Dim inFile As New FileStream(Txt_InputPath.Text, FileMode.Open, FileAccess.Read)
        Dim reader As New StreamReader(inFile)
        Dim line As String

        line = reader.ReadToEnd

        Txt_InputFileData.Text = line


    End Sub










End Class
