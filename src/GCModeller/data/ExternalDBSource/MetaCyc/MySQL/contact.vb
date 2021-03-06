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
''' DROP TABLE IF EXISTS `contact`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `contact` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `URI` varchar(255) DEFAULT NULL,
'''   `Address` varchar(255) DEFAULT NULL,
'''   `Phone` varchar(255) DEFAULT NULL,
'''   `TollFreePhone` varchar(255) DEFAULT NULL,
'''   `Email` varchar(255) DEFAULT NULL,
'''   `Fax` varchar(255) DEFAULT NULL,
'''   `Parent` bigint(20) DEFAULT NULL,
'''   `LastName` varchar(255) DEFAULT NULL,
'''   `FirstName` varchar(255) DEFAULT NULL,
'''   `MidInitials` varchar(255) DEFAULT NULL,
'''   `Affiliation` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Contact1` (`DataSetWID`),
'''   KEY `FK_Contact3` (`Parent`),
'''   KEY `FK_Contact4` (`Affiliation`),
'''   CONSTRAINT `FK_Contact1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Contact3` FOREIGN KEY (`Parent`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Contact4` FOREIGN KEY (`Affiliation`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("contact", Database:="warehouse", SchemaSQL:="
CREATE TABLE `contact` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `URI` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `TollFreePhone` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `Parent` bigint(20) DEFAULT NULL,
  `LastName` varchar(255) DEFAULT NULL,
  `FirstName` varchar(255) DEFAULT NULL,
  `MidInitials` varchar(255) DEFAULT NULL,
  `Affiliation` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Contact1` (`DataSetWID`),
  KEY `FK_Contact3` (`Parent`),
  KEY `FK_Contact4` (`Affiliation`),
  CONSTRAINT `FK_Contact1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Contact3` FOREIGN KEY (`Parent`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Contact4` FOREIGN KEY (`Affiliation`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class contact: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property MAGEClass As String
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("URI"), DataType(MySqlDbType.VarChar, "255")> Public Property URI As String
    <DatabaseField("Address"), DataType(MySqlDbType.VarChar, "255")> Public Property Address As String
    <DatabaseField("Phone"), DataType(MySqlDbType.VarChar, "255")> Public Property Phone As String
    <DatabaseField("TollFreePhone"), DataType(MySqlDbType.VarChar, "255")> Public Property TollFreePhone As String
    <DatabaseField("Email"), DataType(MySqlDbType.VarChar, "255")> Public Property Email As String
    <DatabaseField("Fax"), DataType(MySqlDbType.VarChar, "255")> Public Property Fax As String
    <DatabaseField("Parent"), DataType(MySqlDbType.Int64, "20")> Public Property Parent As Long
    <DatabaseField("LastName"), DataType(MySqlDbType.VarChar, "255")> Public Property LastName As String
    <DatabaseField("FirstName"), DataType(MySqlDbType.VarChar, "255")> Public Property FirstName As String
    <DatabaseField("MidInitials"), DataType(MySqlDbType.VarChar, "255")> Public Property MidInitials As String
    <DatabaseField("Affiliation"), DataType(MySqlDbType.Int64, "20")> Public Property Affiliation As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `contact` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Address`, `Phone`, `TollFreePhone`, `Email`, `Fax`, `Parent`, `LastName`, `FirstName`, `MidInitials`, `Affiliation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `contact` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Address`, `Phone`, `TollFreePhone`, `Email`, `Fax`, `Parent`, `LastName`, `FirstName`, `MidInitials`, `Affiliation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `contact` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `contact` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `URI`='{5}', `Address`='{6}', `Phone`='{7}', `TollFreePhone`='{8}', `Email`='{9}', `Fax`='{10}', `Parent`='{11}', `LastName`='{12}', `FirstName`='{13}', `MidInitials`='{14}', `Affiliation`='{15}' WHERE `WID` = '{16}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `contact` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `contact` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Address`, `Phone`, `TollFreePhone`, `Email`, `Fax`, `Parent`, `LastName`, `FirstName`, `MidInitials`, `Affiliation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Address, Phone, TollFreePhone, Email, Fax, Parent, LastName, FirstName, MidInitials, Affiliation)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{URI}', '{Address}', '{Phone}', '{TollFreePhone}', '{Email}', '{Fax}', '{Parent}', '{LastName}', '{FirstName}', '{MidInitials}', '{Affiliation}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `contact` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Address`, `Phone`, `TollFreePhone`, `Email`, `Fax`, `Parent`, `LastName`, `FirstName`, `MidInitials`, `Affiliation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Address, Phone, TollFreePhone, Email, Fax, Parent, LastName, FirstName, MidInitials, Affiliation)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `contact` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `URI`='{5}', `Address`='{6}', `Phone`='{7}', `TollFreePhone`='{8}', `Email`='{9}', `Fax`='{10}', `Parent`='{11}', `LastName`='{12}', `FirstName`='{13}', `MidInitials`='{14}', `Affiliation`='{15}' WHERE `WID` = '{16}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Address, Phone, TollFreePhone, Email, Fax, Parent, LastName, FirstName, MidInitials, Affiliation, WID)
    End Function
#End Region
End Class


End Namespace
