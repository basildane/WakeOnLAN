Public Class SendMessage
	Private machineNames As String()
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	Public Sub New(items As String())

		' This call is required by the designer.
		InitializeComponent()
		machineNames = items
		Show()
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		Close()
	End Sub

	Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
		For Each item As String In machineNames
			Dim machine As Machines.Machine = Machines(item)
			Shutdown.PopupMessage(machine, txtMessage.Text)
		Next
		Close()
	End Sub
End Class