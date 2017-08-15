Imports MRCS_BLL
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class frmMember

    Dim fs As FileStream
    Dim bf As New BinaryFormatter

    Dim driver As New clsDrivers

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Dir("drivers.txt") <> "" Then
            fs = New FileStream("drivers.txt", FileMode.Append)
        Else
            fs = New FileStream("drivers.txt", FileMode.Create)
        End If

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

        bf.Serialize(fs, driver)
        fs.Close()
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
            If Dir("drivers.txt") <> "" Then
                fs = New FileStream("drivers.txt", FileMode.Open)
                driver = bf.Deserialize(fs)
                Me.txtMembershipnumber.Text = driver.MembershipNo
                Me.txtName.Text = driver.Name
                Me.txtSurname.Text = driver.Surname
                Me.DateTimePicker1.Value = driver.DOB
                Dim gender As String = driver.Gender
                If gender = "Male" Then
                    rdoMale.Checked = True
                Else
                    rdoFemale.Checked = True
                End If
                Me.DateTimePicker2.Value = driver.DateJoined
                Me.txtFeesDue.Text = driver.FeesDue
            End If

            fs.Close()
        Catch
            MessageBox.Show("Could not open or read from text file! ", "IO Exception")
        End Try
    End Sub

    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        'Go to events form
        frmEvents.Show()
        Me.Hide()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Calculate the check digit first
        'driver.CalculateCheckDigit()

        'Open and search binary file for data
        If Dir("drivers.txt") <> "" Then
            fs = New FileStream("drivers.txt", FileMode.Open)

            'Create driver object to store incoming data
            Dim driver As New clsDrivers

            Do Until fs.Position = fs.Length
                driver = bf.Deserialize(fs)
                If StrComp(txtMembershipnumber.Text, Mid(driver.Name, 1, Len(txtMembershipnumber.Text)), vbTextCompare) = 0 Then
                    Me.txtMembershipnumber.Text = driver.MembershipNo
                    Me.txtName.Text = driver.Name
                    Me.txtSurname.Text = driver.Surname
                    Me.DateTimePicker1.Value = driver.DOB
                    Dim gender As String = driver.Gender
                    If gender = "Male" Then
                        rdoMale.Checked = True
                    Else
                        rdoFemale.Checked = True
                    End If
                    Me.DateTimePicker2.Value = driver.DateJoined
                    Me.txtFeesDue.Text = driver.FeesDue
                End If
            Loop
            fs.Close()
        End If

    End Sub
End Class
