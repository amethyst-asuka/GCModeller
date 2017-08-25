﻿#Region "Microsoft.VisualBasic::912a59448a212923931c7cb09636821b, ..\interops\RNA-Seq\RNA-seq.Data\Fastaq\Fastaq.vb"

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

Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace Fastaq

    ''' <summary>
    ''' FASTQ format is a text-based format for storing both a biological sequence (usually nucleotide sequence) and 
    ''' its corresponding quality scores. Both the sequence letter and quality score are each encoded with a single 
    ''' ASCII character for brevity. It was originally developed at the Wellcome Trust Sanger Institute to bundle a 
    ''' FASTA sequence and its quality data, but has recently become the de facto standard for storing the output of 
    ''' high-throughput sequencing instruments such as the Illumina Genome Analyzer.
    ''' 
    ''' There is no standard file extension for a FASTQ file, but .fq and .fastq, are commonly used.
    ''' (http://en.wikipedia.org/wiki/FASTQ_format)
    ''' </summary>
    ''' <remarks>
    ''' A FASTQ file normally uses four lines per sequence.
    ''' 
    ''' + Line 1 begins with a '@' character and is followed by a sequence identifier and an optional description (like a FASTA title line).
    ''' + Line 2 is the raw sequence letters.
    ''' + Line 3 begins with a '+' character and is optionally followed by the same sequence identifier (and any description) again.
    ''' + Line 4 encodes the quality values for the sequence in Line 2, and must contain the same number of symbols as letters in the sequence.
    ''' 
    ''' > + header
    ''' > + seuqnece
    ''' > + ``+``
    ''' > + quality
    ''' 
    ''' 一条FastQ序列文件通常使用4行代表一条序列数据：
    ''' + 第一行： 起始于@字符，后面跟随着序列的标识符，以及一段可选的摘要描述信息
    ''' + 第二行： 原始的序列
    ''' + 第三行： 起始于+符号，与第一行的作用类似
    ''' + 第四行： 编码了第二行的序列数据的质量高低，长度与第二行相同
    ''' </remarks>
    Public Class FastQ : Inherits ISequenceModel
        Implements IAbstractFastaToken

        ''' <summary>
        ''' 第一行的摘要描述信息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Title As String Implements IAbstractFastaToken.Title
            Get
                Return SEQ_ID.Identifier
            End Get
        End Property

        ''' <summary>
        ''' 第一行的序列标识符
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SEQ_ID As FastQIdentifier
        Public Property SEQ_ID2 As FastQIdentifier
        Public Property Quantities As String

        Public Property Attributes As String() Implements IAbstractFastaToken.Attributes

        Public Overrides Function ToString() As String
            Return Title
        End Function

        ''' <summary>
        ''' The character '!' represents the lowest quality while '~' is the highest. Here are the quality value characters in left-to-right increasing order of quality (ASCII):
        ''' </summary>
        ''' <remarks></remarks>
        Public Const QUANTITY_ORDERS As String = "!""#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~"

        Public Shared Function GetQuantityOrder(q As Char) As Integer
            Return FastQ.QUANTITY_ORDERS.IndexOf(q)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' The original Sanger FASTQ files also allowed the sequence and quality strings to be wrapped (split over multiple lines), 
        ''' but this is generally discouraged as it can make parsing complicated due to the unfortunate choice of "@" and "+" as 
        ''' markers (these characters can also occur in the quality string).[2] An example of a tools that break the 4 line convention 
        ''' is vcfutils.pl from samtools.[3]
        ''' </remarks>
        Public Shared Function FastaqParser(str As String()) As FastQ
            Dim Fastaq As New FastQ With {
                .SequenceData = str(1),
                .SEQ_ID = FastQIdentifier.IDParser(str(0)),
                .SEQ_ID2 = FastQIdentifier.IDParser(str(2)),
                .Quantities = str(3)
            }

            Return Fastaq
        End Function
    End Class
End Namespace
