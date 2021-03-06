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
''' DROP TABLE IF EXISTS `subunit`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `subunit` (
'''   `ComplexWID` bigint(20) NOT NULL,
'''   `SubunitWID` bigint(20) NOT NULL,
'''   `Coefficient` smallint(6) DEFAULT NULL,
'''   KEY `FK_Subunit1` (`ComplexWID`),
'''   KEY `FK_Subunit2` (`SubunitWID`),
'''   CONSTRAINT `FK_Subunit1` FOREIGN KEY (`ComplexWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Subunit2` FOREIGN KEY (`SubunitWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("subunit", Database:="warehouse", SchemaSQL:="
CREATE TABLE `subunit` (
  `ComplexWID` bigint(20) NOT NULL,
  `SubunitWID` bigint(20) NOT NULL,
  `Coefficient` smallint(6) DEFAULT NULL,
  KEY `FK_Subunit1` (`ComplexWID`),
  KEY `FK_Subunit2` (`SubunitWID`),
  CONSTRAINT `FK_Subunit1` FOREIGN KEY (`ComplexWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Subunit2` FOREIGN KEY (`SubunitWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class subunit: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ComplexWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ComplexWID As Long
    <DatabaseField("SubunitWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SubunitWID As Long
    <DatabaseField("Coefficient"), DataType(MySqlDbType.Int64, "6")> Public Property Coefficient As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `subunit` (`ComplexWID`, `SubunitWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `subunit` (`ComplexWID`, `SubunitWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `subunit` WHERE `ComplexWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `subunit` SET `ComplexWID`='{0}', `SubunitWID`='{1}', `Coefficient`='{2}' WHERE `ComplexWID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `subunit` WHERE `ComplexWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ComplexWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `subunit` (`ComplexWID`, `SubunitWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ComplexWID, SubunitWID, Coefficient)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ComplexWID}', '{SubunitWID}', '{Coefficient}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `subunit` (`ComplexWID`, `SubunitWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ComplexWID, SubunitWID, Coefficient)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `subunit` SET `ComplexWID`='{0}', `SubunitWID`='{1}', `Coefficient`='{2}' WHERE `ComplexWID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ComplexWID, SubunitWID, Coefficient, ComplexWID)
    End Function
#End Region
End Class


End Namespace
