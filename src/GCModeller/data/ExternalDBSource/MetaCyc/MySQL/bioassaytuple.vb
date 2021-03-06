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
''' DROP TABLE IF EXISTS `bioassaytuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaytuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioAssay` bigint(20) DEFAULT NULL,
'''   `BioDataTuples_BioAssayTuples` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_BioAssayTuple1` (`DataSetWID`),
'''   KEY `FK_BioAssayTuple2` (`BioAssay`),
'''   KEY `FK_BioAssayTuple3` (`BioDataTuples_BioAssayTuples`),
'''   CONSTRAINT `FK_BioAssayTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayTuple2` FOREIGN KEY (`BioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayTuple3` FOREIGN KEY (`BioDataTuples_BioAssayTuples`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaytuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaytuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioAssay` bigint(20) DEFAULT NULL,
  `BioDataTuples_BioAssayTuples` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_BioAssayTuple1` (`DataSetWID`),
  KEY `FK_BioAssayTuple2` (`BioAssay`),
  KEY `FK_BioAssayTuple3` (`BioDataTuples_BioAssayTuples`),
  CONSTRAINT `FK_BioAssayTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayTuple2` FOREIGN KEY (`BioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayTuple3` FOREIGN KEY (`BioDataTuples_BioAssayTuples`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaytuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("BioAssay"), DataType(MySqlDbType.Int64, "20")> Public Property BioAssay As Long
    <DatabaseField("BioDataTuples_BioAssayTuples"), DataType(MySqlDbType.Int64, "20")> Public Property BioDataTuples_BioAssayTuples As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `bioassaytuple` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `bioassaytuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssay`='{2}', `BioDataTuples_BioAssayTuples`='{3}' WHERE `WID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `bioassaytuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{BioAssay}', '{BioDataTuples_BioAssayTuples}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `bioassaytuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssay`='{2}', `BioDataTuples_BioAssayTuples`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples, WID)
    End Function
#End Region
End Class


End Namespace
