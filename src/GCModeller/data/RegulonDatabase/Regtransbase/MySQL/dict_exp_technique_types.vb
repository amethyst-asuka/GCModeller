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
''' DROP TABLE IF EXISTS `dict_exp_technique_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_exp_technique_types` (
'''   `exp_technique_type_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(100) DEFAULT NULL,
'''   `exp_technique_type_superclass_guid` int(10) unsigned DEFAULT NULL,
'''   PRIMARY KEY (`exp_technique_type_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_exp_technique_types", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_exp_technique_types` (
  `exp_technique_type_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(100) DEFAULT NULL,
  `exp_technique_type_superclass_guid` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`exp_technique_type_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dict_exp_technique_types: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("exp_technique_type_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property exp_technique_type_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "100")> Public Property name As String
    <DatabaseField("exp_technique_type_superclass_guid"), DataType(MySqlDbType.Int64, "10")> Public Property exp_technique_type_superclass_guid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dict_exp_technique_types` WHERE `exp_technique_type_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dict_exp_technique_types` SET `exp_technique_type_guid`='{0}', `name`='{1}', `exp_technique_type_superclass_guid`='{2}' WHERE `exp_technique_type_guid` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dict_exp_technique_types` WHERE `exp_technique_type_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, exp_technique_type_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{exp_technique_type_guid}', '{name}', '{exp_technique_type_superclass_guid}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dict_exp_technique_types` SET `exp_technique_type_guid`='{0}', `name`='{1}', `exp_technique_type_superclass_guid`='{2}' WHERE `exp_technique_type_guid` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid, exp_technique_type_guid)
    End Function
#End Region
End Class


End Namespace
