'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2017 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
Imports Machines

Module Wake
    Public Sub WakeUp(ByVal machine As Machine, Optional repeatInterval As Integer = 0)
        Dim host As String

        Try
            If (machine.Method = 0) Then
                host = machine.Broadcast
            Else
                host = machine.Netbios
            End If

            If (machine.RepeatCount > 1) Then
                For i As Integer = 1 To machine.RepeatCount
                    WOL.AquilaWolLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL)
                    Threading.Thread.Sleep(repeatInterval)
                Next
            Else
                WOL.AquilaWolLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL)
            End If
            WOL.AquilaWolLibrary.WriteLog(String.Format("WakeUp sent to ""{0}""", machine.Name), EventLogEntryType.Information, WOL.AquilaWolLibrary.EventId.WakeUp)

        Catch ex As Exception
            WOL.AquilaWolLibrary.WriteLog(String.Format("WakeUp error: {0}", ex.Message), EventLogEntryType.Error, WOL.AquilaWolLibrary.EventId.Error)
            Console.WriteLine(ex.InnerException)

        End Try

    End Sub

    Public Sub WakeUp(ByVal mac As String, Optional network As String = "")
        WOL.AquilaWolLibrary.WakeUp(mac, network)
    End Sub

End Module
