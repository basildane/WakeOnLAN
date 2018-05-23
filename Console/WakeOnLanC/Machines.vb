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

Imports System.Xml.Serialization
Imports Machines
Imports Microsoft.Win32

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

    Public Function GetPath(Path As String)
        If String.IsNullOrEmpty(Path) Then
            Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Aquila Technology\WakeOnLAN", False)
            Path = regKey.GetValue("Database", IO.Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.ToString).ToString, RegistryValueOptions.None)
            Path = IO.Path.Combine(Path, "machines.xml")
            regKey.Close()
        End If
        Return Path
    End Function

    Public Sub Load(Path As String)
        Import(GetPath(Path))
    End Sub

    Public Sub Save(Path As String)
        Export(GetPath(Path))
    End Sub

    Public Sub Import(ByVal Filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim fs As IO.FileStream

        Try
            Console.WriteLine("Loading database: " & Filename)
            fs = New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read)
            Machines = CType(serializer.Deserialize(fs), MachinesClass)
            fs.Close()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Throw

        End Try

    End Sub

    Public Sub Export(ByVal Filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim writer As IO.StreamWriter

        Try
            writer = New IO.StreamWriter(Filename)
            serializer.Serialize(writer, Machines)
            writer.Close()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Throw

        End Try

    End Sub

    Public Sub Add(ByVal machine As Machine)
        List.Add(machine)
    End Sub

End Class
