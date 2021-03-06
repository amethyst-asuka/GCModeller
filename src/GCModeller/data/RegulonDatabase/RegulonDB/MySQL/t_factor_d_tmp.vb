REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `t_factor_d_tmp`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `t_factor_d_tmp` (
'''   `tf_id` decimal(10,0) NOT NULL,
'''   `t_factor_id` char(12) NOT NULL,
'''   `t_factor_name` varchar(255) DEFAULT NULL,
'''   `t_factor_site_length` decimal(10,0) DEFAULT NULL,
'''   `t_factor_key_id_org` char(5) NOT NULL,
'''   `t_factor_site_group` decimal(10,0) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("t_factor_d_tmp", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `t_factor_d_tmp` (
  `tf_id` decimal(10,0) NOT NULL,
  `t_factor_id` char(12) NOT NULL,
  `t_factor_name` varchar(255) DEFAULT NULL,
  `t_factor_site_length` decimal(10,0) DEFAULT NULL,
  `t_factor_key_id_org` char(5) NOT NULL,
  `t_factor_site_group` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class t_factor_d_tmp: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_id"), NotNull, DataType(MySqlDbType.Decimal)> Public Property tf_id As Decimal
    <DatabaseField("t_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property t_factor_id As String
    <DatabaseField("t_factor_name"), DataType(MySqlDbType.VarChar, "255")> Public Property t_factor_name As String
    <DatabaseField("t_factor_site_length"), DataType(MySqlDbType.Decimal)> Public Property t_factor_site_length As Decimal
    <DatabaseField("t_factor_key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property t_factor_key_id_org As String
    <DatabaseField("t_factor_site_group"), NotNull, DataType(MySqlDbType.Decimal)> Public Property t_factor_site_group As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `t_factor_d_tmp` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `t_factor_d_tmp` SET `tf_id`='{0}', `t_factor_id`='{1}', `t_factor_name`='{2}', `t_factor_site_length`='{3}', `t_factor_key_id_org`='{4}', `t_factor_site_group`='{5}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `t_factor_d_tmp` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_id, t_factor_id, t_factor_name, t_factor_site_length, t_factor_key_id_org, t_factor_site_group)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_id}', '{t_factor_id}', '{t_factor_name}', '{t_factor_site_length}', '{t_factor_key_id_org}', '{t_factor_site_group}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_id, t_factor_id, t_factor_name, t_factor_site_length, t_factor_key_id_org, t_factor_site_group)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `t_factor_d_tmp` SET `tf_id`='{0}', `t_factor_id`='{1}', `t_factor_name`='{2}', `t_factor_site_length`='{3}', `t_factor_key_id_org`='{4}', `t_factor_site_group`='{5}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
