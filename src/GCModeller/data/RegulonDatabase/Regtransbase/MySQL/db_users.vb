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
''' DROP TABLE IF EXISTS `db_users`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `db_users` (
'''   `id` int(11) NOT NULL DEFAULT '0',
'''   `user_role_id` int(11) DEFAULT NULL,
'''   `name` varchar(20) DEFAULT NULL,
'''   `full_name` varchar(100) DEFAULT NULL,
'''   `phone` varchar(100) DEFAULT '',
'''   `email` varchar(100) DEFAULT '',
'''   `fl_active` int(1) DEFAULT NULL,
'''   PRIMARY KEY (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("db_users", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `db_users` (
  `id` int(11) NOT NULL DEFAULT '0',
  `user_role_id` int(11) DEFAULT NULL,
  `name` varchar(20) DEFAULT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT '',
  `email` varchar(100) DEFAULT '',
  `fl_active` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class db_users: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("user_role_id"), DataType(MySqlDbType.Int64, "11")> Public Property user_role_id As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "20")> Public Property name As String
    <DatabaseField("full_name"), DataType(MySqlDbType.VarChar, "100")> Public Property full_name As String
    <DatabaseField("phone"), DataType(MySqlDbType.VarChar, "100")> Public Property phone As String
    <DatabaseField("email"), DataType(MySqlDbType.VarChar, "100")> Public Property email As String
    <DatabaseField("fl_active"), DataType(MySqlDbType.Int64, "1")> Public Property fl_active As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `db_users` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `db_users` SET `id`='{0}', `user_role_id`='{1}', `name`='{2}', `full_name`='{3}', `phone`='{4}', `email`='{5}', `fl_active`='{6}' WHERE `id` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `db_users` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{user_role_id}', '{name}', '{full_name}', '{phone}', '{email}', '{fl_active}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `db_users` SET `id`='{0}', `user_role_id`='{1}', `name`='{2}', `full_name`='{3}', `phone`='{4}', `email`='{5}', `fl_active`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, user_role_id, name, full_name, phone, email, fl_active, id)
    End Function
#End Region
End Class


End Namespace
