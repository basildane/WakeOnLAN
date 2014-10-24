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

Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Xml.Serialization
Imports System.Net
Imports System.Linq

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
        Dim m As Machine

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
    Private WithEvents backgroundWorker As New BackgroundWorker
    Private WithEvents ping As New Ping
    Private _run As Boolean = False

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

    Private _Method As Integer = 0
    Public Property Method() As Integer
        Get
            Return _Method
        End Get
        Set(ByVal value As Integer)
            _Method = value
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

    Private _Adapter As String
    Public Property Adapter() As String
        Get
            Return _Adapter
        End Get
        Set(value As String)
            _Adapter = value
        End Set
    End Property

    Private _RDPPort As Integer
    Public Property RDPPort() As Integer
        Get
            Return _RDPPort
        End Get
        Set(value As Integer)
            _RDPPort = value
        End Set
    End Property

    Private _note As String
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(value As String)
            _note = value
        End Set
    End Property

    Private _userid As String
    Public Property UserID() As String
        Get
            Return _userid
        End Get
        Set(value As String)
            _userid = value
        End Set
    End Property

    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Private _domain As String
    Public Property Domain() As String
        Get
            Return _domain
        End Get
        Set(value As String)
            _domain = value
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
        backgroundWorker.WorkerSupportsCancellation = True
    End Sub

    Public Sub Run()
        _run = True
        If backgroundWorker.IsBusy Then Exit Sub

        backgroundWorker.WorkerReportsProgress = True
        If IP.Length Then
            backgroundWorker.RunWorkerAsync(IP)
        Else
            backgroundWorker.RunWorkerAsync(Netbios)
        End If
    End Sub

    Public Function Busy() As Boolean
        Return backgroundWorker.IsBusy
    End Function

    Public Sub Cancel()
        _run = False
        backgroundWorker.CancelAsync()
    End Sub

    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker.DoWork
        Do
            Try
                Threading.Thread.Sleep(2000)
                Reply = ping.Send(e.Argument, 1500)
                If Reply.Status = IPStatus.Success Then
                    backgroundWorker.ReportProgress(100)
                Else
                    backgroundWorker.ReportProgress(0)
                End If

            Catch ex As Exception
                backgroundWorker.ReportProgress(0)

            End Try

        Loop Until backgroundWorker.CancellationPending = True
    End Sub

    Private Sub backgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
        Dim newStatus As StatusCodes
        Dim newIpAddress As String

        Try
            If backgroundWorker.CancellationPending Then Exit Sub

            Select Case e.ProgressPercentage
                Case 100
                    newStatus = StatusCodes.Online
                    newIpAddress = Reply.Address.ToString

                    If Status = StatusCodes.Unknown Then
                        ' if the host is DHCP, try to resolve the correct IP and verify the MAC.
                        ' if we cannot find a matching interface with our MAC, assume the host is OFFLINE.
                        If IP = String.Empty Then
                            newStatus = StatusCodes.Offline

                            For Each ipAddress As IPAddress In From IPA1 In Dns.GetHostAddresses(Netbios) Where IPA1.AddressFamily.ToString() = "InterNetwork"
                                Dim remoteIp As Integer
                                Dim remoteMac() As Byte = New Byte(6) {}
                                Dim dWord As Integer
                                Dim sendInterface As Integer
                                Dim len As Integer = 6

                                Try
                                    If String.IsNullOrEmpty(Adapter) Then
                                        sendInterface = 0
                                    Else
                                        sendInterface = ipAddress.Parse(Adapter).GetHashCode()
                                    End If

                                    remoteIp = ipAddress.GetHashCode()
                                    If remoteIp <> 0 Then
                                        dWord = SendARP(remoteIp, sendInterface, remoteMac, len)
                                        If dWord = 0 Or dWord = 67 Then
                                            '
                                            ' we found a matching MAC, the host is officially ONLINE
                                            ' 67 = ERROR_BAD_NET_NAME: if host on another subnet, just ignore the error
                                            '
                                            If CompareMac(BitConverter.ToString(remoteMac, 0, len), MAC) = 0 Or dWord = 67 Then
                                                newStatus = StatusCodes.Online
                                                newIpAddress = ipAddress.ToString()
                                                Exit For
                                            End If
                                        End If
                                    End If

                                Catch

                                End Try
                            Next
                        End If

                        Status = newStatus
                        RaiseEvent StatusChange(Name, Status, newIpAddress)
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

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        Try
            Debug.WriteLine("(BackgroundWorker_Ping_RunWorkerCompleted) " & Name & " " & e.Result)
            If _run Then
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
