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
''' DROP TABLE IF EXISTS `termrelationship`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `termrelationship` (
'''   `TermWID` bigint(20) NOT NULL,
'''   `RelatedTermWID` bigint(20) NOT NULL,
'''   `Relationship` varchar(10) NOT NULL,
'''   KEY `FK_TermRelationship1` (`TermWID`),
'''   KEY `FK_TermRelationship2` (`RelatedTermWID`),
'''   CONSTRAINT `FK_TermRelationship1` FOREIGN KEY (`TermWID`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_TermRelationship2` FOREIGN KEY (`RelatedTermWID`) REFERENCES `term` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("termrelationship", Database:="warehouse", SchemaSQL:="
CREATE TABLE `termrelationship` (
  `TermWID` bigint(20) NOT NULL,
  `RelatedTermWID` bigint(20) NOT NULL,
  `Relationship` varchar(10) NOT NULL,
  KEY `FK_TermRelationship1` (`TermWID`),
  KEY `FK_TermRelationship2` (`RelatedTermWID`),
  CONSTRAINT `FK_TermRelationship1` FOREIGN KEY (`TermWID`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_TermRelationship2` FOREIGN KEY (`RelatedTermWID`) REFERENCES `term` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class termrelationship: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("TermWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property TermWID As Long
    <DatabaseField("RelatedTermWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property RelatedTermWID As Long
    <DatabaseField("Relationship"), NotNull, DataType(MySqlDbType.VarChar, "10")> Public Property Relationship As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `termrelationship` (`TermWID`, `RelatedTermWID`, `Relationship`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `termrelationship` (`TermWID`, `RelatedTermWID`, `Relationship`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `termrelationship` WHERE `TermWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `termrelationship` SET `TermWID`='{0}', `RelatedTermWID`='{1}', `Relationship`='{2}' WHERE `TermWID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `termrelationship` WHERE `TermWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, TermWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `termrelationship` (`TermWID`, `RelatedTermWID`, `Relationship`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, TermWID, RelatedTermWID, Relationship)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{TermWID}', '{RelatedTermWID}', '{Relationship}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `termrelationship` (`TermWID`, `RelatedTermWID`, `Relationship`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, TermWID, RelatedTermWID, Relationship)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `termrelationship` SET `TermWID`='{0}', `RelatedTermWID`='{1}', `Relationship`='{2}' WHERE `TermWID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, TermWID, RelatedTermWID, Relationship, TermWID)
    End Function
#End Region
End Class


End Namespace
