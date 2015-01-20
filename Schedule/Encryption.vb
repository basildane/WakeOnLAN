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

Public Class Encryption
    Private _sEncryptPassword As String = "Password1"

    Sub New(ByVal Password As String)
        _sEncryptPassword = Password
    End Sub

    Function EnigmaEncrypt(ByVal Message As String) As String
        Dim NewsAscii As Double
        Dim MessageLength As Integer
        Dim PasswordLength As Integer
        Dim Index As Integer
        Dim Ascii As Short
        Dim Key As Short
        Dim NewAscii As Double
        Dim sEncrypted As String = ""

        If Message = "" Or _sEncryptPassword = "" Then
            Return Message
        End If

        MessageLength = Len(Message)
        PasswordLength = Len(_sEncryptPassword)
        For Index = 1 To MessageLength
            Ascii = Asc(Mid(Message, Index, 1))
            Key = Asc(Mid(_sEncryptPassword, Index Mod PasswordLength + 1, 1))
            NewAscii = Ascii + Key
            If NewAscii > 255 Then NewAscii = NewsAscii - 255
            sEncrypted &= Right("0" & Hex(NewAscii), 2)
        Next
        Return sEncrypted
    End Function

    Function EnigmaDecrypt(ByVal Message As String) As String
        Dim NewsAscii As Byte
        Dim MessageLength As Integer
        Dim PasswordLength As Integer
        Dim Index As Integer
        Dim Ascii As Short
        Dim Key As Short
        Dim NewAscii As Integer
        Dim sDecrypt As String = ""

        If Message = "" Or _sEncryptPassword = "" Then
            Return Message
        End If

        MessageLength = Len(CStr(Message)) \ 2
        PasswordLength = Len(_sEncryptPassword)
        On Error Resume Next
        For Index = 1 To MessageLength
            Ascii = CShort("&h" & Mid(Message, ((Index - 1) * 2) + 1, 2))
            Key = Asc(Mid(_sEncryptPassword, Index Mod PasswordLength + 1, 1))
            NewAscii = Ascii - Key
            If NewAscii < 0 Then NewAscii = NewsAscii + 255
            sDecrypt &= Chr(NewAscii)
        Next
        Return sDecrypt
    End Function

End Class
