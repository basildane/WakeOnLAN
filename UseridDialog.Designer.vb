<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UseridDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lDescription = New System.Windows.Forms.Label()
        Me.lUserId = New System.Windows.Forms.Label()
        Me.lPassword = New System.Windows.Forms.Label()
        Me.lDomain = New System.Windows.Forms.Label()
        Me.tDomain = New WakeOnLan.Controls.RegExTextBox()
        Me.tPassword = New WakeOnLan.Controls.RegExTextBox()
        Me.tUserId = New WakeOnLan.Controls.RegExTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lDescription
        '
        Me.lDescription.Location = New System.Drawing.Point(34, 27)
        Me.lDescription.Name = "lDescription"
        Me.lDescription.Size = New System.Drawing.Size(369, 40)
        Me.lDescription.TabIndex = 0
        Me.lDescription.Text = "You may optionally enter a UseridDialog, password, and domain that will be used f" & _
    "or shutdown operations.  Leave these fields blank to use the default credentials" & _
    "."
        '
        'lUserId
        '
        Me.lUserId.AutoSize = True
        Me.lUserId.Location = New System.Drawing.Point(110, 120)
        Me.lUserId.Name = "lUserId"
        Me.lUserId.Size = New System.Drawing.Size(43, 13)
        Me.lUserId.TabIndex = 2
        Me.lUserId.Text = "User ID"
        '
        'lPassword
        '
        Me.lPassword.AutoSize = True
        Me.lPassword.Location = New System.Drawing.Point(100, 151)
        Me.lPassword.Name = "lPassword"
        Me.lPassword.Size = New System.Drawing.Size(53, 13)
        Me.lPassword.TabIndex = 3
        Me.lPassword.Text = "Password"
        '
        'lDomain
        '
        Me.lDomain.AutoSize = True
        Me.lDomain.Location = New System.Drawing.Point(110, 182)
        Me.lDomain.Name = "lDomain"
        Me.lDomain.Size = New System.Drawing.Size(43, 13)
        Me.lDomain.TabIndex = 4
        Me.lDomain.Text = "Domain"
        '
        'tDomain
        '
        Me.tDomain.ErrorColor = System.Drawing.Color.Red
        Me.tDomain.ErrorMessage = Nothing
        Me.tDomain.Location = New System.Drawing.Point(159, 179)
        Me.tDomain.Name = "tDomain"
        Me.tDomain.Size = New System.Drawing.Size(188, 20)
        Me.tDomain.TabIndex = 3
        Me.tDomain.ValidationExpression = ""
        '
        'tPassword
        '
        Me.tPassword.ErrorColor = System.Drawing.Color.Red
        Me.tPassword.ErrorMessage = Nothing
        Me.tPassword.Location = New System.Drawing.Point(159, 148)
        Me.tPassword.Name = "tPassword"
        Me.tPassword.Size = New System.Drawing.Size(188, 20)
        Me.tPassword.TabIndex = 2
        Me.tPassword.ValidationExpression = ""
        '
        'tUserId
        '
        Me.tUserId.ErrorColor = System.Drawing.Color.Red
        Me.tUserId.ErrorMessage = Nothing
        Me.tUserId.Location = New System.Drawing.Point(159, 117)
        Me.tUserId.Name = "tUserId"
        Me.tUserId.Size = New System.Drawing.Size(188, 20)
        Me.tUserId.TabIndex = 1
        Me.tUserId.ValidationExpression = ""
        '
        'UseridDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.tDomain)
        Me.Controls.Add(Me.tPassword)
        Me.Controls.Add(Me.tUserId)
        Me.Controls.Add(Me.lDomain)
        Me.Controls.Add(Me.lPassword)
        Me.Controls.Add(Me.lUserId)
        Me.Controls.Add(Me.lDescription)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UseridDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter user credentials"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lDescription As System.Windows.Forms.Label
    Friend WithEvents lUserId As System.Windows.Forms.Label
    Friend WithEvents lPassword As System.Windows.Forms.Label
    Friend WithEvents lDomain As System.Windows.Forms.Label
    Friend WithEvents tUserId As WakeOnLan.Controls.RegExTextBox
    Friend WithEvents tPassword As WakeOnLan.Controls.RegExTextBox
    Friend WithEvents tDomain As WakeOnLan.Controls.RegExTextBox

End Class
