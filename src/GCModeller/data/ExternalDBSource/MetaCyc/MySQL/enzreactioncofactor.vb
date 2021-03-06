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
''' DROP TABLE IF EXISTS `enzreactioncofactor`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `enzreactioncofactor` (
'''   `EnzymaticReactionWID` bigint(20) NOT NULL,
'''   `ChemicalWID` bigint(20) NOT NULL,
'''   `Prosthetic` char(1) DEFAULT NULL,
'''   KEY `FK_EnzReactionCofactor1` (`EnzymaticReactionWID`),
'''   KEY `FK_EnzReactionCofactor2` (`ChemicalWID`),
'''   CONSTRAINT `FK_EnzReactionCofactor1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_EnzReactionCofactor2` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("enzreactioncofactor", Database:="warehouse", SchemaSQL:="
CREATE TABLE `enzreactioncofactor` (
  `EnzymaticReactionWID` bigint(20) NOT NULL,
  `ChemicalWID` bigint(20) NOT NULL,
  `Prosthetic` char(1) DEFAULT NULL,
  KEY `FK_EnzReactionCofactor1` (`EnzymaticReactionWID`),
  KEY `FK_EnzReactionCofactor2` (`ChemicalWID`),
  CONSTRAINT `FK_EnzReactionCofactor1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_EnzReactionCofactor2` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class enzreactioncofactor: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("EnzymaticReactionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property EnzymaticReactionWID As Long
    <DatabaseField("ChemicalWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ChemicalWID As Long
    <DatabaseField("Prosthetic"), DataType(MySqlDbType.VarChar, "1")> Public Property Prosthetic As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `enzreactioncofactor` (`EnzymaticReactionWID`, `ChemicalWID`, `Prosthetic`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `enzreactioncofactor` (`EnzymaticReactionWID`, `ChemicalWID`, `Prosthetic`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `enzreactioncofactor` WHERE `EnzymaticReactionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `enzreactioncofactor` SET `EnzymaticReactionWID`='{0}', `ChemicalWID`='{1}', `Prosthetic`='{2}' WHERE `EnzymaticReactionWID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `enzreactioncofactor` WHERE `EnzymaticReactionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, EnzymaticReactionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `enzreactioncofactor` (`EnzymaticReactionWID`, `ChemicalWID`, `Prosthetic`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, EnzymaticReactionWID, ChemicalWID, Prosthetic)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{EnzymaticReactionWID}', '{ChemicalWID}', '{Prosthetic}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `enzreactioncofactor` (`EnzymaticReactionWID`, `ChemicalWID`, `Prosthetic`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, EnzymaticReactionWID, ChemicalWID, Prosthetic)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `enzreactioncofactor` SET `EnzymaticReactionWID`='{0}', `ChemicalWID`='{1}', `Prosthetic`='{2}' WHERE `EnzymaticReactionWID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, EnzymaticReactionWID, ChemicalWID, Prosthetic, EnzymaticReactionWID)
    End Function
#End Region
End Class


End Namespace
