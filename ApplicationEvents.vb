'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2013 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

#If DEBUG Then
            My.Settings.dbPath = "\\aquila\files\Administration\WakeOnLAN\machines.xml"
            My.Settings.Language = "fi-FI"
            'My.Forms.Listener.Show()
            'Exit Sub
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
            My.Forms.SplashScreen.Show()

        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            My.Application.Log.WriteException(e.Exception, TraceEventType.Critical, "Application shut down at " & My.Computer.Clock.GmtTime.ToString)
        End Sub

    End Class

End Namespace

