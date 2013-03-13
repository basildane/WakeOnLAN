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

Imports System.Threading
Imports System.ComponentModel

Public Class ShutdownThread
    Private WithEvents BackgroundWorker1 As New BackgroundWorker
    Private _item As ListViewItem
    Private _progressbar As ProgressBar
    Private _Shutdown As Boolean
    Private _Message As String
    Private _delay As Integer
    Private _force As Boolean
    Private _reboot As Boolean
    Private errMessage As String

    Public Sub New(ByVal item As ListViewItem, ByVal progressbar As ProgressBar, ByVal Shutdown As Boolean, ByVal Message As String, ByVal Delay As Integer, ByVal Force As Boolean, ByVal Reboot As Boolean)
        _item = item
        _progressbar = progressbar
        _Shutdown = Shutdown
        _Message = Message
        _delay = Delay
        _force = Force
        _reboot = Reboot
        errMessage = ""
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim dwResult As Integer
        Dim dwReason As Long
        Dim sMachine As String
        Dim sAlertMessage As String
        Dim dwDelay As Long
        Dim dwForce As Long
        Dim dwReboot As Long
        Dim m As Machine

        dwReason = 0L
        sAlertMessage = _Message & vbNullChar
        dwDelay = _delay
        dwForce = CLng(_force)
        dwReboot = CLng(_reboot)

        m = Machines(_item.Text)
        sMachine = "\\" & m.Netbios

        _item.SubItems(1).ForeColor = Color.FromKnownColor(KnownColor.WindowText)

        If m.ShutdownCommand.Length Then
            Shell(m.ShutdownCommand, AppWinStyle.Hide, False)
        Else
            If _Shutdown Then
                dwResult = InitiateSystemShutdown(sMachine, sAlertMessage, dwDelay, dwForce, dwReboot)
            Else
                dwResult = AbortSystemShutdown(sMachine)
            End If
        End If

        If dwResult = 0 Then
            errMessage = FormatMessage(Err.LastDllError)
        End If
        e.Result = dwResult

    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        With _item.SubItems(1)
            If e.Result = 0 Then
                .ForeColor = Color.Red
                .Text = String.Format(My.Resources.Strings.ErrorMsg, errMessage)
            Else
                .ForeColor = Color.Green
                .Text = My.Resources.Strings.Successful
            End If
        End With

        With _progressbar
            .Increment(1)
            If ShutdownMode Then
                If .Value = .Maximum Then
                    Shutdown.Complete()
                End If
            End If
        End With

    End Sub

End Class
