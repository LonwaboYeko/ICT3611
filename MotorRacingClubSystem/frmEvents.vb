Imports MRCS_BLL
Imports System.IO

Public Class frmEvents
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim RaceEvent As New clsEvents
        RaceEvent.Title = ValidTitle(txtTitle.Text)
        RaceEvent.DOE = DateTimePicker1.Value
        RaceEvent.RegFee = FormatCurrency(txtRegFee.Text)
        RaceEvent.Location = ValidLocation(txtLocation.Text)
        RaceEvent.NumberOfLaps = CInt(txtLocation.Text)

        Dim fs As New FileStream("evets.txt", FileMode.Append)
        Dim bw As New BinaryWriter(fs)
        bw.Write(RaceEvent.Title)
        bw.Write(RaceEvent.DOE)
        bw.Write(RaceEvent.RegFee)
        bw.Write(RaceEvent.Location)
        bw.Write(RaceEvent.NumberOfLaps)
        bw.Close()
        fs.Close()
    End Sub

    Private Function ValidTitle(title As String) As String
        If title <> "" And Not IsNumeric(title) Then
            Return title
        Else
            Return MessageBox.Show("Title is a required field", "Entry Error")
        End If
    End Function

    Private Function ValidLocation(location As String) As String
        If location <> "" And Not IsNumeric(location) Then
            Return location
        Else
            Return MessageBox.Show("Location is a required field", "Entry Error")
        End If
    End Function
End Class