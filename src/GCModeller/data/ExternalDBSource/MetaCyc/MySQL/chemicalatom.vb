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
''' DROP TABLE IF EXISTS `chemicalatom`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `chemicalatom` (
'''   `ChemicalWID` bigint(20) NOT NULL,
'''   `AtomIndex` smallint(6) NOT NULL,
'''   `Atom` varchar(2) NOT NULL,
'''   `Charge` smallint(6) NOT NULL,
'''   `X` decimal(10,0) DEFAULT NULL,
'''   `Y` decimal(10,0) DEFAULT NULL,
'''   `Z` decimal(10,0) DEFAULT NULL,
'''   `StereoParity` decimal(10,0) DEFAULT NULL,
'''   UNIQUE KEY `UN_ChemicalAtom` (`ChemicalWID`,`AtomIndex`),
'''   CONSTRAINT `FK_ChemicalAtom` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("chemicalatom", Database:="warehouse", SchemaSQL:="
CREATE TABLE `chemicalatom` (
  `ChemicalWID` bigint(20) NOT NULL,
  `AtomIndex` smallint(6) NOT NULL,
  `Atom` varchar(2) NOT NULL,
  `Charge` smallint(6) NOT NULL,
  `X` decimal(10,0) DEFAULT NULL,
  `Y` decimal(10,0) DEFAULT NULL,
  `Z` decimal(10,0) DEFAULT NULL,
  `StereoParity` decimal(10,0) DEFAULT NULL,
  UNIQUE KEY `UN_ChemicalAtom` (`ChemicalWID`,`AtomIndex`),
  CONSTRAINT `FK_ChemicalAtom` FOREIGN KEY (`ChemicalWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class chemicalatom: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ChemicalWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ChemicalWID As Long
    <DatabaseField("AtomIndex"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "6")> Public Property AtomIndex As Long
    <DatabaseField("Atom"), NotNull, DataType(MySqlDbType.VarChar, "2")> Public Property Atom As String
    <DatabaseField("Charge"), NotNull, DataType(MySqlDbType.Int64, "6")> Public Property Charge As Long
    <DatabaseField("X"), DataType(MySqlDbType.Decimal)> Public Property X As Decimal
    <DatabaseField("Y"), DataType(MySqlDbType.Decimal)> Public Property Y As Decimal
    <DatabaseField("Z"), DataType(MySqlDbType.Decimal)> Public Property Z As Decimal
    <DatabaseField("StereoParity"), DataType(MySqlDbType.Decimal)> Public Property StereoParity As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `chemicalatom` (`ChemicalWID`, `AtomIndex`, `Atom`, `Charge`, `X`, `Y`, `Z`, `StereoParity`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `chemicalatom` (`ChemicalWID`, `AtomIndex`, `Atom`, `Charge`, `X`, `Y`, `Z`, `StereoParity`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `chemicalatom` WHERE `ChemicalWID`='{0}' and `AtomIndex`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `chemicalatom` SET `ChemicalWID`='{0}', `AtomIndex`='{1}', `Atom`='{2}', `Charge`='{3}', `X`='{4}', `Y`='{5}', `Z`='{6}', `StereoParity`='{7}' WHERE `ChemicalWID`='{8}' and `AtomIndex`='{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `chemicalatom` WHERE `ChemicalWID`='{0}' and `AtomIndex`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ChemicalWID, AtomIndex)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `chemicalatom` (`ChemicalWID`, `AtomIndex`, `Atom`, `Charge`, `X`, `Y`, `Z`, `StereoParity`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ChemicalWID, AtomIndex, Atom, Charge, X, Y, Z, StereoParity)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ChemicalWID}', '{AtomIndex}', '{Atom}', '{Charge}', '{X}', '{Y}', '{Z}', '{StereoParity}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `chemicalatom` (`ChemicalWID`, `AtomIndex`, `Atom`, `Charge`, `X`, `Y`, `Z`, `StereoParity`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ChemicalWID, AtomIndex, Atom, Charge, X, Y, Z, StereoParity)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `chemicalatom` SET `ChemicalWID`='{0}', `AtomIndex`='{1}', `Atom`='{2}', `Charge`='{3}', `X`='{4}', `Y`='{5}', `Z`='{6}', `StereoParity`='{7}' WHERE `ChemicalWID`='{8}' and `AtomIndex`='{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ChemicalWID, AtomIndex, Atom, Charge, X, Y, Z, StereoParity, ChemicalWID, AtomIndex)
    End Function
#End Region
End Class


End Namespace
