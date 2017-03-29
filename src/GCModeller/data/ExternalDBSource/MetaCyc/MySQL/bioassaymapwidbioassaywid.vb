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
''' DROP TABLE IF EXISTS `bioassaymapwidbioassaywid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaymapwidbioassaywid` (
'''   `BioAssayMapWID` bigint(20) NOT NULL,
'''   `BioAssayWID` bigint(20) NOT NULL,
'''   KEY `FK_BioAssayMapWIDBioAssayWID1` (`BioAssayMapWID`),
'''   KEY `FK_BioAssayMapWIDBioAssayWID2` (`BioAssayWID`),
'''   CONSTRAINT `FK_BioAssayMapWIDBioAssayWID1` FOREIGN KEY (`BioAssayMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayMapWIDBioAssayWID2` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaymapwidbioassaywid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaymapwidbioassaywid` (
  `BioAssayMapWID` bigint(20) NOT NULL,
  `BioAssayWID` bigint(20) NOT NULL,
  KEY `FK_BioAssayMapWIDBioAssayWID1` (`BioAssayMapWID`),
  KEY `FK_BioAssayMapWIDBioAssayWID2` (`BioAssayWID`),
  CONSTRAINT `FK_BioAssayMapWIDBioAssayWID1` FOREIGN KEY (`BioAssayMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayMapWIDBioAssayWID2` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaymapwidbioassaywid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioAssayMapWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayMapWID As Long
    <DatabaseField("BioAssayWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `bioassaymapwidbioassaywid` (`BioAssayMapWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `bioassaymapwidbioassaywid` (`BioAssayMapWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `bioassaymapwidbioassaywid` WHERE `BioAssayMapWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `bioassaymapwidbioassaywid` SET `BioAssayMapWID`='{0}', `BioAssayWID`='{1}' WHERE `BioAssayMapWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `bioassaymapwidbioassaywid` WHERE `BioAssayMapWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayMapWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `bioassaymapwidbioassaywid` (`BioAssayMapWID`, `BioAssayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioAssayMapWID, BioAssayWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{BioAssayMapWID}', '{BioAssayWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaymapwidbioassaywid` (`BioAssayMapWID`, `BioAssayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioAssayMapWID, BioAssayWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `bioassaymapwidbioassaywid` SET `BioAssayMapWID`='{0}', `BioAssayWID`='{1}' WHERE `BioAssayMapWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioAssayMapWID, BioAssayWID, BioAssayMapWID)
    End Function
#End Region
End Class


End Namespace
