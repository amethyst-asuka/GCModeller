﻿#Region "Microsoft.VisualBasic::337613d28c3284322d4d8a3c712098a4, ..\sciBASIC#\Data_science\Mathematica\Math\Math\Algebra\LP\Data\Solver.vb"

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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

Namespace LP

    Public Module Solver

        <Extension>
        Public Function BuildMatrix(equations As IEnumerable(Of Equation), func As ObjectiveFunction) As Double()()
            Dim eqs As Equation() = equations.ToArray
            Dim Z# = If(func.Z = 0R, 1, func.Z) ' 默认Z是必须存在的，所以默认是1，也可以是其他的数值
            Dim o#() = Z# _
                .Join(func.xyz.Select(Function(x) -x)) _
                .Join(0R.Repeats(eqs.Length)) _
                .Join(0R) _
                .ToArray
            Dim matrix As New List(Of Double())

            matrix += o#

            For Each i As SeqValue(Of Equation) In eqs.SeqIterator
                Dim s#() = New Double(eqs.Length - 1) {}
                Dim eq As Equation = +i

                s(i) = 1.0R

                Dim row#() = 0R _
                    .Join(eq.xyz) _
                    .Join(s) _
                    .Join(eq.c) _
                    .ToArray

                matrix += row#
            Next

            Return matrix
        End Function

        ''' <summary>
        ''' 进行线性规划求解的快捷方式
        ''' </summary>
        ''' <param name="func"></param>
        ''' <param name="equations"></param>
        ''' <returns></returns>
        <Extension>
        Public Function Solve(func As ObjectiveFunction, equations As IEnumerable(Of Equation)) As Double()
            Dim matrix As New Tableau(equations.BuildMatrix(func))
            Dim solver As New LinearSolver(func.type)
            Dim result As Objective = solver.solve(matrix)
            Return result.Solution
        End Function
    End Module
End Namespace
