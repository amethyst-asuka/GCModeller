﻿#Region "Microsoft.VisualBasic::b3e35db2f3effedc332dfc2e084da246, ..\GO_gene-ontology\MySQL\Tables\relation_composition.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:49:20 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `relation_composition`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `relation_composition` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `relation1_id` int(11) NOT NULL,
'''   `relation2_id` int(11) NOT NULL,
'''   `inferred_relation_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `relation1_id` (`relation1_id`,`relation2_id`,`inferred_relation_id`),
'''   KEY `rc1` (`relation1_id`),
'''   KEY `rc2` (`relation2_id`),
'''   KEY `rc3` (`inferred_relation_id`),
'''   KEY `rc4` (`relation1_id`,`relation2_id`,`inferred_relation_id`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("relation_composition", Database:="go")>
Public Class relation_composition: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("relation1_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property relation1_id As Long
    <DatabaseField("relation2_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property relation2_id As Long
    <DatabaseField("inferred_relation_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property inferred_relation_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `relation_composition` (`relation1_id`, `relation2_id`, `inferred_relation_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `relation_composition` (`relation1_id`, `relation2_id`, `inferred_relation_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `relation_composition` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `relation_composition` SET `id`='{0}', `relation1_id`='{1}', `relation2_id`='{2}', `inferred_relation_id`='{3}' WHERE `id` = '{4}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, relation1_id, relation2_id, inferred_relation_id)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, relation1_id, relation2_id, inferred_relation_id)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, relation1_id, relation2_id, inferred_relation_id, id)
    End Function
#End Region
End Class


End Namespace

