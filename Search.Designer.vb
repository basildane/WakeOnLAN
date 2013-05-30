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
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ch_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_OS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_Interface = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_MAC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.IpAddressControl_End = New WakeOnLan.IPAddressControl()
        Me.IpAddressControl_Start = New WakeOnLan.IPAddressControl()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_spacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_CheckAll = New System.Windows.Forms.Button()
        Me.Button_UnCheckAll = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Search
        '
        resources.ApplyResources(Me.Button_Search, "Button_Search")
        Me.Button_Search.Name = "Button_Search"
        Me.ToolTip1.SetToolTip(Me.Button_Search, resources.GetString("Button_Search.ToolTip"))
        Me.Button_Search.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_Name, Me.ch_OS, Me.ch_Interface, Me.ch_IP, Me.ch_MAC})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowGroups = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.IpAddressControl_End)
        Me.GroupBox1.Controls.Add(Me.IpAddressControl_Start)
        Me.GroupBox1.Controls.Add(Me.Button_Cancel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button_Search)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'IpAddressControl_End
        '
        Me.IpAddressControl_End.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.IpAddressControl_End, "IpAddressControl_End")
        Me.IpAddressControl_End.Name = "IpAddressControl_End"
        Me.ToolTip1.SetToolTip(Me.IpAddressControl_End, resources.GetString("IpAddressControl_End.ToolTip"))
        '
        'IpAddressControl_Start
        '
        Me.IpAddressControl_Start.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.IpAddressControl_Start, "IpAddressControl_Start")
        Me.IpAddressControl_Start.Name = "IpAddressControl_Start"
        Me.ToolTip1.SetToolTip(Me.IpAddressControl_Start, resources.GetString("IpAddressControl_Start.ToolTip"))
        '
        'Button_Cancel
        '
        resources.ApplyResources(Me.Button_Cancel, "Button_Cancel")
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.ToolTip1.SetToolTip(Me.Button_Cancel, resources.GetString("Button_Cancel.ToolTip"))
        Me.Button_Cancel.UseVisualStyleBackColor = True
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
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
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
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Button_CheckAll
        '
        resources.ApplyResources(Me.Button_CheckAll, "Button_CheckAll")
        Me.Button_CheckAll.Name = "Button_CheckAll"
        Me.Button_CheckAll.UseVisualStyleBackColor = True
        '
        'Button_UnCheckAll
        '
        resources.ApplyResources(Me.Button_UnCheckAll, "Button_UnCheckAll")
        Me.Button_UnCheckAll.Name = "Button_UnCheckAll"
        Me.Button_UnCheckAll.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Search
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Button_UnCheckAll)
        Me.Controls.Add(Me.Button_CheckAll)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Search"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Search As System.Windows.Forms.Button
    Friend WithEvents ch_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_OS As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_Interface As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_IP As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_MAC As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_spacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_CheckAll As System.Windows.Forms.Button
    Friend WithEvents Button_UnCheckAll As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents IpAddressControl_End As WakeOnLan.IPAddressControl
    Friend WithEvents IpAddressControl_Start As WakeOnLan.IPAddressControl
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button

End Class
