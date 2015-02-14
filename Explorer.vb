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

Imports System.Diagnostics
Imports System.Windows.Forms
Imports AlphaWindow
Imports AutoUpdaterDotNET
Imports System.Globalization
Imports System.Linq
Imports System.ComponentModel

Public Class Explorer
    Private ReadOnly _lvwColumnSorter As New ListViewColumnSorter()
    Dim WithEvents _historyBackgroundworker As New BackgroundWorker()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub Explorer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim auto As New Autorun()

        AutoStartWithWindowsToolStripMenuItem.Checked = auto.AutoRun()

        ListView.View = My.Settings.ListView_View
        GetListViewState(ListView, My.Settings.ListView_Columns)

        ShowGroupsToolStripMenuItem.Checked = My.Settings.ShowGroups
        SetMinimizeToTray()

        If Not My.Settings.ShowHotButtons Then ChangeHotButtonsPanel()
        If Not My.Settings.ShowFolders Then ToggleFoldersVisible()

        ListView.ShowGroups = My.Settings.ShowGroups
        PingToolStripButton.Checked = My.Settings.Pinger

        ' Scheduling functions are only available in Vista and 2008 and higher
        '
        ScheduleToolStripMenuItem.Enabled = (Environment.OSVersion.Version.Major >= 6)
        ScheduleToolStripButton.Enabled = ScheduleToolStripMenuItem.Enabled

        CultureManager_UICultureChanged(Application.CurrentCulture)

        SetView(ListView.View)
        Machines.Load()

        Machines.dirty = False
        LoadTree()
        Location = My.Settings.MainWindow_Location
        Size = My.Settings.MainWindow_Size
        MenuStrip.Location = New Point(0, 0)

        Try
            If (My.Application.CommandLineArgs(0) = "/min") Then
                Hide()
            Else
                Show()
            End If

        Catch ex As Exception

        End Try

        CheckUpdates()
    End Sub

    Private Sub CheckUpdates()
        AutoUpdater.CurrentCulture = Application.CurrentCulture
        AutoUpdater.AppCastURL = My.Settings.updateURL
        AutoUpdater.versionURL = My.Settings.updateVersions
        AddHandler AutoUpdater.UpdateStatus, AddressOf UpdateStatus
        AutoUpdater.Start(My.Settings.updateIntervalDays)
    End Sub

    Private Delegate Sub UpdateStatusHandler(sender As Object, e As AutoUpdateEventArgs)

    Private Sub UpdateStatus(sender As Object, e As AutoUpdateEventArgs)
        If (InvokeRequired) Then
            BeginInvoke(New UpdateStatusHandler(AddressOf UpdateStatus), New Object() {sender, e})
            Return
        End If

        ToolStripStatusLabel2.Text = e.Text
        If (e.Status = AutoUpdateEventArgs.StatusCodes.updateAvailable) Then
            NotifyIconUpdate.Visible = True
            NotifyIconUpdate.ShowBalloonTip(0, My.Resources.Strings.Title, e.Text, ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NotifyIconUpdate_BalloonTipClicked(sender As System.Object, e As EventArgs) Handles NotifyIconUpdate.BalloonTipClicked, NotifyIconUpdate.Click
        NotifyIconUpdate.Visible = False
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub SetMinimizeToTray()
        MinimizeToTaskTrayToolStripMenuItem.Checked = My.Settings.MinimizeToTray
        ShowInTaskbar = Not My.Settings.MinimizeToTray
        NotifyIcon1.Visible = My.Settings.MinimizeToTray
    End Sub

    Private Sub Explorer_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.ListView_View = ListView.View
        My.Settings.ListView_Columns = SaveListViewState(ListView)

        If WindowState = FormWindowState.Normal Then
            My.Settings.MainWindow_Location = Location
            My.Settings.MainWindow_Size = Size
        End If

        My.Settings.ShowGroups = ShowGroupsToolStripMenuItem.Checked
        My.Settings.ShowHotButtons = ShowHotButtonsToolStripMenuItem.Checked
        My.Settings.ShowFolders = FoldersToolStripMenuItem.Checked
        My.Settings.Pinger = PingToolStripButton.Checked
        Machines.Save()
        Machines.Close()
    End Sub

    Public Sub StatusChange(ByVal hostName As String, ByVal Status As Machine.StatusCodes, IPAddress As String)
        Try
            ListView.Items(hostName).SubItems.Item(1).Text = ListView.Groups.Item(Status.GetHashCode).ToString

            Select Case Status
                Case Machine.StatusCodes.Unknown
                    ListView.Items(hostName).ImageIndex = 0

                Case Machine.StatusCodes.Offline
                    If ListView.Items(hostName).ImageIndex = 2 Then
                        WOL.AquilaWolLibrary.WriteLog(String.Format("Host ""{0}"" is offline.", hostName), EventLogEntryType.Information, WOL.AquilaWolLibrary.EventId.Down)

                        If My.Settings.Sound Then
                            My.Computer.Audio.Play(My.Resources.down, AudioPlayMode.Background)
                        End If

                        If (My.Settings.MinimizeToTray) Then
                            NotifyIcon1.ShowBalloonTip(5000, hostName, My.Resources.Strings.OffLine, ToolTipIcon.Info)
                        End If
                    End If
                    ListView.Items(hostName).ImageIndex = 1

                Case Machine.StatusCodes.Online
                    If ListView.Items(hostName).ImageIndex = 1 Then
                        WOL.AquilaWolLibrary.WriteLog(String.Format("Host ""{0}"" is online.", hostName), EventLogEntryType.Information, WOL.AquilaWolLibrary.EventId.Up)

                        If My.Settings.Sound Then
                            My.Computer.Audio.Play(My.Resources.up, AudioPlayMode.Background)
                        End If

                        If (My.Settings.MinimizeToTray) Then
                            NotifyIcon1.ShowBalloonTip(5000, hostName, My.Resources.Strings.OnLine, ToolTipIcon.Info)
                        End If
                    End If
                    ListView.Items(hostName).ImageIndex = 2
                    ListView.Items(hostName).SubItems(2).Text = IPAddress

                Case Else
                    Debug.Fail("status: " & Status)

            End Select
            ListView.Items(hostName).Group = ListView.Groups(Status.ToString)
            ListView.Sort()

        Catch ex As Exception
            Debug.WriteLine("(statuschange error)" & ex.Message)

        End Try
    End Sub

    Private Sub LoadTree()
        Dim tvRoot As TreeNode
        Dim tvNode As TreeNode
        Dim found As Boolean

        TreeView.SuspendLayout()
        TreeView.Nodes.Clear()
        tvRoot = TreeView.Nodes.Add(My.Resources.Strings.AllMachines)

        For Each machine As Machine In From m1 As Machine In Machines Where m1.Group.Length
            found = tvRoot.Nodes.Cast(Of TreeNode)().Any(Function(n) n.Text = machine.Group)

            If Not found Then
                tvNode = tvRoot.Nodes.Add(machine.Group)
                If My.Settings.CurrentGroup = machine.Group Then TreeView.SelectedNode = tvNode
            End If
        Next
        If My.Settings.CurrentGroup = tvRoot.Text Then TreeView.SelectedNode = tvRoot
        TreeView.ResumeLayout()
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        My.Settings.CurrentGroup = e.Node.Text
        LoadList()
    End Sub

    Private Sub LoadList()
        Dim listViewItem As ListViewItem

        ListView.SuspendLayout()
        ListView.Sorting = SortOrder.None
        ListView.ListViewItemSorter = Nothing
        ListView.Items.Clear()

        For Each machine As Machine In From m1 As Machine In Machines Where TreeView.SelectedNode.Level = 0 Or TreeView.SelectedNode.Text = m1.Group
            listViewItem = ListView.Items.Add(machine.Name, machine.Name, 0)
            listViewItem.SubItems.Add(machine.Status.ToString)
            listViewItem.SubItems.Add(machine.IP)
            listViewItem.SubItems.Add(machine.Netbios)
            listViewItem.SubItems.Add(machine.Note)
            listViewItem.SubItems.Add(machine.Group)
            StatusChange(machine.Name, machine.Status, machine.IP)
        Next

        ListView.ListViewItemSorter = _lvwColumnSorter
        _lvwColumnSorter.SortColumn = My.Settings.SortColumn
        _lvwColumnSorter.Order = My.Settings.SortDirection
        If (_lvwColumnSorter.SortColumn = 2) Then
            _lvwColumnSorter.ObjectType = "IP"
        Else
            _lvwColumnSorter.ObjectType = "String"
        End If

        ListView.SetSortIcon(_lvwColumnSorter.SortColumn, _lvwColumnSorter.Order)
        ListView.Sort()

        ListView.ResumeLayout()
        DoPing()
    End Sub

    Private Sub DoPing()

        For Each machine As Machine In Machines
            If PingToolStripButton.Checked Then
                If TreeView.SelectedNode.Level = 0 Or TreeView.SelectedNode.Text = machine.Group Then
                    machine.Run()
                Else
                    machine.Cancel()
                End If
            Else
                machine.Cancel()
            End If
        Next

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        'Toggle the visibility of the toolstrip and also the checked state of the associated menu item
        ToolBarToolStripMenuItem.Checked = Not ToolBarToolStripMenuItem.Checked
        ToolStrip.Visible = ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        'Toggle the visibility of the statusstrip and also the checked state of the associated menu item
        StatusBarToolStripMenuItem.Checked = Not StatusBarToolStripMenuItem.Checked
        StatusStrip.Visible = StatusBarToolStripMenuItem.Checked
    End Sub

    'Change whether or not the folders pane is visible
    Private Sub ToggleFoldersVisible()
        'First toggle the checked state of the associated menu item
        FoldersToolStripMenuItem.Checked = Not FoldersToolStripMenuItem.Checked

        'Change the Folders toolbar button to be in sync
        FoldersToolStripButton.Checked = FoldersToolStripMenuItem.Checked

        ' Collapse the Panel containing the TreeView.
        SplitContainer.Panel1Collapsed = Not FoldersToolStripMenuItem.Checked
    End Sub

    Private Sub FoldersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FoldersToolStripMenuItem.Click, FoldersToolStripButton.Click
        ToggleFoldersVisible()
    End Sub

    Private Sub SetView(ByVal view As System.Windows.Forms.View)
        'Figure out which menu item should be checked
        Dim menuItemToCheck As ToolStripMenuItem = Nothing
        Select Case view
            Case view.Details
                menuItemToCheck = DetailsToolStripMenuItem1

            Case view.LargeIcon
                menuItemToCheck = LargeIconsToolStripMenuItem1

            Case view.List
                menuItemToCheck = ListToolStripMenuItem1

            Case view.SmallIcon
                menuItemToCheck = SmallIconsToolStripMenuItem1

            Case view.Tile
                menuItemToCheck = TileToolStripMenuItem1

            Case Else
                Debug.Fail("Unexpected View")
                view = view.Details
                menuItemToCheck = DetailsToolStripMenuItem1

        End Select

        'Check the appropriate menu item and deselect all others under the Views menu
        For Each menuItem As ToolStripMenuItem In ListViewToolStripButton.DropDownItems
            If menuItem Is menuItemToCheck Then
                menuItem.Checked = True
            Else
                menuItem.Checked = False
            End If
        Next

        'Finally, set the view requested
        ListView.View = view

        'ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ListToolStripMenuItem1.Click
        SetView(View.List)
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DetailsToolStripMenuItem1.Click
        SetView(View.Details)
    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LargeIconsToolStripMenuItem1.Click
        SetView(View.LargeIcon)
    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SmallIconsToolStripMenuItem1.Click
        SetView(View.SmallIcon)
    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles TileToolStripMenuItem1.Click
        SetView(View.Tile)
    End Sub

    Private Sub ResetWindowLayoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ResetWindowLayoutToolStripMenuItem.Click, ResetWindowLayoutToolStripMenuItem1.Click
        My.Settings.MinimizeToTray = False

        Size = New Size(650, 490)
        Location = New Point(100, 100)
        MinimizeToTaskTrayToolStripMenuItem.Checked = My.Settings.MinimizeToTray
        ShowInTaskbar = Not My.Settings.MinimizeToTray
        NotifyIcon1.Visible = My.Settings.MinimizeToTray
        Show()
        WindowState = FormWindowState.Normal
        BringToFront()
        Activate()
    End Sub

    Private Sub PingToolStripButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PingToolStripButton.Click
        DoPing()
    End Sub

    Private Sub ShowGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ShowGroupsToolStripMenuItem.Click
        ListView.ShowGroups = ShowGroupsToolStripMenuItem.Checked
    End Sub

    Private Sub ContextMenuStrip_Machines_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Machines.Opening
        PropertiesToolStripMenuItem.Visible = (ListView.SelectedItems.Count = 1)
    End Sub

    Private Sub ListView_ColumnClick(ByVal sender As Object, ByVal e As Windows.Forms.ColumnClickEventArgs) Handles ListView.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = _lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (_lvwColumnSorter.Order = SortOrder.Ascending) Then
                _lvwColumnSorter.Order = SortOrder.Descending
            Else
                _lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            _lvwColumnSorter.SortColumn = e.Column
            _lvwColumnSorter.Order = SortOrder.Ascending
        End If

        If (e.Column = 2) Then
            _lvwColumnSorter.ObjectType = "IP"
        Else
            _lvwColumnSorter.ObjectType = "String"
        End If
        My.Settings.SortColumn = _lvwColumnSorter.SortColumn
        My.Settings.SortDirection = _lvwColumnSorter.Order

        ' Perform the sort with these new sort options.
        ListView.SetSortIcon(_lvwColumnSorter.SortColumn, _lvwColumnSorter.Order)
        ListView.Sort()
    End Sub

    Private Sub ListView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListView.DoubleClick

        Properties.Edit(ListView.SelectedItems(0).Name)
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()

    End Sub

    Private Sub ListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ListView.SelectedIndexChanged

        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabel2.Text = ""
        ToolStripProgressBar1.Value = 0

        If ListView.SelectedItems.Count = 1 Then
            TimerPing.Start()
        Else
            ResetMonitor()
        End If

    End Sub

    Private Sub ResetMonitor()

        TimerPing.Stop()
        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabel2.Text = ""
        ToolStripProgressBar1.Visible = False

    End Sub

    Private Sub TimerPing_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles TimerPing.Tick
        Dim machine As Machine
        Dim i As Integer

        If PingToolStripButton.Checked = False Or ListView.SelectedItems.Count <> 1 Then
            ResetMonitor()
            Exit Sub
        End If

        machine = Machines(ListView.SelectedItems(0).Name)

        Try
            If machine.Reply Is Nothing Then
                ToolStripStatusLabel1.Text = My.Resources.Strings.OffLine
                ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.HostNotResponding, machine.Name)
                ToolStripProgressBar1.Value = 0
            Else
                Select Case machine.Reply.Status
                    Case Net.NetworkInformation.IPStatus.Success
                        ToolStripStatusLabel1.Text = My.Resources.Strings.OnLine
                        i = machine.Reply.RoundtripTime
                        If i > 10 Then i = 10
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Value = 10 - i
                        ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.ResponseTime, machine.Name, machine.Reply.RoundtripTime)

                    Case Else
                        ToolStripStatusLabel1.Text = My.Resources.Strings.OffLine
                        ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.HostNotResponding, machine.Name)
                        ToolStripProgressBar1.Value = 0

                End Select
            End If

        Catch ex As Exception
            ResetMonitor()
            ToolStripStatusLabel1.Text = ex.Message

        End Try

    End Sub

    Private Sub Button_StartAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_StartAll.Click
        ResetMonitor()
        For Each machine As Machine In Machines
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, machine.Name, machine.MAC)
            WakeUp(machine)
            Application.DoEvents()
            Threading.Thread.Sleep(750)
        Next
    End Sub

    Private Sub Button_Emergency_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Emergency.Click
        ResetMonitor()
        ToolStripStatusLabel1.Text = My.Resources.Strings.EmergencyShutdown
        Shutdown.PerformEmergencyShutdown(Me)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ContentsToolStripMenuItem.Click
        ShowHelp(Me, "default.html")
    End Sub

    Private Sub SearchForMachinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchForMachinesToolStripMenuItem.Click
        ResetMonitor()
        Search.ShowDialog(Me)
        If Search.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Search.Dispose()
    End Sub

    Private Sub WakeUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles WakeUpToolStripMenuItem.Click
        Dim machine As Machine

        For Each listViewItem As ListViewItem In ListView.SelectedItems
            machine = Machines(listViewItem.Name)
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, machine.Name, machine.MAC)
            WakeUp(machine)
        Next
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OptionsToolStripMenuItem.Click, OptionsToolStripButton.Click
        Options.ShowDialog(Me)
        If (My.Settings.Language <> Application.CurrentCulture.IetfLanguageTag) Then
            Localization.CultureManager.ApplicationUICulture = New CultureInfo(My.Settings.Language)
            LoadTree()
            TreeView.SelectedNode = TreeView.Nodes(0)
            LoadList()
            My.Settings.DefaultMessage = My.Resources.Strings.DefaultMessage
            My.Settings.emerg_message = My.Resources.Strings.DefaultEmergency
        End If
    End Sub

    Private Sub CultureManager_UICultureChanged(newCulture As CultureInfo) Handles CultureManager.UICultureChanged
        Text = My.Resources.Strings.Title
        NotifyIcon1.Text = My.Resources.Strings.Title
        ListView.Groups("Online").Header = My.Resources.Strings.OnLine
        ListView.Groups("Offline").Header = My.Resources.Strings.OffLine
        ListView.Groups("Unknown").Header = My.Resources.Strings.lit_Unknown

        ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Version, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        ToolStripStatusLabel2.Text = String.Empty
    End Sub

    Private Sub RDPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles RDPToolStripMenuItem.Click
        Dim machine As Machine

        machine = Machines(ListView.SelectedItems(0).Name)
        Shell(String.Format("mstsc.exe -v:{0}:{1}", machine.Netbios, machine.RDPPort), AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        Dim items As String()

        ResetMonitor()
        items = ListView.SelectedItems.Cast(Of ListViewItem).Select(Function(lvi As ListViewItem) lvi.Text).ToArray()
        Shutdown.PerformShutdown(Me, items)
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PropertiesToolStripMenuItem.Click
        Properties.Edit(ListView.SelectedItems(0).Name)
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        Properties.Create()
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim fileBrowser As New OpenFileDialog

        With fileBrowser
            .Filter = "All files (*.*)|*.*"
            .Title = My.Resources.Strings.SelectFile
            .ShowDialog(Me)
            If .FileName = "" Then Exit Sub
            Machines.Import(.FileName)
        End With

        LoadList()
        MsgBox(String.Format(My.Resources.Strings.ImportedFrom, fileBrowser.FileName), MsgBoxStyle.Information)

    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim fileBrowser As New SaveFileDialog

        With fileBrowser
            .CheckFileExists = False
            .Title = My.Resources.Strings.WhereSave
            .Filter = "All files (*.*)|*.*"
            .ShowDialog(Me)
            If .FileName = "" Then Exit Sub
            Machines.Export(.FileName)
        End With

        MsgBox(String.Format(My.Resources.Strings.ExportedTo, fileBrowser.FileName), MsgBoxStyle.Information)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DeleteToolStripMenuItem.Click

        If MessageBox.Show(String.Format(My.Resources.Strings.AreYouSure), String.Format("Delete {0} record(s)", ListView.SelectedItems.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            For Each l As ListViewItem In ListView.SelectedItems
                Machines.Remove(l.Name)
                l.Remove()
            Next
        End If

    End Sub

    Private Sub ShowHotButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ShowHotButtonsToolStripMenuItem.Click, HotToolStripButton.Click
        ChangeHotButtonsPanel()
    End Sub

    Private Sub ChangeHotButtonsPanel()
        SplitContainer1.Panel2Collapsed = Not SplitContainer1.Panel2Collapsed
        ShowHotButtonsToolStripMenuItem.Checked = Not SplitContainer1.Panel2Collapsed
        If SplitContainer1.Panel2Collapsed Then
            HotToolStripButton.Checked = False
            ShowHotButtonsToolStripMenuItem.Checked = False
        Else
            HotToolStripButton.Checked = True
            ShowHotButtonsToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PrintToolStripMenuItem.Click
        ReportViewer.Show(Me)
    End Sub

    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ScheduleToolStripMenuItem.Click, ScheduleToolStripButton.Click
        Try
            Schedule.Schedule.Show(Me)

        Catch

        End Try
    End Sub

    Private Sub LicenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LicenseToolStripMenuItem.Click
        License.ShowDialog(Me)
    End Sub

    Private Sub ContextToolStripMenuItemOpen_Click(sender As System.Object, e As EventArgs) Handles ContextToolStripMenuItemOpen.Click, NotifyIcon1.DoubleClick
        Show()
        WindowState = FormWindowState.Normal
        BringToFront()
        Activate()
    End Sub

    Private Sub ContextToolStripMenuItemExit_Click(sender As System.Object, e As EventArgs) Handles ContextToolStripMenuItemExit.Click
        Close()
    End Sub

    Private Sub MinimizeToTaskTrayToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles MinimizeToTaskTrayToolStripMenuItem.Click
        My.Settings.MinimizeToTray = Not My.Settings.MinimizeToTray
        SetMinimizeToTray()
    End Sub

    Private Sub AutoStartWithWindowsToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles AutoStartWithWindowsToolStripMenuItem.Click
        Dim auto As New Autorun

        AutoStartWithWindowsToolStripMenuItem.Checked = Not AutoStartWithWindowsToolStripMenuItem.Checked
        auto.AutoRun = AutoStartWithWindowsToolStripMenuItem.Checked
    End Sub

    Private Sub Explorer_Resize(sender As System.Object, e As EventArgs) Handles MyBase.Resize
        If (WindowState = FormWindowState.Minimized And My.Settings.MinimizeToTray = True) Then
            Hide()
        End If
    End Sub

    Private Sub ContextMenuStripTray_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripTray.Opening
        ' load all of the machines into the task tray menu
        '
        ToolStripMenuItemWakeUp.DropDownItems.Clear()

        For Each machine As Machine In Machines
            Dim item As ToolStripMenuItem = New ToolStripMenuItem()

            item.Name = machine.Name
            item.Text = machine.Name
            ToolStripMenuItemWakeUp.DropDownItems.Add(item)
            AddHandler item.Click, AddressOf TaskTrayWake_Click
        Next
    End Sub

    Private Sub TaskTrayWake_Click(sender As System.Object, e As EventArgs)
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim machine As Machine

        If item IsNot Nothing Then
            machine = Machines(item.Name)
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, machine.Name, machine.MAC)
            WakeUp(machine)
        End If
    End Sub

    Private Sub ListenToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles ListenToolStripMenuItem.Click, ListenerToolStripButton.Click
        My.Forms.Listener.Show()
    End Sub

    ' Keep the SplashScreen in the foreground
    Private Sub Explorer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetForegroundWindow(SplashPtr)
    End Sub

    ' TreeView context menu
    Private Sub WakeUpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WakeUpToolStripMenuItem1.Click
        Dim machine As Machine

        For Each l As ListViewItem In ListView.Items
            machine = Machines(l.Name)
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, machine.Name, machine.MAC)
            WakeUp(machine)
        Next
    End Sub

    Private Sub ShutDownToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShutDownToolStripMenuItem1.Click
        Dim items As String()

        ResetMonitor()
        items = ListView.Items.Cast(Of ListViewItem).Select(Function(lvi As ListViewItem) lvi.Text).ToArray()
        Shutdown.PerformShutdown(Me, items)
    End Sub

    ' if user right-clicks a group, select that group
    Private Sub TreeView_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            TreeView.SelectedNode = e.Node
        End If
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        Process.Start(My.Settings.donate)
    End Sub

    Private Sub EventLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventLogToolStripMenuItem.Click, EventLogToolStripButton.Click
        If (Not _historyBackgroundworker.IsBusy) Then
            _historyBackgroundworker.RunWorkerAsync()
        End If
    End Sub

    Private Sub HistoryBackgroundworker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _historyBackgroundworker.DoWork
        History.ShowDialog()
    End Sub

End Class
