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

Imports WOL.AquilaWOLLibrary

Module Wake
    Public Sub WakeUp(ByVal machine As Machine, ByVal Adapter As String)
        Dim host As String

        Try
            If (machine.Method = 0) Then
                host = machine.Broadcast
            Else
                host = machine.Netbios
            End If
            If String.IsNullOrEmpty(Adapter) Then
                Adapter = machine.Adapter
            End If
            WOL.AquilaWOLLibrary.WakeUp(machine.MAC, host, machine.UDPPort, machine.TTL, Adapter)

        Catch ex As Exception
            Console.WriteLine(ex.InnerException)

        End Try

    End Sub

    Public Sub WakeUp(ByVal MAC As String, ByVal Adapter As String)
        WOL.AquilaWOLLibrary.WakeUp(MAC, Adapter:=Adapter)
    End Sub

End Module
