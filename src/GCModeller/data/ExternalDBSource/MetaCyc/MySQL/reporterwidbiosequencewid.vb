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
''' DROP TABLE IF EXISTS `reporterwidbiosequencewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reporterwidbiosequencewid` (
'''   `ReporterWID` bigint(20) NOT NULL,
'''   `BioSequenceWID` bigint(20) NOT NULL,
'''   KEY `FK_ReporterWIDBioSequenceWID1` (`ReporterWID`),
'''   CONSTRAINT `FK_ReporterWIDBioSequenceWID1` FOREIGN KEY (`ReporterWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reporterwidbiosequencewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `reporterwidbiosequencewid` (
  `ReporterWID` bigint(20) NOT NULL,
  `BioSequenceWID` bigint(20) NOT NULL,
  KEY `FK_ReporterWIDBioSequenceWID1` (`ReporterWID`),
  CONSTRAINT `FK_ReporterWIDBioSequenceWID1` FOREIGN KEY (`ReporterWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class reporterwidbiosequencewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ReporterWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReporterWID As Long
    <DatabaseField("BioSequenceWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioSequenceWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reporterwidbiosequencewid` (`ReporterWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reporterwidbiosequencewid` (`ReporterWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reporterwidbiosequencewid` WHERE `ReporterWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reporterwidbiosequencewid` SET `ReporterWID`='{0}', `BioSequenceWID`='{1}' WHERE `ReporterWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reporterwidbiosequencewid` WHERE `ReporterWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ReporterWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reporterwidbiosequencewid` (`ReporterWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ReporterWID, BioSequenceWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ReporterWID}', '{BioSequenceWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reporterwidbiosequencewid` (`ReporterWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ReporterWID, BioSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reporterwidbiosequencewid` SET `ReporterWID`='{0}', `BioSequenceWID`='{1}' WHERE `ReporterWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ReporterWID, BioSequenceWID, ReporterWID)
    End Function
#End Region
End Class


End Namespace
