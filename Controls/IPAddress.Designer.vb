Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IpAddressControl
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.txtIP4 = New System.Windows.Forms.TextBox()
            Me.dot3 = New System.Windows.Forms.Label()
            Me.txtIP3 = New System.Windows.Forms.TextBox()
            Me.dot2 = New System.Windows.Forms.Label()
            Me.txtIP2 = New System.Windows.Forms.TextBox()
            Me.dot1 = New System.Windows.Forms.Label()
            Me.txtIP1 = New System.Windows.Forms.TextBox()
            Me.SuspendLayout()
            '
            'txtIP4
            '
            Me.txtIP4.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtIP4.Location = New System.Drawing.Point(97, 3)
            Me.txtIP4.MaxLength = 3
            Me.txtIP4.Name = "txtIP4"
            Me.txtIP4.Size = New System.Drawing.Size(26, 13)
            Me.txtIP4.TabIndex = 6
            Me.txtIP4.Text = "255"
            Me.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'dot3
            '
            Me.dot3.BackColor = System.Drawing.SystemColors.Window
            Me.dot3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dot3.Location = New System.Drawing.Point(90, 3)
            Me.dot3.Name = "dot3"
            Me.dot3.Size = New System.Drawing.Size(10, 13)
            Me.dot3.TabIndex = 5
            Me.dot3.Text = "."
            '
            'txtIP3
            '
            Me.txtIP3.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtIP3.Location = New System.Drawing.Point(64, 3)
            Me.txtIP3.MaxLength = 3
            Me.txtIP3.Name = "txtIP3"
            Me.txtIP3.Size = New System.Drawing.Size(26, 13)
            Me.txtIP3.TabIndex = 4
            Me.txtIP3.Text = "255"
            Me.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'dot2
            '
            Me.dot2.BackColor = System.Drawing.SystemColors.Window
            Me.dot2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dot2.Location = New System.Drawing.Point(58, 3)
            Me.dot2.Name = "dot2"
            Me.dot2.Size = New System.Drawing.Size(10, 13)
            Me.dot2.TabIndex = 3
            Me.dot2.Text = "."
            '
            'txtIP2
            '
            Me.txtIP2.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtIP2.Location = New System.Drawing.Point(33, 3)
            Me.txtIP2.MaxLength = 3
            Me.txtIP2.Name = "txtIP2"
            Me.txtIP2.Size = New System.Drawing.Size(26, 13)
            Me.txtIP2.TabIndex = 2
            Me.txtIP2.Text = "255"
            Me.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'dot1
            '
            Me.dot1.BackColor = System.Drawing.SystemColors.Window
            Me.dot1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dot1.Location = New System.Drawing.Point(25, 3)
            Me.dot1.Name = "dot1"
            Me.dot1.Size = New System.Drawing.Size(10, 13)
            Me.dot1.TabIndex = 1
            Me.dot1.Text = "."
            '
            'txtIP1
            '
            Me.txtIP1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtIP1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtIP1.Location = New System.Drawing.Point(2, 3)
            Me.txtIP1.MaxLength = 3
            Me.txtIP1.Name = "txtIP1"
            Me.txtIP1.Size = New System.Drawing.Size(27, 13)
            Me.txtIP1.TabIndex = 0
            Me.txtIP1.Text = "255"
            Me.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'IpAddressControl
            '
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Controls.Add(Me.txtIP4)
            Me.Controls.Add(Me.dot3)
            Me.Controls.Add(Me.txtIP3)
            Me.Controls.Add(Me.dot2)
            Me.Controls.Add(Me.txtIP2)
            Me.Controls.Add(Me.dot1)
            Me.Controls.Add(Me.txtIP1)
            Me.Name = "IpAddressControl"
            Me.Size = New System.Drawing.Size(127, 18)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents txtIP4 As System.Windows.Forms.TextBox
        Private WithEvents dot3 As System.Windows.Forms.Label
        Private WithEvents txtIP3 As System.Windows.Forms.TextBox
        Private WithEvents dot2 As System.Windows.Forms.Label
        Private WithEvents txtIP2 As System.Windows.Forms.TextBox
        Private WithEvents dot1 As System.Windows.Forms.Label
        Private WithEvents txtIP1 As System.Windows.Forms.TextBox

    End Class
End Namespace