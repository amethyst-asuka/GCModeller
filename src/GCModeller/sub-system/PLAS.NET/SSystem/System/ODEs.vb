﻿#Region "Microsoft.VisualBasic::fd43aa2cb7e409ab46e674af5656ca39, ..\GCModeller\sub-system\PLAS.NET\SSystem\System\ODEs.vb"

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
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.Calculus
Imports Microsoft.VisualBasic.Math.Scripting
Imports SMRUCC.genomics.Analysis.SSystem.Kernel

Namespace Kernel

    Public Module ODEs

        ''' <summary>
        ''' 使用常微分方程组来解模型的计算
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <Extension>
        Public Function RunSystem(model As Script.Model) As ODEsOut
            Dim vars = LinqAPI.Exec(Of var) <=
                From x As ObjectModels.var
                In model.Vars
                Select New var With {
                    .Name = x.UniqueId,
                    .value = x.Value
                }
            Dim engine As New Expression
            Dim dynamics = (From x As Script.SEquation
                            In model.sEquations
                            Select y = New ObjectModels.Equation(x, engine)
                            Group y By y.Identifier Into Group) _
                                 .ToDictionary(Function(x) x.Identifier,
                                               Function(x) x.Group.ToArray)
            Dim tick As Long
            Dim experimentTrigger As New Kicks(
                vars.Select(Function(x) DirectCast(x, Ivar)).ToDictionary,
                model,
                Function() tick)

            Return New GenericODEs(vars) With {
                .df = Sub(dx, ByRef dy)
                          For Each var As var In vars ' 首先将所有的变量值更新到计算引擎之中
                              Call engine.Variables.Set(var.Name, var.value)
                          Next

                          For Each var As var In vars  ' 然后分别计算常微分方程
                              For Each eq In dynamics(var.Name)
                                  dy(index:=var) = eq.Evaluate
                              Next
                          Next

                          tick += 1

                          ' 在这里执行生物扰动实验
                          Call experimentTrigger.Tick()
                      End Sub
            }.Solve(100000, 0, model.FinalTime)
        End Function
    End Module
End Namespace
