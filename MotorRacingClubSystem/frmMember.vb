Imports MRCS_BLL
Imports System.IO

Public Class frmMember

    Dim driver As New clsDrivers

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'Get user input and create and initialise an object of the driver class


        driver.Name = ValidName(txtName.Text)
        driver.Surname = ValidSurname(txtSurname.Text)
        driver.DOB = DateTimePicker1.Value.ToShortDateString
        If rdoMale.Checked = True Then
            driver.Gender = "Male"
        ElseIf rdoFemale.Checked = True Then
            driver.Gender = "Female"
        Else
            MessageBox.Show("Gender is a required field", "Entry Error")
        End If
        driver.DateJoined = DateTimePicker2.Value.ToShortDateString
        driver.FeesDue = FormatCurrency(txtFeesDue.Text)
        driver.MembershipNo = driver.CalculateMembershipNo()

        'Display membership number on the form
        Me.txtMembershipnumber.Text = driver.MembershipNo


        'Write member data to the driver text file
        Try
            Dim fs As New FileStream("drivers.txt", FileMode.Append)
            Dim bw As New BinaryWriter(fs)
            bw.Write(driver.MembershipNo)
            bw.Write(driver.Name)
            bw.Write(driver.Surname)
            bw.Write(driver.DOB)
            bw.Write(driver.Gender)
            bw.Write(driver.DateJoined)
            bw.Write(driver.FeesDue)
            bw.Close()
            fs.Close()
        Catch
            MessageBox.Show("Could not open or write to text file! ", "IO Exception")
        End Try

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear all data input fields and return focus to the name field
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'reading data back to the user from the text file
        Try
            Dim fs As New FileStream("drivers.txt", FileMode.Open)
            Dim br As New BinaryReader(fs)

            Me.txtMembershipnumber.Text = br.ReadInt64
            Me.txtName.Text = br.ReadString
            Me.txtSurname.Text = br.ReadString
            Me.DateTimePicker1.Value = br.ReadString
            Dim gender As String = br.ReadString
            If gender = "Male" Then
                rdoMale.Checked = True
            Else
                rdoFemale.Checked = True
            End If
            Me.DateTimePicker2.Value = br.ReadString
            Me.txtFeesDue.Text = br.ReadDecimal

            br.Close()
            fs.Close()
        Catch
            MessageBox.Show("Could not open or read from text file! ", "IO Exception")
        End Try
    End Sub

    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        frmEvents.Show()
        Me.Hide()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        driver.CalculateCheckDigit()
    End Sub
End Class
