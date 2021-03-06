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
''' DROP TABLE IF EXISTS `physicalentity`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentity` (
'''   `id` int(32) NOT NULL,
'''   `displayName` varchar(255) NOT NULL,
'''   `species` varchar(255) DEFAULT NULL,
'''   `class` varchar(255) NOT NULL,
'''   `stableId` varchar(32) DEFAULT NULL,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `stableId` (`stableId`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentity", Database:="gk_current_dn", SchemaSQL:="
CREATE TABLE `physicalentity` (
  `id` int(32) NOT NULL,
  `displayName` varchar(255) NOT NULL,
  `species` varchar(255) DEFAULT NULL,
  `class` varchar(255) NOT NULL,
  `stableId` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `stableId` (`stableId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class physicalentity: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property id As Long
    <DatabaseField("displayName"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property displayName As String
    <DatabaseField("species"), DataType(MySqlDbType.VarChar, "255")> Public Property species As String
    <DatabaseField("class"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property [class] As String
    <DatabaseField("stableId"), DataType(MySqlDbType.VarChar, "32")> Public Property stableId As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `physicalentity` (`id`, `displayName`, `species`, `class`, `stableId`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `physicalentity` (`id`, `displayName`, `species`, `class`, `stableId`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `physicalentity` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `physicalentity` SET `id`='{0}', `displayName`='{1}', `species`='{2}', `class`='{3}', `stableId`='{4}' WHERE `id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `physicalentity` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity` (`id`, `displayName`, `species`, `class`, `stableId`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, displayName, species, [class], stableId)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{displayName}', '{species}', '{[class]}', '{stableId}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity` (`id`, `displayName`, `species`, `class`, `stableId`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, displayName, species, [class], stableId)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `physicalentity` SET `id`='{0}', `displayName`='{1}', `species`='{2}', `class`='{3}', `stableId`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, displayName, species, [class], stableId, id)
    End Function
#End Region
End Class


End Namespace
