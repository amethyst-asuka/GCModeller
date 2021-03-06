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
''' DROP TABLE IF EXISTS `enzreactionaltcompound`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `enzreactionaltcompound` (
'''   `EnzymaticReactionWID` bigint(20) NOT NULL,
'''   `PrimaryWID` bigint(20) NOT NULL,
'''   `AlternativeWID` bigint(20) NOT NULL,
'''   `Cofactor` char(1) DEFAULT NULL,
'''   KEY `FK_ERAC1` (`EnzymaticReactionWID`),
'''   KEY `FK_ERAC2` (`PrimaryWID`),
'''   KEY `FK_ERAC3` (`AlternativeWID`),
'''   CONSTRAINT `FK_ERAC1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ERAC2` FOREIGN KEY (`PrimaryWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ERAC3` FOREIGN KEY (`AlternativeWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("enzreactionaltcompound", Database:="warehouse", SchemaSQL:="
CREATE TABLE `enzreactionaltcompound` (
  `EnzymaticReactionWID` bigint(20) NOT NULL,
  `PrimaryWID` bigint(20) NOT NULL,
  `AlternativeWID` bigint(20) NOT NULL,
  `Cofactor` char(1) DEFAULT NULL,
  KEY `FK_ERAC1` (`EnzymaticReactionWID`),
  KEY `FK_ERAC2` (`PrimaryWID`),
  KEY `FK_ERAC3` (`AlternativeWID`),
  CONSTRAINT `FK_ERAC1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ERAC2` FOREIGN KEY (`PrimaryWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ERAC3` FOREIGN KEY (`AlternativeWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class enzreactionaltcompound: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("EnzymaticReactionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property EnzymaticReactionWID As Long
    <DatabaseField("PrimaryWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property PrimaryWID As Long
    <DatabaseField("AlternativeWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property AlternativeWID As Long
    <DatabaseField("Cofactor"), DataType(MySqlDbType.VarChar, "1")> Public Property Cofactor As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `enzreactionaltcompound` (`EnzymaticReactionWID`, `PrimaryWID`, `AlternativeWID`, `Cofactor`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `enzreactionaltcompound` (`EnzymaticReactionWID`, `PrimaryWID`, `AlternativeWID`, `Cofactor`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `enzreactionaltcompound` WHERE `EnzymaticReactionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `enzreactionaltcompound` SET `EnzymaticReactionWID`='{0}', `PrimaryWID`='{1}', `AlternativeWID`='{2}', `Cofactor`='{3}' WHERE `EnzymaticReactionWID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `enzreactionaltcompound` WHERE `EnzymaticReactionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, EnzymaticReactionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `enzreactionaltcompound` (`EnzymaticReactionWID`, `PrimaryWID`, `AlternativeWID`, `Cofactor`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, EnzymaticReactionWID, PrimaryWID, AlternativeWID, Cofactor)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{EnzymaticReactionWID}', '{PrimaryWID}', '{AlternativeWID}', '{Cofactor}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `enzreactionaltcompound` (`EnzymaticReactionWID`, `PrimaryWID`, `AlternativeWID`, `Cofactor`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, EnzymaticReactionWID, PrimaryWID, AlternativeWID, Cofactor)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `enzreactionaltcompound` SET `EnzymaticReactionWID`='{0}', `PrimaryWID`='{1}', `AlternativeWID`='{2}', `Cofactor`='{3}' WHERE `EnzymaticReactionWID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, EnzymaticReactionWID, PrimaryWID, AlternativeWID, Cofactor, EnzymaticReactionWID)
    End Function
#End Region
End Class


End Namespace
