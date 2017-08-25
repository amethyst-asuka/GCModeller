﻿Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' iTraq的DEP分析结果输出的文件数据读取对象
''' https://github.com/xieguigang/GCModeller.cli2R/blob/master/R/iTraq.log2_t-test.R
''' </summary>
Public Class DEP_iTraq : Inherits EntityObject

    <Column("FC.avg")> Public Property FCavg As Double
    <Column("p.value")> Public Property pvalue As Double
    <Column("is.DEP")> Public Property isDEP As Boolean

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class
