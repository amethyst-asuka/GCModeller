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
''' DROP TABLE IF EXISTS `vertice`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `vertice` (
'''   `id` int(11) NOT NULL,
'''   `vertice_ref` varchar(60) NOT NULL,
'''   `compound_id` int(11) DEFAULT NULL,
'''   `ontology_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `UNIQUE_ONTOLOGY_REF` (`vertice_ref`,`ontology_id`),
'''   KEY `ontology_id` (`ontology_id`),
'''   CONSTRAINT `FK_VERTICE_TO_ONTOLOGY` FOREIGN KEY (`ontology_id`) REFERENCES `ontology` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2015-10-22 16:20:17
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("vertice", Database:="chebi", SchemaSQL:="
CREATE TABLE `vertice` (
  `id` int(11) NOT NULL,
  `vertice_ref` varchar(60) NOT NULL,
  `compound_id` int(11) DEFAULT NULL,
  `ontology_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UNIQUE_ONTOLOGY_REF` (`vertice_ref`,`ontology_id`),
  KEY `ontology_id` (`ontology_id`),
  CONSTRAINT `FK_VERTICE_TO_ONTOLOGY` FOREIGN KEY (`ontology_id`) REFERENCES `ontology` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class vertice: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("vertice_ref"), NotNull, DataType(MySqlDbType.VarChar, "60")> Public Property vertice_ref As String
    <DatabaseField("compound_id"), DataType(MySqlDbType.Int64, "11")> Public Property compound_id As Long
    <DatabaseField("ontology_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property ontology_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `vertice` (`id`, `vertice_ref`, `compound_id`, `ontology_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `vertice` (`id`, `vertice_ref`, `compound_id`, `ontology_id`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `vertice` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `vertice` SET `id`='{0}', `vertice_ref`='{1}', `compound_id`='{2}', `ontology_id`='{3}' WHERE `id` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `vertice` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `vertice` (`id`, `vertice_ref`, `compound_id`, `ontology_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, vertice_ref, compound_id, ontology_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{vertice_ref}', '{compound_id}', '{ontology_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `vertice` (`id`, `vertice_ref`, `compound_id`, `ontology_id`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, vertice_ref, compound_id, ontology_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `vertice` SET `id`='{0}', `vertice_ref`='{1}', `compound_id`='{2}', `ontology_id`='{3}' WHERE `id` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, vertice_ref, compound_id, ontology_id, id)
    End Function
#End Region
End Class


End Namespace
