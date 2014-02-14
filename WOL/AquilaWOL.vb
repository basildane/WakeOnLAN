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

Imports System.Net.Sockets
Imports System.Net

Public Class AquilaWOLLibrary
    ''' <summary>
    ''' Send a WOL packet to a remote computer
    ''' </summary>
    ''' <param name="MAC">The MAC address to wake up</param>
    ''' <param name="Network">The network broadcast address</param>
    ''' <param name="UDPPort">WOL UDP Port</param>
    ''' <param name="TTL">WOL Time To Live</param>
    ''' <remarks></remarks>
    Public Shared Sub WakeUp(MAC As String, Optional Network As String = "255.255.255.255", Optional UDPPort As Integer = 9, Optional TTL As Integer = 128, Optional Adapter As String = "")
        Dim client As UdpClient
        Dim localEndPoint As IPEndPoint

        Dim packet(17 * 6 - 1) As Byte
        Dim i, j As Integer
        Dim macBytes As Byte()

        Try
            macBytes = GetMAC(MAC)

            If (String.IsNullOrEmpty(Adapter)) Then
                localEndPoint = New IPEndPoint(IPAddress.Any, UDPPort)
            Else
                localEndPoint = New IPEndPoint(IPAddress.Parse(Adapter), UDPPort)
            End If

            client = New UdpClient(localEndPoint)
            client.Connect(Network, UDPPort)
            client.EnableBroadcast = True
            client.Ttl = TTL

            ' WOL packet contains a 6-bytes header and 16 times a 6-bytes sequence containing the MAC address.
            ' packet =  byte(17 * 6)
            ' Header of 0xFF 6 times.

            For i = 0 To 5
                packet(i) = &HFF
            Next

            ' Body of magic packet contains the MAC address repeated 16 times.

            For i = 1 To 16
                For j = 0 To 5
                    packet(i * 6 + j) = macBytes(j)
                Next
            Next

            client.Send(packet, packet.Length)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Shared Sub Shutdown(Host As String)


    End Sub

    Private Shared Function GetMAC(ByVal Mac As String) As Byte()
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

End Class
