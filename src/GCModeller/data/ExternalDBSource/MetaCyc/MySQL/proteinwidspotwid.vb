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
''' DROP TABLE IF EXISTS `proteinwidspotwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `proteinwidspotwid` (
'''   `ProteinWID` bigint(20) NOT NULL,
'''   `SpotWID` bigint(20) NOT NULL,
'''   KEY `FK_ProteinWIDSpotWID1` (`ProteinWID`),
'''   KEY `FK_ProteinWIDSpotWID2` (`SpotWID`),
'''   CONSTRAINT `FK_ProteinWIDSpotWID1` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProteinWIDSpotWID2` FOREIGN KEY (`SpotWID`) REFERENCES `spot` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("proteinwidspotwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `proteinwidspotwid` (
  `ProteinWID` bigint(20) NOT NULL,
  `SpotWID` bigint(20) NOT NULL,
  KEY `FK_ProteinWIDSpotWID1` (`ProteinWID`),
  KEY `FK_ProteinWIDSpotWID2` (`SpotWID`),
  CONSTRAINT `FK_ProteinWIDSpotWID1` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProteinWIDSpotWID2` FOREIGN KEY (`SpotWID`) REFERENCES `spot` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class proteinwidspotwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProteinWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProteinWID As Long
    <DatabaseField("SpotWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SpotWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `proteinwidspotwid` (`ProteinWID`, `SpotWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `proteinwidspotwid` (`ProteinWID`, `SpotWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `proteinwidspotwid` WHERE `ProteinWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `proteinwidspotwid` SET `ProteinWID`='{0}', `SpotWID`='{1}' WHERE `ProteinWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `proteinwidspotwid` WHERE `ProteinWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProteinWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `proteinwidspotwid` (`ProteinWID`, `SpotWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProteinWID, SpotWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ProteinWID}', '{SpotWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `proteinwidspotwid` (`ProteinWID`, `SpotWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProteinWID, SpotWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `proteinwidspotwid` SET `ProteinWID`='{0}', `SpotWID`='{1}' WHERE `ProteinWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProteinWID, SpotWID, ProteinWID)
    End Function
#End Region
End Class


End Namespace
