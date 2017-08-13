<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResults
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblDrivers = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblDrivers
        '
        Me.lblDrivers.AutoSize = True
        Me.lblDrivers.Location = New System.Drawing.Point(13, 53)
        Me.lblDrivers.Name = "lblDrivers"
        Me.lblDrivers.Size = New System.Drawing.Size(43, 13)
        Me.lblDrivers.TabIndex = 0
        Me.lblDrivers.Text = "Drivers:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(62, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Location = New System.Drawing.Point(256, 53)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(45, 13)
        Me.lblResults.TabIndex = 2
        Me.lblResults.Text = "Results:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(307, 50)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(262, 316)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(494, 402)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 437)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lblDrivers)
        Me.Name = "frmResults"
        Me.Text = "frmResults"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDrivers As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents lblResults As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnExit As Button
End Class
