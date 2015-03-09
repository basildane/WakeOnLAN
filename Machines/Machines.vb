Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Xml.Serialization
Imports System.Net

<Serializable()> <CLSCompliant(True)> Public Class Machine
    <NonSerialized> Private WithEvents backgroundWorker As New BackgroundWorker
    <NonSerialized> Private WithEvents ping As New Ping
    Private _run As Boolean = False

    Private Declare Function SendARP Lib "iphlpapi.dll" (ByVal DestIP As Int32, ByVal SrcIP As Int32, ByVal pMacAddr As Byte(), ByRef PhyAddrLen As Integer) As Integer

    Public Enum ShutdownMethods As Integer
        WMI = 0
        Custom = 1
        Legacy = 2
    End Enum

    Public Enum StatusCodes As Integer
        Online
        Offline
        Unknown
    End Enum

    Public Property Name As String = String.Empty
    Public Property MAC As String = String.Empty
    Public Property IP As String = String.Empty
    Public Property Broadcast As String = String.Empty
    Public Property Netbios As String = String.Empty
    Public Property Method As Integer = 0
    Public Property Emergency As Boolean = False
    Public Property ShutdownCommand As String = String.Empty
    Public Property Group As String = String.Empty
    Public Property UDPPort As Integer = 9
    Public Property TTL As Integer = 128
    Public Property Adapter As String = String.Empty
    Public Property RDPPort As Integer = 3389
    Public Property Note As String = String.Empty
    Public Property UserID As String = String.Empty
    Public Property Password As String = String.Empty
    Public Property Domain As String = String.Empty
    Public Property ShutdownMethod As ShutdownMethods = ShutdownMethods.WMI
    <XmlIgnore()> Public Status As StatusCodes = StatusCodes.Unknown
    <NonSerialized> <XmlIgnore()> Public Reply As PingReply

    Public Event StatusChange(ByVal Name As String, ByVal status As StatusCodes, ByVal IpAddress As String)

    Public Sub New()
        backgroundWorker.WorkerSupportsCancellation = True
    End Sub

    Public Overrides Function ToString() As String
        Return "Machine: " & Name
    End Function

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

    Private Sub backgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
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
                    End If

                    If (Status <> newStatus) Then
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

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
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

    Private Function CompareMac(mac1 As String, mac2 As String) As Int32

        Try
            Dim _mac1 As String = Replace(mac1, ":", "")
            _mac1 = Replace(_mac1, "-", "")

            Dim _mac2 As String = Replace(mac2, ":", "")
            _mac2 = Replace(_mac2, "-", "")

            Return StrComp(_mac1, _mac2, CompareMethod.Text)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

End Class
