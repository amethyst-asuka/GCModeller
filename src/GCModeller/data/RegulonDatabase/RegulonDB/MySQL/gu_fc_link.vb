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
''' DROP TABLE IF EXISTS `gu_fc_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gu_fc_link` (
'''   `gu_id` char(12) NOT NULL,
'''   `functional_class_id` char(12) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gu_fc_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `gu_fc_link` (
  `gu_id` char(12) NOT NULL,
  `functional_class_id` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class gu_fc_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gu_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property gu_id As String
    <DatabaseField("functional_class_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property functional_class_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gu_fc_link` (`gu_id`, `functional_class_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gu_fc_link` (`gu_id`, `functional_class_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gu_fc_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gu_fc_link` SET `gu_id`='{0}', `functional_class_id`='{1}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gu_fc_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gu_fc_link` (`gu_id`, `functional_class_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gu_id, functional_class_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gu_id}', '{functional_class_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gu_fc_link` (`gu_id`, `functional_class_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gu_id, functional_class_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gu_fc_link` SET `gu_id`='{0}', `functional_class_id`='{1}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
