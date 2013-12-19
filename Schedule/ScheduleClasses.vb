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

Imports System.Xml.Serialization

Public Class Task
    Default Public ReadOnly Property Item(ByVal Name As String) As String
        Get
            Return Name
        End Get
    End Property

    Public Name As String = ""
    Public Description As String = ""
    Public Triggers As New Triggers
    Public Actions As New Actions

    Public Function Serialize() As String
        Dim serializer As New XmlSerializer(GetType(Task))
        Dim mstream As New IO.MemoryStream
        Dim xmltextwriter As New Xml.XmlTextWriter(mstream, System.Text.Encoding.UTF8)

        serializer.Serialize(xmltextwriter, Me)
        mstream = xmltextwriter.BaseStream
        Debug.WriteLine(System.Text.UTF8Encoding.UTF8.GetString(mstream.ToArray))
        Return System.Text.UTF8Encoding.UTF8.GetString(mstream.ToArray)
    End Function

    Public Function Deserialize(ByVal Data As String) As Task
        Dim serializer As New XmlSerializer(GetType(Task))
        Dim mstream As New IO.MemoryStream
        Dim xmltextwriter As New Xml.XmlTextWriter(mstream, System.Text.Encoding.UTF8)

        Try
            mstream = New IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(Data))
            Return serializer.Deserialize(mstream)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Resources.Strings.lit_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing

        End Try

    End Function

End Class

Public Class Triggers
    Inherits CollectionBase

    Default Public ReadOnly Property Item(ByVal Index As Integer) As Trigger
        Get
            Return List.Item(Index)
        End Get
    End Property

    Public Sub Add(ByVal Trigger As Trigger)
        List.Add(Trigger)
    End Sub

End Class

Public Class Trigger
    Public Enum TriggerModes
        OneTime
        Daily
        Weekly
        Monthly
    End Enum

    Public Tag As String

    Public Mode As TriggerModes
    Public StartBoundary As DateTime
    Public Enabled As Boolean = True
    Public Daily_Recurs As Integer = 0
    Public Weekly_Recurs As Integer = 0
    Public Weekly_DaysOfWeek As Integer = 0

    Public Overrides Function ToString() As String
        Select Case Mode
            Case Trigger.TriggerModes.OneTime
                Return String.Format(My.Resources.Strings.lit_at, StartBoundary.ToShortDateString, StartBoundary.ToShortTimeString)

            Case Trigger.TriggerModes.Daily
                Return String.Format(My.Resources.Strings.lit_atDays, StartBoundary.ToShortTimeString, Daily_Recurs)

            Case Trigger.TriggerModes.Weekly
                Dim s As String = ""

                If Weekly_DaysOfWeek >= 127 Then
                    s = "weekday"
                Else
                    For i As Integer = 1 To 7
                        If (CInt(2 ^ (i - 1)) And Weekly_DaysOfWeek) > 0 Then
                            s &= WeekdayName(i, True) & ","
                        End If
                    Next
                End If
                s = s.TrimEnd(","c)
                Return String.Format(My.Resources.Strings.lit_atWeeks, StartBoundary.ToShortTimeString, s, Weekly_Recurs, StartBoundary.ToShortDateString)

            Case TriggerModes.Monthly
                Return ""
                'TODO: finish

            Case Else
                Return My.Resources.Strings.lit_Unknown

        End Select

    End Function

End Class

Public Class Actions
    Inherits CollectionBase

    Default Public ReadOnly Property Item(ByVal Index As Integer) As Action
        Get
            Return List.Item(Index)
        End Get
    End Property

    Public Sub Add(ByVal Action As Action)
        List.Add(Action)
    End Sub

End Class

Public Class Action
    Public ReadOnly ActionStrings() As String =
        {
        My.Resources.Strings.actions_start,
        My.Resources.Strings.actions_startAll,
        My.Resources.Strings.actions_shutdown,
        My.Resources.Strings.actions_shutdownAll,
        My.Resources.Strings.actions_popup,
        My.Resources.Strings.actions_email,
        My.Resources.Strings.actions_sleep,
        My.Resources.Strings.actions_sleepAll,
        My.Resources.Strings.actions_hibernate,
        My.Resources.Strings.actions_hibernateAll
        }

    Public Enum ActionItems
        Start
        StartAll
        Shutdown
        ShutdownAll
        SendMessage
        SendEmail
        Sleep
        SleepAll
        Hibernate
        HibernateAll
    End Enum

    Public Name As String
    Public Mode As ActionItems
    Public Force As Boolean

    Public EmailFrom As String = ""
    Public EmailTo As String = ""
    Public EmailSubject As String = ""
    Public EmailText As String = ""
    Public EmailServer As String = ""

    Public MessageTitle As String = ""
    Public MessageText As String = ""

    Public Tag As String = ""

End Class