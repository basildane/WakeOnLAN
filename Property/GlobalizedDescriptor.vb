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
Imports System.ComponentModel
Imports System.Resources

#Region "GlobalizedPropertyDescriptor"

''' <summary>
''' GlobalizedPropertyDescriptor enhances the base class bay obtaining the display name for a property
''' from the resource.
''' </summary>
Public Class GlobalizedPropertyDescriptor
    Inherits PropertyDescriptor

    Private basePropertyDescriptor As PropertyDescriptor
    Private localizedName As [String] = ""
    Private localizedDescription As [String] = ""

    Public Sub New(ByVal basePropertyDescriptor As PropertyDescriptor)
        MyBase.New(basePropertyDescriptor)
        Me.basePropertyDescriptor = basePropertyDescriptor
    End Sub

    Public Overloads Overrides ReadOnly Property Attributes() As AttributeCollection
        Get
            Dim attrs As AttributeCollection = basePropertyDescriptor.Attributes
            For Each attr As Attribute In attrs
                If TypeOf attr Is GlobalizedCategoryAttribute Then
                    Dim attrCat As GlobalizedCategoryAttribute = DirectCast(attr, GlobalizedCategoryAttribute)
                    attrCat.TableName = (basePropertyDescriptor.ComponentType.[Namespace] & ".") + basePropertyDescriptor.ComponentType.Name
                End If
            Next
            Return attrs
        End Get
    End Property

    Public Overloads Overrides Function CanResetValue(ByVal component As Object) As Boolean
        Return basePropertyDescriptor.CanResetValue(component)
    End Function

    Public Overloads Overrides ReadOnly Property ComponentType() As Type
        Get
            Return basePropertyDescriptor.ComponentType
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property DisplayName() As String
        Get
            ' First lookup the property if GlobalizedPropertyAttribute instances are available. 
            ' If yes, then try to get resource table name and display name id from that attribute.
            Dim tableName As String = ""
            Dim _displayName As String = ""
            For Each oAttrib As Attribute In Me.basePropertyDescriptor.Attributes
                If oAttrib.[GetType]().Equals(GetType(GlobalizedPropertyAttribute)) Then
                    _displayName = DirectCast(oAttrib, GlobalizedPropertyAttribute).Name
                    tableName = DirectCast(oAttrib, GlobalizedPropertyAttribute).Table
                End If
            Next
            ' If no resource table is specified at the property level, then look if it is done
            ' on the class level
            If tableName.Length = 0 Then
                Dim attrs As GlobalizedObjectAttribute() = DirectCast(basePropertyDescriptor.ComponentType.GetCustomAttributes(GetType(GlobalizedObjectAttribute), False), GlobalizedObjectAttribute())
                If attrs.Length > 0 Then
                    tableName = DirectCast(attrs(0), GlobalizedObjectAttribute).Table
                End If
            End If
            ' If still no resource table specified by attribute, then build it itself by using namespace and class name.
            If tableName.Length = 0 Then
                tableName = (basePropertyDescriptor.ComponentType.[Namespace] & ".") + basePropertyDescriptor.ComponentType.Name
            End If

            ' If no display name id is specified by attribute, then construct it by using default display name (usually the property name) 
            If _displayName.Length = 0 Then
                _displayName = Me.basePropertyDescriptor.DisplayName
            End If

            ' Now use table name and display name id to access the resources.  
            Dim rm As New ResourceManager(tableName, basePropertyDescriptor.ComponentType.Assembly)

            ' Get the string from the resources. 
            ' If this fails, then use default display name (usually the property name) 
            Dim s As String = rm.GetString(_displayName)
            Me.localizedName = If((s IsNot Nothing), s, Me.basePropertyDescriptor.DisplayName)

            Return Me.localizedName
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property Description() As String
        Get
            ' First lookup the property if there are GlobalizedPropertyAttribute instances
            ' are available. 
            ' If yes, try to get resource table name and display name id from that attribute.
            Dim tableName As String = ""
            Dim displayName As String = ""
            For Each oAttrib As Attribute In Me.basePropertyDescriptor.Attributes
                If oAttrib.[GetType]().Equals(GetType(GlobalizedPropertyAttribute)) Then
                    displayName = DirectCast(oAttrib, GlobalizedPropertyAttribute).Description
                    tableName = DirectCast(oAttrib, GlobalizedPropertyAttribute).Table
                End If
            Next

            ' If no resource table is specified at the property level, then look if it is done
            ' on the class level
            If tableName.Length = 0 Then
                Dim attrs As GlobalizedObjectAttribute() = DirectCast(basePropertyDescriptor.ComponentType.GetCustomAttributes(GetType(GlobalizedObjectAttribute), False), GlobalizedObjectAttribute())
                If attrs.Length > 0 Then
                    tableName = DirectCast(attrs(0), GlobalizedObjectAttribute).Table
                End If
            End If

            ' If no resource table specified by attribute, then build it itself by using namespace and class name.
            If tableName.Length = 0 Then
                tableName = (basePropertyDescriptor.ComponentType.[Namespace] & ".") + basePropertyDescriptor.ComponentType.Name
            End If

            ' If no display name id is specified by attribute, then construct it by using default display name (usually the property name) 
            If displayName.Length = 0 Then
                displayName = Me.basePropertyDescriptor.DisplayName & "Description"
            End If

            ' Now use table name and display name id to access the resources.  
            Dim rm As New ResourceManager(tableName, basePropertyDescriptor.ComponentType.Assembly)

            ' Get the string from the resources. 
            ' If this fails, then use default empty string indictating 'no description' 
            Dim s As String = rm.GetString(displayName)
            Me.localizedDescription = If((s IsNot Nothing), s, "")

            Return Me.localizedDescription
        End Get
    End Property

    Public Overloads Overrides Function GetValue(ByVal component As Object) As Object
        Return Me.basePropertyDescriptor.GetValue(component)
    End Function

    Public Overloads Overrides ReadOnly Property IsReadOnly() As Boolean
        Get
            Return Me.basePropertyDescriptor.IsReadOnly
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property Name() As String
        Get
            Return Me.basePropertyDescriptor.Name
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property PropertyType() As Type
        Get
            Return Me.basePropertyDescriptor.PropertyType
        End Get
    End Property

    Public Overloads Overrides Sub ResetValue(ByVal component As Object)
        Me.basePropertyDescriptor.ResetValue(component)
    End Sub

    Public Overloads Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
        Return Me.basePropertyDescriptor.ShouldSerializeValue(component)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
        Me.basePropertyDescriptor.SetValue(component, value)
    End Sub
