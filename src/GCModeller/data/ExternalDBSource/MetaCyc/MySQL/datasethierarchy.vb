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
''' DROP TABLE IF EXISTS `datasethierarchy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `datasethierarchy` (
'''   `SuperWID` bigint(20) NOT NULL,
'''   `SubWID` bigint(20) NOT NULL,
'''   KEY `FK_DataSetHierarchy1` (`SuperWID`),
'''   KEY `FK_DataSetHierarchy2` (`SubWID`),
'''   CONSTRAINT `FK_DataSetHierarchy1` FOREIGN KEY (`SuperWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DataSetHierarchy2` FOREIGN KEY (`SubWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("datasethierarchy", Database:="warehouse", SchemaSQL:="
CREATE TABLE `datasethierarchy` (
  `SuperWID` bigint(20) NOT NULL,
  `SubWID` bigint(20) NOT NULL,
  KEY `FK_DataSetHierarchy1` (`SuperWID`),
  KEY `FK_DataSetHierarchy2` (`SubWID`),
  CONSTRAINT `FK_DataSetHierarchy1` FOREIGN KEY (`SuperWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DataSetHierarchy2` FOREIGN KEY (`SubWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class datasethierarchy: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("SuperWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SuperWID As Long
    <DatabaseField("SubWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SubWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `datasethierarchy` (`SuperWID`, `SubWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `datasethierarchy` (`SuperWID`, `SubWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `datasethierarchy` WHERE `SuperWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `datasethierarchy` SET `SuperWID`='{0}', `SubWID`='{1}' WHERE `SuperWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `datasethierarchy` WHERE `SuperWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, SuperWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `datasethierarchy` (`SuperWID`, `SubWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, SuperWID, SubWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{SuperWID}', '{SubWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `datasethierarchy` (`SuperWID`, `SubWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, SuperWID, SubWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `datasethierarchy` SET `SuperWID`='{0}', `SubWID`='{1}' WHERE `SuperWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, SuperWID, SubWID, SuperWID)
    End Function
#End Region
End Class


End Namespace
