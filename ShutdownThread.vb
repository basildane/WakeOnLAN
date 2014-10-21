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

Imports System.ComponentModel
Imports System.Management
Imports WOL

Public Class ShutdownThread
    Public Enum ShutdownAction
        None
        Abort
        Shutdown
        Sleep
        Hibernate
        User
    End Enum

    Private WithEvents _backgroundWorker As New BackgroundWorker
    Private ReadOnly _item As ListViewItem
    Private ReadOnly _progressbar As ProgressBar
    Private _action As ShutdownAction
    Private ReadOnly _message As String
    Private ReadOnly _delay As Integer
    Private ReadOnly _force As Boolean
    Private ReadOnly _reboot As Boolean
    Private _errMessage As String

    Public Sub New(ByVal item As ListViewItem, ByVal progressbar As ProgressBar, ByVal action As ShutdownAction, ByVal message As String, ByVal delay As Integer, ByVal force As Boolean, ByVal reboot As Boolean)
        _item = item
        _progressbar = progressbar
        _action = action
        _message = message
        _delay = delay
        _force = force
        _reboot = reboot
        _errMessage = ""
        _backgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _backgroundWorker.DoWork
        Dim dwResult As Integer
        Dim sMachine As String
        Dim sAlertMessage As String
        Dim dwDelay As Long
        Dim dwForce As Long
        Dim dwReboot As Long
        Dim machine As Machine

        dwResult = 0
        sAlertMessage = _message & vbNullChar
        dwDelay = _delay
        dwForce = CLng(_force)
        dwReboot = CLng(_reboot)

        machine = Machines(_item.Text)
        sMachine = "\\" & machine.Netbios

        _item.SubItems(1).ForeColor = Color.FromKnownColor(KnownColor.WindowText)

        If (_action <> ShutdownAction.Abort And machine.ShutdownCommand.Length > 0) Then _action = ShutdownAction.User

        Try
            Select Case _action
                Case ShutdownAction.Abort
                    dwResult = AbortSystemShutdown(sMachine)

                Case ShutdownAction.Shutdown
                    If (dwForce) Then
                        If (dwReboot) Then
                            dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.ForcedReboot)
                        Else
                            dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.ForcedShutdown)
                        End If
                    Else
                        If (dwReboot) Then
                            dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.Reboot)
                        Else
                            dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.Shutdown)
                        End If
                    End If
                    'dwResult = InitiateSystemShutdown(sMachine, sAlertMessage, dwDelay, dwForce, dwReboot)

                Case ShutdownAction.User
                    Shell(machine.ShutdownCommand, AppWinStyle.Hide, False)

                Case ShutdownAction.Sleep
                    dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.Sleep)

                Case ShutdownAction.Hibernate
                    dwResult = AquilaWolLibrary.Shutdown(sMachine, AquilaWolLibrary.ShutdownFlags.Hibernate)

            End Select

        Catch ex As Exception
            _errMessage = ex.Message
            e.Result = 0
            Return

        End Try

        If dwResult = 0 Then
            _errMessage = FormatMessage(Err.LastDllError)
        End If
        e.Result = dwResult

    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles _backgroundWorker.RunWorkerCompleted

        With _item.SubItems(1)
            If e.Result = 0 Then
                .ForeColor = Color.Red
                .Text = String.Format(My.Resources.Strings.ErrorMsg, _errMessage)
                .Tag = .Text ' error
            Else
                .ForeColor = Color.Green
                .Text = My.Resources.Strings.Successful
                .Tag = "" ' success
            End If
        End With

        With _progressbar
            .Increment(1)
            If (ShutdownMode = True) And (.Value = .Maximum) Then
                Shutdown.Complete()
            End If
        End With

    End Sub

End Class
