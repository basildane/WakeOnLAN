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

Imports System.Diagnostics
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports AutoUpdaterDotNET
Imports System.Globalization

Public Class Explorer
    Declare Function IsValidLocale Lib "kernel32" (ByVal Locale As Integer, ByVal dwFlags As Integer) As Integer
    Declare Function OpenIcon Lib "user32" (ByVal hwnd As Long) As Long
    Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As Long

    Const LCID_INSTALLED As Long = &H1 '-- is locale present?

    Private Sub Explorer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim auto As New Autorun()
        AutoStartWithWindowsToolStripMenuItem.Checked = auto.autorun()

        Me.Text = My.Resources.Strings.Title
        ListView.View = My.Settings.ListView_View
        GetListViewState(ListView, My.Settings.ListView_Columns)

        ShowGroupsToolStripMenuItem.Checked = My.Settings.ShowGroups
        SetMinimizeToTray()

        If Not My.Settings.ShowHotButtons Then ChangeHotButtonsPanel()
        If Not My.Settings.ShowFolders Then ToggleFoldersVisible()

        ListView.ShowGroups = My.Settings.ShowGroups
        PingToolStripButton.Checked = My.Settings.Pinger
        ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Version, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        ToolStripStatusLabel2.Text = ""

        For Each l As ToolStripMenuItem In LanguageToolStripMenuItem.DropDownItems
            If l.Tag = My.Settings.Language Then
                l.Checked = True
            End If
        Next

        ' Scheduling functions are only available in Vista and 2008 and higher
        '
        ScheduleToolStripMenuItem.Enabled = (Environment.OSVersion.Version.Major >= 6)
        ScheduleToolStripButton.Enabled = ScheduleToolStripMenuItem.Enabled

        ' If Chinese character set is not installed, revert to English
        '
        If IsValidLocale(New Globalization.CultureInfo("zh-TW").LCID, LCID_INSTALLED) = 0 Then
            With TaiwanToolStripMenuItem
                .Enabled = False
                .Text = "Taiwan (Chinese)"
            End With
        End If

        ListView.Groups("Online").Header = My.Resources.Strings.OnLine
        ListView.Groups("Offline").Header = My.Resources.Strings.OffLine
        ListView.Groups("Unknown").Header = My.Resources.Strings.lit_Unknown

        SetView(ListView.View)
        Machines.Load()

        Machines.dirty = False
        LoadTree()
        Me.ListView.ListViewItemSorter = New ListViewItemComparer(My.Settings.SortColumn)

        Me.Location = My.Settings.MainWindow_Location
        Me.Size = My.Settings.MainWindow_Size
        MenuStrip.Location = New Point(0, 0)

        Try
            If (My.Application.CommandLineArgs(0) = "/min") Then
                Me.Hide()
            Else
                Me.Show()
            End If

        Catch ex As Exception

        End Try

        CheckUpdates()
    End Sub

    Private Sub CheckUpdates()
        AutoUpdater.CurrentCulture = Application.CurrentCulture
        AutoUpdater.AppCastURL = My.Settings.updateURL
        AutoUpdater.versionURL = My.Settings.updateVersions
        AddHandler AutoUpdater.UpdateStatus, AddressOf updateStatus
        AutoUpdater.Start(My.Settings.updateIntervalDays)
    End Sub

    Private Delegate Sub UpdateStatusHandler(sender As Object, e As AutoUpdateEventArgs)

    Private Sub updateStatus(sender As Object, e As AutoUpdateEventArgs)
        If (InvokeRequired) Then
            BeginInvoke(New UpdateStatusHandler(AddressOf updateStatus), New Object() {sender, e})
            Return
        End If

        ToolStripStatusLabel2.Text = e.text
        If (e.status = AutoUpdateEventArgs.statusCodes.updateAvailable) Then
            NotifyIconUpdate.Visible = True
            NotifyIconUpdate.ShowBalloonTip(0, "WakeOnLAN", e.text, ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NotifyIconUpdate_BalloonTipClicked(sender As System.Object, e As System.EventArgs) Handles NotifyIconUpdate.BalloonTipClicked, NotifyIconUpdate.Click
        NotifyIconUpdate.Visible = False
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub SetMinimizeToTray()
        MinimizeToTaskTrayToolStripMenuItem.Checked = My.Settings.MinimizeToTray
        Me.ShowInTaskbar = Not My.Settings.MinimizeToTray
        NotifyIcon1.Visible = My.Settings.MinimizeToTray
    End Sub

    Private Sub Explorer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.ListView_View = ListView.View
        My.Settings.ListView_Columns = SaveListViewState(ListView)

        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.MainWindow_Location = Me.Location
            My.Settings.MainWindow_Size = Me.Size
        End If

        My.Settings.ShowGroups = ShowGroupsToolStripMenuItem.Checked
        My.Settings.ShowHotButtons = ShowHotButtonsToolStripMenuItem.Checked
        My.Settings.ShowFolders = FoldersToolStripMenuItem.Checked
        My.Settings.Pinger = PingToolStripButton.Checked
        Machines.Save()
        Machines.Close()
    End Sub

    Public Sub StatusChange(ByVal Name As String, ByVal Status As Machine.StatusCodes, IPAddress As String)
        Try
            ListView.Items(Name).SubItems.Item(1).Text = ListView.Groups.Item(Status.GetHashCode).ToString

            Select Case Status
                Case Machine.StatusCodes.Unknown
                    ListView.Items(Name).ImageIndex = 0

                Case Machine.StatusCodes.Offline
                    If ListView.Items(Name).ImageIndex = 2 Then
                        If My.Settings.Sound Then
                            My.Computer.Audio.Play(My.Resources.down, AudioPlayMode.Background)
                        End If

                        If (My.Settings.MinimizeToTray) Then
                            NotifyIcon1.ShowBalloonTip(5000, Name, My.Resources.Strings.OffLine, ToolTipIcon.Info)
                        End If
                    End If
                    ListView.Items(Name).ImageIndex = 1

                Case Machine.StatusCodes.Online
                    If ListView.Items(Name).ImageIndex = 1 Then
                        If My.Settings.Sound Then
                            My.Computer.Audio.Play(My.Resources.up, AudioPlayMode.Background)
                        End If

                        If (My.Settings.MinimizeToTray) Then
                            NotifyIcon1.ShowBalloonTip(5000, Name, My.Resources.Strings.OnLine, ToolTipIcon.Info)
                        End If
                    End If
                    ListView.Items(Name).ImageIndex = 2
                    ListView.Items(Name).SubItems(2).Text = IPAddress

                Case Else
                    Debug.Fail("status: " & Status)

            End Select
            ListView.Items(Name).Group = ListView.Groups(Status.ToString)

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
        tvRoot = Me.TreeView.Nodes.Add(My.Resources.Strings.AllMachines)

        For Each m As Machine In Machines
            If m.Group.Length Then
                found = False
                For Each n As TreeNode In tvRoot.Nodes
                    If n.Text = m.Group Then
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then
                    tvNode = tvRoot.Nodes.Add(m.Group)
                    If My.Settings.CurrentGroup = m.Group Then TreeView.SelectedNode = tvNode
                End If
            End If
        Next
        If My.Settings.CurrentGroup = tvRoot.Text Then TreeView.SelectedNode = tvRoot
        TreeView.ResumeLayout()

    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        My.Settings.CurrentGroup = e.Node.Text
        LoadList()
    End Sub

    Private Sub LoadList()
        Dim l As ListViewItem

        ListView.SuspendLayout()
        ListView.Sorting = SortOrder.None
        ListView.Items.Clear()

        For Each m As Machine In Machines
            If TreeView.SelectedNode.Level = 0 Or TreeView.SelectedNode.Text = m.Group Then
                l = ListView.Items.Add(m.Name, m.Name, 0)
                l.SubItems.Add(m.Status.ToString)
                l.SubItems.Add(m.IP)
                l.SubItems.Add(m.Netbios)
                l.SubItems.Add(m.Group)
                StatusChange(m.Name, m.Status, m.IP)
            End If
        Next

        Me.ListView.ListViewItemSorter = New ListViewItemComparer(My.Settings.SortColumn)
        ListView.Sorting = My.Settings.SortDirection
        ListView.ResumeLayout()
        DoPing()
    End Sub

    Private Sub DoPing()

        For Each m As Machine In Machines
            If PingToolStripButton.Checked Then
                If TreeView.SelectedNode.Level = 0 Or TreeView.SelectedNode.Text = m.Group Then
                    m.Run()
                Else
                    m.Cancel()
                End If
            Else
                m.Cancel()
            End If
        Next

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        'Toggle the visibility of the toolstrip and also the checked state of the associated menu item
        ToolBarToolStripMenuItem.Checked = Not ToolBarToolStripMenuItem.Checked
        ToolStrip.Visible = ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
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
        Me.SplitContainer.Panel1Collapsed = Not FoldersToolStripMenuItem.Checked
    End Sub

    Private Sub FoldersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoldersToolStripMenuItem.Click, FoldersToolStripButton.Click
        ToggleFoldersVisible()
    End Sub

    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        'Figure out which menu item should be checked
        Dim MenuItemToCheck As ToolStripMenuItem = Nothing
        Select Case View
            Case View.Details
                MenuItemToCheck = DetailsToolStripMenuItem1

            Case View.LargeIcon
                MenuItemToCheck = LargeIconsToolStripMenuItem1

            Case View.List
                MenuItemToCheck = ListToolStripMenuItem1

            Case View.SmallIcon
                MenuItemToCheck = SmallIconsToolStripMenuItem1

            Case View.Tile
                MenuItemToCheck = TileToolStripMenuItem1

            Case Else
                Debug.Fail("Unexpected View")
                View = View.Details
                MenuItemToCheck = DetailsToolStripMenuItem1

        End Select

        'Check the appropriate menu item and deselect all others under the Views menu
        For Each MenuItem As ToolStripMenuItem In ListViewToolStripButton.DropDownItems
            If MenuItem Is MenuItemToCheck Then
                MenuItem.Checked = True
            Else
                MenuItem.Checked = False
            End If
        Next

        'Finally, set the view requested
        ListView.View = View

        'ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem1.Click
        SetView(View.List)
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem1.Click
        SetView(View.Details)
    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeIconsToolStripMenuItem1.Click
        SetView(View.LargeIcon)
    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallIconsToolStripMenuItem1.Click
        SetView(View.SmallIcon)
    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem1.Click
        SetView(View.Tile)
    End Sub

    Private Sub ResetWindowLayoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetWindowLayoutToolStripMenuItem.Click
        Me.Size = New Size(650, 490)
        Me.Location = New Point(100, 100)
    End Sub

    Private Sub PingToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingToolStripButton.Click
        DoPing()
    End Sub

    Private Sub ShowGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowGroupsToolStripMenuItem.Click
        ListView.ShowGroups = ShowGroupsToolStripMenuItem.Checked
    End Sub

    Private Sub ContextMenuStrip_Machines_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Machines.Opening
        PropertiesToolStripMenuItem.Visible = (ListView.SelectedItems.Count = 1)
    End Sub

    Private Sub ListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView.ColumnClick
        If e.Column = My.Settings.SortColumn Then
            If My.Settings.SortDirection = 1 Then
                My.Settings.SortDirection = 2
            Else
                My.Settings.SortDirection = 1
            End If
        End If
        My.Settings.SortColumn = e.Column
        Me.ListView.ListViewItemSorter = New ListViewItemComparer(My.Settings.SortColumn)
    End Sub

    Private Sub ListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick

        Properties.Edit(ListView.SelectedItems(0).Name)
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()

    End Sub

    Private Sub ListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.SelectedIndexChanged

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

    Private Sub TimerPing_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerPing.Tick
        Dim m As Machine
        Dim i As Integer

        If PingToolStripButton.Checked = False Or ListView.SelectedItems.Count <> 1 Then
            ResetMonitor()
            Exit Sub
        End If

        m = Machines(ListView.SelectedItems(0).Name)

        Try
            If m.Reply Is Nothing Then
                ToolStripStatusLabel1.Text = My.Resources.Strings.OffLine
                ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.HostNotResponding, m.Name)
                ToolStripProgressBar1.Value = 0
            Else
                Select Case m.Reply.Status
                    Case Net.NetworkInformation.IPStatus.Success
                        ToolStripStatusLabel1.Text = My.Resources.Strings.OnLine
                        i = m.Reply.RoundtripTime
                        If i > 10 Then i = 10
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Value = 10 - i
                        ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.ResponseTime, m.Name, m.Reply.RoundtripTime)

                    Case Else
                        ToolStripStatusLabel1.Text = My.Resources.Strings.OffLine
                        ToolStripStatusLabel2.Text = String.Format(My.Resources.Strings.HostNotResponding, m.Name)
                        ToolStripProgressBar1.Value = 0

                End Select
            End If

        Catch ex As Exception
            ResetMonitor()
            ToolStripStatusLabel1.Text = ex.Message

        End Try

    End Sub

    Private Sub Button_StartAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_StartAll.Click
        ResetMonitor()
        For Each Machine As Machine In Machines
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, Machine.Name, Machine.MAC)
            WakeUp(Machine)
            Application.DoEvents()
            System.Threading.Thread.Sleep(750)
        Next
    End Sub

    Private Sub Button_Emergency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Emergency.Click
        ResetMonitor()
        ToolStripStatusLabel1.Text = My.Resources.Strings.EmergencyShutdown
        Shutdown.PerformEmergencyShutdown(Me)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Globals.ShowHelp(Me, "default.html")
    End Sub

    Private Sub SearchForMachinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchForMachinesToolStripMenuItem.Click
        ResetMonitor()
        Search.ShowDialog(Me)
        If Search.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Search.Dispose()
    End Sub

    Private Sub WakeUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WakeUpToolStripMenuItem.Click
        Dim m As Machine

        For Each l As ListViewItem In ListView.SelectedItems
            m = Machines(l.Name)
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, m.Name, m.MAC)
            WakeUp(m)
        Next
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.ShowDialog(Me)
    End Sub

    Private Sub LanguageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click, RussianToolStripMenuItem.Click, TaiwanToolStripMenuItem.Click, FinnishToolStripMenuItem.Click, PortugueseToolStripMenuItem.Click, DeutschToolStripMenuItem.Click, FrenchToolStripMenuItem.Click, HungaryToolStripMenuItem.Click, DutchToolStripMenuItem.Click, RomanianToolStripMenuItem.Click
        Dim menuitem As ToolStripMenuItem

        For Each menuitem In LanguageToolStripMenuItem.DropDownItems
            If menuitem.Checked Then menuitem.Checked = False
        Next

        menuitem = sender
        My.Settings.Language = menuitem.Tag
        menuitem.Checked = True
        Localization.CultureManager.ApplicationUICulture = New CultureInfo(menuitem.Tag.ToString())
        LoadTree()
        TreeView.SelectedNode = TreeView.Nodes(0)
        LoadList()
    End Sub


    Private Sub CultureManager_UICultureChanged(newCulture As CultureInfo) Handles CultureManager.UICultureChanged
        ListView.Groups("Online").Header = My.Resources.Strings.OnLine
        ListView.Groups("Offline").Header = My.Resources.Strings.OffLine
        ListView.Groups("Unknown").Header = My.Resources.Strings.lit_Unknown

        ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.Version, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        ToolStripStatusLabel2.Text = ""

        My.Settings.DefaultMessage = My.Resources.Strings.DefaultMessage
        My.Settings.emerg_message = My.Resources.Strings.DefaultEmergency
    End Sub

    Private Sub RDPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDPToolStripMenuItem.Click
        Dim m As Machine

        m = Machines(ListView.SelectedItems(0).Name)
        Shell(String.Format("mstsc.exe -v:{0}:{1}", m.Netbios, m.RDPPort), AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        ResetMonitor()
        Shutdown.PerformShutdown(Me, ListView.SelectedItems)
    End Sub

    Private Sub AbortShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbortShutdownToolStripMenuItem.Click
        Dim dwResult As Integer
        Dim m As Machine

        Me.Cursor = Cursors.WaitCursor
        ResetMonitor()
        For Each l As ListViewItem In ListView.SelectedItems
            m = Machines(l.Name)

            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.AbortingShutdown, m.Name)
            dwResult = AbortSystemShutdown("\\" & m.Netbios)
            If dwResult = 0 Then
                ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.AbortFailed, m.Netbios, FormatMessage(Err.LastDllError))
            Else
                ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.AbortSuccess, m.Netbios)
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Properties.Edit(ListView.SelectedItems(0).Name)
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Properties.Create()
        If Properties.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTree()
        End If
        Properties.Dispose()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Dim FileBrowser As New OpenFileDialog

        With FileBrowser
            .Filter = "All files (*.*)|*.*"
            .Title = My.Resources.Strings.SelectFile
            .ShowDialog(Me)
            If .FileName = "" Then Exit Sub
            Machines.Import(.FileName)
        End With

        LoadList()
        MsgBox(String.Format(My.Resources.Strings.ImportedFrom, FileBrowser.FileName), MsgBoxStyle.Information)

    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim FileBrowser As New SaveFileDialog

        With FileBrowser
            .CheckFileExists = False
            .Title = My.Resources.Strings.WhereSave
            .Filter = "All files (*.*)|*.*"
            .ShowDialog(Me)
            If .FileName = "" Then Exit Sub
            Machines.Export(.FileName)
        End With

        MsgBox(String.Format(My.Resources.Strings.ExportedTo, FileBrowser.FileName), MsgBoxStyle.Information)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If MessageBox.Show(String.Format(My.Resources.Strings.AreYouSure), String.Format("Delete {0} record(s)", ListView.SelectedItems.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            For Each l As ListViewItem In ListView.SelectedItems
                Machines.Remove(l.Name)
                l.Remove()
            Next
        End If

    End Sub

    Private Sub ShowHotButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHotButtonsToolStripMenuItem.Click, HotToolStripButton.Click
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

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        ReportViewer.Show(Me)
    End Sub

    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem.Click, ScheduleToolStripButton.Click
        Schedule.Show(Me)
    End Sub

    Private Sub LicenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenseToolStripMenuItem.Click
        License.ShowDialog(Me)
    End Sub

    Private Sub ContextToolStripMenuItemOpen_Click(sender As System.Object, e As System.EventArgs) Handles ContextToolStripMenuItemOpen.Click, NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
        Me.Activate()
    End Sub

    Private Sub ContextToolStripMenuItemExit_Click(sender As System.Object, e As System.EventArgs) Handles ContextToolStripMenuItemExit.Click
        Me.Close()
    End Sub

    Private Sub MinimizeToTaskTrayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MinimizeToTaskTrayToolStripMenuItem.Click
        My.Settings.MinimizeToTray = Not My.Settings.MinimizeToTray
        SetMinimizeToTray()
    End Sub

    Private Sub AutoStartWithWindowsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AutoStartWithWindowsToolStripMenuItem.Click
        Dim auto As New Autorun

        AutoStartWithWindowsToolStripMenuItem.Checked = Not AutoStartWithWindowsToolStripMenuItem.Checked
        auto.autorun = AutoStartWithWindowsToolStripMenuItem.Checked
    End Sub

    Private Sub Explorer_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        If (Me.WindowState = FormWindowState.Minimized And My.Settings.MinimizeToTray = True) Then
            Me.Hide()
        End If
    End Sub

    Private Sub ContextMenuStripTray_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripTray.Opening
        ' load all of the machines into the task tray menu
        '
        ToolStripMenuItemWakeUp.DropDownItems.Clear()

        For Each m As Machine In Machines
            Dim item As ToolStripMenuItem = New ToolStripMenuItem()

            item.Name = m.Name
            item.Text = m.Name
            ToolStripMenuItemWakeUp.DropDownItems.Add(item)
            AddHandler item.Click, AddressOf TaskTrayWake_Click
        Next
    End Sub

    Private Sub TaskTrayWake_Click(sender As System.Object, e As System.EventArgs)
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim m As Machine

        If item IsNot Nothing Then
            m = Machines(item.Name)
            ToolStripStatusLabel1.Text = String.Format(My.Resources.Strings.SentTo, m.Name, m.MAC)
            WakeUp(m)
        End If
    End Sub

    Private Sub ListenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListenToolStripMenuItem.Click, ListenerToolStripButton.Click
        My.Forms.Listener.Show()
    End Sub

    Private Sub ToolStripButtonDonate_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDonate.Click
        System.Diagnostics.Process.Start(My.Settings.donate)
    End Sub

    ' Keep the SplashScreen in the foreground
    Private Sub Explorer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetForegroundWindow(Globals.splashPtr)
    End Sub
End Class

' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        ' col 2 is IP address
        Dim direction As Int16

        direction = IIf(My.Settings.SortDirection = 1, 1, -1)

        If col = 2 Then
            Try
                Return ((ConvDotIP2Long(CType(x, ListViewItem).SubItems(col).Text)) - ConvDotIP2Long(CType(y, ListViewItem).SubItems(col).Text)) * direction

            Catch ex As Exception
                Debug.WriteLine("compare:" & ex.Message)

            End Try
            Return 0
        End If
        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text) * direction
    End Function

    Private Function ConvDotIP2Long(ByVal DotIP As String) As Long
        Dim IPArray() As String

        ConvDotIP2Long = 0
        Try
            IPArray = Split(DotIP, ".")
            For i As Int16 = 0 To UBound(IPArray)
                ConvDotIP2Long += ((IPArray(i) Mod 256) * (256 ^ (4 - i)))
            Next

        Catch ex As Exception
            Debug.WriteLine(ex.Message)

        End Try

    End Function
End Class
