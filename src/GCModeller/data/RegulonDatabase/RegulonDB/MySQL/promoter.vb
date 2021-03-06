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
''' DROP TABLE IF EXISTS `promoter`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `promoter` (
'''   `promoter_id` char(12) NOT NULL,
'''   `promoter_name` varchar(255) DEFAULT NULL,
'''   `promoter_strand` varchar(10) DEFAULT NULL,
'''   `pos_1` decimal(10,0) DEFAULT NULL,
'''   `sigma_factor` varchar(80) DEFAULT NULL,
'''   `basal_trans_val` decimal(20,5) DEFAULT NULL,
'''   `equilibrium_const` decimal(20,5) DEFAULT NULL,
'''   `kinetic_const` decimal(20,5) DEFAULT NULL,
'''   `strength_seq` decimal(20,5) DEFAULT NULL,
'''   `promoter_sequence` varchar(200) DEFAULT NULL,
'''   `promoter_note` varchar(4000) DEFAULT NULL,
'''   `promoter_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("promoter", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `promoter` (
  `promoter_id` char(12) NOT NULL,
  `promoter_name` varchar(255) DEFAULT NULL,
  `promoter_strand` varchar(10) DEFAULT NULL,
  `pos_1` decimal(10,0) DEFAULT NULL,
  `sigma_factor` varchar(80) DEFAULT NULL,
  `basal_trans_val` decimal(20,5) DEFAULT NULL,
  `equilibrium_const` decimal(20,5) DEFAULT NULL,
  `kinetic_const` decimal(20,5) DEFAULT NULL,
  `strength_seq` decimal(20,5) DEFAULT NULL,
  `promoter_sequence` varchar(200) DEFAULT NULL,
  `promoter_note` varchar(4000) DEFAULT NULL,
  `promoter_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class promoter: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("promoter_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property promoter_id As String
    <DatabaseField("promoter_name"), DataType(MySqlDbType.VarChar, "255")> Public Property promoter_name As String
    <DatabaseField("promoter_strand"), DataType(MySqlDbType.VarChar, "10")> Public Property promoter_strand As String
    <DatabaseField("pos_1"), DataType(MySqlDbType.Decimal)> Public Property pos_1 As Decimal
    <DatabaseField("sigma_factor"), DataType(MySqlDbType.VarChar, "80")> Public Property sigma_factor As String
    <DatabaseField("basal_trans_val"), DataType(MySqlDbType.Decimal)> Public Property basal_trans_val As Decimal
    <DatabaseField("equilibrium_const"), DataType(MySqlDbType.Decimal)> Public Property equilibrium_const As Decimal
    <DatabaseField("kinetic_const"), DataType(MySqlDbType.Decimal)> Public Property kinetic_const As Decimal
    <DatabaseField("strength_seq"), DataType(MySqlDbType.Decimal)> Public Property strength_seq As Decimal
    <DatabaseField("promoter_sequence"), DataType(MySqlDbType.VarChar, "200")> Public Property promoter_sequence As String
    <DatabaseField("promoter_note"), DataType(MySqlDbType.VarChar, "4000")> Public Property promoter_note As String
    <DatabaseField("promoter_internal_comment"), DataType(MySqlDbType.Text)> Public Property promoter_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `promoter` (`promoter_id`, `promoter_name`, `promoter_strand`, `pos_1`, `sigma_factor`, `basal_trans_val`, `equilibrium_const`, `kinetic_const`, `strength_seq`, `promoter_sequence`, `promoter_note`, `promoter_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `promoter` (`promoter_id`, `promoter_name`, `promoter_strand`, `pos_1`, `sigma_factor`, `basal_trans_val`, `equilibrium_const`, `kinetic_const`, `strength_seq`, `promoter_sequence`, `promoter_note`, `promoter_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `promoter` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `promoter` SET `promoter_id`='{0}', `promoter_name`='{1}', `promoter_strand`='{2}', `pos_1`='{3}', `sigma_factor`='{4}', `basal_trans_val`='{5}', `equilibrium_const`='{6}', `kinetic_const`='{7}', `strength_seq`='{8}', `promoter_sequence`='{9}', `promoter_note`='{10}', `promoter_internal_comment`='{11}', `key_id_org`='{12}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `promoter` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `promoter` (`promoter_id`, `promoter_name`, `promoter_strand`, `pos_1`, `sigma_factor`, `basal_trans_val`, `equilibrium_const`, `kinetic_const`, `strength_seq`, `promoter_sequence`, `promoter_note`, `promoter_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, promoter_id, promoter_name, promoter_strand, pos_1, sigma_factor, basal_trans_val, equilibrium_const, kinetic_const, strength_seq, promoter_sequence, promoter_note, promoter_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{promoter_id}', '{promoter_name}', '{promoter_strand}', '{pos_1}', '{sigma_factor}', '{basal_trans_val}', '{equilibrium_const}', '{kinetic_const}', '{strength_seq}', '{promoter_sequence}', '{promoter_note}', '{promoter_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `promoter` (`promoter_id`, `promoter_name`, `promoter_strand`, `pos_1`, `sigma_factor`, `basal_trans_val`, `equilibrium_const`, `kinetic_const`, `strength_seq`, `promoter_sequence`, `promoter_note`, `promoter_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, promoter_id, promoter_name, promoter_strand, pos_1, sigma_factor, basal_trans_val, equilibrium_const, kinetic_const, strength_seq, promoter_sequence, promoter_note, promoter_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `promoter` SET `promoter_id`='{0}', `promoter_name`='{1}', `promoter_strand`='{2}', `pos_1`='{3}', `sigma_factor`='{4}', `basal_trans_val`='{5}', `equilibrium_const`='{6}', `kinetic_const`='{7}', `strength_seq`='{8}', `promoter_sequence`='{9}', `promoter_note`='{10}', `promoter_internal_comment`='{11}', `key_id_org`='{12}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
