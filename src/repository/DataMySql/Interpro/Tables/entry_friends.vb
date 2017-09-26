﻿#Region "Microsoft.VisualBasic::9bbdd5e13ed4fe6da96adab4885027bc, ..\repository\DataMySql\Interpro\Tables\entry_friends.vb"

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
''' DROP TABLE IF EXISTS `entry_friends`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entry_friends` (
'''   `entry1_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `entry2_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `s` int(3) NOT NULL,
'''   `p1` int(7) NOT NULL,
'''   `p2` int(7) NOT NULL,
'''   `pb` int(7) NOT NULL,
'''   `a1` int(5) NOT NULL,
'''   `a2` int(5) NOT NULL,
'''   `ab` int(5) NOT NULL,
'''   PRIMARY KEY (`entry1_ac`,`entry2_ac`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entry_friends", Database:="interpro", SchemaSQL:="
CREATE TABLE `entry_friends` (
  `entry1_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `entry2_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `s` int(3) NOT NULL,
  `p1` int(7) NOT NULL,
  `p2` int(7) NOT NULL,
  `pb` int(7) NOT NULL,
  `a1` int(5) NOT NULL,
  `a2` int(5) NOT NULL,
  `ab` int(5) NOT NULL,
  PRIMARY KEY (`entry1_ac`,`entry2_ac`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class entry_friends: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry1_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property entry1_ac As String
    <DatabaseField("entry2_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property entry2_ac As String
    <DatabaseField("s"), NotNull, DataType(MySqlDbType.Int64, "3")> Public Property s As Long
    <DatabaseField("p1"), NotNull, DataType(MySqlDbType.Int64, "7")> Public Property p1 As Long
    <DatabaseField("p2"), NotNull, DataType(MySqlDbType.Int64, "7")> Public Property p2 As Long
    <DatabaseField("pb"), NotNull, DataType(MySqlDbType.Int64, "7")> Public Property pb As Long
    <DatabaseField("a1"), NotNull, DataType(MySqlDbType.Int64, "5")> Public Property a1 As Long
    <DatabaseField("a2"), NotNull, DataType(MySqlDbType.Int64, "5")> Public Property a2 As Long
    <DatabaseField("ab"), NotNull, DataType(MySqlDbType.Int64, "5")> Public Property ab As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `entry_friends` (`entry1_ac`, `entry2_ac`, `s`, `p1`, `p2`, `pb`, `a1`, `a2`, `ab`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `entry_friends` (`entry1_ac`, `entry2_ac`, `s`, `p1`, `p2`, `pb`, `a1`, `a2`, `ab`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `entry_friends` WHERE `entry1_ac`='{0}' and `entry2_ac`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `entry_friends` SET `entry1_ac`='{0}', `entry2_ac`='{1}', `s`='{2}', `p1`='{3}', `p2`='{4}', `pb`='{5}', `a1`='{6}', `a2`='{7}', `ab`='{8}' WHERE `entry1_ac`='{9}' and `entry2_ac`='{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `entry_friends` WHERE `entry1_ac`='{0}' and `entry2_ac`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry1_ac, entry2_ac)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `entry_friends` (`entry1_ac`, `entry2_ac`, `s`, `p1`, `p2`, `pb`, `a1`, `a2`, `ab`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry1_ac, entry2_ac, s, p1, p2, pb, a1, a2, ab)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry1_ac}', '{entry2_ac}', '{s}', '{p1}', '{p2}', '{pb}', '{a1}', '{a2}', '{ab}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `entry_friends` (`entry1_ac`, `entry2_ac`, `s`, `p1`, `p2`, `pb`, `a1`, `a2`, `ab`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry1_ac, entry2_ac, s, p1, p2, pb, a1, a2, ab)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `entry_friends` SET `entry1_ac`='{0}', `entry2_ac`='{1}', `s`='{2}', `p1`='{3}', `p2`='{4}', `pb`='{5}', `a1`='{6}', `a2`='{7}', `ab`='{8}' WHERE `entry1_ac`='{9}' and `entry2_ac`='{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry1_ac, entry2_ac, s, p1, p2, pb, a1, a2, ab, entry1_ac, entry2_ac)
    End Function
#End Region
End Class


End Namespace

