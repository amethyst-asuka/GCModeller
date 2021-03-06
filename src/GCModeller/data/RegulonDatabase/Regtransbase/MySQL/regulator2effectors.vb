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
''' DROP TABLE IF EXISTS `regulator2effectors`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulator2effectors` (
'''   `regulator_guid` int(10) unsigned NOT NULL DEFAULT '0',
'''   `effector_guid` int(10) unsigned NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`regulator_guid`,`effector_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulator2effectors", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `regulator2effectors` (
  `regulator_guid` int(10) unsigned NOT NULL DEFAULT '0',
  `effector_guid` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`regulator_guid`,`effector_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class regulator2effectors: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulator_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property regulator_guid As Long
    <DatabaseField("effector_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property effector_guid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulator2effectors` WHERE `regulator_guid`='{0}' and `effector_guid`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulator2effectors` SET `regulator_guid`='{0}', `effector_guid`='{1}' WHERE `regulator_guid`='{2}' and `effector_guid`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulator2effectors` WHERE `regulator_guid`='{0}' and `effector_guid`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, regulator_guid, effector_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulator_guid, effector_guid)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulator_guid}', '{effector_guid}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulator_guid, effector_guid)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulator2effectors` SET `regulator_guid`='{0}', `effector_guid`='{1}' WHERE `regulator_guid`='{2}' and `effector_guid`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, regulator_guid, effector_guid, regulator_guid, effector_guid)
    End Function
#End Region
End Class


End Namespace
