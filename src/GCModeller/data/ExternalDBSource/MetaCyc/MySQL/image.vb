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
''' DROP TABLE IF EXISTS `image`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `image` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `URI` varchar(255) DEFAULT NULL,
'''   `Image_Format` bigint(20) DEFAULT NULL,
'''   `PhysicalBioAssay` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Image1` (`DataSetWID`),
'''   KEY `FK_Image3` (`Image_Format`),
'''   KEY `FK_Image4` (`PhysicalBioAssay`),
'''   CONSTRAINT `FK_Image1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Image3` FOREIGN KEY (`Image_Format`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Image4` FOREIGN KEY (`PhysicalBioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("image", Database:="warehouse", SchemaSQL:="
CREATE TABLE `image` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `URI` varchar(255) DEFAULT NULL,
  `Image_Format` bigint(20) DEFAULT NULL,
  `PhysicalBioAssay` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Image1` (`DataSetWID`),
  KEY `FK_Image3` (`Image_Format`),
  KEY `FK_Image4` (`PhysicalBioAssay`),
  CONSTRAINT `FK_Image1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Image3` FOREIGN KEY (`Image_Format`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Image4` FOREIGN KEY (`PhysicalBioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class image: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("URI"), DataType(MySqlDbType.VarChar, "255")> Public Property URI As String
    <DatabaseField("Image_Format"), DataType(MySqlDbType.Int64, "20")> Public Property Image_Format As Long
    <DatabaseField("PhysicalBioAssay"), DataType(MySqlDbType.Int64, "20")> Public Property PhysicalBioAssay As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `image` (`WID`, `DataSetWID`, `Identifier`, `Name`, `URI`, `Image_Format`, `PhysicalBioAssay`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `image` (`WID`, `DataSetWID`, `Identifier`, `Name`, `URI`, `Image_Format`, `PhysicalBioAssay`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `image` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `image` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `URI`='{4}', `Image_Format`='{5}', `PhysicalBioAssay`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `image` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `image` (`WID`, `DataSetWID`, `Identifier`, `Name`, `URI`, `Image_Format`, `PhysicalBioAssay`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name, URI, Image_Format, PhysicalBioAssay)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}', '{URI}', '{Image_Format}', '{PhysicalBioAssay}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `image` (`WID`, `DataSetWID`, `Identifier`, `Name`, `URI`, `Image_Format`, `PhysicalBioAssay`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name, URI, Image_Format, PhysicalBioAssay)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `image` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `URI`='{4}', `Image_Format`='{5}', `PhysicalBioAssay`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Identifier, Name, URI, Image_Format, PhysicalBioAssay, WID)
    End Function
#End Region
End Class


End Namespace
