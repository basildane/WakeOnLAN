'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2015 Aquila Technology, LLC. <webmaster@aquilatech.com>
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
Imports System.Drawing.Design
Imports System.Globalization

Public Class Countries : Inherits System.ComponentModel.StringConverter

    Declare Function IsValidLocale Lib "kernel32" (ByVal locale As Integer, ByVal dwFlags As Integer) As Integer

    Const LCID_INSTALLED As Long = &H1 '-- is locale present?

    ReadOnly _countryCodes As String() = New String() _
        {
            "pt-BR",
            "de-DE",
            "fr-FR",
            "hu-HU",
            "nl-NL",
            "en-US",
            "ru-RU",
            "ro-RO",
            "fi-FI",
            "zh-TW"
        }

    ReadOnly _countryNames(9) As String

    Public Sub New()
        Dim cultureInfo As CultureInfo
        Dim i As Integer = 0

        For Each s As String In _countryCodes
            cultureInfo = New CultureInfo(s)
            If IsValidLocale(cultureInfo.LCID, LCID_INSTALLED) Then
                _countryNames(i) = cultureInfo.NativeName
            Else
                _countryNames(i) = cultureInfo.EnglishName
            End If
            i += 1
        Next
    End Sub

    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(_countryCodes)
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
        If TypeOf value Is String AndAlso destinationType = GetType(String) Then
            For i As Integer = 0 To _countryCodes.Length - 1
                If (_countryCodes(i) = value) Then
                    Return _countryNames(i)
                End If
            Next
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) As Object
        Dim txt As String = TryCast(value, String)

        For i As Integer = 0 To _countryCodes.Length - 1
            If (_countryNames(i) = txt) Then
                Return _countryCodes(i)
            End If
        Next
        Return MyBase.ConvertFrom(context, culture, value)
    End Function

End Class


Public Class LanguageEditor : Inherits UITypeEditor

    Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
        'Set to true to implement the PaintValue method
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        Dim newImage As Bitmap

        If IsNothing(e.Value) Then Return

        Select Case (e.Value.ToString())
            Case "pt-BR"
                newImage = My.Resources.Flags.Brazil
            Case "de-DE"
                newImage = My.Resources.Flags.Germany
            Case "fr-FR"
                newImage = My.Resources.Flags.France
            Case "hu-HU"
                newImage = My.Resources.Flags.Hungary
            Case "nl-NL"
                newImage = My.Resources.Flags.Netherlands
            Case "en-US"
                newImage = My.Resources.Flags.USA
            Case "ru-RU"
                newImage = My.Resources.Flags.Russia
            Case "ro-RO"
                newImage = My.Resources.Flags.Romania
            Case "fi-FI"
                newImage = My.Resources.Flags.Finland
            Case "zh-TW"
                newImage = My.Resources.Flags.Taiwan
            Case Else
                Return
        End Select

        Dim destRect As Rectangle = e.Bounds
        newImage.MakeTransparent()
        e.Graphics.DrawImage(newImage, destRect)
    End Sub

End Class
