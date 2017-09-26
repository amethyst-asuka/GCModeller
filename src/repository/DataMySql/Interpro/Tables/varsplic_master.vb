﻿#Region "Microsoft.VisualBasic::6b669ee4cc1fe4902aad7a175bb2c25b, ..\repository\DataMySql\Interpro\Tables\varsplic_master.vb"

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
''' DROP TABLE IF EXISTS `varsplic_master`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `varsplic_master` (
'''   `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `variant` int(3) DEFAULT NULL,
'''   `crc64` varchar(16) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `length` int(5) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("varsplic_master", Database:="interpro", SchemaSQL:="
CREATE TABLE `varsplic_master` (
  `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `variant` int(3) DEFAULT NULL,
  `crc64` varchar(16) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `length` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class varsplic_master: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), DataType(MySqlDbType.VarChar, "6")> Public Property protein_ac As String
    <DatabaseField("variant"), DataType(MySqlDbType.Int64, "3")> Public Property [variant] As Long
    <DatabaseField("crc64"), DataType(MySqlDbType.VarChar, "16")> Public Property crc64 As String
    <DatabaseField("length"), DataType(MySqlDbType.Int64, "5")> Public Property length As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `varsplic_master` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `varsplic_master` SET `protein_ac`='{0}', `variant`='{1}', `crc64`='{2}', `length`='{3}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `varsplic_master` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, [variant], crc64, length)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{protein_ac}', '{[variant]}', '{crc64}', '{length}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, [variant], crc64, length)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `varsplic_master` SET `protein_ac`='{0}', `variant`='{1}', `crc64`='{2}', `length`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace

