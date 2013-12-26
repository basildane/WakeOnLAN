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

Public Class Shutdown

    Private CountdownTime As Integer = My.Settings.emerg_delay

    Private Sub Clear()
        ShutdownMode = True
        meItem = Nothing
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 0
        Cursor = Cursors.Default
        ListView1.Items.Clear()
    End Sub

    Public Sub PerformShutdown(ByVal Parent As Form, ByVal Items As ListView.SelectedListViewItemCollection)
        Dim m As Machine
        Dim newItem As ListViewItem

        Clear()

        shut_message.Text = My.Settings.DefaultMessage
        shut_timeout.Text = My.Settings.DefaultTimeout
        shut_force.Checked = My.Settings.Force
        shut_reboot.Checked = My.Settings.Reboot

        Select Case My.Settings.shutdownAction
            Case ShutdownThread.Action.Sleep
                rbSleep.Checked = True

            Case ShutdownThread.Action.Hibernate
                rbHibernate.Checked = True

            Case Else
                rbShutdown.Checked = True

        End Select

        For Each l As ListViewItem In Items
            m = Machines(l.Name)
            newItem = ListView1.Items.Add(m.Name)
            newItem.UseItemStyleForSubItems = False

            If String.Compare(m.Netbios, My.Computer.Name, True) Then
                newItem.SubItems.Add(My.Resources.Strings.ShuttingDown)
                ProgressBar1.Maximum += 1
            Else
                newItem.SubItems.Add(My.Resources.Strings.Pausing)
                meItem = newItem
            End If

        Next

        Me.ShowDialog(Parent)

    End Sub

    Public Sub PerformEmergencyShutdown(ByVal Parent As Form)
        Dim newItem As ListViewItem

        Clear()

        shut_message.Text = My.Settings.emerg_message
        shut_timeout.Text = 30
        shut_force.Checked = True
        shut_reboot.Checked = False

        Select Case My.Settings.shutdownAction
            Case ShutdownThread.Action.Sleep
                rbSleep.Checked = True

            Case ShutdownThread.Action.Hibernate
                rbHibernate.Checked = True

            Case Else
                rbShutdown.Checked = True

        End Select

        For Each m As Machine In Machines
            newItem = ListView1.Items.Add(m.Name)
            newItem.UseItemStyleForSubItems = False

            If String.Compare(m.Netbios, My.Computer.Name, True) Then
                If m.Emergency Then
                    newItem.SubItems.Add(My.Resources.Strings.ShuttingDown)
                    ProgressBar1.Maximum += 1
                Else
                    newItem.SubItems.Add(My.Resources.Strings.Skipping)
                End If
            Else
                newItem.SubItems.Add(My.Resources.Strings.Pausing)
                meItem = newItem
            End If

        Next

        Me.ShowDialog(Parent)

    End Sub

    Private Sub AbortButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbortButton.Click
        Label_Operation.Text = My.Resources.Strings.AbortShutdown
        ShutdownMode = False

        Timer1.Stop()
        For Each item As ListViewItem In ListView1.Items
            If item.SubItems(1).Text = My.Resources.Strings.ShuttingDown Then
                item.SubItems(1).Text = My.Resources.Strings.Aborting
                Dim st As New ShutdownThread(item, ProgressBar1, ShutdownThread.Action.Abort, shut_message.Text, shut_timeout.Text, shut_force.Checked, shut_reboot.Checked)
            End If
        Next

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub Complete()
        For Each item As ListViewItem In ListView1.Items
            If (Not String.IsNullOrEmpty(item.SubItems(1).Tag)) Then
                Cursor = Cursors.Default
                Label_Operation.Text = My.Resources.Strings.lit_Error
                Return
            End If
        Next

        If meItem Is Nothing Then Me.Close()
        If ShutdownMode Then Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not ShutdownMode Then
            Timer1.Stop()
            Exit Sub
        End If

        Try
            CountdownTime -= 1
            meItem.SubItems(1).Text = String.Format(My.Resources.Strings.ShutDownSeconds, CountdownTime)
            If CountdownTime <= 0 Then
                Timer1.Stop()
                If (rbShutdown.Checked) Then LocalShutdown.ExitWindows(RestartOptions.PowerOff, True)
                If (rbSleep.Checked) Then LocalShutdown.ExitWindows(RestartOptions.Suspend, True)
                If (rbHibernate.Checked) Then LocalShutdown.ExitWindows(RestartOptions.Hibernate, True)
            End If

        Catch ex As Exception
            Timer1.Stop()

        End Try

    End Sub

    Private Sub Shutdown_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        With ListView1
            .Columns(1).Width = .ClientSize.Width - .Columns(0).Width
        End With
    End Sub

    Private Sub ShutdownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownButton.Click
        Dim action As ShutdownThread.Action

        Me.Cursor = Cursors.WaitCursor

        If (rbShutdown.Checked) Then action = ShutdownThread.Action.Shutdown
        If (rbSleep.Checked) Then action = ShutdownThread.Action.Sleep
        If (rbHibernate.Checked) Then action = ShutdownThread.Action.Hibernate

        My.Settings.DefaultMessage = shut_message.Text
        My.Settings.DefaultTimeout = shut_timeout.Text
        My.Settings.Force = shut_force.Checked
        My.Settings.Reboot = shut_reboot.Checked
        My.Settings.shutdownAction = action

        Label_Operation.Text = My.Resources.Strings.BeginShutdown
        For Each item As ListViewItem In ListView1.Items
            If item.SubItems(1).Text = My.Resources.Strings.ShuttingDown Then
                Dim st As New ShutdownThread(item, ProgressBar1, action, shut_message.Text, shut_timeout.Text, shut_force.Checked, shut_reboot.Checked)
            End If
        Next

        If (ListView1.Items.Count = 1) And (Not meItem Is Nothing) Then
            CountdownTime = 0
            Complete()
        End If

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Shutdown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.system_log_out
    End Sub
End Class

