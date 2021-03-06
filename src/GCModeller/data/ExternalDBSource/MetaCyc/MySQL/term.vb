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
''' DROP TABLE IF EXISTS `term`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `term` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` varchar(255) NOT NULL,
'''   `Definition` text,
'''   `Hierarchical` char(1) DEFAULT NULL,
'''   `Root` char(1) DEFAULT NULL,
'''   `Obsolete` char(1) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("term", Database:="warehouse", SchemaSQL:="
CREATE TABLE `term` (
  `WID` bigint(20) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Definition` text,
  `Hierarchical` char(1) DEFAULT NULL,
  `Root` char(1) DEFAULT NULL,
  `Obsolete` char(1) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class term: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("Definition"), DataType(MySqlDbType.Text)> Public Property Definition As String
    <DatabaseField("Hierarchical"), DataType(MySqlDbType.VarChar, "1")> Public Property Hierarchical As String
    <DatabaseField("Root"), DataType(MySqlDbType.VarChar, "1")> Public Property Root As String
    <DatabaseField("Obsolete"), DataType(MySqlDbType.VarChar, "1")> Public Property Obsolete As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `term` (`WID`, `Name`, `Definition`, `Hierarchical`, `Root`, `Obsolete`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `term` (`WID`, `Name`, `Definition`, `Hierarchical`, `Root`, `Obsolete`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `term` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `term` SET `WID`='{0}', `Name`='{1}', `Definition`='{2}', `Hierarchical`='{3}', `Root`='{4}', `Obsolete`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `term` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `term` (`WID`, `Name`, `Definition`, `Hierarchical`, `Root`, `Obsolete`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, Definition, Hierarchical, Root, Obsolete, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{Definition}', '{Hierarchical}', '{Root}', '{Obsolete}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `term` (`WID`, `Name`, `Definition`, `Hierarchical`, `Root`, `Obsolete`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, Definition, Hierarchical, Root, Obsolete, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `term` SET `WID`='{0}', `Name`='{1}', `Definition`='{2}', `Hierarchical`='{3}', `Root`='{4}', `Obsolete`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, Definition, Hierarchical, Root, Obsolete, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
