Imports Microsoft.Win32

Public Class Autorun
    Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")

    Property autorun As Boolean
        Get
            With CU
                .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False)
                If (.GetValue(My.Application.Info.ProductName, "", RegistryValueOptions.None) = "") Then
                    Return False
                Else
                    Return True
                End If
            End With
        End Get

        Set(value As Boolean)
            With CU
                .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                If (value) Then
                    .SetValue(My.Application.Info.ProductName, """" & Application.ExecutablePath & """" & " /min")
                Else
                    .DeleteValue(My.Application.Info.ProductName, False)
                End If
            End With

        End Set

    End Property

End Class
