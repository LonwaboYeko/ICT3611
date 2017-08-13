Imports MRCS_BLL
Imports System.IO

Public Class frmMember
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim driver As New clsDrivers
        driver.Name = ValidName(txtName.Text)
        driver.Surname = ValidSurname(txtSurname.Text)
        driver.DOB = DateTimePicker1.Value
        If rdoMale.Checked = True Then
            driver.Gender = "Male"
        ElseIf rdoFemale.Checked = True Then
            driver.Gender = "Female"
        Else
            MessageBox.Show("Gender is a required field", "Entry Error")
        End If
        driver.DateJoined = DateTimePicker2.Value
        driver.FeesDue = FormatCurrency(txtFeesDue.Text)

        Dim fs As New FileStream("drivers.txt", FileMode.Append)
        Dim bw As New BinaryWriter(fs)
        bw.Write(driver.Name)
        bw.Write(driver.Surname)
        bw.Write(driver.DOB)
        bw.Write(driver.Gender)
        bw.Write(driver.DateJoined)
        bw.Write(driver.FeesDue)
        bw.Close()
        fs.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtMembershipnumber.Text = ""
        Me.txtName.Text = ""
        Me.txtSurname.Text = ""
        Me.DateTimePicker1.ResetText()
        Me.rdoMale.Checked = False
        Me.rdoFemale.Checked = False
        Me.DateTimePicker2.ResetText()
        Me.txtFeesDue.Text = ""
        Me.txtName.Select()
    End Sub

    Private Function ValidName(name As String) As String
        If name = "" Or IsNumeric(name) = True Then
            Return MessageBox.Show("Name is a required field and should be alphabetic", "Entry Error")
        Else
            Return name
        End If
    End Function

    Private Function ValidSurname(surname As String) As String
        If surname = "" Or IsNumeric(surname) = True Then
            Return MessageBox.Show("Surname is a required field and should be alphabetic", "Entry Error")
        Else
            Return surname
        End If
    End Function

End Class
