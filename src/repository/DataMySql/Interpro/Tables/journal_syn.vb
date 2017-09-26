﻿#Region "Microsoft.VisualBasic::c14062f33c609934c730225b51f9a375, ..\repository\DataMySql\Interpro\Tables\journal_syn.vb"

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
''' DROP TABLE IF EXISTS `journal_syn`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `journal_syn` (
'''   `issn` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `code` char(4) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `text` varchar(200) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `uppercase` varchar(200) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   PRIMARY KEY (`issn`,`text`,`code`),
'''   KEY `fk_journal_syn$code` (`code`),
'''   CONSTRAINT `fk_journal_syn$code` FOREIGN KEY (`code`) REFERENCES `cv_synonym` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_journal_syn$issn` FOREIGN KEY (`issn`) REFERENCES `journal` (`issn`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("journal_syn", Database:="interpro", SchemaSQL:="
CREATE TABLE `journal_syn` (
  `issn` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `code` char(4) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `text` varchar(200) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `uppercase` varchar(200) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  PRIMARY KEY (`issn`,`text`,`code`),
  KEY `fk_journal_syn$code` (`code`),
  CONSTRAINT `fk_journal_syn$code` FOREIGN KEY (`code`) REFERENCES `cv_synonym` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_journal_syn$issn` FOREIGN KEY (`issn`) REFERENCES `journal` (`issn`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class journal_syn: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("issn"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "10")> Public Property issn As String
    <DatabaseField("code"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "4")> Public Property code As String
    <DatabaseField("text"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "200")> Public Property text As String
    <DatabaseField("uppercase"), DataType(MySqlDbType.VarChar, "200")> Public Property uppercase As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `journal_syn` (`issn`, `code`, `text`, `uppercase`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `journal_syn` (`issn`, `code`, `text`, `uppercase`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `journal_syn` WHERE `issn`='{0}' and `text`='{1}' and `code`='{2}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `journal_syn` SET `issn`='{0}', `code`='{1}', `text`='{2}', `uppercase`='{3}' WHERE `issn`='{4}' and `text`='{5}' and `code`='{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `journal_syn` WHERE `issn`='{0}' and `text`='{1}' and `code`='{2}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, issn, text, code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `journal_syn` (`issn`, `code`, `text`, `uppercase`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, issn, code, text, uppercase)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{issn}', '{code}', '{text}', '{uppercase}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `journal_syn` (`issn`, `code`, `text`, `uppercase`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, issn, code, text, uppercase)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `journal_syn` SET `issn`='{0}', `code`='{1}', `text`='{2}', `uppercase`='{3}' WHERE `issn`='{4}' and `text`='{5}' and `code`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, issn, code, text, uppercase, issn, text, code)
    End Function
#End Region
End Class


End Namespace

