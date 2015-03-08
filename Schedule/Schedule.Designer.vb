Namespace Schedule
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Schedule
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Schedule))
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.ListViewSchedule = New System.Windows.Forms.ListView()
            Me.NameColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.StatusColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TriggerColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.StateColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.NextColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.LastColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ResultColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.EndToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.EnableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
            Me.ToolStripButtonCreate = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripButtonEnable = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonDisable = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripButtonRun = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonStop = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripButtonProperties = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
            Me.timer = New System.Windows.Forms.Timer(Me.components)
            Me.CultureManager1 = New Localization.CultureManager(Me.components)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.ToolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewSchedule)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
            '
            'ListViewSchedule
            '
            Me.ListViewSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumnHeader, Me.StatusColumnHeader, Me.TriggerColumnHeader, Me.StateColumnHeader, Me.NextColumnHeader, Me.LastColumnHeader, Me.ResultColumnHeader})
            Me.ListViewSchedule.ContextMenuStrip = Me.ContextMenuStrip1
            resources.ApplyResources(Me.ListViewSchedule, "ListViewSchedule")
            Me.ListViewSchedule.FullRowSelect = True
            Me.ListViewSchedule.Name = "ListViewSchedule"
            Me.ListViewSchedule.SmallImageList = Me.ImageList1
            Me.ListViewSchedule.UseCompatibleStateImageBehavior = False
            Me.ListViewSchedule.View = System.Windows.Forms.View.Details
            '
            'NameColumnHeader
            '
            resources.ApplyResources(Me.NameColumnHeader, "NameColumnHeader")
            '
            'StatusColumnHeader
            '
            resources.ApplyResources(Me.StatusColumnHeader, "StatusColumnHeader")
            '
            'TriggerColumnHeader
            '
            resources.ApplyResources(Me.TriggerColumnHeader, "TriggerColumnHeader")
            '
            'StateColumnHeader
            '
            resources.ApplyResources(Me.StateColumnHeader, "StateColumnHeader")
            '
            'NextColumnHeader
            '
            resources.ApplyResources(Me.NextColumnHeader, "NextColumnHeader")
            '
            'LastColumnHeader
            '
            resources.ApplyResources(Me.LastColumnHeader, "LastColumnHeader")
            '
            'ResultColumnHeader
            '
            resources.ApplyResources(Me.ResultColumnHeader, "ResultColumnHeader")
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripMenuItem, Me.EndToolStripMenuItem, Me.DisableToolStripMenuItem, Me.EnableToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.NewToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
            '
            'RunToolStripMenuItem
            '
            Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
            resources.ApplyResources(Me.RunToolStripMenuItem, "RunToolStripMenuItem")
            '
            'EndToolStripMenuItem
            '
            Me.EndToolStripMenuItem.Name = "EndToolStripMenuItem"
            resources.ApplyResources(Me.EndToolStripMenuItem, "EndToolStripMenuItem")
            '
            'DisableToolStripMenuItem
            '
            Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
            resources.ApplyResources(Me.DisableToolStripMenuItem, "DisableToolStripMenuItem")
            '
            'EnableToolStripMenuItem
            '
            Me.EnableToolStripMenuItem.Name = "EnableToolStripMenuItem"
            resources.ApplyResources(Me.EnableToolStripMenuItem, "EnableToolStripMenuItem")
            '
            'DeleteToolStripMenuItem
            '
            Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
            resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
            '
            'NewToolStripMenuItem
            '
            Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
            resources.ApplyResources(Me.NewToolStripMenuItem, "NewToolStripMenuItem")
            '
            'ImageList1
            '
            Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
            Me.ImageList1.Images.SetKeyName(0, "clock")
            '
            'ToolStrip1
            '
            resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButtonCreate, Me.ToolStripSeparator1, Me.ToolStripButtonEnable, Me.ToolStripButtonDisable, Me.ToolStripSeparator2, Me.ToolStripButtonRun, Me.ToolStripButtonStop, Me.ToolStripSeparator3, Me.ToolStripButtonProperties, Me.ToolStripButtonDelete})
            Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
            Me.ToolStrip1.Name = "ToolStrip1"
            '
            'ToolStripLabel1
            '
            Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
            Me.ToolStripLabel1.Name = "ToolStripLabel1"
            '
            'ToolStripButtonCreate
            '
            resources.ApplyResources(Me.ToolStripButtonCreate, "ToolStripButtonCreate")
            Me.ToolStripButtonCreate.Name = "ToolStripButtonCreate"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
            '
            'ToolStripButtonEnable
            '
            resources.ApplyResources(Me.ToolStripButtonEnable, "ToolStripButtonEnable")
            Me.ToolStripButtonEnable.Name = "ToolStripButtonEnable"
            '
            'ToolStripButtonDisable
            '
            resources.ApplyResources(Me.ToolStripButtonDisable, "ToolStripButtonDisable")
            Me.ToolStripButtonDisable.Name = "ToolStripButtonDisable"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
            '
            'ToolStripButtonRun
            '
            resources.ApplyResources(Me.ToolStripButtonRun, "ToolStripButtonRun")
            Me.ToolStripButtonRun.Name = "ToolStripButtonRun"
            '
            'ToolStripButtonStop
            '
            resources.ApplyResources(Me.ToolStripButtonStop, "ToolStripButtonStop")
            Me.ToolStripButtonStop.Name = "ToolStripButtonStop"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
            '
            'ToolStripButtonProperties
            '
            resources.ApplyResources(Me.ToolStripButtonProperties, "ToolStripButtonProperties")
            Me.ToolStripButtonProperties.Name = "ToolStripButtonProperties"
            '
            'ToolStripButtonDelete
            '
            resources.ApplyResources(Me.ToolStripButtonDelete, "ToolStripButtonDelete")
            Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
            '
            'timer
            '
            Me.timer.Interval = 1000
            '
            'CultureManager1
            '
            Me.CultureManager1.ManagedControl = Me
            '
            'Schedule
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.SplitContainer1)
            Me.Name = "Schedule"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.Panel2.PerformLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ListViewSchedule As System.Windows.Forms.ListView
        Friend WithEvents NameColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents StatusColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents NextColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents LastColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents ResultColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents EndToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DisableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents EnableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents StateColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents timer As System.Windows.Forms.Timer
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripButtonDelete As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonCreate As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonEnable As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonDisable As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonRun As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonStop As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButtonProperties As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
        Friend WithEvents TriggerColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents CultureManager1 As Localization.CultureManager
    End Class
End Namespace