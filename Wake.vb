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

Imports System.Net.Sockets
Imports System.Net

Module Wake
    Public Sub WakeUp(ByVal machine As Machine)
        Dim client As New UdpClient
        Dim packet(17 * 6 - 1) As Byte
        Dim i, j As Integer
        Dim m As Byte()

        Try
            m = GetMAC(machine.MAC)

            Debug.WriteLine(String.Format("WakeUp: [{0}] [{1}] / [{2}] port: {3} TTL: {4}", machine.Name, machine.MAC, machine.Broadcast, machine.UDPPort, machine.TTL))
            client.Connect(machine.Broadcast, machine.UDPPort)
            client.EnableBroadcast = True
            client.Ttl = machine.TTL

            ' WOL packet contains a 6-bytes header and 16 times a 6-bytes sequence containing the MAC address.
            ' packet =  byte(17 * 6)
            ' Header of 0xFF 6 times.

            For i = 0 To 5
                packet(i) = &HFF
            Next

            ' Body of magic packet contains the MAC address repeated 16 times.

            For i = 1 To 16
                For j = 0 To 5
                    packet(i * 6 + j) = m(j)
                Next
            Next

            client.Send(packet, packet.Length)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function GetMAC(ByVal Mac As String) As Byte()
        Dim i As Integer
        Dim m(5) As Byte
        Dim s As String

        s = Replace(Mac, " ", "")
        s = Replace(s, ":", "")
        s = Replace(s, "-", "")

        For i = 0 To 5
            m(i) = "&H" & Mid(s, (i * 2) + 1, 2)
        Next
        Return m
    End Function

End Module
