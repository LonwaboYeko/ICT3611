Imports System.IO
Imports MRCS_BLL

Public Class frmResults
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Try
            Dim fs As New FileStream("drivers.txt", FileMode.Open)
            Dim br As New BinaryReader(fs)

            RichTextBox1.Text = "Membership number: " = br.ReadInt64 & vbNewLine &
            "Name: " = br.ReadString & vbNewLine &
            "Surname: " = br.ReadString & vbNewLine

            br.Close()
            fs.Close()
        Catch
            MessageBox.Show("Could not open or read from text file! ", "IO Exception")
        End Try
    End Sub
End Class