﻿#Region "Microsoft.VisualBasic::e5e87d95e9c8be40426b39c80c2fa437, ..\repository\DataMySql\Interpro\Tables\entry2entry.vb"

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
''' DROP TABLE IF EXISTS `entry2entry`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entry2entry` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `parent_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `relation` char(2) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   PRIMARY KEY (`entry_ac`,`parent_ac`),
'''   KEY `fk_entry2entry$parent` (`parent_ac`),
'''   KEY `fk_entry2entry$relation` (`relation`),
'''   CONSTRAINT `fk_entry2entry$child` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_entry2entry$parent` FOREIGN KEY (`parent_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_entry2entry$relation` FOREIGN KEY (`relation`) REFERENCES `cv_relation` (`code`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entry2entry", Database:="interpro", SchemaSQL:="
CREATE TABLE `entry2entry` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `parent_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `relation` char(2) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`entry_ac`,`parent_ac`),
  KEY `fk_entry2entry$parent` (`parent_ac`),
  KEY `fk_entry2entry$relation` (`relation`),
  CONSTRAINT `fk_entry2entry$child` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_entry2entry$parent` FOREIGN KEY (`parent_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_entry2entry$relation` FOREIGN KEY (`relation`) REFERENCES `cv_relation` (`code`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class entry2entry: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property entry_ac As String
    <DatabaseField("parent_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property parent_ac As String
    <DatabaseField("relation"), NotNull, DataType(MySqlDbType.VarChar, "2")> Public Property relation As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `entry2entry` (`entry_ac`, `parent_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `entry2entry` (`entry_ac`, `parent_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `entry2entry` WHERE `entry_ac`='{0}' and `parent_ac`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `entry2entry` SET `entry_ac`='{0}', `parent_ac`='{1}', `relation`='{2}' WHERE `entry_ac`='{3}' and `parent_ac`='{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `entry2entry` WHERE `entry_ac`='{0}' and `parent_ac`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac, parent_ac)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `entry2entry` (`entry_ac`, `parent_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, parent_ac, relation)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{parent_ac}', '{relation}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `entry2entry` (`entry_ac`, `parent_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, parent_ac, relation)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `entry2entry` SET `entry_ac`='{0}', `parent_ac`='{1}', `relation`='{2}' WHERE `entry_ac`='{3}' and `parent_ac`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, parent_ac, relation, entry_ac, parent_ac)
    End Function
#End Region
End Class


End Namespace

