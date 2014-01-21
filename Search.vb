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

Imports System.Net.Sockets
Imports System.Net
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.Win32
Imports System.Management

Public Class Search

    Declare Function SendARP Lib "iphlpapi.dll" (
        ByVal DestIP As Int32, ByVal SrcIP As Int32, _
        ByVal pMacAddr As Byte(), ByRef PhyAddrLen As Integer) As Integer

    Private Structure Profile
        Public Name As String
        Public IPAddress As String
        Public OSName As String
        Public NetInterface As String
        Public MacAddress As String
        Public HasError As Boolean
    End Structure

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim m As Machine

        For Each l As ListViewItem In ListView1.CheckedItems
            Machines.Remove(l.SubItems(0).Text)

            m = New Machine
            m.Name = l.SubItems(0).Text
            m.MAC = l.SubItems(4).Text
            m.IP = l.SubItems(3).Text
            m.Netbios = l.SubItems(0).Text
            m.Emergency = True
            m.ShutdownCommand = ""
            Machines.Add(m)
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Poll(ByVal IP As String, ByVal Progress As Integer)
        Dim scope As ManagementScope
        Dim managementObject As ManagementObject
        Dim searcher As ManagementObjectSearcher
        Dim queryCollection As ManagementObjectCollection
        Dim query As ObjectQuery

        Dim profile As New Profile

        Try
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Polling, IP)
            profile.HasError = False

            If Not My.Computer.Network.Ping(IP) Then
                BackgroundWorker1.ReportProgress(Progress, Nothing)
                Exit Sub
            End If

            scope = New ManagementScope("\\" & IP & "\root\cimv2")
            scope.Connect()

            ' Use this code if you are connecting with a 
            ' different user name and password:
            '
            ' Dim scope As ManagementScope
            ' scope = New ManagementScope( _
            '     "\\FullComputerName\root\cimv2", options)
            ' scope.Connect()

            ' Query system for Operating System information

            query = New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
            searcher = New ManagementObjectSearcher(scope, query)
            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                profile.Name = managementObject("csname")
                profile.OSName = managementObject("Caption")
                Exit For
            Next

            query = New ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration")
            searcher = New ManagementObjectSearcher(scope, query)

            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                If managementObject("IPEnabled") Then
                    profile.NetInterface = managementObject("Caption")
                    If profile.NetInterface.StartsWith("[") Then
                        Dim j As Int16
                        j = InStr(profile.NetInterface, "]", CompareMethod.Text)
                        profile.NetInterface = profile.NetInterface.Substring(j + 1)
                    End If

                    For Each s As String In managementObject("IPaddress")
                        profile.IPAddress = s
                        Exit For
                    Next

                    profile.MacAddress = managementObject("MacAddress")
                    BackgroundWorker1.ReportProgress(Progress, profile)
                Else
                    BackgroundWorker1.ReportProgress(Progress, Nothing)
                End If
            Next

        Catch ex As Exception
            profile.IPAddress = IP
            profile = FindMAC(profile)
            If profile.Name = "" Then profile.Name = IP
            BackgroundWorker1.ReportProgress(Progress, profile)

        End Try

    End Sub

    Private Function FindMAC(profile As Profile) As Profile
        Dim address As IPAddress
        Dim dwRemoteIP As Int32
        Dim mac() As Byte = New Byte(6) {}
        Dim len As Integer = 6
        Dim DNShost As IPHostEntry

        Try
            address = IPAddress.Parse(profile.IPAddress)
            dwRemoteIP = address.GetHashCode()

            If dwRemoteIP <> 0 Then
                If SendARP(dwRemoteIP, 0, mac, len) = 0 Then
                    profile.MacAddress = BitConverter.ToString(mac, 0, len)
                    DNShost = Dns.GetHostEntry(address)
                    profile.Name = DNShost.HostName
                    profile.OSName = "Unknown"
                End If
            End If

        Catch ex As Exception
            profile.OSName = ex.Message
            profile.HasError = True

        End Try

        Return profile

    End Function

    Private Sub Button_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Search.Click
        Me.Cursor = Cursors.WaitCursor
        Button_Search.Enabled = False
        Button_Cancel.Enabled = True
        ToolStripProgressBar1.Visible = True
        ListView1.Items.Clear()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

#Region "DEMO"

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IpAddressControl_Start.Text = "192.168.0.1"
        IpAddressControl_End.Text = "192.168.0.20"

