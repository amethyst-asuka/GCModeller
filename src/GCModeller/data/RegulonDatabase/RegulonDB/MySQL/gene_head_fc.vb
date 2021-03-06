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
''' DROP TABLE IF EXISTS `gene_head_fc`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene_head_fc` (
'''   `gene_id` char(12) DEFAULT NULL,
'''   `gene_name` varchar(255) DEFAULT NULL,
'''   `head_fc_id` char(12) DEFAULT NULL,
'''   `head_fc_description` varchar(500) DEFAULT NULL,
'''   `head_fc_label_index` varchar(50) DEFAULT NULL,
'''   `head_fc_reference` varchar(255) DEFAULT NULL,
'''   `child_fc_id` char(12) DEFAULT NULL,
'''   `child_fc_description` varchar(500) DEFAULT NULL,
'''   `child_fc_label_index` varchar(50) DEFAULT NULL,
'''   `child_fc_reference` varchar(255) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene_head_fc", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `gene_head_fc` (
  `gene_id` char(12) DEFAULT NULL,
  `gene_name` varchar(255) DEFAULT NULL,
  `head_fc_id` char(12) DEFAULT NULL,
  `head_fc_description` varchar(500) DEFAULT NULL,
  `head_fc_label_index` varchar(50) DEFAULT NULL,
  `head_fc_reference` varchar(255) DEFAULT NULL,
  `child_fc_id` char(12) DEFAULT NULL,
  `child_fc_description` varchar(500) DEFAULT NULL,
  `child_fc_label_index` varchar(50) DEFAULT NULL,
  `child_fc_reference` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class gene_head_fc: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gene_id"), DataType(MySqlDbType.VarChar, "12")> Public Property gene_id As String
    <DatabaseField("gene_name"), DataType(MySqlDbType.VarChar, "255")> Public Property gene_name As String
    <DatabaseField("head_fc_id"), DataType(MySqlDbType.VarChar, "12")> Public Property head_fc_id As String
    <DatabaseField("head_fc_description"), DataType(MySqlDbType.VarChar, "500")> Public Property head_fc_description As String
    <DatabaseField("head_fc_label_index"), DataType(MySqlDbType.VarChar, "50")> Public Property head_fc_label_index As String
    <DatabaseField("head_fc_reference"), DataType(MySqlDbType.VarChar, "255")> Public Property head_fc_reference As String
    <DatabaseField("child_fc_id"), DataType(MySqlDbType.VarChar, "12")> Public Property child_fc_id As String
    <DatabaseField("child_fc_description"), DataType(MySqlDbType.VarChar, "500")> Public Property child_fc_description As String
    <DatabaseField("child_fc_label_index"), DataType(MySqlDbType.VarChar, "50")> Public Property child_fc_label_index As String
    <DatabaseField("child_fc_reference"), DataType(MySqlDbType.VarChar, "255")> Public Property child_fc_reference As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene_head_fc` (`gene_id`, `gene_name`, `head_fc_id`, `head_fc_description`, `head_fc_label_index`, `head_fc_reference`, `child_fc_id`, `child_fc_description`, `child_fc_label_index`, `child_fc_reference`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene_head_fc` (`gene_id`, `gene_name`, `head_fc_id`, `head_fc_description`, `head_fc_label_index`, `head_fc_reference`, `child_fc_id`, `child_fc_description`, `child_fc_label_index`, `child_fc_reference`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene_head_fc` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene_head_fc` SET `gene_id`='{0}', `gene_name`='{1}', `head_fc_id`='{2}', `head_fc_description`='{3}', `head_fc_label_index`='{4}', `head_fc_reference`='{5}', `child_fc_id`='{6}', `child_fc_description`='{7}', `child_fc_label_index`='{8}', `child_fc_reference`='{9}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene_head_fc` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene_head_fc` (`gene_id`, `gene_name`, `head_fc_id`, `head_fc_description`, `head_fc_label_index`, `head_fc_reference`, `child_fc_id`, `child_fc_description`, `child_fc_label_index`, `child_fc_reference`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gene_id, gene_name, head_fc_id, head_fc_description, head_fc_label_index, head_fc_reference, child_fc_id, child_fc_description, child_fc_label_index, child_fc_reference)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gene_id}', '{gene_name}', '{head_fc_id}', '{head_fc_description}', '{head_fc_label_index}', '{head_fc_reference}', '{child_fc_id}', '{child_fc_description}', '{child_fc_label_index}', '{child_fc_reference}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gene_head_fc` (`gene_id`, `gene_name`, `head_fc_id`, `head_fc_description`, `head_fc_label_index`, `head_fc_reference`, `child_fc_id`, `child_fc_description`, `child_fc_label_index`, `child_fc_reference`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gene_id, gene_name, head_fc_id, head_fc_description, head_fc_label_index, head_fc_reference, child_fc_id, child_fc_description, child_fc_label_index, child_fc_reference)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene_head_fc` SET `gene_id`='{0}', `gene_name`='{1}', `head_fc_id`='{2}', `head_fc_description`='{3}', `head_fc_label_index`='{4}', `head_fc_reference`='{5}', `child_fc_id`='{6}', `child_fc_description`='{7}', `child_fc_label_index`='{8}', `child_fc_reference`='{9}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
