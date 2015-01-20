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
Imports System
Imports System.ComponentModel
Imports System.Reflection
Imports System.Resources

' This attribute may be added to properties to control the resource table name and 
' keys for accessing the property name and description. 
<AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)> _
Public Class GlobalizedPropertyAttribute
    Inherits Attribute

    Private resourceName As [String] = ""
    Private resourceDescription As [String] = ""
    Private resourceTable As [String] = ""

    Public Sub New(ByVal name As [String])
        resourceName = name
    End Sub

    ' The key for a property name into the resource table.
    ' If empty the property name will be used by default.
    Public Property Name() As [String]
        Get
            Return resourceName
        End Get
        Set(ByVal value As [String])
            resourceName = value
        End Set
    End Property

    ' The key for a property description into the resource table.
    ' If empty the property name appended by 'Description' will be used by default.
    Public Property Description() As [String]
        Get
            Return resourceDescription
        End Get
        Set(ByVal value As [String])
            resourceDescription = value
        End Set
    End Property

    ' The name fully qualified name of the resource table to use, f.ex.
    ' "GlobalizedPropertyGrid.Person".
    Public Property Table() As [String]
        Get
            Return resourceTable
        End Get
        Set(ByVal value As [String])
            resourceTable = value
        End Set
    End Property
End Class

' This attribute may be added to properties to control the resource table name and 
' keys for accessing the property name and description. 
<AttributeUsage(AttributeTargets.[Class], AllowMultiple:=False, Inherited:=True)> _
Public Class GlobalizedObjectAttribute
    Inherits Attribute
    Private resourceTable As [String] = ""

    Public Sub New(ByVal name As [String])
        resourceTable = name
    End Sub

    ' resource table name to use for the class. 
    ' If this string is empty the name of the class will be used by default. 
    Public ReadOnly Property Table() As [String]
        Get
            Return resourceTable
        End Get
    End Property
End Class

' This attribute class extends the CategoryAttribute class from the .NET framework
' to support localization.
<AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)> _
Class GlobalizedCategoryAttribute
    Inherits CategoryAttribute

    Private table As String = ""

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub

    ' The name fully qualified name of the resource table to use, f.ex.
    ' "GlobalizedPropertyGrid.Person".
    Public Property TableName() As String
        Get
            Return table
        End Get
        Set(ByVal value As String)
            table = value
        End Set
    End Property

    ' This method will be called by the component framework to get a localized
    ' string. Note: Only called once on first access.
    Protected Overloads Overrides Function GetLocalizedString(ByVal value As String) As String
        Dim baseStr As String = MyBase.GetLocalizedString(value)

        ' Now use table name and display name id to access the resources.  
        Dim rm As New ResourceManager(table, Assembly.GetExecutingAssembly())

        ' Get the string from the resources.
        Try
            Return rm.GetString(value)

        Catch generatedExceptionName As Exception
            Return value

        End Try

    End Function
End Class
