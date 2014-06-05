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

Imports System.Reflection
Imports System.Linq
Imports AutoUpdaterDotNET

Public NotInheritable Class AboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        LabelProductName.Text = My.Resources.Strings.Title
        LabelVersion.Text = System.String.Format(My.Resources.Strings.Version, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        LabelCopyright.Text = My.Application.Info.Copyright

        LabelVersion.Text &= " (" & My.Application.Info.Version.Revision & ")"

#If DEBUG Then
        LabelVersion.Text &= " [DEBUG]"
#End If

        ListBox1.Items.Clear()
        For Each a As AssemblyName In Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToArray()
            ListBox1.Items.Add(String.Format("{0}, version: {1}", a.Name, a.Version))
        Next

        AutoUpdater.CurrentCulture = Application.CurrentCulture
        AutoUpdater.AppCastURL = My.Settings.updateURL
        AutoUpdater.versionURL = My.Settings.updateVersions
        AddHandler AutoUpdater.UpdateStatus, AddressOf updateStatus
        AutoUpdater.Start(0)
    End Sub

    Private Delegate Sub UpdateStatusHandler(sender As Object, e As AutoUpdateEventArgs)

    Private Sub UpdateStatus(sender As Object, e As AutoUpdateEventArgs)
        If (InvokeRequired) Then
            BeginInvoke(New UpdateStatusHandler(AddressOf updateStatus), New Object() {sender, e})
            Return
        End If

        Select Case (e.status)
            Case AutoUpdateEventArgs.statusCodes.checking
                pbUpdate.Image = My.Resources.system_software_update

            Case AutoUpdateEventArgs.statusCodes.error
                pbUpdate.Image = My.Resources.error2

            Case AutoUpdateEventArgs.statusCodes.updateAvailable
                pbUpdate.Image = My.Resources.software_update_available

            Case Else
                pbUpdate.Image = My.Resources.emblem_ok

        End Select

        lAutomaticUpdate.Text = e.text
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OKButton.Click
        Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start(LinkLabel2.Text)
    End Sub

    Private Sub bDonate_Click(sender As Object, e As EventArgs) Handles bDonate.Click
        Process.Start(My.Settings.donate)
    End Sub

End Class
