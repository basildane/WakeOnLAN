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

Imports System.Net
Imports System.Windows.Forms
Imports System.Management
Imports System.Linq

Public Class Search

    Declare Function SendARP Lib "iphlpapi.dll" (ByVal DestIP As Int32, ByVal SrcIP As Int32, ByVal pMacAddr As Byte(), ByRef PhyAddrLen As Integer) As Integer

    Private Structure Profile
        Public Name As String
        Public IpAddress As String
        Public OsName As String
        Public NetInterface As String
        Public MacAddress As String
        Public WakeEnabled As String
        Public PowerManagementEnable As String
        Public PowerManagementActive As String
        Public WakeOnMagicOnly As String
    End Structure

    Private ReadOnly _none As String = "--" & My.Resources.Strings.lit_None & "--"

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OKButton.Click
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
            If (ComboBoxGroup.Text <> _none) Then
                m.Group = ComboBoxGroup.Text
            End If

            Machines.Add(m)
        Next

        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles closeButton.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Poll(ByVal ip As String, ByVal progress As Integer)
        Dim profile As Profile

        Try
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Polling, ip)

            If Not My.Computer.Network.Ping(ip) Then
                backgroundWorker.ReportProgress(progress, Nothing)
                Exit Sub
            End If

            profile = GetWmIdata(ip)
            backgroundWorker.ReportProgress(progress, profile)

        Catch ex As Exception
            backgroundWorker.ReportProgress(progress, Nothing)

        End Try

    End Sub

    Private Function GetWmIdata(ip As String) As Profile
        Dim scopeCimv2, scopeWmi As ManagementScope
        Dim managementObject As ManagementObject
        Dim searcher As ManagementObjectSearcher
        Dim queryCollection As ManagementObjectCollection
        Dim wmiQuery As ObjectQuery
        Dim profile As New Profile

        Try
            scopeCimv2 = New ManagementScope("\\" & ip & "\root\cimv2")
            scopeCimv2.Connect()
            scopeWmi = New ManagementScope("\\" & ip & "\root\WMI")
            scopeWmi.Connect()

            ' Query system for Operating System information
            wmiQuery = New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
            searcher = New ManagementObjectSearcher(scopeCimv2, wmiQuery)
            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                profile.Name = managementObject("csname")
                profile.OsName = managementObject("Caption")
                Exit For
            Next

            wmiQuery = New ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=True")
            searcher = New ManagementObjectSearcher(scopeCimv2, wmiQuery)

            queryCollection = searcher.Get()

            For Each managementObject In queryCollection
                For Each s As String In managementObject("IPaddress")
                    profile.IpAddress = s
                    Exit For
                Next

                wmiQuery = New ObjectQuery("SELECT * FROM Win32_NetWorkAdapter WHERE AdapterTypeId=0 AND Index='" & managementObject("Index") & "'")
                searcher = New ManagementObjectSearcher(scopeCimv2, wmiQuery)

                For Each managementObjectAdapter As ManagementObject In searcher.Get()
                    profile.NetInterface = managementObjectAdapter("Description")
                    profile.MacAddress = managementObjectAdapter("MACAddress")

                    Try
                        wmiQuery = New ObjectQuery("SELECT * FROM MSPower_DeviceEnable")
                        searcher2 = New ManagementObjectSearcher(scopeWmi, wmiQuery)
                        For Each managementObject2 As ManagementObject In searcher2.Get()
                            If (managementObject2("InstanceName").ToString().ToUpper.StartsWith(managementObjectAdapter("PNPDeviceID"))) Then
                                profile.PowerManagementEnable = IIf(managementObject2("Enable"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                profile.PowerManagementActive = IIf(managementObject2("Active"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                Exit For
                            End If
                        Next

                        wmiQuery = New ObjectQuery("SELECT * FROM MSPower_DeviceWakeEnable")
                        searcher2 = New ManagementObjectSearcher(scopeWmi, wmiQuery)
                        For Each managementObject2 As ManagementObject In searcher2.Get()
                            If (managementObject2("InstanceName").ToString().ToUpper.StartsWith(managementObjectAdapter("PNPDeviceID"))) Then
                                profile.WakeEnabled = IIf(managementObject2("Enable"), My.Resources.Strings.lit_true, My.Resources.Strings.lit_false)
                                Exit For
                            End If
                        Next

                        wmiQuery = New ObjectQuery("SELECT * FROM MSNdis_DeviceWakeOnMagicPacketOnly")
                        searcher2 = New ManagementObjectSearcher(scopeWmi, wmiQuery)
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
            profile.IpAddress = ip
            profile = FindMAC(profile)

        End Try

        If String.IsNullOrEmpty(profile.Name) Then profile.Name = ip
        If String.IsNullOrEmpty(profile.PowerManagementEnable) Then profile.PowerManagementEnable = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.PowerManagementActive) Then profile.PowerManagementActive = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.WakeEnabled) Then profile.WakeEnabled = My.Resources.Strings.lit_Unknown
        If String.IsNullOrEmpty(profile.WakeOnMagicOnly) Then profile.WakeOnMagicOnly = My.Resources.Strings.lit_Unknown

        Return profile

    End Function

    Private Function FindMAC(profile As Profile) As Profile
        Dim address As IPAddress
        Dim remoteIp As Int32
        Dim mac() As Byte = New Byte(6) {}
        Dim len As Integer = 6
        Dim hostEntry As IPHostEntry

        Try
            address = IPAddress.Parse(profile.IpAddress)
            remoteIp = address.GetHashCode()

            If remoteIp <> 0 Then
                If SendArp(remoteIp, 0, mac, len) = 0 Then
                    profile.MacAddress = BitConverter.ToString(mac, 0, len)
                    hostEntry = Dns.GetHostEntry(address)
                    profile.Name = hostEntry.HostName
                    profile.OsName = My.Resources.Strings.lit_Unknown
                End If
            End If

        Catch ex As Exception
            profile.OsName = ex.Message

        End Try

        Return profile

    End Function

    Private Sub searchButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBegin.Click
        Cursor = Cursors.WaitCursor
        SearchBegin.Enabled = False
        cancelSearch.Enabled = True
        ToolStripProgressBar1.Visible = True
        listView.Items.Clear()
        backgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim found As Boolean

        IpAddressControl_Start.Text = "192.168.0.1"
        IpAddressControl_End.Text = "192.168.0.20"

        ComboBoxGroup.Items.Clear()
        ComboBoxGroup.Items.Add(_none)
        For Each machine As Machine In From _machine As Machine In Machines Where _machine.Group.Length
            found = ComboBoxGroup.Items.Cast(Of String)().Any(Function(item) item.ToString = machine.Group)
            If Not found Then ComboBoxGroup.Items.Add(machine.Group)
        Next
        ComboBoxGroup.Text = _none

    End Sub

    Private Sub cancelSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cancelSearch.Click
        backgroundWorker.CancelAsync()
    End Sub

    Private Sub backgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker.DoWork
        Dim i, startIp, stopIp As UInt32
        Dim ip As String
        Dim progress As Integer

        Try
            startIp = IPToInt(IPAddress.Parse(IpAddressControl_Start.Text))
            stopIp = IPToInt(IPAddress.Parse(IpAddressControl_End.Text))

            For i = startIp To stopIp
                ip = IPAddress.Parse(i).ToString()
                If (ip.EndsWith(".255")) Then
                    Continue For
                End If
                progress = (i - startIp) * 100 / Math.Max(1, stopIp - startIp)
                Poll(ip, progress)
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
            i.SubItems.Add(p.OsName)
            i.SubItems.Add(p.NetInterface)
            i.SubItems.Add(p.IpAddress)
            i.SubItems.Add(p.MacAddress)
            i.SubItems.Add(p.WakeEnabled)
        End If

        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        SearchBegin.Enabled = True
        cancelSearch.Enabled = False
        Cursor = Cursors.Default
        ToolStripStatusLabel1.Text = My.Resources.Strings.Done
        ToolStripProgressBar1.Visible = False
    End Sub

    Private Sub CheckAllButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CheckAllButton.Click
        For Each l As ListViewItem In listView.Items
            l.Checked = True
        Next
    End Sub

    Private Sub UnCheckAllButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles UnCheckAllButton.Click
        For Each l As ListViewItem In listView.Items
            l.Checked = False
        Next
    End Sub

    Private Sub ShowDetails(ByVal l As ListViewItem)
        Dim profile As Profile
        Dim s As String

        If l.SubItems(0).Text = "" Then
            l.StateImageIndex = 2
            MsgBox(l.SubItems(1).Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        profile = GetWmIdata(l.SubItems(3).Text)
#If DISPLAY Then
        profile.MacAddress = profile.MacAddress.Substring(0, 9) & "00:00:00"
#End If

        s = "OS: " & profile.OsName & vbCrLf
        s &= "Network adapter: " & profile.NetInterface & vbCrLf
        s &= "IP: " & profile.IpAddress & vbCrLf
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
