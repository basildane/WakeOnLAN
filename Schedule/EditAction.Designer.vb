<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditAction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAction))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ActionComboBox = New System.Windows.Forms.ComboBox()
        Me.ComputerGroupBox = New System.Windows.Forms.GroupBox()
        Me.forceCheckBox = New System.Windows.Forms.CheckBox()
        Me.MachinesComboBox = New System.Windows.Forms.ComboBox()
        Me.MessageGroupBox = New System.Windows.Forms.GroupBox()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.MessageTitleTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EmailGroupBox = New System.Windows.Forms.GroupBox()
        Me.EmailServerTextBox = New System.Windows.Forms.TextBox()
        Me.EmailSubjectTextBox = New System.Windows.Forms.TextBox()
        Me.EmailToTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EmailMessageTextBox = New System.Windows.Forms.TextBox()
        Me.EmailFromTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AllGroupBox = New System.Windows.Forms.GroupBox()
        Me.forceAll = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ComputerGroupBox.SuspendLayout()
        Me.MessageGroupBox.SuspendLayout()
        Me.EmailGroupBox.SuspendLayout()
        Me.AllGroupBox.SuspendLayout()
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
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ActionComboBox
        '
        resources.ApplyResources(Me.ActionComboBox, "ActionComboBox")
        Me.ActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ActionComboBox.FormattingEnabled = True
        Me.ActionComboBox.Name = "ActionComboBox"
        '
        'ComputerGroupBox
        '
        resources.ApplyResources(Me.ComputerGroupBox, "ComputerGroupBox")
        Me.ComputerGroupBox.Controls.Add(Me.forceCheckBox)
        Me.ComputerGroupBox.Controls.Add(Me.MachinesComboBox)
        Me.ComputerGroupBox.Name = "ComputerGroupBox"
        Me.ComputerGroupBox.TabStop = False
        '
        'forceCheckBox
        '
        resources.ApplyResources(Me.forceCheckBox, "forceCheckBox")
        Me.forceCheckBox.Name = "forceCheckBox"
        Me.forceCheckBox.UseVisualStyleBackColor = True
        '
        'MachinesComboBox
        '
        resources.ApplyResources(Me.MachinesComboBox, "MachinesComboBox")
        Me.MachinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachinesComboBox.FormattingEnabled = True
        Me.MachinesComboBox.Name = "MachinesComboBox"
        '
        'MessageGroupBox
        '
        resources.ApplyResources(Me.MessageGroupBox, "MessageGroupBox")
        Me.MessageGroupBox.Controls.Add(Me.MessageTextBox)
        Me.MessageGroupBox.Controls.Add(Me.MessageTitleTextBox)
        Me.MessageGroupBox.Controls.Add(Me.Label3)
        Me.MessageGroupBox.Controls.Add(Me.Label2)
        Me.MessageGroupBox.Name = "MessageGroupBox"
        Me.MessageGroupBox.TabStop = False
        '
        'MessageTextBox
        '
        resources.ApplyResources(Me.MessageTextBox, "MessageTextBox")
        Me.MessageTextBox.Name = "MessageTextBox"
        '
        'MessageTitleTextBox
        '
        resources.ApplyResources(Me.MessageTitleTextBox, "MessageTitleTextBox")
        Me.MessageTitleTextBox.Name = "MessageTitleTextBox"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'EmailGroupBox
        '
        resources.ApplyResources(Me.EmailGroupBox, "EmailGroupBox")
        Me.EmailGroupBox.Controls.Add(Me.EmailServerTextBox)
        Me.EmailGroupBox.Controls.Add(Me.EmailSubjectTextBox)
        Me.EmailGroupBox.Controls.Add(Me.EmailToTextBox)
        Me.EmailGroupBox.Controls.Add(Me.Label8)
        Me.EmailGroupBox.Controls.Add(Me.Label7)
        Me.EmailGroupBox.Controls.Add(Me.Label6)
        Me.EmailGroupBox.Controls.Add(Me.EmailMessageTextBox)
        Me.EmailGroupBox.Controls.Add(Me.EmailFromTextBox)
        Me.EmailGroupBox.Controls.Add(Me.Label4)
        Me.EmailGroupBox.Controls.Add(Me.Label5)
        Me.EmailGroupBox.Name = "EmailGroupBox"
        Me.EmailGroupBox.TabStop = False
        '
        'EmailServerTextBox
        '
        resources.ApplyResources(Me.EmailServerTextBox, "EmailServerTextBox")
        Me.EmailServerTextBox.Name = "EmailServerTextBox"
        '
        'EmailSubjectTextBox
        '
        resources.ApplyResources(Me.EmailSubjectTextBox, "EmailSubjectTextBox")
        Me.EmailSubjectTextBox.Name = "EmailSubjectTextBox"
        '
        'EmailToTextBox
        '
        resources.ApplyResources(Me.EmailToTextBox, "EmailToTextBox")
        Me.EmailToTextBox.Name = "EmailToTextBox"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'EmailMessageTextBox
        '
        resources.ApplyResources(Me.EmailMessageTextBox, "EmailMessageTextBox")
        Me.EmailMessageTextBox.Name = "EmailMessageTextBox"
        '
        'EmailFromTextBox
        '
        resources.ApplyResources(Me.EmailFromTextBox, "EmailFromTextBox")
        Me.EmailFromTextBox.Name = "EmailFromTextBox"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'AllGroupBox
        '
        resources.ApplyResources(Me.AllGroupBox, "AllGroupBox")
        Me.AllGroupBox.Controls.Add(Me.forceAll)
        Me.AllGroupBox.Name = "AllGroupBox"
        Me.AllGroupBox.TabStop = False
        '
        'forceAll
        '
        resources.ApplyResources(Me.forceAll, "forceAll")
        Me.forceAll.Name = "forceAll"
        Me.forceAll.UseVisualStyleBackColor = True
        '
        'EditAction
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.ActionComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ComputerGroupBox)
        Me.Controls.Add(Me.EmailGroupBox)
        Me.Controls.Add(Me.MessageGroupBox)
        Me.Controls.Add(Me.AllGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditAction"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ComputerGroupBox.ResumeLayout(False)
        Me.ComputerGroupBox.PerformLayout()
        Me.MessageGroupBox.ResumeLayout(False)
        Me.MessageGroupBox.PerformLayout()
        Me.EmailGroupBox.ResumeLayout(False)
        Me.EmailGroupBox.PerformLayout()
        Me.AllGroupBox.ResumeLayout(False)
        Me.AllGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ActionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ComputerGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MachinesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MessageGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MessageTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EmailGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents EmailMessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailFromTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EmailServerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailSubjectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailToTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents forceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AllGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents forceAll As System.Windows.Forms.CheckBox

End Class
