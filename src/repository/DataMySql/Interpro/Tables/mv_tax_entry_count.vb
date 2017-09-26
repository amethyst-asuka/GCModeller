﻿#Region "Microsoft.VisualBasic::3cd8ef919b0a21a9d5c5b087888fe38b, ..\repository\DataMySql\Interpro\Tables\mv_tax_entry_count.vb"

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

REM  Dump @3/29/2017 10:21:21 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `mv_tax_entry_count`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mv_tax_entry_count` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `tax_id` decimal(22,0) NOT NULL,
'''   `count` decimal(22,0) NOT NULL,
'''   PRIMARY KEY (`entry_ac`,`tax_id`,`count`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mv_tax_entry_count", Database:="interpro", SchemaSQL:="
CREATE TABLE `mv_tax_entry_count` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `tax_id` decimal(22,0) NOT NULL,
  `count` decimal(22,0) NOT NULL,
  PRIMARY KEY (`entry_ac`,`tax_id`,`count`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class mv_tax_entry_count: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property entry_ac As String
    <DatabaseField("tax_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Decimal)> Public Property tax_id As Decimal
    <DatabaseField("count"), PrimaryKey, NotNull, DataType(MySqlDbType.Decimal)> Public Property count As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `mv_tax_entry_count` WHERE `entry_ac`='{0}' and `tax_id`='{1}' and `count`='{2}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `mv_tax_entry_count` SET `entry_ac`='{0}', `tax_id`='{1}', `count`='{2}' WHERE `entry_ac`='{3}' and `tax_id`='{4}' and `count`='{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `mv_tax_entry_count` WHERE `entry_ac`='{0}' and `tax_id`='{1}' and `count`='{2}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac, tax_id, count)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, tax_id, count)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{tax_id}', '{count}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, tax_id, count)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `mv_tax_entry_count` SET `entry_ac`='{0}', `tax_id`='{1}', `count`='{2}' WHERE `entry_ac`='{3}' and `tax_id`='{4}' and `count`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, tax_id, count, entry_ac, tax_id, count)
    End Function
#End Region
End Class


End Namespace

