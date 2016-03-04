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

Imports System.Windows.Forms
Imports System.Linq
Imports Machines

Public Class EditAction
    Private _myAction As Action

    Public Overloads Function ShowDialog(ByVal owner As Form, ByRef Action As Action) As Windows.Forms.DialogResult
        _myAction = Action

#If Not Debug Then
        ' Hide the tab buttons in release mode
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.ItemSize = New Size(0, 1)
        TabControl1.SizeMode = TabSizeMode.Fixed
#End If

        Return ShowDialog(owner)
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK_Button.Click
        With _myAction
            Select Case .Mode
                Case Action.ActionItems.ShutdownAll, Action.ActionItems.SleepAll, Action.ActionItems.HibernateAll
                    .Force = forceAll.Checked

                Case Else
                    .Force = forceCheckBox.Checked

            End Select

            Select Case .Mode
                Case Action.ActionItems.Shutdown, Action.ActionItems.ShutdownAll, Action.ActionItems.ShutdownGroup
                    .Reboot = RebootCheckBox.Checked

                Case Else
                    .Reboot = False

            End Select

            .EmailFrom = EmailFromTextBox.Text
            .EmailTo = EmailToTextBox.Text
            .EmailSubject = EmailSubjectTextBox.Text
            .EmailServer = EmailServerTextBox.Text
            .EmailText = EmailMessageTextBox.Text

            .MessageTitle = MessageTitleTextBox.Text
            .MessageText = MessageTextBox.Text
        End With

        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub EditAction_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        ActionComboBox.Items.Clear()
        For Each method As String In _myAction.ActionStrings
            ActionComboBox.Items.Add(method)
        Next

        With _myAction
            ActionComboBox.SelectedIndex = .Mode
            Select Case .Mode
                Case Action.ActionItems.ShutdownAll, Action.ActionItems.SleepAll, Action.ActionItems.HibernateAll
                    forceAll.Checked = .Force

                Case Else
                    forceCheckBox.Checked = .Force

            End Select

            EmailFromTextBox.Text = .EmailFrom
            EmailToTextBox.Text = .EmailTo
            EmailSubjectTextBox.Text = .EmailSubject
            EmailServerTextBox.Text = .EmailServer
            EmailMessageTextBox.Text = .EmailText

            MessageTitleTextBox.Text = .MessageTitle
            MessageTextBox.Text = .MessageText
        End With
    End Sub

    Private Sub ActionComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ActionComboBox.SelectedIndexChanged
        RefreshDisplay()
    End Sub

    Private Sub RefreshDisplay()
        _myAction.Mode = ActionComboBox.SelectedIndex

        Try
            Select Case _myAction.Mode

                Case Action.ActionItems.Start
                    TabControl1.SelectTab("SelectTabPage")
                    forceCheckBox.Visible = False
                    RebootCheckBox.Visible = False
                    MachinesComboBox.Items.Clear()

                    Dim names() As String =
                        (From machine As Machine In Machines
                        Order By machine.Name
                        Select machine.Name).ToArray()

                    MachinesComboBox.Items.AddRange(names)
                    MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(_myAction.Name)
                    If String.IsNullOrEmpty(MachinesComboBox.SelectedItem) Then
                        MachinesComboBox.SelectedIndex = 0
                    End If

                Case Action.ActionItems.StartGroup
                    TabControl1.SelectTab("SelectTabPage")
                    forceCheckBox.Visible = False
                    RebootCheckBox.Visible = False
                    MachinesComboBox.Items.Clear()

                    Dim groups() As String =
                        (From machine As Machine In Machines
                            Order By machine.Group
                            Where Not String.IsNullOrEmpty(machine.Group)
                            Select machine.Group Distinct
                            ).ToArray()

                    MachinesComboBox.Items.AddRange(groups)
                    MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(_myAction.Name)
                    If String.IsNullOrEmpty(MachinesComboBox.SelectedItem) Then
                        MachinesComboBox.SelectedIndex = 0
                    End If

                Case Action.ActionItems.StartAll
                    TabControl1.SelectTab("AllTabPage")

                Case Action.ActionItems.Shutdown, Action.ActionItems.Sleep, Action.ActionItems.Hibernate
                    TabControl1.SelectTab("SelectTabPage")
                    forceCheckBox.Visible = True
                    forceCheckBox.Checked = _myAction.Force
                    RebootCheckBox.Checked = _myAction.Reboot
                    MachinesComboBox.Items.Clear()

                    If _myAction.Mode = Action.ActionItems.Shutdown Then
                        RebootCheckBox.Visible = True
                    Else
                        RebootCheckBox.Visible = False
                    End If

                    Dim names() As String =
                        (From machine As Machine In Machines
                        Order By machine.Name
                        Select machine.Name).ToArray()

                    MachinesComboBox.Items.AddRange(names)
                    MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(_myAction.Name)
                    forceCheckBox.Checked = _myAction.Force
                    If String.IsNullOrEmpty(MachinesComboBox.SelectedItem) Then
                        MachinesComboBox.SelectedIndex = 0
                    End If

                Case Action.ActionItems.ShutdownGroup
                    TabControl1.SelectTab("SelectTabPage")
                    forceCheckBox.Visible = True
                    forceCheckBox.Checked = _myAction.Force
                    RebootCheckBox.Visible = True
                    RebootCheckBox.Checked = _myAction.Reboot
                    MachinesComboBox.Items.Clear()

                    Dim groups() As String =
                        (From machine As Machine In Machines
                            Order By machine.Group
                            Where Not String.IsNullOrEmpty(machine.Group)
                            Select machine.Group Distinct
                            ).ToArray()

                    MachinesComboBox.Items.AddRange(groups)
                    MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(_myAction.Name)
                    If String.IsNullOrEmpty(MachinesComboBox.SelectedItem) Then
                        MachinesComboBox.SelectedIndex = 0
                    End If

                Case Action.ActionItems.ShutdownAll, Action.ActionItems.SleepAll, Action.ActionItems.HibernateAll
                    TabControl1.SelectTab("AllTabPage")
                    forceAll.Checked = _myAction.Force
                    If (_myAction.Mode = Action.ActionItems.ShutdownAll) Then
                        RebootAll.Visible = True
                    Else
                        RebootAll.Visible = False
                    End If
                    RebootAll.Checked = _myAction.Reboot

                Case Action.ActionItems.SendMessage
                    TabControl1.SelectTab("PopupTabPage")
                    ComboBoxPopupMachine.Items.Clear()

                    Dim names() As String =
                        (From machine As Machine In Machines
                        Order By machine.Name
                        Select machine.Name).ToArray()

                    ComboBoxPopupMachine.Items.AddRange(names)
                    ComboBoxPopupMachine.SelectedIndex = ComboBoxPopupMachine.FindStringExact(_myAction.Name)

                    MessageTitleTextBox.Text = _myAction.MessageTitle
                    MessageTextBox.Text = _myAction.MessageText

                Case Action.ActionItems.SendEmail
                    TabControl1.SelectTab("EmailTabPage")

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MachinesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles MachinesComboBox.SelectedIndexChanged
        _myAction.Name = MachinesComboBox.Items(MachinesComboBox.SelectedIndex).ToString
    End Sub

    Private Sub ComboBoxPopupMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPopupMachine.SelectedIndexChanged
        _myAction.Name = ComboBoxPopupMachine.Items(ComboBoxPopupMachine.SelectedIndex).ToString
    End Sub
End Class
