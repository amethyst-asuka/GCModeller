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
''' DROP TABLE IF EXISTS `packages`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `packages` (
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `title` char(50) DEFAULT NULL,
'''   `annotator_id` int(11) DEFAULT NULL,
'''   `article_num` int(11) DEFAULT NULL,
'''   `pkg_state` int(11) NOT NULL DEFAULT '0',
'''   `pkg_state_date` char(10) DEFAULT NULL,
'''   `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`pkg_guid`),
'''   KEY `annotator_id` (`annotator_id`),
'''   CONSTRAINT `packages_ibfk_1` FOREIGN KEY (`annotator_id`) REFERENCES `db_users` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("packages", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `packages` (
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `title` char(50) DEFAULT NULL,
  `annotator_id` int(11) DEFAULT NULL,
  `article_num` int(11) DEFAULT NULL,
  `pkg_state` int(11) NOT NULL DEFAULT '0',
  `pkg_state_date` char(10) DEFAULT NULL,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`pkg_guid`),
  KEY `annotator_id` (`annotator_id`),
  CONSTRAINT `packages_ibfk_1` FOREIGN KEY (`annotator_id`) REFERENCES `db_users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class packages: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pkg_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_guid As Long
    <DatabaseField("title"), DataType(MySqlDbType.VarChar, "50")> Public Property title As String
    <DatabaseField("annotator_id"), DataType(MySqlDbType.Int64, "11")> Public Property annotator_id As Long
    <DatabaseField("article_num"), DataType(MySqlDbType.Int64, "11")> Public Property article_num As Long
    <DatabaseField("pkg_state"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_state As Long
    <DatabaseField("pkg_state_date"), DataType(MySqlDbType.VarChar, "10")> Public Property pkg_state_date As String
    <DatabaseField("last_update"), NotNull, DataType(MySqlDbType.DateTime)> Public Property last_update As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `packages` (`pkg_guid`, `title`, `annotator_id`, `article_num`, `pkg_state`, `pkg_state_date`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `packages` (`pkg_guid`, `title`, `annotator_id`, `article_num`, `pkg_state`, `pkg_state_date`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `packages` WHERE `pkg_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `packages` SET `pkg_guid`='{0}', `title`='{1}', `annotator_id`='{2}', `article_num`='{3}', `pkg_state`='{4}', `pkg_state_date`='{5}', `last_update`='{6}' WHERE `pkg_guid` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `packages` WHERE `pkg_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pkg_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `packages` (`pkg_guid`, `title`, `annotator_id`, `article_num`, `pkg_state`, `pkg_state_date`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pkg_guid, title, annotator_id, article_num, pkg_state, pkg_state_date, DataType.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pkg_guid}', '{title}', '{annotator_id}', '{article_num}', '{pkg_state}', '{pkg_state_date}', '{last_update}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `packages` (`pkg_guid`, `title`, `annotator_id`, `article_num`, `pkg_state`, `pkg_state_date`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pkg_guid, title, annotator_id, article_num, pkg_state, pkg_state_date, DataType.ToMySqlDateTimeString(last_update))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `packages` SET `pkg_guid`='{0}', `title`='{1}', `annotator_id`='{2}', `article_num`='{3}', `pkg_state`='{4}', `pkg_state_date`='{5}', `last_update`='{6}' WHERE `pkg_guid` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pkg_guid, title, annotator_id, article_num, pkg_state, pkg_state_date, DataType.ToMySqlDateTimeString(last_update), pkg_guid)
    End Function
#End Region
End Class


End Namespace
