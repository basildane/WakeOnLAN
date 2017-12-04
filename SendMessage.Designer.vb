<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendMessage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendMessage))
		Me.btnSend = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.txtMessage = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnSend
		'
		Me.btnSend.Location = New System.Drawing.Point(191, 288)
		Me.btnSend.Name = "btnSend"
		Me.btnSend.Size = New System.Drawing.Size(75, 23)
		Me.btnSend.TabIndex = 1
		Me.btnSend.Text = "Send"
		Me.btnSend.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(272, 288)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'txtMessage
		'
		Me.txtMessage.Location = New System.Drawing.Point(12, 31)
		Me.txtMessage.Multiline = True
		Me.txtMessage.Name = "txtMessage"
		Me.txtMessage.Size = New System.Drawing.Size(335, 237)
		Me.txtMessage.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 15)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(77, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Send message"
		'
		'SendMessage
		'
		Me.AcceptButton = Me.btnSend
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(370, 331)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.txtMessage)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSend)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "SendMessage"
		Me.Text = "Send Message"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnSend As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents txtMessage As TextBox
	Friend WithEvents Label1 As Label
End Class
