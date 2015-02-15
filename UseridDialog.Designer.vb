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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UseridDialog))
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
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'lDescription
        '
        resources.ApplyResources(Me.lDescription, "lDescription")
        Me.lDescription.Name = "lDescription"
        '
        'lUserId
        '
        resources.ApplyResources(Me.lUserId, "lUserId")
        Me.lUserId.Name = "lUserId"
        '
        'lPassword
        '
        resources.ApplyResources(Me.lPassword, "lPassword")
        Me.lPassword.Name = "lPassword"
        '
        'lDomain
        '
        resources.ApplyResources(Me.lDomain, "lDomain")
        Me.lDomain.Name = "lDomain"
        '
        'tDomain
        '
        Me.tDomain.ErrorColor = System.Drawing.Color.Red
        Me.tDomain.ErrorMessage = Nothing
        resources.ApplyResources(Me.tDomain, "tDomain")
        Me.tDomain.Name = "tDomain"
        Me.tDomain.ValidationExpression = ""
        '
        'tPassword
        '
        Me.tPassword.ErrorColor = System.Drawing.Color.Red
        Me.tPassword.ErrorMessage = Nothing
        resources.ApplyResources(Me.tPassword, "tPassword")
        Me.tPassword.Name = "tPassword"
        Me.tPassword.ValidationExpression = ""
        '
        'tUserId
        '
        Me.tUserId.ErrorColor = System.Drawing.Color.Red
        Me.tUserId.ErrorMessage = Nothing
        resources.ApplyResources(Me.tUserId, "tUserId")
        Me.tUserId.Name = "tUserId"
        Me.tUserId.ValidationExpression = ""
        '
        'UseridDialog
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
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
