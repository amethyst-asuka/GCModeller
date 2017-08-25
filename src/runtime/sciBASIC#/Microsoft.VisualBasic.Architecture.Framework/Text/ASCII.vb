﻿#Region "Microsoft.VisualBasic::1c75bcd044f78268febcc01498591477, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Text\ASCII.vb"

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
Imports System.Text
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Language

Namespace Text

    ''' <summary>
    ''' ``ASCII`` (``American Standard Code for Information Interchange``，美国信息互换标准代码，``ASCⅡ``) 是基于拉丁字母的一套电脑编码系统。
    ''' 它主要用于显示现代英语和其他西欧语言。它是现今最通用的单字节编码系统，并等同于国际标准``ISO/IEC 646``。
    ''' ASCII第一次以规范标准的型态发表是在1967年，最后一次更新则是在1986年，至今为止共定义了128个字符，其中33个字符无法显示
    ''' （这是以现今操作系统为依归，但在DOS模式下可显示出一些诸如笑脸、扑克牌花式等8-bit符号），且这33个字符多数都已是陈废的控制字符，
    ''' 控制字符的用途主要是用来操控已经处理过的文字，在33个字符之外的是95个可显示的字符，包含用键盘敲下空白键所产生的空白字符也算1个可显示字符
    ''' （显示为空白）。
    ''' </summary>
    ''' <remarks>http://ascii.911cha.com/</remarks>
    Public Class ASCII

        ''' <summary>
        ''' 0000 0000	0	00	NUL	空字符（Null）
        ''' </summary>
        Public Const NUL As Char = Chr(0)
        ''' <summary>
        ''' 0000 0001	1	01	SOH	标题开始
        ''' </summary>
        Public Const SOH As Char = Chr(1)
        ''' <summary>
        ''' 0000 0010	2	02	STX	本文开始
        ''' </summary>
        Public Const STX As Char = Chr(2)
        ''' <summary>
        ''' 0000 0011	3	03	ETX	本文结束
        ''' </summary>
        Public Const ETX As Char = Chr(3)
        ''' <summary>
        ''' 0000 0100	4	04	EOT	传输结束
        ''' </summary>
        Public Const EOT As Char = Chr(4)
        ''' <summary>
        ''' 0000 0101	5	05	ENQ	请求
        ''' </summary>
        Public Const ENQ As Char = Chr(5)
        ''' <summary>
        ''' 0000 0110	6	06	ACK	确认回应
        ''' </summary>
        Public Const ACK As Char = Chr(6)
        ''' <summary>
        ''' 0000 0111	7	07	BEL	响铃
        ''' </summary>
        Public Const BEL As Char = Chr(7)
        ''' <summary>
        ''' 0000 1000	8	08	BS	退格
        ''' </summary>
        Public Const BS As Char = Chr(8)
        ''' <summary>
        ''' 0000 1001	9	09	HT	水平定位符号
        ''' </summary>
        Public Const HT As Char = Chr(9)
        ''' <summary>
        ''' 0000 1010	10	0A	LF	换行键
        ''' </summary>
        Public Const LF As Char = Chr(10)
        ''' <summary>
        ''' 0000 1011	11	0B	VT	垂直定位符号
        ''' </summary>
        Public Const VT As Char = Chr(11)
        ''' <summary>
        ''' 0000 1100	12	0C	FF	换页键
        ''' </summary>
        Public Const FF As Char = Chr(12)
        ''' <summary>
        ''' 0000 1101	13	0D	CR	归位键
        ''' </summary>
        Public Const CR As Char = Chr(13)
        ''' <summary>
        ''' 0000 1110	14	0E	SO	取消变换（Shift out）
        ''' </summary>
        Public Const SO As Char = Chr(14)
        ''' <summary>
        ''' 0000 1111	15	0F	SI	启用变换（Shift in）
        ''' </summary>
        Public Const SI As Char = Chr(15)
        ''' <summary>
        ''' 0001 0000	16	10	DLE	跳出数据通讯
        ''' </summary>
        Public Const DLE As Char = Chr(16)
        ''' <summary>
        ''' 0001 0001	17	11	DC1	设备控制一（XON 启用软件速度控制）
        ''' </summary>
        Public Const DC1 As Char = Chr(17)
        ''' <summary>
        ''' 0001 0010	18	12	DC2	设备控制二
        ''' </summary>
        Public Const DC2 As Char = Chr(18)
        ''' <summary>
        ''' 0001 0011	19	13	DC3	设备控制三（XOFF 停用软件速度控制）
        ''' </summary>
        Public Const DC3 As Char = Chr(19)
        ''' <summary>
        ''' 0001 0100	20	14	DC4	设备控制四
        ''' </summary>
        Public Const DC4 As Char = Chr(20)
        ''' <summary>
        ''' 0001 0101	21	15	NAK	确认失败回应
        ''' </summary>
        Public Const NAK As Char = Chr(21)
        ''' <summary>
        ''' 0001 0110	22	16	SYN	同步用暂停
        ''' </summary>
        Public Const SYN As Char = Chr(22)
        ''' <summary>
        ''' 0001 0111	23	17	ETB	区块传输结束
        ''' </summary>
        Public Const ETB As Char = Chr(23)
        ''' <summary>
        ''' 0001 1000	24	18	CAN	取消
        ''' </summary>
        Public Const CAN As Char = Chr(24)
        ''' <summary>
        ''' 0001 1001	25	19	EM	连接介质中断
        ''' </summary>
        Public Const EM As Char = Chr(25)
        ''' <summary>
        ''' 0001 1010	26	1A	SUB	替换
        ''' </summary>
        Public Const [SUB] As Char = Chr(26)
        ''' <summary>
        ''' 0001 1011	27	1B	ESC	跳出
        ''' </summary>
        Public Const ESC As Char = Chr(27)
        ''' <summary>
        ''' 0001 1100	28	1C	FS	文件分割符
        ''' </summary>
        Public Const FS As Char = Chr(28)
        ''' <summary>
        ''' 0001 1101	29	1D	GS	组群分隔符
        ''' </summary>
        Public Const GS As Char = Chr(29)
        ''' <summary>
        ''' 0001 1110	30	1E	RS	记录分隔符
        ''' </summary>
        Public Const RS As Char = Chr(30)
        ''' <summary>
        ''' 0001 1111	31	1F	US	单元分隔符
        ''' </summary>
        Public Const US As Char = Chr(31)
        ''' <summary>
        ''' 0111 1111	127	7F	DEL	删除
        ''' </summary>
        Public Const DEL As Char = Chr(127)

        ''' <summary>
        ''' 非打印字符也可以是正则表达式的组成部分。下表列出了表示非打印字符的转义序列：
        ''' 
        ''' ##### 转义序列
        ''' 
        ''' |字符|含义|
        ''' |---|----|
        ''' |\cx|匹配 x 指示的控制字符。例如，\cM 匹配 Control-M 或回车符。x 的值必须在 A-Z 或 a-z 之间。如果不是这样，则假定 c 就是“c”字符本身。|
        ''' |\f |换页符匹配。等效于 \x0c 和 \cL。|
        ''' |\n |换行符匹配。等效于 \x0a 和 \cJ。|
        ''' |\r |匹配一个回车符。等效于 \x0d 和 \cM。|
        ''' |\s |匹配任何空白字符，包括空格、制表符、换页符等。与 [\f\n\r\t\v] 等效。|
        ''' |\S |匹配任何非空白字符。与 [^ \f\n\r\t\v] 等效。|
        ''' |\t |制表符匹配。与 \x09 和 \cI 等效。|
        ''' |\v |垂直制表符匹配。与 \x0b 和 \cK 等效。|
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property Nonprintings As Char() = {
            ASCII.ACK,
            ASCII.BEL,
            ASCII.BS,
            ASCII.CAN,
            ASCII.DC1,
            ASCII.DC2,
            ASCII.DC3,
            ASCII.DC4,
            ASCII.DEL,
            ASCII.DLE,
            ASCII.EM,
            ASCII.ENQ,
            ASCII.EOT,
            ASCII.ESC,
            ASCII.ETB,
            ASCII.ETX,
            ASCII.FF,
            ASCII.FS,
            ASCII.GS,
            ASCII.HT,
            ASCII.NAK,
            ASCII.NUL,
            ASCII.RS,
            ASCII.SI,
            ASCII.SO,
            ASCII.SOH,
            ASCII.STX,
            ASCII.SUB,
            ASCII.SYN,
            ASCII.US,
            ASCII.VT
        }

        ''' <summary>
        ''' <see cref="vbTab"/>
        ''' </summary>
        Public Const TAB As Char = CChar(vbTab)

        ''' <summary>
        ''' 双引号``"``
        ''' </summary>
        Public Const Quot As Char = Chr(34)
        Public Shared ReadOnly QuotBegin_ZHCN As Char = Convert.ToChar(8220)
        Public Shared ReadOnly QuotEnds_ZHCN As Char = Convert.ToChar(8221)
        Public Const QuotUnknown As Char = "″"c

        Public Const A As Integer = Asc("A"c)
        Public Const Z As Integer = Asc("Z"c)
        Public Const al% = Asc("a"c)
        Public Const zl% = Asc("z"c)

        ''' <summary>
        ''' ASCII code for number ``0``
        ''' </summary>
        Public Const n0% = Asc("0"c)
        ''' <summary>
        ''' ASCII code for number ``9``
        ''' </summary>
        Public Const n9% = Asc("9"c)

        ''' <summary>
        ''' 单引号
        ''' </summary>
        Public Const Mark As Char = "'"c

        ''' <summary>
        ''' 分别替换英文双引号，中文双引号为指定的字符串
        ''' </summary>
        ''' <param name="s"></param>
        ''' <param name="replace"></param>
        ''' <returns></returns>
        Public Shared Function ReplaceQuot(s As String, Optional replace As String = "'") As String
            Dim sb As New StringBuilder(s)

            Call sb.Replace(ASCII.Quot, replace)
            Call sb.Replace(ASCII.QuotBegin_ZHCN, replace)
            Call sb.Replace(ASCII.QuotEnds_ZHCN, replace)
            Call sb.Replace(ASCII.QuotUnknown, replace)

            Return sb.ToString
        End Function

        ''' <summary>
        ''' 可以印刷的ASCII符号列表
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property Symbols As Char() = ASCII.Byte.GetASCIISymbols().ToArray(AddressOf Chr)

        Public Class [Byte]

            Public Shared Function GetASCIISymbols() As Integer()
                Dim code As New List(Of Integer)

                code += {33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47}
                code += {58, 59, 60, 61, 62, 63, 64}
                code += {91, 92, 93, 94, 95, 96}
                code += {123, 124, 125, 126}

                Return code
            End Function

            ''' <summary>
            ''' 0000 0000	0	00	NUL	空字符（Null）
            ''' </summary>
            Public Const NUL As Integer = 0
            ''' <summary>
            ''' 0000 0001	1	01	SOH	标题开始
            ''' </summary>
            Public Const SOH As Integer = 1
            ''' <summary>
            ''' 0000 0010	2	02	STX	本文开始
            ''' </summary>
            Public Const STX As Integer = 2
            ''' <summary>
            ''' 0000 0011	3	03	ETX	本文结束
            ''' </summary>
            Public Const ETX As Integer = 3
            ''' <summary>
            ''' 0000 0100	4	04	EOT	传输结束
            ''' </summary>
            Public Const EOT As Integer = 4
            ''' <summary>
            ''' 0000 0101	5	05	ENQ	请求
            ''' </summary>
            Public Const ENQ As Integer = 5
            ''' <summary>
            ''' 0000 0110	6	06	ACK	确认回应
            ''' </summary>
            Public Const ACK As Integer = 6
            ''' <summary>
            ''' 0000 0111	7	07	BEL	响铃
            ''' </summary>
            Public Const BEL As Integer = 7
            ''' <summary>
            ''' 0000 1000	8	08	BS	退格
            ''' </summary>
            Public Const BS As Integer = 8
            ''' <summary>
            ''' 0000 1001	9	09	HT	水平定位符号
            ''' </summary>
            Public Const HT As Integer = 9
            ''' <summary>
            ''' 0000 1010	10	0A	LF	换行键
            ''' </summary>
            Public Const LF As Integer = 10
            ''' <summary>
            ''' 0000 1011	11	0B	VT	垂直定位符号
            ''' </summary>
            Public Const VT As Integer = 11
            ''' <summary>
            ''' 0000 1100	12	0C	FF	换页键
            ''' </summary>
            Public Const FF As Integer = 12
            ''' <summary>
            ''' 0000 1101	13	0D	CR	归位键
            ''' </summary>
            Public Const CR As Integer = 13
            ''' <summary>
            ''' 0000 1110	14	0E	SO	取消变换（Shift out）
            ''' </summary>
            Public Const SO As Integer = 14
            ''' <summary>
            ''' 0000 1111	15	0F	SI	启用变换（Shift in）
            ''' </summary>
            Public Const SI As Integer = 15
            ''' <summary>
            ''' 0001 0000	16	10	DLE	跳出数据通讯
            ''' </summary>
            Public Const DLE As Integer = 16
            ''' <summary>
            ''' 0001 0001	17	11	DC1	设备控制一（XON 启用软件速度控制）
            ''' </summary>
            Public Const DC1 As Integer = 17
            ''' <summary>
            ''' 0001 0010	18	12	DC2	设备控制二
            ''' </summary>
            Public Const DC2 As Integer = 18
            ''' <summary>
            ''' 0001 0011	19	13	DC3	设备控制三（XOFF 停用软件速度控制）
            ''' </summary>
            Public Const DC3 As Integer = 19
            ''' <summary>
            ''' 0001 0100	20	14	DC4	设备控制四
            ''' </summary>
            Public Const DC4 As Integer = 20
            ''' <summary>
            ''' 0001 0101	21	15	NAK	确认失败回应
            ''' </summary>
            Public Const NAK As Integer = 21
            ''' <summary>
            ''' 0001 0110	22	16	SYN	同步用暂停
            ''' </summary>
            Public Const SYN As Integer = 22
            ''' <summary>
            ''' 0001 0111	23	17	ETB	区块传输结束
            ''' </summary>
            Public Const ETB As Integer = 23
            ''' <summary>
            ''' 0001 1000	24	18	CAN	取消
            ''' </summary>
            Public Const CAN As Integer = 24
            ''' <summary>
            ''' 0001 1001	25	19	EM	连接介质中断
            ''' </summary>
            Public Const EM As Integer = 25
            ''' <summary>
            ''' 0001 1010	26	1A	SUB	替换
            ''' </summary>
            Public Const [SUB] As Integer = 26
            ''' <summary>
            ''' 0001 1011	27	1B	ESC	跳出
            ''' </summary>
            Public Const ESC As Integer = 27
            ''' <summary>
            ''' 0001 1100	28	1C	FS	文件分割符
            ''' </summary>
            Public Const FS As Integer = 28
            ''' <summary>
            ''' 0001 1101	29	1D	GS	组群分隔符
            ''' </summary>
            Public Const GS As Integer = 29
            ''' <summary>
            ''' 0001 1110	30	1E	RS	记录分隔符
            ''' </summary>
            Public Const RS As Integer = 30
            ''' <summary>
            ''' 0001 1111	31	1F	US	单元分隔符
            ''' </summary>
            Public Const US As Integer = 31
            ''' <summary>
            ''' 0111 1111	127	7F	DEL	删除
            ''' </summary>
            Public Const DEL As Integer = 127

            ''' <summary>
            ''' <see cref="vbTab"/>
            ''' </summary>
            Public Const TAB As Integer = Asc(vbTab)

        End Class
    End Class
End Namespace
