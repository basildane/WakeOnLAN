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

Imports System.Text.RegularExpressions
Imports System.ComponentModel

Namespace Controls

    Public Class RegExTextBox
        Inherits Windows.Forms.TextBox

        ' String representation of the RegEx that will be used to 
        ' validate the text in the TextBox.  This is needed because
        ' the property needs to be exposed as a string to be set
        ' at design time.
        Private _validationPattern As String

        ' Message that should be available if the text does not 
        ' match the pattern.
        Private _errorMessage As String

        ' RegEx object that's used to perform the validation.
        Private _validationExpression As Regex

        ' Default color to use if the text in the TextBox is not
        ' valid.
        Private _errorColor As Color = Color.Red

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

        ' If the TextBox text does not match the RegEx, then it
        ' will be changed to this color.
        Public Property ErrorColor() As Color
            Get
                Return _errorColor
            End Get
            Set(ByVal value As Color)
                _errorColor = value
            End Set
        End Property

        ' Let's the developer determine if the text in the TextBox
        ' is valid.
        Public ReadOnly Property IsValid() As Boolean
            Get
                If Not _validationExpression Is Nothing Then
                    Return _validationExpression.IsMatch(Text)
                Else
                    Return True
                End If
            End Get
        End Property

        ' Lets the developer specify the regular expression (as
        ' a string) that will be used to validate the text in the
        ' TextBox.  It's important that this be setable as a string
        ' (vs. a RegEx object) so that the developer can specify 
        ' the RegEx pattern using the properties window.
        Public Property ValidationExpression() As String
            Get
                Return _validationPattern
            End Get
            Set(ByVal value As String)
                _validationExpression = New Regex(value)
                _validationPattern = value
            End Set
        End Property

        ' If the text does not match the RegEx, then change the
        ' color of the text to the ErrorColor.  If it does match
        ' then make sure it's displayed using the default color.
        Protected Overrides Sub OnValidated(ByVal e As EventArgs)
            If Not IsValid Then
                ForeColor = _errorColor
            Else
                ForeColor = DefaultForeColor
            End If

            ' Any time you inherit a control, and override one of
            ' the On... subs, it's critical that you call the On...
            ' method of the base class, or the control won't fire
            ' events like it's supposed to.
            MyBase.OnValidated(e)
        End Sub

        Private Sub InitializeComponent()
            SuspendLayout()
            ResumeLayout(False)

        End Sub
    End Class
End Namespace