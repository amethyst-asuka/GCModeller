﻿Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Imaging.LayoutModel

''' <summary>
''' Tsv table reader for string-db export result ``string_network_coordinates.txt``
''' </summary>
Public Class Coordinates
    Implements ILayoutCoordinate

    <Column("#node")> Public Property node As String Implements ILayoutCoordinate.ID
    Public Property x_position As Double Implements ILayoutCoordinate.X
    Public Property y_position As Double Implements ILayoutCoordinate.Y
    Public Property color As String
    Public Property annotation As String

    Public Overrides Function ToString() As String
        Return annotation
    End Function
End Class
