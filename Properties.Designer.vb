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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_Command = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox_Emergency = New System.Windows.Forms.CheckBox()
        Me.Edit_NETBIOS = New System.Windows.Forms.TextBox()
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.bCalcBroadcast = New System.Windows.Forms.Button()
        Me.Help_Button = New System.Windows.Forms.Button()
        Me.TTL = New WakeOnLan.RegExTextBox()
        Me.UDPPort = New WakeOnLan.RegExTextBox()
        Me.Broadcast = New WakeOnLan.IPAddressControl()
        Me.IP = New WakeOnLan.IPAddressControl()
        Me.MachineName = New WakeOnLan.RegExTextBox()
        Me.MAC = New WakeOnLan.RegExTextBox()
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
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.ErrorProvider1.SetIconAlignment(Me.Label3, CType(resources.GetObject("Label3.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label3.Name = "Label3"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.ErrorProvider1.SetIconAlignment(Me.Label11, CType(resources.GetObject("Label11.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.ErrorProvider1.SetIconAlignment(Me.Label10, CType(resources.GetObject("Label10.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label10.Name = "Label10"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.ErrorProvider1.SetIconAlignment(Me.Label9, CType(resources.GetObject("Label9.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label9.Name = "Label9"
        '
        'TextBox_Command
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBox_Command, CType(resources.GetObject("TextBox_Command.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.TextBox_Command, "TextBox_Command")
        Me.TextBox_Command.Name = "TextBox_Command"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.ErrorProvider1.SetIconAlignment(Me.Label1, CType(resources.GetObject("Label1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label1.Name = "Label1"
        '
        'CheckBox_Emergency
        '
        resources.ApplyResources(Me.CheckBox_Emergency, "CheckBox_Emergency")
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBox_Emergency, CType(resources.GetObject("CheckBox_Emergency.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.CheckBox_Emergency.Name = "CheckBox_Emergency"
        Me.CheckBox_Emergency.UseVisualStyleBackColor = True
        '
        'Edit_NETBIOS
        '
        Me.ErrorProvider1.SetIconAlignment(Me.Edit_NETBIOS, CType(resources.GetObject("Edit_NETBIOS.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.Edit_NETBIOS, "Edit_NETBIOS")
        Me.Edit_NETBIOS.Name = "Edit_NETBIOS"
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
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.ErrorProvider1.SetIconAlignment(Me.Label2, CType(resources.GetObject("Label2.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label2.Name = "Label2"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.ErrorProvider1.SetIconAlignment(Me.Label4, CType(resources.GetObject("Label4.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.ErrorProvider1.SetIconAlignment(Me.Label5, CType(resources.GetObject("Label5.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.ErrorProvider1.SetIconAlignment(Me.Label6, CType(resources.GetObject("Label6.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.Label6.Name = "Label6"
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
        'IP
        '
        Me.IP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.IP.BackColor = System.Drawing.SystemColors.Window
        Me.ErrorProvider1.SetIconAlignment(Me.IP, CType(resources.GetObject("IP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.IP, "IP")
        Me.IP.Name = "IP"
        '
        'MachineName
        '
        Me.MachineName.ErrorColor = System.Drawing.Color.Red
        Me.MachineName.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MachineName, CType(resources.GetObject("MachineName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.MachineName, "MachineName")
        Me.MachineName.Name = "MachineName"
        Me.MachineName.ValidationExpression = "^([\w\-]+){1,1}?$"
        '
        'MAC
        '
        Me.MAC.ErrorColor = System.Drawing.Color.Red
        Me.MAC.ErrorMessage = ""
        Me.ErrorProvider1.SetIconAlignment(Me.MAC, CType(resources.GetObject("MAC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        resources.ApplyResources(Me.MAC, "MAC")
        Me.MAC.Name = "MAC"
        Me.MAC.ValidationExpression = "^([0-9a-fA-F]{2}([-:])?){5}[0-9a-fA-F]{2}$"
        '
        'Properties
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.TTL)
        Me.Controls.Add(Me.UDPPort)
        Me.Controls.Add(Me.Help_Button)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bCalcBroadcast)
        Me.Controls.Add(Me.Broadcast)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.IP)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.MachineName)
        Me.Controls.Add(Me.MAC)
        Me.Controls.Add(Me.Group)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Delete_Button)
        Me.Controls.Add(Me.Edit_NETBIOS)
        Me.Controls.Add(Me.TextBox_Command)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox_Emergency)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Command As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Emergency As System.Windows.Forms.CheckBox
    Friend WithEvents Edit_NETBIOS As System.Windows.Forms.TextBox
    Friend WithEvents Delete_Button As System.Windows.Forms.Button
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents MAC As WakeOnLan.RegExTextBox
    Friend WithEvents MachineName As WakeOnLan.RegExTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents IP As WakeOnLan.IPAddressControl
    Friend WithEvents Broadcast As WakeOnLan.IPAddressControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bCalcBroadcast As System.Windows.Forms.Button
    Friend WithEvents Help_Button As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TTL As WakeOnLan.RegExTextBox
    Friend WithEvents UDPPort As WakeOnLan.RegExTextBox

End Class
