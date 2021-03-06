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
''' DROP TABLE IF EXISTS `regulator`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulator` (
'''   `regulator_id` varchar(12) NOT NULL,
'''   `product_id` char(12) DEFAULT NULL,
'''   `regulator_name` varchar(250) DEFAULT NULL,
'''   `regulator_internal_commnet` varchar(2000) DEFAULT NULL,
'''   `regulator_note` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulator", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `regulator` (
  `regulator_id` varchar(12) NOT NULL,
  `product_id` char(12) DEFAULT NULL,
  `regulator_name` varchar(250) DEFAULT NULL,
  `regulator_internal_commnet` varchar(2000) DEFAULT NULL,
  `regulator_note` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class regulator: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulator_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property regulator_id As String
    <DatabaseField("product_id"), DataType(MySqlDbType.VarChar, "12")> Public Property product_id As String
    <DatabaseField("regulator_name"), DataType(MySqlDbType.VarChar, "250")> Public Property regulator_name As String
    <DatabaseField("regulator_internal_commnet"), DataType(MySqlDbType.VarChar, "2000")> Public Property regulator_internal_commnet As String
    <DatabaseField("regulator_note"), DataType(MySqlDbType.Text)> Public Property regulator_note As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulator` (`regulator_id`, `product_id`, `regulator_name`, `regulator_internal_commnet`, `regulator_note`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulator` (`regulator_id`, `product_id`, `regulator_name`, `regulator_internal_commnet`, `regulator_note`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulator` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulator` SET `regulator_id`='{0}', `product_id`='{1}', `regulator_name`='{2}', `regulator_internal_commnet`='{3}', `regulator_note`='{4}', `key_id_org`='{5}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulator` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulator` (`regulator_id`, `product_id`, `regulator_name`, `regulator_internal_commnet`, `regulator_note`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulator_id, product_id, regulator_name, regulator_internal_commnet, regulator_note, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulator_id}', '{product_id}', '{regulator_name}', '{regulator_internal_commnet}', '{regulator_note}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulator` (`regulator_id`, `product_id`, `regulator_name`, `regulator_internal_commnet`, `regulator_note`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulator_id, product_id, regulator_name, regulator_internal_commnet, regulator_note, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulator` SET `regulator_id`='{0}', `product_id`='{1}', `regulator_name`='{2}', `regulator_internal_commnet`='{3}', `regulator_note`='{4}', `key_id_org`='{5}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
