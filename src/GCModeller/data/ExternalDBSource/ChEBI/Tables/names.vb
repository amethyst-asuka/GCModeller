REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:55 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace ChEBI.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `names`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `names` (
'''   `id` int(11) NOT NULL,
'''   `compound_id` int(11) NOT NULL,
'''   `name` text NOT NULL,
'''   `type` text NOT NULL,
'''   `source` text NOT NULL,
'''   `adapted` text NOT NULL,
'''   `language` text NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `compound_id` (`compound_id`),
'''   CONSTRAINT `FK_NAMES_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("names", Database:="chebi", SchemaSQL:="
CREATE TABLE `names` (
  `id` int(11) NOT NULL,
  `compound_id` int(11) NOT NULL,
  `name` text NOT NULL,
  `type` text NOT NULL,
  `source` text NOT NULL,
  `adapted` text NOT NULL,
  `language` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `compound_id` (`compound_id`),
  CONSTRAINT `FK_NAMES_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class names: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("compound_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property compound_id As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.Text)> Public Property name As String
    <DatabaseField("type"), NotNull, DataType(MySqlDbType.Text)> Public Property type As String
    <DatabaseField("source"), NotNull, DataType(MySqlDbType.Text)> Public Property source As String
    <DatabaseField("adapted"), NotNull, DataType(MySqlDbType.Text)> Public Property adapted As String
    <DatabaseField("language"), NotNull, DataType(MySqlDbType.Text)> Public Property language As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `names` (`id`, `compound_id`, `name`, `type`, `source`, `adapted`, `language`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `names` (`id`, `compound_id`, `name`, `type`, `source`, `adapted`, `language`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `names` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `names` SET `id`='{0}', `compound_id`='{1}', `name`='{2}', `type`='{3}', `source`='{4}', `adapted`='{5}', `language`='{6}' WHERE `id` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `names` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `names` (`id`, `compound_id`, `name`, `type`, `source`, `adapted`, `language`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, compound_id, name, type, source, adapted, language)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{compound_id}', '{name}', '{type}', '{source}', '{adapted}', '{language}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `names` (`id`, `compound_id`, `name`, `type`, `source`, `adapted`, `language`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, compound_id, name, type, source, adapted, language)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `names` SET `id`='{0}', `compound_id`='{1}', `name`='{2}', `type`='{3}', `source`='{4}', `adapted`='{5}', `language`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, compound_id, name, type, source, adapted, language, id)
    End Function
#End Region
End Class


End Namespace
