Imports WakeOnLan.Controls

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
        Me.lbSendTo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lNotes = New System.Windows.Forms.Label()
        Me.MachineName = New WakeOnLan.Controls.RegExTextBox()
        Me.Broadcast = New WakeOnLan.Controls.IpAddressControl()
        Me.IP = New WakeOnLan.Controls.IpAddressControl()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabProperties = New System.Windows.Forms.TabPage()
        Me.TextBox_Notes = New System.Windows.Forms.TextBox()
        Me.TabWakeUp = New System.Windows.Forms.TabPage()
        Me.cbKeepAlive = New System.Windows.Forms.CheckBox()
        Me.tHostURI = New WakeOnLan.Controls.RegExTextBox()
        Me.bCalcBroadcast = New System.Windows.Forms.Button()
        Me.rbURI = New System.Windows.Forms.RadioButton()
        Me.rbIP = New System.Windows.Forms.RadioButton()
        Me.TTL = New WakeOnLan.Controls.RegExTextBox()
        Me.UDPPort = New WakeOnLan.Controls.RegExTextBox()
        Me.MAC = New WakeOnLan.Controls.RegExTextBox()
        Me.TabStatus = New System.Windows.Forms.TabPage()
        Me.lbRemoteDesktop = New System.Windows.Forms.Label()
        Me.lbLeaveBlank = New System.Windows.Forms.Label()
        Me.lbRDPPort = New System.Windows.Forms.Label()
        Me.tRDPPort = New WakeOnLan.Controls.RegExTextBox()
        Me.TabShutdown = New System.Windows.Forms.TabPage()
        Me.tDomain = New WakeOnLan.Controls.RegExTextBox()
        Me.tPassword = New WakeOnLan.Controls.RegExTextBox()
        Me.tUserId = New WakeOnLan.Controls.RegExTextBox()
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
        Me.TabShutdown.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.ErrorProvider1.SetIconAlignment(Me.OK_Button, CType(resources.GetObject("OK_Button.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
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
        'lbSendTo
        '
        resources.ApplyResources(Me.lbSendTo, "lbSendTo")
        Me.ErrorProvider1.SetIconAlignment(Me.lbSendTo, CType(resources.GetObject("lbSendTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lbSendTo.Name = "lbSendTo"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.ErrorProvider1.SetIconAlignment(Me.Label1, CType(resources.GetObject("Label1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label1.Name = "Label1"
        '
        'lNotes
        '
        resources.ApplyResources(Me.lNotes, "lNotes")
        Me.ErrorProvider1.SetIconAlignment(Me.lNotes, CType(resources.GetObject("lNotes.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.lNotes.Name = "lNotes"
        '
        'MachineName
        '
        Me.MachineName.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.MachineName, "MachineName")
        Me.ErrorProvider1.SetIconAlignment(Me.MachineName, CType(resources.GetObject("MachineName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MachineName.Name = "MachineName"
        Me.ToolTip1.SetToolTip(Me.MachineName, resources.GetString("MachineName.ToolTip"))
        Me.MachineName.ValidationExpression = "\w{1,}"
        '
        'Broadcast
        '
        Me.Broadcast.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.Broadcast.BackColor = System.Drawing.SystemColors.Window
        Me.Broadcast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Broadcast, "Broadcast")
        Me.ErrorProvider1.SetIconAlignment(Me.Broadcast, CType(resources.GetObject("Broadcast.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Broadcast.Name = "Broadcast"
        '
        'IP
        '
        Me.IP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.IP.BackColor = System.Drawing.SystemColors.Window
        Me.IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.IP, "IP")
        Me.ErrorProvider1.SetIconAlignment(Me.IP, CType(resources.GetObject("IP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.IP.Name = "IP"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabProperties)
        Me.TabControl1.Controls.Add(Me.TabWakeUp)
        Me.TabControl1.Controls.Add(Me.TabStatus)
        Me.TabControl1.Controls.Add(Me.TabShutdown)
        Me.ErrorProvider1.SetIconAlignment(Me.TabControl1, CType(resources.GetObject("TabControl1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabProperties
        '
        Me.TabProperties.Controls.Add(Me.lNotes)
        Me.TabProperties.Controls.Add(Me.TextBox_Notes)
        Me.TabProperties.Controls.Add(Me.Group)
        Me.TabProperties.Controls.Add(Me.lbGroup)
        Me.TabProperties.Controls.Add(Me.lbName)
        Me.TabProperties.Controls.Add(Me.MachineName)
        resources.ApplyResources(Me.TabProperties, "TabProperties")
        Me.TabProperties.Name = "TabProperties"
        Me.TabProperties.UseVisualStyleBackColor = True
        '
        'TextBox_Notes
        '
        resources.ApplyResources(Me.TextBox_Notes, "TextBox_Notes")
        Me.TextBox_Notes.Name = "TextBox_Notes"
        '
        'TabWakeUp
        '
        Me.TabWakeUp.Controls.Add(Me.cbKeepAlive)
        Me.TabWakeUp.Controls.Add(Me.tHostURI)
        Me.TabWakeUp.Controls.Add(Me.lbUDP)
        Me.TabWakeUp.Controls.Add(Me.lbTTL)
        Me.TabWakeUp.Controls.Add(Me.lbMAC)
        Me.TabWakeUp.Controls.Add(Me.bCalcBroadcast)
        Me.TabWakeUp.Controls.Add(Me.lbNetbios)
        Me.TabWakeUp.Controls.Add(Me.lbSendTo)
        Me.TabWakeUp.Controls.Add(Me.rbURI)
        Me.TabWakeUp.Controls.Add(Me.rbIP)
        Me.TabWakeUp.Controls.Add(Me.lbBroadcast)
        Me.TabWakeUp.Controls.Add(Me.TTL)
        Me.TabWakeUp.Controls.Add(Me.UDPPort)
        Me.TabWakeUp.Controls.Add(Me.Broadcast)
        Me.TabWakeUp.Controls.Add(Me.MAC)
        resources.ApplyResources(Me.TabWakeUp, "TabWakeUp")
        Me.TabWakeUp.Name = "TabWakeUp"
        Me.TabWakeUp.UseVisualStyleBackColor = True
        '
        'cbKeepAlive
        '
        resources.ApplyResources(Me.cbKeepAlive, "cbKeepAlive")
        Me.cbKeepAlive.Name = "cbKeepAlive"
        Me.cbKeepAlive.UseVisualStyleBackColor = True
        '
        'tHostURI
        '
        Me.tHostURI.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.tHostURI, "tHostURI")
        Me.tHostURI.Name = "tHostURI"
        Me.tHostURI.ValidationExpression = "^(?!\s*$).+"
        '
        'bCalcBroadcast
        '
        resources.ApplyResources(Me.bCalcBroadcast, "bCalcBroadcast")
        Me.bCalcBroadcast.Name = "bCalcBroadcast"
        Me.bCalcBroadcast.UseVisualStyleBackColor = True
        '
        'rbURI
        '
        resources.ApplyResources(Me.rbURI, "rbURI")
        Me.rbURI.Name = "rbURI"
        Me.rbURI.TabStop = True
        Me.rbURI.UseVisualStyleBackColor = True
        '
        'rbIP
        '
        resources.ApplyResources(Me.rbIP, "rbIP")
        Me.rbIP.Name = "rbIP"
        Me.rbIP.TabStop = True
        Me.rbIP.UseVisualStyleBackColor = True
        '
        'TTL
        '
        Me.TTL.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.TTL, "TTL")
        Me.TTL.Name = "TTL"
        Me.TTL.ValidationExpression = "^\d+$"
        '
        'UDPPort
        '
        Me.UDPPort.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.UDPPort, "UDPPort")
        Me.UDPPort.Name = "UDPPort"
        Me.UDPPort.ValidationExpression = "^\d+$"
        '
        'MAC
        '
        Me.MAC.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.MAC, "MAC")
        Me.MAC.ForeColor = System.Drawing.Color.Red
        Me.MAC.Name = "MAC"
        Me.ToolTip1.SetToolTip(Me.MAC, resources.GetString("MAC.ToolTip"))
        Me.MAC.ValidationExpression = "^([0-9a-fA-F]{2}([-:])?){5}[0-9a-fA-F]{2}$"
        '
        'TabStatus
        '
        Me.TabStatus.Controls.Add(Me.lbRemoteDesktop)
        Me.TabStatus.Controls.Add(Me.lbLeaveBlank)
        Me.TabStatus.Controls.Add(Me.lbIP)
        Me.TabStatus.Controls.Add(Me.Label1)
        Me.TabStatus.Controls.Add(Me.lbRDPPort)
        Me.TabStatus.Controls.Add(Me.IP)
        Me.TabStatus.Controls.Add(Me.tRDPPort)
        resources.ApplyResources(Me.TabStatus, "TabStatus")
        Me.TabStatus.Name = "TabStatus"
        Me.TabStatus.UseVisualStyleBackColor = True
        '
        'lbRemoteDesktop
        '
        resources.ApplyResources(Me.lbRemoteDesktop, "lbRemoteDesktop")
        Me.lbRemoteDesktop.Name = "lbRemoteDesktop"
        '
        'lbLeaveBlank
        '
        resources.ApplyResources(Me.lbLeaveBlank, "lbLeaveBlank")
        Me.lbLeaveBlank.Name = "lbLeaveBlank"
        '
        'lbRDPPort
        '
        resources.ApplyResources(Me.lbRDPPort, "lbRDPPort")
        Me.lbRDPPort.Name = "lbRDPPort"
        '
        'tRDPPort
        '
        Me.tRDPPort.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.tRDPPort, "tRDPPort")
        Me.tRDPPort.Name = "tRDPPort"
        Me.ToolTip1.SetToolTip(Me.tRDPPort, resources.GetString("tRDPPort.ToolTip"))
        Me.tRDPPort.ValidationExpression = ""
        '
        'TabShutdown
        '
        Me.TabShutdown.Controls.Add(Me.tDomain)
        Me.TabShutdown.Controls.Add(Me.tPassword)
        Me.TabShutdown.Controls.Add(Me.tUserId)
        Me.TabShutdown.Controls.Add(Me.lDomain)
        Me.TabShutdown.Controls.Add(Me.lPassword)
        Me.TabShutdown.Controls.Add(Me.lUserId)
        Me.TabShutdown.Controls.Add(Me.lDescription)
        Me.TabShutdown.Controls.Add(Me.LabelShutdownMethod)
        Me.TabShutdown.Controls.Add(Me.ComboBoxShutdownMethod)
        Me.TabShutdown.Controls.Add(Me.TextBox_Command)
        Me.TabShutdown.Controls.Add(Me.lbShutdownCommand)
        Me.TabShutdown.Controls.Add(Me.CheckBox_Emergency)
        resources.ApplyResources(Me.TabShutdown, "TabShutdown")
        Me.TabShutdown.Name = "TabShutdown"
        Me.TabShutdown.UseVisualStyleBackColor = True
        '
        'tDomain
        '
        Me.tDomain.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.tDomain, "tDomain")
        Me.tDomain.Name = "tDomain"
        Me.tDomain.ValidationExpression = ""
        '
        'tPassword
        '
        Me.tPassword.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.tPassword, "tPassword")
        Me.tPassword.Name = "tPassword"
        Me.tPassword.UseSystemPasswordChar = True
        Me.tPassword.ValidationExpression = ""
        '
        'tUserId
        '
        Me.tUserId.ErrorColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.tUserId, "tUserId")
        Me.tUserId.Name = "tUserId"
        Me.tUserId.ValidationExpression = ""
        '
        'lDomain
        '
        resources.ApplyResources(Me.lDomain, "lDomain")
        Me.lDomain.Name = "lDomain"
        '
        'lPassword
        '
        resources.ApplyResources(Me.lPassword, "lPassword")
        Me.lPassword.Name = "lPassword"
        '
        'lUserId
        '
        resources.ApplyResources(Me.lUserId, "lUserId")
        Me.lUserId.Name = "lUserId"
        '
        'lDescription
        '
        resources.ApplyResources(Me.lDescription, "lDescription")
        Me.lDescription.Name = "lDescription"
        '
        'LabelShutdownMethod
        '
        resources.ApplyResources(Me.LabelShutdownMethod, "LabelShutdownMethod")
        Me.LabelShutdownMethod.Name = "LabelShutdownMethod"
        '
        'ComboBoxShutdownMethod
        '
        Me.ComboBoxShutdownMethod.FormattingEnabled = True
        Me.ComboBoxShutdownMethod.Items.AddRange(New Object() {resources.GetString("ComboBoxShutdownMethod.Items"), resources.GetString("ComboBoxShutdownMethod.Items1"), resources.GetString("ComboBoxShutdownMethod.Items2")})
        resources.ApplyResources(Me.ComboBoxShutdownMethod, "ComboBoxShutdownMethod")
        Me.ComboBoxShutdownMethod.Name = "ComboBoxShutdownMethod"
        '
        'Help_Button
        '
        resources.ApplyResources(Me.Help_Button, "Help_Button")
        Me.Help_Button.Name = "Help_Button"
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
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabProperties.ResumeLayout(False)
        Me.TabProperties.PerformLayout()
        Me.TabWakeUp.ResumeLayout(False)
        Me.TabWakeUp.PerformLayout()
        Me.TabStatus.ResumeLayout(False)
        Me.TabStatus.PerformLayout()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
End Class
