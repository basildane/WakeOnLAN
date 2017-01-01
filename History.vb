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

Imports System.Globalization

Public Class History

    Public Property cultureInfo() As CultureInfo

    Private Sub History_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub History_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        EventLogViewer1.Source = My.Application.Info.ProductName
        EventLogViewer1.Populate()
    End Sub

End Class