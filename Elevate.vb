Imports System.Runtime.InteropServices

Public Class Elevate
    <DllImport("user32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Shared Function SendMessage( _
        ByVal hWnd As IntPtr, _
        ByVal msg As Integer, _
        ByVal wParam As Integer, _
        ByVal lParam As IntPtr) _
        As Integer
    End Function

    Const BCM_SETSHIELD As UInt32 = &H160C

    Private Sub CreateEventSource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Update the Self-elevate button to show the UAC shield icon.
        btnElevate.FlatStyle = FlatStyle.System
        SendMessage(btnElevate.Handle, BCM_SETSHIELD, 0, New IntPtr(1))
    End Sub

    Private Sub btnElevate_Click(sender As Object, e As EventArgs) Handles btnElevate.Click
        ' Launch itself as administrator
        Dim proc As New ProcessStartInfo
        proc.UseShellExecute = True
        proc.WorkingDirectory = Environment.CurrentDirectory
        proc.FileName = Application.ExecutablePath
        proc.Verb = "runas"

        Try
            Process.Start(proc)
        Catch
            ' The user refused to allow privileges elevation.
            ' Do nothing and return directly ...
            Return
        End Try

        Application.Exit()  ' Quit itself
    End Sub
End Class