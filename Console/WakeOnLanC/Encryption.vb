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

Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.Win32

Public Class Encryption

    Private key() As Byte
    Private IV() As Byte
    Private Const padding As PaddingMode = PaddingMode.PKCS7

    Sub New()
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Aquila Technology\WakeOnLAN", True)

        If key Is Nothing Then
            Try
                key = regKey.GetValue("Key", Nothing)
                IV = regKey.GetValue("IV", Nothing)

                If key Is Nothing Or IV Is Nothing Then
                    Using myAes As Aes = Aes.Create()
                        myAes.Padding = padding
                        key = myAes.Key
                        regKey.SetValue("Key", key, RegistryValueKind.Binary)
                        IV = myAes.IV
                        regKey.SetValue("IV", IV, RegistryValueKind.Binary)
                    End Using

                End If

            Catch ex As Exception

            End Try
            regKey.Close()

        End If
    End Sub

    Function Encrypt(Original As String) As String
        ' Encrypt the string to an array of bytes.
        Dim encrypted As Byte() = EncryptStringToBytes_Aes(Original)
        Return Convert.ToBase64String(encrypted)
    End Function

    Function Decrypt(Encrypted As String) As String
        Try
            Dim bytes As Byte() = Convert.FromBase64String(Encrypted)

            Dim decrypted As String = DecryptStringFromBytes_Aes(bytes)
            Return decrypted

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Private Function EncryptStringToBytes_Aes(ByVal plainText As String) As Byte()
        Dim encrypted() As Byte
        ' Create an Aes object
        ' with the specified key and IV.
        Using aesAlg As Aes = Aes.Create()
            aesAlg.Padding = padding
            aesAlg.Key = key
            aesAlg.IV = IV

            ' Create a decrytor to perform the stream transform.
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)

                        'Write all data to the stream.
                        swEncrypt.Write(plainText)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using

        ' Return the encrypted bytes from the memory stream.
        Return encrypted

    End Function 'EncryptStringToBytes_Aes

    Private Function DecryptStringFromBytes_Aes(ByVal cipherText() As Byte) As String
        ' Declare the string used to hold
        ' the decrypted text.
        Dim plaintext As String = Nothing

        ' Create an Aes object
        ' with the specified key and IV.
        Try
            Using aesAlg As Aes = Aes.Create()
                aesAlg.Padding = padding
                aesAlg.Key = key
                aesAlg.IV = IV

                ' Create a decrytor to perform the stream transform.
                Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

                ' Create the streams used for decryption.
                Using msDecrypt As New MemoryStream(cipherText)

                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

                        Using srDecrypt As New StreamReader(csDecrypt)
                            ' Read the decrypted bytes from the decrypting stream
                            ' and place them in a string.
                            plaintext = srDecrypt.ReadToEnd()
                        End Using

                    End Using
                End Using
            End Using

        Catch ex As Exception
            plaintext = ""

        End Try

        Return plaintext

    End Function 'DecryptStringFromBytes_Aes 

End Class
