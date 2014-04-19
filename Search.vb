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
        Public WakeEnabled As String
        Public PowerManagementEnable As String
        Public PowerManagementActive As String
        Public WakeOnMagicOnly As String
    End Structure

    Private none As String = "--" & My.Resources.Strings.lit_None & "--"

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim m As Machine

        For Each l As ListViewItem In listView.CheckedItems
            Machines.Remove(l.SubItems(0).Text)

            m = New Machine
            m.Name = l.SubItems(0).Text
            m.MAC = l.SubItems(4).Text
            m.IP = l.SubItems(3).Text
            m.Netbios = l.SubItems(0).Text
            m.Emergency = True
            m.ShutdownCommand = ""
            If (ComboBoxGroup.Text <> none) Then
                m.Group = ComboBoxGroup.Text
            End If

            Machines.Add(m)
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Poll(ByVal IP As String, ByVal Progress As Integer)
        Dim profile As Profile

        Try
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Polling, IP)

            If Not My.Computer.Network.Ping(IP) Then
                backgroundWorker.ReportProgress(Progress, Nothing)
                Exit Sub
            End If

            profile = getWMIdata(IP)
            backgroundWorker.ReportProgress(Progress, profile)

        Catch ex As Exception
            backgroundWorker.ReportProgress(Progress, Nothing)

        End Try

    End Sub

    Private Function getWMIdata(IP As String) As Profile
        Dim scope_cimv2, scope_WMI As ManagementScope
        Dim managementObject As ManagementObject
        Dim searcher As ManagementObjectSearcher
        Dim queryCollection As ManagementObjectCollection
        Dim WMIquery As ObjectQuery

        Dim profile As New Profile

        Try
            profile.HasError = False

            scope_cimv2 = New ManagementScope("\\" & IP & "\root\cimv2")
            scope_cimv2.Connect()
            scope_WMI = New ManagementScope("\\" & IP & "\root\WMI")
            scope_WMI.Connect()

            ' Query system for Operating System information
            WMIquery = New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
            searcher = New ManagementObjectSearcher(scope_cimv2, WMIquery)
            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                profile.Name = managementObject("csname")
                profile.OSName = managementObject("Caption")
                Exit For
            Next

            WMIquery = New ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=True")
            searcher = New ManagementObjectSearcher(scope_cimv2, WMIquery)

            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                For Each s As String In managementObject("IPaddress")
                    profile.IPAddress = s
                    Exit For
                Next

                WMIquery = New ObjectQuery("SELECT * FROM Win32_NetWorkAdapter WHERE AdapterTypeId=0 AND Index='" & managementObject("Index") & "'")
                searcher = New ManagementObjectSearcher(scope_cimv2, WMIquery)

                For Each managementObjectAdapter As ManagementObject In searcher.Get()
                    profile.NetInterface = managementObjectAdapter("Description")
                    profile.MacAddress = managementObjectAdapter("MACAddress")

                    Try
                        WMIquery = New ObjectQuery("SELECT * FROM MSPower_DeviceEnable")
                        searcher2 = New ManagementObjectSearcher(scope_WMI, WMIquery)
                        For Each managementObject2 As ManagementObject In searcher2.Get()
                            If (managementObject2("InstanceName").ToString().ToUpper.StartsWith(managementObjectAdapter("PNPDeviceID"))) Then
                                profile.PowerManagementEnable = IIf(managementObject2("Enable"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                profile.PowerManagementActive = IIf(managementObject2("Active"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                Exit For
                            End If
                        Next

                        WMIquery = New ObjectQuery("SELECT * FROM MSPower_DeviceWakeEnable")
                        searcher2 = New ManagementObjectSearcher(scope_WMI, WMIquery)
                        For Each managementObject2 As ManagementObject In searcher2.Get()
                            If (managementObject2("InstanceName").ToString().ToUpper.StartsWith(managementObjectAdapter("PNPDeviceID"))) Then
                                profile.WakeEnabled = IIf(managementObject2("Enable"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                Exit For
                            End If
                        Next

                        WMIquery = New ObjectQuery("SELECT * FROM MSNdis_DeviceWakeOnMagicPacketOnly")
                        searcher2 = New ManagementObjectSearcher(scope_WMI, WMIquery)
                        For Each managementObject2 As ManagementObject In searcher2.Get()
                            If (managementObject2("InstanceName").ToString().ToUpper.StartsWith(managementObjectAdapter("PNPDeviceID"))) Then
                                profile.WakeOnMagicOnly = IIf(managementObject2("EnableWakeOnMagicPacketOnly"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                Exit For
                            End If
                        Next

                    Catch

                    End Try

                Next
            Next

        Catch ex As Exception
            profile.IPAddress = IP
            profile = FindMAC(profile)

        End Try

        If String.IsNullOrEmpty(profile.Name) Then profile.Name = IP
        If String.IsNullOrEmpty(profile.PowerManagementEnable) Then profile.PowerManagementEnable = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.PowerManagementActive) Then profile.PowerManagementActive = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.WakeEnabled) Then profile.WakeEnabled = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.WakeOnMagicOnly) Then profile.WakeOnMagicOnly = My.Resources.Strings.lit_Unknown

        Return profile

    End Function

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
                    profile.OSName = My.Resources.Strings.lit_Unknown
                End If
            End If

        Catch ex As Exception
            profile.OSName = ex.Message
            profile.HasError = True

        End Try

        Return profile

    End Function

    Private Sub searchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBegin.Click
        Me.Cursor = Cursors.WaitCursor
        SearchBegin.Enabled = False
        cancelSearch.Enabled = True
        ToolStripProgressBar1.Visible = True
        listView.Items.Clear()
        backgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim found As Boolean

        IpAddressControl_Start.Text = "192.168.0.1"
        IpAddressControl_End.Text = "192.168.0.20"

        ComboBoxGroup.Items.Clear()
        ComboBoxGroup.Items.Add(none)
        For Each machine As Machine In Machines
            If machine.Group.Length Then
                found = False
                For Each item As String In ComboBoxGroup.Items
                    If item.ToString = machine.Group Then
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then ComboBoxGroup.Items.Add(machine.Group)
            End If
        Next
        ComboBoxGroup.Text = none

    End Sub

    Private Sub cancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelSearch.Click
        backgroundWorker.CancelAsync()
    End Sub

    Private Sub backgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker.DoWork
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
                If backgroundWorker.CancellationPending Then
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

    Private Sub backgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
        Dim i As ListViewItem
        Dim p As Profile

        If Not (e.UserState Is Nothing) Then
            p = e.UserState
#If DISPLAY Then
            p.MacAddress = p.MacAddress.Substring(0, 9) & "00:00:00"
#End If
            i = listView.Items.Add(p.Name)
            i.SubItems.Add(p.OSName)
            i.SubItems.Add(p.NetInterface)
            i.SubItems.Add(p.IPAddress)
            i.SubItems.Add(p.MacAddress)
            i.SubItems.Add(p.WakeEnabled)
        End If

        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        SearchBegin.Enabled = True
        cancelSearch.Enabled = False
        Me.Cursor = Cursors.Default
        ToolStripStatusLabel1.Text = My.Resources.Strings.Done
        ToolStripProgressBar1.Visible = False
    End Sub

    Private Sub CheckAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllButton.Click
        For Each l As ListViewItem In listView.Items
            l.Checked = True
        Next
    End Sub

    Private Sub UnCheckAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCheckAllButton.Click
        For Each l As ListViewItem In listView.Items
            l.Checked = False
        Next
    End Sub

    Private Sub ShowDetails(ByVal l As ListViewItem)
        Dim profile As Profile
        Dim s As String = ""

        If l.SubItems(0).Text = "" Then
            l.StateImageIndex = 2
            MsgBox(l.SubItems(1).Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        profile = getWMIdata(l.SubItems(3).Text)
#If DISPLAY Then
        profile.MacAddress = profile.MacAddress.Substring(0, 9) & "00:00:00"
#End If

        s = "OS: " & profile.OSName & vbCrLf
        s &= "Network adapter: " & profile.NetInterface & vbCrLf
        s &= "IP: " & profile.IPAddress & vbCrLf


        s &= "MAC: " & profile.MacAddress & vbCrLf & vbCrLf
        s &= "WakeOnLAN Enabled: " & profile.WakeEnabled & vbCrLf
        s &= "Power Management Enabled: " & profile.PowerManagementEnable & vbCrLf
        s &= "Wake by Magic Packet only: " & profile.WakeOnMagicOnly

        MsgBox(s, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, l.Text & " settings")

    End Sub

    Private Sub listView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listView.DoubleClick
        listView.Cursor = Cursors.WaitCursor
        ShowDetails(listView.SelectedItems(0))
        listView.Cursor = Cursors.Default
    End Sub

End Class
