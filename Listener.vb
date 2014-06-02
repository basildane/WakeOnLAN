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

Imports System.Net
Imports System.Net.Sockets

Public Class Listener
    Private ReadOnly _gso As New StateObject
    Private Delegate Sub HitDelegate(ByVal ip As String)
    Private ReadOnly _showHit As New HitDelegate(AddressOf hit)

    Private Sub Listener_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
    End Sub

    Private Sub Listener_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ReceiveMessages()
    End Sub

    Private Sub Listener_FormClosing(sender As System.Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _gso.Socket.Close()
    End Sub

    Private Sub ReceiveMessages()
        Try
            _gso.EndPoint = New IPEndPoint(IPAddress.Any, 9)
            _gso.Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            _gso.Socket.EnableBroadcast = True

            _gso.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
            _gso.Socket.ExclusiveAddressUse = False

            _gso.Socket.Bind(_gso.EndPoint)
            _gso.Socket.BeginReceiveFrom(_gso.Buffer, 0, _gso.Buffer.Length, SocketFlags.None, _gso.EndPoint, New AsyncCallback(AddressOf Async_Send_Receive), _gso)

        Catch ex As Exception
            ' Handle the HelpRequested event for the following message.
            AddHandler HelpRequested, AddressOf Listener_HelpRequested

            MessageBox.Show(ex.Message & "." & vbCrLf & "Click HELP for advice on fixing this.", "ReceiveMessages", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 0, True)

            ' Remove the HelpRequested event handler to keep the event
            ' from being handled for other message boxes.
            RemoveHandler HelpRequested, AddressOf Listener_HelpRequested

        End Try
    End Sub

    Private Sub Async_Send_Receive(ByVal ar As IAsyncResult)
        Dim so As StateObject
        Dim i As Integer

        Try
            so = ar.AsyncState
            i = so.Socket.EndReceiveFrom(ar, so.EndPoint)
            Debug.WriteLine(Parse(so.Buffer, i))
            hit(Parse(so.Buffer, i))

            'Setup to receive the next packet
            so.Socket.BeginReceiveFrom(so.Buffer, 0, so.Buffer.Length, SocketFlags.None, so.EndPoint, New AsyncCallback(AddressOf Async_Send_Receive), so)

        Catch eod As ObjectDisposedException
            Debug.WriteLine("Socket closed")

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Async_Send_Receive")

        End Try
    End Sub

    Private Sub Hit(mac As String)
        Try
            If (ListView1.InvokeRequired) Then
                ListView1.Invoke(_showHit, MAC)
            Else
                Dim li As New ListViewItem
                Dim n As String = ""

                li.Text = MAC
#If DISPLAY Then
                li.Text = li.Text.Substring(0, 9) & "00:00:00"
#End If

                li.ImageIndex = 0
                li.SubItems.Add(Now.ToShortTimeString)
                For Each m As Machine In Machines
                    If (compareMAC(m.MAC, MAC) = 0) Then
                        n = m.Name
                    End If
                Next
                li.SubItems.Add(n)

                ' always insert it at the top
                ListView1.Items.Insert(0, li)

                ' the next 2 lines are to work around a bug
                ' in the listview sorting
                ListView1.Alignment = ListViewAlignment.Default
                ListView1.Alignment = ListViewAlignment.Top

                If My.Settings.Sound Then
                    My.Computer.Audio.Play(My.Resources.blip, AudioPlayMode.Background)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "hit")

        End Try
    End Sub

    Private Function compareMAC(mac1 As String, mac2 As String) As Int32

        Try
            Dim _mac1 As String = Replace(mac1, ":", "")
            _mac1 = Replace(_mac1, "-", "")

            Dim _mac2 As String = Replace(mac2, ":", "")
            _mac2 = Replace(_mac2, "-", "")

            Return StrComp(_mac1, _mac2, CompareMethod.Text)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "compareMAC")

        End Try

    End Function

    Private Function Parse(ByVal b As Byte(), l As Integer) As String
        Dim i As Int16
        Dim s As String = ""

        Try
            If l < 102 Then Return String.Empty

            For i = 0 To 5
                If b(i) <> 255 Then Return String.Empty
            Next

            For i = 1 To 15
                For j As Int16 = 0 To 5
                    If b(6 + j) <> b(6 + j + (i * 6)) Then
                        Return String.Empty
                    End If
                Next
            Next

            For i = 0 To 5
                If b(6 + i) < 16 Then
                    s &= "0"
                End If

                s &= Hex(b(6 + i))
                If i < 5 Then s &= ":"
            Next

            Return s

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Parse")
            Return String.Empty

        End Try
    End Function

    Private Sub Button_clear_Click(sender As System.Object, e As EventArgs) Handles Button_clear.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub Listener_HelpRequested(sender As Object, hlpevent As HelpEventArgs)
        ShowHelp(Me, "troubleshooting\listener.html")
    End Sub

End Class

Friend Class StateObject
    Public Buffer(127) As Byte
    Public Socket As Socket
    Public EndPoint As EndPoint
End Class