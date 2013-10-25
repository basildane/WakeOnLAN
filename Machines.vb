'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2013 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

Imports System.Threading
Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Xml.Serialization
Imports System.Net


Module MachinesModule
    Public Machines As New MachinesClass
End Module

Public Class MachinesClass
    Inherits CollectionBase

    Public dirty As Boolean = False

    Default Public Property Item(ByVal Name As String) As Machine
        Get
            For Each m As Machine In List
                If m.Name = Name Then Return m
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
        If My.Settings.dbPath = "" Then
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
            'MessageBox.Show(ex.Message, My.Resources.Strings.ChangesNotSaved, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub CheckUpgrade()
        For Each machine As Machine In Machines
            If (machine.Broadcast = "") Then
                dirty = True
                machine.Broadcast = "255.255.255.255"
            End If
            If (machine.UDPPort = 0) Then
                dirty = True
                machine.UDPPort = 9
            End If
            If (machine.TTL = 0) Then
                dirty = True
                machine.TTL = 128
            End If
        Next
    End Sub

    Public Sub Export(ByVal Filename As String)
        Dim serializer As New XmlSerializer(GetType(MachinesClass))
        Dim writer As IO.StreamWriter

        Try
            writer = New IO.StreamWriter(Filename)
            serializer.Serialize(writer, Machines)
            writer.Close()

        Catch ex As UnauthorizedAccessException
            If (MessageBox.Show(ex.Message, My.Resources.Strings.ChangesNotSaved, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) = DialogResult.Retry) Then
                Export(Filename)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Resources.Strings.ChangesNotSaved, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub Add(ByVal Machine As Machine)
        List.Add(Machine)
        AddHandler Machine.StatusChange, AddressOf My.Forms.Explorer.StatusChange

        If My.Forms.Explorer.PingToolStripButton.Checked Then
            Machine.Run()
        End If
        dirty = True

    End Sub

    Public Sub Remove(ByVal Name As String)
        Dim m As Machine = Nothing
        Dim i As Integer

        For i = 0 To List.Count - 1
            m = List(i)
            If m.Name = Name Then Exit For
        Next
        If i = List.Count Then Exit Sub

        m.Cancel()
        RemoveHandler m.StatusChange, AddressOf My.Forms.Explorer.StatusChange
        List.RemoveAt(i)
        dirty = True
    End Sub

    Public Sub Close()
        Dim m As Machine = Nothing

        For i As Integer = List.Count - 1 To 0 Step -1
            m = List(i)
            m.Cancel()
            RemoveHandler m.StatusChange, AddressOf My.Forms.Explorer.StatusChange
            List.RemoveAt(i)
            dirty = True
        Next
    End Sub

End Class



<Serializable()> Public Class Machine
    Private WithEvents Worker As New BackgroundWorker
    Private WithEvents ping As New Ping
    Private PingComplete As Boolean = True
    Private _Run As Boolean = False

    <XmlIgnore()> Public Reply As PingReply

    Private _Name As String = ""
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _MAC As String = ""
    Public Property MAC() As String
        Get
            Return _MAC
        End Get
        Set(ByVal value As String)
            _MAC = value
        End Set
    End Property

    Private _IP As String = ""
    Public Property IP() As String
        Get
            Return _IP
        End Get
        Set(ByVal value As String)
            _IP = value
        End Set
    End Property

    Private _Broadcast As String = ""
    Public Property Broadcast() As String
        Get
            Return _Broadcast
        End Get
        Set(value As String)
            _Broadcast = value
        End Set
    End Property

    Private _Netbios As String = ""

    Public Property Netbios() As String
        Get
            Return _Netbios
        End Get
        Set(ByVal value As String)
            _Netbios = value
        End Set
    End Property

    Private _Emergency As Boolean = False
    Public Property Emergency() As Boolean
        Get
            Return _Emergency
        End Get
        Set(ByVal value As Boolean)
            _Emergency = value
        End Set
    End Property

    Private _ShutdownCommand As String = ""
    Public Property ShutdownCommand() As String
        Get
            Return _ShutdownCommand
        End Get
        Set(ByVal value As String)
            _ShutdownCommand = value
        End Set
    End Property

    Private _Group As String = ""
    Public Property Group() As String
        Get
            Return _Group
        End Get
        Set(ByVal value As String)
            _Group = value
        End Set
    End Property

    Private _UDPPort As Integer
    Public Property UDPPort() As Integer
        Get
            Return _UDPPort
        End Get
        Set(ByVal value As Integer)
            _UDPPort = value
        End Set
    End Property

    Private _TTL As Integer
    Public Property TTL() As Integer
        Get
            Return _TTL
        End Get
        Set(ByVal value As Integer)
            _TTL = value
        End Set
    End Property

    Public Enum StatusCodes As Integer
        Online
        Offline
        Unknown
    End Enum

    <XmlIgnore()> Public Status As StatusCodes = StatusCodes.Unknown

    Public Event StatusChange(ByVal Name As String, ByVal status As StatusCodes, ByVal IpAddress As String)

    Public Sub New()
        Worker.WorkerSupportsCancellation = True
    End Sub

    Public Sub Run()
        _Run = True
        If Worker.IsBusy Then Exit Sub

        Worker.WorkerReportsProgress = True
        If IP.Length Then
            Worker.RunWorkerAsync(IP)
        Else
            Worker.RunWorkerAsync(Netbios)
        End If
    End Sub

    Public Function Busy() As Boolean
        Return Worker.IsBusy
    End Function

    Public Sub Cancel()
        _Run = False
        Worker.CancelAsync()
    End Sub

    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles Worker.DoWork
        Do
            Try
                Threading.Thread.Sleep(2000)
                Reply = ping.Send(e.Argument, 1500)
                If Reply.Status = IPStatus.Success Then
                    Worker.ReportProgress(100)
                Else
                    Worker.ReportProgress(0)
                End If

            Catch ex As Exception
                Worker.ReportProgress(0)

            End Try

        Loop Until Worker.CancellationPending = True
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        Try
            If Worker.CancellationPending Then Exit Sub

            Select Case e.ProgressPercentage
                Case 100
                    If Status <> StatusCodes.Online Then
                        Status = StatusCodes.Online
                        ' return ip4 address if possible
                        If IP = "" Then
                            For Each IPA As IPAddress In Dns.GetHostAddresses(Name)
                                If IPA.AddressFamily.ToString() = "InterNetwork" Then
                                    RaiseEvent StatusChange(Name, Status, IPA.ToString)
                                    Exit Sub
                                End If
                            Next

                        End If

                        RaiseEvent StatusChange(Name, Status, Reply.Address.ToString)
                    End If

                Case Else
                    If Status <> StatusCodes.Offline Then
                        Status = StatusCodes.Offline
                        RaiseEvent StatusChange(Name, Status, "")
                    End If

            End Select

        Catch ex As Exception
            Debug.Fail(ex.Message)

        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        Try
            Debug.WriteLine("(BackgroundWorker_Ping_RunWorkerCompleted) " & Name & " " & e.Result)
            If _Run Then
                'Debug.WriteLine("*** worker completed - rerun")
                Run()
                Exit Sub
            End If
            Status = StatusCodes.Unknown
            RaiseEvent StatusChange(Name, Status, "")

        Catch ex As Exception
            Debug.Fail(ex.Message)

        End Try

    End Sub

End Class
