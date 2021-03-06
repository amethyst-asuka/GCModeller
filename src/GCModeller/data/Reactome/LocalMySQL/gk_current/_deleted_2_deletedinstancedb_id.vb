REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `_deleted_2_deletedinstancedb_id`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `_deleted_2_deletedinstancedb_id` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `deletedInstanceDB_ID_rank` int(10) unsigned DEFAULT NULL,
'''   `deletedInstanceDB_ID` int(10) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `deletedInstanceDB_ID` (`deletedInstanceDB_ID`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("_deleted_2_deletedinstancedb_id", Database:="gk_current", SchemaSQL:="
CREATE TABLE `_deleted_2_deletedinstancedb_id` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `deletedInstanceDB_ID_rank` int(10) unsigned DEFAULT NULL,
  `deletedInstanceDB_ID` int(10) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `deletedInstanceDB_ID` (`deletedInstanceDB_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class _deleted_2_deletedinstancedb_id: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("deletedInstanceDB_ID_rank"), DataType(MySqlDbType.Int64, "10")> Public Property deletedInstanceDB_ID_rank As Long
    <DatabaseField("deletedInstanceDB_ID"), DataType(MySqlDbType.Int64, "10")> Public Property deletedInstanceDB_ID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `_deleted_2_deletedinstancedb_id` (`DB_ID`, `deletedInstanceDB_ID_rank`, `deletedInstanceDB_ID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `_deleted_2_deletedinstancedb_id` (`DB_ID`, `deletedInstanceDB_ID_rank`, `deletedInstanceDB_ID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `_deleted_2_deletedinstancedb_id` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `_deleted_2_deletedinstancedb_id` SET `DB_ID`='{0}', `deletedInstanceDB_ID_rank`='{1}', `deletedInstanceDB_ID`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `_deleted_2_deletedinstancedb_id` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `_deleted_2_deletedinstancedb_id` (`DB_ID`, `deletedInstanceDB_ID_rank`, `deletedInstanceDB_ID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, deletedInstanceDB_ID_rank, deletedInstanceDB_ID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{deletedInstanceDB_ID_rank}', '{deletedInstanceDB_ID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `_deleted_2_deletedinstancedb_id` (`DB_ID`, `deletedInstanceDB_ID_rank`, `deletedInstanceDB_ID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, deletedInstanceDB_ID_rank, deletedInstanceDB_ID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `_deleted_2_deletedinstancedb_id` SET `DB_ID`='{0}', `deletedInstanceDB_ID_rank`='{1}', `deletedInstanceDB_ID`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, deletedInstanceDB_ID_rank, deletedInstanceDB_ID, DB_ID)
    End Function
#End Region
End Class


End Namespace
