Imports System.ComponentModel

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

Namespace Controls
    Public Class IpAddressControl

        Public Shadows Event TextChanged()

        Private _value As String = String.Empty

        ' Message that should be available if the text does not 
        ' match the pattern.
        Private _errorMessage As String

        ' Allow the developer to set the error message
        ' at design time or run time.
        <Localizable(True)> _
        Public Property ErrorMessage() As String
            Get
                Return _errorMessage
            End Get
            Set(ByVal value As String)
                _errorMessage = value
            End Set
        End Property

        Private Sub txtIP_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtIP1.GotFocus, txtIP2.GotFocus, txtIP3.GotFocus, txtIP4.GotFocus
            Dim txtBox As TextBox = DirectCast(sender, TextBox)

            txtBox.SelectAll()
        End Sub

        Private Sub txtIP_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles txtIP1.KeyDown, txtIP2.KeyDown, txtIP3.KeyDown, txtIP4.KeyDown
            Dim txtBox As TextBox = DirectCast(sender, TextBox)

            Select Case e.KeyData
                Case Keys.Left, Keys.Back
                    If txtBox.SelectionStart = 0 Then
                        SelectNextControl(txtBox, False, True, False, False)
                    End If

                Case Keys.Right
                    If txtBox.SelectionStart = txtBox.TextLength Then
                        SelectNextControl(txtBox, True, True, False, False)
                    End If

                Case Keys.Decimal, Keys.OemPeriod
                    SelectNextControl(txtBox, True, True, False, False)
                    e.SuppressKeyPress = True

                Case Keys.Control + Keys.C
                    Copy()
                    e.SuppressKeyPress = True

                Case Keys.Control + Keys.V
                    Paste()
                    e.SuppressKeyPress = True

                Case Keys.Control + Keys.Z
                    txtBox.Undo()
                    e.SuppressKeyPress = True

                Case Keys.Delete

                Case Keys.D0 To Keys.D9, Keys.NumPad0 To Keys.NumPad9

                Case Else
                    e.SuppressKeyPress = True

            End Select

        End Sub

        Private Sub txtIP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIP1.Validating, txtIP2.Validating, txtIP3.Validating, txtIP4.Validating
            Dim txtBox As TextBox = DirectCast(sender, TextBox)

            If txtBox.Text = String.Empty Then Return

            If IsNumeric(txtBox.Text) Then
                If Convert.ToInt32(txtBox.Text) < 256 Then
                    txtBox.ForeColor = ForeColor
                    Return
                End If
            End If

            txtBox.ForeColor = Color.Red
            e.Cancel = True

        End Sub

        Private Sub txtIP_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtIP1.TextChanged, txtIP2.TextChanged, txtIP3.TextChanged, txtIP4.TextChanged
            Dim txtBox As TextBox = DirectCast(sender, TextBox)

            'IF WE TYPED IN 3 DIGITS, SELECT THE NEXT CONTROL
            If txtBox.SelectionStart = 3 Then
                SelectNextControl(txtBox, True, True, False, False)
            End If

        End Sub

        Public Overrides Property Text() As String
            Get
                Return _value
            End Get

            Set(ByVal value As String)
                _value = value

                Try
                    txtIP1.Text = ""
                    txtIP2.Text = ""
                    txtIP3.Text = ""
                    txtIP4.Text = ""

                    Dim octets() As String = value.Split("."c)
                    txtIP1.Text = octets(0)
                    txtIP2.Text = octets(1)
                    txtIP3.Text = octets(2)
                    txtIP4.Text = octets(3)

                Catch ex As Exception

                End Try

                ValidateChildren()
                RaiseEvent TextChanged()
            End Set

        End Property

        Private Sub IPAddress_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Validated
            RaiseEvent TextChanged()
        End Sub

        Public ReadOnly Property IsValid() As Boolean
            Get
                If _value = "" Then
                    Return True
                End If

                If System.Text.RegularExpressions.Regex.IsMatch(_value, "^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$") Then
                    Return True
                End If

                Return False
            End Get
        End Property


        Private Sub IPAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
            If txtIP1.Text = "" And txtIP2.Text = "" And txtIP3.Text = "" And txtIP4.Text = "" Then
                _value = ""
            Else
                If IsNumeric(txtIP1.Text) Then txtIP1.Text = Convert.ToString(Convert.ToInt32(txtIP1.Text))
                If IsNumeric(txtIP2.Text) Then txtIP2.Text = Convert.ToString(Convert.ToInt32(txtIP2.Text))
                If IsNumeric(txtIP3.Text) Then txtIP3.Text = Convert.ToString(Convert.ToInt32(txtIP3.Text))
                If IsNumeric(txtIP4.Text) Then txtIP4.Text = Convert.ToString(Convert.ToInt32(txtIP4.Text))

                _value = String.Format("{0}.{1}.{2}.{3}", New String() {txtIP1.Text, txtIP2.Text, txtIP3.Text, txtIP4.Text})
            End If

            e.Cancel = Not IsValid
        End Sub

        Public Sub Copy()
            Clipboard.SetText(Text)
        End Sub

        Public Sub Paste()
            Text = Clipboard.GetText
        End Sub

    End Class
End Namespace