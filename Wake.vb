'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2016 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
Imports System.Collections.Generic
Imports Machines

Module Wake
    Dim repeatTimer As Timer = New Timer()
    Dim keepAliveTimer As Timer = New Timer()
    Dim repeatMachine As New List(Of repeatingMachine)
    Dim thisLock As New Object

    Public Sub WakeUp(ByVal machine As Machine)
        Dim host As String
        Dim newMachine As repeatingMachine

        Try
            If (String.IsNullOrEmpty(machine.MAC)) Then
                MessageBox.Show(String.Format("Host {0} does not have a valid MAC address.  Cannot send wake-up message until you add a MAC address.", machine.Name), "WakeUp Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            SyncLock thisLock
                If (machine.Method = 0) Then
                    host = machine.Broadcast
                Else
                    host = machine.Netbios
                End If

                If (machine.KeepAlive) Then

                    newMachine = New repeatingMachine(machine)
                    If Not repeatMachine.Contains(newMachine) Then
                        newMachine.remainingCount = -1
                        repeatMachine.Add(newMachine)
                    End If
                    If keepAliveTimer.Enabled = False Then
                        keepAliveTimer.Interval = My.Settings.keepAliveInterval
                        keepAliveTimer.Enabled = True
                        AddHandler keepAliveTimer.Tick, AddressOf KeepAliveTimerEvent
                    End If

                ElseIf (machine.RepeatCount > 1) Then

                    newMachine = New repeatingMachine(machine)
                    newMachine.remainingCount = machine.RepeatCount - 1
                    repeatMachine.Add(newMachine)

                    If repeatTimer.Enabled = False Then
                        repeatTimer.Interval = My.Settings.repeatInterval
                        repeatTimer.Enabled = True
                        AddHandler repeatTimer.Tick, AddressOf RepeatTimerEvent
                    End If

                End If

                WOL.AquilaWolLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL)

            End SyncLock

            WOL.AquilaWolLibrary.WriteLog(String.Format("WakeUp sent to ""{0}""", machine.Name), EventLogEntryType.Information, WOL.AquilaWolLibrary.EventId.WakeUp)

        Catch ex As Exception
            WOL.AquilaWolLibrary.WriteLog(String.Format("WakeUp error: {0}", ex.Message), EventLogEntryType.Error, WOL.AquilaWolLibrary.EventId.Error)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub RepeatTimerEvent(ByVal sender As Object, ByVal e As EventArgs)
        SyncLock thisLock
            For i As Integer = repeatMachine.Count - 1 To 0 Step -1
                Dim machine As repeatingMachine = repeatMachine(i)
                If (machine.Method = 0) Then
                    host = machine.Broadcast
                Else
                    host = machine.Netbios
                End If

                Select Case machine.remainingCount
                    Case > 0
                        machine.remainingCount -= 1
                        WOL.AquilaWolLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL)

                    Case 0
                        Debug.WriteLine("remove: " & machine.Name)
                        repeatMachine.RemoveAt(i)

                End Select

            Next
        End SyncLock
    End Sub

    Private Sub KeepAliveTimerEvent(ByVal sender As Object, ByVal e As EventArgs)
        SyncLock thisLock
            For Each machine As repeatingMachine In repeatMachine
                If (machine.Method = 0) Then
                    host = machine.Broadcast
                Else
                    host = machine.Netbios
                End If

                WOL.AquilaWolLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL)
            Next
        End SyncLock
    End Sub

    Class repeatingMachine
        Inherits Machine

        Public Property remainingCount As Integer

        Public Sub New(machine As Machine)
            Name = machine.Name
            MAC = machine.MAC
            IP = machine.IP
            Broadcast = machine.Broadcast
            Netbios = machine.Netbios
            Method = machine.Method
            Emergency = machine.Emergency
            ShutdownCommand = machine.ShutdownCommand
            Group = machine.Group
            UDPPort = machine.UDPPort
            TTL = machine.TTL
            RDPPort = machine.RDPPort
            RDPFile = machine.RDPFile
            Note = machine.Note
            UserID = machine.UserID
            Password = machine.Password
            Domain = machine.Domain
            ShutdownMethod = machine.ShutdownMethod
            KeepAlive = machine.KeepAlive
            RepeatCount = machine.RepeatCount
        End Sub

    End Class

End Module
