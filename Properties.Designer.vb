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
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.lbGroup = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbBroadcast = New System.Windows.Forms.Label()
        Me.lbTTL = New System.Windows.Forms.Label()
        Me.lbUDP = New System.Windows.Forms.Label()
        Me.lbLeaveBlank = New System.Windows.Forms.Label()
        Me.lbSendTo = New System.Windows.Forms.Label()
        Me.TTL = New WakeOnLan.RegExTextBox()
        Me.UDPPort = New WakeOnLan.RegExTextBox()
        Me.Broadcast = New WakeOnLan.IPAddressControl()
        Me.MachineName = New WakeOnLan.RegExTextBox()
        Me.MAC = New WakeOnLan.RegExTextBox()
        Me.IP = New WakeOnLan.IPAddressControl()
        Me.bCalcBroadcast = New System.Windows.Forms.Button()
        Me.Help_Button = New System.Windows.Forms.Button()
        Me.rbIP = New System.Windows.Forms.RadioButton()
        Me.rbURI = New System.Windows.Forms.RadioButton()
        Me.ComboBoxAdapters = New System.Windows.Forms.ComboBox()
        Me.LabelInterfaces = New System.Windows.Forms.Label()
        Me.tHostURI = New WakeOnLan.RegExTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.ErrorProvider1.SetIconAlignment(Me.OK_Button, CType(resources.GetObject("OK_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.CausesValidation = False
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ErrorProvider1.SetIconAlignment(Me.Cancel_Button, CType(resources.GetObject("Cancel_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'lbIP
        '
        resources.ApplyResources(Me.lbIP, "lbIP")
        Me.ErrorProvider1.SetIconAlignment(Me.lbIP, CType(resources.GetObject("lbIP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbIP.Name = "lbIP"
        '
        'lbNetbios
        '
        resources.ApplyResources(Me.lbNetbios, "lbNetbios")
        Me.ErrorProvider1.SetIconAlignment(Me.lbNetbios, CType(resources.GetObject("lbNetbios.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbNetbios.Name = "lbNetbios"
        '
        'lbName
        '
        resources.ApplyResources(Me.lbName, "lbName")
        Me.ErrorProvider1.SetIconAlignment(Me.lbName, CType(resources.GetObject("lbName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbName.Name = "lbName"
        '
        'lbMAC
        '
        resources.ApplyResources(Me.lbMAC, "lbMAC")
        Me.ErrorProvider1.SetIconAlignment(Me.lbMAC, CType(resources.GetObject("lbMAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbMAC.Name = "lbMAC"
        '
        'TextBox_Command
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBox_Command, CType(resources.GetObject("TextBox_Command.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.TextBox_Command, "TextBox_Command")
        Me.TextBox_Command.Name = "TextBox_Command"
        '
        'lbShutdownCommand
        '
        resources.ApplyResources(Me.lbShutdownCommand, "lbShutdownCommand")
        Me.ErrorProvider1.SetIconAlignment(Me.lbShutdownCommand, CType(resources.GetObject("lbShutdownCommand.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbShutdownCommand.Name = "lbShutdownCommand"
        '
        'CheckBox_Emergency
        '
        resources.ApplyResources(Me.CheckBox_Emergency, "CheckBox_Emergency")
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBox_Emergency, CType(resources.GetObject("CheckBox_Emergency.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.CheckBox_Emergency.Name = "CheckBox_Emergency"
        Me.CheckBox_Emergency.UseVisualStyleBackColor = True
        '
        'Delete_Button
        '
        Me.ErrorProvider1.SetIconAlignment(Me.Delete_Button, CType(resources.GetObject("Delete_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.Delete_Button, "Delete_Button")
        Me.Delete_Button.Name = "Delete_Button"
        Me.Delete_Button.UseVisualStyleBackColor = True
        '
        'Group
        '
        Me.ErrorProvider1.SetIconAlignment(Me.Group, CType(resources.GetObject("Group.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.Group, "Group")
        Me.Group.Name = "Group"
        '
        'lbGroup
        '
        resources.ApplyResources(Me.lbGroup, "lbGroup")
        Me.ErrorProvider1.SetIconAlignment(Me.lbGroup, CType(resources.GetObject("lbGroup.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbGroup.Name = "lbGroup"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbBroadcast
        '
        resources.ApplyResources(Me.lbBroadcast, "lbBroadcast")
        Me.ErrorProvider1.SetIconAlignment(Me.lbBroadcast, CType(resources.GetObject("lbBroadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbBroadcast.Name = "lbBroadcast"
        '
        'lbTTL
        '
        resources.ApplyResources(Me.lbTTL, "lbTTL")
        Me.ErrorProvider1.SetIconAlignment(Me.lbTTL, CType(resources.GetObject("lbTTL.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbTTL.Name = "lbTTL"
        '
        'lbUDP
        '
        resources.ApplyResources(Me.lbUDP, "lbUDP")
        Me.ErrorProvider1.SetIconAlignment(Me.lbUDP, CType(resources.GetObject("lbUDP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbUDP.Name = "lbUDP"
        '
        'lbLeaveBlank
        '
        resources.ApplyResources(Me.lbLeaveBlank, "lbLeaveBlank")
        Me.ErrorProvider1.SetIconAlignment(Me.lbLeaveBlank, CType(resources.GetObject("lbLeaveBlank.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbLeaveBlank.Name = "lbLeaveBlank"
        '
        'lbSendTo
        '
        resources.ApplyResources(Me.lbSendTo, "lbSendTo")
        Me.ErrorProvider1.SetIconAlignment(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbSendTo.Name = "lbSendTo"
        '
        'TTL
        '
        Me.TTL.ErrorColor = System.Drawing.Color.Red
        Me.TTL.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.TTL, CType(resources.GetObject("TTL.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.TTL, "TTL")
        Me.TTL.Name = "TTL"
        Me.TTL.ValidationExpression = "^\d+$"
        '
        'UDPPort
        '
        Me.UDPPort.ErrorColor = System.Drawing.Color.Red
        Me.UDPPort.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.UDPPort, CType(resources.GetObject("UDPPort.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.UDPPort, "UDPPort")
        Me.UDPPort.Name = "UDPPort"
        Me.UDPPort.ValidationExpression = "^\d+$"
        '
        'Broadcast
        '
        Me.Broadcast.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.Broadcast.BackColor = System.Drawing.SystemColors.Window
        Me.ErrorProvider1.SetIconAlignment(Me.Broadcast, CType(resources.GetObject("Broadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.Broadcast, "Broadcast")
        Me.Broadcast.Name = "Broadcast"
        '
        'MachineName
        '
        Me.MachineName.ErrorColor = System.Drawing.Color.Red
        Me.MachineName.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MachineName, CType(resources.GetObject("MachineName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.MachineName, "MachineName")
        Me.MachineName.Name = "MachineName"
        Me.ToolTip1.SetToolTip(Me.MachineName, resources.GetString("MachineName.ToolTip"))
        Me.MachineName.ValidationExpression = "\w{1,}"
        '
        'MAC
        '
        Me.MAC.ErrorColor = System.Drawing.Color.Red
        Me.MAC.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MAC, CType(resources.GetObject("MAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.MAC, "MAC")
        Me.MAC.Name = "MAC"
        Me.ToolTip1.SetToolTip(Me.MAC, resources.GetString("MAC.ToolTip"))
        Me.MAC.ValidationExpression = "^([0-9a-fA-F]{2}([-:])?){5}[0-9a-fA-F]{2}$"
        '
        'IP
        '
        Me.IP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.IP.BackColor = System.Drawing.SystemColors.Window
        Me.ErrorProvider1.SetIconAlignment(Me.IP, CType(resources.GetObject("IP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.IP, "IP")
        Me.IP.Name = "IP"
        '
        'bCalcBroadcast
        '
        resources.ApplyResources(Me.bCalcBroadcast, "bCalcBroadcast")
        Me.bCalcBroadcast.Name = "bCalcBroadcast"
        Me.bCalcBroadcast.UseVisualStyleBackColor = True
        '
        'Help_Button
        '
        resources.ApplyResources(Me.Help_Button, "Help_Button")
        Me.Help_Button.Name = "Help_Button"
        Me.Help_Button.UseVisualStyleBackColor = True
        '
        'rbIP
        '
        resources.ApplyResources(Me.rbIP, "rbIP")
        Me.rbIP.Name = "rbIP"
        Me.rbIP.TabStop = True
        Me.rbIP.UseVisualStyleBackColor = True
        '
        'rbURI
        '
        resources.ApplyResources(Me.rbURI, "rbURI")
        Me.rbURI.Name = "rbURI"
        Me.rbURI.TabStop = True
        Me.rbURI.UseVisualStyleBackColor = True
        '
        'ComboBoxAdapters
        '
        Me.ComboBoxAdapters.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxAdapters, "ComboBoxAdapters")
        Me.ComboBoxAdapters.Name = "ComboBoxAdapters"
        '
        'LabelInterfaces
        '
        resources.ApplyResources(Me.LabelInterfaces, "LabelInterfaces")
        Me.LabelInterfaces.Name = "LabelInterfaces"
        '
        'tHostURI
        '
        Me.tHostURI.ErrorColor = System.Drawing.Color.Red
        Me.tHostURI.ErrorMessage = Nothing
        resources.ApplyResources(Me.tHostURI, "tHostURI")
        Me.tHostURI.Name = "tHostURI"
        Me.tHostURI.ValidationExpression = "^(?!\s*$).+"
        '
        'Properties
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.tHostURI)
        Me.Controls.Add(Me.LabelInterfaces)
        Me.Controls.Add(Me.ComboBoxAdapters)
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
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.MachineName)
        Me.Controls.Add(Me.MAC)
        Me.Controls.Add(Me.Group)
        Me.Controls.Add(Me.lbGroup)
        Me.Controls.Add(Me.Delete_Button)
        Me.Controls.Add(Me.TextBox_Command)
        Me.Controls.Add(Me.lbShutdownCommand)
        Me.Controls.Add(Me.CheckBox_Emergency)
        Me.Controls.Add(Me.lbNetbios)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbMAC)
        Me.Controls.Add(Me.lbIP)
        Me.Controls.Add(Me.IP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Properties"
        Me.ShowInTaskbar = False
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
    Friend WithEvents ComboBoxAdapters As System.Windows.Forms.ComboBox
    Friend WithEvents LabelInterfaces As System.Windows.Forms.Label
    Friend WithEvents tHostURI As WakeOnLan.RegExTextBox

End Class
