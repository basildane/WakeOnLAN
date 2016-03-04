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

Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports WOL.AquilaWolLibrary

' An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
<StructLayout(LayoutKind.Sequential, Pack:=1)> _
Friend Structure LUID
    Public LowPart As Integer
    Public HighPart As Integer
End Structure

' The LUID_AND_ATTRIBUTES structure represents a locally unique identifier (LUID) and its attributes.
<StructLayout(LayoutKind.Sequential, Pack:=1)> _
Friend Structure LUID_AND_ATTRIBUTES
    Public pLuid As LUID
    Public Attributes As Integer    ' Specifies attributes of the LUID. This value contains up to 32 one-bit flags. Its meaning is dependent on the definition and use of the LUID.
End Structure

' The TOKEN_PRIVILEGES structure contains information about a set of privileges for an access token.
<StructLayout(LayoutKind.Sequential, Pack:=1)> _
Friend Structure TOKEN_PRIVILEGES
    ' Specifies the number of entries in the Privileges array.
    Public PrivilegeCount As Integer
    ' Specifies an array of LUID_AND_ATTRIBUTES structures. Each structure contains the LUID and attributes of a privilege.
    Public Privileges As LUID_AND_ATTRIBUTES
End Structure

' Implements methods to exit Windows.
Friend Class LocalShutdown
    ' <summary>Required to enable or disable the privileges in an access token.</summary>
    Private Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20

    ' <summary>Required to query an access token.</summary>
    Private Const TOKEN_QUERY As Integer = &H8

    ' <summary>The privilege is enabled.</summary>
    Private Const SE_PRIVILEGE_ENABLED As Integer = &H2

    ' The LoadLibrary function maps the specified executable module into the address space of the calling process.
    ' <param name="lpLibFileName">Pointer to a null-terminated string that names the executable module (either a .dll or .exe file). The name specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.</param>
    ' <returns>If the function succeeds, the return value is a handle to the module.<br></br><br>If the function fails, the return value is NULL. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
    Private Declare Ansi Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As IntPtr

    ' The FreeLibrary function decrements the reference count of the loaded dynamic-link library (DLL). When the reference count reaches zero, the module is unmapped from the address space of the calling process and the handle is no longer valid.
    ' <param name="hLibModule">Handle to the loaded DLL module. The LoadLibrary or GetModuleHandle function returns this handle.</param>
    ' <returns>If the function succeeds, the return value is nonzero.<br></br><br>If the function fails, the return value is zero. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
    Private Declare Ansi Function FreeLibrary Lib "kernel32" (ByVal hLibModule As IntPtr) As Integer

    ' The GetProcAddress function retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
    ' <param name="hModule">Handle to the DLL module that contains the function or variable. The LoadLibrary or GetModuleHandle function returns this handle.</param>
    ' <param name="lpProcName">Pointer to a null-terminated string containing the function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
    ' <returns>If the function succeeds, the return value is the address of the exported function or variable.<br></br><br>If the function fails, the return value is NULL. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
    Private Declare Ansi Function GetProcAddress Lib "kernel32" (ByVal hModule As IntPtr, ByVal lpProcName As String) As IntPtr

    ' The OpenProcessToken function opens the access token associated with a process.
    ' <param name="ProcessHandle">Handle to the process whose access token is opened.</param>
    ' <param name="DesiredAccess">Specifies an access mask that specifies the requested types of access to the access token. These requested access types are compared with the token's discretionary access-control list (DACL) to determine which accesses are granted or denied.</param>
    ' <param name="TokenHandle">Pointer to a handle identifying the newly-opened access token when the function returns.</param>
    ' <returns>If the function succeeds, the return value is nonzero.<br></br><br>If the function fails, the return value is zero. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
    Private Declare Ansi Function OpenProcessToken Lib "advapi32" (ByVal ProcessHandle As IntPtr, ByVal DesiredAccess As Integer, ByRef TokenHandle As IntPtr) As Integer

    ' The LookupPrivilegeValue function retrieves the locally unique identifier (LUID) used on a specified system to locally represent the specified privilege name.
    ' <param name="lpSystemName">Pointer to a null-terminated string specifying the name of the system on which the privilege name is looked up. If a null string is specified, the function attempts to find the privilege name on the local system.</param>
    ' <param name="lpName">Pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file. For example, this parameter could specify the constant SE_SECURITY_NAME, or its corresponding string, "SeSecurityPrivilege".</param>
    ' <param name="lpLuid">Pointer to a variable that receives the locally unique identifier by which the privilege is known on the system, specified by the lpSystemName parameter.</param>
    ' <returns>If the function succeeds, the return value is nonzero.<br></br><br>If the function fails, the return value is zero. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
    Private Declare Ansi Function LookupPrivilegeValue Lib "advapi32" Alias "LookupPrivilegeValueA" (ByVal lpSystemName As String, ByVal lpName As String, ByRef lpLuid As LUID) As Integer

    ' The AdjustTokenPrivileges function enables or disables privileges in the specified access token. Enabling or disabling privileges in an access token requires TOKEN_ADJUST_PRIVILEGES access.
    ' <param name="TokenHandle">Handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to the token. If the PreviousState parameter is not NULL, the handle must also have TOKEN_QUERY access.</param>
    ' <param name="DisableAllPrivileges">Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all privileges and ignores the NewState parameter. If it is FALSE, the function modifies privileges based on the information pointed to by the NewState parameter.</param>
    ' <param name="NewState">Pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If the DisableAllPrivileges parameter is FALSE, AdjustTokenPrivileges enables or disables these privileges for the token. If you set the SE_PRIVILEGE_ENABLED attribute for a privilege, the function enables that privilege; otherwise, it disables the privilege. If DisableAllPrivileges is TRUE, the function ignores this parameter.</param>
    ' <param name="BufferLength">Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the PreviousState parameter is NULL.</param>
    ' <param name="PreviousState">Pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any privileges that the function modifies. This parameter can be NULL.</param>
    ' <param name="ReturnLength">Pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be NULL if PreviousState is NULL.</param>
    ' <returns>If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified privileges, call Marshal.GetLastWin32Error.</returns>
    Private Declare Ansi Function AdjustTokenPrivileges Lib "advapi32" (ByVal TokenHandle As IntPtr, ByVal DisableAllPrivileges As Integer, ByRef NewState As TOKEN_PRIVILEGES, ByVal BufferLength As Integer, ByRef PreviousState As TOKEN_PRIVILEGES, ByRef ReturnLength As Integer) As Integer

    ' Tries to enable the specified privilege.
    ' <param name="privilege">The privilege to enable.</param>
    ' <exception cref="PrivilegeException">There was an error while requesting a required privilege.</exception>
    Public Shared Sub EnableToken(ByVal privilege As String)
        If (Environment.OSVersion.Platform <> PlatformID.Win32NT) OrElse (Not CheckEntryPoint("advapi32.dll", "AdjustTokenPrivileges")) Then Return
        Dim tokenHandle As IntPtr
        Dim privilegeLUID As LUID
        Dim newPrivileges As TOKEN_PRIVILEGES
        Dim tokenPrivileges As TOKEN_PRIVILEGES
        If OpenProcessToken(Process.GetCurrentProcess.Handle, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle) = 0 Then Throw New PrivilegeException(FormatMessage(Marshal.GetLastWin32Error))
        If LookupPrivilegeValue("", privilege, privilegeLUID) = 0 Then Throw New PrivilegeException(FormatMessage(Marshal.GetLastWin32Error))
        tokenPrivileges.PrivilegeCount = 1
        tokenPrivileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED
        tokenPrivileges.Privileges.pLuid = privilegeLUID
        If AdjustTokenPrivileges(tokenHandle, 0, tokenPrivileges, 4 + (12 * tokenPrivileges.PrivilegeCount), newPrivileges, 4 + (12 * newPrivileges.PrivilegeCount)) = 0 Then Throw New PrivilegeException(FormatMessage(Marshal.GetLastWin32Error))
    End Sub

    ' Checks whether a specified method exists on the local computer.
    ' <param name="library">The library that holds the method.</param>
    ' <param name="method">The entry point of the requested method.</param>
    ' <returns>True if the specified method is present, false otherwise.</returns>
    Protected Shared Function CheckEntryPoint(ByVal library As String, ByVal method As String) As Boolean
        Dim libPtr As IntPtr = LoadLibrary(library)
        If Not libPtr.Equals(IntPtr.Zero) Then
            If Not GetProcAddress(libPtr, method).Equals(IntPtr.Zero) Then
                FreeLibrary(libPtr)
                Return True
            End If
            FreeLibrary(libPtr)
        End If
        Return False
    End Function

End Class



' The exception that is thrown when an error occures when requesting a specific privilege.
Friend Class PrivilegeException

    Inherits Exception
    ' Initializes a new instance of the PrivilegeException class.
    Public Sub New()
        MyBase.New()
    End Sub

    ' Initializes a new instance of the PrivilegeException class with a specified error message.
    ' <param name="message">The message that describes the error.</param>
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

End Class