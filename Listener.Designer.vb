<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listener
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Listener))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader_IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_Time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList_Large = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_clear = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lUDPport = New System.Windows.Forms.Label()
        Me.LabelHeader = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_IP, Me.ColumnHeader_Time, Me.ColumnHeader_Name})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.LargeImageList = Me.ImageList_Large
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Name = "ListView1"
        Me.ListView1.TileSize = New System.Drawing.Size(410, 52)
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader_IP
        '
        resources.ApplyResources(Me.ColumnHeader_IP, "ColumnHeader_IP")
        '
        'ColumnHeader_Time
        '
        resources.ApplyResources(Me.ColumnHeader_Time, "ColumnHeader_Time")
        '
        'ColumnHeader_Name
        '
        resources.ApplyResources(Me.ColumnHeader_Name, "ColumnHeader_Name")
        '
        'ImageList_Large
        '
        Me.ImageList_Large.ImageStream = CType(resources.GetObject("ImageList_Large.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Large.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Large.Images.SetKeyName(0, "connected_48x48.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WakeOnLan.My.Resources.Resources.network_transmit
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Button_clear
        '
        resources.ApplyResources(Me.Button_clear, "Button_clear")
        Me.Button_clear.Name = "Button_clear"
        Me.Button_clear.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lUDPport)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lUDPport
        '
        resources.ApplyResources(Me.lUDPport, "lUDPport")
        Me.lUDPport.Name = "lUDPport"
        '
        'LabelHeader
        '
        resources.ApplyResources(Me.LabelHeader, "LabelHeader")
        Me.LabelHeader.Name = "LabelHeader"
        '
        'Listener
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_clear)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Listener"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader_IP As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader_Time As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList_Large As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button_clear As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lUDPport As System.Windows.Forms.Label
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
