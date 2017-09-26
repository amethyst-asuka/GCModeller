﻿#Region "Microsoft.VisualBasic::dd7303b7752dc60ab7643d75b0314aac, ..\repository\DataMySql\Xfam\Rfam\Tables\seed_region.vb"

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

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `seed_region`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `seed_region` (
'''   `rfam_acc` varchar(7) NOT NULL,
'''   `rfamseq_acc` varchar(20) NOT NULL,
'''   `seq_start` bigint(19) unsigned NOT NULL DEFAULT '0',
'''   `seq_end` bigint(19) unsigned NOT NULL,
'''   KEY `fk_rfam_reg_seed_family1_idx` (`rfam_acc`),
'''   KEY `fk_rfam_reg_seed_rfamseq1_idx` (`rfamseq_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("seed_region", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `seed_region` (
  `rfam_acc` varchar(7) NOT NULL,
  `rfamseq_acc` varchar(20) NOT NULL,
  `seq_start` bigint(19) unsigned NOT NULL DEFAULT '0',
  `seq_end` bigint(19) unsigned NOT NULL,
  KEY `fk_rfam_reg_seed_family1_idx` (`rfam_acc`),
  KEY `fk_rfam_reg_seed_rfamseq1_idx` (`rfamseq_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class seed_region: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property rfam_acc As String
    <DatabaseField("rfamseq_acc"), NotNull, DataType(MySqlDbType.VarChar, "20")> Public Property rfamseq_acc As String
    <DatabaseField("seq_start"), NotNull, DataType(MySqlDbType.Int64, "19")> Public Property seq_start As Long
    <DatabaseField("seq_end"), NotNull, DataType(MySqlDbType.Int64, "19")> Public Property seq_end As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `seed_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `seed_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `seed_region` WHERE `rfam_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `seed_region` SET `rfam_acc`='{0}', `rfamseq_acc`='{1}', `seq_start`='{2}', `seq_end`='{3}' WHERE `rfam_acc` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `seed_region` WHERE `rfam_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `seed_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{rfam_acc}', '{rfamseq_acc}', '{seq_start}', '{seq_end}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `seed_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `seed_region` SET `rfam_acc`='{0}', `rfamseq_acc`='{1}', `seq_start`='{2}', `seq_end`='{3}' WHERE `rfam_acc` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end, rfam_acc)
    End Function
#End Region
End Class


End Namespace
