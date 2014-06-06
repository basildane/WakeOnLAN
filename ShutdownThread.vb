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
        _Message = message
        _delay = delay
        _force = force
        _reboot = Reboot
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
        Dim m As Machine

        dwResult = 0
        sAlertMessage = _Message & vbNullChar
        dwDelay = _delay
        dwForce = CLng(_force)
        dwReboot = CLng(_reboot)

        m = Machines(_item.Text)
        sMachine = "\\" & m.Netbios

        _item.SubItems(1).ForeColor = Color.FromKnownColor(KnownColor.WindowText)

        If (_action <> ShutdownAction.Abort And m.ShutdownCommand.Length > 0) Then _action = ShutdownAction.User

        Try
            Select Case _action
                Case ShutdownAction.Abort
                    dwResult = AbortSystemShutdown(sMachine)

                Case ShutdownAction.Shutdown
                    dwResult = InitiateSystemShutdown(sMachine, sAlertMessage, dwDelay, dwForce, dwReboot)

                Case ShutdownAction.User
                    Shell(m.ShutdownCommand, AppWinStyle.Hide, False)

                Case ShutdownAction.Sleep, ShutdownAction.Hibernate
                    dwResult = WMIpower(sMachine)

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

    Private Function WMIpower(sMachine As String) As Integer
        Dim process As ManagementClass
        Dim path As ManagementPath
        Dim inparams, outparams As ManagementBaseObject
        Dim ProcID, retval As String

        process = New ManagementClass("Win32_Process")
        path = New ManagementPath(String.Format("{0}\root\cimv2", sMachine))

#If False Then
        Dim options As ConnectionOptions = New ConnectionOptions()
        options.Username = ""
        options.Password = ""
        process.Scope = New ManagementScope(path, options)
#Else
        process.Scope = New ManagementScope(path)
#End If
        process.Scope.Connect()

        inparams = process.GetMethodParameters("Create")
        Select Case _action
            Case ShutdownAction.Sleep
                inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Standby"

            Case ShutdownAction.Hibernate
                inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Hibernate"

        End Select

        outparams = process.InvokeMethod("Create", inparams, Nothing)
        ProcID = outparams("ProcessID").ToString()
        retval = outparams("ReturnValue").ToString()

        Return IIf(retval, 0, 1)
    End Function

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
