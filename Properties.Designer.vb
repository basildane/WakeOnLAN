<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Properties
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
        Me.Edit_NETBIOS = New System.Windows.Forms.TextBox()
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.lbGroup = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbBroadcast = New System.Windows.Forms.Label()
        Me.lbTTL = New System.Windows.Forms.Label()
        Me.lbUDP = New System.Windows.Forms.Label()
        Me.TTL = New WakeOnLan.RegExTextBox()
        Me.UDPPort = New WakeOnLan.RegExTextBox()
        Me.Broadcast = New WakeOnLan.IPAddressControl()
        Me.IP = New WakeOnLan.IPAddressControl()
        Me.MachineName = New WakeOnLan.RegExTextBox()
        Me.MAC = New WakeOnLan.RegExTextBox()
        Me.lbLeaveBlank = New System.Windows.Forms.Label()
        Me.lbSendTo = New System.Windows.Forms.Label()
        Me.bCalcBroadcast = New System.Windows.Forms.Button()
        Me.Help_Button = New System.Windows.Forms.Button()
        Me.rbIP = New System.Windows.Forms.RadioButton()
        Me.rbURI = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Edit_NETBIOS
        '
        resources.ApplyResources(Me.Edit_NETBIOS, "Edit_NETBIOS")
        Me.ErrorProvider1.SetError(Me.Edit_NETBIOS, resources.GetString("Edit_NETBIOS.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Edit_NETBIOS, CType(resources.GetObject("Edit_NETBIOS.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Edit_NETBIOS, CType(resources.GetObject("Edit_NETBIOS.IconPadding"), Integer))
        Me.Edit_NETBIOS.Name = "Edit_NETBIOS"
        Me.ToolTip1.SetToolTip(Me.Edit_NETBIOS, resources.GetString("Edit_NETBIOS.ToolTip"))
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
        'TTL
        '
        resources.ApplyResources(Me.TTL, "TTL")
        Me.ErrorProvider1.SetError(Me.TTL, resources.GetString("TTL.Error"))
        Me.TTL.ErrorColor = System.Drawing.Color.Red
        Me.TTL.ErrorMessage = ""
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
        Me.UDPPort.ErrorMessage = ""
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
        Me.ErrorProvider1.SetError(Me.Broadcast, resources.GetString("Broadcast.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.Broadcast, CType(resources.GetObject("Broadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.Broadcast, CType(resources.GetObject("Broadcast.IconPadding"), Integer))
        Me.Broadcast.Name = "Broadcast"
        Me.ToolTip1.SetToolTip(Me.Broadcast, resources.GetString("Broadcast.ToolTip"))
        '
        'IP
        '
        resources.ApplyResources(Me.IP, "IP")
        Me.IP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.IP.BackColor = System.Drawing.SystemColors.Window
        Me.ErrorProvider1.SetError(Me.IP, resources.GetString("IP.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.IP, CType(resources.GetObject("IP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.IP, CType(resources.GetObject("IP.IconPadding"), Integer))
        Me.IP.Name = "IP"
        Me.ToolTip1.SetToolTip(Me.IP, resources.GetString("IP.ToolTip"))
        '
        'MachineName
        '
        resources.ApplyResources(Me.MachineName, "MachineName")
        Me.ErrorProvider1.SetError(Me.MachineName, resources.GetString("MachineName.Error"))
        Me.MachineName.ErrorColor = System.Drawing.Color.Red
        Me.MachineName.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MachineName, CType(resources.GetObject("MachineName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.MachineName, CType(resources.GetObject("MachineName.IconPadding"), Integer))
        Me.MachineName.Name = "MachineName"
        Me.ToolTip1.SetToolTip(Me.MachineName, resources.GetString("MachineName.ToolTip"))
        Me.MachineName.ValidationExpression = "^([\w\-\.]+){1,1}?$"
        '
        'MAC
        '
        resources.ApplyResources(Me.MAC, "MAC")
        Me.ErrorProvider1.SetError(Me.MAC, resources.GetString("MAC.Error"))
        Me.MAC.ErrorColor = System.Drawing.Color.Red
        Me.MAC.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MAC, CType(resources.GetObject("MAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.MAC, CType(resources.GetObject("MAC.IconPadding"), Integer))
        Me.MAC.Name = "MAC"
        Me.ToolTip1.SetToolTip(Me.MAC, resources.GetString("MAC.ToolTip"))
        Me.MAC.ValidationExpression = "^([0-9a-fA-F]{2}([-:])?){5}[0-9a-fA-F]{2}$"
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
        'lbSendTo
        '
        resources.ApplyResources(Me.lbSendTo, "lbSendTo")
        Me.ErrorProvider1.SetError(Me.lbSendTo, resources.GetString("lbSendTo.Error"))
        Me.ErrorProvider1.SetIconAlignment(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.ErrorProvider1.SetIconPadding(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconPadding"), Integer))
        Me.lbSendTo.Name = "lbSendTo"
        Me.ToolTip1.SetToolTip(Me.lbSendTo, resources.GetString("lbSendTo.ToolTip"))
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
        'Properties
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.lbSendTo)
        Me.Controls.Add(Me.rbURI)
        Me.Controls.Add(Me.rbIP)
        Me.Controls.Add(Me.lbLeaveBlank)
        Me.Controls.Add(Me.TTL)
        Me.Controls.Add(Me.UDPPort)
        Me.Controls.Add(Me.Help_Button)
        Me.Controls.Add(Me.lbUDP)
        Me.Controls.Add(Me.lbTTL)
        Me.Controls.Add(Me.bCalcBroadcast)
        Me.Controls.Add(Me.Broadcast)
        Me.Controls.Add(Me.lbBroadcast)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.IP)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.MachineName)
        Me.Controls.Add(Me.MAC)
        Me.Controls.Add(Me.Group)
        Me.Controls.Add(Me.lbGroup)
        Me.Controls.Add(Me.Delete_Button)
        Me.Controls.Add(Me.Edit_NETBIOS)
        Me.Controls.Add(Me.TextBox_Command)
        Me.Controls.Add(Me.lbShutdownCommand)
        Me.Controls.Add(Me.CheckBox_Emergency)
        Me.Controls.Add(Me.lbNetbios)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbMAC)
        Me.Controls.Add(Me.lbIP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Properties"
        Me.ShowInTaskbar = False
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents Edit_NETBIOS As System.Windows.Forms.TextBox
    Friend WithEvents Delete_Button As System.Windows.Forms.Button
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents lbGroup As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents MAC As WakeOnLan.RegExTextBox
    Friend WithEvents MachineName As WakeOnLan.RegExTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents IP As WakeOnLan.IPAddressControl
    Friend WithEvents Broadcast As WakeOnLan.IPAddressControl
    Friend WithEvents lbBroadcast As System.Windows.Forms.Label
    Friend WithEvents bCalcBroadcast As System.Windows.Forms.Button
    Friend WithEvents Help_Button As System.Windows.Forms.Button
    Friend WithEvents lbUDP As System.Windows.Forms.Label
    Friend WithEvents lbTTL As System.Windows.Forms.Label
    Friend WithEvents TTL As WakeOnLan.RegExTextBox
    Friend WithEvents UDPPort As WakeOnLan.RegExTextBox
    Friend WithEvents lbSendTo As System.Windows.Forms.Label
    Friend WithEvents rbURI As System.Windows.Forms.RadioButton
    Friend WithEvents rbIP As System.Windows.Forms.RadioButton
    Friend WithEvents lbLeaveBlank As System.Windows.Forms.Label

End Class
