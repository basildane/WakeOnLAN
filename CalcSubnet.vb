Imports System.Net

Public Class CalcSubnet
    Dim p As Properties

    Private Sub CalcSubnet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        p = Me.Owner

        IpIP.Text = p.IP.Text
        IpBroadcast.Text = ""
        IpSubnet.Text = "255.255.255.255"

    End Sub

    Private Function GetBroadcastAddress(address As IPAddress, subnetMask As IPAddress) As IPAddress
        Dim ipAdressBytes As Byte() = address.GetAddressBytes()
        Dim subnetMaskBytes As Byte() = subnetMask.GetAddressBytes()

        If ipAdressBytes.Length <> subnetMaskBytes.Length Then
            Throw New ArgumentException("Lengths of IP address and subnet mask do not match.")
        End If

        Dim broadcastAddress As Byte() = New Byte(ipAdressBytes.Length - 1) {}
        For i As Integer = 0 To broadcastAddress.Length - 1
            broadcastAddress(i) = CByte(ipAdressBytes(i) Or (subnetMaskBytes(i) Xor 255))
        Next

        Return New IPAddress(broadcastAddress)
    End Function


    Private Sub bCalculate_Click(sender As System.Object, e As System.EventArgs) Handles bCalculate.Click
        Try
            If (IpSubnet.Text = "255.255.255.255") Then
                IpBroadcast.Text = "255.255.255.255"
            Else
                IpBroadcast.Text = GetBroadcastAddress(IPAddress.Parse(IpIP.Text), IPAddress.Parse(IpSubnet.Text)).ToString()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub bOK_Click(sender As System.Object, e As System.EventArgs) Handles bOK.Click
        p.Broadcast.Text = IpBroadcast.Text
        Me.Close()
    End Sub
End Class