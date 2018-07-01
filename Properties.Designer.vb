Imports WakeOnLan.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Properties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Properties))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lbIP = New System.Windows.Forms.Label()
        Me.lbNetbios = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.lbMAC = New System.Windows.Forms.Label()
        Me.TextBox_Command = New System.Windows.Forms.TextBox()
        Me.lbShutdownCommand = New System.Windows.Forms.Label()
        Me.CheckBox_Emergency = New System.Windows.Forms.CheckBox()
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.lbGroup = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbBroadcast = New System.Windows.Forms.Label()
        Me.lbTTL = New System.Windows.Forms.Label()
        Me.lbUDP = New System.Windows.Forms.Label()
        Me.lbSendTo = New System.Windows.Forms.Label()
        Me.lNotes = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabProperties = New System.Windows.Forms.TabPage()
        Me.TextBox_Notes = New System.Windows.Forms.TextBox()
        Me.MachineName = New WakeOnLan.Controls.RegExTextBox()
        Me.TabWakeUp = New System.Windows.Forms.TabPage()
        Me.Repeat = New WakeOnLan.Controls.RegExTextBox()
        Me.lbRepeat = New System.Windows.Forms.Label()
        Me.cbKeepAlive = New System.Windows.Forms.CheckBox()
        Me.bCalcBroadcast = New System.Windows.Forms.Button()
        Me.rbURI = New System.Windows.Forms.RadioButton()
        Me.rbIP = New System.Windows.Forms.RadioButton()
        Me.tHostURI = New WakeOnLan.Controls.RegExTextBox()
        Me.TTL = New WakeOnLan.Controls.RegExTextBox()
        Me.UDPPort = New WakeOnLan.Controls.RegExTextBox()
        Me.Broadcast = New WakeOnLan.Controls.IpAddressControl()
        Me.MAC = New WakeOnLan.Controls.RegExTextBox()
        Me.TabStatus = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tRemoteCommand = New WakeOnLan.Controls.RegExTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.IP = New WakeOnLan.Controls.IpAddressControl()
        Me.lbLeaveBlank = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tRDPFilename = New WakeOnLan.Controls.RegExTextBox()
        Me.tRDPPort = New WakeOnLan.Controls.RegExTextBox()
        Me.lbRDPPort = New System.Windows.Forms.Label()
        Me.EditRDPButton = New System.Windows.Forms.Button()
        Me.lbRemoteDesktop = New System.Windows.Forms.Label()
        Me.File_Button = New System.Windows.Forms.Button()
        Me.lbRDPFile = New System.Windows.Forms.Label()
        Me.TabShutdown = New System.Windows.Forms.TabPage()
        Me.tDomain = New WakeOnLan.Controls.RegExTextBox()
        Me.tUserId = New WakeOnLan.Controls.RegExTextBox()
        Me.tPassword = New WakeOnLan.Controls.RegExTextBox()
        Me.lDomain = New System.Windows.Forms.Label()
        Me.lPassword = New System.Windows.Forms.Label()
        Me.lUserId = New System.Windows.Forms.Label()
        Me.lDescription = New System.Windows.Forms.Label()
        Me.LabelShutdownMethod = New System.Windows.Forms.Label()
        Me.ComboBoxShutdownMethod = New System.Windows.Forms.ComboBox()
        Me.Help_Button = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabProperties.SuspendLayout()
        Me.TabWakeUp.SuspendLayout()
        Me.TabStatus.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabShutdown.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.ErrorProvider1.SetError(Me.OK_Button, resources.GetString("OK_Button.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.OK_Button, CType(resources.GetObject("OK_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.OK_Button, CType(resources.GetObject("OK_Button.IconPadding"), Integer))
        Me.OK_Button.Name = "OK_Button"
        Me.ToolTip1.SetToolTip(Me.OK_Button, resources.GetString("OK_Button.ToolTip"))
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.CausesValidation = False
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ErrorProvider1.SetError(Me.Cancel_Button, resources.GetString("Cancel_Button.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Cancel_Button, CType(resources.GetObject("Cancel_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Cancel_Button, CType(resources.GetObject("Cancel_Button.IconPadding"), Integer))
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, resources.GetString("Cancel_Button.ToolTip"))
        '
        'lbIP
        '
        resources.ApplyResources(Me.lbIP, "lbIP")
        Me.ErrorProvider1.SetError(Me.lbIP, resources.GetString("lbIP.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbIP, CType(resources.GetObject("lbIP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbIP, CType(resources.GetObject("lbIP.IconPadding"), Integer))
        Me.lbIP.Name = "lbIP"
        Me.ToolTip1.SetToolTip(Me.lbIP, resources.GetString("lbIP.ToolTip"))
        '
        'lbNetbios
        '
        resources.ApplyResources(Me.lbNetbios, "lbNetbios")
        Me.ErrorProvider1.SetError(Me.lbNetbios, resources.GetString("lbNetbios.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbNetbios, CType(resources.GetObject("lbNetbios.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbNetbios, CType(resources.GetObject("lbNetbios.IconPadding"), Integer))
        Me.lbNetbios.Name = "lbNetbios"
        Me.ToolTip1.SetToolTip(Me.lbNetbios, resources.GetString("lbNetbios.ToolTip"))
        '
        'lbName
        '
        resources.ApplyResources(Me.lbName, "lbName")
        Me.ErrorProvider1.SetError(Me.lbName, resources.GetString("lbName.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbName, CType(resources.GetObject("lbName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbName, CType(resources.GetObject("lbName.IconPadding"), Integer))
        Me.lbName.Name = "lbName"
        Me.ToolTip1.SetToolTip(Me.lbName, resources.GetString("lbName.ToolTip"))
        '
        'lbMAC
        '
        resources.ApplyResources(Me.lbMAC, "lbMAC")
        Me.ErrorProvider1.SetError(Me.lbMAC, resources.GetString("lbMAC.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbMAC, CType(resources.GetObject("lbMAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbMAC, CType(resources.GetObject("lbMAC.IconPadding"), Integer))
        Me.lbMAC.Name = "lbMAC"
        Me.ToolTip1.SetToolTip(Me.lbMAC, resources.GetString("lbMAC.ToolTip"))
        '
        'TextBox_Command
        '
        resources.ApplyResources(Me.TextBox_Command, "TextBox_Command")
        Me.ErrorProvider1.SetError(Me.TextBox_Command, resources.GetString("TextBox_Command.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TextBox_Command, CType(resources.GetObject("TextBox_Command.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TextBox_Command, CType(resources.GetObject("TextBox_Command.IconPadding"), Integer))
        Me.TextBox_Command.Name = "TextBox_Command"
        Me.ToolTip1.SetToolTip(Me.TextBox_Command, resources.GetString("TextBox_Command.ToolTip"))
        '
        'lbShutdownCommand
        '
        resources.ApplyResources(Me.lbShutdownCommand, "lbShutdownCommand")
        Me.ErrorProvider1.SetError(Me.lbShutdownCommand, resources.GetString("lbShutdownCommand.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbShutdownCommand, CType(resources.GetObject("lbShutdownCommand.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbShutdownCommand, CType(resources.GetObject("lbShutdownCommand.IconPadding"), Integer))
        Me.lbShutdownCommand.Name = "lbShutdownCommand"
        Me.ToolTip1.SetToolTip(Me.lbShutdownCommand, resources.GetString("lbShutdownCommand.ToolTip"))
        '
        'CheckBox_Emergency
        '
        resources.ApplyResources(Me.CheckBox_Emergency, "CheckBox_Emergency")
        Me.ErrorProvider1.SetError(Me.CheckBox_Emergency, resources.GetString("CheckBox_Emergency.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBox_Emergency, CType(resources.GetObject("CheckBox_Emergency.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.CheckBox_Emergency, CType(resources.GetObject("CheckBox_Emergency.IconPadding"), Integer))
        Me.CheckBox_Emergency.Name = "CheckBox_Emergency"
        Me.ToolTip1.SetToolTip(Me.CheckBox_Emergency, resources.GetString("CheckBox_Emergency.ToolTip"))
        Me.CheckBox_Emergency.UseVisualStyleBackColor = True
        '
        'Delete_Button
        '
        resources.ApplyResources(Me.Delete_Button, "Delete_Button")
        Me.ErrorProvider1.SetError(Me.Delete_Button, resources.GetString("Delete_Button.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Delete_Button, CType(resources.GetObject("Delete_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Delete_Button, CType(resources.GetObject("Delete_Button.IconPadding"), Integer))
        Me.Delete_Button.Name = "Delete_Button"
        Me.ToolTip1.SetToolTip(Me.Delete_Button, resources.GetString("Delete_Button.ToolTip"))
        Me.Delete_Button.UseVisualStyleBackColor = True
        '
        'Group
        '
        resources.ApplyResources(Me.Group, "Group")
        Me.ErrorProvider1.SetError(Me.Group, resources.GetString("Group.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Group, CType(resources.GetObject("Group.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Group, CType(resources.GetObject("Group.IconPadding"), Integer))
        Me.Group.Name = "Group"
        Me.ToolTip1.SetToolTip(Me.Group, resources.GetString("Group.ToolTip"))
        '
        'lbGroup
        '
        resources.ApplyResources(Me.lbGroup, "lbGroup")
        Me.ErrorProvider1.SetError(Me.lbGroup, resources.GetString("lbGroup.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbGroup, CType(resources.GetObject("lbGroup.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbGroup, CType(resources.GetObject("lbGroup.IconPadding"), Integer))
        Me.lbGroup.Name = "lbGroup"
        Me.ToolTip1.SetToolTip(Me.lbGroup, resources.GetString("lbGroup.ToolTip"))
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        resources.ApplyResources(Me.ErrorProvider1, "ErrorProvider1")
        '
        'lbBroadcast
        '
        resources.ApplyResources(Me.lbBroadcast, "lbBroadcast")
        Me.ErrorProvider1.SetError(Me.lbBroadcast, resources.GetString("lbBroadcast.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbBroadcast, CType(resources.GetObject("lbBroadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbBroadcast, CType(resources.GetObject("lbBroadcast.IconPadding"), Integer))
        Me.lbBroadcast.Name = "lbBroadcast"
        Me.ToolTip1.SetToolTip(Me.lbBroadcast, resources.GetString("lbBroadcast.ToolTip"))
        '
        'lbTTL
        '
        resources.ApplyResources(Me.lbTTL, "lbTTL")
        Me.ErrorProvider1.SetError(Me.lbTTL, resources.GetString("lbTTL.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbTTL, CType(resources.GetObject("lbTTL.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbTTL, CType(resources.GetObject("lbTTL.IconPadding"), Integer))
        Me.lbTTL.Name = "lbTTL"
        Me.ToolTip1.SetToolTip(Me.lbTTL, resources.GetString("lbTTL.ToolTip"))
        '
        'lbUDP
        '
        resources.ApplyResources(Me.lbUDP, "lbUDP")
        Me.ErrorProvider1.SetError(Me.lbUDP, resources.GetString("lbUDP.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbUDP, CType(resources.GetObject("lbUDP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbUDP, CType(resources.GetObject("lbUDP.IconPadding"), Integer))
        Me.lbUDP.Name = "lbUDP"
        Me.ToolTip1.SetToolTip(Me.lbUDP, resources.GetString("lbUDP.ToolTip"))
        '
        'lbSendTo
        '
        resources.ApplyResources(Me.lbSendTo, "lbSendTo")
        Me.ErrorProvider1.SetError(Me.lbSendTo, resources.GetString("lbSendTo.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconPadding"), Integer))
        Me.lbSendTo.Name = "lbSendTo"
        Me.ToolTip1.SetToolTip(Me.lbSendTo, resources.GetString("lbSendTo.ToolTip"))
        '
        'lNotes
        '
        resources.ApplyResources(Me.lNotes, "lNotes")
        Me.ErrorProvider1.SetError(Me.lNotes, resources.GetString("lNotes.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lNotes, CType(resources.GetObject("lNotes.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lNotes, CType(resources.GetObject("lNotes.IconPadding"), Integer))
        Me.lNotes.Name = "lNotes"
        Me.ToolTip1.SetToolTip(Me.lNotes, resources.GetString("lNotes.ToolTip"))
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabProperties)
        Me.TabControl1.Controls.Add(Me.TabWakeUp)
        Me.TabControl1.Controls.Add(Me.TabStatus)
        Me.TabControl1.Controls.Add(Me.TabShutdown)
        Me.ErrorProvider1.SetError(Me.TabControl1, resources.GetString("TabControl1.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TabControl1, CType(resources.GetObject("TabControl1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TabControl1, CType(resources.GetObject("TabControl1.IconPadding"), Integer))
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.ToolTip1.SetToolTip(Me.TabControl1, resources.GetString("TabControl1.ToolTip"))
        '
        'TabProperties
        '
        resources.ApplyResources(Me.TabProperties, "TabProperties")
        Me.TabProperties.Controls.Add(Me.lNotes)
        Me.TabProperties.Controls.Add(Me.TextBox_Notes)
        Me.TabProperties.Controls.Add(Me.Group)
        Me.TabProperties.Controls.Add(Me.lbGroup)
        Me.TabProperties.Controls.Add(Me.lbName)
        Me.TabProperties.Controls.Add(Me.MachineName)
        Me.ErrorProvider1.SetError(Me.TabProperties, resources.GetString("TabProperties.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TabProperties, CType(resources.GetObject("TabProperties.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TabProperties, CType(resources.GetObject("TabProperties.IconPadding"), Integer))
        Me.TabProperties.Name = "TabProperties"
        Me.ToolTip1.SetToolTip(Me.TabProperties, resources.GetString("TabProperties.ToolTip"))
        Me.TabProperties.UseVisualStyleBackColor = True
        '
        'TextBox_Notes
        '
        resources.ApplyResources(Me.TextBox_Notes, "TextBox_Notes")
        Me.ErrorProvider1.SetError(Me.TextBox_Notes, resources.GetString("TextBox_Notes.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TextBox_Notes, CType(resources.GetObject("TextBox_Notes.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TextBox_Notes, CType(resources.GetObject("TextBox_Notes.IconPadding"), Integer))
        Me.TextBox_Notes.Name = "TextBox_Notes"
        Me.ToolTip1.SetToolTip(Me.TextBox_Notes, resources.GetString("TextBox_Notes.ToolTip"))
        '
        'MachineName
        '
        resources.ApplyResources(Me.MachineName, "MachineName")
        Me.ErrorProvider1.SetError(Me.MachineName, resources.GetString("MachineName.Error"))
        Me.MachineName.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.MachineName, CType(resources.GetObject("MachineName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.MachineName, CType(resources.GetObject("MachineName.IconPadding"), Integer))
        Me.MachineName.Name = "MachineName"
        Me.ToolTip1.SetToolTip(Me.MachineName, resources.GetString("MachineName.ToolTip"))
        Me.MachineName.ValidationExpression = "\w{1,}"
        '
        'TabWakeUp
        '
        resources.ApplyResources(Me.TabWakeUp, "TabWakeUp")
        Me.TabWakeUp.Controls.Add(Me.Repeat)
        Me.TabWakeUp.Controls.Add(Me.lbRepeat)
        Me.TabWakeUp.Controls.Add(Me.cbKeepAlive)
        Me.TabWakeUp.Controls.Add(Me.lbUDP)
        Me.TabWakeUp.Controls.Add(Me.lbTTL)
        Me.TabWakeUp.Controls.Add(Me.lbMAC)
        Me.TabWakeUp.Controls.Add(Me.bCalcBroadcast)
        Me.TabWakeUp.Controls.Add(Me.lbNetbios)
        Me.TabWakeUp.Controls.Add(Me.lbSendTo)
        Me.TabWakeUp.Controls.Add(Me.rbURI)
        Me.TabWakeUp.Controls.Add(Me.rbIP)
        Me.TabWakeUp.Controls.Add(Me.lbBroadcast)
        Me.TabWakeUp.Controls.Add(Me.tHostURI)
        Me.TabWakeUp.Controls.Add(Me.TTL)
        Me.TabWakeUp.Controls.Add(Me.UDPPort)
        Me.TabWakeUp.Controls.Add(Me.Broadcast)
        Me.TabWakeUp.Controls.Add(Me.MAC)
        Me.ErrorProvider1.SetError(Me.TabWakeUp, resources.GetString("TabWakeUp.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TabWakeUp, CType(resources.GetObject("TabWakeUp.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TabWakeUp, CType(resources.GetObject("TabWakeUp.IconPadding"), Integer))
        Me.TabWakeUp.Name = "TabWakeUp"
        Me.ToolTip1.SetToolTip(Me.TabWakeUp, resources.GetString("TabWakeUp.ToolTip"))
        Me.TabWakeUp.UseVisualStyleBackColor = True
        '
        'Repeat
        '
        resources.ApplyResources(Me.Repeat, "Repeat")
        Me.ErrorProvider1.SetError(Me.Repeat, resources.GetString("Repeat.Error"))
        Me.Repeat.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.Repeat, CType(resources.GetObject("Repeat.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Repeat, CType(resources.GetObject("Repeat.IconPadding"), Integer))
        Me.Repeat.Name = "Repeat"
        Me.ToolTip1.SetToolTip(Me.Repeat, resources.GetString("Repeat.ToolTip"))
        Me.Repeat.ValidationExpression = "^[1-9][0-9]*$"
        '
        'lbRepeat
        '
        resources.ApplyResources(Me.lbRepeat, "lbRepeat")
        Me.ErrorProvider1.SetError(Me.lbRepeat, resources.GetString("lbRepeat.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbRepeat, CType(resources.GetObject("lbRepeat.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbRepeat, CType(resources.GetObject("lbRepeat.IconPadding"), Integer))
        Me.lbRepeat.Name = "lbRepeat"
        Me.ToolTip1.SetToolTip(Me.lbRepeat, resources.GetString("lbRepeat.ToolTip"))
        '
        'cbKeepAlive
        '
        resources.ApplyResources(Me.cbKeepAlive, "cbKeepAlive")
        Me.ErrorProvider1.SetError(Me.cbKeepAlive, resources.GetString("cbKeepAlive.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.cbKeepAlive, CType(resources.GetObject("cbKeepAlive.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.cbKeepAlive, CType(resources.GetObject("cbKeepAlive.IconPadding"), Integer))
        Me.cbKeepAlive.Name = "cbKeepAlive"
        Me.ToolTip1.SetToolTip(Me.cbKeepAlive, resources.GetString("cbKeepAlive.ToolTip"))
        Me.cbKeepAlive.UseVisualStyleBackColor = True
        '
        'bCalcBroadcast
        '
        resources.ApplyResources(Me.bCalcBroadcast, "bCalcBroadcast")
        Me.ErrorProvider1.SetError(Me.bCalcBroadcast, resources.GetString("bCalcBroadcast.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.bCalcBroadcast, CType(resources.GetObject("bCalcBroadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.bCalcBroadcast, CType(resources.GetObject("bCalcBroadcast.IconPadding"), Integer))
        Me.bCalcBroadcast.Name = "bCalcBroadcast"
        Me.ToolTip1.SetToolTip(Me.bCalcBroadcast, resources.GetString("bCalcBroadcast.ToolTip"))
        Me.bCalcBroadcast.UseVisualStyleBackColor = True
        '
        'rbURI
        '
        resources.ApplyResources(Me.rbURI, "rbURI")
        Me.ErrorProvider1.SetError(Me.rbURI, resources.GetString("rbURI.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.rbURI, CType(resources.GetObject("rbURI.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.rbURI, CType(resources.GetObject("rbURI.IconPadding"), Integer))
        Me.rbURI.Name = "rbURI"
        Me.rbURI.TabStop = True
        Me.ToolTip1.SetToolTip(Me.rbURI, resources.GetString("rbURI.ToolTip"))
        Me.rbURI.UseVisualStyleBackColor = True
        '
        'rbIP
        '
        resources.ApplyResources(Me.rbIP, "rbIP")
        Me.ErrorProvider1.SetError(Me.rbIP, resources.GetString("rbIP.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.rbIP, CType(resources.GetObject("rbIP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.rbIP, CType(resources.GetObject("rbIP.IconPadding"), Integer))
        Me.rbIP.Name = "rbIP"
        Me.rbIP.TabStop = True
        Me.ToolTip1.SetToolTip(Me.rbIP, resources.GetString("rbIP.ToolTip"))
        Me.rbIP.UseVisualStyleBackColor = True
        '
        'tHostURI
        '
        resources.ApplyResources(Me.tHostURI, "tHostURI")
        Me.ErrorProvider1.SetError(Me.tHostURI, resources.GetString("tHostURI.Error"))
        Me.tHostURI.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tHostURI, CType(resources.GetObject("tHostURI.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tHostURI, CType(resources.GetObject("tHostURI.IconPadding"), Integer))
        Me.tHostURI.Name = "tHostURI"
        Me.ToolTip1.SetToolTip(Me.tHostURI, resources.GetString("tHostURI.ToolTip"))
        Me.tHostURI.ValidationExpression = "^(?!\s*$).+"
        '
        'TTL
        '
        resources.ApplyResources(Me.TTL, "TTL")
        Me.ErrorProvider1.SetError(Me.TTL, resources.GetString("TTL.Error"))
        Me.TTL.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.TTL, CType(resources.GetObject("TTL.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TTL, CType(resources.GetObject("TTL.IconPadding"), Integer))
        Me.TTL.Name = "TTL"
        Me.ToolTip1.SetToolTip(Me.TTL, resources.GetString("TTL.ToolTip"))
        Me.TTL.ValidationExpression = "^\d+$"
        '
        'UDPPort
        '
        resources.ApplyResources(Me.UDPPort, "UDPPort")
        Me.ErrorProvider1.SetError(Me.UDPPort, resources.GetString("UDPPort.Error"))
        Me.UDPPort.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.UDPPort, CType(resources.GetObject("UDPPort.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.UDPPort, CType(resources.GetObject("UDPPort.IconPadding"), Integer))
        Me.UDPPort.Name = "UDPPort"
        Me.ToolTip1.SetToolTip(Me.UDPPort, resources.GetString("UDPPort.ToolTip"))
        Me.UDPPort.ValidationExpression = "^\d+$"
        '
        'Broadcast
        '
        resources.ApplyResources(Me.Broadcast, "Broadcast")
        Me.Broadcast.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.Broadcast.BackColor = System.Drawing.SystemColors.Window
        Me.Broadcast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ErrorProvider1.SetError(Me.Broadcast, resources.GetString("Broadcast.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Broadcast, CType(resources.GetObject("Broadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Broadcast, CType(resources.GetObject("Broadcast.IconPadding"), Integer))
        Me.Broadcast.Name = "Broadcast"
        Me.ToolTip1.SetToolTip(Me.Broadcast, resources.GetString("Broadcast.ToolTip"))
        '
        'MAC
        '
        resources.ApplyResources(Me.MAC, "MAC")
        Me.ErrorProvider1.SetError(Me.MAC, resources.GetString("MAC.Error"))
        Me.MAC.ErrorColor = System.Drawing.Color.Red
        Me.MAC.ForeColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.MAC, CType(resources.GetObject("MAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.MAC, CType(resources.GetObject("MAC.IconPadding"), Integer))
        Me.MAC.Name = "MAC"
        Me.ToolTip1.SetToolTip(Me.MAC, resources.GetString("MAC.ToolTip"))
        Me.MAC.ValidationExpression = "^([0-9a-fA-F]{2}([-:])?){5}[0-9a-fA-F]{2}$"
        '
        'TabStatus
        '
        resources.ApplyResources(Me.TabStatus, "TabStatus")
        Me.TabStatus.Controls.Add(Me.GroupBox3)
        Me.TabStatus.Controls.Add(Me.GroupBox2)
        Me.TabStatus.Controls.Add(Me.GroupBox1)
        Me.ErrorProvider1.SetError(Me.TabStatus, resources.GetString("TabStatus.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TabStatus, CType(resources.GetObject("TabStatus.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TabStatus, CType(resources.GetObject("TabStatus.IconPadding"), Integer))
        Me.TabStatus.Name = "TabStatus"
        Me.ToolTip1.SetToolTip(Me.TabStatus, resources.GetString("TabStatus.ToolTip"))
        Me.TabStatus.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.tRemoteCommand)
        Me.ErrorProvider1.SetError(Me.GroupBox3, resources.GetString("GroupBox3.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.GroupBox3, CType(resources.GetObject("GroupBox3.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.GroupBox3, CType(resources.GetObject("GroupBox3.IconPadding"), Integer))
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox3, resources.GetString("GroupBox3.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.ErrorProvider1.SetError(Me.Label1, resources.GetString("Label1.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Label1, CType(resources.GetObject("Label1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Label1, CType(resources.GetObject("Label1.IconPadding"), Integer))
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'tRemoteCommand
        '
        resources.ApplyResources(Me.tRemoteCommand, "tRemoteCommand")
        Me.ErrorProvider1.SetError(Me.tRemoteCommand, resources.GetString("tRemoteCommand.Error"))
        Me.tRemoteCommand.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tRemoteCommand, CType(resources.GetObject("tRemoteCommand.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tRemoteCommand, CType(resources.GetObject("tRemoteCommand.IconPadding"), Integer))
        Me.tRemoteCommand.Name = "tRemoteCommand"
        Me.ToolTip1.SetToolTip(Me.tRemoteCommand, resources.GetString("tRemoteCommand.ToolTip"))
        Me.tRemoteCommand.ValidationExpression = ""
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.IP)
        Me.GroupBox2.Controls.Add(Me.lbIP)
        Me.GroupBox2.Controls.Add(Me.lbLeaveBlank)
        Me.ErrorProvider1.SetError(Me.GroupBox2, resources.GetString("GroupBox2.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.GroupBox2, CType(resources.GetObject("GroupBox2.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.GroupBox2, CType(resources.GetObject("GroupBox2.IconPadding"), Integer))
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip"))
        '
        'IP
        '
        resources.ApplyResources(Me.IP, "IP")
        Me.IP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.IP.BackColor = System.Drawing.SystemColors.Window
        Me.IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ErrorProvider1.SetError(Me.IP, resources.GetString("IP.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.IP, CType(resources.GetObject("IP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.IP, CType(resources.GetObject("IP.IconPadding"), Integer))
        Me.IP.Name = "IP"
        Me.ToolTip1.SetToolTip(Me.IP, resources.GetString("IP.ToolTip"))
        '
        'lbLeaveBlank
        '
        resources.ApplyResources(Me.lbLeaveBlank, "lbLeaveBlank")
        Me.ErrorProvider1.SetError(Me.lbLeaveBlank, resources.GetString("lbLeaveBlank.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbLeaveBlank, CType(resources.GetObject("lbLeaveBlank.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbLeaveBlank, CType(resources.GetObject("lbLeaveBlank.IconPadding"), Integer))
        Me.lbLeaveBlank.Name = "lbLeaveBlank"
        Me.ToolTip1.SetToolTip(Me.lbLeaveBlank, resources.GetString("lbLeaveBlank.ToolTip"))
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.tRDPFilename)
        Me.GroupBox1.Controls.Add(Me.tRDPPort)
        Me.GroupBox1.Controls.Add(Me.lbRDPPort)
        Me.GroupBox1.Controls.Add(Me.EditRDPButton)
        Me.GroupBox1.Controls.Add(Me.lbRemoteDesktop)
        Me.GroupBox1.Controls.Add(Me.File_Button)
        Me.GroupBox1.Controls.Add(Me.lbRDPFile)
        Me.ErrorProvider1.SetError(Me.GroupBox1, resources.GetString("GroupBox1.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.GroupBox1, CType(resources.GetObject("GroupBox1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.GroupBox1, CType(resources.GetObject("GroupBox1.IconPadding"), Integer))
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'tRDPFilename
        '
        resources.ApplyResources(Me.tRDPFilename, "tRDPFilename")
        Me.ErrorProvider1.SetError(Me.tRDPFilename, resources.GetString("tRDPFilename.Error"))
        Me.tRDPFilename.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tRDPFilename, CType(resources.GetObject("tRDPFilename.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tRDPFilename, CType(resources.GetObject("tRDPFilename.IconPadding"), Integer))
        Me.tRDPFilename.Name = "tRDPFilename"
        Me.ToolTip1.SetToolTip(Me.tRDPFilename, resources.GetString("tRDPFilename.ToolTip"))
        Me.tRDPFilename.ValidationExpression = ""
        '
        'tRDPPort
        '
        resources.ApplyResources(Me.tRDPPort, "tRDPPort")
        Me.ErrorProvider1.SetError(Me.tRDPPort, resources.GetString("tRDPPort.Error"))
        Me.tRDPPort.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tRDPPort, CType(resources.GetObject("tRDPPort.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tRDPPort, CType(resources.GetObject("tRDPPort.IconPadding"), Integer))
        Me.tRDPPort.Name = "tRDPPort"
        Me.ToolTip1.SetToolTip(Me.tRDPPort, resources.GetString("tRDPPort.ToolTip"))
        Me.tRDPPort.ValidationExpression = ""
        '
        'lbRDPPort
        '
        resources.ApplyResources(Me.lbRDPPort, "lbRDPPort")
        Me.ErrorProvider1.SetError(Me.lbRDPPort, resources.GetString("lbRDPPort.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbRDPPort, CType(resources.GetObject("lbRDPPort.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbRDPPort, CType(resources.GetObject("lbRDPPort.IconPadding"), Integer))
        Me.lbRDPPort.Name = "lbRDPPort"
        Me.ToolTip1.SetToolTip(Me.lbRDPPort, resources.GetString("lbRDPPort.ToolTip"))
        '
        'EditRDPButton
        '
        resources.ApplyResources(Me.EditRDPButton, "EditRDPButton")
        Me.ErrorProvider1.SetError(Me.EditRDPButton, resources.GetString("EditRDPButton.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.EditRDPButton, CType(resources.GetObject("EditRDPButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.EditRDPButton, CType(resources.GetObject("EditRDPButton.IconPadding"), Integer))
        Me.EditRDPButton.Name = "EditRDPButton"
        Me.ToolTip1.SetToolTip(Me.EditRDPButton, resources.GetString("EditRDPButton.ToolTip"))
        Me.EditRDPButton.UseVisualStyleBackColor = True
        '
        'lbRemoteDesktop
        '
        resources.ApplyResources(Me.lbRemoteDesktop, "lbRemoteDesktop")
        Me.ErrorProvider1.SetError(Me.lbRemoteDesktop, resources.GetString("lbRemoteDesktop.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbRemoteDesktop, CType(resources.GetObject("lbRemoteDesktop.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbRemoteDesktop, CType(resources.GetObject("lbRemoteDesktop.IconPadding"), Integer))
        Me.lbRemoteDesktop.Name = "lbRemoteDesktop"
        Me.ToolTip1.SetToolTip(Me.lbRemoteDesktop, resources.GetString("lbRemoteDesktop.ToolTip"))
        '
        'File_Button
        '
        resources.ApplyResources(Me.File_Button, "File_Button")
        Me.ErrorProvider1.SetError(Me.File_Button, resources.GetString("File_Button.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.File_Button, CType(resources.GetObject("File_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.File_Button, CType(resources.GetObject("File_Button.IconPadding"), Integer))
        Me.File_Button.Name = "File_Button"
        Me.ToolTip1.SetToolTip(Me.File_Button, resources.GetString("File_Button.ToolTip"))
        Me.File_Button.UseVisualStyleBackColor = True
        '
        'lbRDPFile
        '
        resources.ApplyResources(Me.lbRDPFile, "lbRDPFile")
        Me.ErrorProvider1.SetError(Me.lbRDPFile, resources.GetString("lbRDPFile.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbRDPFile, CType(resources.GetObject("lbRDPFile.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbRDPFile, CType(resources.GetObject("lbRDPFile.IconPadding"), Integer))
        Me.lbRDPFile.Name = "lbRDPFile"
        Me.ToolTip1.SetToolTip(Me.lbRDPFile, resources.GetString("lbRDPFile.ToolTip"))
        '
        'TabShutdown
        '
        resources.ApplyResources(Me.TabShutdown, "TabShutdown")
        Me.TabShutdown.Controls.Add(Me.tDomain)
        Me.TabShutdown.Controls.Add(Me.tUserId)
        Me.TabShutdown.Controls.Add(Me.tPassword)
        Me.TabShutdown.Controls.Add(Me.lDomain)
        Me.TabShutdown.Controls.Add(Me.lPassword)
        Me.TabShutdown.Controls.Add(Me.lUserId)
        Me.TabShutdown.Controls.Add(Me.lDescription)
        Me.TabShutdown.Controls.Add(Me.LabelShutdownMethod)
        Me.TabShutdown.Controls.Add(Me.ComboBoxShutdownMethod)
        Me.TabShutdown.Controls.Add(Me.TextBox_Command)
        Me.TabShutdown.Controls.Add(Me.lbShutdownCommand)
        Me.TabShutdown.Controls.Add(Me.CheckBox_Emergency)
        Me.ErrorProvider1.SetError(Me.TabShutdown, resources.GetString("TabShutdown.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.TabShutdown, CType(resources.GetObject("TabShutdown.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.TabShutdown, CType(resources.GetObject("TabShutdown.IconPadding"), Integer))
        Me.TabShutdown.Name = "TabShutdown"
        Me.ToolTip1.SetToolTip(Me.TabShutdown, resources.GetString("TabShutdown.ToolTip"))
        Me.TabShutdown.UseVisualStyleBackColor = True
        '
        'tDomain
        '
        resources.ApplyResources(Me.tDomain, "tDomain")
        Me.ErrorProvider1.SetError(Me.tDomain, resources.GetString("tDomain.Error"))
        Me.tDomain.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tDomain, CType(resources.GetObject("tDomain.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tDomain, CType(resources.GetObject("tDomain.IconPadding"), Integer))
        Me.tDomain.Name = "tDomain"
        Me.ToolTip1.SetToolTip(Me.tDomain, resources.GetString("tDomain.ToolTip"))
        Me.tDomain.ValidationExpression = ""
        '
        'tUserId
        '
        resources.ApplyResources(Me.tUserId, "tUserId")
        Me.ErrorProvider1.SetError(Me.tUserId, resources.GetString("tUserId.Error"))
        Me.tUserId.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tUserId, CType(resources.GetObject("tUserId.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tUserId, CType(resources.GetObject("tUserId.IconPadding"), Integer))
        Me.tUserId.Name = "tUserId"
        Me.ToolTip1.SetToolTip(Me.tUserId, resources.GetString("tUserId.ToolTip"))
        Me.tUserId.ValidationExpression = ""
        '
        'tPassword
        '
        resources.ApplyResources(Me.tPassword, "tPassword")
        Me.ErrorProvider1.SetError(Me.tPassword, resources.GetString("tPassword.Error"))
        Me.tPassword.ErrorColor = System.Drawing.Color.Red
        Me.ErrorProvider1.SetIconAlignment(Me.tPassword, CType(resources.GetObject("tPassword.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.tPassword, CType(resources.GetObject("tPassword.IconPadding"), Integer))
        Me.tPassword.Name = "tPassword"
        Me.ToolTip1.SetToolTip(Me.tPassword, resources.GetString("tPassword.ToolTip"))
        Me.tPassword.UseSystemPasswordChar = True
        Me.tPassword.ValidationExpression = ""
        '
        'lDomain
        '
        resources.ApplyResources(Me.lDomain, "lDomain")
        Me.ErrorProvider1.SetError(Me.lDomain, resources.GetString("lDomain.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lDomain, CType(resources.GetObject("lDomain.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lDomain, CType(resources.GetObject("lDomain.IconPadding"), Integer))
        Me.lDomain.Name = "lDomain"
        Me.ToolTip1.SetToolTip(Me.lDomain, resources.GetString("lDomain.ToolTip"))
        '
        'lPassword
        '
        resources.ApplyResources(Me.lPassword, "lPassword")
        Me.ErrorProvider1.SetError(Me.lPassword, resources.GetString("lPassword.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lPassword, CType(resources.GetObject("lPassword.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lPassword, CType(resources.GetObject("lPassword.IconPadding"), Integer))
        Me.lPassword.Name = "lPassword"
        Me.ToolTip1.SetToolTip(Me.lPassword, resources.GetString("lPassword.ToolTip"))
        '
        'lUserId
        '
        resources.ApplyResources(Me.lUserId, "lUserId")
        Me.ErrorProvider1.SetError(Me.lUserId, resources.GetString("lUserId.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lUserId, CType(resources.GetObject("lUserId.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lUserId, CType(resources.GetObject("lUserId.IconPadding"), Integer))
        Me.lUserId.Name = "lUserId"
        Me.ToolTip1.SetToolTip(Me.lUserId, resources.GetString("lUserId.ToolTip"))
        '
        'lDescription
        '
        resources.ApplyResources(Me.lDescription, "lDescription")
        Me.ErrorProvider1.SetError(Me.lDescription, resources.GetString("lDescription.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lDescription, CType(resources.GetObject("lDescription.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lDescription, CType(resources.GetObject("lDescription.IconPadding"), Integer))
        Me.lDescription.Name = "lDescription"
        Me.ToolTip1.SetToolTip(Me.lDescription, resources.GetString("lDescription.ToolTip"))
        '
        'LabelShutdownMethod
        '
        resources.ApplyResources(Me.LabelShutdownMethod, "LabelShutdownMethod")
        Me.ErrorProvider1.SetError(Me.LabelShutdownMethod, resources.GetString("LabelShutdownMethod.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.LabelShutdownMethod, CType(resources.GetObject("LabelShutdownMethod.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.LabelShutdownMethod, CType(resources.GetObject("LabelShutdownMethod.IconPadding"), Integer))
        Me.LabelShutdownMethod.Name = "LabelShutdownMethod"
        Me.ToolTip1.SetToolTip(Me.LabelShutdownMethod, resources.GetString("LabelShutdownMethod.ToolTip"))
        '
        'ComboBoxShutdownMethod
        '
        resources.ApplyResources(Me.ComboBoxShutdownMethod, "ComboBoxShutdownMethod")
        Me.ErrorProvider1.SetError(Me.ComboBoxShutdownMethod, resources.GetString("ComboBoxShutdownMethod.Error"))
        Me.ComboBoxShutdownMethod.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxShutdownMethod, CType(resources.GetObject("ComboBoxShutdownMethod.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxShutdownMethod, CType(resources.GetObject("ComboBoxShutdownMethod.IconPadding"), Integer))
        Me.ComboBoxShutdownMethod.Items.AddRange(New Object() {resources.GetString("ComboBoxShutdownMethod.Items"), resources.GetString("ComboBoxShutdownMethod.Items1"), resources.GetString("ComboBoxShutdownMethod.Items2")})
        Me.ComboBoxShutdownMethod.Name = "ComboBoxShutdownMethod"
        Me.ToolTip1.SetToolTip(Me.ComboBoxShutdownMethod, resources.GetString("ComboBoxShutdownMethod.ToolTip"))
        '
        'Help_Button
        '
        resources.ApplyResources(Me.Help_Button, "Help_Button")
        Me.ErrorProvider1.SetError(Me.Help_Button, resources.GetString("Help_Button.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Help_Button, CType(resources.GetObject("Help_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Help_Button, CType(resources.GetObject("Help_Button.IconPadding"), Integer))
        Me.Help_Button.Name = "Help_Button"
        Me.ToolTip1.SetToolTip(Me.Help_Button, resources.GetString("Help_Button.ToolTip"))
        Me.Help_Button.UseVisualStyleBackColor = True
        '
        'Properties
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Help_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Delete_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Properties"
        Me.ShowInTaskbar = False
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabProperties.ResumeLayout(False)
        Me.TabProperties.PerformLayout()
        Me.TabWakeUp.ResumeLayout(False)
        Me.TabWakeUp.PerformLayout()
        Me.TabStatus.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabShutdown.ResumeLayout(False)
        Me.TabShutdown.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lbIP As System.Windows.Forms.Label
    Friend WithEvents lbNetbios As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents lbMAC As System.Windows.Forms.Label
    Friend WithEvents TextBox_Command As System.Windows.Forms.TextBox
    Friend WithEvents lbShutdownCommand As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Emergency As System.Windows.Forms.CheckBox
    Friend WithEvents Delete_Button As System.Windows.Forms.Button
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents lbGroup As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents MAC As RegExTextBox
    Friend WithEvents MachineName As RegExTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents IP As IPAddressControl
    Friend WithEvents Broadcast As IPAddressControl
    Friend WithEvents lbBroadcast As System.Windows.Forms.Label
    Friend WithEvents bCalcBroadcast As System.Windows.Forms.Button
    Friend WithEvents Help_Button As System.Windows.Forms.Button
    Friend WithEvents lbUDP As System.Windows.Forms.Label
    Friend WithEvents lbTTL As System.Windows.Forms.Label
    Friend WithEvents TTL As RegExTextBox
    Friend WithEvents UDPPort As RegExTextBox
    Friend WithEvents lbSendTo As System.Windows.Forms.Label
    Friend WithEvents rbURI As System.Windows.Forms.RadioButton
    Friend WithEvents rbIP As System.Windows.Forms.RadioButton
    Friend WithEvents tHostURI As RegExTextBox
    Friend WithEvents tRDPPort As RegExTextBox
    Friend WithEvents lbRDPPort As System.Windows.Forms.Label
    Friend WithEvents lbRemoteDesktop As System.Windows.Forms.Label
    Friend WithEvents lbLeaveBlank As System.Windows.Forms.Label
    Friend WithEvents TextBox_Notes As System.Windows.Forms.TextBox
    Friend WithEvents LabelShutdownMethod As System.Windows.Forms.Label
    Friend WithEvents ComboBoxShutdownMethod As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabProperties As System.Windows.Forms.TabPage
    Friend WithEvents lNotes As System.Windows.Forms.Label
    Friend WithEvents TabWakeUp As System.Windows.Forms.TabPage
    Friend WithEvents TabStatus As System.Windows.Forms.TabPage
    Friend WithEvents TabShutdown As System.Windows.Forms.TabPage
    Friend WithEvents tDomain As WakeOnLan.Controls.RegExTextBox
    Friend WithEvents tPassword As WakeOnLan.Controls.RegExTextBox
    Friend WithEvents tUserId As WakeOnLan.Controls.RegExTextBox
    Friend WithEvents lDomain As System.Windows.Forms.Label
    Friend WithEvents lPassword As System.Windows.Forms.Label
    Friend WithEvents lUserId As System.Windows.Forms.Label
    Friend WithEvents lDescription As System.Windows.Forms.Label
    Friend WithEvents cbKeepAlive As CheckBox
    Friend WithEvents File_Button As Button
    Friend WithEvents lbRDPFile As Label
    Friend WithEvents EditRDPButton As Button
    Friend WithEvents tRDPFilename As RegExTextBox
    Friend WithEvents Repeat As RegExTextBox
    Friend WithEvents lbRepeat As Label
    Friend WithEvents tRemoteCommand As RegExTextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
