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
''' DROP TABLE IF EXISTS `pathwayreaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwayreaction` (
'''   `PathwayWID` bigint(20) NOT NULL,
'''   `ReactionWID` bigint(20) NOT NULL,
'''   `PriorReactionWID` bigint(20) DEFAULT NULL,
'''   `Hypothetical` char(1) NOT NULL,
'''   KEY `PR_PATHWID_REACTIONWID` (`PathwayWID`,`ReactionWID`),
'''   KEY `FK_PathwayReaction3` (`PriorReactionWID`),
'''   CONSTRAINT `FK_PathwayReaction1` FOREIGN KEY (`PathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_PathwayReaction3` FOREIGN KEY (`PriorReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwayreaction", Database:="warehouse", SchemaSQL:="
CREATE TABLE `pathwayreaction` (
  `PathwayWID` bigint(20) NOT NULL,
  `ReactionWID` bigint(20) NOT NULL,
  `PriorReactionWID` bigint(20) DEFAULT NULL,
  `Hypothetical` char(1) NOT NULL,
  KEY `PR_PATHWID_REACTIONWID` (`PathwayWID`,`ReactionWID`),
  KEY `FK_PathwayReaction3` (`PriorReactionWID`),
  CONSTRAINT `FK_PathwayReaction1` FOREIGN KEY (`PathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_PathwayReaction3` FOREIGN KEY (`PriorReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class pathwayreaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("PathwayWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property PathwayWID As Long
    <DatabaseField("ReactionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReactionWID As Long
    <DatabaseField("PriorReactionWID"), DataType(MySqlDbType.Int64, "20")> Public Property PriorReactionWID As Long
    <DatabaseField("Hypothetical"), NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property Hypothetical As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pathwayreaction` WHERE `PathwayWID`='{0}' and `ReactionWID`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pathwayreaction` SET `PathwayWID`='{0}', `ReactionWID`='{1}', `PriorReactionWID`='{2}', `Hypothetical`='{3}' WHERE `PathwayWID`='{4}' and `ReactionWID`='{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pathwayreaction` WHERE `PathwayWID`='{0}' and `ReactionWID`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, PathwayWID, ReactionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{PathwayWID}', '{ReactionWID}', '{PriorReactionWID}', '{Hypothetical}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pathwayreaction` SET `PathwayWID`='{0}', `ReactionWID`='{1}', `PriorReactionWID`='{2}', `Hypothetical`='{3}' WHERE `PathwayWID`='{4}' and `ReactionWID`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical, PathwayWID, ReactionWID)
    End Function
#End Region
End Class


End Namespace
