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
''' DROP TABLE IF EXISTS `pathwaylink`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwaylink` (
'''   `Pathway1WID` bigint(20) NOT NULL,
'''   `Pathway2WID` bigint(20) NOT NULL,
'''   `ChemicalWID` bigint(20) NOT NULL,
'''   KEY `FK_PathwayLink1` (`Pathway1WID`),
'''   KEY `FK_PathwayLink2` (`Pathway2WID`),
'''   KEY `FK_PathwayLink3` (`ChemicalWID`),
'''   CONSTRAINT `FK_PathwayLink1` FOREIGN KEY (`Pathway1WID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_PathwayLink2` FOREIGN KEY (`Pathway2WID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_PathwayLink3` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwaylink", Database:="warehouse", SchemaSQL:="
CREATE TABLE `pathwaylink` (
  `Pathway1WID` bigint(20) NOT NULL,
  `Pathway2WID` bigint(20) NOT NULL,
  `ChemicalWID` bigint(20) NOT NULL,
  KEY `FK_PathwayLink1` (`Pathway1WID`),
  KEY `FK_PathwayLink2` (`Pathway2WID`),
  KEY `FK_PathwayLink3` (`ChemicalWID`),
  CONSTRAINT `FK_PathwayLink1` FOREIGN KEY (`Pathway1WID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_PathwayLink2` FOREIGN KEY (`Pathway2WID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_PathwayLink3` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class pathwaylink: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("Pathway1WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property Pathway1WID As Long
    <DatabaseField("Pathway2WID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property Pathway2WID As Long
    <DatabaseField("ChemicalWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ChemicalWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pathwaylink` (`Pathway1WID`, `Pathway2WID`, `ChemicalWID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pathwaylink` (`Pathway1WID`, `Pathway2WID`, `ChemicalWID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pathwaylink` WHERE `Pathway1WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pathwaylink` SET `Pathway1WID`='{0}', `Pathway2WID`='{1}', `ChemicalWID`='{2}' WHERE `Pathway1WID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pathwaylink` WHERE `Pathway1WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, Pathway1WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pathwaylink` (`Pathway1WID`, `Pathway2WID`, `ChemicalWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, Pathway1WID, Pathway2WID, ChemicalWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{Pathway1WID}', '{Pathway2WID}', '{ChemicalWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwaylink` (`Pathway1WID`, `Pathway2WID`, `ChemicalWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, Pathway1WID, Pathway2WID, ChemicalWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pathwaylink` SET `Pathway1WID`='{0}', `Pathway2WID`='{1}', `ChemicalWID`='{2}' WHERE `Pathway1WID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, Pathway1WID, Pathway2WID, ChemicalWID, Pathway1WID)
    End Function
#End Region
End Class


End Namespace
