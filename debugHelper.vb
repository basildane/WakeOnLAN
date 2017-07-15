Public Class debugHelper
    Private Sub debugHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Log(text As String)
        TextBox1.AppendText(String.Format("{0:MM/dd/yyy HH:mm:ss.fff}: {1}", DateTime.Now(), text & vbCrLf))
    End Sub
End Class