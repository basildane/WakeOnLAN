'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2015 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

Public Class EditTrigger

    Dim _trigger As Trigger

    Public Overloads Function ShowDialog(ByVal owner As Form, ByRef trigger As Trigger) As Windows.Forms.DialogResult
        _trigger = trigger

        Return MyBase.ShowDialog(owner)
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK_Button.Click
        With _trigger
            Dim i As Integer

            .StartBoundary = FormatDateTime(DateTimePickerDate.Value, DateFormat.ShortDate) & " " & FormatDateTime(DateTimePickerTime.Value, DateFormat.ShortTime)
            .Enabled = CheckBoxEnabled.Checked

            Select Case _trigger.Mode
                Case Trigger.TriggerModes.OneTime

                Case Trigger.TriggerModes.Daily
                    Int32.TryParse(TextBoxRecurDays.Text, i)
                    If i < 1 Then
                        MessageBox.Show(My.Resources.Strings.errGreaterThan1, My.Resources.Strings.lit_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                Case Trigger.TriggerModes.Weekly
                    Int32.TryParse(TextBoxWeeklyRecurs.Text, i)
                    If i < 1 Or i > 52 Then
                        MessageBox.Show(My.Resources.Strings.errWeeks, My.Resources.Strings.lit_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                Case Trigger.TriggerModes.Monthly
                    'TODO:

            End Select

            .DailyRecurs = TextBoxRecurDays.Text
            .WeeklyRecurs = TextBoxWeeklyRecurs.Text

            .WeeklyDaysOfWeek = 0
            For i = 1 To 7
                Dim c As CheckBox

                c = GroupBoxWeekly.Controls("CheckBox" & i)
                If c.Checked Then
                    .WeeklyDaysOfWeek += CInt(2 ^ (i - 1))
                End If

            Next

        End With

        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub EditTrigger_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Select Case _trigger.Mode
            Case Trigger.TriggerModes.OneTime
                RadioButtonOneTime.Checked = True

            Case Trigger.TriggerModes.Daily
                RadioButtonDaily.Checked = True

            Case Trigger.TriggerModes.Weekly
                RadioButtonWeekly.Checked = True

            Case Trigger.TriggerModes.Monthly
                RadioButtonMontly.Checked = True

        End Select

        DateTimePickerDate.Value = _trigger.StartBoundary
        DateTimePickerTime.Value = _trigger.StartBoundary
        TextBoxRecurDays.Text = _trigger.DailyRecurs
        TextBoxWeeklyRecurs.Text = _trigger.WeeklyRecurs

        For i As Integer = 1 To 7
            Dim c As CheckBox

            c = GroupBoxWeekly.Controls("CheckBox" & i)
            c.Text = WeekdayName(i, False, FirstDayOfWeek.Sunday)
            c.Checked = (_trigger.WeeklyDaysOfWeek And CInt(2 ^ (i - 1))) > 0
        Next

        CheckBoxEnabled.Checked = _trigger.Enabled
    End Sub

    Private Sub RadioButtonOneTime_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButtonOneTime.CheckedChanged
        _trigger.Mode = Trigger.TriggerModes.OneTime
        GroupBoxDaily.Hide()
        GroupBoxWeekly.Hide()
    End Sub

    Private Sub RadioButtonDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButtonDaily.CheckedChanged
        _trigger.Mode = Trigger.TriggerModes.Daily
        GroupBoxDaily.Show()
        GroupBoxWeekly.Hide()
    End Sub

    Private Sub RadioButtonWeekly_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButtonWeekly.CheckedChanged
        _trigger.Mode = Trigger.TriggerModes.Weekly
        GroupBoxDaily.Hide()
        GroupBoxWeekly.Show()
    End Sub

End Class
