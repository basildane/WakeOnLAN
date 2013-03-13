' Copyright (c) Microsoft Corporation. All rights reserved.
Imports System.Text.RegularExpressions

Public Class RegExTextBox
    Inherits System.Windows.Forms.TextBox

    ' String representation of the RegEx that will be used to 
    ' validate the text in the TextBox.  This is needed because
    ' the property needs to be exposed as a string to be set
    ' at design time.
    Protected validationPattern As String

    ' Message that should be available if the text does not 
    ' match the pattern.
    Protected mErrorMessage As String

    ' RegEx object that's used to perform the validation.
    Protected mValidationExpression As Regex

    ' Default color to use if the text in the TextBox is not
    ' valid.
    Protected mErrorColor As Color = Color.Red

    ' Allow the developer to set the error message
    ' at design time or run time.
    Public Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
        Set(ByVal Value As String)
            mErrorMessage = Value
        End Set
    End Property

    ' If the TextBox text does not match the RegEx, then it
    ' will be changed to this color.
    Public Property ErrorColor() As Color
        Get
            Return mErrorColor
        End Get
        Set(ByVal Value As Color)
            mErrorColor = Value
        End Set
    End Property

    ' Let's the developer determine if the text in the TextBox
    ' is valid.
    Public ReadOnly Property IsValid() As Boolean
        Get
            If Not mValidationExpression Is Nothing Then
                Return mValidationExpression.IsMatch(Me.Text)
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
            Return validationPattern
        End Get
        Set(ByVal Value As String)
            mValidationExpression = New Regex(Value)
            validationPattern = Value
        End Set
    End Property

    ' If the text does not match the RegEx, then change the
    ' color of the text to the ErrorColor.  If it does match
    ' then make sure it's displayed using the default color.
    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        If Not Me.IsValid Then
            Me.ForeColor = mErrorColor
        Else
            Me.ForeColor = DefaultForeColor
        End If

        ' Any time you inherit a control, and override one of
        ' the On... subs, it's critical that you call the On...
        ' method of the base class, or the control won't fire
        ' events like it's supposed to.
        MyBase.OnValidated(e)
    End Sub

End Class
