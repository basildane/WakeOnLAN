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

Imports System.Net.Sockets
Imports System.Net
Imports System.Management
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Net.NetworkInformation

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
        LegacyShutdown = 102
        LegacyForcedShutdown = 103
        LegacyReboot = 104
        LegacyForcedReboot = 105
    End Enum

    Public Enum EventId As Integer
        WakeUp = 1
        Shutdown = 2
        Up = 100
        Down = 101
        [Error] = 1000
    End Enum

    ''' <summary>
    ''' Send a WOL packet to a remote computer
    ''' </summary>
    ''' <param name="mac">The MAC address to wake up</param>
    ''' <param name="network">The network broadcast address</param>
    ''' <param name="udpPort">WOL UDP Port</param>
    ''' <param name="ttl">WOL Time To Live</param>
    ''' <remarks></remarks>
    Public Shared Sub WakeUp(mac As String, Optional network As String = "255.255.255.255", Optional udpPort As Integer = 9, Optional ttl As Integer = 128)
        Dim client As UdpClient
        Dim localEndPoint As IPEndPoint
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

        Dim packet(17 * 6 - 1) As Byte
        Dim i, j As Integer
        Dim macBytes As Byte()

        Try
            macBytes = GetMac(mac)
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

            For Each adapter As NetworkInterface In nics
                ' Only display informatin for interfaces that support IPv4. 
                If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                    Continue For
                End If

                Dim addresses As UnicastIPAddressInformationCollection = adapter.GetIPProperties.UnicastAddresses

                For Each address As UnicastIPAddressInformation In addresses
                    If address.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                        localEndPoint = New IPEndPoint(IPAddress.Parse(address.Address.ToString()), udpPort)
                        Debug.WriteLine("Interface: " & localEndPoint.ToString())

                        Try
                            client = New UdpClient()
                            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
                            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
                            client.ExclusiveAddressUse = False
                            client.Client.Bind(localEndPoint)
                            client.Connect(network, udpPort)
                            client.EnableBroadcast = True
                            client.Ttl = ttl

                            client.Send(packet, packet.Length)

                        Catch

                        End Try

                    End If
                Next
            Next adapter

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
    ''' <param name="message">Optional Shutdown message.</param>
    ''' <remarks></remarks>
    Public Shared Sub Shutdown(host As String,
                                    flags As ShutdownFlags,
                                    Optional userid As String = "",
                                    Optional password As String = "",
                                    Optional domain As String = "",
                                    Optional message As String = "")

        Select Case flags
            Case ShutdownFlags.LegacyShutdown, ShutdownFlags.LegacyForcedShutdown, ShutdownFlags.LegacyReboot, ShutdownFlags.LegacyForcedReboot
                ShutdownLegacy(host, flags, userid, password, message)

            Case Else
                shutdownWMI(host, flags, userid, password, domain, message)

        End Select

    End Sub

    Private Shared Sub shutdownWMI(host As String,
                                    flags As ShutdownFlags,
                                    Optional userid As String = "",
                                    Optional password As String = "",
                                    Optional domain As String = "",
                                    Optional message As String = "")

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
            Throw New WOLException(ex.Message, ex)

        End Try

        If retval <> 0 Then
            Throw New WOLException(FormatMessage(retval))
        End If

    End Sub

    Private Shared Sub ShutdownLegacy(host As String,
                                    flags As ShutdownFlags,
                                    Optional userid As String = "",
                                    Optional password As String = "",
                                    Optional message As String = "")

        Dim dwDelay As Long
        Dim shutdownCommand As New StringBuilder("/c ")
        Dim p As New Process
        Dim [error] As String = String.Empty

        Try
            dwDelay = 30

            If (String.IsNullOrEmpty(host)) Then Return

            If (Not String.IsNullOrEmpty(userid)) Then
				shutdownCommand.AppendFormat("net use \\{0}\IPC$ ""{1}"" /User:{2} & ", host, password, userid)
			End If

            shutdownCommand.AppendFormat("shutdown /m \\{0} /t {1}", host, dwDelay)

            Select Case flags
                Case ShutdownFlags.LegacyShutdown
                    shutdownCommand.Append(" /s")

                Case ShutdownFlags.LegacyForcedShutdown
                    shutdownCommand.Append(" /s /f")

                Case ShutdownFlags.LegacyReboot
                    shutdownCommand.Append(" /r")

                Case ShutdownFlags.LegacyForcedReboot
                    shutdownCommand.Append(" /r /f")

            End Select

            If Not String.IsNullOrEmpty(message) Then
                shutdownCommand.AppendFormat(" /c ""{0}""", message)
            End If

            Dim pi As ProcessStartInfo = New ProcessStartInfo() With {
                .Arguments = shutdownCommand.ToString(),
                .FileName = "cmd.exe",
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .RedirectStandardError = True,
                .RedirectStandardOutput = False
            }
            p.StartInfo = pi
            p.Start()

            ' Display process statistics until
            ' the user closes the program.
            Do
                If Not p.HasExited Then

                    ' Refresh the current process property values.
                    p.Refresh()

                    Debug.WriteLine("")

					' Display current process statistics.

					Debug.WriteLine("  Process: " & p.StartInfo.FileName)
                    Debug.WriteLine("Arguments: " & p.StartInfo.Arguments.ToString())
                    Debug.WriteLine("-------------------------------------")

                    If p.Responding Then
                        Debug.WriteLine("Status = Running")
                    Else
                        Debug.WriteLine("Status = Not Responding")
                    End If
                End If

                [error] &= p.StandardError.ReadToEnd()
                Debug.WriteLine("error: " & [error].ToString())

            Loop While Not p.WaitForExit(1000)

            Debug.WriteLine("")
            Debug.WriteLine("Process exit code: {0}", p.ExitCode)

            If (p.ExitCode <> 0) Then
                Throw New Exception([error])
            End If

        Finally
            If Not p Is Nothing Then
                p.Close()
            End If

        End Try

    End Sub

    ''' <summary>
    ''' Write the EventLog record for this event.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="entryType"></param>
    ''' <param name="eventId"></param>
    ''' <remarks>If no event source has been created for WOL, just skip it.</remarks>
    Public Shared Sub WriteLog(message As String, entryType As EventLogEntryType, eventId As EventId)
        Try
            EventLog.WriteEntry(My.Application.Info.ProductName, message, entryType, eventId)

        Catch ex As SystemException

        End Try
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

<Serializable()> Public Class WOLException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Public Sub New(ByVal info As SerializationInfo, context As StreamingContext)
        MyBase.New(info, context)
    End Sub

End Class
