﻿#Region "Microsoft.VisualBasic::4df009d0d5cfe3d117991dc73fd7b724, ..\repository\DataMySql\CEG\MySQL\ceg_base.vb"

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

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:05:12 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace CEG.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `ceg_base`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `ceg_base` (
'''   `access_num` varchar(255) DEFAULT NULL,
'''   `koid` varchar(255) DEFAULT NULL,
'''   `cogid` varchar(255) NOT NULL,
'''   `description` varchar(255) NOT NULL,
'''   `ec` varchar(100) NOT NULL
''' ) ENGINE=MyISAM DEFAULT CHARSET=gb2312;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("ceg_base", Database:="ceg", SchemaSQL:="
CREATE TABLE `ceg_base` (
  `access_num` varchar(255) DEFAULT NULL,
  `koid` varchar(255) DEFAULT NULL,
  `cogid` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `ec` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=gb2312;")>
Public Class ceg_base: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("access_num"), DataType(MySqlDbType.VarChar, "255")> Public Property access_num As String
    <DatabaseField("koid"), DataType(MySqlDbType.VarChar, "255")> Public Property koid As String
    <DatabaseField("cogid"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property cogid As String
    <DatabaseField("description"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property description As String
    <DatabaseField("ec"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property ec As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `ceg_base` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `ceg_base` SET `access_num`='{0}', `koid`='{1}', `cogid`='{2}', `description`='{3}', `ec`='{4}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `ceg_base` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, access_num, koid, cogid, description, ec)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{access_num}', '{koid}', '{cogid}', '{description}', '{ec}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, access_num, koid, cogid, description, ec)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `ceg_base` SET `access_num`='{0}', `koid`='{1}', `cogid`='{2}', `description`='{3}', `ec`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace

