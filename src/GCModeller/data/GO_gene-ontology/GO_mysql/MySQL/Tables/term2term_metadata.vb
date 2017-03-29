REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:59 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `term2term_metadata`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `term2term_metadata` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `relationship_type_id` int(11) NOT NULL,
'''   `term1_id` int(11) NOT NULL,
'''   `term2_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `term1_id` (`term1_id`,`term2_id`),
'''   KEY `relationship_type_id` (`relationship_type_id`),
'''   KEY `term2_id` (`term2_id`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=2317 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("term2term_metadata", Database:="go", SchemaSQL:="
CREATE TABLE `term2term_metadata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `relationship_type_id` int(11) NOT NULL,
  `term1_id` int(11) NOT NULL,
  `term2_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `term1_id` (`term1_id`,`term2_id`),
  KEY `relationship_type_id` (`relationship_type_id`),
  KEY `term2_id` (`term2_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2317 DEFAULT CHARSET=latin1;")>
Public Class term2term_metadata: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("relationship_type_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property relationship_type_id As Long
    <DatabaseField("term1_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property term1_id As Long
    <DatabaseField("term2_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property term2_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `term2term_metadata` (`relationship_type_id`, `term1_id`, `term2_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `term2term_metadata` (`relationship_type_id`, `term1_id`, `term2_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `term2term_metadata` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `term2term_metadata` SET `id`='{0}', `relationship_type_id`='{1}', `term1_id`='{2}', `term2_id`='{3}' WHERE `id` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `term2term_metadata` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `term2term_metadata` (`relationship_type_id`, `term1_id`, `term2_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, relationship_type_id, term1_id, term2_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{relationship_type_id}', '{term1_id}', '{term2_id}', '{3}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `term2term_metadata` (`relationship_type_id`, `term1_id`, `term2_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, relationship_type_id, term1_id, term2_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `term2term_metadata` SET `id`='{0}', `relationship_type_id`='{1}', `term1_id`='{2}', `term2_id`='{3}' WHERE `id` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, relationship_type_id, term1_id, term2_id, id)
    End Function
#End Region
End Class


End Namespace
