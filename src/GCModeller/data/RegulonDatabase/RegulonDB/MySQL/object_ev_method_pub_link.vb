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
''' DROP TABLE IF EXISTS `object_ev_method_pub_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `object_ev_method_pub_link` (
'''   `object_id` char(12) NOT NULL,
'''   `evidence_id` char(12) DEFAULT NULL,
'''   `method_id` char(12) DEFAULT NULL,
'''   `publication_id` char(12) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("object_ev_method_pub_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `object_ev_method_pub_link` (
  `object_id` char(12) NOT NULL,
  `evidence_id` char(12) DEFAULT NULL,
  `method_id` char(12) DEFAULT NULL,
  `publication_id` char(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class object_ev_method_pub_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("object_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property object_id As String
    <DatabaseField("evidence_id"), DataType(MySqlDbType.VarChar, "12")> Public Property evidence_id As String
    <DatabaseField("method_id"), DataType(MySqlDbType.VarChar, "12")> Public Property method_id As String
    <DatabaseField("publication_id"), DataType(MySqlDbType.VarChar, "12")> Public Property publication_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `object_ev_method_pub_link` (`object_id`, `evidence_id`, `method_id`, `publication_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `object_ev_method_pub_link` (`object_id`, `evidence_id`, `method_id`, `publication_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `object_ev_method_pub_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `object_ev_method_pub_link` SET `object_id`='{0}', `evidence_id`='{1}', `method_id`='{2}', `publication_id`='{3}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `object_ev_method_pub_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `object_ev_method_pub_link` (`object_id`, `evidence_id`, `method_id`, `publication_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, object_id, evidence_id, method_id, publication_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{object_id}', '{evidence_id}', '{method_id}', '{publication_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `object_ev_method_pub_link` (`object_id`, `evidence_id`, `method_id`, `publication_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, object_id, evidence_id, method_id, publication_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `object_ev_method_pub_link` SET `object_id`='{0}', `evidence_id`='{1}', `method_id`='{2}', `publication_id`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
