'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2019 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
Imports TaskScheduler

Namespace Schedule

    Public Class Schedule
        Dim _scheduler As TaskScheduler.TaskScheduler
        Dim _taskFolder As ITaskFolder

        Private Sub Schedule_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            If (My.Settings.schedulerWindowLocation.X > 0 And My.Settings.schedulerWindowLocation.Y > 0 And My.Settings.schedulerWindowLocation.X < My.Computer.Screen.WorkingArea.Right And My.Settings.schedulerWindowLocation.Y < My.Computer.Screen.WorkingArea.Height) Then
                Location = My.Settings.schedulerWindowLocation
                Size = My.Settings.schedulerWindowSize
            End If

            GetListViewState(ListViewSchedule, My.Settings.schedulerColumns)

            _scheduler = New TaskScheduler.TaskScheduler
            _scheduler.Connect()

            _taskFolder = _scheduler.GetFolder("\")
            Try
                _taskFolder = _taskFolder.GetFolder("Aquila Technology")

            Catch ex As Exception
                _taskFolder = _taskFolder.CreateFolder("Aquila Technology")

            End Try

            Try
                _taskFolder = _taskFolder.GetFolder("Wake On LAN")

            Catch ex As Exception
                _taskFolder = _taskFolder.CreateFolder("Wake On LAN")

            End Try

            RefreshList()

        End Sub

        Private Sub Schedule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If WindowState = FormWindowState.Normal Then
                My.Settings.schedulerColumns = SaveListViewState(ListViewSchedule)
                My.Settings.schedulerWindowLocation = Location
                My.Settings.schedulerWindowSize = Size
            End If
        End Sub

        Private Sub RefreshList()
            Dim tasks As IRegisteredTaskCollection
            Dim li As ListViewItem

            timer.Stop()
            tasks = _taskFolder.GetTasks(_TASK_ENUM_FLAGS.TASK_ENUM_HIDDEN)
            ListViewSchedule.SuspendLayout()
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
            ListViewSchedule.ResumeLayout()
            timer.Start()
        End Sub

        Private Function GetState(ByVal state As Integer) As String
            Select Case state
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

        Private Sub RunToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RunToolStripMenuItem.Click, ToolStripButtonRun.Click
            Dim task As IRegisteredTask

            For Each li As ListViewItem In ListViewSchedule.SelectedItems
                task = _taskFolder.GetTask(li.Text)
                task.Run(vbNull)
            Next
        End Sub

        Private Sub EndToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EndToolStripMenuItem.Click, ToolStripButtonStop.Click
            Dim task As IRegisteredTask

            For Each li As ListViewItem In ListViewSchedule.SelectedItems
                task = _taskFolder.GetTask(li.Text)
                task.Stop(0)
            Next
        End Sub

        Private Sub DeleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripButtonDelete.Click
            For Each li As ListViewItem In ListViewSchedule.SelectedItems
                _taskFolder.DeleteTask(li.Text, 0)
            Next
            RefreshList()
        End Sub

        Private Sub NewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, ToolStripButtonCreate.Click
            Dim myTask As New Task

            Edit(myTask)
        End Sub

        Private Sub ListViewSchedule_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewSchedule.DoubleClick, ToolStripButtonProperties.Click
            Dim itask As IRegisteredTask
            Dim myTask As New Task
            Dim li As ListViewItem

            If ListViewSchedule.SelectedItems.Count <> 1 Then Exit Sub
            li = ListViewSchedule.SelectedItems(0)

            itask = _taskFolder.GetTask(li.Text)
            myTask = myTask.Deserialize(itask.Definition.Data)
            If myTask Is Nothing Then Exit Sub
            Edit(myTask)
        End Sub

        Private Function Edit(ByVal myTask As Task) As Boolean
            Dim result As Boolean = False
            Dim m As Machine
            Dim encrypt As New Encryption()
            Dim machinesXml As String

            machinesXml = "-p " & wrapSpaces(Machines.GetFile())

            timer.Stop()

            If EditTask.ShowDialog(Me, myTask) = DialogResult.OK Then
                Dim iTask As ITaskDefinition
                Dim executable As String

#If DEBUG Then
                executable = wrapSpaces("C:\Projects\WakeOnLan\Console\WakeOnLanC\bin\Debug\WakeOnLANc.exe")
#Else
                executable = wrapSpaces(IO.Path.Combine(My.Application.Info.DirectoryPath, "WakeOnLANc.exe"))
#End If

                Try
                    iTask = _scheduler.NewTask(0)
                    With iTask
                        .RegistrationInfo.Author = My.User.Name
                        .RegistrationInfo.Description = myTask.Description
                        .Settings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_STOP_EXISTING

                        For Each myTrigger As Trigger In myTask.Triggers
                            Select Case myTrigger.Mode

                                Case Trigger.TriggerModes.OneTime
                                    Dim iTrigger As ITimeTrigger

                                    iTrigger = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME)
                                    With iTrigger
                                        .Id = myTrigger.Tag
                                        .StartBoundary = myTrigger.StartBoundary.ToString("o")
                                        .Enabled = myTrigger.Enabled
                                    End With

                                Case Trigger.TriggerModes.Daily
                                    Dim iTriggerDaily As IDailyTrigger

                                    iTriggerDaily = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_DAILY)
                                    With iTriggerDaily
                                        .Id = myTrigger.Tag
                                        .StartBoundary = myTrigger.StartBoundary.ToString("o")
                                        .DaysInterval = myTrigger.DailyRecurs
                                        .Enabled = myTrigger.Enabled
                                    End With

                                Case Trigger.TriggerModes.Weekly
                                    Dim iTriggerWeekly As IWeeklyTrigger

                                    iTriggerWeekly = .Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY)
                                    With iTriggerWeekly
                                        .Id = myTrigger.Tag
                                        .StartBoundary = myTrigger.StartBoundary.ToString("o")
                                        .WeeksInterval = myTrigger.WeeklyRecurs
                                        .DaysOfWeek = myTrigger.WeeklyDaysOfWeek
                                        .Enabled = myTrigger.Enabled
                                    End With

                            End Select
                        Next

                        For Each myAction As Action In myTask.Actions
                            Select Case myAction.Mode
                                Case Action.ActionItems.Start
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    m = Machines(myAction.Name)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -w -m " & wrapSpaces(m.Name)
                                    End With

                                Case Action.ActionItems.StartGroup
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -w -g " & wrapSpaces(myAction.Name)
                                    End With

                                Case Action.ActionItems.StartAll
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -w -all"
                                    End With

                                Case Action.ActionItems.Shutdown
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    m = Machines(myAction.Name)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s -m " & wrapSpaces(m.Name) & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                        If myAction.Reboot Then .Arguments &= " -r"
                                    End With

                                Case Action.ActionItems.Sleep
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    m = Machines(myAction.Name)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s1 -m " & wrapSpaces(m.Name) & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                    End With

                                Case Action.ActionItems.Hibernate
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    m = Machines(myAction.Name)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s4 -m " & wrapSpaces(m.Name) & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                    End With

                                Case Action.ActionItems.ShutdownGroup
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s -g " & wrapSpaces(myAction.Name) & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                        If myAction.Reboot Then .Arguments &= " -r"
                                    End With

                                Case Action.ActionItems.ShutdownAll
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s -all" & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                        If myAction.Reboot Then .Arguments &= " -r"
                                    End With

                                Case Action.ActionItems.SleepAll
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s1 -all" & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                    End With

                                Case Action.ActionItems.HibernateAll
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -s4 -all" & " -t " & My.Settings.DefaultTimeout
                                        If myAction.Force Then .Arguments &= " -f"
                                    End With

                                Case Action.ActionItems.SendMessage
                                    Dim actionRun As IExecAction

                                    actionRun = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                                    m = Machines(myAction.Name)

                                    If m Is Nothing Then
                                        MessageBox.Show("Unable to locate host " + myAction.Name, "Task Scheduler")
                                        Continue For
                                    End If
                                    With actionRun
                                        .Id = myAction.Tag
                                        .Path = executable
                                        .Arguments = machinesXml & " -m " & wrapSpaces(m.Name) & " -msg -c " & wrapSpaces(myAction.MessageText)
                                    End With

                                Case Action.ActionItems.SendEmail
                                    Dim actionEmail As IEmailAction

                                    actionEmail = .Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_SEND_EMAIL)
                                    With actionEmail
                                        .Id = myAction.Tag
                                        .From = myAction.EmailFrom
                                        .To = myAction.EmailTo
                                        .Subject = myAction.EmailSubject
                                        .Server = myAction.EmailServer
                                        .Body = myAction.EmailText
                                    End With

                            End Select

                        Next

                    End With

                    iTask.Data = myTask.Serialize
                    _taskFolder.RegisterTaskDefinition(myTask.Name, iTask,
                                                       _TASK_CREATION.TASK_CREATE_OR_UPDATE,
                                                       My.Settings.TaskUserID, encrypt.Decrypt(My.Settings.TaskPassword),
                                                       _TASK_LOGON_TYPE.TASK_LOGON_PASSWORD, "")

                    result = True

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Register Task Definition")
                    result = False

                End Try

                'AddFileSecurity(Machines.GetFile, My.Settings.TaskUserID, FileSystemRights.Modify, AccessControlType.Allow)
            End If

            RefreshList()
            timer.Start()
            Return result

        End Function

        Private Function wrapSpaces(s As String) As String
            If s.Contains(" ") Then
                Return """" & s & """"
            Else
                Return s
            End If
        End Function

