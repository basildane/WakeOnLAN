<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.ApplicationTitle = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.PictureBox_GPL = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_GPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ApplicationTitle
        '
        resources.ApplyResources(Me.ApplicationTitle, "ApplicationTitle")
        Me.ApplicationTitle.BackColor = System.Drawing.SystemColors.Control
        Me.ApplicationTitle.Name = "ApplicationTitle"
        '
        'Version
        '
        resources.ApplyResources(Me.Version, "Version")
        Me.Version.BackColor = System.Drawing.SystemColors.Control
        Me.Version.Name = "Version"
        '
        'Copyright
        '
        resources.ApplyResources(Me.Copyright, "Copyright")
        Me.Copyright.BackColor = System.Drawing.SystemColors.Control
        Me.Copyright.Name = "Copyright"
        '
        'Timer1
        '
        Me.Timer1.Interval = 4000
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Name = "Label1"
        '
        'PictureBox_logo
        '
        resources.ApplyResources(Me.PictureBox_logo, "PictureBox_logo")
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.TabStop = False
        '
        'PictureBox_GPL
        '
        resources.ApplyResources(Me.PictureBox_GPL, "PictureBox_GPL")
        Me.PictureBox_GPL.Name = "PictureBox_GPL"
        Me.PictureBox_GPL.TabStop = False
        '
        'SplashScreen
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox_GPL)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ApplicationTitle)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Copyright)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.Color.Magenta
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_GPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox_GPL As System.Windows.Forms.PictureBox

End Class
