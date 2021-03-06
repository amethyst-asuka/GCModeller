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
''' DROP TABLE IF EXISTS `synonymtable`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `synonymtable` (
'''   `OtherWID` bigint(20) NOT NULL,
'''   `Syn` varchar(255) NOT NULL,
'''   KEY `SYNONYM_OTHERWID_SYN` (`OtherWID`,`Syn`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("synonymtable", Database:="warehouse", SchemaSQL:="
CREATE TABLE `synonymtable` (
  `OtherWID` bigint(20) NOT NULL,
  `Syn` varchar(255) NOT NULL,
  KEY `SYNONYM_OTHERWID_SYN` (`OtherWID`,`Syn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class synonymtable: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("OtherWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property OtherWID As Long
    <DatabaseField("Syn"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property Syn As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `synonymtable` (`OtherWID`, `Syn`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `synonymtable` (`OtherWID`, `Syn`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `synonymtable` WHERE `OtherWID`='{0}' and `Syn`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `synonymtable` SET `OtherWID`='{0}', `Syn`='{1}' WHERE `OtherWID`='{2}' and `Syn`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `synonymtable` WHERE `OtherWID`='{0}' and `Syn`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, OtherWID, Syn)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `synonymtable` (`OtherWID`, `Syn`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, OtherWID, Syn)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{OtherWID}', '{Syn}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `synonymtable` (`OtherWID`, `Syn`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, OtherWID, Syn)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `synonymtable` SET `OtherWID`='{0}', `Syn`='{1}' WHERE `OtherWID`='{2}' and `Syn`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, OtherWID, Syn, OtherWID, Syn)
    End Function
#End Region
End Class


End Namespace
