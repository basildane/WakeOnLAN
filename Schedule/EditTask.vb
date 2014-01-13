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

Public Class EditTask

    Private MyTask As Task
    Private Encrypt As New Encryption(My.Application.Info.ProductName)


    Public Overloads Function ShowDialog(ByVal owner As Form, ByRef Task As Task) As Windows.Forms.DialogResult
        Dim li As ListViewItem

        MyTask = Task
        NameTextBox.Text = MyTask.Name
        DescriptionTextBox.Text = MyTask.Description
        UserIDTextBox.Text = My.Settings.TaskUserID
        PasswordTextBox.Text = Encrypt.EnigmaDecrypt(My.Settings.TaskPassword)

        ListViewTriggers.Items.Clear()
        For Each Trigger As Trigger In MyTask.Triggers
            li = ListViewTriggers.Items.Add(key:=Trigger.Tag, text:=Trigger.Mode.ToString, imageIndex:=0)
            li.SubItems.Add(Trigger.ToString)
        Next

        ListViewActions.Items.Clear()
        For Each Action As Action In MyTask.Actions
            li = ListViewActions.Items.Add(key:=Action.Tag, text:=Action.ActionStrings(Action.Mode), imageIndex:=0)
            li.SubItems.Add(Action.Name)
        Next

        TabControlTasks.SelectedIndex = 0

        Return MyBase.ShowDialog(owner)
    End Function

    Private Sub CancelClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OKClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (String.IsNullOrEmpty(UserIDTextBox.Text) Or String.IsNullOrEmpty(PasswordTextBox.Text)) Then
            MessageBox.Show("You must set a proper UserID and Password for a scheduled task.", "Create / Edit task", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            TabControlTasks.SelectedIndex = 0
            Return
        End If

        With MyTask
            .Name = NameTextBox.Text
            .Description = DescriptionTextBox.Text
        End With

        My.Settings.TaskUserID = UserIDTextBox.Text
        My.Settings.TaskPassword = Encrypt.EnigmaEncrypt(PasswordTextBox.Text)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ActionNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionNewButton.Click
        Dim MyAction As New Action
        Dim li As ListViewItem

        MyAction.Mode = Action.ActionItems.Start
        MyAction.Tag = Guid.NewGuid.ToString
        If EditAction.ShowDialog(Me, MyAction) <> Windows.Forms.DialogResult.OK Then Exit Sub

        li = ListViewActions.Items.Add(key:=MyAction.Tag, text:=MyAction.ActionStrings(MyAction.Mode), imageIndex:=0)
        li.SubItems.Add(MyAction.Name)
        MyTask.Actions.Add(MyAction)
    End Sub

    Private Sub ActionEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionEditButton.Click, ListViewActions.DoubleClick
        Dim MyAction As Action = Nothing
        Dim li As ListViewItem

        If ListViewActions.SelectedItems.Count <> 1 Then Exit Sub
        li = ListViewActions.SelectedItems(0)

        For Each Action As Action In MyTask.Actions
            If Action.Tag = li.Name Then
                MyAction = Action
                Exit For
            End If
        Next

        If MyAction Is Nothing Then Exit Sub

        If EditAction.ShowDialog(Me, MyAction) <> Windows.Forms.DialogResult.OK Then Exit Sub
        li.SubItems(0).Text = MyAction.ActionStrings(MyAction.Mode)
        li.SubItems(1).Text = MyAction.Name
    End Sub

    Private Sub ActionDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionDeleteButton.Click
        Dim li As ListViewItem

        If ListViewActions.SelectedItems.Count <> 1 Then Exit Sub
        li = ListViewActions.SelectedItems(0)

        For i As Integer = 0 To MyTask.Actions.Count - 1
            If MyTask.Actions.Item(i).Tag = li.Name Then
                MyTask.Actions.RemoveAt(i)
                li.Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub TriggerNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriggerNewButton.Click
        Dim Mytrigger As New Trigger
        Dim li As ListViewItem

        With Mytrigger
            .Mode = Trigger.TriggerModes.OneTime
            .StartBoundary = Now
            .Tag = Guid.NewGuid.ToString
        End With

        If EditTrigger.ShowDialog(Me, Mytrigger) <> Windows.Forms.DialogResult.OK Then Exit Sub

        li = ListViewTriggers.Items.Add(key:=Mytrigger.Tag, text:=Mytrigger.Mode.ToString, imageIndex:=0)
        li.SubItems.Add(Mytrigger.ToString)
        MyTask.Triggers.Add(Mytrigger)
    End Sub

    Private Sub TriggerEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriggerEditButton.Click, ListViewTriggers.DoubleClick
        Dim MyTrigger As Trigger = Nothing
        Dim li As ListViewItem

        If ListViewTriggers.SelectedItems.Count <> 1 Then Exit Sub
        li = ListViewTriggers.SelectedItems(0)

        For Each Trigger As Trigger In MyTask.Triggers
            If Trigger.Tag = li.Name Then
                MyTrigger = Trigger
                Exit For
            End If
        Next

        If MyTrigger Is Nothing Then Exit Sub

        If EditTrigger.ShowDialog(Me, MyTrigger) <> Windows.Forms.DialogResult.OK Then Exit Sub
        li.SubItems(0).Text = MyTrigger.Mode.ToString
        li.SubItems(1).Text = MyTrigger.ToString
    End Sub

    Private Sub TriggerDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriggerDeleteButton.Click
        Dim li As ListViewItem

        If ListViewTriggers.SelectedItems.Count <> 1 Then Exit Sub
        li = ListViewTriggers.SelectedItems(0)

        For i As Integer = 0 To MyTask.Triggers.Count - 1
            If MyTask.Triggers.Item(i).Tag = li.Name Then
                MyTask.Triggers.RemoveAt(i)
                li.Remove()
                Exit For
            End If
        Next
    End Sub

End Class