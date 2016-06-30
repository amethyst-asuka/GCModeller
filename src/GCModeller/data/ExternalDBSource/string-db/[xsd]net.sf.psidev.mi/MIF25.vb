﻿Imports System.Xml.Serialization
Imports LANS.SystemsBiology.DatabaseServices.StringDB.MIF25.Nodes

Namespace StringDB.MIF25

    ' 请勿再修改本命名空间之中的所有Xml序列化对象的格式定义了，这个是用来读取string-db数据库的官方文档之中所介绍的格式

    ''' <summary>
    ''' net:sf:psidev:mi/http://psidev.sourceforge.net/mi/rel25/src/MIF25.xsd
    ''' </summary>
    <XmlRoot("entrySet", Namespace:="net:sf:psidev:mi")>
    Public Class EntrySet

        <XmlAttribute("level")> Public Property Level As Integer
        <XmlAttribute("version")> Public Property Version As Integer

        <XmlElement("entry")> Public Property Entries As Entry()
            Get
                Return _innerList
            End Get
            Set(value As Entry())
                _innerList = value
                If value.IsNullOrEmpty Then
                    _FirstInstance = Nothing
                Else
                    _FirstInstance = value(Scan0)
                End If
            End Set
        End Property

        Dim _innerList As Entry()
        ''' <summary>
        ''' 仅当<see cref="_innerList"/>之中包含有元素的时候，这个变量才不为空值
        ''' </summary>
        Public ReadOnly Property FirstInstance As Entry

        Public Function GetInteractor(Id As Integer) As Interactor
            If _FirstInstance Is Nothing Then
                Return Nothing
            End If
            If Entries.Length = 1 Then
                Return _FirstInstance.GetInteractor(handle:=Id)
            Else
                For Each entry In _innerList
                    Dim value As Interactor = entry.GetInteractor(Id)
                    If Not value Is Nothing Then
                        Return value
                    End If
                Next

                Return Nothing
            End If
        End Function

        Public Function ExtractNetwork() As StringDB.SimpleCsv.PitrNode()
            Dim LQuery = (From entry As Entry
                          In Me.Entries
                          Select __extractNetwork(entry)).ToArray.MatrixToVector
            Return LQuery
        End Function

        Private Function __extractNetwork(entry As Entry) As SimpleCsv.PitrNode()
            Dim LQuery = (From interacts As Interaction
                          In entry.InteractionList
                          Select __extractEdge(interacts)).ToArray
            Return LQuery
        End Function

        Private Function __extractEdge(Interaction As Interaction) As StringDB.SimpleCsv.PitrNode
            Dim Node As StringDB.SimpleCsv.PitrNode = New StringDB.SimpleCsv.PitrNode
            Node.Confidence = Interaction.ConfidenceList.First.value
            Node.FromNode = GetInteractor(Interaction.ParticipantList.First.InteractorRef).Xref.PrimaryReference.Id
            Node.ToNode = GetInteractor(Interaction.ParticipantList.Last.InteractorRef).Xref.PrimaryReference.Id
            Return Node
        End Function

        Public Shared Function ExtractNetwork(Dir As String) As StringDB.SimpleCsv.PitrNode()
            Dim LoadFilesLQuery = (From File As String
                                   In FileIO.FileSystem.GetFiles(Dir, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
                                   Select File.LoadXml(Of EntrySet)()).ToArray
            Dim Network As StringDB.SimpleCsv.PitrNode()() = (From file As EntrySet
                                                              In LoadFilesLQuery.AsParallel
                                                              Select edges = file.ExtractNetwork).ToArray
            Return Network.MatrixToList.TrimNull
        End Function
    End Class
End Namespace