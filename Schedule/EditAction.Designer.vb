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
        Me.RebootCheckBox = New System.Windows.Forms.CheckBox()
        Me.forceCheckBox = New System.Windows.Forms.CheckBox()
        Me.MachinesComboBox = New System.Windows.Forms.ComboBox()
        Me.ComboBoxPopupMachine = New System.Windows.Forms.ComboBox()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.MessageTitleTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SelectTabPage = New System.Windows.Forms.TabPage()
        Me.SelectLabel = New System.Windows.Forms.Label()
        Me.EmailTabPage = New System.Windows.Forms.TabPage()
        Me.EmailLabel = New System.Windows.Forms.Label()
        Me.PopupTabPage = New System.Windows.Forms.TabPage()
        Me.PopupLabel = New System.Windows.Forms.Label()
        Me.AllTabPage = New System.Windows.Forms.TabPage()
        Me.AllLabel = New System.Windows.Forms.Label()
        Me.RebootAll = New System.Windows.Forms.CheckBox()
        Me.forceAll = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SelectTabPage.SuspendLayout()
        Me.EmailTabPage.SuspendLayout()
        Me.PopupTabPage.SuspendLayout()
        Me.AllTabPage.SuspendLayout()
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
        'RebootCheckBox
        '
        resources.ApplyResources(Me.RebootCheckBox, "RebootCheckBox")
        Me.RebootCheckBox.Name = "RebootCheckBox"
        Me.RebootCheckBox.UseVisualStyleBackColor = True
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
        'ComboBoxPopupMachine
        '
        resources.ApplyResources(Me.ComboBoxPopupMachine, "ComboBoxPopupMachine")
        Me.ComboBoxPopupMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPopupMachine.FormattingEnabled = True
        Me.ComboBoxPopupMachine.Name = "ComboBoxPopupMachine"
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
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.SelectTabPage)
        Me.TabControl1.Controls.Add(Me.EmailTabPage)
        Me.TabControl1.Controls.Add(Me.PopupTabPage)
        Me.TabControl1.Controls.Add(Me.AllTabPage)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'SelectTabPage
        '
        resources.ApplyResources(Me.SelectTabPage, "SelectTabPage")
        Me.SelectTabPage.Controls.Add(Me.SelectLabel)
        Me.SelectTabPage.Controls.Add(Me.RebootCheckBox)
        Me.SelectTabPage.Controls.Add(Me.MachinesComboBox)
        Me.SelectTabPage.Controls.Add(Me.forceCheckBox)
        Me.SelectTabPage.Name = "SelectTabPage"
        Me.SelectTabPage.UseVisualStyleBackColor = True
        '
        'SelectLabel
        '
        resources.ApplyResources(Me.SelectLabel, "SelectLabel")
        Me.SelectLabel.Name = "SelectLabel"
        '
        'EmailTabPage
        '
        resources.ApplyResources(Me.EmailTabPage, "EmailTabPage")
        Me.EmailTabPage.Controls.Add(Me.EmailLabel)
        Me.EmailTabPage.Controls.Add(Me.EmailServerTextBox)
        Me.EmailTabPage.Controls.Add(Me.EmailMessageTextBox)
        Me.EmailTabPage.Controls.Add(Me.EmailSubjectTextBox)
        Me.EmailTabPage.Controls.Add(Me.Label5)
        Me.EmailTabPage.Controls.Add(Me.EmailToTextBox)
        Me.EmailTabPage.Controls.Add(Me.Label4)
        Me.EmailTabPage.Controls.Add(Me.Label8)
        Me.EmailTabPage.Controls.Add(Me.EmailFromTextBox)
        Me.EmailTabPage.Controls.Add(Me.Label7)
        Me.EmailTabPage.Controls.Add(Me.Label6)
        Me.EmailTabPage.Name = "EmailTabPage"
        Me.EmailTabPage.UseVisualStyleBackColor = True
        '
        'EmailLabel
        '
        resources.ApplyResources(Me.EmailLabel, "EmailLabel")
        Me.EmailLabel.Name = "EmailLabel"
        '
        'PopupTabPage
        '
        resources.ApplyResources(Me.PopupTabPage, "PopupTabPage")
        Me.PopupTabPage.Controls.Add(Me.PopupLabel)
        Me.PopupTabPage.Controls.Add(Me.ComboBoxPopupMachine)
        Me.PopupTabPage.Controls.Add(Me.MessageTextBox)
        Me.PopupTabPage.Controls.Add(Me.Label2)
        Me.PopupTabPage.Controls.Add(Me.MessageTitleTextBox)
        Me.PopupTabPage.Controls.Add(Me.Label3)
        Me.PopupTabPage.Name = "PopupTabPage"
        Me.PopupTabPage.UseVisualStyleBackColor = True
        '
        'PopupLabel
        '
        resources.ApplyResources(Me.PopupLabel, "PopupLabel")
        Me.PopupLabel.Name = "PopupLabel"
        '
        'AllTabPage
        '
        resources.ApplyResources(Me.AllTabPage, "AllTabPage")
        Me.AllTabPage.Controls.Add(Me.AllLabel)
        Me.AllTabPage.Controls.Add(Me.RebootAll)
        Me.AllTabPage.Controls.Add(Me.forceAll)
        Me.AllTabPage.Name = "AllTabPage"
        Me.AllTabPage.UseVisualStyleBackColor = True
        '
        'AllLabel
        '
        resources.ApplyResources(Me.AllLabel, "AllLabel")
        Me.AllLabel.Name = "AllLabel"
        '
        'RebootAll
        '
        resources.ApplyResources(Me.RebootAll, "RebootAll")
        Me.RebootAll.Name = "RebootAll"
        Me.RebootAll.UseVisualStyleBackColor = True
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
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ActionComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditAction"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.SelectTabPage.ResumeLayout(False)
        Me.SelectTabPage.PerformLayout()
        Me.EmailTabPage.ResumeLayout(False)
        Me.EmailTabPage.PerformLayout()
        Me.PopupTabPage.ResumeLayout(False)
        Me.PopupTabPage.PerformLayout()
        Me.AllTabPage.ResumeLayout(False)
        Me.AllTabPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ActionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MachinesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MessageTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents RebootCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxPopupMachine As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents SelectTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EmailTabPage As System.Windows.Forms.TabPage
    Friend WithEvents PopupTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AllTabPage As System.Windows.Forms.TabPage
    Friend WithEvents RebootAll As System.Windows.Forms.CheckBox
    Friend WithEvents forceAll As System.Windows.Forms.CheckBox
    Friend WithEvents SelectLabel As System.Windows.Forms.Label
    Friend WithEvents EmailLabel As System.Windows.Forms.Label
    Friend WithEvents PopupLabel As System.Windows.Forms.Label
    Friend WithEvents AllLabel As System.Windows.Forms.Label

End Class