End Class
#End Region

#Region "GlobalizedObject"

''' <summary>
''' GlobalizedObject implements ICustomTypeDescriptor to enable 
''' required functionality to describe a type (class).<br></br>
''' The main task of this class is to instantiate our own property descriptor 
''' of type GlobalizedPropertyDescriptor.  
''' </summary>
Public Class GlobalizedObject
    Implements ICustomTypeDescriptor

    Private globalizedProps As PropertyDescriptorCollection

    Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
        Return TypeDescriptor.GetClassName(Me, True)
    End Function

    Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
        Return TypeDescriptor.GetAttributes(Me, True)
    End Function

    Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
        Return TypeDescriptor.GetComponentName(Me, True)
    End Function

    Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
        Return TypeDescriptor.GetConverter(Me, True)
    End Function

    Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
        Return TypeDescriptor.GetDefaultEvent(Me, True)
    End Function

    Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
        Return TypeDescriptor.GetDefaultProperty(Me, True)
    End Function

    Public Function GetEditor(ByVal editorBaseType As Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
        Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
    End Function

    Public Function GetEvents(ByVal attributes As Attribute()) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, attributes, True)
    End Function

    Public Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, True)
    End Function

    ''' <summary>
    ''' Called to get the properties of a type.
    ''' </summary>
    ''' <param name="attributes"></param>
    ''' <returns></returns>
    Public Function GetProperties(ByVal attributes As Attribute()) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        If globalizedProps Is Nothing Then
            ' Get the collection of properties
            Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, attributes, True)

            globalizedProps = New PropertyDescriptorCollection(Nothing)

            ' For each property use a property descriptor of our own that is able to be globalized
            For Each oProp As PropertyDescriptor In baseProps
                globalizedProps.Add(New GlobalizedPropertyDescriptor(oProp))
            Next
        End If
        Return globalizedProps
    End Function

    Public Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        ' Only do once
        If globalizedProps Is Nothing Then
            ' Get the collection of properties
            Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, True)
            globalizedProps = New PropertyDescriptorCollection(Nothing)

            ' For each property use a property descriptor of our own that is able to be globalized
            For Each oProp As PropertyDescriptor In baseProps
                globalizedProps.Add(New GlobalizedPropertyDescriptor(oProp))
            Next
        End If
        Return globalizedProps
    End Function

    Public Function GetPropertyOwner(ByVal pd As PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
        Return Me
    End Function

End Class

#End Region
