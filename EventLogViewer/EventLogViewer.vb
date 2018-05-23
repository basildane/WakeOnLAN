'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2018 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
'
'
'    This module was adapted from "EventLog Viewer"
'    Benjamin Liedblad, published 14 Jun 2006

Option Explicit On
Option Strict On

Public Class EventLogViewer

#Region " Declarations "
    Private WithEvents evLog As EventLog
    Private logName As String = "Application"
    Private SourceName As String

    ' Show the category/eventID
    Private sourceVisible As Boolean = True
    Private categoryVisible As Boolean = True
    Private eventIDVisible As Boolean = True

    ' Used for display of the selected grid item
    Private oldRowIndex As Int32 = 0

    ' Used to display the number of errors, warnings, messages
    Private numErrors As Integer = 0
    Private numWarnings As Integer = 0
    Private numMessages As Integer = 0

    ' Data binding objects
    Private ds As DataSet = Nothing
    Private bs As BindingSource = Nothing
#End Region

#Region " Delegates "
    Private Delegate Sub d_appendEntryToDataSet(ByVal [message] As String, _
                                                ByVal [source] As String, _
                                                ByVal [type] As EventLogEntryType, _
                                                ByVal [instanceID] As Long, _
                                                ByVal [category] As String)
#End Region

#Region " Public Properties "
    Public Property Log() As String
        Get
            Return logName
        End Get
        Set(ByVal value As String)
            logName = value
        End Set
    End Property

    Public Property Source() As String
        Get
            Return SourceName
        End Get
        Set(ByVal value As String)
            SourceName = value
        End Set
    End Property

    Public Property IsSourceVisible() As Boolean
        Get
            Return sourceVisible
        End Get
        Set(ByVal value As Boolean)
            ' Set the column visibility
            sourceVisible = value
            If Not DesignMode Then
                ' Show/Hide the source column if applicable
                If DataGridView1.Columns.Contains("Source") Then
                    DataGridView1.Columns.Item("Source").Visible = sourceVisible
                End If

                ' Show/Hide the source dropdown
                SourceCombo.Visible = sourceVisible
                SourceSeparator.Visible = sourceVisible
                SourceLabel.Visible = sourceVisible

                ' Auto size all columns except the message column
                For Each col As DataGridViewColumn In DataGridView1.Columns
                    If col.Name <> "Message" Then
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If
                Next
            End If
        End Set
    End Property

    Public Property IsCategoryVisible() As Boolean
        Get
            Return categoryVisible
        End Get
        Set(ByVal value As Boolean)
            ' Set the column visibility
            categoryVisible = value
            If Not DesignMode Then
                If DataGridView1.Columns.Contains("Category") Then
                    DataGridView1.Columns.Item("Category").Visible = categoryVisible
                End If

                ' Auto size all columns except the message column
                For Each col As DataGridViewColumn In DataGridView1.Columns
                    If col.Name <> "Message" Then
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If
                Next
            End If
        End Set
    End Property

    Public Property IsEventIDVisible() As Boolean
        Get
            Return eventIDVisible
        End Get
        Set(ByVal value As Boolean)
            ' Set the column visibility
            eventIDVisible = value
            If Not DesignMode Then
                If DataGridView1.Columns.Contains("EventID") Then
                    DataGridView1.Columns.Item("EventID").Visible = eventIDVisible
                End If

                ' Auto size all columns except the message column
                For Each col As DataGridViewColumn In DataGridView1.Columns
                    If col.Name <> "Message" Then
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If
                Next
            End If
        End Set
    End Property
#End Region

