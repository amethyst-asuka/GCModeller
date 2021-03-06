REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:30 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current_dn

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `id_to_externalidentifier`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `id_to_externalidentifier` (
'''   `id` int(32) NOT NULL DEFAULT '0',
'''   `referenceDatabase` varchar(255) NOT NULL DEFAULT '',
'''   `externalIdentifier` varchar(32) NOT NULL DEFAULT '',
'''   `description` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`id`,`referenceDatabase`,`externalIdentifier`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("id_to_externalidentifier", Database:="gk_current_dn", SchemaSQL:="
CREATE TABLE `id_to_externalidentifier` (
  `id` int(32) NOT NULL DEFAULT '0',
  `referenceDatabase` varchar(255) NOT NULL DEFAULT '',
  `externalIdentifier` varchar(32) NOT NULL DEFAULT '',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`,`referenceDatabase`,`externalIdentifier`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class id_to_externalidentifier: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property id As Long
    <DatabaseField("referenceDatabase"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property referenceDatabase As String
    <DatabaseField("externalIdentifier"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "32")> Public Property externalIdentifier As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "255")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `id_to_externalidentifier` (`id`, `referenceDatabase`, `externalIdentifier`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `id_to_externalidentifier` (`id`, `referenceDatabase`, `externalIdentifier`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `id_to_externalidentifier` WHERE `id`='{0}' and `referenceDatabase`='{1}' and `externalIdentifier`='{2}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `id_to_externalidentifier` SET `id`='{0}', `referenceDatabase`='{1}', `externalIdentifier`='{2}', `description`='{3}' WHERE `id`='{4}' and `referenceDatabase`='{5}' and `externalIdentifier`='{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `id_to_externalidentifier` WHERE `id`='{0}' and `referenceDatabase`='{1}' and `externalIdentifier`='{2}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id, referenceDatabase, externalIdentifier)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `id_to_externalidentifier` (`id`, `referenceDatabase`, `externalIdentifier`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, referenceDatabase, externalIdentifier, description)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{referenceDatabase}', '{externalIdentifier}', '{description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `id_to_externalidentifier` (`id`, `referenceDatabase`, `externalIdentifier`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, referenceDatabase, externalIdentifier, description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `id_to_externalidentifier` SET `id`='{0}', `referenceDatabase`='{1}', `externalIdentifier`='{2}', `description`='{3}' WHERE `id`='{4}' and `referenceDatabase`='{5}' and `externalIdentifier`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, referenceDatabase, externalIdentifier, description, id, referenceDatabase, externalIdentifier)
    End Function
#End Region
End Class


End Namespace
