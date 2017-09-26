﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv.Excel
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MIME.Office.Excel.XML.xl
Imports Microsoft.VisualBasic.MIME.Office.Excel.XML.xl.worksheets
Imports csv = Microsoft.VisualBasic.Data.csv.IO.File

''' <summary>
''' 读取工作表的数据或者生成工作表数据的过程
''' </summary>
Public Module StoreProcedure

    <Extension>
    Public Function ToTableFrame(worksheet As worksheet, strings As sharedStrings) As csv
        Dim getValues As IEnumerable(Of RowObject) =
            worksheet _
                .sheetData _
                .rows _
                .Select(Function(r) r.ToRowData(strings))
        Dim csv As New csv(getValues)
        Return csv
    End Function

    <Extension>
    Private Function ToRowData(row As row, strings As sharedStrings) As RowObject
        Dim csv As New RowObject
        Dim string$
        Dim colIndex%
        Dim cellIndex As Point

        For Each col As c In row.columns
            cellIndex = Coordinates.Index(col.r)
            colIndex = cellIndex.Y ' 因为这里都是同一行的数据，所以只取列下标即可

            With col.sharedStringsRef
                If .ref = -1 Then
                    [string] = col.v
                Else
                    [string] = strings.strings(.ref).t
                End If
            End With

            csv(colIndex - 1) = [string]
        Next

        Return csv
    End Function

    <Extension>
    Public Function CreateWorksheet(table As csv, strings As sharedStrings) As worksheet
        Dim stringTable = strings.ToHashTable
        Dim rows As row() = table _
            .SeqIterator _
            .Select(Function(i) StoreProcedure.CreateRow(i.i + 1, i, stringTable)) _
            .ToArray
        Dim worksheet As New worksheet With {
            .sheetData = New sheetData With {
                .rows = rows
            },
            .dimension = New dimension With {
                .ref = table.Dimension
            }
        }

        strings += stringTable

        Return worksheet
    End Function

    Private Function CreateRow(i%, data As RowObject, strings As Dictionary(Of String, Integer)) As row
        Dim spans$
        Dim cols As c() = data _
            .SeqIterator _
            .Where(Function(s) Not s.value.StringEmpty) _
            .Select(Function(x)
                        Dim s$ = x
                        Dim t$ = Nothing

                        If strings.ContainsKey(s) Then
                            ' 使用共享引用以减少所生成的文件的大小
                            t = "s"
                            s = strings(s)
                        ElseIf Not s.IsNumeric Then

                            ' 非数值类型的要添加进入共享字符串列表
                            SyncLock strings
                                With strings
                                    Call .Add(s, .Count)
                                End With
                            End SyncLock

                            t = "s"
                            s = strings(s)
                        End If

                        Return New c With {
                            .r = x.i.ColumnIndex & i,
                            .v = s,
                            .t = t,
                            .s = If(t Is Nothing, Nothing, "1")
                        }
                    End Function) _
            .ToArray

        With data.Spans
            spans = $"{ .start},{ .ends}"
        End With

        Return New row With {
            .r = i,
            .spans = spans,
            .columns = cols
        }
    End Function
End Module
