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

Imports System.Diagnostics
Imports System.Net
Imports System.Management

Module Module1
    Private Declare Function FormatMessageA Lib "kernel32" (ByVal flags As Integer, ByRef source As Object, ByVal messageID As Integer, ByVal languageID As Integer, ByVal buffer As String, ByVal size As Integer, ByRef arguments As Integer) As Integer
    Private Declare Function InitiateSystemShutdown Lib "advapi32.dll" Alias "InitiateSystemShutdownA" (ByVal lpMachineName As String, ByVal lpMessage As String, ByVal dwTimeout As Integer, ByVal bForceAppsClosed As Integer, ByVal bRebootAfterShutdown As Integer) As Integer
    Private Declare Function AbortSystemShutdown Lib "advapi32.dll" Alias "AbortSystemShutdownA" (ByVal lpMachineName As String) As Integer

    Enum _modeTypes
        none
        Shutdown
        WakeUp
        Abort
        Debug
        Sleep
        Hibernate
    End Enum

    Enum ErrorCodes
        OK = 0
        InvalidCommand = 1
        NotFound = 2
        PermissionDenied = 5
    End Enum

    Dim sMachine As String = ""
    Dim sMAC As String = ""
    Dim all As Boolean = False
    Dim sAlertMessage As String = "System is shutting down" & vbNullChar
    Dim dwDelay As Long = 30
    Dim dwForce As Long = 0
    Dim dwReboot As Long = 0
    Dim Mode As _modeTypes = _modeTypes.none
    Dim Result As Integer = ErrorCodes.OK
    Dim sPath As String = ""
    Dim sInterface As String = ""

    Function Main() As Integer

        Dim i As Integer

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(My.Application.Info.Title & " " & My.Application.Info.Version.ToString)
        Console.ResetColor()

        If My.Application.CommandLineArgs.Count = 0 Then
            DisplayHelp()
            Return ErrorCodes.OK
        End If

        For i = 0 To My.Application.CommandLineArgs.Count - 1
            Select Case My.Application.CommandLineArgs.Item(i)
                Case "-t"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    dwDelay = Val(My.Application.CommandLineArgs.Item(i + 1))
                    i += 1

                Case "-f"
                    dwForce = 1

                Case "-m"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    sMachine = My.Application.CommandLineArgs.Item(i)

                Case "-p"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    sPath = My.Application.CommandLineArgs.Item(i)

                Case "-mac"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    sMAC = My.Application.CommandLineArgs.Item(i)

                Case "-if"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    i += 1
                    sInterface = My.Application.CommandLineArgs.Item(i)

                Case "-all"
                    all = True

                Case "-r"
                    Mode = _modeTypes.Shutdown
                    dwReboot = 1

                Case "-s"
                    Mode = _modeTypes.Shutdown
                    dwReboot = 0

                Case "-s1"
                    Mode = _modeTypes.Sleep
                    dwReboot = 0

                Case "-s4"
                    Mode = _modeTypes.Hibernate
                    dwReboot = 0

                Case "-w"
                    Mode = _modeTypes.WakeUp

                Case "-a"
                    Mode = _modeTypes.Abort

                Case "-c"
                    If i = My.Application.CommandLineArgs.Count - 1 Then
                        BadCommand()
                        Return ErrorCodes.InvalidCommand
                    End If
                    sAlertMessage = My.Application.CommandLineArgs.Item(i + 1) & vbNullChar
                    i += 1

                Case "-l"
                    Listen()
                    Return ErrorCodes.OK

                Case "-e"
                    Enumerate()
                    Return ErrorCodes.OK

                Case "-h"
                    DisplayHelp()
                    Return ErrorCodes.OK

                Case "-d"
                    Mode = _modeTypes.Debug

                Case Else
                    DisplayHelp()
                    Return ErrorCodes.InvalidCommand

            End Select

        Next

        Select Case Mode

            Case _modeTypes.Shutdown
                Return Shutdown()

            Case _modeTypes.Sleep, _modeTypes.Hibernate
                Return SleepHibernate()

            Case _modeTypes.WakeUp
                Return DoWakeup()

            Case _modeTypes.Abort
                Return Abort()

            Case _modeTypes.Debug
                Return ShowIPConfig()

            Case Else
                BadCommand()
                Return ErrorCodes.InvalidCommand

        End Select

    End Function

    Private Sub DisplayHelp()
        Console.WriteLine()
        Console.WriteLine("Commands are:")
        Console.WriteLine("-s   (shutdown) requires -m or -all")
        Console.WriteLine("-s1  (sleep) requires -m or -all")
        Console.WriteLine("-s4  (hibernate) requires -m or -all")
        Console.WriteLine("-a   (abort a shutdown) requires -m")
        Console.WriteLine("-r   (reboot)")
        Console.WriteLine("-w   (wakeup) requires -m, -mac parameter, or -all")
        Console.WriteLine("-l   (listen for WOL packets)")
        Console.WriteLine("-e   (enumerate machine list)")
        Console.WriteLine("-p   (path to machines.xml (optional))")
        Console.WriteLine("-if  (select Interface (example -if 192.168.0.20) (optional))")
        Console.WriteLine("-d   (debug) requires -m")
        Console.WriteLine("-h   (display this help message)")
        Console.WriteLine()
        Console.WriteLine("options:")
        Console.WriteLine("-t xx      delay (xx = seconds).  For Shutdown and Reboot commands.")
        Console.WriteLine("-f         force files closed.  For Shutdown and reboot commands.")
        Console.WriteLine("-m xx      xx = machine name.")
        Console.WriteLine("-mac xxxxxxxx = mac address.")
        Console.WriteLine("-all       all machines.")
        Console.WriteLine("-c ""xx""    xx = comment.  Options for Shutdown and Reboot.")
        Console.WriteLine()
        Console.WriteLine("note.  Use -m with -w to send to a specific subnet.")
    End Sub

    Private Sub BadCommand()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("Invalid command line.")
        Console.ResetColor()
        DisplayHelp()
    End Sub

    Private Sub ShowResult(ByVal dwResult As Integer)
        If dwResult Then
            Console.WriteLine("...Successful")
        Else
            Dim errMessage As String

            Result = Err.LastDllError
            errMessage = FormatMessage(Result)
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("...Error")
            Console.WriteLine(errMessage)
            Console.ResetColor()
        End If
    End Sub

    Private Function DoWakeup() As Integer

        If all Then
            Try
                Machines.Load(sPath)

            Catch ex As Exception
                Result = ErrorCodes.PermissionDenied
                Return Result

            End Try

            For Each m As Machine In Machines
                Console.Write("Wakeup " & m.Name & "... ")
                If m.MAC = "" Then
                    Result = ErrorCodes.NotFound
                    Console.WriteLine("Cannot find MAC address for " & m.Name)
                Else
                    Console.WriteLine("waking up mac: " & m.MAC)
                    WakeUp(m, sInterface)
                End If
            Next
            Return Result

        ElseIf sMachine.Length Then
            Dim m As Machine

            Try
                Machines.Load(sPath)

            Catch ex As Exception
                Result = ErrorCodes.PermissionDenied
                Return Result

            End Try

            m = Machines(sMachine)
            If m Is Nothing Then
                Console.WriteLine("Cannot find machine " & sMachine)
                Return ErrorCodes.NotFound
            End If
            Console.WriteLine("wakeup sent to " & sMachine)
            Console.WriteLine("waking up mac: " & m.MAC)
            WakeUp(m, sInterface)
            Return ErrorCodes.OK

        ElseIf sMAC.Length Then
            Console.WriteLine("waking up mac: " & sMAC)
            WakeUp(sMAC, sInterface)
            Return ErrorCodes.OK

        Else
            Console.WriteLine("Error.  No machine or MAC specified.")
            DisplayHelp()
            Return ErrorCodes.InvalidCommand

        End If

    End Function

    Private Function Abort() As Integer
        Dim dwResult As Integer

        If sMachine = "" And all = False Then
            Console.WriteLine("Error.  No machine specified.")
            DisplayHelp()
            Return ErrorCodes.InvalidCommand
        End If

        If all Then
            Machines.Load(sPath)
            For Each m As Machine In Machines
                Console.Write("Abort shutdown sent to " & m.Name)
                dwResult = AbortSystemShutdown(m.Netbios)
                ShowResult(dwResult)
            Next
        Else
            Console.Write("Abort shutdown sent to " & sMachine)
            dwResult = AbortSystemShutdown(sMachine)
            ShowResult(dwResult)
        End If

        Return Result

    End Function

    Private Function Shutdown() As Integer
        Dim dwResult As Integer = 1
        Machines.Load(sPath)

        If ((sMachine = "") And (all = False)) Then
            Console.WriteLine("Error.  No machine specified.")
            DisplayHelp()
            Result = ErrorCodes.InvalidCommand
            Return Result
        End If

        If all Then
            For Each m As Machine In Machines
                Console.Write("Shutdown sent to " & m.Name)
                dwResult = InitiateSystemShutdown(m.Netbios, sAlertMessage, dwDelay, dwForce, dwReboot)
                ShowResult(dwResult)
            Next
        Else
            Dim m As Machine
            m = Machines(sMachine)
            Console.Write("Shutdown sent to " & sMachine)
            dwResult = InitiateSystemShutdown(sMachine, sAlertMessage, dwDelay, dwForce, dwReboot)
            ShowResult(dwResult)
        End If

        Return Result

    End Function

    Private Function SleepHibernate() As Integer
        Dim dwResult As Integer = 1

        Try

            Machines.Load(sPath)

            If ((sMachine = "") And (all = False)) Then
                Console.WriteLine("Error.  No machine specified.")
                DisplayHelp()
                Result = ErrorCodes.InvalidCommand
                Return Result
            End If

            If all Then
                For Each m As Machine In Machines
                    Console.Write(Mode.ToString() & " sent to " & m.Name)
                    dwResult = WMIpower(m.Netbios)
                    ShowResult(dwResult)
                Next
            Else
                Dim m As Machine
                m = Machines(sMachine)
                Console.Write(Mode.ToString() & " sent to " & sMachine)
                dwResult = WMIpower(sMachine)
                ShowResult(dwResult)
            End If

            Return Result

        Catch ex As Exception
            Console.WriteLine()
            Console.WriteLine(ex.Message)
            Return ErrorCodes.InvalidCommand

        End Try

    End Function

    Private Function WMIpower(sMachine As String) As Integer
        Dim process As ManagementClass
        Dim path As ManagementPath
        Dim options As ConnectionOptions = New ConnectionOptions()
        Dim inparams, outparams As ManagementBaseObject
        Dim ProcID, retval As String

        process = New ManagementClass("Win32_Process")
        path = New ManagementPath(String.Format("\\{0}\root\cimv2", sMachine))

        'options.Username = ""
        'options.Password = ""
        'process.Scope = New ManagementScope(mp1, co1)
        process.Scope = New ManagementScope(path)
        process.Scope.Connect()

        inparams = process.GetMethodParameters("Create")
        Select Case Mode
            Case _modeTypes.Sleep
                inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Standby"

            Case _modeTypes.Hibernate
                inparams("CommandLine") = "rundll32.exe powrprof.dll,SetSuspendState Hibernate"

        End Select

        outparams = process.InvokeMethod("Create", inparams, Nothing)
        ProcID = outparams("ProcessID").ToString()
        retval = outparams("ReturnValue").ToString()

        Return retval
    End Function

    Private Sub Listen()
        Dim sn As New Listener

        Console.WriteLine("Listening for WakeUp packets.  CTRL-C to abort...")
        Do
            sn.BeginReceive()
        Loop

    End Sub

    Private Sub Enumerate()
        Console.WriteLine("Enumerate machines...")

        Machines.Load(sPath)
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

        If (sMachine = "") Then
            Console.WriteLine("You must specify machine name with -m")
            Return ErrorCodes.InvalidCommand
        End If
        Console.WriteLine("Show IP configuration for " & sMachine)
        Try
            For Each IPA As IPAddress In Dns.GetHostAddresses(sMachine)
                Console.WriteLine("  Address: {0} Family: {1}", IPA.ToString(), IPA.AddressFamily.ToString())
            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ErrorCodes.NotFound

        End Try

        reply = ping.Send(sMachine, 1500)
        Console.WriteLine("Ping: " & reply.Status.ToString())
        Return ErrorCodes.OK

    End Function


    Private Function FormatMessage(ByVal [error] As Integer) As String
        Const FORMAT_MESSAGE_FROM_SYSTEM As Short = &H1000
        Const LANG_NEUTRAL As Short = &H0
        Dim buffer As String = Space(999)
        FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, 0, [error], LANG_NEUTRAL, buffer, 999, 0)
        buffer = Replace(Replace(buffer, Chr(13), ""), Chr(10), "")
        Return buffer.Substring(0, buffer.IndexOf(Chr(0)))
    End Function

End Module
