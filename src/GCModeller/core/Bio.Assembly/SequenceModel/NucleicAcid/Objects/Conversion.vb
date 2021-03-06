﻿Imports Microsoft.VisualBasic.ComponentModel.Collection

Namespace SequenceModel.NucleotideModels

    ''' <summary>
    ''' 转换包含有普通类型的基本碱基字符，还包括有简并碱基字符
    ''' </summary>
    Public NotInheritable Class Conversion

        ''' <summary>
        ''' 简并碱基以及与之所对应的DNA碱基列表
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property DegenerateBases As Dictionary(Of DNA, DNA())
        Public Shared ReadOnly Property BaseDegenerateEntries As Dictionary(Of DNA, DNA())

        Shared ReadOnly validsChars As Index(Of Char)

        Public Overloads Shared Function Equals(a As DNA, b As DNA) As Boolean
            If a = b Then
                Return True
            End If

            Dim vx As DNA() = Nothing, vy As DNA() = Nothing

            If DegenerateBases.ContainsKey(a) Then
                vx = DegenerateBases(a)
            End If
            If DegenerateBases.ContainsKey(b) Then
                vy = DegenerateBases(b)
            End If

            If vx Is Nothing Then
                ' a 不是简并碱基
                If vy Is Nothing Then
                    ' b也不是简并碱基
                    Return False
                Else
                    ' b 是简并碱基
                    Return Array.IndexOf(vy, a) > -1
                End If
            Else
                ' a 是简并碱基
                If vy Is Nothing Then
                    ' b不是简并碱基
                    Return Array.IndexOf(vx, b) > -1
                Else
                    ' b也是简并碱基
                    ' 判断二者是不是有交集？
                    For Each base In vx
                        If Array.IndexOf(vy, base) > -1 Then
                            Return True
                        End If
                    Next

                    Return False
                End If
            End If
        End Function

        Private Sub New()
        End Sub

        Shared Sub New()
            NucleotideConvert = Enums(Of DNA).ToDictionary(Function(base) base.Description.First)
            NucleotideAsChar = Enums(Of DNA) _
                .ToDictionary(Function(base) base,
                              Function(c) c.Description.First)

            ' 添加完大写的碱基字母之后再添加小写的碱基字母，这样子就可以大小写不敏感了
            For Each base In NucleotideConvert.ToArray
                If base.Key <> "-" Then
                    Call NucleotideConvert.Add(Char.ToLower(base.Key), base.Value)
                End If
            Next

            validsChars = New Index(Of Char)(NucleotideConvert.Keys)

            With New DegenerateBasesExtensions
                DegenerateBases = .DegenerateBases _
                    .ToDictionary(Function(dgBase) CharEnums(dgBase.Key),
                                  Function(bases)
                                      Return bases _
                                          .Value _
                                          .Select(AddressOf CharEnums) _
                                          .ToArray
                                  End Function)
                BaseDegenerateEntries = .BaseDegenerateEntries _
                    .ToDictionary(Function(base) CharEnums(base.Key),
                                  Function(dgBases)
                                      Return dgBases _
                                          .Value _
                                          .Select(AddressOf CharEnums) _
                                          .ToArray
                                  End Function)
            End With
        End Sub

        Public Shared Function IsAValidDNAChar(c As Char) As Boolean
            Return validsChars(c) > -1
        End Function

        ''' <summary>
        ''' 大小写不敏感
        ''' </summary>
        Public Shared ReadOnly Property NucleotideConvert As Dictionary(Of Char, DNA)

        ''' <summary>
        ''' 大小写不敏感
        ''' </summary>
        ''' <param name="base"></param>
        ''' <returns></returns>
        Public Shared Function CharEnums(base As Char) As DNA
            Return NucleotideConvert(base)
        End Function

        ''' <summary>
        '''
        ''' </summary>
        Public Shared ReadOnly Property NucleotideAsChar As Dictionary(Of DNA, Char)

        ''' <summary>
        ''' ``<see cref="DNA"/> -> char``.(转换出来的全部都是大写字母)
        ''' </summary>
        ''' <param name="base"></param>
        ''' <returns></returns>
        Public Shared Function ToChar(base As DNA) As Char
            Return NucleotideAsChar(base)
        End Function
    End Class
End Namespace