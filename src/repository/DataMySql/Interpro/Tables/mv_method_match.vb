﻿#Region "Microsoft.VisualBasic::5dcffdfa4d7b6bba580c1e66c2d406a5, ..\repository\DataMySql\Interpro\Tables\mv_method_match.vb"

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
''' DROP TABLE IF EXISTS `mv_method_match`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mv_method_match` (
'''   `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `protein_count` int(7) NOT NULL,
'''   `match_count` int(7) NOT NULL,
'''   PRIMARY KEY (`method_ac`),
'''   CONSTRAINT `fk_mv_method_match$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mv_method_match", Database:="interpro", SchemaSQL:="
CREATE TABLE `mv_method_match` (
  `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `protein_count` int(7) NOT NULL,
  `match_count` int(7) NOT NULL,
  PRIMARY KEY (`method_ac`),
  CONSTRAINT `fk_mv_method_match$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class mv_method_match: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("method_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "25")> Public Property method_ac As String
    <DatabaseField("protein_count"), NotNull, DataType(MySqlDbType.Int64, "7")> Public Property protein_count As Long
    <DatabaseField("match_count"), NotNull, DataType(MySqlDbType.Int64, "7")> Public Property match_count As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `mv_method_match` (`method_ac`, `protein_count`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `mv_method_match` (`method_ac`, `protein_count`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `mv_method_match` WHERE `method_ac` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `mv_method_match` SET `method_ac`='{0}', `protein_count`='{1}', `match_count`='{2}' WHERE `method_ac` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `mv_method_match` WHERE `method_ac` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, method_ac)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `mv_method_match` (`method_ac`, `protein_count`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, method_ac, protein_count, match_count)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{method_ac}', '{protein_count}', '{match_count}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mv_method_match` (`method_ac`, `protein_count`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, method_ac, protein_count, match_count)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `mv_method_match` SET `method_ac`='{0}', `protein_count`='{1}', `match_count`='{2}' WHERE `method_ac` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, method_ac, protein_count, match_count, method_ac)
    End Function
#End Region
End Class


End Namespace

