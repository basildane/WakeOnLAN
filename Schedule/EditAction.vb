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

Imports System.Windows.Forms

Public Class EditAction
    Private MyAction As Action

    Public Overloads Function ShowDialog(ByVal owner As Form, ByRef Action As Action) As Windows.Forms.DialogResult
        MyAction = Action

        Return MyBase.ShowDialog(owner)
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        With MyAction
            If .Mode = Action.ActionItems.ShutdownAll Then
                .Force = forceAll.Checked
            Else
                .Force = forceCheckBox.Checked
            End If

            .EmailFrom = EmailFromTextBox.Text
            .EmailTo = EmailToTextBox.Text
            .EmailSubject = EmailSubjectTextBox.Text
            .EmailServer = EmailServerTextBox.Text
            .EmailText = EmailMessageTextBox.Text

            .MessageTitle = MessageTitleTextBox.Text
            .MessageText = MessageTextBox.Text
        End With

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EditAction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActionComboBox.Items.Clear()
        For Each method As String In MyAction.ActionStrings
            ActionComboBox.Items.Add(method)
        Next

        With MyAction
            ActionComboBox.SelectedIndex = .Mode
            If .Mode = Action.ActionItems.ShutdownAll Then
                forceAll.Checked = .Force
            Else
                forceCheckBox.Checked = .Force
            End If

            EmailFromTextBox.Text = .EmailFrom
            EmailToTextBox.Text = .EmailTo
            EmailSubjectTextBox.Text = .EmailSubject
            EmailServerTextBox.Text = .EmailServer
            EmailMessageTextBox.Text = .EmailText

            MessageTitleTextBox.Text = .MessageTitle
            MessageTextBox.Text = .MessageText
        End With
    End Sub

    Private Sub ActionComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionComboBox.SelectedIndexChanged
        RefreshDisplay()
    End Sub

    Private Sub RefreshDisplay()
        MyAction.Mode = ActionComboBox.SelectedIndex

        Select Case MyAction.Mode

            Case Action.ActionItems.Start
                forceCheckBox.Visible = False
                ComputerGroupBox.Show()
                MachinesComboBox.Items.Clear()
                For Each m As Machine In Machines
                    MachinesComboBox.Items.Add(m.Name)
                Next
                MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(MyAction.Name)
                AllGroupBox.Hide()
                MessageGroupBox.Hide()
                EmailGroupBox.Hide()

            Case Action.ActionItems.StartAll
                AllGroupBox.Hide()
                ComputerGroupBox.Hide()
                MessageGroupBox.Hide()
                EmailGroupBox.Hide()

            Case Action.ActionItems.Shutdown
                forceCheckBox.Visible = True
                forceCheckBox.Checked = MyAction.Force
                ComputerGroupBox.Show()
                MachinesComboBox.Items.Clear()
                For Each m As Machine In Machines
                    MachinesComboBox.Items.Add(m.Name)
                Next
                MachinesComboBox.SelectedIndex = MachinesComboBox.FindStringExact(MyAction.Name)
                forceCheckBox.Checked = MyAction.Force
                AllGroupBox.Hide()
                MessageGroupBox.Hide()
                EmailGroupBox.Hide()

            Case Action.ActionItems.ShutdownAll
                forceAll.Checked = MyAction.Force
                ComputerGroupBox.Hide()
                MessageGroupBox.Hide()
                EmailGroupBox.Hide()
                AllGroupBox.Show()

            Case Action.ActionItems.SendMessage
                ComputerGroupBox.Hide()

                MessageTitleTextBox.Text = MyAction.MessageTitle
                MessageTextBox.Text = MyAction.MessageText
                MessageGroupBox.Show()
                AllGroupBox.Hide()
                EmailGroupBox.Hide()

            Case Action.ActionItems.SendEmail
                EmailGroupBox.Show()
                AllGroupBox.Hide()
                ComputerGroupBox.Hide()
                MessageGroupBox.Hide()

        End Select

    End Sub

    Private Sub MachinesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachinesComboBox.SelectedIndexChanged
        MyAction.Name = MachinesComboBox.Items(MachinesComboBox.SelectedIndex).ToString
    End Sub
End Class
