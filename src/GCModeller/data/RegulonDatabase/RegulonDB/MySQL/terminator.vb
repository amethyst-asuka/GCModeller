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
''' DROP TABLE IF EXISTS `terminator`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `terminator` (
'''   `terminator_id` char(12) NOT NULL,
'''   `terminator_dist_gene` decimal(10,0) DEFAULT NULL,
'''   `terminator_posleft` decimal(10,0) DEFAULT NULL,
'''   `terminator_posright` decimal(10,0) DEFAULT NULL,
'''   `terminator_class` varchar(30) DEFAULT NULL,
'''   `terminator_sequence` varchar(200) DEFAULT NULL,
'''   `terminator_note` varchar(2000) DEFAULT NULL,
'''   `terminator_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("terminator", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `terminator` (
  `terminator_id` char(12) NOT NULL,
  `terminator_dist_gene` decimal(10,0) DEFAULT NULL,
  `terminator_posleft` decimal(10,0) DEFAULT NULL,
  `terminator_posright` decimal(10,0) DEFAULT NULL,
  `terminator_class` varchar(30) DEFAULT NULL,
  `terminator_sequence` varchar(200) DEFAULT NULL,
  `terminator_note` varchar(2000) DEFAULT NULL,
  `terminator_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class terminator: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("terminator_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property terminator_id As String
    <DatabaseField("terminator_dist_gene"), DataType(MySqlDbType.Decimal)> Public Property terminator_dist_gene As Decimal
    <DatabaseField("terminator_posleft"), DataType(MySqlDbType.Decimal)> Public Property terminator_posleft As Decimal
    <DatabaseField("terminator_posright"), DataType(MySqlDbType.Decimal)> Public Property terminator_posright As Decimal
    <DatabaseField("terminator_class"), DataType(MySqlDbType.VarChar, "30")> Public Property terminator_class As String
    <DatabaseField("terminator_sequence"), DataType(MySqlDbType.VarChar, "200")> Public Property terminator_sequence As String
    <DatabaseField("terminator_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property terminator_note As String
    <DatabaseField("terminator_internal_comment"), DataType(MySqlDbType.Text)> Public Property terminator_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `terminator` (`terminator_id`, `terminator_dist_gene`, `terminator_posleft`, `terminator_posright`, `terminator_class`, `terminator_sequence`, `terminator_note`, `terminator_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `terminator` (`terminator_id`, `terminator_dist_gene`, `terminator_posleft`, `terminator_posright`, `terminator_class`, `terminator_sequence`, `terminator_note`, `terminator_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `terminator` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `terminator` SET `terminator_id`='{0}', `terminator_dist_gene`='{1}', `terminator_posleft`='{2}', `terminator_posright`='{3}', `terminator_class`='{4}', `terminator_sequence`='{5}', `terminator_note`='{6}', `terminator_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `terminator` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `terminator` (`terminator_id`, `terminator_dist_gene`, `terminator_posleft`, `terminator_posright`, `terminator_class`, `terminator_sequence`, `terminator_note`, `terminator_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, terminator_id, terminator_dist_gene, terminator_posleft, terminator_posright, terminator_class, terminator_sequence, terminator_note, terminator_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{terminator_id}', '{terminator_dist_gene}', '{terminator_posleft}', '{terminator_posright}', '{terminator_class}', '{terminator_sequence}', '{terminator_note}', '{terminator_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `terminator` (`terminator_id`, `terminator_dist_gene`, `terminator_posleft`, `terminator_posright`, `terminator_class`, `terminator_sequence`, `terminator_note`, `terminator_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, terminator_id, terminator_dist_gene, terminator_posleft, terminator_posright, terminator_class, terminator_sequence, terminator_note, terminator_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `terminator` SET `terminator_id`='{0}', `terminator_dist_gene`='{1}', `terminator_posleft`='{2}', `terminator_posright`='{3}', `terminator_class`='{4}', `terminator_sequence`='{5}', `terminator_note`='{6}', `terminator_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
