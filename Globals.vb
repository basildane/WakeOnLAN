'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2017 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

Imports System.Linq
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Net

Module Globals
	Private Declare Function FormatMessageA Lib "kernel32" (ByVal flags As Integer, ByRef source As Object, ByVal messageID As Integer, ByVal languageID As Integer, ByVal buffer As String, ByVal size As Integer, ByRef arguments As Integer) As Integer
	Public Declare Function SendARP Lib "iphlpapi.dll" (ByVal DestIP As Int32, ByVal SrcIP As Int32, ByVal pMacAddr As Byte(), ByRef PhyAddrLen As Integer) As Integer

	<DllImport("user32.dll")>
	Public Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
	End Function

	Public ShutdownMode As Boolean      'true if in shutdown mode, false if in abort mode
	Public CurrentItem As ListViewItem

	Public Sub ShowHelp(parent As Control, url As String)
		Try
#If DEBUG Then
			Help.ShowHelp(parent, "file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\help\" + url))
#Else
            Help.ShowHelp(parent, "file:///" + AppDomain.CurrentDomain.BaseDirectory + "help\" + url)
#End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Help Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	Public Function SaveListViewState(ByVal listview As ListView) As String
		Return listview.Columns.Cast(Of ColumnHeader)().Aggregate("", Function(current, c) current & (c.Width & " "))
	End Function

	Public Sub GetListViewState(ByVal listview As ListView, ByVal state As String)
		Dim s() As String
		Dim i As Int16

		s = Split(state)
		If (UBound(s) <> listview.Columns.Count) Then Exit Sub

		For i = 0 To UBound(s) - 1
			listview.Columns(i).Width = Int(s(i))
		Next
	End Sub

	Public Function FormatMessage(ByVal [error] As Integer) As String
		Const FORMAT_MESSAGE_FROM_SYSTEM As UInteger = &H1000
		Const LANG_NEUTRAL As Integer = &H0
		Const bufferLen As Integer = 1024
		Dim buffer As String = Space(bufferLen)

		FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, [error], LANG_NEUTRAL, buffer, bufferLen, IntPtr.Zero)
		buffer = Replace(Replace(buffer, Chr(13), ""), Chr(10), "")
		If buffer.Contains(Chr(0)) Then
			buffer = buffer.Substring(0, buffer.IndexOf(Chr(0)))
		Else
			buffer = String.Empty
		End If
		Return buffer
	End Function

	Public Function IpToInt(address As IPAddress) As UInt32
		Dim bytes As Byte() = address.GetAddressBytes()

		If BitConverter.IsLittleEndian Then
			Array.Reverse(bytes)
		End If
		Dim num As UInt32 = BitConverter.ToUInt32(bytes, 0)
		Return num
	End Function

	Public Function IpToInt(address As String) As UInt32
		Dim _address As IPAddress = Nothing

		If (IPAddress.TryParse(address, _address)) Then
			Return IpToInt(_address)
		Else
			Return 0
		End If
	End Function

	Public Function CompareMac(mac1 As String, mac2 As String) As Int32

		Try
			Dim _mac1 As String = Replace(mac1, ":", "")
			_mac1 = Replace(_mac1, "-", "")

			Dim _mac2 As String = Replace(mac2, ":", "")
			_mac2 = Replace(_mac2, "-", "")

			Return StrComp(_mac1, _mac2, CompareMethod.Text)

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "compareMAC")

		End Try

	End Function

	''' <summary>
	''' Returns TRUE if form is on screen.
	''' </summary>
	''' <param name="form">The form to test</param>
	''' <returns>Boolean</returns>
	Public Function IsOnScreen(form As Form) As Boolean
		Const margin As Integer = 100
		If form.Left < 0 Or form.Top < 0 Then Return False
		Dim formRectangle As New Rectangle(form.Left + margin, form.Top + margin, form.Width, form.Height)

		Return Screen.AllScreens.Any(Function(s) s.WorkingArea.IntersectsWith(formRectangle))
	End Function

	''' <summary>
	''' Centers a given form on the screen.
	''' </summary>
	''' <param name="form">The form to center</param>
	Public Sub CenterForm(form As Form)
		form.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (form.Height \ 2)
		form.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (form.Width \ 2)
	End Sub

End Module
