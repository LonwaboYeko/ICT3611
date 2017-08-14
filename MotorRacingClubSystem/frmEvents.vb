Imports MRCS_BLL
Imports System.IO

Public Class frmEvents
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Create events objects and initialise properties 
        Dim RaceEvent As New clsEvents

        RaceEvent.Title = ValidTitle(txtTitle.Text)
        RaceEvent.DOE = DateTimePicker1.Value
        RaceEvent.RegFee = FormatCurrency(txtRegFee.Text)
        RaceEvent.Location = ValidLocation(txtLocation.Text)
        RaceEvent.NumberOfLaps = CInt(txtNumberOfLaps.Text)

        'Display racing event data on to the user
        RichTextBox1.Text = "Title: " & RaceEvent.Title & vbNewLine & "DOE: " & RaceEvent.DOE & vbNewLine & "Registration Fee: " & RaceEvent.RegFee & vbNewLine & "Location: " & RaceEvent.Location & vbNewLine & "Number of laps: " & RaceEvent.NumberOfLaps

        'Write event data to events text file
        Dim fs As New FileStream("evets.txt", FileMode.Append)
        Dim bw As New BinaryWriter(fs)
        bw.Write("Title: " & RaceEvent.Title)
        bw.Write("DOE: " & RaceEvent.DOE)
        bw.Write("Registration Fee: " & RaceEvent.RegFee)
        bw.Write("Location: " & RaceEvent.Location)
        bw.Write("Number of Laps: " & RaceEvent.NumberOfLaps)
        bw.Close()
        fs.Close()
    End Sub

    Private Function ValidTitle(title As String) As String
        If title <> "" And Not IsNumeric(title) Then
            Return title
        Else
            Return MessageBox.Show("Title is a required field and must be alphabetic", "Entry Error")
            Me.txtTitle.Select()
        End If
    End Function

    Private Function ValidLocation(location As String) As String
        If location <> "" Then
            Return location
        Else
            Return MessageBox.Show("Location is a required field", "Entry Error")
            Me.txtLocation.Select()
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub

    Private Sub btnResults_Click(sender As Object, e As EventArgs) Handles btnResults.Click
        frmResults.Show()
        Me.Hide()
    End Sub
End Class