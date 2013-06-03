<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditTask))
        Me.TabControlTasks = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UserIDTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListViewTriggers = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TriggerDeleteButton = New System.Windows.Forms.Button()
        Me.TriggerEditButton = New System.Windows.Forms.Button()
        Me.TriggerNewButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ActionDeleteButton = New System.Windows.Forms.Button()
        Me.ActionEditButton = New System.Windows.Forms.Button()
        Me.ActionNewButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListViewActions = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TabControlTasks.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlTasks
        '
        resources.ApplyResources(Me.TabControlTasks, "TabControlTasks")
        Me.TabControlTasks.Controls.Add(Me.TabPage1)
        Me.TabControlTasks.Controls.Add(Me.TabPage2)
        Me.TabControlTasks.Controls.Add(Me.TabPage3)
        Me.TabControlTasks.Name = "TabControlTasks"
        Me.TabControlTasks.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.DescriptionTextBox)
        Me.TabPage1.Controls.Add(Me.NameTextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.UserIDTextBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'PasswordTextBox
        '
        resources.ApplyResources(Me.PasswordTextBox, "PasswordTextBox")
        Me.PasswordTextBox.Name = "PasswordTextBox"
        '
        'UserIDTextBox
        '
        resources.ApplyResources(Me.UserIDTextBox, "UserIDTextBox")
        Me.UserIDTextBox.Name = "UserIDTextBox"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'DescriptionTextBox
        '
        resources.ApplyResources(Me.DescriptionTextBox, "DescriptionTextBox")
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        '
        'NameTextBox
        '
        resources.ApplyResources(Me.NameTextBox, "NameTextBox")
        Me.NameTextBox.Name = "NameTextBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Controls.Add(Me.ListViewTriggers)
        Me.TabPage2.Controls.Add(Me.TriggerDeleteButton)
        Me.TabPage2.Controls.Add(Me.TriggerEditButton)
        Me.TabPage2.Controls.Add(Me.TriggerNewButton)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListViewTriggers
        '
        resources.ApplyResources(Me.ListViewTriggers, "ListViewTriggers")
        Me.ListViewTriggers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewTriggers.FullRowSelect = True
        Me.ListViewTriggers.Name = "ListViewTriggers"
        Me.ListViewTriggers.UseCompatibleStateImageBehavior = False
        Me.ListViewTriggers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'TriggerDeleteButton
        '
        resources.ApplyResources(Me.TriggerDeleteButton, "TriggerDeleteButton")
        Me.TriggerDeleteButton.Name = "TriggerDeleteButton"
        Me.TriggerDeleteButton.UseVisualStyleBackColor = True
        '
        'TriggerEditButton
        '
        resources.ApplyResources(Me.TriggerEditButton, "TriggerEditButton")
        Me.TriggerEditButton.Name = "TriggerEditButton"
        Me.TriggerEditButton.UseVisualStyleBackColor = True
        '
        'TriggerNewButton
        '
        resources.ApplyResources(Me.TriggerNewButton, "TriggerNewButton")
        Me.TriggerNewButton.Name = "TriggerNewButton"
        Me.TriggerNewButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'TabPage3
        '
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Controls.Add(Me.ActionDeleteButton)
        Me.TabPage3.Controls.Add(Me.ActionEditButton)
        Me.TabPage3.Controls.Add(Me.ActionNewButton)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.ListViewActions)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ActionDeleteButton
        '
        resources.ApplyResources(Me.ActionDeleteButton, "ActionDeleteButton")
        Me.ActionDeleteButton.Name = "ActionDeleteButton"
        Me.ActionDeleteButton.UseVisualStyleBackColor = True
        '
        'ActionEditButton
        '
        resources.ApplyResources(Me.ActionEditButton, "ActionEditButton")
        Me.ActionEditButton.Name = "ActionEditButton"
        Me.ActionEditButton.UseVisualStyleBackColor = True
        '
        'ActionNewButton
        '
        resources.ApplyResources(Me.ActionNewButton, "ActionNewButton")
        Me.ActionNewButton.Name = "ActionNewButton"
        Me.ActionNewButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'ListViewActions
        '
        resources.ApplyResources(Me.ListViewActions, "ListViewActions")
        Me.ListViewActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewActions.FullRowSelect = True
        Me.ListViewActions.Name = "ListViewActions"
        Me.ListViewActions.UseCompatibleStateImageBehavior = False
        Me.ListViewActions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'EditTask
        '
        Me.AcceptButton = Me.OKButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.TabControlTasks)
        Me.Name = "EditTask"
        Me.TabControlTasks.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlTasks As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ActionDeleteButton As System.Windows.Forms.Button
    Friend WithEvents ActionEditButton As System.Windows.Forms.Button
    Friend WithEvents ActionNewButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListViewActions As System.Windows.Forms.ListView
    Friend WithEvents ListViewTriggers As System.Windows.Forms.ListView
    Friend WithEvents TriggerDeleteButton As System.Windows.Forms.Button
    Friend WithEvents TriggerEditButton As System.Windows.Forms.Button
    Friend WithEvents TriggerNewButton As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
