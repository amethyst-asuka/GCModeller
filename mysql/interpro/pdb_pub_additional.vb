REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:52 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `pdb_pub_additional`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pdb_pub_additional` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   KEY `fk_pdbpubadd$entry_ac` (`entry_ac`),
'''   KEY `fk_pdbpubadd$pub_id` (`pub_id`),
'''   CONSTRAINT `fk_pdbpubadd$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_pdbpubadd$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pdb_pub_additional", Database:="interpro", SchemaSQL:="
CREATE TABLE `pdb_pub_additional` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  KEY `fk_pdbpubadd$entry_ac` (`entry_ac`),
  KEY `fk_pdbpubadd$pub_id` (`pub_id`),
  CONSTRAINT `fk_pdbpubadd$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_pdbpubadd$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class pdb_pub_additional: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9")> Public Property entry_ac As String
    <DatabaseField("pub_id"), NotNull, DataType(MySqlDbType.VarChar, "11")> Public Property pub_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pdb_pub_additional` WHERE `entry_ac` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pdb_pub_additional` SET `entry_ac`='{0}', `pub_id`='{1}' WHERE `entry_ac` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pdb_pub_additional` WHERE `entry_ac` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, pub_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{pub_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, pub_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pdb_pub_additional` SET `entry_ac`='{0}', `pub_id`='{1}' WHERE `entry_ac` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, pub_id, entry_ac)
    End Function
#End Region
End Class


End Namespace
