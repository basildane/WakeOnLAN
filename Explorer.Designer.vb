<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Explorer
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

    Friend WithEvents ToolStripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TreeNodeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FoldersToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView As System.Windows.Forms.TreeView
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ListViewLargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListViewSmallImageList As System.Windows.Forms.ImageList

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer))
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TreeView = New System.Windows.Forms.TreeView()
        Me.TreeViewContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WakeUpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutDownToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeNodeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListView = New System.Windows.Forms.ListView()
        Me.MachineName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IPAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Netbios = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Note = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Group = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip_Machines = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WakeUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RDPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListViewLargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewSmallImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Button_Emergency = New System.Windows.Forms.Button()
        Me.Button_StartAll = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowHotButtonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EventLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MinimizeToTaskTrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoStartWithWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetWindowLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchForMachinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.DonateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.FoldersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListViewToolStripButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ContextMenuStripViews = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ListToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PingToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ScheduleToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ListenerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EventLogToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OptionsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.HotToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripMenuItemWakeUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStripTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextToolStripMenuItemOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetWindowLayoutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerPing = New System.Windows.Forms.Timer(Me.components)
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIconUpdate = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CultureManager = New Localization.CultureManager(Me.components)
        Me.TimerUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TreeViewContextMenuStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip_Machines.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ContextMenuStripViews.SuspendLayout()
        Me.ContextMenuStripTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer
        '
        resources.ApplyResources(Me.ToolStripContainer, "ToolStripContainer")
        '
        'ToolStripContainer.BottomToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.BottomToolStripPanel, "ToolStripContainer.BottomToolStripPanel")
        Me.ToolStripContainer.BottomToolStripPanel.Controls.Add(Me.StatusStrip)
        Me.ToolTip.SetToolTip(Me.ToolStripContainer.BottomToolStripPanel, resources.GetString("ToolStripContainer.BottomToolStripPanel.ToolTip"))
        '
        'ToolStripContainer.ContentPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.ContentPanel, "ToolStripContainer.ContentPanel")
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.SplitContainer)
        Me.ToolTip.SetToolTip(Me.ToolStripContainer.ContentPanel, resources.GetString("ToolStripContainer.ContentPanel.ToolTip"))
        '
        'ToolStripContainer.LeftToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.LeftToolStripPanel, "ToolStripContainer.LeftToolStripPanel")
        Me.ToolTip.SetToolTip(Me.ToolStripContainer.LeftToolStripPanel, resources.GetString("ToolStripContainer.LeftToolStripPanel.ToolTip"))
        Me.ToolStripContainer.Name = "ToolStripContainer"
        '
        'ToolStripContainer.RightToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.RightToolStripPanel, "ToolStripContainer.RightToolStripPanel")
        Me.ToolTip.SetToolTip(Me.ToolStripContainer.RightToolStripPanel, resources.GetString("ToolStripContainer.RightToolStripPanel.ToolTip"))
        Me.ToolTip.SetToolTip(Me.ToolStripContainer, resources.GetString("ToolStripContainer.ToolTip"))
        '
        'ToolStripContainer.TopToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.TopToolStripPanel, "ToolStripContainer.TopToolStripPanel")
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.MenuStrip)
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.ToolStrip)
        Me.ToolTip.SetToolTip(Me.ToolStripContainer.TopToolStripPanel, resources.GetString("ToolStripContainer.TopToolStripPanel.ToolTip"))
        '
        'StatusStrip
        '
        resources.ApplyResources(Me.StatusStrip, "StatusStrip")
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1})
        Me.StatusStrip.Name = "StatusStrip"
        Me.ToolTip.SetToolTip(Me.StatusStrip, resources.GetString("StatusStrip.ToolTip"))
        '
        'ToolStripStatusLabel1
        '
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Spring = True
        '
        'ToolStripProgressBar1
        '
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        Me.ToolStripProgressBar1.Maximum = 10
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        '
        'SplitContainer
        '
        resources.ApplyResources(Me.SplitContainer, "SplitContainer")
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        resources.ApplyResources(Me.SplitContainer.Panel1, "SplitContainer.Panel1")
        Me.SplitContainer.Panel1.Controls.Add(Me.TreeView)
        Me.ToolTip.SetToolTip(Me.SplitContainer.Panel1, resources.GetString("SplitContainer.Panel1.ToolTip"))
        '
        'SplitContainer.Panel2
        '
        resources.ApplyResources(Me.SplitContainer.Panel2, "SplitContainer.Panel2")
        Me.SplitContainer.Panel2.Controls.Add(Me.SplitContainer1)
        Me.ToolTip.SetToolTip(Me.SplitContainer.Panel2, resources.GetString("SplitContainer.Panel2.ToolTip"))
        Me.ToolTip.SetToolTip(Me.SplitContainer, resources.GetString("SplitContainer.ToolTip"))
        '
        'TreeView
        '
        resources.ApplyResources(Me.TreeView, "TreeView")
        Me.TreeView.ContextMenuStrip = Me.TreeViewContextMenuStrip
        Me.TreeView.ImageList = Me.TreeNodeImageList
        Me.TreeView.Name = "TreeView"
        Me.TreeView.ShowLines = False
        Me.ToolTip.SetToolTip(Me.TreeView, resources.GetString("TreeView.ToolTip"))
        '
        'TreeViewContextMenuStrip
        '
        resources.ApplyResources(Me.TreeViewContextMenuStrip, "TreeViewContextMenuStrip")
        Me.TreeViewContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WakeUpToolStripMenuItem1, Me.ShutDownToolStripMenuItem1})
        Me.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip"
        Me.ToolTip.SetToolTip(Me.TreeViewContextMenuStrip, resources.GetString("TreeViewContextMenuStrip.ToolTip"))
        '
        'WakeUpToolStripMenuItem1
        '
        resources.ApplyResources(Me.WakeUpToolStripMenuItem1, "WakeUpToolStripMenuItem1")
        Me.WakeUpToolStripMenuItem1.Name = "WakeUpToolStripMenuItem1"
        '
        'ShutDownToolStripMenuItem1
        '
        resources.ApplyResources(Me.ShutDownToolStripMenuItem1, "ShutDownToolStripMenuItem1")
        Me.ShutDownToolStripMenuItem1.Name = "ShutDownToolStripMenuItem1"
        '
        'TreeNodeImageList
        '
        Me.TreeNodeImageList.ImageStream = CType(resources.GetObject("TreeNodeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeNodeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeNodeImageList.Images.SetKeyName(0, "ClosedFolder")
        Me.TreeNodeImageList.Images.SetKeyName(1, "OpenFolder")
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        resources.ApplyResources(Me.SplitContainer1.Panel1, "SplitContainer1.Panel1")
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView)
        Me.ToolTip.SetToolTip(Me.SplitContainer1.Panel1, resources.GetString("SplitContainer1.Panel1.ToolTip"))
        '
        'SplitContainer1.Panel2
        '
        resources.ApplyResources(Me.SplitContainer1.Panel2, "SplitContainer1.Panel2")
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button_Emergency)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button_StartAll)
        Me.ToolTip.SetToolTip(Me.SplitContainer1.Panel2, resources.GetString("SplitContainer1.Panel2.ToolTip"))
        Me.ToolTip.SetToolTip(Me.SplitContainer1, resources.GetString("SplitContainer1.ToolTip"))
        '
        'ListView
        '
        resources.ApplyResources(Me.ListView, "ListView")
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.MachineName, Me.Status, Me.IPAddress, Me.Netbios, Me.Note, Me.Group})
        Me.ListView.ContextMenuStrip = Me.ContextMenuStrip_Machines
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("ListView.Groups"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListView.Groups1"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListView.Groups2"), System.Windows.Forms.ListViewGroup)})
        Me.ListView.LargeImageList = Me.ListViewLargeImageList
        Me.ListView.Name = "ListView"
        Me.ListView.SmallImageList = Me.ListViewSmallImageList
        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ToolTip.SetToolTip(Me.ListView, resources.GetString("ListView.ToolTip"))
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'MachineName
        '
        resources.ApplyResources(Me.MachineName, "MachineName")
        '
        'Status
        '
        resources.ApplyResources(Me.Status, "Status")
        '
        'IPAddress
        '
        resources.ApplyResources(Me.IPAddress, "IPAddress")
        '
        'Netbios
        '
        resources.ApplyResources(Me.Netbios, "Netbios")
        '
        'Note
        '
        resources.ApplyResources(Me.Note, "Note")
        '
        'Group
        '
        resources.ApplyResources(Me.Group, "Group")
        '
        'ContextMenuStrip_Machines
        '
        resources.ApplyResources(Me.ContextMenuStrip_Machines, "ContextMenuStrip_Machines")
        Me.ContextMenuStrip_Machines.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WakeUpToolStripMenuItem, Me.ShutdownToolStripMenuItem, Me.ToolStripSeparator10, Me.NewToolStripMenuItem1, Me.RDPToolStripMenuItem, Me.PropertiesToolStripMenuItem, Me.ClearIPToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip_Machines.Name = "ContextMenuStrip_Machines"
        Me.ToolTip.SetToolTip(Me.ContextMenuStrip_Machines, resources.GetString("ContextMenuStrip_Machines.ToolTip"))
        '
        'WakeUpToolStripMenuItem
        '
        resources.ApplyResources(Me.WakeUpToolStripMenuItem, "WakeUpToolStripMenuItem")
        Me.WakeUpToolStripMenuItem.Name = "WakeUpToolStripMenuItem"
        '
        'ShutdownToolStripMenuItem
        '
        resources.ApplyResources(Me.ShutdownToolStripMenuItem, "ShutdownToolStripMenuItem")
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        '
        'ToolStripSeparator10
        '
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        '
        'NewToolStripMenuItem1
        '
        resources.ApplyResources(Me.NewToolStripMenuItem1, "NewToolStripMenuItem1")
        Me.NewToolStripMenuItem1.Image = Global.WakeOnLan.My.Resources.Resources._new
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        '
        'RDPToolStripMenuItem
        '
        resources.ApplyResources(Me.RDPToolStripMenuItem, "RDPToolStripMenuItem")
        Me.RDPToolStripMenuItem.Name = "RDPToolStripMenuItem"
        '
        'PropertiesToolStripMenuItem
        '
        resources.ApplyResources(Me.PropertiesToolStripMenuItem, "PropertiesToolStripMenuItem")
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        '
        'ClearIPToolStripMenuItem
        '
        resources.ApplyResources(Me.ClearIPToolStripMenuItem, "ClearIPToolStripMenuItem")
        Me.ClearIPToolStripMenuItem.Image = Global.WakeOnLan.My.Resources.Resources.eraser_exclamation
        Me.ClearIPToolStripMenuItem.Name = "ClearIPToolStripMenuItem"
        '
        'DeleteToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        Me.DeleteToolStripMenuItem.Image = Global.WakeOnLan.My.Resources.Resources.deletered
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        '
        'ListViewLargeImageList
        '
        Me.ListViewLargeImageList.ImageStream = CType(resources.GetObject("ListViewLargeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewLargeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewLargeImageList.Images.SetKeyName(0, "greyed_48x48.png")
        Me.ListViewLargeImageList.Images.SetKeyName(1, "shutdown_48x48.png")
        Me.ListViewLargeImageList.Images.SetKeyName(2, "connected_48x48.png")
        '
        'ListViewSmallImageList
        '
        Me.ListViewSmallImageList.ImageStream = CType(resources.GetObject("ListViewSmallImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewSmallImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewSmallImageList.Images.SetKeyName(0, "greyed_16x16.png")
        Me.ListViewSmallImageList.Images.SetKeyName(1, "shutdown_16x16.png")
        Me.ListViewSmallImageList.Images.SetKeyName(2, "connected_16x16.png")
        '
        'Button_Emergency
        '
        resources.ApplyResources(Me.Button_Emergency, "Button_Emergency")
        Me.Button_Emergency.Name = "Button_Emergency"
        Me.ToolTip.SetToolTip(Me.Button_Emergency, resources.GetString("Button_Emergency.ToolTip"))
        Me.Button_Emergency.UseVisualStyleBackColor = True
        '
        'Button_StartAll
        '
        resources.ApplyResources(Me.Button_StartAll, "Button_StartAll")
        Me.Button_StartAll.Name = "Button_StartAll"
        Me.ToolTip.SetToolTip(Me.Button_StartAll, resources.GetString("Button_StartAll.ToolTip"))
        Me.Button_StartAll.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Name = "MenuStrip"
        Me.ToolTip.SetToolTip(Me.MenuStrip, resources.GetString("MenuStrip.ToolTip"))
        '
        'FileToolStripMenuItem
        '
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator1, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        '
        'NewToolStripMenuItem
        '
        resources.ApplyResources(Me.NewToolStripMenuItem, "NewToolStripMenuItem")
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'ImportToolStripMenuItem
        '
        resources.ApplyResources(Me.ImportToolStripMenuItem, "ImportToolStripMenuItem")
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        '
        'ExportToolStripMenuItem
        '
        resources.ApplyResources(Me.ExportToolStripMenuItem, "ExportToolStripMenuItem")
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'PrintToolStripMenuItem
        '
        resources.ApplyResources(Me.PrintToolStripMenuItem, "PrintToolStripMenuItem")
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        '
        'PrintPreviewToolStripMenuItem
        '
        resources.ApplyResources(Me.PrintPreviewToolStripMenuItem, "PrintPreviewToolStripMenuItem")
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'ExitToolStripMenuItem
        '
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        '
        'EditToolStripMenuItem
        '
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator4, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator5, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        '
        'UndoToolStripMenuItem
        '
        resources.ApplyResources(Me.UndoToolStripMenuItem, "UndoToolStripMenuItem")
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        '
        'RedoToolStripMenuItem
        '
        resources.ApplyResources(Me.RedoToolStripMenuItem, "RedoToolStripMenuItem")
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        '
        'ToolStripSeparator4
        '
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        '
        'CutToolStripMenuItem
        '
        resources.ApplyResources(Me.CutToolStripMenuItem, "CutToolStripMenuItem")
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        '
        'CopyToolStripMenuItem
        '
        resources.ApplyResources(Me.CopyToolStripMenuItem, "CopyToolStripMenuItem")
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        '
        'PasteToolStripMenuItem
        '
        resources.ApplyResources(Me.PasteToolStripMenuItem, "PasteToolStripMenuItem")
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        '
        'ToolStripSeparator5
        '
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        '
        'SelectAllToolStripMenuItem
        '
        resources.ApplyResources(Me.SelectAllToolStripMenuItem, "SelectAllToolStripMenuItem")
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        '
        'ViewToolStripMenuItem
        '
        resources.ApplyResources(Me.ViewToolStripMenuItem, "ViewToolStripMenuItem")
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem, Me.FoldersToolStripMenuItem, Me.ShowGroupsToolStripMenuItem, Me.ShowHotButtonsToolStripMenuItem, Me.EventLogToolStripMenuItem, Me.ToolStripSeparator7, Me.MinimizeToTaskTrayToolStripMenuItem, Me.AutoStartWithWindowsToolStripMenuItem, Me.ToolStripSeparator9, Me.ResetWindowLayoutToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        '
        'ToolBarToolStripMenuItem
        '
        resources.ApplyResources(Me.ToolBarToolStripMenuItem, "ToolBarToolStripMenuItem")
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        '
        'StatusBarToolStripMenuItem
        '
        resources.ApplyResources(Me.StatusBarToolStripMenuItem, "StatusBarToolStripMenuItem")
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        '
        'FoldersToolStripMenuItem
        '
        resources.ApplyResources(Me.FoldersToolStripMenuItem, "FoldersToolStripMenuItem")
        Me.FoldersToolStripMenuItem.Checked = True
        Me.FoldersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FoldersToolStripMenuItem.Name = "FoldersToolStripMenuItem"
        '
        'ShowGroupsToolStripMenuItem
        '
        resources.ApplyResources(Me.ShowGroupsToolStripMenuItem, "ShowGroupsToolStripMenuItem")
        Me.ShowGroupsToolStripMenuItem.CheckOnClick = True
        Me.ShowGroupsToolStripMenuItem.Name = "ShowGroupsToolStripMenuItem"
        '
        'ShowHotButtonsToolStripMenuItem
        '
        resources.ApplyResources(Me.ShowHotButtonsToolStripMenuItem, "ShowHotButtonsToolStripMenuItem")
        Me.ShowHotButtonsToolStripMenuItem.Checked = True
        Me.ShowHotButtonsToolStripMenuItem.CheckOnClick = True
        Me.ShowHotButtonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowHotButtonsToolStripMenuItem.Name = "ShowHotButtonsToolStripMenuItem"
        '
        'EventLogToolStripMenuItem
        '
        resources.ApplyResources(Me.EventLogToolStripMenuItem, "EventLogToolStripMenuItem")
        Me.EventLogToolStripMenuItem.Name = "EventLogToolStripMenuItem"
        '
        'ToolStripSeparator7
        '
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        '
        'MinimizeToTaskTrayToolStripMenuItem
        '
        resources.ApplyResources(Me.MinimizeToTaskTrayToolStripMenuItem, "MinimizeToTaskTrayToolStripMenuItem")
        Me.MinimizeToTaskTrayToolStripMenuItem.Name = "MinimizeToTaskTrayToolStripMenuItem"
        '
        'AutoStartWithWindowsToolStripMenuItem
        '
        resources.ApplyResources(Me.AutoStartWithWindowsToolStripMenuItem, "AutoStartWithWindowsToolStripMenuItem")
        Me.AutoStartWithWindowsToolStripMenuItem.Name = "AutoStartWithWindowsToolStripMenuItem"
        '
        'ToolStripSeparator9
        '
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        '
        'ResetWindowLayoutToolStripMenuItem
        '
        resources.ApplyResources(Me.ResetWindowLayoutToolStripMenuItem, "ResetWindowLayoutToolStripMenuItem")
        Me.ResetWindowLayoutToolStripMenuItem.Name = "ResetWindowLayoutToolStripMenuItem"
        '
        'ToolsToolStripMenuItem
        '
        resources.ApplyResources(Me.ToolsToolStripMenuItem, "ToolsToolStripMenuItem")
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.SearchForMachinesToolStripMenuItem, Me.ScheduleToolStripMenuItem, Me.ListenToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        '
        'OptionsToolStripMenuItem
        '
        resources.ApplyResources(Me.OptionsToolStripMenuItem, "OptionsToolStripMenuItem")
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        '
        'SearchForMachinesToolStripMenuItem
        '
        resources.ApplyResources(Me.SearchForMachinesToolStripMenuItem, "SearchForMachinesToolStripMenuItem")
        Me.SearchForMachinesToolStripMenuItem.Name = "SearchForMachinesToolStripMenuItem"
        '
        'ScheduleToolStripMenuItem
        '
        resources.ApplyResources(Me.ScheduleToolStripMenuItem, "ScheduleToolStripMenuItem")
        Me.ScheduleToolStripMenuItem.Name = "ScheduleToolStripMenuItem"
        '
        'ListenToolStripMenuItem
        '
        resources.ApplyResources(Me.ListenToolStripMenuItem, "ListenToolStripMenuItem")
        Me.ListenToolStripMenuItem.Image = Global.WakeOnLan.My.Resources.Resources.network_receive_48
        Me.ListenToolStripMenuItem.Name = "ListenToolStripMenuItem"
        '
        'HelpToolStripMenuItem
        '
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ToolStripSeparator6, Me.DonateToolStripMenuItem, Me.LicenseToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        '
        'ContentsToolStripMenuItem
        '
        resources.ApplyResources(Me.ContentsToolStripMenuItem, "ContentsToolStripMenuItem")
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        '
        'ToolStripSeparator6
        '
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        '
        'DonateToolStripMenuItem
        '
        resources.ApplyResources(Me.DonateToolStripMenuItem, "DonateToolStripMenuItem")
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        '
        'LicenseToolStripMenuItem
        '
        resources.ApplyResources(Me.LicenseToolStripMenuItem, "LicenseToolStripMenuItem")
        Me.LicenseToolStripMenuItem.Name = "LicenseToolStripMenuItem"
        '
        'AboutToolStripMenuItem
        '
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        '
        'ToolStrip
        '
        resources.ApplyResources(Me.ToolStrip, "ToolStrip")
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FoldersToolStripButton, Me.ToolStripSeparator8, Me.ListViewToolStripButton, Me.PingToolStripButton, Me.ScheduleToolStripButton, Me.ListenerToolStripButton, Me.EventLogToolStripButton, Me.OptionsToolStripButton, Me.HotToolStripButton})
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolTip.SetToolTip(Me.ToolStrip, resources.GetString("ToolStrip.ToolTip"))
        '
        'FoldersToolStripButton
        '
        resources.ApplyResources(Me.FoldersToolStripButton, "FoldersToolStripButton")
        Me.FoldersToolStripButton.Checked = True
        Me.FoldersToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FoldersToolStripButton.Name = "FoldersToolStripButton"
        '
        'ToolStripSeparator8
        '
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        '
        'ListViewToolStripButton
        '
        resources.ApplyResources(Me.ListViewToolStripButton, "ListViewToolStripButton")
        Me.ListViewToolStripButton.DropDown = Me.ContextMenuStripViews
        Me.ListViewToolStripButton.Name = "ListViewToolStripButton"
        '
        'ContextMenuStripViews
        '
        resources.ApplyResources(Me.ContextMenuStripViews, "ContextMenuStripViews")
        Me.ContextMenuStripViews.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListToolStripMenuItem1, Me.DetailsToolStripMenuItem1, Me.LargeIconsToolStripMenuItem1, Me.SmallIconsToolStripMenuItem1, Me.TileToolStripMenuItem1})
        Me.ContextMenuStripViews.Name = "ContextMenuStripViews"
        Me.ContextMenuStripViews.OwnerItem = Me.ListViewToolStripButton
        Me.ContextMenuStripViews.ShowCheckMargin = True
        Me.ContextMenuStripViews.ShowImageMargin = False
        Me.ToolTip.SetToolTip(Me.ContextMenuStripViews, resources.GetString("ContextMenuStripViews.ToolTip"))
        '
        'ListToolStripMenuItem1
        '
        resources.ApplyResources(Me.ListToolStripMenuItem1, "ListToolStripMenuItem1")
        Me.ListToolStripMenuItem1.Name = "ListToolStripMenuItem1"
        '
        'DetailsToolStripMenuItem1
        '
        resources.ApplyResources(Me.DetailsToolStripMenuItem1, "DetailsToolStripMenuItem1")
        Me.DetailsToolStripMenuItem1.Name = "DetailsToolStripMenuItem1"
        '
        'LargeIconsToolStripMenuItem1
        '
        resources.ApplyResources(Me.LargeIconsToolStripMenuItem1, "LargeIconsToolStripMenuItem1")
        Me.LargeIconsToolStripMenuItem1.Name = "LargeIconsToolStripMenuItem1"
        '
        'SmallIconsToolStripMenuItem1
        '
        resources.ApplyResources(Me.SmallIconsToolStripMenuItem1, "SmallIconsToolStripMenuItem1")
        Me.SmallIconsToolStripMenuItem1.Name = "SmallIconsToolStripMenuItem1"
        '
        'TileToolStripMenuItem1
        '
        resources.ApplyResources(Me.TileToolStripMenuItem1, "TileToolStripMenuItem1")
        Me.TileToolStripMenuItem1.Name = "TileToolStripMenuItem1"
        '
        'PingToolStripButton
        '
        resources.ApplyResources(Me.PingToolStripButton, "PingToolStripButton")
        Me.PingToolStripButton.Checked = True
        Me.PingToolStripButton.CheckOnClick = True
        Me.PingToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PingToolStripButton.Name = "PingToolStripButton"
        '
        'ScheduleToolStripButton
        '
        resources.ApplyResources(Me.ScheduleToolStripButton, "ScheduleToolStripButton")
        Me.ScheduleToolStripButton.Name = "ScheduleToolStripButton"
        '
        'ListenerToolStripButton
        '
        resources.ApplyResources(Me.ListenerToolStripButton, "ListenerToolStripButton")
        Me.ListenerToolStripButton.Image = Global.WakeOnLan.My.Resources.Resources.network_transmit
        Me.ListenerToolStripButton.Name = "ListenerToolStripButton"
        '
        'EventLogToolStripButton
        '
        resources.ApplyResources(Me.EventLogToolStripButton, "EventLogToolStripButton")
        Me.EventLogToolStripButton.Name = "EventLogToolStripButton"
        '
        'OptionsToolStripButton
        '
        resources.ApplyResources(Me.OptionsToolStripButton, "OptionsToolStripButton")
        Me.OptionsToolStripButton.Name = "OptionsToolStripButton"
        '
        'HotToolStripButton
        '
        resources.ApplyResources(Me.HotToolStripButton, "HotToolStripButton")
        Me.HotToolStripButton.Checked = True
        Me.HotToolStripButton.CheckOnClick = True
        Me.HotToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HotToolStripButton.Name = "HotToolStripButton"
        '
        'ToolStripMenuItemWakeUp
        '
        resources.ApplyResources(Me.ToolStripMenuItemWakeUp, "ToolStripMenuItemWakeUp")
        Me.ToolStripMenuItemWakeUp.Name = "ToolStripMenuItemWakeUp"
        '
        'ContextMenuStripTray
        '
        resources.ApplyResources(Me.ContextMenuStripTray, "ContextMenuStripTray")
        Me.ContextMenuStripTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextToolStripMenuItemOpen, Me.ToolStripMenuItemWakeUp, Me.ResetWindowLayoutToolStripMenuItem1, Me.ContextToolStripMenuItemExit})
        Me.ContextMenuStripTray.Name = "ContextMenuStripTray"
        Me.ToolTip.SetToolTip(Me.ContextMenuStripTray, resources.GetString("ContextMenuStripTray.ToolTip"))
        '
        'ContextToolStripMenuItemOpen
        '
        resources.ApplyResources(Me.ContextToolStripMenuItemOpen, "ContextToolStripMenuItemOpen")
        Me.ContextToolStripMenuItemOpen.Name = "ContextToolStripMenuItemOpen"
        '
        'ResetWindowLayoutToolStripMenuItem1
        '
        resources.ApplyResources(Me.ResetWindowLayoutToolStripMenuItem1, "ResetWindowLayoutToolStripMenuItem1")
        Me.ResetWindowLayoutToolStripMenuItem1.Name = "ResetWindowLayoutToolStripMenuItem1"
        '
        'ContextToolStripMenuItemExit
        '
        resources.ApplyResources(Me.ContextToolStripMenuItemExit, "ContextToolStripMenuItemExit")
        Me.ContextToolStripMenuItemExit.Name = "ContextToolStripMenuItemExit"
        '
        'TimerPing
        '
        Me.TimerPing.Interval = 1000
        '
        'TileToolStripMenuItem
        '
        resources.ApplyResources(Me.TileToolStripMenuItem, "TileToolStripMenuItem")
        Me.TileToolStripMenuItem.Name = "TileToolStripMenuItem"
        '
        'SmallIconsToolStripMenuItem
        '
        resources.ApplyResources(Me.SmallIconsToolStripMenuItem, "SmallIconsToolStripMenuItem")
        Me.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem"
        '
        'LargeIconsToolStripMenuItem
        '
        resources.ApplyResources(Me.LargeIconsToolStripMenuItem, "LargeIconsToolStripMenuItem")
        Me.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem"
        '
        'DetailsToolStripMenuItem
        '
        resources.ApplyResources(Me.DetailsToolStripMenuItem, "DetailsToolStripMenuItem")
        Me.DetailsToolStripMenuItem.Checked = True
        Me.DetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        '
        'ListToolStripMenuItem
        '
        resources.ApplyResources(Me.ListToolStripMenuItem, "ListToolStripMenuItem")
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        '
        'NotifyIcon1
        '
        resources.ApplyResources(Me.NotifyIcon1, "NotifyIcon1")
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStripTray
        '
        'NotifyIconUpdate
        '
        Me.NotifyIconUpdate.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        resources.ApplyResources(Me.NotifyIconUpdate, "NotifyIconUpdate")
        '
        'CultureManager
        '
        Me.CultureManager.ManagedControl = Me
        '
        'TimerUpdate
        '
        Me.TimerUpdate.Interval = 15000
        '
        'Explorer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Name = "Explorer"
        Me.ToolTip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ToolStripContainer.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.TreeViewContextMenuStrip.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip_Machines.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ContextMenuStripViews.ResumeLayout(False)
        Me.ContextMenuStripTray.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResetWindowLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents MachineName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents PingToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_StartAll As System.Windows.Forms.Button
    Friend WithEvents Button_Emergency As System.Windows.Forms.Button
    Friend WithEvents ShowGroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IPAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents Netbios As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip_Machines As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WakeUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TimerPing As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SearchForMachinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RDPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowHotButtonsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScheduleToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripViews As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ListToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HotToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LicenseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizeToTaskTrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextToolStripMenuItemOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoStartWithWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemWakeUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconUpdate As System.Windows.Forms.NotifyIcon
    Friend WithEvents Group As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListenerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CultureManager As Localization.CultureManager
    Friend WithEvents OptionsToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TreeViewContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WakeUpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutDownToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Note As System.Windows.Forms.ColumnHeader
    Friend WithEvents DonateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetWindowLayoutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLogToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClearIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerUpdate As System.Windows.Forms.Timer

End Class
