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
''' DROP TABLE IF EXISTS `comments`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `comments` (
'''   `id` int(11) NOT NULL,
'''   `compound_id` int(11) NOT NULL,
'''   `text` text NOT NULL,
'''   `created_on` datetime NOT NULL,
'''   `datatype` varchar(80) DEFAULT NULL,
'''   `datatype_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `compound_id` (`compound_id`),
'''   CONSTRAINT `FK_COMMENTS_TO_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("comments", Database:="chebi", SchemaSQL:="
CREATE TABLE `comments` (
  `id` int(11) NOT NULL,
  `compound_id` int(11) NOT NULL,
  `text` text NOT NULL,
  `created_on` datetime NOT NULL,
  `datatype` varchar(80) DEFAULT NULL,
  `datatype_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `compound_id` (`compound_id`),
  CONSTRAINT `FK_COMMENTS_TO_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class comments: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("compound_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property compound_id As Long
    <DatabaseField("text"), NotNull, DataType(MySqlDbType.Text)> Public Property text As String
    <DatabaseField("created_on"), NotNull, DataType(MySqlDbType.DateTime)> Public Property created_on As Date
    <DatabaseField("datatype"), DataType(MySqlDbType.VarChar, "80")> Public Property datatype As String
    <DatabaseField("datatype_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property datatype_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `comments` (`id`, `compound_id`, `text`, `created_on`, `datatype`, `datatype_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `comments` (`id`, `compound_id`, `text`, `created_on`, `datatype`, `datatype_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `comments` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `comments` SET `id`='{0}', `compound_id`='{1}', `text`='{2}', `created_on`='{3}', `datatype`='{4}', `datatype_id`='{5}' WHERE `id` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `comments` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `comments` (`id`, `compound_id`, `text`, `created_on`, `datatype`, `datatype_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, compound_id, text, Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.DataType.ToMySqlDateTimeString(created_on), datatype, datatype_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{compound_id}', '{text}', '{created_on}', '{datatype}', '{datatype_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `comments` (`id`, `compound_id`, `text`, `created_on`, `datatype`, `datatype_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, compound_id, text, Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.DataType.ToMySqlDateTimeString(created_on), datatype, datatype_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `comments` SET `id`='{0}', `compound_id`='{1}', `text`='{2}', `created_on`='{3}', `datatype`='{4}', `datatype_id`='{5}' WHERE `id` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, compound_id, text, Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.DataType.ToMySqlDateTimeString(created_on), datatype, datatype_id, id)
    End Function
#End Region
End Class


End Namespace
