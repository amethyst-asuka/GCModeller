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
''' DROP TABLE IF EXISTS `tu_gene_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `tu_gene_link` (
'''   `transcription_unit_id` char(12) NOT NULL,
'''   `gene_id` char(12) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("tu_gene_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `tu_gene_link` (
  `transcription_unit_id` char(12) NOT NULL,
  `gene_id` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class tu_gene_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("transcription_unit_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property transcription_unit_id As String
    <DatabaseField("gene_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property gene_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `tu_gene_link` (`transcription_unit_id`, `gene_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `tu_gene_link` (`transcription_unit_id`, `gene_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `tu_gene_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `tu_gene_link` SET `transcription_unit_id`='{0}', `gene_id`='{1}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `tu_gene_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `tu_gene_link` (`transcription_unit_id`, `gene_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, transcription_unit_id, gene_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{transcription_unit_id}', '{gene_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `tu_gene_link` (`transcription_unit_id`, `gene_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, transcription_unit_id, gene_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `tu_gene_link` SET `transcription_unit_id`='{0}', `gene_id`='{1}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
