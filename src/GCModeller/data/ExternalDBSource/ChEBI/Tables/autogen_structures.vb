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
''' DROP TABLE IF EXISTS `autogen_structures`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `autogen_structures` (
'''   `id` int(11) NOT NULL,
'''   `structure_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `FK_STRUCTURES_TO_AUTOGEN_STRUC` (`structure_id`),
'''   CONSTRAINT `FK_STRUCTURES_TO_AUTOGEN_STRUC` FOREIGN KEY (`structure_id`) REFERENCES `structures` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("autogen_structures", Database:="chebi", SchemaSQL:="
CREATE TABLE `autogen_structures` (
  `id` int(11) NOT NULL,
  `structure_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_STRUCTURES_TO_AUTOGEN_STRUC` (`structure_id`),
  CONSTRAINT `FK_STRUCTURES_TO_AUTOGEN_STRUC` FOREIGN KEY (`structure_id`) REFERENCES `structures` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class autogen_structures: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("structure_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property structure_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `autogen_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `autogen_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `autogen_structures` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `autogen_structures` SET `id`='{0}', `structure_id`='{1}' WHERE `id` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `autogen_structures` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `autogen_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, structure_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{structure_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `autogen_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, structure_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `autogen_structures` SET `id`='{0}', `structure_id`='{1}' WHERE `id` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, structure_id, id)
    End Function
#End Region
End Class


End Namespace
