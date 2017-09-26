Imports Microsoft.VisualBasic.Linq

''' <summary>
''' Tree node with data.(����ֱ�ӱ�ʹ�õ�����������)
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class Tree(Of T) : Inherits AbstractTree(Of Tree(Of T))
    Public Property Data As T
End Class

Public Class AbstractTree(Of T As AbstractTree(Of T)) : Inherits Vertex

    Public Property Childs As List(Of T)
    Public Property Parent As T

    ''' <summary>
    ''' Not null child count in this tree node.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Count As Integer
        Get
            Dim childs = Me.Childs _
                .SafeQuery _
                .Where(Function(c) Not c Is Nothing) _
                .ToArray

            If childs.IsNullOrEmpty Then
                Return 1  ' �Լ���һ���ڵ㣬������������1��
            Else
                Dim n% = childs.Length

                For Each node In childs
                    n += node.Count ' ����ڵ�û��childs����᷵��1����Ϊ���������һ���ڵ�
                Next

                Return n
            End If
        End Get
    End Property

    Public ReadOnly Property QualifyName As String
        Get
            If Not Parent Is Nothing Then
                Return Parent.QualifyName & "." & Label
            Else
                Return Label
            End If
        End Get
    End Property

    Public ReadOnly Property IsRoot As Boolean
        Get
            Return Parent Is Nothing
        End Get
    End Property

    Public ReadOnly Property IsLeaf As Boolean
        Get
            Return Childs.IsNullOrEmpty
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return QualifyName
    End Function

    ''' <summary>
    ''' ��������е�Ҷ�ڵ�������������Լ���child��Ҷ�ڵ�
    ''' </summary>
    ''' <returns></returns>
    Public Function CountLeafs() As Integer
        Return CountLeafs(Me, 0)
    End Function

    ''' <summary>
    ''' ��ĳһ���ڵ�����е�Ҷ�ڵ���м���
    ''' </summary>
    ''' <param name="node"></param>
    ''' <param name="count"></param>
    ''' <returns></returns>
    Public Shared Function CountLeafs(node As T, count As Integer) As Integer
        If node.IsLeaf Then
            count += 1
        End If

        For Each child As T In node.Childs.SafeQuery
            count += child.CountLeafs()
        Next

        Return count
    End Function
End Class
