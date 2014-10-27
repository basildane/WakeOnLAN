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
Imports System.Linq

Public Class Shutdown

    Private _countdownTime As Integer = My.Settings.emerg_delay
    Private _preCountdown As Integer

    Private Sub Clear()
        ShutdownMode = True
        CurrentItem = Nothing
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 0
        Cursor = Cursors.Default
        ListView1.Items.Clear()
    End Sub

    Public Sub PerformShutdown(ByVal Parent As Form, ByVal Items() As String)
        Dim machine As Machine
        Dim newItem As ListViewItem

        Clear()

        shut_message.Text = My.Settings.DefaultMessage
        shut_timeout.Text = My.Settings.DefaultTimeout
        shut_force.Checked = My.Settings.Force
        shut_reboot.Checked = My.Settings.Reboot

        Select Case My.Settings.shutdownAction
            Case ShutdownThread.ShutdownAction.Sleep
                rbSleep.Checked = True

            Case ShutdownThread.ShutdownAction.Hibernate
                rbHibernate.Checked = True

            Case ShutdownThread.ShutdownAction.Logoff
                rbLogoff.Checked = True

            Case Else
                rbShutdown.Checked = True

        End Select

        For Each item As String In Items
            machine = Machines(item)
            newItem = ListView1.Items.Add(machine.Name)
            newItem.UseItemStyleForSubItems = False

            If IsLocal(machine.Netbios) Then
                newItem.SubItems.Add(My.Resources.Strings.Pausing)
                CurrentItem = newItem
            Else
                newItem.SubItems.Add(My.Resources.Strings.lit_Ready)
                ProgressBar1.Maximum += 1
            End If
        Next

        ShowDialog(Parent)

    End Sub

    Private Function IsLocal(host As String) As Boolean
        If String.Compare(host, My.Computer.Name, True) = 0 Then
            Return True
        ElseIf String.Compare(host, My.Computer.Name & "." & Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties.DomainName, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub PerformEmergencyShutdown(ByVal Parent As Form)
        Dim newItem As ListViewItem

        Clear()

        shut_message.Text = My.Settings.emerg_message
        shut_timeout.Text = 30
        shut_force.Checked = True
        shut_reboot.Checked = False

        Select Case My.Settings.shutdownAction
            Case ShutdownThread.ShutdownAction.Sleep
                rbSleep.Checked = True

            Case ShutdownThread.ShutdownAction.Hibernate
                rbHibernate.Checked = True

            Case ShutdownThread.ShutdownAction.Logoff
                rbLogoff.Checked = True

            Case Else
                rbShutdown.Checked = True

        End Select

        For Each machine As Machine In Machines
            newItem = ListView1.Items.Add(machine.Name)
            newItem.UseItemStyleForSubItems = False

            If IsLocal(machine.Netbios) Then
                newItem.SubItems.Add(My.Resources.Strings.Pausing)
                CurrentItem = newItem
            Else
                If machine.Emergency Then
                    newItem.SubItems.Add(My.Resources.Strings.ShuttingDown)
                    ProgressBar1.Maximum += 1
                Else
                    newItem.SubItems.Add(My.Resources.Strings.Skipping)
                End If
            End If

        Next

        ShowDialog(Parent)

    End Sub

    Private Sub AbortButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles AbortButton.Click
        Label_Operation.Text = My.Resources.Strings.AbortShutdown
        ShutdownMode = False
        pre_timer.Stop()
        timer.Stop()
        For Each item As ListViewItem In From item1 As ListViewItem In ListView1.Items
            item.SubItems(1).Text = My.Resources.Strings.lit_Ready
            PopupMessage(item.Text, String.Format(My.Resources.Strings.AbortingShutdown, item.Text))
        Next

        Cursor = Cursors.Default
    End Sub

    Public Sub Complete()
        If ListView1.Items.Cast(Of ListViewItem)().Any(Function(item) (Not String.IsNullOrEmpty(item.SubItems(1).Tag))) Then
            Cursor = Cursors.Default
            Label_Operation.Text = My.Resources.Strings.lit_Error
            Return
        End If

        If CurrentItem Is Nothing Then Close()
        If ShutdownMode Then timer.Start()
    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer.Tick
        If Not ShutdownMode Then
            timer.Stop()
            Exit Sub
        End If

        Try
            _countdownTime -= 1
            CurrentItem.SubItems(1).Text = String.Format(My.Resources.Strings.ShutDownSeconds, _countdownTime)
            If _countdownTime <= 0 Then
                timer.Stop()

                Dim action As ShutdownThread.ShutdownAction

                Cursor = Cursors.WaitCursor

                If (rbShutdown.Checked) Then action = ShutdownThread.ShutdownAction.Shutdown
                If (rbSleep.Checked) Then action = ShutdownThread.ShutdownAction.Sleep
                If (rbHibernate.Checked) Then action = ShutdownThread.ShutdownAction.Hibernate
                If (rbLogoff.Checked) Then action = ShutdownThread.ShutdownAction.Logoff

                My.Settings.DefaultMessage = shut_message.Text
                My.Settings.DefaultTimeout = shut_timeout.Text
                My.Settings.Force = shut_force.Checked
                My.Settings.Reboot = shut_reboot.Checked
                My.Settings.shutdownAction = action

                'TODO: test here
                Label_Operation.Text = My.Resources.Strings.BeginShutdown
                For Each item As ListViewItem In From item1 As ListViewItem In ListView1.Items
                                                 Where (item1.SubItems(1).Text = My.Resources.Strings.Pausing)
                    Dim shutdownThread As New ShutdownThread(item, ProgressBar1, action, shut_message.Text, shut_timeout.Text, shut_force.Checked, shut_reboot.Checked)
                Next

            End If

        Catch ex As Exception
            timer.Stop()

        End Try

    End Sub

    Private Sub Shutdown_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        With ListView1
            .Columns(1).Width = .ClientSize.Width - .Columns(0).Width
        End With
    End Sub

    Private Sub ShutdownButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ShutdownButton.Click
        Dim action As ShutdownThread.ShutdownAction

        If (rbShutdown.Checked) Then action = ShutdownThread.ShutdownAction.Shutdown
        If (rbSleep.Checked) Then action = ShutdownThread.ShutdownAction.Sleep
        If (rbHibernate.Checked) Then action = ShutdownThread.ShutdownAction.Hibernate
        If (rbLogoff.Checked) Then action = ShutdownThread.ShutdownAction.Logoff

        My.Settings.DefaultMessage = shut_message.Text
        My.Settings.DefaultTimeout = shut_timeout.Text
        My.Settings.Force = shut_force.Checked
        My.Settings.Reboot = shut_reboot.Checked
        My.Settings.shutdownAction = action
        Label_Operation.Text = My.Resources.Strings.BeginShutdown

        For Each item As ListViewItem In From item1 As ListViewItem In ListView1.Items Where (item1.SubItems(1).Text <> My.Resources.Strings.Pausing)
            item.SubItems(1).Text = My.Resources.Strings.lit_Ready
            If (Not String.IsNullOrEmpty(shut_message.Text)) Then
                PopupMessage(item.Text, shut_message.Text)
            End If
        Next

        _preCountdown = shut_timeout.Text
        pre_timer.Start()

    End Sub

    Private Sub PopupMessage(host As String, message As String)
        Try
            If (Not String.IsNullOrEmpty(message)) Then
                Shell(String.Format("msg * /server:{0} ""{1}""", host, message), AppWinStyle.Hide, False)
            End If

        Catch

        End Try
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        Close()
    End Sub

    Private Sub Shutdown_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub pre_timer_Tick(sender As Object, e As EventArgs) Handles pre_timer.Tick
        _preCountdown -= 1
        If (_preCountdown >= 0) Then Label_Operation.Text = String.Format("{0} {1}", My.Resources.Strings.BeginShutdown, _preCountdown)

        If _preCountdown <= 0 Then
            pre_timer.Stop()

            For Each item As ListViewItem In From item1 As ListViewItem In ListView1.Items Where (item1.SubItems(1).Text = My.Resources.Strings.lit_Ready)
                Dim shutdownThread As New ShutdownThread(item, ProgressBar1, My.Settings.shutdownAction, shut_message.Text, shut_timeout.Text, shut_force.Checked, shut_reboot.Checked)
            Next

            If (ListView1.Items.Count = 1) And (Not CurrentItem Is Nothing) Then
                _countdownTime = 0
                Complete()
            End If
        End If
    End Sub

End Class

