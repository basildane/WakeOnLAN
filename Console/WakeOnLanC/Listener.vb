'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2018 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
    ReadOnly _udpClient As New UdpClient(9)
    Dim _endPoint As New IPEndPoint(IPAddress.Any, 0)

    Public Sub BeginReceive()

        Try
            Dim receiveBytes As [Byte]() = _udpClient.Receive(_endPoint)
            Parse(receiveBytes)

        Catch e As Exception
            Console.WriteLine(e.ToString())

        End Try

    End Sub

    Private Sub Parse(ByVal b As Byte())
        Dim i As Int16
        Dim s As String

        If b.Length < 102 Then Exit Sub

        For i = 0 To 5
            If b(i) <> 255 Then Exit Sub
        Next

        For i = 1 To 15
            For j As Int16 = 0 To 5
                If b(6 + j) <> b(6 + j + (i * 6)) Then
                    Exit Sub
                End If
            Next
        Next

        s = Now & " WakeUp: "
        For i = 0 To 5
            If b(6 + i) < 16 Then
                s &= "0"
            End If

            s &= Hex(b(6 + i))
            If i < 5 Then s &= ":"
        Next

        Console.WriteLine(s)
        Console.Beep()
    End Sub

End Class
