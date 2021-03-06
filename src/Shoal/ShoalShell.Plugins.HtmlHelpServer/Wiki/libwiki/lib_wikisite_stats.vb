REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:20:41 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Wiki.MySQL

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `lib_wikisite_stats`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `lib_wikisite_stats` (
'''   `ss_row_id` int(10) unsigned NOT NULL,
'''   `ss_total_edits` bigint(20) unsigned DEFAULT '0',
'''   `ss_good_articles` bigint(20) unsigned DEFAULT '0',
'''   `ss_total_pages` bigint(20) DEFAULT '-1',
'''   `ss_users` bigint(20) DEFAULT '-1',
'''   `ss_active_users` bigint(20) DEFAULT '-1',
'''   `ss_images` int(11) DEFAULT '0',
'''   UNIQUE KEY `ss_row_id` (`ss_row_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=binary;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("lib_wikisite_stats", Database:="wiki")>
Public Class lib_wikisite_stats: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ss_row_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property ss_row_id As Long
    <DatabaseField("ss_total_edits"), DataType(MySqlDbType.Int64, "20")> Public Property ss_total_edits As Long
    <DatabaseField("ss_good_articles"), DataType(MySqlDbType.Int64, "20")> Public Property ss_good_articles As Long
    <DatabaseField("ss_total_pages"), DataType(MySqlDbType.Int64, "20")> Public Property ss_total_pages As Long
    <DatabaseField("ss_users"), DataType(MySqlDbType.Int64, "20")> Public Property ss_users As Long
    <DatabaseField("ss_active_users"), DataType(MySqlDbType.Int64, "20")> Public Property ss_active_users As Long
    <DatabaseField("ss_images"), DataType(MySqlDbType.Int64, "11")> Public Property ss_images As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `lib_wikisite_stats` (`ss_row_id`, `ss_total_edits`, `ss_good_articles`, `ss_total_pages`, `ss_users`, `ss_active_users`, `ss_images`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `lib_wikisite_stats` (`ss_row_id`, `ss_total_edits`, `ss_good_articles`, `ss_total_pages`, `ss_users`, `ss_active_users`, `ss_images`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `lib_wikisite_stats` WHERE `ss_row_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `lib_wikisite_stats` SET `ss_row_id`='{0}', `ss_total_edits`='{1}', `ss_good_articles`='{2}', `ss_total_pages`='{3}', `ss_users`='{4}', `ss_active_users`='{5}', `ss_images`='{6}' WHERE `ss_row_id` = '{7}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ss_row_id)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ss_row_id, ss_total_edits, ss_good_articles, ss_total_pages, ss_users, ss_active_users, ss_images)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ss_row_id, ss_total_edits, ss_good_articles, ss_total_pages, ss_users, ss_active_users, ss_images)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ss_row_id, ss_total_edits, ss_good_articles, ss_total_pages, ss_users, ss_active_users, ss_images, ss_row_id)
    End Function
#End Region
End Class


End Namespace
