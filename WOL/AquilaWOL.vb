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
Imports System.Management

Public Class AquilaWolLibrary
    Private Declare Function FormatMessageA Lib "kernel32" (ByVal flags As Integer, ByRef source As Object, ByVal messageID As Integer, ByVal languageID As Integer, ByVal buffer As String, ByVal size As Integer, ByRef arguments As Integer) As Integer

    Public Enum ShutdownFlags
        Logoff = 0
        ForcedLogoff = 4
        Shutdown = 1
        ForcedShutdown = 5
        Reboot = 2
        ForcedReboot = 6
        PowerOff = 8
        ForcedPoweroff = 12
        Sleep = 100
        Hibernate = 101
    End Enum

    ''' <summary>
    ''' Send a WOL packet to a remote computer
    ''' </summary>
    ''' <param name="mac">The MAC address to wake up</param>
    ''' <param name="network">The network broadcast address</param>
    ''' <param name="udpPort">WOL UDP Port</param>
    ''' <param name="ttl">WOL Time To Live</param>
    ''' <remarks></remarks>
    Public Shared Sub WakeUp(mac As String, Optional network As String = "255.255.255.255", Optional udpPort As Integer = 9, Optional ttl As Integer = 128, Optional adapter As String = "")
        Dim client As UdpClient
        Dim localEndPoint As IPEndPoint

        Dim packet(17 * 6 - 1) As Byte
        Dim i, j As Integer
        Dim macBytes As Byte()

        Try
            macBytes = GetMac(mac)

            If (String.IsNullOrEmpty(adapter)) Then
                localEndPoint = New IPEndPoint(IPAddress.Any, udpPort)
            Else
                localEndPoint = New IPEndPoint(IPAddress.Parse(adapter), udpPort)
            End If

            client = New UdpClient()
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
            client.ExclusiveAddressUse = False
            client.Client.Bind(localEndPoint)
            client.Connect(network, udpPort)
            client.EnableBroadcast = True
            client.Ttl = ttl

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
            Throw

        End Try

    End Sub

    ''' <summary>
    ''' Shutdown a Windows host.
    ''' </summary>
    ''' <param name="host">The name or IP of the computer to shutdown.</param>
    ''' <param name="flags">One of the ShutdownFlags, such as Reboot, Sleep, etc.</param>
    ''' <param name="userid">Optional userid credentials.</param>
    ''' <param name="password">Optional password.</param>
    ''' <param name="domain">Optional Domain name.</param>
    ''' <remarks></remarks>
    Public Shared Sub Shutdown(host As String,
                                    flags As ShutdownFlags,
                                    Optional userid As String = "",
                                    Optional password As String = "",
                                    Optional domain As String = "")

        Dim process As ManagementClass
        Dim scope As ManagementScope
        Dim options As ConnectionOptions = New ConnectionOptions()
        Dim query As SelectQuery
        Dim searcher As ManagementObjectSearcher
        Dim inparams, outparams As ManagementBaseObject
        Dim retval As UInteger
        Const wmiPath As String = "\\{0}\root\cimv2"

        Try
            process = New ManagementClass("Win32_Process")

            If (String.IsNullOrEmpty(userid)) Then
                scope = New ManagementScope(String.Format(wmiPath, host))
            Else
                options.Username = userid
                options.Password = password
                options.Authority = "ntlmdomain:" & domain
                scope = New ManagementScope(String.Format(wmiPath, host), options)
            End If
            process.Scope = scope
            process.Scope.Connect()
            LocalShutdown.EnableToken("SeShutdownPrivilege")

            If (flags = ShutdownFlags.Sleep Or flags = ShutdownFlags.Hibernate) Then
                inparams = process.GetMethodParameters("Create")
                Select Case flags
                    Case ShutdownFlags.Sleep
                        inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Standby"

                    Case ShutdownFlags.Hibernate
                        inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Hibernate"

                End Select

                outparams = process.InvokeMethod("Create", inparams, Nothing)
                retval = outparams("ReturnValue")
            Else
                query = New SelectQuery("SELECT * FROM Win32_OperatingSystem WHERE Primary=true")
                searcher = New ManagementObjectSearcher(scope, query)

                For Each managementObject As ManagementObject In searcher.Get()
                    Debug.WriteLine(managementObject("Caption"))

                    inparams = managementObject.GetMethodParameters("Win32Shutdown")
                    inparams("Flags") = flags
                    outparams = managementObject.InvokeMethod("Win32Shutdown", inparams, Nothing)

                    retval = outparams("ReturnValue")
                Next
            End If

        Catch ex As Exception
            Throw

        End Try

        If retval <> 0 Then
            Throw New Exception(FormatMessage(retval))
        End If

    End Sub

    Friend Shared Function FormatMessage(ByVal [error] As Integer) As String
        Const FORMAT_MESSAGE_FROM_SYSTEM As UInteger = &H1000
        Const LANG_NEUTRAL As Integer = &H0
        Const bufferLen As Integer = 1024
        Dim buffer As String = Space(bufferLen)

        FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, [error], LANG_NEUTRAL, buffer, bufferLen, IntPtr.Zero)
        buffer = Replace(Replace(buffer, Chr(13), ""), Chr(10), "")
        If buffer.Contains(Chr(0)) Then
            buffer = buffer.Substring(0, buffer.IndexOf(Chr(0)))
        Else
            buffer = String.Empty
        End If
        Return buffer
    End Function

    Private Shared Function GetMac(ByVal mac As String) As Byte()
        Dim i As Integer
        Dim m(5) As Byte
        Dim s As String

        s = Replace(mac, " ", "")
        s = Replace(s, ":", "")
        s = Replace(s, "-", "")

        For i = 0 To 5
            m(i) = "&H" & Mid(s, (i * 2) + 1, 2)
        Next
        Return m
    End Function

End Class
