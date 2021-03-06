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
''' DROP TABLE IF EXISTS `enzymaticreaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `enzymaticreaction` (
'''   `WID` bigint(20) NOT NULL,
'''   `ReactionWID` bigint(20) NOT NULL,
'''   `ProteinWID` bigint(20) NOT NULL,
'''   `ComplexWID` bigint(20) DEFAULT NULL,
'''   `ReactionDirection` varchar(30) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `ER_DATASETWID` (`DataSetWID`),
'''   KEY `FK_EnzymaticReaction1` (`ReactionWID`),
'''   KEY `FK_EnzymaticReaction2` (`ProteinWID`),
'''   KEY `FK_EnzymaticReaction3` (`ComplexWID`),
'''   CONSTRAINT `FK_EnzymaticReaction1` FOREIGN KEY (`ReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_EnzymaticReaction2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_EnzymaticReaction3` FOREIGN KEY (`ComplexWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_EnzymaticReaction4` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("enzymaticreaction", Database:="warehouse", SchemaSQL:="
CREATE TABLE `enzymaticreaction` (
  `WID` bigint(20) NOT NULL,
  `ReactionWID` bigint(20) NOT NULL,
  `ProteinWID` bigint(20) NOT NULL,
  `ComplexWID` bigint(20) DEFAULT NULL,
  `ReactionDirection` varchar(30) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `ER_DATASETWID` (`DataSetWID`),
  KEY `FK_EnzymaticReaction1` (`ReactionWID`),
  KEY `FK_EnzymaticReaction2` (`ProteinWID`),
  KEY `FK_EnzymaticReaction3` (`ComplexWID`),
  CONSTRAINT `FK_EnzymaticReaction1` FOREIGN KEY (`ReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_EnzymaticReaction2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_EnzymaticReaction3` FOREIGN KEY (`ComplexWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_EnzymaticReaction4` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class enzymaticreaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("ReactionWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReactionWID As Long
    <DatabaseField("ProteinWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProteinWID As Long
    <DatabaseField("ComplexWID"), DataType(MySqlDbType.Int64, "20")> Public Property ComplexWID As Long
    <DatabaseField("ReactionDirection"), DataType(MySqlDbType.VarChar, "30")> Public Property ReactionDirection As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `enzymaticreaction` (`WID`, `ReactionWID`, `ProteinWID`, `ComplexWID`, `ReactionDirection`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `enzymaticreaction` (`WID`, `ReactionWID`, `ProteinWID`, `ComplexWID`, `ReactionDirection`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `enzymaticreaction` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `enzymaticreaction` SET `WID`='{0}', `ReactionWID`='{1}', `ProteinWID`='{2}', `ComplexWID`='{3}', `ReactionDirection`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `enzymaticreaction` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `enzymaticreaction` (`WID`, `ReactionWID`, `ProteinWID`, `ComplexWID`, `ReactionDirection`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, ReactionWID, ProteinWID, ComplexWID, ReactionDirection, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{ReactionWID}', '{ProteinWID}', '{ComplexWID}', '{ReactionDirection}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `enzymaticreaction` (`WID`, `ReactionWID`, `ProteinWID`, `ComplexWID`, `ReactionDirection`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, ReactionWID, ProteinWID, ComplexWID, ReactionDirection, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `enzymaticreaction` SET `WID`='{0}', `ReactionWID`='{1}', `ProteinWID`='{2}', `ComplexWID`='{3}', `ReactionDirection`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, ReactionWID, ProteinWID, ComplexWID, ReactionDirection, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
