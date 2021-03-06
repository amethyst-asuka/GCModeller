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
''' DROP TABLE IF EXISTS `relation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `relation` (
'''   `id` int(11) NOT NULL,
'''   `type` text NOT NULL,
'''   `init_id` int(11) NOT NULL,
'''   `final_id` int(11) NOT NULL,
'''   `status` varchar(1) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `final_id` (`final_id`),
'''   KEY `init_id` (`init_id`),
'''   CONSTRAINT `FK_RELATION_TO_FINAL_VERTICE` FOREIGN KEY (`final_id`) REFERENCES `vertice` (`id`),
'''   CONSTRAINT `FK_RELATION_TO_INIT_VERTICE` FOREIGN KEY (`init_id`) REFERENCES `vertice` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("relation", Database:="chebi", SchemaSQL:="
CREATE TABLE `relation` (
  `id` int(11) NOT NULL,
  `type` text NOT NULL,
  `init_id` int(11) NOT NULL,
  `final_id` int(11) NOT NULL,
  `status` varchar(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `final_id` (`final_id`),
  KEY `init_id` (`init_id`),
  CONSTRAINT `FK_RELATION_TO_FINAL_VERTICE` FOREIGN KEY (`final_id`) REFERENCES `vertice` (`id`),
  CONSTRAINT `FK_RELATION_TO_INIT_VERTICE` FOREIGN KEY (`init_id`) REFERENCES `vertice` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class relation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("type"), NotNull, DataType(MySqlDbType.Text)> Public Property type As String
    <DatabaseField("init_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property init_id As Long
    <DatabaseField("final_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property final_id As Long
    <DatabaseField("status"), NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property status As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `relation` (`id`, `type`, `init_id`, `final_id`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `relation` (`id`, `type`, `init_id`, `final_id`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `relation` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `relation` SET `id`='{0}', `type`='{1}', `init_id`='{2}', `final_id`='{3}', `status`='{4}' WHERE `id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `relation` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `relation` (`id`, `type`, `init_id`, `final_id`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, type, init_id, final_id, status)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{type}', '{init_id}', '{final_id}', '{status}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `relation` (`id`, `type`, `init_id`, `final_id`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, type, init_id, final_id, status)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `relation` SET `id`='{0}', `type`='{1}', `init_id`='{2}', `final_id`='{3}', `status`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, type, init_id, final_id, status, id)
    End Function
#End Region
End Class


End Namespace
