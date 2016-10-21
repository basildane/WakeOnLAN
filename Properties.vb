'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2016 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

Imports Machines

Public Class Properties
    Private _previousHostName As String
    Private ReadOnly _encryption As New Encryption(My.Application.Info.ProductName)

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        Dim m As New Machine

        Try
            Machines.Remove(_previousHostName)

            m.Name = MachineName.Text
            m.MAC = MAC.Text
            m.IP = IP.Text

            If (rbIP.Checked) Then
                m.Method = 0
            Else
                m.Method = 1
            End If

            m.Broadcast = Broadcast.Text
            m.Netbios = tHostURI.Text
            m.KeepAlive = cbKeepAlive.Checked
            m.Emergency = CheckBox_Emergency.Checked
            m.ShutdownCommand = TextBox_Command.Text
            m.Group = Group.Text
            m.UDPPort = CInt(UDPPort.Text)
            m.TTL = CInt(TTL.Text)
            m.RDPPort = tRDPPort.Text
            m.Note = TextBox_Notes.Text
            m.UserID = tUserId.Text
            m.Password = _encryption.EnigmaEncrypt(tPassword.Text)
            m.Domain = tDomain.Text
            m.ShutdownMethod = ComboBoxShutdownMethod.SelectedIndex
            Machines.Add(m)

            Machines.Save()
            DialogResult = DialogResult.OK
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Resources.Strings.lit_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Public Sub Create()
        _previousHostName = String.Empty
        Text = String.Format(My.Resources.Strings.Properties, My.Resources.Strings.isNew)
        Delete_Button.Visible = False
        cbKeepAlive.Checked = False
        IP.Text = String.Empty
        Broadcast.Text = Net.IPAddress.Broadcast.ToString()
        rbIP.Checked = True
        UDPPort.Text = "9"
        TTL.Text = "128"
        tRDPPort.Text = "3389"
        ComboBoxShutdownMethod.SelectedIndex = 0
        TextBox_Notes.Text = String.Empty
        ShowDialog(My.Forms.Explorer)
    End Sub

    Public Sub Edit(ByVal hostName As String)
        Dim m As Machine

        _previousHostName = hostName
        Text = String.Format(My.Resources.Strings.Properties, hostName)

        m = Machines(hostName)
        MachineName.Text = m.Name
        MAC.Text = m.MAC
        IP.Text = m.IP
        Broadcast.Text = m.Broadcast
        tHostURI.Text = m.Netbios
        cbKeepAlive.Checked = m.KeepAlive
        CheckBox_Emergency.Checked = m.Emergency
        TextBox_Command.Text = m.ShutdownCommand
        Group.Text = m.Group
        UDPPort.Text = m.UDPPort
        TTL.Text = m.TTL
        rbIP.Checked = (m.Method = 0)
        rbURI.Checked = (m.Method = 1)
        tRDPPort.Text = m.RDPPort
        TextBox_Notes.Text = m.Note
        tUserId.Text = m.UserID
        tPassword.Text = _encryption.EnigmaDecrypt(m.Password)
        tDomain.Text = m.Domain
        ComboBoxShutdownMethod.SelectedIndex = m.ShutdownMethod

        ValidateChildren()
        ShowDialog(My.Forms.Explorer)
    End Sub

    Private Sub Delete_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Delete_Button.Click
        If MessageBox.Show(String.Format(My.Resources.Strings.AreYouSure), String.Format(My.Resources.Strings.Delete, 1), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Machines.Remove(_previousHostName)
            Machines.Save()
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.Cancel
        End If

        Close()
    End Sub

    Private Sub Controls_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MachineName.Validating, tHostURI.Validating, MAC.Validating, Broadcast.Validating, IP.Validating, UDPPort.Validating, TTL.Validating
        If sender.IsValid() Then
            ErrorProvider1.SetError(sender, String.Empty)
        Else
            ErrorProvider1.SetError(sender, sender.ErrorMessage)
        End If

        For Each tab As TabPage In TabControl1.TabPages
            For Each c As Control In tab.Controls
                If ErrorProvider1.GetError(c).Length Then
                    OK_Button.Enabled = False

                    Dim rc As Rectangle = TabControl1.GetTabRect(tab.TabIndex)
                    ErrorProvider1.SetIconPadding(TabControl1, -rc.Right)
                    ErrorProvider1.SetError(TabControl1, ErrorProvider1.GetError(c).ToString())
                    Exit Sub
                End If
            Next
        Next

        ErrorProvider1.SetError(TabControl1, String.Empty)

        If String.IsNullOrEmpty(MachineName.Text) Then Return
        If String.IsNullOrEmpty(MAC.Text) Then Return
        If String.IsNullOrEmpty(tHostURI.Text) Then Return
        If String.IsNullOrEmpty(Broadcast.Text) Then Return

        OK_Button.Enabled = True
    End Sub

    Private Sub bCalcBroadcast_Click(sender As Object, e As EventArgs) Handles bCalcBroadcast.Click
        CalcSubnet.ShowDialog(Me)
    End Sub

    Private Sub Help_Button_Click(sender As Object, e As EventArgs) Handles Help_Button.Click
        ShowHelp(Me, "properties\default.html")
    End Sub

    Private Sub MachineName_TextChanged(sender As Object, e As EventArgs) Handles MachineName.TextChanged
        Text = String.Format(My.Resources.Strings.Properties, MachineName.Text)
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