REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `experimentrelationship`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experimentrelationship` (
'''   `ExperimentWID` bigint(20) NOT NULL,
'''   `RelatedExperimentWID` bigint(20) NOT NULL,
'''   KEY `FK_ExpRelationship1` (`ExperimentWID`),
'''   KEY `FK_ExpRelationship2` (`RelatedExperimentWID`),
'''   CONSTRAINT `FK_ExpRelationship1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExpRelationship2` FOREIGN KEY (`RelatedExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experimentrelationship", Database:="warehouse", SchemaSQL:="
CREATE TABLE `experimentrelationship` (
  `ExperimentWID` bigint(20) NOT NULL,
  `RelatedExperimentWID` bigint(20) NOT NULL,
  KEY `FK_ExpRelationship1` (`ExperimentWID`),
  KEY `FK_ExpRelationship2` (`RelatedExperimentWID`),
  CONSTRAINT `FK_ExpRelationship1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ExpRelationship2` FOREIGN KEY (`RelatedExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class experimentrelationship: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ExperimentWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ExperimentWID As Long
    <DatabaseField("RelatedExperimentWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property RelatedExperimentWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `experimentrelationship` WHERE `ExperimentWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `experimentrelationship` SET `ExperimentWID`='{0}', `RelatedExperimentWID`='{1}' WHERE `ExperimentWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `experimentrelationship` WHERE `ExperimentWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ExperimentWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ExperimentWID, RelatedExperimentWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ExperimentWID}', '{RelatedExperimentWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ExperimentWID, RelatedExperimentWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `experimentrelationship` SET `ExperimentWID`='{0}', `RelatedExperimentWID`='{1}' WHERE `ExperimentWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ExperimentWID, RelatedExperimentWID, ExperimentWID)
    End Function
#End Region
End Class


End Namespace
