Public Class IPAddressControl

    Public Shadows Event TextChanged()

    Private _value As String = String.Empty

    Private Sub txtIP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIP1.GotFocus, txtIP2.GotFocus, txtIP3.GotFocus, txtIP4.GotFocus
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        txtBox.SelectAll()
    End Sub

    Private Sub txtIP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIP1.KeyDown, txtIP2.KeyDown, txtIP3.KeyDown, txtIP4.KeyDown
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        Select Case e.KeyData
            Case Keys.Left, Keys.Back
                If txtBox.SelectionStart = 0 Then
                    Me.SelectNextControl(txtBox, False, True, False, False)
                End If

            Case Keys.Right
                If txtBox.SelectionStart = txtBox.TextLength Then
                    Me.SelectNextControl(txtBox, True, True, False, False)
                End If

            Case Keys.Decimal, Keys.OemPeriod
                Me.SelectNextControl(txtBox, True, True, False, False)
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

    'Private Sub txtIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIP1.KeyPress, txtIP2.KeyPress, txtIP3.KeyPress, txtIP4.KeyPress
    '    Dim txtBox As TextBox = DirectCast(sender, TextBox)
    '    'ONLY ALLOW CONTROL CHARS (LIKE BACKSPACE) AND NUMBERS TO BE ENTERED

    '    Select Case Char.GetUnicodeCategory(e.KeyChar)

    '        Case Globalization.UnicodeCategory.Control, Globalization.UnicodeCategory.DecimalDigitNumber

    '        Case Else
    '            e.Handled = True

    '    End Select

    'End Sub


    Private Sub txtIP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIP1.Validating, txtIP2.Validating, txtIP3.Validating, txtIP4.Validating
        Debug.WriteLine("validating part")
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        If txtBox.Text = String.Empty Then Return

        If IsNumeric(txtBox.Text) Then
            If Convert.ToInt32(txtBox.Text) < 256 Then
                txtBox.ForeColor = Me.ForeColor
                Return
            End If
        End If

        Debug.WriteLine("validate part failed")
        txtBox.ForeColor = Color.Red
        e.Cancel = True

    End Sub

    Private Sub txtIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIP1.TextChanged, txtIP2.TextChanged, txtIP3.TextChanged, txtIP4.TextChanged
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        'IF WE TYPED IN 3 DIGITS, SELECT THE NEXT CONTROL
        If txtBox.SelectionStart = 3 Then
            Me.SelectNextControl(txtBox, True, True, False, False)
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

                Dim Octets() As String = value.Split("."c)
                txtIP1.Text = Octets(0)
                txtIP2.Text = Octets(1)
                txtIP3.Text = Octets(2)
                txtIP4.Text = Octets(3)

            Catch ex As Exception

            End Try

            ValidateChildren()
            RaiseEvent TextChanged()
        End Set

    End Property

    Private Sub IPAddress_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
        Debug.WriteLine("validated: " & _value)
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
        Clipboard.SetText(Me.Text)
    End Sub

    Public Sub Paste()
        Me.Text = Clipboard.GetText
    End Sub

End Class
