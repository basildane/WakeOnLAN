<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventLogViewer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventLogViewer))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnErrors = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnWarnings = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMessages = New System.Windows.Forms.ToolStripButton()
        Me.SourceSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SourceLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SourceCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.FindSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.FindLabel = New System.Windows.Forms.ToolStripLabel()
        Me.FindText = New System.Windows.Forms.ToolStripTextBox()
        Me.NotFoundLabel = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EventImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnErrors, Me.ButtonSeparator1, Me.btnWarnings, Me.ButtonSeparator2, Me.btnMessages, Me.SourceSeparator, Me.SourceLabel, Me.SourceCombo, Me.FindSeparator, Me.FindLabel, Me.FindText, Me.NotFoundLabel})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'btnErrors
        '
        Me.btnErrors.Checked = True
        Me.btnErrors.CheckOnClick = True
        Me.btnErrors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnErrors.Image = Global.autoFocus.Components.My.Resources.Resources.ErrorGif
        resources.ApplyResources(Me.btnErrors, "btnErrors")
        Me.btnErrors.Name = "btnErrors"
        '
        'ButtonSeparator1
        '
        Me.ButtonSeparator1.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.ButtonSeparator1.Name = "ButtonSeparator1"
        resources.ApplyResources(Me.ButtonSeparator1, "ButtonSeparator1")
        '
        'btnWarnings
        '
        Me.btnWarnings.Checked = True
        Me.btnWarnings.CheckOnClick = True
        Me.btnWarnings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnWarnings.Image = Global.autoFocus.Components.My.Resources.Resources.WarningGif
        resources.ApplyResources(Me.btnWarnings, "btnWarnings")
        Me.btnWarnings.Name = "btnWarnings"
        '
        'ButtonSeparator2
        '
        Me.ButtonSeparator2.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.ButtonSeparator2.Name = "ButtonSeparator2"
        resources.ApplyResources(Me.ButtonSeparator2, "ButtonSeparator2")
        '
        'btnMessages
        '
        Me.btnMessages.Checked = True
        Me.btnMessages.CheckOnClick = True
        Me.btnMessages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnMessages.Image = Global.autoFocus.Components.My.Resources.Resources.MessageGif
        resources.ApplyResources(Me.btnMessages, "btnMessages")
        Me.btnMessages.Name = "btnMessages"
        '
        'SourceSeparator
        '
        Me.SourceSeparator.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.SourceSeparator.Name = "SourceSeparator"
        resources.ApplyResources(Me.SourceSeparator, "SourceSeparator")
        '
        'SourceLabel
        '
        Me.SourceLabel.Name = "SourceLabel"
        resources.ApplyResources(Me.SourceLabel, "SourceLabel")
        '
        'SourceCombo
        '
        Me.SourceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.SourceCombo, "SourceCombo")
        Me.SourceCombo.Items.AddRange(New Object() {resources.GetString("SourceCombo.Items")})
        Me.SourceCombo.Margin = New System.Windows.Forms.Padding(1, 0, 2, 0)
        Me.SourceCombo.Name = "SourceCombo"
        Me.SourceCombo.Sorted = True
        '
        'FindSeparator
        '
        Me.FindSeparator.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.FindSeparator.Name = "FindSeparator"
        resources.ApplyResources(Me.FindSeparator, "FindSeparator")
        '
        'FindLabel
        '
        Me.FindLabel.Name = "FindLabel"
        resources.ApplyResources(Me.FindLabel, "FindLabel")
        '
        'FindText
        '
        Me.FindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FindText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FindText.Name = "FindText"
        Me.FindText.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        resources.ApplyResources(Me.FindText, "FindText")
        '
        'NotFoundLabel
        '
        Me.NotFoundLabel.Image = Global.autoFocus.Components.My.Resources.Resources.NotFoundGif
        Me.NotFoundLabel.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.NotFoundLabel.Name = "NotFoundLabel"
        resources.ApplyResources(Me.NotFoundLabel, "NotFoundLabel")
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EventImage})
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        '
        'EventImage
        '
        resources.ApplyResources(Me.EventImage, "EventImage")
        Me.EventImage.Name = "EventImage"
        Me.EventImage.ReadOnly = True
        Me.EventImage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EventImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EventLogViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "EventLogViewer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnErrors As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWarnings As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMessages As System.Windows.Forms.ToolStripButton
    Friend WithEvents SourceSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindText As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SourceCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ButtonSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotFoundLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SourceLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FindLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents EventImage As System.Windows.Forms.DataGridViewImageColumn

End Class
