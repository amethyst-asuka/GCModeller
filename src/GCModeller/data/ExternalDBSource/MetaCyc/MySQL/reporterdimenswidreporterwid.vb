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
''' DROP TABLE IF EXISTS `reporterdimenswidreporterwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reporterdimenswidreporterwid` (
'''   `ReporterDimensionWID` bigint(20) NOT NULL,
'''   `ReporterWID` bigint(20) NOT NULL,
'''   KEY `FK_ReporterDimensWIDReporter1` (`ReporterDimensionWID`),
'''   KEY `FK_ReporterDimensWIDReporter2` (`ReporterWID`),
'''   CONSTRAINT `FK_ReporterDimensWIDReporter1` FOREIGN KEY (`ReporterDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ReporterDimensWIDReporter2` FOREIGN KEY (`ReporterWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reporterdimenswidreporterwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `reporterdimenswidreporterwid` (
  `ReporterDimensionWID` bigint(20) NOT NULL,
  `ReporterWID` bigint(20) NOT NULL,
  KEY `FK_ReporterDimensWIDReporter1` (`ReporterDimensionWID`),
  KEY `FK_ReporterDimensWIDReporter2` (`ReporterWID`),
  CONSTRAINT `FK_ReporterDimensWIDReporter1` FOREIGN KEY (`ReporterDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ReporterDimensWIDReporter2` FOREIGN KEY (`ReporterWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class reporterdimenswidreporterwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ReporterDimensionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReporterDimensionWID As Long
    <DatabaseField("ReporterWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReporterWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reporterdimenswidreporterwid` (`ReporterDimensionWID`, `ReporterWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reporterdimenswidreporterwid` (`ReporterDimensionWID`, `ReporterWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reporterdimenswidreporterwid` WHERE `ReporterDimensionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reporterdimenswidreporterwid` SET `ReporterDimensionWID`='{0}', `ReporterWID`='{1}' WHERE `ReporterDimensionWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reporterdimenswidreporterwid` WHERE `ReporterDimensionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ReporterDimensionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reporterdimenswidreporterwid` (`ReporterDimensionWID`, `ReporterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ReporterDimensionWID, ReporterWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ReporterDimensionWID}', '{ReporterWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reporterdimenswidreporterwid` (`ReporterDimensionWID`, `ReporterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ReporterDimensionWID, ReporterWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reporterdimenswidreporterwid` SET `ReporterDimensionWID`='{0}', `ReporterWID`='{1}' WHERE `ReporterDimensionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ReporterDimensionWID, ReporterWID, ReporterDimensionWID)
    End Function
#End Region
End Class


End Namespace
