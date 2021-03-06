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
''' DROP TABLE IF EXISTS `crossreference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `crossreference` (
'''   `OtherWID` bigint(20) NOT NULL,
'''   `CrossWID` bigint(20) DEFAULT NULL,
'''   `XID` varchar(50) DEFAULT NULL,
'''   `Type` varchar(20) DEFAULT NULL,
'''   `Version` varchar(10) DEFAULT NULL,
'''   `Relationship` varchar(50) DEFAULT NULL,
'''   `DatabaseName` varchar(255) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("crossreference", Database:="warehouse", SchemaSQL:="
CREATE TABLE `crossreference` (
  `OtherWID` bigint(20) NOT NULL,
  `CrossWID` bigint(20) DEFAULT NULL,
  `XID` varchar(50) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `Version` varchar(10) DEFAULT NULL,
  `Relationship` varchar(50) DEFAULT NULL,
  `DatabaseName` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class crossreference: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("OtherWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property OtherWID As Long
    <DatabaseField("CrossWID"), DataType(MySqlDbType.Int64, "20")> Public Property CrossWID As Long
    <DatabaseField("XID"), DataType(MySqlDbType.VarChar, "50")> Public Property XID As String
    <DatabaseField("Type"), DataType(MySqlDbType.VarChar, "20")> Public Property Type As String
    <DatabaseField("Version"), DataType(MySqlDbType.VarChar, "10")> Public Property Version As String
    <DatabaseField("Relationship"), DataType(MySqlDbType.VarChar, "50")> Public Property Relationship As String
    <DatabaseField("DatabaseName"), DataType(MySqlDbType.VarChar, "255")> Public Property DatabaseName As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `crossreference` (`OtherWID`, `CrossWID`, `XID`, `Type`, `Version`, `Relationship`, `DatabaseName`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `crossreference` (`OtherWID`, `CrossWID`, `XID`, `Type`, `Version`, `Relationship`, `DatabaseName`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `crossreference` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `crossreference` SET `OtherWID`='{0}', `CrossWID`='{1}', `XID`='{2}', `Type`='{3}', `Version`='{4}', `Relationship`='{5}', `DatabaseName`='{6}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `crossreference` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `crossreference` (`OtherWID`, `CrossWID`, `XID`, `Type`, `Version`, `Relationship`, `DatabaseName`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, OtherWID, CrossWID, XID, Type, Version, Relationship, DatabaseName)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{OtherWID}', '{CrossWID}', '{XID}', '{Type}', '{Version}', '{Relationship}', '{DatabaseName}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `crossreference` (`OtherWID`, `CrossWID`, `XID`, `Type`, `Version`, `Relationship`, `DatabaseName`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, OtherWID, CrossWID, XID, Type, Version, Relationship, DatabaseName)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `crossreference` SET `OtherWID`='{0}', `CrossWID`='{1}', `XID`='{2}', `Type`='{3}', `Version`='{4}', `Relationship`='{5}', `DatabaseName`='{6}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
