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
''' DROP TABLE IF EXISTS `warehouse`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `warehouse` (
'''   `Version` decimal(6,3) NOT NULL,
'''   `LoadDate` datetime NOT NULL,
'''   `MaxSpecialWID` bigint(20) NOT NULL,
'''   `MaxReservedWID` bigint(20) NOT NULL,
'''   `Description` text
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("warehouse", Database:="warehouse", SchemaSQL:="
CREATE TABLE `warehouse` (
  `Version` decimal(6,3) NOT NULL,
  `LoadDate` datetime NOT NULL,
  `MaxSpecialWID` bigint(20) NOT NULL,
  `MaxReservedWID` bigint(20) NOT NULL,
  `Description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class warehouse: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("Version"), NotNull, DataType(MySqlDbType.Decimal)> Public Property Version As Decimal
    <DatabaseField("LoadDate"), NotNull, DataType(MySqlDbType.DateTime)> Public Property LoadDate As Date
    <DatabaseField("MaxSpecialWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property MaxSpecialWID As Long
    <DatabaseField("MaxReservedWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property MaxReservedWID As Long
    <DatabaseField("Description"), DataType(MySqlDbType.Text)> Public Property Description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `warehouse` (`Version`, `LoadDate`, `MaxSpecialWID`, `MaxReservedWID`, `Description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `warehouse` (`Version`, `LoadDate`, `MaxSpecialWID`, `MaxReservedWID`, `Description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `warehouse` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `warehouse` SET `Version`='{0}', `LoadDate`='{1}', `MaxSpecialWID`='{2}', `MaxReservedWID`='{3}', `Description`='{4}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `warehouse` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `warehouse` (`Version`, `LoadDate`, `MaxSpecialWID`, `MaxReservedWID`, `Description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, Version, DataType.ToMySqlDateTimeString(LoadDate), MaxSpecialWID, MaxReservedWID, Description)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{Version}', '{LoadDate}', '{MaxSpecialWID}', '{MaxReservedWID}', '{Description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `warehouse` (`Version`, `LoadDate`, `MaxSpecialWID`, `MaxReservedWID`, `Description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, Version, DataType.ToMySqlDateTimeString(LoadDate), MaxSpecialWID, MaxReservedWID, Description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `warehouse` SET `Version`='{0}', `LoadDate`='{1}', `MaxSpecialWID`='{2}', `MaxReservedWID`='{3}', `Description`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
