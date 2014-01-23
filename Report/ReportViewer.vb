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

Imports Microsoft.Reporting.WinForms

Public Class ReportViewer

    Private Sub ReportViewr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p(8) As ReportParameter

        p(0) = New ReportParameter("ReportParameterName", My.Resources.ReportStrings.RepName.ToString, True)
        p(1) = New ReportParameter("ReportParameterGroup", My.Resources.Strings.AllMachines.ToString, True)
        p(2) = New ReportParameter("ReportParameterTitle", My.Resources.Strings.Title.ToString, True)
        p(3) = New ReportParameter("ReportParameterIP", My.Resources.ReportStrings.RepIP.ToString, True)
        p(4) = New ReportParameter("ReportParameterMAC", My.Resources.ReportStrings.RepMAC.ToString, True)
        p(5) = New ReportParameter("ReportParameterNetbios", My.Resources.ReportStrings.RepNetbios.ToString, True)
        p(6) = New ReportParameter("ReportParameterEmergency", My.Resources.ReportStrings.RepEmergency.ToString, True)
        p(7) = New ReportParameter("ReportParameterShutdown", My.Resources.ReportStrings.RepShutdown.ToString, True)
        p(8) = New ReportParameter("ReportParameterBroadcast", My.Resources.ReportStrings.RepBroadcast.ToString, True)

        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("MachinesDS", Machines))
            .ReportEmbeddedResource = "WakeOnLan.Report1.rdlc"
            .SetParameters(p)
        End With

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class