#Region " Private Methods "
    Private Sub appendEntryToDataSet(ByVal [message] As String, _
                                     ByVal [source] As String, _
                                     ByVal [type] As EventLogEntryType, _
                                     ByVal [instanceID] As Long, _
                                     ByVal [category] As String)

        If String.IsNullOrEmpty(SourceName) Or StrComp(SourceName, [source], CompareMethod.Text) = 0 Then
            ' A new entry was added to the event log, add it to the dataview (use the 'Now' function to get close to the actual generated time)
            Dim currentDateTime As DateTime = Now
            Dim params() As Object = {type, _
                                      currentDateTime, _
                                      source, _
                                      category, _
                                      instanceID, _
                                      message}

            ds.Tables("Events").Rows.Add(params)

            ' Increment the event type counts
            If type = EventLogEntryType.Error Then
                numErrors += 1
            End If

            If type = EventLogEntryType.Warning Then
                numWarnings += 1
            End If

            If type = EventLogEntryType.Information Then
                numMessages += 1
            End If

            ' Update the text of the bbuttons 
            btnErrors.Text = String.Format(My.Resources.Strings.Errors, numErrors)
            btnErrors.ToolTipText = btnErrors.Text
            btnWarnings.Text = String.Format(My.Resources.Strings.Warnings, numWarnings)
            btnWarnings.ToolTipText = btnWarnings.Text
            btnMessages.Text = String.Format(My.Resources.Strings.Messages, numMessages)
            btnMessages.ToolTipText = btnMessages.Text
        End If
    End Sub

    Private Function GenerateEventFilter() As String
        Dim displayFilter As String = String.Empty

        ' Add errors to the filter
        If btnErrors.Checked Then
            displayFilter = "(Type='Error')"
        End If

        ' Add warnings to the filter
        If btnWarnings.Checked Then
            If String.IsNullOrEmpty(displayFilter) Then
                displayFilter = "(Type='Warning')"
            Else
                displayFilter = displayFilter.Trim(")".ToCharArray)
                displayFilter += " OR Type='Warning')"
            End If
        End If

        ' Add messages to the filter
        If btnMessages.Checked Then
            If String.IsNullOrEmpty(displayFilter) Then
                displayFilter = "(Type='Information')"
            Else
                displayFilter = displayFilter.Trim(")".ToCharArray)
                displayFilter += " OR Type='Information')"
            End If
        End If

        ' If none of the buttons are pressed, this means they want none of these displayed
        If String.IsNullOrEmpty(displayFilter) Then
            displayFilter = "Type=''"
        Else
            ' Add a filter for the source
            If Not String.IsNullOrEmpty(SourceCombo.Text.Trim) Then
                displayFilter += " AND Source='" + SourceCombo.Text + "'"
            End If

            ' Add a filter for the typed message filter
            If Not String.IsNullOrEmpty(FindText.Text) Then
                displayFilter += " AND Message LIKE '*" + FindText.Text + "*'"
            End If
        End If

        ' Return the filter string
        Return displayFilter
    End Function

    Private Sub refreshFilterDisplay()
        ' Check to see if any entries still remain
        If DataGridView1.Rows.Count = 0 Then
            ' Signal no matching events
            If FindText.Text.Length > 0 Then
                FindText.BackColor = Color.Salmon
            Else
                FindText.BackColor = Color.White
            End If
            NotFoundLabel.Visible = True
        Else
            ' Signal no "error"
            FindText.BackColor = Color.White
            NotFoundLabel.Visible = False
        End If
    End Sub
#End Region

