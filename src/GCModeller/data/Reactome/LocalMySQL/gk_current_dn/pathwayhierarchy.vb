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
''' DROP TABLE IF EXISTS `pathwayhierarchy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwayhierarchy` (
'''   `pathwayId` int(32) NOT NULL DEFAULT '0',
'''   `childPathwayId` int(32) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`pathwayId`,`childPathwayId`),
'''   CONSTRAINT `PathwayHierarchy_ibfk_1` FOREIGN KEY (`pathwayId`) REFERENCES `pathway` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwayhierarchy", Database:="gk_current_dn", SchemaSQL:="
CREATE TABLE `pathwayhierarchy` (
  `pathwayId` int(32) NOT NULL DEFAULT '0',
  `childPathwayId` int(32) NOT NULL DEFAULT '0',
  PRIMARY KEY (`pathwayId`,`childPathwayId`),
  CONSTRAINT `PathwayHierarchy_ibfk_1` FOREIGN KEY (`pathwayId`) REFERENCES `pathway` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class pathwayhierarchy: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pathwayId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property pathwayId As Long
    <DatabaseField("childPathwayId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property childPathwayId As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pathwayhierarchy` (`pathwayId`, `childPathwayId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pathwayhierarchy` (`pathwayId`, `childPathwayId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pathwayhierarchy` WHERE `pathwayId`='{0}' and `childPathwayId`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pathwayhierarchy` SET `pathwayId`='{0}', `childPathwayId`='{1}' WHERE `pathwayId`='{2}' and `childPathwayId`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pathwayhierarchy` WHERE `pathwayId`='{0}' and `childPathwayId`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pathwayId, childPathwayId)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pathwayhierarchy` (`pathwayId`, `childPathwayId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pathwayId, childPathwayId)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pathwayId}', '{childPathwayId}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwayhierarchy` (`pathwayId`, `childPathwayId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pathwayId, childPathwayId)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pathwayhierarchy` SET `pathwayId`='{0}', `childPathwayId`='{1}' WHERE `pathwayId`='{2}' and `childPathwayId`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pathwayId, childPathwayId, pathwayId, childPathwayId)
    End Function
#End Region
End Class


End Namespace