#If False Then
    ' Adds an ACL entry on the specified file for the specified account.
    ' TODO: this only works with domain accounts
    '
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
#End If

        Private Sub DisableToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DisableToolStripMenuItem.Click, ToolStripButtonDisable.Click
            Dim task As IRegisteredTask

            For Each li As ListViewItem In ListViewSchedule.SelectedItems
                task = _taskFolder.GetTask(li.Text)
                task.Enabled = False
            Next
        End Sub

        Private Sub EnableToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnableToolStripMenuItem.Click, ToolStripButtonEnable.Click
            Dim task As IRegisteredTask

            For Each li As ListViewItem In ListViewSchedule.SelectedItems
                task = _taskFolder.GetTask(li.Text)
                task.Enabled = True
            Next
        End Sub

        Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer.Tick
            UpdateTaskDisplay()
        End Sub

        Private Sub UpdateTaskDisplay()
            Dim task As IRegisteredTask

            ListViewSchedule.SuspendLayout()

            For Each li As ListViewItem In ListViewSchedule.Items

                Try
                    task = _taskFolder.GetTask(li.Text)
                    li.SubItems(1).Text = IIf(task.Enabled, My.Resources.Strings.lit_Enabled, My.Resources.Strings.lit_Disabled)

                    If li.SubItems(2).Text = "" Then
                        Dim myTask As New Task
                        myTask = myTask.Deserialize(task.Definition.Data)
                        Select Case myTask.Triggers.Count
                            Case 0
                                li.SubItems(2).Text = My.Resources.Strings.lit_None

                            Case 1
                                li.SubItems(2).Text = myTask.Triggers(0).ModeString

                            Case Else
                                li.SubItems(2).Text = My.Resources.Strings.lit_multipleTriggers

                        End Select

                    End If

                    li.SubItems(3).Text = GetState(task.State)
                    li.SubItems(4).Text = IIf(task.NextRunTime.Year < 1970, My.Resources.Strings.lit_Never, task.NextRunTime.ToString("G"))
                    li.SubItems(5).Text = IIf(task.LastRunTime.Year < 1970, My.Resources.Strings.lit_Never, task.LastRunTime.ToString("G"))

                    Select Case task.LastTaskResult

                        Case "1"
                            li.SubItems(6).Text = IIf(task.LastRunTime.Year < 1970, String.Empty, My.Resources.Strings.lit_Invalid & " (0x1)")

                        Case "2"
                            li.SubItems(6).Text = My.Resources.Strings.lit_notFound & " (0x2)"

                        Case Else
                            li.SubItems(6).Text = String.Format("{0} (0x{1})", FormatMessage(task.LastTaskResult), task.LastTaskResult.ToString("x"))

                    End Select

                Catch ex As Exception
                    li.Remove()

                End Try

            Next

            ListViewSchedule.ResumeLayout()
        End Sub

        Private Sub Schedule_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
            With ListViewSchedule
                .Columns(6).Width = .ClientRectangle.Width - (.Columns(0).Width + .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width) - 1
            End With
        End Sub

    End Class

    Public Class ffListView
        Inherits ListView

        Public Sub New()
            DoubleBuffered = True
        End Sub

    End Class
End Namespace