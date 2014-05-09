'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2014 Aquila Technology, LLC. <webmaster@aquilatech.com>
'
'    This file is part of WakeOnLAN.
'
'    WakeOnLAN is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    WakeOnLAN is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication
        Private Declare Function ShowWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
        Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
        Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As IntPtr

        ' Defines:
        ' DISPLAY  - used to zero out the last part of MAC addresses for screenshots

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            configureCulture()
            singleInstance()
            upgradeSettings()

#If DEBUG Then
            My.Settings.dbPath = "\\aquila\files\Administration\WakeOnLAN\machines.xml"
#End If

        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            My.Application.Log.WriteException(e.Exception, TraceEventType.Critical, "Application shut down at " & My.Computer.Clock.GmtTime.ToString)
        End Sub

        ''' <summary>
        ''' Setup the culture and language configuration.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub configureCulture()

#If DEBUG Then
            'My.Settings.Language = "ro-RO"
            My.Settings.Language = "en-US"
#End If

            If My.Settings.Language = "" Then
                My.Settings.Language = My.Application.Culture.Name
                My.Application.ChangeUICulture(My.Settings.Language)
                My.Application.ChangeCulture(My.Settings.Language)
                My.Settings.DefaultMessage = My.Resources.Strings.DefaultMessage
                My.Settings.emerg_message = My.Resources.Strings.DefaultEmergency
            Else
                My.Application.ChangeUICulture(My.Settings.Language)
                My.Application.ChangeCulture(My.Settings.Language)
            End If

            Debug.WriteLine(My.Settings.Language)
        End Sub

        ''' <summary>
        ''' Search for another running instance of WOL.  If found, activate it and terminate this instance.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub singleInstance()
            Const SW_RESTORE As Int32 = 9
            Const SW_SHOW As Int32 = 5
            Dim hwnd As IntPtr

            hwnd = FindWindow(Nothing, My.Resources.Strings.Title)
            If hwnd <> IntPtr.Zero Then
                ShowWindow(hwnd, SW_SHOW)
                ShowWindow(hwnd, SW_RESTORE)
                SetForegroundWindow(hwnd)
                End
            End If

        End Sub

        ''' <summary>
        ''' If this is an upgrade from a previous version, try to recover the previous user settings.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub upgradeSettings()
            Dim regKey As Microsoft.Win32.RegistryKey
            Dim database As String

            If My.Settings.needUpgrade Then
                My.Settings.Upgrade()
                My.Settings.needUpgrade = False

                Try
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Aquila Technology\WakeOnLAN")
                    database = regKey.GetValue("Database", IO.Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.ToString).ToString, Microsoft.Win32.RegistryValueOptions.None)
                    My.Settings.dbPath = IO.Path.Combine(database, "machines.xml")

                Catch ex As Exception

                End Try

                My.Settings.Save()
            End If
        End Sub
    End Class

End Namespace

