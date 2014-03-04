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

Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Net.NetworkInformation

Public Class Properties
    Private _Name As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim m As New Machine
        Dim r As Integer

        If (Not Integer.TryParse(UDPPort.Text, r)) Then
            MessageBox.Show("UDP Port error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If (Not Integer.TryParse(TTL.Text, r)) Then
            MessageBox.Show("TTL error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Machines.Remove(_Name)

        m.Name = MachineName.Text
        m.MAC = MAC.Text
        m.IP = IP.Text

        If (rbIP.Checked) Then
            m.Method = 0
        Else
            m.Method = 1
        End If

        m.Broadcast = Broadcast.Text
        m.Netbios = Edit_NETBIOS.Text
        m.Emergency = CheckBox_Emergency.Checked
        m.ShutdownCommand = TextBox_Command.Text
        m.Group = Group.Text
        m.UDPPort = CInt(UDPPort.Text)
        m.TTL = CInt(TTL.Text)
        Dim item As ComboboxItem
        item = ComboBoxAdapters.SelectedItem
        m.Adapter = item.Value
        Machines.Add(m)

        Machines.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Create()
        _Name = ""
        Me.Text = String.Format(My.Resources.Strings.Properties, My.Resources.Strings.isNew)
        Me.Delete_Button.Visible = False
        Me.IP.Text = ""
        Me.Broadcast.Text = Net.IPAddress.Broadcast.ToString()
        Me.rbIP.Checked = True
        Me.UDPPort.Text = "9"
        Me.TTL.Text = "128"
        DisplayIPv4NetworkInterfaces("")
        Me.ShowDialog(My.Forms.Explorer)
    End Sub

    Public Sub Edit(ByVal Name As String)
        Dim m As Machine

        _Name = Name
        Me.Text = String.Format(My.Resources.Strings.Properties, Name)

        m = Machines(Name)
        MachineName.Text = m.Name
        MAC.Text = m.MAC
        IP.Text = m.IP
        Broadcast.Text = m.Broadcast
        Edit_NETBIOS.Text = m.Netbios
        CheckBox_Emergency.Checked = m.Emergency
        TextBox_Command.Text = m.ShutdownCommand
        Group.Text = m.Group
        UDPPort.Text = m.UDPPort
        TTL.Text = m.TTL
        rbIP.Checked = (m.Method = 0)
        rbURI.Checked = (m.Method = 1)
        DisplayIPv4NetworkInterfaces(m.Adapter)
        ValidateChildren()
        Me.ShowDialog(My.Forms.Explorer)
    End Sub

    Public Sub DisplayIPv4NetworkInterfaces(DefaultAdapter As String)
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim item As ComboboxItem

        ComboBoxAdapters.Items.Clear()
        item = New ComboboxItem
        item.Text = My.Resources.Strings.useDefault
        item.Value = String.Empty
        ComboBoxAdapters.Items.Add(item)
        ComboBoxAdapters.SelectedItem = item

        LabelInterfaces.Text = String.Format(My.Resources.Strings.interfaceInfo, properties.HostName, properties.DomainName)

        Dim adapter As NetworkInterface
        Dim addresses As UnicastIPAddressInformationCollection

        For Each adapter In nics
            ' Only display informatin for interfaces that support IPv4. 
            If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                Continue For
            End If

            addresses = adapter.GetIPProperties.UnicastAddresses

            For Each address As UnicastIPAddressInformation In addresses
                If address.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    item = New ComboboxItem()
                    item.Text = String.Format("{0} - {1}", address.Address.ToString, adapter.Name)
                    item.Value = address.Address.ToString
                    ComboBoxAdapters.Items.Add(item)
                    If (item.Value = DefaultAdapter) Then
                        ComboBoxAdapters.SelectedItem = item
                    End If
                End If
            Next
        Next adapter

    End Sub

    Private Sub Delete_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_Button.Click
        If MessageBox.Show(String.Format(My.Resources.Strings.AreYouSure), String.Format(My.Resources.Strings.Delete, 1), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Machines.Remove(_Name)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If

        Me.Close()
    End Sub

    Private Sub CheckValidation()
        For Each c As Control In Me.Controls
            If ErrorProvider1.GetError(c).Length Then
                OK_Button.Enabled = False
                Exit Sub
            End If
        Next
        OK_Button.Enabled = True
    End Sub

    Private Sub MachineName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MachineName.Validating
        If MachineName.IsValid() Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, My.Resources.Strings.ErrorInvalidName)
        End If
        CheckValidation()
    End Sub

    Private Sub MAC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MAC.Validating
        If MAC.IsValid() Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, My.Resources.Strings.ErrorInvalidMAC)
        End If
        CheckValidation()
    End Sub

    Private Sub IP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IP.Validating
        If IP.IsValid() Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, My.Resources.Strings.ErrorInvalidIP)
        End If
        CheckValidation()
    End Sub

    Private Sub bCalcBroadcast_Click(sender As System.Object, e As System.EventArgs) Handles bCalcBroadcast.Click
        CalcSubnet.ShowDialog(Me)
    End Sub

    Private Sub Help_Button_Click(sender As System.Object, e As System.EventArgs) Handles Help_Button.Click
        Globals.ShowHelp(Me, "properties\default.html")
    End Sub

End Class

Public Class ComboboxItem
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
        End Set
    End Property

    Private m_Text As String
    Public Property Value() As Object
        Get
            Return m_Value
        End Get
        Set(value As Object)
            m_Value = value
        End Set
    End Property

    Private m_Value As Object

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class