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
''' DROP TABLE IF EXISTS `interaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `interaction` (
'''   `interaction_id` varchar(12) NOT NULL,
'''   `regulator_id` varchar(12) DEFAULT NULL,
'''   `promoter_id` char(12) DEFAULT NULL,
'''   `site_id` char(12) DEFAULT NULL,
'''   `interaction_function` varchar(12) DEFAULT NULL,
'''   `center_position` decimal(20,2) DEFAULT NULL,
'''   `interaction_first_gene_id` varchar(12) DEFAULT NULL,
'''   `affinity_exp` decimal(20,5) DEFAULT NULL,
'''   `interaction_note` varchar(2000) DEFAULT NULL,
'''   `interaction_internal_comment` longtext,
'''   `interaction_sequence` varchar(100) DEFAULT NULL,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("interaction", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `interaction` (
  `interaction_id` varchar(12) NOT NULL,
  `regulator_id` varchar(12) DEFAULT NULL,
  `promoter_id` char(12) DEFAULT NULL,
  `site_id` char(12) DEFAULT NULL,
  `interaction_function` varchar(12) DEFAULT NULL,
  `center_position` decimal(20,2) DEFAULT NULL,
  `interaction_first_gene_id` varchar(12) DEFAULT NULL,
  `affinity_exp` decimal(20,5) DEFAULT NULL,
  `interaction_note` varchar(2000) DEFAULT NULL,
  `interaction_internal_comment` longtext,
  `interaction_sequence` varchar(100) DEFAULT NULL,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class interaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("interaction_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property interaction_id As String
    <DatabaseField("regulator_id"), DataType(MySqlDbType.VarChar, "12")> Public Property regulator_id As String
    <DatabaseField("promoter_id"), DataType(MySqlDbType.VarChar, "12")> Public Property promoter_id As String
    <DatabaseField("site_id"), DataType(MySqlDbType.VarChar, "12")> Public Property site_id As String
    <DatabaseField("interaction_function"), DataType(MySqlDbType.VarChar, "12")> Public Property interaction_function As String
    <DatabaseField("center_position"), DataType(MySqlDbType.Decimal)> Public Property center_position As Decimal
    <DatabaseField("interaction_first_gene_id"), DataType(MySqlDbType.VarChar, "12")> Public Property interaction_first_gene_id As String
    <DatabaseField("affinity_exp"), DataType(MySqlDbType.Decimal)> Public Property affinity_exp As Decimal
    <DatabaseField("interaction_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property interaction_note As String
    <DatabaseField("interaction_internal_comment"), DataType(MySqlDbType.Text)> Public Property interaction_internal_comment As String
    <DatabaseField("interaction_sequence"), DataType(MySqlDbType.VarChar, "100")> Public Property interaction_sequence As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `interaction` (`interaction_id`, `regulator_id`, `promoter_id`, `site_id`, `interaction_function`, `center_position`, `interaction_first_gene_id`, `affinity_exp`, `interaction_note`, `interaction_internal_comment`, `interaction_sequence`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `interaction` (`interaction_id`, `regulator_id`, `promoter_id`, `site_id`, `interaction_function`, `center_position`, `interaction_first_gene_id`, `affinity_exp`, `interaction_note`, `interaction_internal_comment`, `interaction_sequence`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `interaction` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `interaction` SET `interaction_id`='{0}', `regulator_id`='{1}', `promoter_id`='{2}', `site_id`='{3}', `interaction_function`='{4}', `center_position`='{5}', `interaction_first_gene_id`='{6}', `affinity_exp`='{7}', `interaction_note`='{8}', `interaction_internal_comment`='{9}', `interaction_sequence`='{10}', `key_id_org`='{11}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `interaction` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `interaction` (`interaction_id`, `regulator_id`, `promoter_id`, `site_id`, `interaction_function`, `center_position`, `interaction_first_gene_id`, `affinity_exp`, `interaction_note`, `interaction_internal_comment`, `interaction_sequence`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, interaction_id, regulator_id, promoter_id, site_id, interaction_function, center_position, interaction_first_gene_id, affinity_exp, interaction_note, interaction_internal_comment, interaction_sequence, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{interaction_id}', '{regulator_id}', '{promoter_id}', '{site_id}', '{interaction_function}', '{center_position}', '{interaction_first_gene_id}', '{affinity_exp}', '{interaction_note}', '{interaction_internal_comment}', '{interaction_sequence}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `interaction` (`interaction_id`, `regulator_id`, `promoter_id`, `site_id`, `interaction_function`, `center_position`, `interaction_first_gene_id`, `affinity_exp`, `interaction_note`, `interaction_internal_comment`, `interaction_sequence`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, interaction_id, regulator_id, promoter_id, site_id, interaction_function, center_position, interaction_first_gene_id, affinity_exp, interaction_note, interaction_internal_comment, interaction_sequence, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `interaction` SET `interaction_id`='{0}', `regulator_id`='{1}', `promoter_id`='{2}', `site_id`='{3}', `interaction_function`='{4}', `center_position`='{5}', `interaction_first_gene_id`='{6}', `affinity_exp`='{7}', `interaction_note`='{8}', `interaction_internal_comment`='{9}', `interaction_sequence`='{10}', `key_id_org`='{11}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
