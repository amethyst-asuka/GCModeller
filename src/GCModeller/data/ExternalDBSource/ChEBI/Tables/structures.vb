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
''' DROP TABLE IF EXISTS `structures`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `structures` (
'''   `id` int(11) NOT NULL,
'''   `compound_id` int(11) NOT NULL,
'''   `structure` text NOT NULL,
'''   `type` text NOT NULL,
'''   `dimension` text NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `FK_STRUCTURES_TO_COMPOUND` (`compound_id`),
'''   CONSTRAINT `FK_STRUCTURES_TO_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("structures", Database:="chebi", SchemaSQL:="
CREATE TABLE `structures` (
  `id` int(11) NOT NULL,
  `compound_id` int(11) NOT NULL,
  `structure` text NOT NULL,
  `type` text NOT NULL,
  `dimension` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_STRUCTURES_TO_COMPOUND` (`compound_id`),
  CONSTRAINT `FK_STRUCTURES_TO_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class structures: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("compound_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property compound_id As Long
    <DatabaseField("structure"), NotNull, DataType(MySqlDbType.Text)> Public Property [structure] As String
    <DatabaseField("type"), NotNull, DataType(MySqlDbType.Text)> Public Property type As String
    <DatabaseField("dimension"), NotNull, DataType(MySqlDbType.Text)> Public Property dimension As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `structures` (`id`, `compound_id`, `structure`, `type`, `dimension`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `structures` (`id`, `compound_id`, `structure`, `type`, `dimension`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `structures` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `structures` SET `id`='{0}', `compound_id`='{1}', `structure`='{2}', `type`='{3}', `dimension`='{4}' WHERE `id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `structures` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `structures` (`id`, `compound_id`, `structure`, `type`, `dimension`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, compound_id, [structure], type, dimension)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{compound_id}', '{[structure]}', '{type}', '{dimension}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `structures` (`id`, `compound_id`, `structure`, `type`, `dimension`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, compound_id, [structure], type, dimension)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `structures` SET `id`='{0}', `compound_id`='{1}', `structure`='{2}', `type`='{3}', `dimension`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, compound_id, [structure], type, dimension, id)
    End Function
#End Region
End Class


End Namespace
