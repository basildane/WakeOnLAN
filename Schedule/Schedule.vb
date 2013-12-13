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

Imports TaskScheduler
Imports System.Security.AccessControl
Imports System.Security.Principal

Public Class Schedule
    Dim sc As TaskScheduler.TaskScheduler
    Dim folder As ITaskFolder

    Private Sub Schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sc = New TaskScheduler.TaskScheduler
        sc.Connect()

        folder = sc.GetFolder("\")
        Try
            folder = folder.GetFolder("Aquila Technology")

        Catch ex As Exception
            folder = folder.CreateFolder("Aquila Technology")

        End Try

        Try
            folder = folder.GetFolder("Wake On LAN")

        Catch ex As Exception
            folder = folder.CreateFolder("Wake On LAN")

        End Try

        RefreshList()
    End Sub

    Private Sub RefreshList()
        Dim tasks As IRegisteredTaskCollection
        Dim li As ListViewItem

        Timer1.Stop()

        tasks = folder.GetTasks(_TASK_ENUM_FLAGS.TASK_ENUM_HIDDEN)

        With ListViewSchedule
            .Items.Clear()
            For Each t As IRegisteredTask In tasks
                li = .Items.Add(t.Name)
                li.ImageIndex = 0
                li.SubItems.Add("")
                li.SubItems.Add("")
                li.SubItems.Add("")
                li.SubItems.Add("")
                li.SubItems.Add("")
                li.SubItems.Add("")
            Next
        End With

        UpdateTaskDisplay()
        Timer1.Start()
    End Sub

    Private Function GetState(ByVal State As Integer) As String
        Select Case State
            Case 1
                Return My.Resources.Strings.lit_Disabled

            Case 2
                Return My.Resources.Strings.lit_Queued

            Case 3
                Return My.Resources.Strings.lit_Ready

            Case 4
                Return My.Resources.Strings.lit_Running

            Case Else
                Return My.Resources.Strings.lit_Unknown

        End Select
    End Function

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click, ToolStripButtonRun.Click
        Dim task As IRegisteredTask

        For Each li As ListViewItem In ListViewSchedule.SelectedItems
            task = folder.GetTask(li.Text)
            task.Run(vbNull)
        Next
    End Sub

    Private Sub EndToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndToolStripMenuItem.Click, ToolStripButtonStop.Click
        Dim task As IRegisteredTask

        For Each li As ListViewItem In ListViewSchedule.SelectedItems
            task = folder.GetTask(li.Text)
            task.Stop(0)
        Next
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripButtonDelete.Click
        For Each li As ListViewItem In ListViewSchedule.SelectedItems
            folder.DeleteTask(li.Text, 0)
        Next
        RefreshList()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click, ToolStripButtonCreate.Click
        Dim MyTask As New Task

        Edit(MyTask)
    End Sub

    Private Sub ListViewSchedule_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSchedule.DoubleClick, ToolStripButtonProperties.Click
        Dim itask As IRegisteredTask
        Dim myTask As New Task
        Dim li As ListViewItem

        If ListViewSchedule.SelectedItems.Count <> 1 Then Exit Sub
        li = ListViewSchedule.SelectedItems(0)

        itask = folder.GetTask(li.Text)
        myTask = myTask.Deserialize(itask.Definition.Data)
        If myTask Is Nothing Then Exit Sub
        Edit(myTask)
    End Sub

    Private Function Edit(ByVal MyTask As Task) As Boolean
        Dim Result As Boolean = False
        Dim m As Machine
        Dim Encrypt As New Encryption(My.Application.Info.ProductName)
        Dim sPath As String

        sPath = "-p """ & Machines.GetFile() & """"

        Timer1.Stop()

        If EditTask.ShowDialog(Me, MyTask) = Windows.Forms.DialogResult.OK Then
            Dim iTask As ITaskDefinition
            Dim exe As String

            exe = """" & IO.Path.Combine(My.Application.Info.DirectoryPath, "WakeOnLANc.exe") & """"

            Try
                iTask = sc.NewTask(0)
                With iTask
                    .RegistrationInfo.Author = My.User.Name
                    .RegistrationInfo.Description = MyTask.Description
                    .Settings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_STOP_EXISTING

                    For Each MyTrigger As Trigger In MyTask.Triggers
                        Select Case MyTrigger.Mode

                            Case Trigger.TriggerModes.OneTime
                                Dim iTrigger As ITimeTrigger

                                iTrigger = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME)
                                With iTrigger
                                    .Id = MyTrigger.Tag
                                    .StartBoundary = MyTrigger.StartBoundary.ToString("o")
                                    .Enabled = MyTrigger.Enabled
                                End With

                            Case Trigger.TriggerModes.Daily
                                Dim iTriggerDaily As IDailyTrigger

                                iTriggerDaily = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_DAILY)
                                With iTriggerDaily
                                    .Id = MyTrigger.Tag
                                    .StartBoundary = MyTrigger.StartBoundary.ToString("o")
                                    .DaysInterval = MyTrigger.Daily_Recurs
                                    .Enabled = MyTrigger.Enabled
                                End With

                            Case Trigger.TriggerModes.Weekly
                                Dim iTriggerWeekly As IWeeklyTrigger

                                iTriggerWeekly = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY)
                                With iTriggerWeekly
                                    .Id = MyTrigger.Tag
                                    .StartBoundary = MyTrigger.StartBoundary.ToString("o")
                                    .WeeksInterval = MyTrigger.Weekly_Recurs
                                    .DaysOfWeek = MyTrigger.Weekly_DaysOfWeek
                                    .Enabled = MyTrigger.Enabled
                                End With

                        End Select
                    Next

                    For Each MyAction As Action In MyTask.Actions
                        Select Case MyAction.Mode
                            Case WakeOnLan.Action.ActionItems.Start
                                Dim actionRun As IExecAction

                                actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                m = Machines(MyAction.Name)
                                With actionRun
                                    .Id = MyAction.Tag
                                    .Path = exe
                                    .Arguments = sPath & " -w -m " & m.Name
                                End With

                            Case WakeOnLan.Action.ActionItems.StartAll
                                Dim actionRun As IExecAction

                                actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                With actionRun
                                    .Id = MyAction.Tag
                                    .Path = exe
                                    .Arguments = sPath & " -w -all"
                                End With

                            Case Action.ActionItems.Shutdown
                                Dim actionRun As IExecAction

                                actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                m = Machines(MyAction.Name)
                                With actionRun
                                    .Id = MyAction.Tag
                                    .Path = exe
                                    .Arguments = sPath & " -s -m " & m.Name & " -t " & My.Settings.DefaultTimeout
                                    If MyAction.Force Then .Arguments &= " -f"
                                End With

                            Case Action.ActionItems.ShutdownAll
                                Dim actionRun As IExecAction

                                actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                With actionRun
                                    .Id = MyAction.Tag
                                    .Path = exe
                                    .Arguments = sPath & " -s -all" & " -t " & My.Settings.DefaultTimeout
                                    If MyAction.Force Then .Arguments &= " -f"
                                End With

                            Case WakeOnLan.Action.ActionItems.SendMessage
                                Dim actionMsg As IShowMessageAction

                                actionMsg = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_SHOW_MESSAGE)
                                With actionMsg
                                    .Id = MyAction.Tag
                                    .Title = MyAction.MessageTitle
                                    .MessageBody = MyAction.MessageText
                                End With

                            Case Action.ActionItems.SendEmail
                                Dim actionEmail As IEmailAction

                                actionEmail = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_SEND_EMAIL)
                                With actionEmail
                                    .Id = MyAction.Tag
                                    .From = MyAction.EmailFrom
                                    .To = MyAction.EmailTo
                                    .Subject = MyAction.EmailSubject
                                    .Server = MyAction.EmailServer
                                    .Body = MyAction.EmailText
                                End With

                        End Select

                    Next

                End With

                iTask.Data = MyTask.Serialize
                folder.RegisterTaskDefinition(MyTask.Name, iTask, _
                    _TASK_CREATION.TASK_CREATE_OR_UPDATE, _
                    My.Settings.TaskUserID, Encrypt.EnigmaDecrypt(My.Settings.TaskPassword), _
                    _TASK_LOGON_TYPE.TASK_LOGON_PASSWORD, "")

                Result = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Register Task Definition")
                Result = False

            End Try

            AddFileSecurity(Machines.GetFile, My.Settings.TaskUserID, FileSystemRights.Modify, AccessControlType.Allow)
        End If

        RefreshList()
        Timer1.Start()
        Return Result

    End Function

    ' Adds an ACL entry on the specified file for the specified account.
    Private Sub AddFileSecurity(ByVal fileName As String, ByVal account As String, _
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        Dim fSecurity As FileSecurity
        Dim user As WindowsIdentity
        Dim principal As WindowsPrincipal

        Try
            fSecurity = IO.File.GetAccessControl(fileName)

            user = New WindowsIdentity(account)
            principal = New WindowsPrincipal(user)

            For Each rule As AuthorizationRule In fSecurity.GetAccessRules(True, True, GetType(NTAccount))
                Dim fsAccessRule As FileSystemAccessRule = rule

                If (IsNothing(fsAccessRule)) Then
                    Continue For
                End If

                If ((fsAccessRule.FileSystemRights And FileSystemRights.Read) > 0) Then
                    Dim ntAccount As NTAccount = rule.IdentityReference

                    If (IsNothing(ntAccount)) Then
                        Continue For
                    End If

                    If (principal.IsInRole(ntAccount.Value)) Then
                        Debug.WriteLine(String.Format("user {0} has access in group {1}", principal.Identity.Name, ntAccount.Value))
                        Exit Sub
                    End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Security error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

        If MessageBox.Show(String.Format(My.Resources.Strings.lit_noRights, principal.Identity.Name), "Security warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        ' Add the FileSystemAccessRule to the security settings. 
        Dim accessRule As FileSystemAccessRule = New FileSystemAccessRule(account, rights, controlType)

        Try
            fSecurity.AddAccessRule(accessRule)
            IO.File.SetAccessControl(fileName, fSecurity)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Security warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub



    Private Sub DisableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableToolStripMenuItem.Click, ToolStripButtonDisable.Click
        Dim task As IRegisteredTask

        For Each li As ListViewItem In ListViewSchedule.SelectedItems
            task = folder.GetTask(li.Text)
            task.Enabled = False
        Next
    End Sub

    Private Sub EnableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableToolStripMenuItem.Click, ToolStripButtonEnable.Click
        Dim task As IRegisteredTask

        For Each li As ListViewItem In ListViewSchedule.SelectedItems
            task = folder.GetTask(li.Text)
            task.Enabled = True
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        UpdateTaskDisplay()
    End Sub

    Private Sub UpdateTaskDisplay()
        Dim task As IRegisteredTask

        'ListViewSchedule.SuspendLayout()

        For Each li As ListViewItem In ListViewSchedule.Items

            Try
                task = folder.GetTask(li.Text)
                li.SubItems(1).Text = IIf(task.Enabled, My.Resources.Strings.lit_Enabled, My.Resources.Strings.lit_Disabled)

                If li.SubItems(2).Text = "" Then
                    Dim MyTask As New Task
                    MyTask = MyTask.Deserialize(task.Definition.Data)
                    Select Case MyTask.Triggers.Count
                        Case 0
                            li.SubItems(2).Text = My.Resources.Strings.lit_None

                        Case 1
                            li.SubItems(2).Text = MyTask.Triggers(0).ToString

                        Case Else
                            li.SubItems(2).Text = My.Resources.Strings.lit_multipleTriggers

                    End Select

                End If

                li.SubItems(3).Text = GetState(task.State)
                li.SubItems(4).Text = IIf(task.NextRunTime.Year < 1970, My.Resources.Strings.lit_Never, task.NextRunTime.ToString)
                li.SubItems(5).Text = IIf(task.LastRunTime.Year < 1970, My.Resources.Strings.lit_Never, task.LastRunTime.ToString)

                Select Case task.LastTaskResult

                    Case "1"
                        li.SubItems(6).Text = My.Resources.Strings.lit_Invalid & " (0x1)"

                    Case "2"
                        li.SubItems(6).Text = My.Resources.Strings.lit_notFound & " (0x2)"

                    Case Else
                        li.SubItems(6).Text = String.Format("{0} (0x{1})", FormatMessage(task.LastTaskResult), task.LastTaskResult.ToString("x"))

                End Select

            Catch ex As Exception
                li.Remove()

            End Try

        Next

        'ListViewSchedule.ResumeLayout()
    End Sub

    Private Sub Schedule_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With ListViewSchedule
            .Columns(6).Width = .ClientRectangle.Width - (.Columns(0).Width + .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width) - 1
        End With
    End Sub

End Class
