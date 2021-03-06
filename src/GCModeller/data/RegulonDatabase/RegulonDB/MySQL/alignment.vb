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
''' DROP TABLE IF EXISTS `alignment`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `alignment` (
'''   `tf_alignment_id` char(12) NOT NULL,
'''   `site_id` char(12) NOT NULL,
'''   `alignment_sequence` varchar(255) NOT NULL,
'''   `alignment_score_sequence` decimal(10,0) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("alignment", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `alignment` (
  `tf_alignment_id` char(12) NOT NULL,
  `site_id` char(12) NOT NULL,
  `alignment_sequence` varchar(255) NOT NULL,
  `alignment_score_sequence` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class alignment: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_alignment_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property tf_alignment_id As String
    <DatabaseField("site_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property site_id As String
    <DatabaseField("alignment_sequence"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property alignment_sequence As String
    <DatabaseField("alignment_score_sequence"), NotNull, DataType(MySqlDbType.Decimal)> Public Property alignment_score_sequence As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `alignment` (`tf_alignment_id`, `site_id`, `alignment_sequence`, `alignment_score_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `alignment` (`tf_alignment_id`, `site_id`, `alignment_sequence`, `alignment_score_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `alignment` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `alignment` SET `tf_alignment_id`='{0}', `site_id`='{1}', `alignment_sequence`='{2}', `alignment_score_sequence`='{3}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `alignment` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `alignment` (`tf_alignment_id`, `site_id`, `alignment_sequence`, `alignment_score_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_alignment_id, site_id, alignment_sequence, alignment_score_sequence)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_alignment_id}', '{site_id}', '{alignment_sequence}', '{alignment_score_sequence}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `alignment` (`tf_alignment_id`, `site_id`, `alignment_sequence`, `alignment_score_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_alignment_id, site_id, alignment_sequence, alignment_score_sequence)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `alignment` SET `tf_alignment_id`='{0}', `site_id`='{1}', `alignment_sequence`='{2}', `alignment_score_sequence`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
