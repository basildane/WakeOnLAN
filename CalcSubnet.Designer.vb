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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalcSubnet))
        Me.bCalculate = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.IpBroadcast = New WakeOnLan.IPAddressControl()
        Me.IpSubnet = New WakeOnLan.IPAddressControl()
        Me.IpIP = New WakeOnLan.IPAddressControl()
        Me.lIP = New System.Windows.Forms.Label()
        Me.lSubnet = New System.Windows.Forms.Label()
        Me.lRecommended = New System.Windows.Forms.Label()
        Me.lHeader = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'bCalculate
        '
        resources.ApplyResources(Me.bCalculate, "bCalculate")
        Me.bCalculate.Name = "bCalculate"
        Me.bCalculate.UseVisualStyleBackColor = True
        '
        'bOK
        '
        resources.ApplyResources(Me.bOK, "bOK")
        Me.bOK.Name = "bOK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'IpBroadcast
        '
        resources.ApplyResources(Me.IpBroadcast, "IpBroadcast")
        Me.IpBroadcast.BackColor = System.Drawing.SystemColors.Window
        Me.IpBroadcast.Name = "IpBroadcast"
        '
        'IpSubnet
        '
        resources.ApplyResources(Me.IpSubnet, "IpSubnet")
        Me.IpSubnet.BackColor = System.Drawing.SystemColors.Window
        Me.IpSubnet.Name = "IpSubnet"
        '
        'IpIP
        '
        resources.ApplyResources(Me.IpIP, "IpIP")
        Me.IpIP.BackColor = System.Drawing.SystemColors.Window
        Me.IpIP.Name = "IpIP"
        '
        'lIP
        '
        resources.ApplyResources(Me.lIP, "lIP")
        Me.lIP.Name = "lIP"
        '
        'lSubnet
        '
        resources.ApplyResources(Me.lSubnet, "lSubnet")
        Me.lSubnet.Name = "lSubnet"
        '
        'lRecommended
        '
        resources.ApplyResources(Me.lRecommended, "lRecommended")
        Me.lRecommended.Name = "lRecommended"
        '
        'lHeader
        '
        resources.ApplyResources(Me.lHeader, "lHeader")
        Me.lHeader.Name = "lHeader"
        '
        'CalcSubnet
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lHeader)
        Me.Controls.Add(Me.lRecommended)
        Me.Controls.Add(Me.lSubnet)
        Me.Controls.Add(Me.lIP)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bCalculate)
        Me.Controls.Add(Me.IpBroadcast)
        Me.Controls.Add(Me.IpSubnet)
        Me.Controls.Add(Me.IpIP)
        Me.Name = "CalcSubnet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IpIP As WakeOnLan.IPAddressControl
    Friend WithEvents IpSubnet As WakeOnLan.IPAddressControl
    Friend WithEvents IpBroadcast As WakeOnLan.IPAddressControl
    Friend WithEvents bCalculate As System.Windows.Forms.Button
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents lIP As System.Windows.Forms.Label
    Friend WithEvents lSubnet As System.Windows.Forms.Label
    Friend WithEvents lRecommended As System.Windows.Forms.Label
    Friend WithEvents lHeader As System.Windows.Forms.Label
End Class
