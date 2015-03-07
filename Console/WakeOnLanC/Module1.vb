'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2015 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
Imports System.Linq
Imports System.Threading
Imports WOL
Imports WOL.AquilaWolLibrary

Public Module Module1
    Enum ModeTypes
        None
        Shutdown
        WakeUp
        Abort
        Debug
        Sleep
        Hibernate
    End Enum

    Enum ErrorCodes
        Ok = 0
        InvalidCommand = 1
        NotFound = 2
        PermissionDenied = 5
    End Enum

    Dim _machine As String = String.Empty
    Dim _mac As String = String.Empty
    Dim _all As Boolean = False
    Dim _alertMessage As String = "System is shutting down"
    Dim _delay As Long = 30
    Dim _force As Long = 0
    Dim _reboot As Long = 0
    Dim _group As String = String.Empty
    Dim _mode As ModeTypes = ModeTypes.None
    Dim _result As Integer = ErrorCodes.Ok
    Dim _path As String = ""
    Dim _interface As String = ""

    Function Main() As Integer
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(My.Application.Info.Title & " " & My.Application.Info.Version.ToString)
        Console.ResetColor()

        If My.Application.CommandLineArgs.Count = 0 Then
            DisplayHelp()
            Return ErrorCodes.Ok
        End If

        For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
            Select Case My.Application.CommandLineArgs.Item(i)
                Case "-t"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    _delay = Val(My.Application.CommandLineArgs.Item(i + 1))
                    i += 1

                Case "-f"
                    _force = 1

                Case "-m"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    _machine = My.Application.CommandLineArgs.Item(i)

                Case "-p"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    _path = My.Application.CommandLineArgs.Item(i)

                Case "-mac"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    _mac = My.Application.CommandLineArgs.Item(i)

                Case "-g"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    _group = My.Application.CommandLineArgs.Item(i)

                Case "-if"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    _interface = My.Application.CommandLineArgs.Item(i)

                Case "-all"
                    _all = True

                Case "-r"
                    _mode = ModeTypes.Shutdown
                    _reboot = 1

                Case "-s"
                    _mode = ModeTypes.Shutdown
                    _reboot = 0

                Case "-s1"
                    _mode = ModeTypes.Sleep
                    _reboot = 0

                Case "-s4"
                    _mode = ModeTypes.Hibernate
                    _reboot = 0

                Case "-w"
                    _mode = ModeTypes.WakeUp

                Case "-a"
                    _mode = ModeTypes.Abort

                Case "-c"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    _alertMessage = My.Application.CommandLineArgs.Item(i + 1)
                    i += 1

                Case "-l"
                    Listen()
                    Return ErrorCodes.Ok

                Case "-e"
                    Enumerate()
                    Return ErrorCodes.Ok

                Case "-h"
                    DisplayHelp()
                    Return ErrorCodes.Ok

                Case "-d"
                    _mode = ModeTypes.Debug

                Case Else
                    DisplayHelp()
                    Return ErrorCodes.InvalidCommand

            End Select

        Next

        Select Case _mode

            Case ModeTypes.Shutdown, ModeTypes.Sleep, ModeTypes.Hibernate
                Return Shutdown()

            Case ModeTypes.WakeUp
                Return DoWakeup()

            Case ModeTypes.Abort
                Return Abort()

            Case ModeTypes.Debug
                Return ShowIPConfig()

            Case Else
                BadCommand()
                Return ErrorCodes.InvalidCommand

        End Select

    End Function

    Private Sub DisplayHelp()
        Console.WriteLine()
        Console.WriteLine("Commands are:")
        Console.WriteLine("-s   (shutdown) requires -m, -g or -all")
        Console.WriteLine("-s1  (sleep) requires -m or -all")
        Console.WriteLine("-s4  (hibernate) requires -m or -all")
        Console.WriteLine("-a   (abort a shutdown) requires -m (depreciated)")
        Console.WriteLine("-r   (reboot)")
        Console.WriteLine("-w   (wakeup) requires -m, -g, -mac parameter, or -all")
        Console.WriteLine("-l   (listen for WOL packets)")
        Console.WriteLine("-e   (enumerate machine list)")
        Console.WriteLine("-p   (path to machines.xml (optional))")
        Console.WriteLine("-if  (select Interface (example -if 192.168.0.20) (optional))")
        Console.WriteLine("-d   (debug) requires -m")
        Console.WriteLine("-h   (display this help message)")
        Console.WriteLine()
        Console.WriteLine("options:")
        Console.WriteLine("-t xx      delay (xx = seconds).  For Shutdown and Reboot commands.")
        Console.WriteLine("-f         force files closed.  For Shutdown and Reboot commands.")
        Console.WriteLine("-m xx      xx = machine name.")
        Console.WriteLine("-mac xx    xx = mac address.")
        Console.WriteLine("-g xx      xx = group name.  To wakeup or shutdown a group of machines.")
        Console.WriteLine("-all       all machines.")
        Console.WriteLine("-c ""xx""  xx = popup message.  Optional popup message.")
        Console.WriteLine()
        Console.WriteLine("note.  Use -m with -w to send to a specific subnet.")
    End Sub

    Private Sub BadCommand()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("Invalid command line.")
        Console.ResetColor()
        DisplayHelp()
    End Sub

    Private Function DoWakeup() As Integer
        Dim machine As Machine

        If _all Then
            Try
                Machines.Load(_path)

            Catch ex As Exception
                _result = ErrorCodes.PermissionDenied
                Return _result

            End Try

            For Each machine In Machines
                Console.Write("Wakeup " & machine.Name & "... ")
                If machine.MAC = "" Then
                    _result = ErrorCodes.NotFound
                    Console.WriteLine("Cannot find MAC address for " & machine.Name)
                Else
                    Console.WriteLine("waking up mac: " & machine.MAC)
                    WakeUp(machine, _interface)
                End If
            Next
            Return _result

        ElseIf _machine.Length Then
            Try
                Machines.Load(_path)

            Catch ex As Exception
                _result = ErrorCodes.PermissionDenied
                Return _result

            End Try

            machine = Machines(_machine)
            If machine Is Nothing Then
                Console.WriteLine("Cannot find machine " & _machine)
                Return ErrorCodes.NotFound
            End If
            Console.Write("wakeup sent to ")
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.WriteLine(_machine)
            Console.ResetColor()
            Console.Write("waking up mac: " & machine.MAC & " broadcast: ")
            If (machine.Method = 0) Then
                Console.WriteLine(machine.Broadcast)
            Else
                Console.WriteLine(machine.Netbios)
            End If
            WakeUp(machine, _interface)
            Return ErrorCodes.Ok

        ElseIf _mac.Length Then
            Console.WriteLine("waking up mac: " & _mac)
            WakeUp(_mac, _interface)
            Return ErrorCodes.Ok

        ElseIf _group.Length Then
            Try
                Machines.Load(_path)

            Catch ex As Exception
                _result = ErrorCodes.PermissionDenied
                Return _result

            End Try

            Console.WriteLine("waking up group: " & _group)
            For Each machine In From machine1 As Machine In Machines Where machine1.Group = _group
                Console.WriteLine("  > " & machine.Name)
                WakeUp(machine, _interface)
                Thread.Sleep(500)
            Next
            Console.WriteLine("Done.")
            Return ErrorCodes.Ok

        Else
            Console.WriteLine("Error.  No machine or MAC specified.")
            DisplayHelp()
            Return ErrorCodes.InvalidCommand

        End If

    End Function

    Private Function Abort() As Integer
        Console.WriteLine("Error.  Abort command is depreciated.")
        Return ErrorCodes.InvalidCommand
    End Function

    Private Function Shutdown() As Integer
        'TODO: handle _delay
        Dim machine As Machine
        Dim flags As ShutdownFlags

        Machines.Load(_path)

        If (String.IsNullOrEmpty(_machine) And String.IsNullOrEmpty(_group) And (_all = False)) Then
            Console.WriteLine("Error.  No machine specified.")
            DisplayHelp()
            _result = ErrorCodes.InvalidCommand
            Return _result
        End If

        If _mode = ModeTypes.Shutdown Then
            If _force Then
                If _reboot Then
                    flags = ShutdownFlags.ForcedReboot
                Else
                    flags = ShutdownFlags.ForcedShutdown
                End If
            Else
                If _reboot Then
                    flags = ShutdownFlags.Reboot
                Else
                    flags = ShutdownFlags.Shutdown
                End If
            End If
        ElseIf _mode = ModeTypes.Hibernate Then
            flags = ShutdownFlags.Hibernate
        ElseIf _mode = ModeTypes.Sleep Then
            flags = ShutdownFlags.Sleep
        End If

        If _all Then
            For Each machine In Machines
                Console.WriteLine(String.Format("Command {0} to {1}", flags.ToString(), machine.Name))
                ProcessMachine(machine, flags)
            Next
        ElseIf (_group.Length) Then
            Console.WriteLine(String.Format("Command {0} to group: {1}", flags.ToString(), _group))
            For Each machine In From machine1 As Machine In Machines Where machine1.Group = _group
                Console.Write("  > " & machine.Name)
                ProcessMachine(machine, flags)
            Next
            Console.WriteLine("Done.")
        Else
            machine = Machines(_machine)
            Console.Write(flags.ToString() & " sent to " & machine.Name)
            ProcessMachine(machine, flags)
        End If

        Return _result

    End Function

    Private Sub ProcessMachine(machine As Machine, flags As AquilaWolLibrary.ShutdownFlags)
        Dim encryption As New Encryption(My.Application.Info.ProductName)

        Try
            Select Case machine.ShutdownMethod
                Case MachinesClass.ShutdownMethods.WMI
                    PopupMessage(machine.Netbios, _alertMessage)
                    AquilaWolLibrary.Shutdown(machine.Netbios, flags, machine.UserID, encryption.EnigmaDecrypt(machine.Password), machine.Domain)

                Case MachinesClass.ShutdownMethods.Custom
                    Shell(machine.ShutdownCommand, AppWinStyle.Hide, False)

                Case MachinesClass.ShutdownMethods.Legacy
                    Select Case flags
                        Case ShutdownFlags.Shutdown
                            flags = ShutdownFlags.LegacyShutdown

                        Case ShutdownFlags.ForcedShutdown
                            flags = ShutdownFlags.LegacyForcedShutdown

                        Case ShutdownFlags.Reboot
                            flags = ShutdownFlags.LegacyReboot

                        Case ShutdownFlags.ForcedReboot
                            flags = ShutdownFlags.LegacyForcedReboot

                        Case Else
                            Throw New Exception(String.Format("{0} not supported with Legacy shutdown method.", flags.ToString()))

                    End Select

                    AquilaWolLibrary.Shutdown(machine.Netbios, flags, machine.UserID, encryption.EnigmaDecrypt(machine.Password), machine.Domain, _alertMessage)

            End Select

            Console.WriteLine("...Successful")
            WriteLog(String.Format("Sending {0} to ""{1}""", flags.ToString(), machine.Name), EventLogEntryType.Information, EventId.Shutdown)

        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("...Error: ")
            Console.WriteLine(ex.Message)
            Console.ResetColor()
            WriteLog(String.Format("Shutdown error on host {0}{1}: {2}", machine.Name, vbCrLf, ex.Message), EventLogEntryType.Error, EventId.Error)

        End Try

    End Sub

    Private Sub PopupMessage(host As String, message As String)
        If (Not String.IsNullOrEmpty(message)) Then
            Shell(String.Format("msg * /server:{0} ""{1}""", host, message), AppWinStyle.Hide, False)
        End If
    End Sub

    Private Sub Listen()
        Dim sn As New Listener

        Console.WriteLine("Listening for WakeUp packets.  CTRL-C to abort...")
        Do
            sn.BeginReceive()
        Loop

    End Sub

    Private Sub Enumerate()
        Console.WriteLine("Enumerate machines...")

        Machines.Load(_path)
        For Each m As Machine In Machines
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("{0}", m.Name.PadRight(10, " "))
            Console.ResetColor()
            Console.WriteLine(" IP: {0} MAC: {1}", m.IP.PadRight(16, " "), m.MAC)
        Next
    End Sub

    Private Function ShowIPConfig() As Integer
        Dim ping As New NetworkInformation.Ping
        Dim reply As NetworkInformation.PingReply

        If (_machine = "") Then
            Console.WriteLine("You must specify machine name with -m")
            Return ErrorCodes.InvalidCommand
        End If
        Console.WriteLine("Show IP configuration for " & _machine)
        Try
            For Each IPA As IPAddress In Dns.GetHostAddresses(_machine)
                Console.WriteLine("  Address: {0} Family: {1}", IPA.ToString(), IPA.AddressFamily.ToString())
            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ErrorCodes.NotFound

        End Try

        reply = ping.Send(_machine, 1500)
        Console.WriteLine("Ping: " & reply.Status.ToString())
        Return ErrorCodes.Ok

    End Function

End Module
