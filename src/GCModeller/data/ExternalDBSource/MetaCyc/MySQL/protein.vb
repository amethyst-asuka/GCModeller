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
''' DROP TABLE IF EXISTS `protein`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` text,
'''   `AASequence` longtext,
'''   `Length` int(11) DEFAULT NULL,
'''   `LengthApproximate` varchar(10) DEFAULT NULL,
'''   `Charge` smallint(6) DEFAULT NULL,
'''   `Fragment` char(1) DEFAULT NULL,
'''   `MolecularWeightCalc` float DEFAULT NULL,
'''   `MolecularWeightExp` float DEFAULT NULL,
'''   `PICalc` varchar(50) DEFAULT NULL,
'''   `PIExp` varchar(50) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `PROTEIN_DWID` (`DataSetWID`),
'''   CONSTRAINT `FK_Protein` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein", Database:="warehouse", SchemaSQL:="
CREATE TABLE `protein` (
  `WID` bigint(20) NOT NULL,
  `Name` text,
  `AASequence` longtext,
  `Length` int(11) DEFAULT NULL,
  `LengthApproximate` varchar(10) DEFAULT NULL,
  `Charge` smallint(6) DEFAULT NULL,
  `Fragment` char(1) DEFAULT NULL,
  `MolecularWeightCalc` float DEFAULT NULL,
  `MolecularWeightExp` float DEFAULT NULL,
  `PICalc` varchar(50) DEFAULT NULL,
  `PIExp` varchar(50) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `PROTEIN_DWID` (`DataSetWID`),
  CONSTRAINT `FK_Protein` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protein: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.Text)> Public Property Name As String
    <DatabaseField("AASequence"), DataType(MySqlDbType.Text)> Public Property AASequence As String
    <DatabaseField("Length"), DataType(MySqlDbType.Int64, "11")> Public Property Length As Long
    <DatabaseField("LengthApproximate"), DataType(MySqlDbType.VarChar, "10")> Public Property LengthApproximate As String
    <DatabaseField("Charge"), DataType(MySqlDbType.Int64, "6")> Public Property Charge As Long
    <DatabaseField("Fragment"), DataType(MySqlDbType.VarChar, "1")> Public Property Fragment As String
    <DatabaseField("MolecularWeightCalc"), DataType(MySqlDbType.Double)> Public Property MolecularWeightCalc As Double
    <DatabaseField("MolecularWeightExp"), DataType(MySqlDbType.Double)> Public Property MolecularWeightExp As Double
    <DatabaseField("PICalc"), DataType(MySqlDbType.VarChar, "50")> Public Property PICalc As String
    <DatabaseField("PIExp"), DataType(MySqlDbType.VarChar, "50")> Public Property PIExp As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein` (`WID`, `Name`, `AASequence`, `Length`, `LengthApproximate`, `Charge`, `Fragment`, `MolecularWeightCalc`, `MolecularWeightExp`, `PICalc`, `PIExp`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein` (`WID`, `Name`, `AASequence`, `Length`, `LengthApproximate`, `Charge`, `Fragment`, `MolecularWeightCalc`, `MolecularWeightExp`, `PICalc`, `PIExp`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein` SET `WID`='{0}', `Name`='{1}', `AASequence`='{2}', `Length`='{3}', `LengthApproximate`='{4}', `Charge`='{5}', `Fragment`='{6}', `MolecularWeightCalc`='{7}', `MolecularWeightExp`='{8}', `PICalc`='{9}', `PIExp`='{10}', `DataSetWID`='{11}' WHERE `WID` = '{12}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein` (`WID`, `Name`, `AASequence`, `Length`, `LengthApproximate`, `Charge`, `Fragment`, `MolecularWeightCalc`, `MolecularWeightExp`, `PICalc`, `PIExp`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, AASequence, Length, LengthApproximate, Charge, Fragment, MolecularWeightCalc, MolecularWeightExp, PICalc, PIExp, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{AASequence}', '{Length}', '{LengthApproximate}', '{Charge}', '{Fragment}', '{MolecularWeightCalc}', '{MolecularWeightExp}', '{PICalc}', '{PIExp}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein` (`WID`, `Name`, `AASequence`, `Length`, `LengthApproximate`, `Charge`, `Fragment`, `MolecularWeightCalc`, `MolecularWeightExp`, `PICalc`, `PIExp`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, AASequence, Length, LengthApproximate, Charge, Fragment, MolecularWeightCalc, MolecularWeightExp, PICalc, PIExp, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein` SET `WID`='{0}', `Name`='{1}', `AASequence`='{2}', `Length`='{3}', `LengthApproximate`='{4}', `Charge`='{5}', `Fragment`='{6}', `MolecularWeightCalc`='{7}', `MolecularWeightExp`='{8}', `PICalc`='{9}', `PIExp`='{10}', `DataSetWID`='{11}' WHERE `WID` = '{12}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, AASequence, Length, LengthApproximate, Charge, Fragment, MolecularWeightCalc, MolecularWeightExp, PICalc, PIExp, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
