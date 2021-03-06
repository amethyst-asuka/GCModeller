REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 10:54:58 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dict_regulator_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_regulator_types` (
'''   `regulator_type_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(100) NOT NULL DEFAULT '',
'''   PRIMARY KEY (`regulator_type_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_regulator_types", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_regulator_types` (
  `regulator_type_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`regulator_type_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dict_regulator_types: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulator_type_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property regulator_type_guid As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dict_regulator_types` (`regulator_type_guid`, `name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dict_regulator_types` (`regulator_type_guid`, `name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dict_regulator_types` WHERE `regulator_type_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dict_regulator_types` SET `regulator_type_guid`='{0}', `name`='{1}' WHERE `regulator_type_guid` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dict_regulator_types` WHERE `regulator_type_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, regulator_type_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dict_regulator_types` (`regulator_type_guid`, `name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulator_type_guid, name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulator_type_guid}', '{name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_regulator_types` (`regulator_type_guid`, `name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulator_type_guid, name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dict_regulator_types` SET `regulator_type_guid`='{0}', `name`='{1}' WHERE `regulator_type_guid` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, regulator_type_guid, name, regulator_type_guid)
    End Function
#End Region
End Class


End Namespace
