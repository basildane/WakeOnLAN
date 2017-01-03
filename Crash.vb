Public Class Crash
    Public exception As Exception

    Private Sub Crash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lError.Text = String.Format("{1}{0}{0}At {2} GMT.{0}Version {3}", Environment.NewLine, exception.Message, My.Computer.Clock.GmtTime.ToString, My.Application.Info.Version)
        tStack.Text = exception.StackTrace
    End Sub

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class