#If DEMO Then
        Dim i As ListViewItem

        i = ListView1.Items.Add("Landru")
        i.SubItems.Add("Microsoft(R) Windows(R) Server 2003, Standard Edition")
        i.SubItems.Add("HP Network Teaming Virtual Miniport Driver")
        i.SubItems.Add("192.168.0.4")
        i.SubItems.Add("00:0B:33:6D:02:3A")

        i = ListView1.Items.Add("Morbo")
        i.SubItems.Add("Microsoft(R) Windows XP")
        i.SubItems.Add("HP Network Teaming Virtual Miniport Driver")
        i.SubItems.Add("192.168.0.8")
        i.SubItems.Add("00:0A:13:6F:01:3A")

        ToolStripProgressBar1.Visible = True
        ToolStripProgressBar1.Value = 20
        ToolStripStatusLabel1.Text = "Polling 129.168.0.9"
#End If

    End Sub
#End Region

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim i, startIP, stopIP As UInt32
        Dim ip As String
        Dim Progress As Integer

        Try
            startIP = IPToInt(IPAddress.Parse(IpAddressControl_Start.Text))
            stopIP = IPToInt(IPAddress.Parse(IpAddressControl_End.Text))

            For i = startIP To stopIP
                ip = IPAddress.Parse(i).ToString()
                If (ip.EndsWith(".255")) Then
                    Continue For
                End If
                Progress = (i - startIP) * 100 / Math.Max(1, stopIP - startIP)
                Poll(ip, Progress)
                If BackgroundWorker1.CancellationPending Then
                    Exit For
                End If
                Application.DoEvents()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Search worker", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function IPToInt(address As IPAddress) As UInt32
        Dim bytes As Byte() = address.GetAddressBytes()

        If BitConverter.IsLittleEndian Then
            Array.Reverse(bytes)
        End If
        Dim num As UInt32 = BitConverter.ToUInt32(bytes, 0)
        Return num
    End Function

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim i As ListViewItem
        Dim p As Profile

        If Not (e.UserState Is Nothing) Then
            p = e.UserState
            i = ListView1.Items.Add(p.Name)
            i.SubItems.Add(p.OSName)
            i.SubItems.Add(p.NetInterface)
            i.SubItems.Add(p.IPAddress)
            i.SubItems.Add(p.MacAddress)
        End If

        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button_Search.Enabled = True
        Button_Cancel.Enabled = False
        Me.Cursor = Cursors.Default
        ToolStripStatusLabel1.Text = My.Resources.Strings.Done
        ToolStripProgressBar1.Visible = False
    End Sub

    Private Sub Button_CheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CheckAll.Click
        For Each l As ListViewItem In ListView1.Items
            l.Checked = True
        Next
    End Sub

    Private Sub Button_UnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_UnCheckAll.Click
        For Each l As ListViewItem In ListView1.Items
            l.Checked = False
        Next
    End Sub

    Private Sub ShowDetails(ByVal l As ListViewItem)
        Dim scope As ManagementScope
        Dim m As ManagementObject
        Dim searcher As ManagementObjectSearcher
        Dim queryCollection As ManagementObjectCollection
        Dim query As ObjectQuery
        Dim s As String = ""

        If l.SubItems(0).Text = "" Then
            l.StateImageIndex = 2
            MsgBox(l.SubItems(1).Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        Try
            scope = New ManagementScope("\\" & l.Text & "\root\cimv2")
            scope.Connect()

            ' Query system for Operating System information

            query = New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
            searcher = New ManagementObjectSearcher(scope, query)
            queryCollection = searcher.Get()

            For Each m In queryCollection
                s = m("Caption") & vbCrLf
                Exit For
            Next

            query = New ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration")
            searcher = New ManagementObjectSearcher(scope, query)
            queryCollection = searcher.Get()

            For Each m In queryCollection
                If m("IPEnabled") Then
                    s &= "Network adapter: " & m("Caption") & vbCrLf
                    'If p.NetInterface.StartsWith("[") Then
                    '    Dim j As Int16
                    '    j = InStr(p.NetInterface, "]", CompareMethod.Text)
                    '    p.NetInterface = p.NetInterface.Substring(j + 1)
                    'End If

                    For Each ip As String In m("IPaddress")
                        s &= "IP: " & ip & vbCrLf
                    Next

                    s &= "MAC: " & m("MacAddress")
                End If
            Next
            MsgBox(s, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, l.Text & " settings")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")

        End Try
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        ShowDetails(ListView1.SelectedItems(0))
    End Sub

End Class
