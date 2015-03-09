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

Imports System.Xml.Serialization
Imports System.Net
Imports System.Linq
Imports Machines

Module MachinesModule
    Public Machines As New MachinesClass
End Module

Public Class MachinesClass
    Inherits CollectionBase

    Public dirty As Boolean = False

    Default Public Property Item(ByVal Name As String) As Machine
        Get
            For Each m As Machine In From m1 As Machine In List Where m1.Name = Name
                Return m
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

    Public Sub Load()
        Import(GetFile)
    End Sub

    Public Sub Save()
        If Not dirty Then Exit Sub
        Export(GetFile)
        dirty = False
    End Sub

    Public Function GetFile() As String
        If String.IsNullOrEmpty(My.Settings.dbPath) Then
            My.Settings.dbPath = IO.Path.Combine(IO.Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.ToString).ToString, "machines.xml")
        End If

        Return My.Settings.dbPath
    End Function

    Public Sub Import(ByVal Filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim fs As IO.FileStream

        Try
            fs = New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read)
            Machines = CType(serializer.Deserialize(fs), MachinesClass)
            fs.Close()
            CheckUpgrade()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Debugger.Break()

        End Try

    End Sub

    Private Sub CheckUpgrade()
        For Each machine As Machine In Machines
            If (machine.Broadcast = "") Then
                dirty = True
                machine.Broadcast = IPAddress.Broadcast.ToString()
            End If
            If (machine.UDPPort = 0) Then
                dirty = True
                machine.UDPPort = 9
            End If
            If (machine.TTL = 0) Then
                dirty = True
                machine.TTL = 128
            End If
            If (machine.RDPPort = 0) Then
                dirty = True
                machine.RDPPort = 3389
            End If
        Next
    End Sub

    Public Sub Export(ByVal filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim writer As IO.StreamWriter

        Try
            writer = New IO.StreamWriter(filename)
            serializer.Serialize(writer, Machines)
            writer.Close()

        Catch ex As UnauthorizedAccessException
            If (MessageBox.Show(ex.Message, My.Resources.Strings.ChangesNotSaved, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) = DialogResult.Retry) Then
                Export(filename)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Resources.Strings.ChangesNotSaved, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub Add(ByVal machine As Machine)
        List.Add(machine)
        AddHandler machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange

        If My.Forms.Explorer.PingToolStripButton.Checked Then
            machine.Run()
        End If
        dirty = True

    End Sub

    Public Sub Update(ByVal machine As Machine)
        dirty = True
    End Sub

    Public Sub Remove(ByVal name As String)
        Dim machine As Machine = Machines(name)

        If machine Is Nothing Then Return
        machine.Cancel()
        RemoveHandler machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange
        List.Remove(machine)
        dirty = True
    End Sub

    Public Sub Close()
        Dim machine As Machine

        For i As Integer = List.Count - 1 To 0 Step -1
            machine = List(i)
            machine.Cancel()
            RemoveHandler machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange
        Next
    End Sub

End Class
