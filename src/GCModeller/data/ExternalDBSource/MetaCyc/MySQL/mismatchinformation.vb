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
''' DROP TABLE IF EXISTS `mismatchinformation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mismatchinformation` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `CompositePosition` bigint(20) DEFAULT NULL,
'''   `FeatureInformation` bigint(20) DEFAULT NULL,
'''   `StartCoord` smallint(6) DEFAULT NULL,
'''   `NewSequence` varchar(255) DEFAULT NULL,
'''   `ReplacedLength` smallint(6) DEFAULT NULL,
'''   `ReporterPosition` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_MismatchInformation1` (`DataSetWID`),
'''   KEY `FK_MismatchInformation2` (`CompositePosition`),
'''   KEY `FK_MismatchInformation3` (`FeatureInformation`),
'''   KEY `FK_MismatchInformation4` (`ReporterPosition`),
'''   CONSTRAINT `FK_MismatchInformation1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation2` FOREIGN KEY (`CompositePosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation3` FOREIGN KEY (`FeatureInformation`) REFERENCES `featureinformation` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation4` FOREIGN KEY (`ReporterPosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mismatchinformation", Database:="warehouse", SchemaSQL:="
CREATE TABLE `mismatchinformation` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `CompositePosition` bigint(20) DEFAULT NULL,
  `FeatureInformation` bigint(20) DEFAULT NULL,
  `StartCoord` smallint(6) DEFAULT NULL,
  `NewSequence` varchar(255) DEFAULT NULL,
  `ReplacedLength` smallint(6) DEFAULT NULL,
  `ReporterPosition` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_MismatchInformation1` (`DataSetWID`),
  KEY `FK_MismatchInformation2` (`CompositePosition`),
  KEY `FK_MismatchInformation3` (`FeatureInformation`),
  KEY `FK_MismatchInformation4` (`ReporterPosition`),
  CONSTRAINT `FK_MismatchInformation1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation2` FOREIGN KEY (`CompositePosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation3` FOREIGN KEY (`FeatureInformation`) REFERENCES `featureinformation` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation4` FOREIGN KEY (`ReporterPosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class mismatchinformation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("CompositePosition"), DataType(MySqlDbType.Int64, "20")> Public Property CompositePosition As Long
    <DatabaseField("FeatureInformation"), DataType(MySqlDbType.Int64, "20")> Public Property FeatureInformation As Long
    <DatabaseField("StartCoord"), DataType(MySqlDbType.Int64, "6")> Public Property StartCoord As Long
    <DatabaseField("NewSequence"), DataType(MySqlDbType.VarChar, "255")> Public Property NewSequence As String
    <DatabaseField("ReplacedLength"), DataType(MySqlDbType.Int64, "6")> Public Property ReplacedLength As Long
    <DatabaseField("ReporterPosition"), DataType(MySqlDbType.Int64, "20")> Public Property ReporterPosition As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `mismatchinformation` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `mismatchinformation` SET `WID`='{0}', `DataSetWID`='{1}', `CompositePosition`='{2}', `FeatureInformation`='{3}', `StartCoord`='{4}', `NewSequence`='{5}', `ReplacedLength`='{6}', `ReporterPosition`='{7}' WHERE `WID` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `mismatchinformation` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{CompositePosition}', '{FeatureInformation}', '{StartCoord}', '{NewSequence}', '{ReplacedLength}', '{ReporterPosition}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `mismatchinformation` SET `WID`='{0}', `DataSetWID`='{1}', `CompositePosition`='{2}', `FeatureInformation`='{3}', `StartCoord`='{4}', `NewSequence`='{5}', `ReplacedLength`='{6}', `ReporterPosition`='{7}' WHERE `WID` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition, WID)
    End Function
#End Region
End Class


End Namespace
