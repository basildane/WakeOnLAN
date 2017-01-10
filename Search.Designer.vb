Imports WakeOnLan.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search))
        Me.SearchBegin = New System.Windows.Forms.Button()
        Me.listView = New System.Windows.Forms.ListView()
        Me.ch_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_OS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_Interface = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_MAC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEnabled = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.IpAddressControl_End = New WakeOnLan.Controls.IpAddressControl()
        Me.IpAddressControl_Start = New WakeOnLan.Controls.IpAddressControl()
        Me.cancelSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_spacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.CheckAllButton = New System.Windows.Forms.Button()
        Me.UnCheckAllButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.closeButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.ComboBoxGroup = New System.Windows.Forms.ComboBox()
        Me.gbAddToGroup = New System.Windows.Forms.GroupBox()
        Me.gbSearch.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gbAddToGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchBegin
        '
        resources.ApplyResources(Me.SearchBegin, "SearchBegin")
        Me.SearchBegin.Name = "SearchBegin"
        Me.ToolTip1.SetToolTip(Me.SearchBegin, resources.GetString("SearchBegin.ToolTip"))
        Me.SearchBegin.UseVisualStyleBackColor = True
        '
        'listView
        '
        resources.ApplyResources(Me.listView, "listView")
        Me.listView.CheckBoxes = True
        Me.listView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_Name, Me.ch_OS, Me.ch_Interface, Me.ch_IP, Me.ch_MAC, Me.chEnabled})
        Me.listView.FullRowSelect = True
        Me.listView.MultiSelect = False
        Me.listView.Name = "listView"
        Me.listView.ShowGroups = False
        Me.listView.UseCompatibleStateImageBehavior = False
        Me.listView.View = System.Windows.Forms.View.Details
        '
        'ch_Name
        '
        resources.ApplyResources(Me.ch_Name, "ch_Name")
        '
        'ch_OS
        '
        resources.ApplyResources(Me.ch_OS, "ch_OS")
        '
        'ch_Interface
        '
        resources.ApplyResources(Me.ch_Interface, "ch_Interface")
        '
        'ch_IP
        '
        resources.ApplyResources(Me.ch_IP, "ch_IP")
        '
        'ch_MAC
        '
        resources.ApplyResources(Me.ch_MAC, "ch_MAC")
        '
        'chEnabled
        '
        resources.ApplyResources(Me.chEnabled, "chEnabled")
        '
        'gbSearch
        '
        resources.ApplyResources(Me.gbSearch, "gbSearch")
        Me.gbSearch.Controls.Add(Me.IpAddressControl_End)
        Me.gbSearch.Controls.Add(Me.IpAddressControl_Start)
        Me.gbSearch.Controls.Add(Me.cancelSearch)
        Me.gbSearch.Controls.Add(Me.Label2)
        Me.gbSearch.Controls.Add(Me.Label1)
        Me.gbSearch.Controls.Add(Me.SearchBegin)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.TabStop = False
        '
        'IpAddressControl_End
        '
        Me.IpAddressControl_End.BackColor = System.Drawing.SystemColors.Window
        Me.IpAddressControl_End.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.IpAddressControl_End, "IpAddressControl_End")
        Me.IpAddressControl_End.Name = "IpAddressControl_End"
        Me.ToolTip1.SetToolTip(Me.IpAddressControl_End, resources.GetString("IpAddressControl_End.ToolTip"))
        '
        'IpAddressControl_Start
        '
        Me.IpAddressControl_Start.BackColor = System.Drawing.SystemColors.Window
        Me.IpAddressControl_Start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.IpAddressControl_Start, "IpAddressControl_Start")
        Me.IpAddressControl_Start.Name = "IpAddressControl_Start"
        Me.ToolTip1.SetToolTip(Me.IpAddressControl_Start, resources.GetString("IpAddressControl_Start.ToolTip"))
        '
        'cancelSearch
        '
        resources.ApplyResources(Me.cancelSearch, "cancelSearch")
        Me.cancelSearch.Name = "cancelSearch"
        Me.ToolTip1.SetToolTip(Me.cancelSearch, resources.GetString("cancelSearch.ToolTip"))
        Me.cancelSearch.UseVisualStyleBackColor = True
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
        'backgroundWorker
        '
        Me.backgroundWorker.WorkerReportsProgress = True
        Me.backgroundWorker.WorkerSupportsCancellation = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel_spacer, Me.ToolStripProgressBar1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.SizingGrip = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        '
        'ToolStripStatusLabel_spacer
        '
        Me.ToolStripStatusLabel_spacer.Name = "ToolStripStatusLabel_spacer"
        resources.ApplyResources(Me.ToolStripStatusLabel_spacer, "ToolStripStatusLabel_spacer")
        Me.ToolStripStatusLabel_spacer.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        '
        'LabelDescription
        '
        resources.ApplyResources(Me.LabelDescription, "LabelDescription")
        Me.LabelDescription.Name = "LabelDescription"
        '
        'CheckAllButton
        '
        resources.ApplyResources(Me.CheckAllButton, "CheckAllButton")
        Me.CheckAllButton.Name = "CheckAllButton"
        Me.CheckAllButton.UseVisualStyleBackColor = True
        '
        'UnCheckAllButton
        '
        resources.ApplyResources(Me.UnCheckAllButton, "UnCheckAllButton")
        Me.UnCheckAllButton.Name = "UnCheckAllButton"
        Me.UnCheckAllButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        resources.ApplyResources(Me.closeButton, "closeButton")
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.closeButton.Name = "closeButton"
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        '
        'ComboBoxGroup
        '
        Me.ComboBoxGroup.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxGroup, "ComboBoxGroup")
        Me.ComboBoxGroup.Name = "ComboBoxGroup"
        '
        'gbAddToGroup
        '
        resources.ApplyResources(Me.gbAddToGroup, "gbAddToGroup")
        Me.gbAddToGroup.Controls.Add(Me.ComboBoxGroup)
        Me.gbAddToGroup.Controls.Add(Me.UnCheckAllButton)
        Me.gbAddToGroup.Controls.Add(Me.CheckAllButton)
        Me.gbAddToGroup.Name = "gbAddToGroup"
        Me.gbAddToGroup.TabStop = False
        '
        'Search
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbAddToGroup)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.listView)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Search"
        Me.ShowInTaskbar = False
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbAddToGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SearchBegin As System.Windows.Forms.Button
    Friend WithEvents ch_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_OS As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_Interface As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_IP As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_MAC As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listView As System.Windows.Forms.ListView
    Friend WithEvents cancelSearch As System.Windows.Forms.Button
    Friend WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_spacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents CheckAllButton As System.Windows.Forms.Button
    Friend WithEvents UnCheckAllButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents IpAddressControl_End As IPAddressControl
    Friend WithEvents IpAddressControl_Start As IPAddressControl
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents ComboBoxGroup As System.Windows.Forms.ComboBox
    Friend WithEvents chEnabled As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbAddToGroup As GroupBox
End Class
