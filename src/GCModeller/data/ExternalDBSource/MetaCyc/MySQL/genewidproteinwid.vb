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
''' DROP TABLE IF EXISTS `genewidproteinwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `genewidproteinwid` (
'''   `GeneWID` bigint(20) NOT NULL,
'''   `ProteinWID` bigint(20) NOT NULL,
'''   KEY `FK_GeneWIDProteinWID1` (`GeneWID`),
'''   KEY `FK_GeneWIDProteinWID2` (`ProteinWID`),
'''   CONSTRAINT `FK_GeneWIDProteinWID1` FOREIGN KEY (`GeneWID`) REFERENCES `gene` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_GeneWIDProteinWID2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("genewidproteinwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `genewidproteinwid` (
  `GeneWID` bigint(20) NOT NULL,
  `ProteinWID` bigint(20) NOT NULL,
  KEY `FK_GeneWIDProteinWID1` (`GeneWID`),
  KEY `FK_GeneWIDProteinWID2` (`ProteinWID`),
  CONSTRAINT `FK_GeneWIDProteinWID1` FOREIGN KEY (`GeneWID`) REFERENCES `gene` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_GeneWIDProteinWID2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class genewidproteinwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("GeneWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property GeneWID As Long
    <DatabaseField("ProteinWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProteinWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `genewidproteinwid` (`GeneWID`, `ProteinWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `genewidproteinwid` (`GeneWID`, `ProteinWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `genewidproteinwid` WHERE `GeneWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `genewidproteinwid` SET `GeneWID`='{0}', `ProteinWID`='{1}' WHERE `GeneWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `genewidproteinwid` WHERE `GeneWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, GeneWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `genewidproteinwid` (`GeneWID`, `ProteinWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, GeneWID, ProteinWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{GeneWID}', '{ProteinWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `genewidproteinwid` (`GeneWID`, `ProteinWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, GeneWID, ProteinWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `genewidproteinwid` SET `GeneWID`='{0}', `ProteinWID`='{1}' WHERE `GeneWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, GeneWID, ProteinWID, GeneWID)
    End Function
#End Region
End Class


End Namespace
