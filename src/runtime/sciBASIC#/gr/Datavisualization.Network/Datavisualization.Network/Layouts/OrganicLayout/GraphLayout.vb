Imports System.Drawing
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Imaging.LayoutModel

Namespace Layouts

    ''' <summary>
    ''' Abstract bass class for layouts
    ''' </summary>
    Public MustInherit Class mxGraphLayout

        ''' <summary>
        ''' The parent cell of the layout, if any
        ''' </summary>
        Protected Friend parent As Object

        ''' <summary>
        ''' Boolean indicating if the bounding box of the label should be used if
        ''' its available. Default is true.
        ''' </summary>
        Public Property useBoundingBox As Boolean = True

        ''' <summary>
        ''' Constructs a new fast organic layout for the specified graph.
        ''' </summary>
        Public Sub New(ByVal graph As NetworkGraph)
            Me.Graph = graph
        End Sub

        Public Overridable Sub execute(ByVal parent As Object)
            Me.parent = parent
        End Sub

        ''' <summary>
        ''' Returns the associated graph.
        ''' </summary>
        Public Overridable Property Graph As NetworkGraph

        ''' <summary>
        ''' Returns true if the given edge has no source or target terminal.
        ''' </summary>
        ''' <param name="edge"> Object that represents the edge to be tested. </param>
        ''' <returns> Returns true if the edge should be ignored. </returns>
        Public Overridable Function isEdgeIgnored(ByVal edge As Object) As Boolean
            Dim model As com.mxgraph.model.mxIGraphModel = Graph.Model

            Return (Not model.isEdge(edge)) OrElse (Not Graph.isCellVisible(edge)) OrElse model.getTerminal(edge, True) Is Nothing OrElse model.getTerminal(edge, False) Is Nothing
        End Function

        ''' <summary>
        ''' Disables or enables the edge style of the given edge.
        ''' </summary>
        Public Overridable Sub setEdgeStyleEnabled(ByVal edge As Object, ByVal value As Boolean)
            Graph.setCellStyles(com.mxgraph.util.mxConstants.STYLE_NOEDGESTYLE, If(value, "0", "1"), New Object() {edge})
        End Sub


        Public Overridable Function getParentOffset(ByVal parent As Object) As mxPoint
            Dim result As New mxPoint

            If parent IsNot Nothing AndAlso parent IsNot Me.parent Then
                Dim model As com.mxgraph.model.mxIGraphModel = Graph.Model

                If model.isAncestor(Me.parent, parent) Then
                    Dim parentGeo As mxGeometry = model.getGeometry(parent)

                    Do While parent IsNot Me.parent
                        result.X = result.X + parentGeo.X
                        result.Y = result.Y + parentGeo.Y

                        parent = model.getParent(parent)
                        parentGeo = model.getGeometry(parent)
                    Loop
                End If
            End If

            Return result
        End Function

        ''' <summary>
        ''' Returns an <mxRectangle> that defines the bounds of the given cell
        ''' or the bounding box if <useBoundingBox> is true.
        ''' </summary>
        Public Overridable Function getVertexBounds(ByVal vertex As Object) As mxRectangle
            Dim geo As mxRectangle = Graph.Model.getGeometry(vertex)

            ' Checks for oversize label bounding box and corrects
            ' the return value accordingly
            If useBoundingBox Then
                Dim state As com.mxgraph.view.mxCellState = Graph.View.getState(vertex)

                If state IsNot Nothing Then
                    Dim scale As Double = Graph.View.Scale
                    Dim tmp As mxRectangle = state.BoundingBox

                    Dim dx0 As Double = (tmp.X - state.X) / scale
                    Dim dy0 As Double = (tmp.Y - state.Y) / scale
                    Dim dx1 As Double = (tmp.X + tmp.Width - state.X - state.Width) / scale
                    Dim dy1 As Double = (tmp.Y + tmp.Height - state.Y - state.Height) / scale

                    geo = New mxRectangle(geo.X + dx0, geo.Y + dy0, geo.Width - dx0 + dx1, geo.Height + -dy0 + dy1)
                End If
            End If

            If Me.parent IsNot Nothing Then
                Dim parent As Object = Graph.Model.getParent(vertex)
                geo = CType(geo.Clone(), mxRectangle)

                If parent IsNot Nothing AndAlso parent IsNot Me.parent Then
                    Dim ___parentOffset As mxPoint = getParentOffset(parent)
                    geo.X = geo.X + ___parentOffset.X
                    geo.Y = geo.Y + ___parentOffset.Y
                End If
            End If

            Return New mxRectangle(geo)
        End Function

        ''' <summary>
        ''' Sets the new position of the given cell taking into account the size of
        ''' the bounding box if <useBoundingBox> is true. The change is only carried
        ''' out if the new location is not equal to the existing location, otherwise
        ''' the geometry is not replaced with an updated instance. The new or old
        ''' bounds are returned (including overlapping labels).
        ''' 
        ''' Parameters:
        ''' 
        ''' cell - <mxCell> whose geometry is to be set.
        ''' x - Integer that defines the x-coordinate of the new location.
        ''' y - Integer that defines the y-coordinate of the new location.
        ''' </summary>
        Public Overridable Function setVertexLocation(ByVal vertex As Object, ByVal x As Double, ByVal y As Double) As mxRectangle
            Dim model As com.mxgraph.model.mxIGraphModel = Graph.Model
            Dim geometry As mxGeometry = model.getGeometry(vertex)
            Dim result As mxRectangle = Nothing

            If geometry IsNot Nothing Then
                result = New mxRectangle(x, y, geometry.Width, geometry.Height)

                Dim graphView As NetworkGraphView = Graph.View

                ' Checks for oversize labels and offset the result
                If useBoundingBox Then
                    Dim state As com.mxgraph.view.mxCellState = graphView.getState(vertex)

                    If state IsNot Nothing Then
                        Dim scale As Double = Graph.View.Scale
                        Dim box As mxRectangle = state.BoundingBox

                        If state.BoundingBox.X < state.X Then
                            x += (state.X - box.X) / scale
                            result.Width = box.Width
                        End If
                        If state.BoundingBox.Y < state.Y Then
                            y += (state.Y - box.Y) / scale
                            result.Height = box.Height
                        End If
                    End If
                End If

                If Me.parent IsNot Nothing Then
                    Dim parent As Object = model.getParent(vertex)

                    If parent IsNot Nothing AndAlso parent IsNot Me.parent Then
                        Dim ___parentOffset As mxPoint = getParentOffset(parent)

                        x = x - ___parentOffset.X
                        y = y - ___parentOffset.Y
                    End If
                End If

                If geometry.X <> x OrElse geometry.Y <> y Then
                    geometry = CType(geometry.clone(), mxGeometry)
                    geometry.X = x
                    geometry.Y = y

                    model.setGeometry(vertex, geometry)
                End If
            End If

            Return result
        End Function
    End Class

End Namespace