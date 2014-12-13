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
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 1, 1)
        Me.ToolStrip1.Size = New System.Drawing.Size(728, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnErrors
        '
        Me.btnErrors.Checked = True
        Me.btnErrors.CheckOnClick = True
        Me.btnErrors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnErrors.Image = Global.autoFocus.Components.My.Resources.Resources.ErrorGif
        Me.btnErrors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnErrors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnErrors.Name = "btnErrors"
        Me.btnErrors.Size = New System.Drawing.Size(64, 20)
        Me.btnErrors.Text = "0 Errors"
        Me.btnErrors.ToolTipText = "0 Errors"
        '
        'ButtonSeparator1
        '
        Me.ButtonSeparator1.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.ButtonSeparator1.Name = "ButtonSeparator1"
        Me.ButtonSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnWarnings
        '
        Me.btnWarnings.Checked = True
        Me.btnWarnings.CheckOnClick = True
        Me.btnWarnings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnWarnings.Image = Global.autoFocus.Components.My.Resources.Resources.WarningGif
        Me.btnWarnings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnWarnings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWarnings.Name = "btnWarnings"
        Me.btnWarnings.Size = New System.Drawing.Size(86, 20)
        Me.btnWarnings.Text = "0 Warnings"
        Me.btnWarnings.ToolTipText = "0 Warnings"
        '
        'ButtonSeparator2
        '
        Me.ButtonSeparator2.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.ButtonSeparator2.Name = "ButtonSeparator2"
        Me.ButtonSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnMessages
        '
        Me.btnMessages.Checked = True
        Me.btnMessages.CheckOnClick = True
        Me.btnMessages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnMessages.Image = Global.autoFocus.Components.My.Resources.Resources.MessageGif
        Me.btnMessages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMessages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMessages.Name = "btnMessages"
        Me.btnMessages.Size = New System.Drawing.Size(86, 20)
        Me.btnMessages.Text = "0 Messages"
        Me.btnMessages.ToolTipText = "0 Messages"
        '
        'SourceSeparator
        '
        Me.SourceSeparator.Margin = New System.Windows.Forms.Padding(-1, 0, 1, 0)
        Me.SourceSeparator.Name = "SourceSeparator"
        Me.SourceSeparator.Size = New System.Drawing.Size(6, 23)
        '
        'SourceLabel
        '
        Me.SourceLabel.Name = "SourceLabel"
        Me.SourceLabel.Size = New System.Drawing.Size(46, 20)
        Me.SourceLabel.Text = "Source:"
        '
        'SourceCombo
        '
        Me.SourceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SourceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.SourceCombo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SourceCombo.Items.AddRange(New Object() {" "})
        Me.SourceCombo.Margin = New System.Windows.Forms.Padding(1, 0, 2, 0)
        Me.SourceCombo.Name = "SourceCombo"
        Me.SourceCombo.Size = New System.Drawing.Size(100, 23)
        Me.SourceCombo.Sorted = True
        '
        'FindSeparator
        '
        Me.FindSeparator.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.FindSeparator.Name = "FindSeparator"
        Me.FindSeparator.Size = New System.Drawing.Size(6, 23)
        '
        'FindLabel
        '
        Me.FindLabel.Name = "FindLabel"
        Me.FindLabel.Size = New System.Drawing.Size(33, 20)
        Me.FindLabel.Text = "Find:"
        '
        'FindText
        '
        Me.FindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FindText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FindText.Name = "FindText"
        Me.FindText.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.FindText.Size = New System.Drawing.Size(80, 23)
        '
        'NotFoundLabel
        '
        Me.NotFoundLabel.Image = Global.autoFocus.Components.My.Resources.Resources.NotFoundGif
        Me.NotFoundLabel.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.NotFoundLabel.Name = "NotFoundLabel"
        Me.NotFoundLabel.Size = New System.Drawing.Size(111, 20)
        Me.NotFoundLabel.Text = "No events found"
        Me.NotFoundLabel.ToolTipText = "There are no events that match the defined filter."
        Me.NotFoundLabel.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EventImage})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 26)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(728, 320)
        Me.DataGridView1.TabIndex = 5
        '
        'EventImage
        '
        Me.EventImage.HeaderText = ""
        Me.EventImage.Name = "EventImage"
        Me.EventImage.ReadOnly = True
        Me.EventImage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EventImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EventLogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "EventLogViewer"
        Me.Size = New System.Drawing.Size(728, 346)
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
