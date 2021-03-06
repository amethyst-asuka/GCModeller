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
''' DROP TABLE IF EXISTS `enzreactioninhibitoractivator`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `enzreactioninhibitoractivator` (
'''   `EnzymaticReactionWID` bigint(20) NOT NULL,
'''   `CompoundWID` bigint(20) NOT NULL,
'''   `InhibitOrActivate` char(1) DEFAULT NULL,
'''   `Mechanism` char(1) DEFAULT NULL,
'''   `PhysioRelevant` char(1) DEFAULT NULL,
'''   KEY `FK_EnzReactionIA1` (`EnzymaticReactionWID`),
'''   CONSTRAINT `FK_EnzReactionIA1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("enzreactioninhibitoractivator", Database:="warehouse", SchemaSQL:="
CREATE TABLE `enzreactioninhibitoractivator` (
  `EnzymaticReactionWID` bigint(20) NOT NULL,
  `CompoundWID` bigint(20) NOT NULL,
  `InhibitOrActivate` char(1) DEFAULT NULL,
  `Mechanism` char(1) DEFAULT NULL,
  `PhysioRelevant` char(1) DEFAULT NULL,
  KEY `FK_EnzReactionIA1` (`EnzymaticReactionWID`),
  CONSTRAINT `FK_EnzReactionIA1` FOREIGN KEY (`EnzymaticReactionWID`) REFERENCES `enzymaticreaction` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class enzreactioninhibitoractivator: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("EnzymaticReactionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property EnzymaticReactionWID As Long
    <DatabaseField("CompoundWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompoundWID As Long
    <DatabaseField("InhibitOrActivate"), DataType(MySqlDbType.VarChar, "1")> Public Property InhibitOrActivate As String
    <DatabaseField("Mechanism"), DataType(MySqlDbType.VarChar, "1")> Public Property Mechanism As String
    <DatabaseField("PhysioRelevant"), DataType(MySqlDbType.VarChar, "1")> Public Property PhysioRelevant As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `enzreactioninhibitoractivator` (`EnzymaticReactionWID`, `CompoundWID`, `InhibitOrActivate`, `Mechanism`, `PhysioRelevant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `enzreactioninhibitoractivator` (`EnzymaticReactionWID`, `CompoundWID`, `InhibitOrActivate`, `Mechanism`, `PhysioRelevant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `enzreactioninhibitoractivator` WHERE `EnzymaticReactionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `enzreactioninhibitoractivator` SET `EnzymaticReactionWID`='{0}', `CompoundWID`='{1}', `InhibitOrActivate`='{2}', `Mechanism`='{3}', `PhysioRelevant`='{4}' WHERE `EnzymaticReactionWID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `enzreactioninhibitoractivator` WHERE `EnzymaticReactionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, EnzymaticReactionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `enzreactioninhibitoractivator` (`EnzymaticReactionWID`, `CompoundWID`, `InhibitOrActivate`, `Mechanism`, `PhysioRelevant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, EnzymaticReactionWID, CompoundWID, InhibitOrActivate, Mechanism, PhysioRelevant)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{EnzymaticReactionWID}', '{CompoundWID}', '{InhibitOrActivate}', '{Mechanism}', '{PhysioRelevant}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `enzreactioninhibitoractivator` (`EnzymaticReactionWID`, `CompoundWID`, `InhibitOrActivate`, `Mechanism`, `PhysioRelevant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, EnzymaticReactionWID, CompoundWID, InhibitOrActivate, Mechanism, PhysioRelevant)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `enzreactioninhibitoractivator` SET `EnzymaticReactionWID`='{0}', `CompoundWID`='{1}', `InhibitOrActivate`='{2}', `Mechanism`='{3}', `PhysioRelevant`='{4}' WHERE `EnzymaticReactionWID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, EnzymaticReactionWID, CompoundWID, InhibitOrActivate, Mechanism, PhysioRelevant, EnzymaticReactionWID)
    End Function
#End Region
End Class


End Namespace
