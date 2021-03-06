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
''' DROP TABLE IF EXISTS `derivbioawidderivbioadatawid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `derivbioawidderivbioadatawid` (
'''   `DerivedBioAssayWID` bigint(20) NOT NULL,
'''   `DerivedBioAssayDataWID` bigint(20) NOT NULL,
'''   KEY `FK_DerivBioAWIDDerivBioAData1` (`DerivedBioAssayWID`),
'''   KEY `FK_DerivBioAWIDDerivBioAData2` (`DerivedBioAssayDataWID`),
'''   CONSTRAINT `FK_DerivBioAWIDDerivBioAData1` FOREIGN KEY (`DerivedBioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DerivBioAWIDDerivBioAData2` FOREIGN KEY (`DerivedBioAssayDataWID`) REFERENCES `bioassaydata` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("derivbioawidderivbioadatawid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `derivbioawidderivbioadatawid` (
  `DerivedBioAssayWID` bigint(20) NOT NULL,
  `DerivedBioAssayDataWID` bigint(20) NOT NULL,
  KEY `FK_DerivBioAWIDDerivBioAData1` (`DerivedBioAssayWID`),
  KEY `FK_DerivBioAWIDDerivBioAData2` (`DerivedBioAssayDataWID`),
  CONSTRAINT `FK_DerivBioAWIDDerivBioAData1` FOREIGN KEY (`DerivedBioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DerivBioAWIDDerivBioAData2` FOREIGN KEY (`DerivedBioAssayDataWID`) REFERENCES `bioassaydata` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class derivbioawidderivbioadatawid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DerivedBioAssayWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DerivedBioAssayWID As Long
    <DatabaseField("DerivedBioAssayDataWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DerivedBioAssayDataWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `derivbioawidderivbioadatawid` (`DerivedBioAssayWID`, `DerivedBioAssayDataWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `derivbioawidderivbioadatawid` (`DerivedBioAssayWID`, `DerivedBioAssayDataWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `derivbioawidderivbioadatawid` WHERE `DerivedBioAssayWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `derivbioawidderivbioadatawid` SET `DerivedBioAssayWID`='{0}', `DerivedBioAssayDataWID`='{1}' WHERE `DerivedBioAssayWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `derivbioawidderivbioadatawid` WHERE `DerivedBioAssayWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DerivedBioAssayWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `derivbioawidderivbioadatawid` (`DerivedBioAssayWID`, `DerivedBioAssayDataWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DerivedBioAssayWID, DerivedBioAssayDataWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DerivedBioAssayWID}', '{DerivedBioAssayDataWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `derivbioawidderivbioadatawid` (`DerivedBioAssayWID`, `DerivedBioAssayDataWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DerivedBioAssayWID, DerivedBioAssayDataWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `derivbioawidderivbioadatawid` SET `DerivedBioAssayWID`='{0}', `DerivedBioAssayDataWID`='{1}' WHERE `DerivedBioAssayWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DerivedBioAssayWID, DerivedBioAssayDataWID, DerivedBioAssayWID)
    End Function
#End Region
End Class


End Namespace
