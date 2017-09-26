﻿#Region "Microsoft.VisualBasic::0fa15bc373167661dafc69384f2d0bef, ..\repository\DataMySql\Xfam\Rfam\Tables\clan_membership.vb"

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
''' DROP TABLE IF EXISTS `clan_membership`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `clan_membership` (
'''   `clan_acc` varchar(7) NOT NULL,
'''   `rfam_acc` varchar(7) NOT NULL,
'''   UNIQUE KEY `UniqueFamilyIdx` (`rfam_acc`),
'''   KEY `fk_clan_membership_family1_idx` (`rfam_acc`),
'''   KEY `fk_clan_membership_clan1_idx` (`clan_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("clan_membership", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `clan_membership` (
  `clan_acc` varchar(7) NOT NULL,
  `rfam_acc` varchar(7) NOT NULL,
  UNIQUE KEY `UniqueFamilyIdx` (`rfam_acc`),
  KEY `fk_clan_membership_family1_idx` (`rfam_acc`),
  KEY `fk_clan_membership_clan1_idx` (`clan_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class clan_membership: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("clan_acc"), NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property clan_acc As String
    <DatabaseField("rfam_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property rfam_acc As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `clan_membership` (`clan_acc`, `rfam_acc`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `clan_membership` (`clan_acc`, `rfam_acc`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `clan_membership` WHERE `rfam_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `clan_membership` SET `clan_acc`='{0}', `rfam_acc`='{1}' WHERE `rfam_acc` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `clan_membership` WHERE `rfam_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `clan_membership` (`clan_acc`, `rfam_acc`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, clan_acc, rfam_acc)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{clan_acc}', '{rfam_acc}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `clan_membership` (`clan_acc`, `rfam_acc`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, clan_acc, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `clan_membership` SET `clan_acc`='{0}', `rfam_acc`='{1}' WHERE `rfam_acc` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, clan_acc, rfam_acc, rfam_acc)
    End Function
#End Region
End Class


End Namespace