#Region " Event Handlers "
    Public Sub Populate()
        btnErrors.Text = String.Format(My.Resources.Strings.Errors, numErrors)
        btnErrors.ToolTipText = btnErrors.Text
        btnWarnings.Text = String.Format(My.Resources.Strings.Warnings, numWarnings)
        btnWarnings.ToolTipText = btnWarnings.Text
        btnMessages.Text = String.Format(My.Resources.Strings.Messages, numMessages)
        btnMessages.ToolTipText = btnMessages.Text

        DataGridView1.SuspendLayout()
        Application.UseWaitCursor = True
        Application.DoEvents()

        ' Set the selection background color to transparent so 
        ' the cell won't paint over the custom selection background.
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent

        ' Initialize other DataGridView properties.
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Adjust the row heights to accommodate the normal cell content.
        DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)

        ' If in runtime, load the grid with data
        If Not DesignMode Then
            ' Connect to the log
            evLog = New EventLog(logName)
            evLog.EnableRaisingEvents = True
            AddHandler evLog.EntryWritten, AddressOf evLog_EntryWritten

            ' Setup the dataset
            ds = New DataSet("EventLog Entries")
            ds.Tables.Add("Events")
            With ds.Tables("Events")
                .Columns.Add("Type")
                .Columns.Add("Date/Time")
                .Columns("Date/Time").DataType = GetType(DateTime)
                .Columns.Add("Source")
                .Columns.Add("Category")
                .Columns.Add("EventID")
                .Columns.Add("Message")
            End With

            ' Add all the items from the event log to the dataview
            For i As Integer = 0 To evLog.Entries.Count - 1
                With evLog.Entries(i)
                    ' Add a row to the dataset
                    Dim params() As Object = {.EntryType, _
                                              .TimeGenerated, _
                                              .Source, _
                                              .Category, _
                                              .InstanceId, _
                                              .Message}

                    If String.IsNullOrEmpty(SourceName) Or StrComp(SourceName, evLog.Entries(i).Source, CompareMethod.Text) = 0 Then
                        ds.Tables("Events").Rows.Add(params)

                        ' If this source doesn't exist in the dropdown, add it
                        If Not SourceCombo.Items.Contains(.Source) Then
                            SourceCombo.Items.Add(.Source)
                        End If

                        ' Increment the event type counts
                        If .EntryType = EventLogEntryType.Error Then
                            numErrors += 1
                            Continue For
                        End If

                        If .EntryType = EventLogEntryType.Warning Then
                            numWarnings += 1
                            Continue For
                        End If

                        If .EntryType = EventLogEntryType.Information Then
                            numMessages += 1
                            Continue For
                        End If
                    End If
                End With
            Next

            ' Update the buttons 
            btnErrors.Text = String.Format(My.Resources.Strings.Errors, numErrors)
            btnErrors.ToolTipText = btnErrors.Text
            btnWarnings.Text = String.Format(My.Resources.Strings.Warnings, numWarnings)
            btnWarnings.ToolTipText = btnWarnings.Text
            btnMessages.Text = String.Format(My.Resources.Strings.Messages, numMessages)
            btnMessages.ToolTipText = btnMessages.Text

            ' Create a binding source that will be used to filter the dataset
            bs = New BindingSource(ds, "Events")

            ' Bind the datagridview
            DataGridView1.DataSource = bs

            ' Auto size all columns except the message column
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Name = "Date/Time" Then
                    col.HeaderText = My.Resources.Strings.col_Date
                    col.ValueType = GetType(DateTime)
                    DataGridView1.Sort(col, System.ComponentModel.ListSortDirection.Descending)
                End If
                If col.Name = "Type" Then
                    col.HeaderText = My.Resources.Strings.col_Type
                End If
                If col.Name = "EventID" Then
                    col.HeaderText = My.Resources.Strings.col_EventID
                End If
                If col.Name = "Message" Then
                    col.HeaderText = My.Resources.Strings.col_Message
                End If
                If col.Name <> "Message" Then
                    'col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            ' Hide the source column if applicable
            If DataGridView1.Columns.Contains("Source") Then
                DataGridView1.Columns.Item("Source").Visible = sourceVisible
            End If

            ' Show/Hide the source dropdown
            SourceCombo.Visible = sourceVisible
            SourceSeparator.Visible = sourceVisible
            SourceLabel.Visible = sourceVisible

            ' Hide the category column if applicable
            If DataGridView1.Columns.Contains("Category") Then
                DataGridView1.Columns.Item("Category").Visible = categoryVisible
            End If

            ' Hide the event ID if applicable
            If DataGridView1.Columns.Contains("EventID") Then
                DataGridView1.Columns.Item("EventID").Visible = eventIDVisible
                DataGridView1.Columns.Item("EventID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If

        End If

        DataGridView1.ResumeLayout()
        Application.UseWaitCursor = False

    End Sub

    Private Sub evLog_EntryWritten(ByVal sender As Object, ByVal e As EntryWrittenEventArgs)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If InvokeRequired Then
            ' Update the dataset by calling the delegate
            Dim d As New d_appendEntryToDataSet(AddressOf appendEntryToDataSet)
            Invoke(d, New Object() {e.Entry.Message, e.Entry.Source, e.Entry.EntryType, e.Entry.InstanceId, e.Entry.Category})
        Else
            ' Update the underlying dataset as events from the event log seem to be unreliable
            appendEntryToDataSet(e.Entry.Message, e.Entry.Source, e.Entry.EntryType, e.Entry.InstanceId, e.Entry.Category)
        End If
    End Sub

    Private Sub btnErrors_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnErrors.Click
        ' Set the filter for the binding source
        bs.Filter = GenerateEventFilter()
        ' Refresh the display
        refreshFilterDisplay()
    End Sub

    Private Sub btnWarnings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWarnings.Click
        ' Set the filter for the binding source
        bs.Filter = GenerateEventFilter()
        ' Refresh the display
        refreshFilterDisplay()
    End Sub

    Private Sub btnMessages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMessages.Click
        ' Set the filter for the binding source
        bs.Filter = GenerateEventFilter()
        ' Refresh the display
        refreshFilterDisplay()
    End Sub

    Private Sub cmbSourceCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SourceCombo.SelectedIndexChanged
        ' Set the filter for the binding source
        bs.Filter = GenerateEventFilter()
        ' Refresh the display
        refreshFilterDisplay()
    End Sub

    Private Sub txtFindText_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles FindText.KeyPress
        ' Don't allow characters like ']' or '!' as they may cause an exception on the filter
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
            Beep()
        End If
    End Sub

    Private Sub txtFindText_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FindText.TextChanged
        ' Set the filter for the binding source
        bs.Filter = GenerateEventFilter()
        ' Check to see if any entries still remain
        If DataGridView1.Rows.Count = 0 Then
            ' Signal no matching text
            FindText.BackColor = Color.Salmon
            NotFoundLabel.Visible = True
        Else
            ' Signal no "error"
            FindText.BackColor = Color.White
            NotFoundLabel.Visible = False
        End If
    End Sub

    Private Sub dataGridView1_ColumnWidthChanged(ByVal sender As Object, _
        ByVal e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        ' Forces the control to repaint itself when the user 
        ' manually changes the width of a column.
        DataGridView1.Invalidate()

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
        ' Forces the row to repaint itself when the user changes the 
        ' current cell. This is necessary to refresh the focus rectangle.
        If oldRowIndex <> -1 Then
            DataGridView1.InvalidateRow(oldRowIndex)
        End If
        oldRowIndex = DataGridView1.CurrentCellAddress.Y

    End Sub

    Private Sub dataGridView1_RowPrePaint(ByVal sender As Object, _
        ByVal e As DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        ' Paints the custom selection background for selected rows.
        
        ' Do not automatically paint the focus rectangle.
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus

        ' Determine whether the cell should be painted with the 
        ' custom selection background.
        If (e.State And DataGridViewElementStates.Selected) = _
            DataGridViewElementStates.Selected Then

            ' Calculate the bounds of the row.
            Dim rowBounds As New Rectangle( _
                0, e.RowBounds.Top, DataGridView1.Columns.GetColumnsWidth( _
                DataGridViewElementStates.Visible) - DataGridView1.HorizontalScrollingOffset + 1, _
                e.RowBounds.Height)

            ' Paint the custom selection background.
            Dim backbrush As New Drawing2D.LinearGradientBrush(rowBounds, DataGridView1.DefaultCellStyle.SelectionBackColor, _
                e.InheritedRowStyle.ForeColor, Drawing2D.LinearGradientMode.Horizontal)
            Try
                e.Graphics.FillRectangle(backbrush, rowBounds)
            Finally
                backbrush.Dispose()
            End Try
        End If

    End Sub

    Private Sub dataGridView1_RowPostPaint(ByVal sender As Object, _
        ByVal e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        ' Paints the content that spans multiple columns and the focus rectangle.

        ' Calculate the bounds of the row.
        Dim rowBounds As New Rectangle(0, _
            e.RowBounds.Top, DataGridView1.Columns.GetColumnsWidth( _
            DataGridViewElementStates.Visible) - DataGridView1.HorizontalScrollingOffset + 1, e.RowBounds.Height)

        Dim forebrush As SolidBrush = Nothing
        Try
            ' Determine the foreground color.
            If (e.State And DataGridViewElementStates.Selected) = _
                DataGridViewElementStates.Selected Then

                forebrush = New SolidBrush(e.InheritedRowStyle.SelectionForeColor)
            Else
                forebrush = New SolidBrush(e.InheritedRowStyle.ForeColor)
            End If

        Finally
            forebrush.Dispose()
        End Try

        If DataGridView1.CurrentCellAddress.Y = e.RowIndex Then
            ' Paint the focus rectangle.
            e.DrawFocus(rowBounds, True)
        End If

    End Sub

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
                                             ByVal e As Windows.Forms.DataGridViewCellFormattingEventArgs) _
                                             Handles DataGridView1.CellFormatting

        ' Changes how cells are displayed depending on their columns and values.

        ' Replace string values in the Priority column with images.
        If DataGridView1.Columns(e.ColumnIndex).Name.Equals("EventImage") AndAlso DataGridView1.Columns.Contains("Type") Then

            ' Ensure that the value is a string.
            Dim stringValue As String = TryCast(DataGridView1.Item("Type", e.RowIndex).Value, String)
            If stringValue Is Nothing Then Return

            ' Set the cell ToolTip to the text value.
            Dim cell As DataGridViewCell = _
                DataGridView1(e.ColumnIndex, e.RowIndex)
            cell.ToolTipText = stringValue

            ' Replace the string value with the image value.
            Select Case stringValue

                Case "Error"
                    e.Value = My.Resources.ErrorGif
                Case "Warning"
                    e.Value = My.Resources.WarningGif
                Case "Information"
                    e.Value = My.Resources.MessageGif

            End Select

        End If

    End Sub
#End Region

End Class
