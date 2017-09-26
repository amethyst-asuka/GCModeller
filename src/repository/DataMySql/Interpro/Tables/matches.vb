﻿#Region "Microsoft.VisualBasic::3f7054036408a4429c140ca15d474849, ..\repository\DataMySql\Interpro\Tables\matches.vb"

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
''' DROP TABLE IF EXISTS `matches`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `matches` (
'''   `protein_ac` varchar(12) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `pos_from` int(5) DEFAULT NULL,
'''   `pos_to` int(5) DEFAULT NULL,
'''   `status` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `evidence` char(3) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `match_date` datetime NOT NULL,
'''   `seq_date` datetime NOT NULL,
'''   `score` double DEFAULT NULL,
'''   KEY `fk_matches$evidence` (`evidence`),
'''   KEY `fk_matches$method` (`method_ac`),
'''   CONSTRAINT `fk_matches$evidence` FOREIGN KEY (`evidence`) REFERENCES `cv_evidence` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_matches$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("matches", Database:="interpro", SchemaSQL:="
CREATE TABLE `matches` (
  `protein_ac` varchar(12) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `pos_from` int(5) DEFAULT NULL,
  `pos_to` int(5) DEFAULT NULL,
  `status` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `evidence` char(3) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `match_date` datetime NOT NULL,
  `seq_date` datetime NOT NULL,
  `score` double DEFAULT NULL,
  KEY `fk_matches$evidence` (`evidence`),
  KEY `fk_matches$method` (`method_ac`),
  CONSTRAINT `fk_matches$evidence` FOREIGN KEY (`evidence`) REFERENCES `cv_evidence` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_matches$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class matches: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property protein_ac As String
    <DatabaseField("method_ac"), NotNull, DataType(MySqlDbType.VarChar, "25")> Public Property method_ac As String
    <DatabaseField("pos_from"), DataType(MySqlDbType.Int64, "5")> Public Property pos_from As Long
    <DatabaseField("pos_to"), DataType(MySqlDbType.Int64, "5")> Public Property pos_to As Long
    <DatabaseField("status"), NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property status As String
    <DatabaseField("evidence"), PrimaryKey, DataType(MySqlDbType.VarChar, "3")> Public Property evidence As String
    <DatabaseField("match_date"), NotNull, DataType(MySqlDbType.DateTime)> Public Property match_date As Date
    <DatabaseField("seq_date"), NotNull, DataType(MySqlDbType.DateTime)> Public Property seq_date As Date
    <DatabaseField("score"), DataType(MySqlDbType.Double)> Public Property score As Double
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `matches` (`protein_ac`, `method_ac`, `pos_from`, `pos_to`, `status`, `evidence`, `match_date`, `seq_date`, `score`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `matches` (`protein_ac`, `method_ac`, `pos_from`, `pos_to`, `status`, `evidence`, `match_date`, `seq_date`, `score`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `matches` WHERE `evidence` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `matches` SET `protein_ac`='{0}', `method_ac`='{1}', `pos_from`='{2}', `pos_to`='{3}', `status`='{4}', `evidence`='{5}', `match_date`='{6}', `seq_date`='{7}', `score`='{8}' WHERE `evidence` = '{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `matches` WHERE `evidence` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, evidence)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `matches` (`protein_ac`, `method_ac`, `pos_from`, `pos_to`, `status`, `evidence`, `match_date`, `seq_date`, `score`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, method_ac, pos_from, pos_to, status, evidence, DataType.ToMySqlDateTimeString(match_date), DataType.ToMySqlDateTimeString(seq_date), score)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{protein_ac}', '{method_ac}', '{pos_from}', '{pos_to}', '{status}', '{evidence}', '{match_date}', '{seq_date}', '{score}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `matches` (`protein_ac`, `method_ac`, `pos_from`, `pos_to`, `status`, `evidence`, `match_date`, `seq_date`, `score`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, method_ac, pos_from, pos_to, status, evidence, DataType.ToMySqlDateTimeString(match_date), DataType.ToMySqlDateTimeString(seq_date), score)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `matches` SET `protein_ac`='{0}', `method_ac`='{1}', `pos_from`='{2}', `pos_to`='{3}', `status`='{4}', `evidence`='{5}', `match_date`='{6}', `seq_date`='{7}', `score`='{8}' WHERE `evidence` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, protein_ac, method_ac, pos_from, pos_to, status, evidence, DataType.ToMySqlDateTimeString(match_date), DataType.ToMySqlDateTimeString(seq_date), score, evidence)
    End Function
#End Region
End Class


End Namespace

