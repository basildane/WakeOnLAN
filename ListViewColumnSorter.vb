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

Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Private _columnToSort As Integer
    Private _orderOfSort As SortOrder
    Private _objectCompare As CaseInsensitiveComparer
    Private _objectType As String

    Public Sub New()
        ' Initialize the column to '0'.
        _columnToSort = 0

        ' Initialize the sort order to 'none'.
        _orderOfSort = SortOrder.None

        ' Initialize the CaseInsensitiveComparer object.
        _objectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        ' Compare the two items.
        If (_objectType = "IP") Then
            compareResult = _objectCompare.Compare(IpToInt(listviewX.SubItems(_columnToSort).Text), IpToInt(listviewY.SubItems(_columnToSort).Text))
        Else
            compareResult = _objectCompare.Compare(listviewX.SubItems(_columnToSort).Text, listviewY.SubItems(_columnToSort).Text)
        End If

        ' Calculate the correct return value based on the object 
        ' comparison.
        If (_orderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return typical result of 
            ' compare operation.
            Return compareResult
        ElseIf (_orderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of 
            ' compare operation.
            Return (-compareResult)
        Else
            ' Return '0' to indicate that they are equal.
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            _columnToSort = Value
        End Set

        Get
            Return _columnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            _orderOfSort = Value
        End Set

        Get
            Return _orderOfSort
        End Get
    End Property

    Public Property ObjectType() As String
        Set(ByVal Value As String)
            _objectType = Value
        End Set

        Get
            Return _objectType
        End Get
    End Property

End Class
