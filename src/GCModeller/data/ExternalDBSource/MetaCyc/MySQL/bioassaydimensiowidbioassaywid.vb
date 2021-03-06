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
''' DROP TABLE IF EXISTS `bioassaydimensiowidbioassaywid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaydimensiowidbioassaywid` (
'''   `BioAssayDimensionWID` bigint(20) NOT NULL,
'''   `BioAssayWID` bigint(20) NOT NULL,
'''   KEY `FK_BioAssayDimensioWIDBioAss1` (`BioAssayDimensionWID`),
'''   KEY `FK_BioAssayDimensioWIDBioAss2` (`BioAssayWID`),
'''   CONSTRAINT `FK_BioAssayDimensioWIDBioAss1` FOREIGN KEY (`BioAssayDimensionWID`) REFERENCES `bioassaydimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayDimensioWIDBioAss2` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaydimensiowidbioassaywid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaydimensiowidbioassaywid` (
  `BioAssayDimensionWID` bigint(20) NOT NULL,
  `BioAssayWID` bigint(20) NOT NULL,
  KEY `FK_BioAssayDimensioWIDBioAss1` (`BioAssayDimensionWID`),
  KEY `FK_BioAssayDimensioWIDBioAss2` (`BioAssayWID`),
  CONSTRAINT `FK_BioAssayDimensioWIDBioAss1` FOREIGN KEY (`BioAssayDimensionWID`) REFERENCES `bioassaydimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayDimensioWIDBioAss2` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaydimensiowidbioassaywid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioAssayDimensionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayDimensionWID As Long
    <DatabaseField("BioAssayWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `bioassaydimensiowidbioassaywid` (`BioAssayDimensionWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `bioassaydimensiowidbioassaywid` (`BioAssayDimensionWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `bioassaydimensiowidbioassaywid` WHERE `BioAssayDimensionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `bioassaydimensiowidbioassaywid` SET `BioAssayDimensionWID`='{0}', `BioAssayWID`='{1}' WHERE `BioAssayDimensionWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `bioassaydimensiowidbioassaywid` WHERE `BioAssayDimensionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayDimensionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `bioassaydimensiowidbioassaywid` (`BioAssayDimensionWID`, `BioAssayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioAssayDimensionWID, BioAssayWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{BioAssayDimensionWID}', '{BioAssayWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaydimensiowidbioassaywid` (`BioAssayDimensionWID`, `BioAssayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioAssayDimensionWID, BioAssayWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `bioassaydimensiowidbioassaywid` SET `BioAssayDimensionWID`='{0}', `BioAssayWID`='{1}' WHERE `BioAssayDimensionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioAssayDimensionWID, BioAssayWID, BioAssayDimensionWID)
    End Function
#End Region
End Class


End Namespace
