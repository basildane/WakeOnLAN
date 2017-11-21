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

Imports System.IO
Imports System.Xml.Serialization
Imports System.Net
Imports System.Linq
Imports Machines
Imports System.Threading

Module MachinesModule
    Public Machines As New MachinesClass
End Module

Public Class MachinesClass
    Inherits CollectionBase

    Public Dirty As Boolean = False
    Private Shared _pool As Semaphore

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

    Public Sub Load(pool As Semaphore)
        _pool = pool
        Import(GetFile)
    End Sub

    Public Sub Save()
        If Not Dirty Then Exit Sub
        Export(GetFile)
        Dirty = False
    End Sub

    Public Function GetFile() As String
        If String.IsNullOrEmpty(My.Settings.dbPath) Then
            My.Settings.dbPath = IO.Path.Combine(IO.Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.ToString).ToString, "machines.xml")
        End If

        Return My.Settings.dbPath
    End Function

    Public Sub Import(filename As String)
        Try
            Dim serializer As New XmlSerializer(GetType(MachinesClass))

            Dim fileStream As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read)
            Machines = CType(serializer.Deserialize(fileStream), MachinesClass)
            fileStream.Close()
            CheckUpgrade()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
#If DEBUG Then
            Debugger.Break()
#End If

        End Try

    End Sub

    Private Sub CheckUpgrade()
        Debug.WriteLine("Loading database")
        Debug.Indent()

        For Each machine As Machine In Machines
            machine.Pool = _pool

            If (machine.Broadcast = "") Then
                Dirty = True
                machine.Broadcast = IPAddress.Broadcast.ToString()
            End If
            If (machine.UDPPort = 0) Then
                Dirty = True
                machine.UDPPort = 9
            End If
            If (machine.TTL = 0) Then
                Dirty = True
                machine.TTL = 128
            End If
            If (machine.RDPPort = 0) Then
                Dirty = True
                machine.RDPPort = 3389
            End If

            Debug.WriteLine("Machine: " & machine.Name)
            Debug.Indent()
            Debug.WriteLine("MAC [" & machine.MAC & "]")
            Debug.WriteLine("IP [" & machine.IP & "]")
            Debug.WriteLine("Broadcast [" & machine.Broadcast & "]")
            Debug.WriteLine("Netbios [" & machine.Netbios & "]")
            Debug.WriteLine("Method [" & machine.Method & "]")
            Debug.WriteLine("Emergency [" & machine.Emergency & "]")
            Debug.WriteLine("ShutdownCommand [" & machine.ShutdownCommand & "]")
            Debug.WriteLine("Group [" & machine.Group & "]")
            Debug.WriteLine("UDPPort [" & machine.UDPPort & "]")
            Debug.WriteLine("TTL [" & machine.TTL & "]")
            Debug.WriteLine("RDPPort [" & machine.RDPPort & "]")
            Debug.WriteLine("RDPFile [" & machine.RDPFile & "]")
            Debug.WriteLine("Note [" & machine.Note & "]")
            Debug.WriteLine("UserID [" & machine.UserID & "]")
            Debug.WriteLine("Domain [" & machine.Domain & "]")
            Debug.WriteLine("ShutdownMethod [" & machine.ShutdownMethod & "]")
            Debug.WriteLine("KeepAlive [" & machine.KeepAlive & "]")
            Debug.WriteLine("RepeatCount [" & machine.RepeatCount & "]")
            Debug.Unindent()
        Next

        Debug.Unindent()
        Debug.WriteLine("Database complete")
        Debug.WriteLine("***********************************************")
    End Sub

    Public Sub Export(ByVal filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim writer As StreamWriter

        Try
            writer = New StreamWriter(filename)
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
            machine.Pool = _pool
            machine.Run()
        End If
        Dirty = True

    End Sub

    Public Sub Update(ByVal machine As Machine)
        Dirty = True
    End Sub

    Public Sub Remove(ByVal name As String)
        Dim machine As Machine = Machines(name)

        If machine Is Nothing Then Return
        machine.Cancel()
        RemoveHandler machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange
        List.Remove(machine)
        Dirty = True
    End Sub

    Public Sub Close()
        For Each machine As Machine In List
            machine.Cancel()
            RemoveHandler machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange
        Next
    End Sub

End Class
