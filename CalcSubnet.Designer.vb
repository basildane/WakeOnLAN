<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalcSubnet
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
        Me.bCalculate = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.IpBroadcast = New WakeOnLan.IPAddressControl()
        Me.IpSubnet = New WakeOnLan.IPAddressControl()
        Me.IpIP = New WakeOnLan.IPAddressControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'bCalculate
        '
        Me.bCalculate.Location = New System.Drawing.Point(15, 236)
        Me.bCalculate.Name = "bCalculate"
        Me.bCalculate.Size = New System.Drawing.Size(75, 23)
        Me.bCalculate.TabIndex = 3
        Me.bCalculate.Text = "Calculate"
        Me.bCalculate.UseVisualStyleBackColor = True
        '
        'bOK
        '
        Me.bOK.Location = New System.Drawing.Point(197, 236)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(75, 23)
        Me.bOK.TabIndex = 4
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'IpBroadcast
        '
        Me.IpBroadcast.BackColor = System.Drawing.SystemColors.Window
        Me.IpBroadcast.Enabled = False
        Me.IpBroadcast.Location = New System.Drawing.Point(143, 180)
        Me.IpBroadcast.Name = "IpBroadcast"
        Me.IpBroadcast.Size = New System.Drawing.Size(129, 24)
        Me.IpBroadcast.TabIndex = 2
        '
        'IpSubnet
        '
        Me.IpSubnet.BackColor = System.Drawing.SystemColors.Window
        Me.IpSubnet.Location = New System.Drawing.Point(143, 106)
        Me.IpSubnet.Name = "IpSubnet"
        Me.IpSubnet.Size = New System.Drawing.Size(129, 24)
        Me.IpSubnet.TabIndex = 1
        '
        'IpIP
        '
        Me.IpIP.BackColor = System.Drawing.SystemColors.Window
        Me.IpIP.Location = New System.Drawing.Point(143, 64)
        Me.IpIP.Name = "IpIP"
        Me.IpIP.Size = New System.Drawing.Size(129, 24)
        Me.IpIP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Subnet"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Recommended Broadcast Address:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(260, 57)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "This function is used to help you find the ""Broadcast Address"" to use, based on t" & _
    "he IP Address and Subnet."
        '
        'CalcSubnet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 277)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bCalculate)
        Me.Controls.Add(Me.IpBroadcast)
        Me.Controls.Add(Me.IpSubnet)
        Me.Controls.Add(Me.IpIP)
        Me.Name = "CalcSubnet"
        Me.Text = "Calculate Subnet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IpIP As WakeOnLan.IPAddressControl
    Friend WithEvents IpSubnet As WakeOnLan.IPAddressControl
    Friend WithEvents IpBroadcast As WakeOnLan.IPAddressControl
    Friend WithEvents bCalculate As System.Windows.Forms.Button
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
