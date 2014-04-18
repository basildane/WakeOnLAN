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

Imports System.Xml.Serialization


Module MachinesModule
    Public Machines As New MachinesClass
End Module

Public Class MachinesClass
    Inherits CollectionBase

    Default Public Property Item(ByVal Name As String) As Machine
        Get
            For Each m As Machine In List
                If String.Compare(m.Name, Name, True) = 0 Then Return m
            Next
            Return Nothing
        End Get
        Set(ByVal value As Machine)
            List(Name) = value
        End Set
    End Property

    Default Public ReadOnly Property Item(ByVal Index As Integer) As Machine
        Get
            Return List(Index)
        End Get
    End Property

    Public Sub Load(Path As String)
        If (Path = "") Then
            Path = IO.Path.Combine(IO.Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.ToString).ToString, "machines.xml")
        End If

        Import(Path)
    End Sub

    Public Sub Import(ByVal Filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim fs As IO.FileStream

        Try
            fs = New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read)
            Machines = CType(serializer.Deserialize(fs), MachinesClass)

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Throw

        End Try

    End Sub

    Public Sub Add(ByVal Machine As Machine)
        List.Add(Machine)
    End Sub

End Class


<Serializable()> Public Class Machine
    Public Name As String = ""
    Public MAC As String = ""
    Public IP As String = ""
    Public Broadcast As String = ""
    Public Netbios As String = ""
    Public Method As Integer = 0
    Public Emergency As Boolean = False
    Public ShutdownCommand As String = ""
    Public Group As String = ""
    Public UDPPort As Integer = 9
    Public TTL As Integer = 128
    Public Adapter As String = ""
End Class
