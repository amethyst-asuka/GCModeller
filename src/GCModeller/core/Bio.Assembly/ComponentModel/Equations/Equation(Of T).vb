﻿#Region "Microsoft.VisualBasic::a545be1b29cbb0cfc01e9b8a089be2d1, ..\core\Bio.Assembly\ComponentModel\Equations\Equation(Of T).vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Linq

Namespace ComponentModel.EquaionModel

    Public MustInherit Class Equation(Of T As ICompoundSpecies) : Implements IEquation(Of T)

#Region "SBML接口"

        ''' <summary>
        ''' list of metabolism reaction substrates
        ''' </summary>
        ''' <returns></returns>
        <XmlArray("listOfReactants")> Public Overridable Property Reactants As T() Implements IEquation(Of T).Reactants
            Get
                Return __leftOri
            End Get
            Set(value As T())
                If value.IsNullOrEmpty Then
                    __leftHash = New Dictionary(Of String, T())
                Else
                    __leftHash = __gethash(value)
                End If

                __leftOri = value
            End Set
        End Property
        <XmlAttribute> Public Overridable Property Reversible As Boolean Implements IEquation(Of T).Reversible

        ''' <summary>
        ''' list of metabolism reaction products
        ''' </summary>
        ''' <returns></returns>
        <XmlArray("listOfProducts")> Public Overridable Property Products As T() Implements IEquation(Of T).Products
            Get
                Return __rightOri
            End Get
            Set(value As T())
                If value.IsNullOrEmpty Then
                    __rightHash = New Dictionary(Of String, T())
                Else
                    __rightHash = __gethash(value)
                End If

                __rightOri = value
            End Set
        End Property
#End Region

        Protected __leftOri As T()
        Protected __rightOri As T()

        ' 为了兼容KEGG里面的方程式，因为有些方程式可能会在一边出现相同的化合物

        Protected __leftHash As Dictionary(Of String, T())
        Protected __rightHash As Dictionary(Of String, T())

        Private Shared Function __gethash(value As T()) As Dictionary(Of String, T())
            Dim Groups = (From x As T
                          In value
                          Select x
                          Group x By x.Key.ToLower Into Group)
            Dim hash As Dictionary(Of String, T()) =
                Groups.ToDictionary(Function(x) x.Group.First.Key,
                                    Function(x) x.Group.ToArray)
            Return hash
        End Function

        ''' <summary>
        ''' 得到这个代谢反应过程之中的所有的代谢物，即左边加右边
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMetabolites() As T()
            Return Reactants.Join(Products).ToArray
        End Function

        ''' <summary>
        ''' 获取得到某个代谢物在本反应过程之中的化学计量数；
        ''' [
        ''' 左边，返回负数；
        ''' 右边，返回正数；
        ''' 不存在则返回0。
        ''' ]
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        Public Overridable Function GetCoEfficient(ID As String) As Double
            ID = ID.ToLower

            If __leftHash.ContainsKey(ID) Then
                Return -1 * __leftHash(ID).ToArray(Function(x) x.StoiChiometry).Sum
            ElseIf __rightHash.ContainsKey(ID) Then
                Return __rightHash(ID).ToArray(Function(x) x.StoiChiometry).Sum
            Else
                Return 0
            End If
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Metabolite">Id</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Produce(metabolite As T) As Boolean
            Return __rightHash.ContainsKey(metabolite.Key)
        End Function

        Public Function Consume(metabolite As T) As Boolean
            Return __leftHash.ContainsKey(metabolite.Key)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Metabolite">Metabolite.Species</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Produce(metabolite As String) As Boolean
            Return __rightHash.ContainsKey(metabolite)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Metabolite">Metabolite.Species</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Consume(metabolite As String) As Boolean
            Return __leftHash.ContainsKey(metabolite)
        End Function

        Protected MustOverride Function __equals(a As T, b As T, strict As Boolean)

        Public Overridable Overloads Function Equals(b As Equation(Of T), strict As Boolean) As Boolean
            Return Me.Equals(b, AddressOf __equals, strict)
        End Function

        ''' <summary>
        ''' Equation expression
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return EquationBuilder.ToString(Of T)(Equation:=Me)
        End Function
    End Class
End Namespace
