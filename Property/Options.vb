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
Imports System.ComponentModel
Imports Microsoft.Win32

Public Class Options
    ReadOnly p As New OptionProperties
    Dim _savedDbPath As String

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        Dim regKey As RegistryKey

        With p
            My.Settings.DefaultTimeout = .Delay
            My.Settings.DefaultMessage = .Shutdown
            My.Settings.emerg_delay = .EmergencyDelay
            My.Settings.emerg_message = .EmergencyShutdown
            My.Settings.Sound = .EnableSound
            My.Settings.Force = .Force
            My.Settings.Reboot = .Reboot
            My.Settings.ShowSplash = .ShowSplash
            My.Settings.dbPath = .dbPath
            My.Settings.autocheckUpdates = .AutoCheck
            My.Settings.Language = .Language
            My.Settings.Threads = .Threads
            My.Settings.repeatInterval = .RepeatInterval
        End With
        My.Settings.Save()
        DialogResult = DialogResult.OK

        Try
            regKey = Registry.CurrentUser.OpenSubKey("Software\Aquila Technology\WakeOnLAN", True)
            regKey.SetValue("RepeatInterval", My.Settings.repeatInterval, RegistryValueKind.DWord)
            regKey.Close()

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Save RepeatInterval to registry.")

        End Try

        If _savedDbPath <> My.Settings.dbPath Then
            Try
                regKey = Registry.CurrentUser.OpenSubKey("Software\Aquila Technology\WakeOnLAN", True)
                regKey.SetValue("Database", IO.Path.GetDirectoryName(My.Settings.dbPath), RegistryValueKind.String)
                regKey.Close()

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Save database path.")

            End Try

            Application.Restart()
        End If

        Dispose()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Dispose()
    End Sub

    Private Sub Options_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        _savedDbPath = My.Settings.dbPath
        LoadOptions()
    End Sub

    Private Sub LoadOptions()

        With p
            .Delay = My.Settings.DefaultTimeout
            .Shutdown = My.Settings.DefaultMessage
            .EmergencyDelay = My.Settings.emerg_delay
            .EmergencyShutdown = My.Settings.emerg_message
            .EnableSound = My.Settings.Sound
            .Force = My.Settings.Force
            .Reboot = My.Settings.Reboot
            .ShowSplash = My.Settings.ShowSplash
            .dbPath = My.Settings.dbPath
            .AutoCheck = My.Settings.autocheckUpdates
            .Language = My.Settings.Language
            .Threads = My.Settings.Threads
            .RepeatInterval = My.Settings.repeatInterval
        End With

        With PropertyGrid1
            .SelectedObject = p
        End With

        OK_Button.Enabled = False
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        OK_Button.Enabled = True
    End Sub

    Private Sub Button_Default_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Default.Click
        If MsgBox(My.Resources.Strings.AreYouSure, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        My.Settings.Reset()
        My.Settings.DefaultMessage = My.Resources.Strings.DefaultMessage
        My.Settings.emerg_message = My.Resources.Strings.DefaultEmergency
        Machines.GetFile()      ' reset the default database path
        LoadOptions()
        OK_Button.Enabled = True
    End Sub


    Private Class OptionProperties
        Inherits GlobalizedObject

        Private _sound As Boolean

        <TypeConverter(GetType(TrueFalseConverter))> _
        <GlobalizedCategory("cat_WOL")> Public Property EnableSound() As Boolean
            Get
                Return _sound
            End Get
            Set(ByVal Value As Boolean)
                _sound = Value
            End Set
        End Property

        Private _Force As Boolean

        <TypeConverter(GetType(TrueFalseConverter))> _
        <GlobalizedCategory("cat_WOL")> Public Property Force() As Boolean
            Get
                Return _Force
            End Get
            Set(ByVal Value As Boolean)
                _Force = Value
            End Set
        End Property

        <TypeConverter(GetType(TrueFalseConverter))> _
        <GlobalizedCategory("cat_WOL")> Public Property Reboot() As Boolean
            Get
                Return _Reboot
            End Get
            Set(value As Boolean)
                _Reboot = value
            End Set
        End Property
        Private _Reboot As Boolean

        <TypeConverter(GetType(TrueFalseConverter))> _
        <GlobalizedCategory("cat_WOL")> Public Property AutoCheck() As Boolean
            Get
                Return _autocheck
            End Get
            Set(value As Boolean)
                _autocheck = value
            End Set
        End Property
        Private _autocheck As Boolean

        Private _RepeatInterval As Integer

        <GlobalizedCategory("cat_WOL")> Public Property RepeatInterval() As Integer
            Get
                Return _RepeatInterval
            End Get
            Set(ByVal Value As Integer)
                _RepeatInterval = Value
            End Set
        End Property

        Private _Shutdown As String

        <GlobalizedCategory("cat_Shutdown")> Public Property Shutdown() As String
            Get
                Return _Shutdown
            End Get
            Set(ByVal Value As String)
                _Shutdown = Value
            End Set
        End Property

        Private _Delay As Integer

        <GlobalizedCategory("cat_Shutdown")> Public Property Delay() As String
            Get
                Return _Delay
            End Get
            Set(ByVal Value As String)
                _Delay = Value
            End Set
        End Property

        Private _emerg_message As String

        <GlobalizedCategory("cat_Emergency")> Public Property EmergencyShutdown() As String
            Get
                Return _emerg_message
            End Get
            Set(ByVal Value As String)
                _emerg_message = Value
            End Set
        End Property

        Private _emerg_delay As Integer

        <GlobalizedCategory("cat_Emergency")> Public Property EmergencyDelay() As Integer
            Get
                Return _emerg_delay
            End Get
            Set(ByVal Value As Integer)
                _emerg_delay = Value
            End Set
        End Property

        '<GlobalizedCategory("cat_Application"), ReadOnlyAttribute(True)> Public ReadOnly Property AppVersion() As String
        '    Get
        '        Return My.Application.Info.Version.ToString
        '    End Get
        'End Property

        '<GlobalizedCategory("cat_Application"), ReadOnlyAttribute(True)> Public ReadOnly Property Language() As String
        '    Get
        '        Return Globalization.CultureInfo.CurrentUICulture.DisplayName.ToString
        '    End Get
        'End Property

        <GlobalizedCategory("cat_Application"), ReadOnlyAttribute(True)> Public ReadOnly Property Culture() As String
            Get
                Return Globalization.CultureInfo.CurrentUICulture.Name
            End Get
        End Property

        ' References: System.Design
        Private _dbPath As String

        <GlobalizedCategory("cat_Application"), Editor(GetType(Windows.Forms.Design.FileNameEditor), _
                                                       GetType(Drawing.Design.UITypeEditor))> Public Property dbPath() As String
            Get
                Return _dbPath
            End Get
            Set(ByVal Value As String)
                _dbPath = Value
            End Set
        End Property

        <TypeConverter(GetType(TrueFalseConverter))>
        <GlobalizedCategory("cat_Application")> Public Property ShowSplash() As Boolean
            Get
                Return _showSplash
            End Get
            Set(value As Boolean)
                _showSplash = value
            End Set
        End Property
        Private _showSplash As Boolean

        Private _language As String
        <GlobalizedCategory("cat_Application"), _
            TypeConverter(GetType(Countries)), _
            Editor(GetType(LanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Property Language() As String
            Get
                Return _language
            End Get
            Set(ByVal Value As String)
                _language = Value
            End Set
        End Property

        Private _threads As Integer
        <GlobalizedCategory("cat_Application")> Public Property Threads() As Integer
            Get
                Return _threads
            End Get
            Set(ByVal Value As Integer)
                _threads = Value
            End Set
        End Property

    End Class

End Class


Class TrueFalseConverter
    Inherits BooleanConverter
    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object, destinationType As Type) As Object
        If TypeOf value Is Boolean AndAlso destinationType = GetType(String) Then
            Return _values(If(CBool(value), 1, 0))
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object) As Object
        Dim txt As String = TryCast(value, String)
        If _values(0) = txt Then
            Return False
        End If
        If _values(1) = txt Then
            Return True
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Private ReadOnly _values As String() = New String() {My.Resources.Strings.lit_false, My.Resources.Strings.lit_true}
End Class

'End Namespace
