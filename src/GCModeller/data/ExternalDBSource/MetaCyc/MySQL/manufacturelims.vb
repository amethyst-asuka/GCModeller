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
''' DROP TABLE IF EXISTS `manufacturelims`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `manufacturelims` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `ArrayManufacture_FeatureLIMSs` bigint(20) DEFAULT NULL,
'''   `Quality` varchar(255) DEFAULT NULL,
'''   `Feature` bigint(20) DEFAULT NULL,
'''   `BioMaterial` bigint(20) DEFAULT NULL,
'''   `ManufactureLIMS_IdentifierLIMS` bigint(20) DEFAULT NULL,
'''   `BioMaterialPlateIdentifier` varchar(255) DEFAULT NULL,
'''   `BioMaterialPlateRow` varchar(255) DEFAULT NULL,
'''   `BioMaterialPlateCol` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ManufactureLIMS1` (`DataSetWID`),
'''   KEY `FK_ManufactureLIMS3` (`ArrayManufacture_FeatureLIMSs`),
'''   KEY `FK_ManufactureLIMS4` (`Feature`),
'''   KEY `FK_ManufactureLIMS5` (`BioMaterial`),
'''   CONSTRAINT `FK_ManufactureLIMS1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ManufactureLIMS3` FOREIGN KEY (`ArrayManufacture_FeatureLIMSs`) REFERENCES `arraymanufacture` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ManufactureLIMS4` FOREIGN KEY (`Feature`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ManufactureLIMS5` FOREIGN KEY (`BioMaterial`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("manufacturelims", Database:="warehouse", SchemaSQL:="
CREATE TABLE `manufacturelims` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `ArrayManufacture_FeatureLIMSs` bigint(20) DEFAULT NULL,
  `Quality` varchar(255) DEFAULT NULL,
  `Feature` bigint(20) DEFAULT NULL,
  `BioMaterial` bigint(20) DEFAULT NULL,
  `ManufactureLIMS_IdentifierLIMS` bigint(20) DEFAULT NULL,
  `BioMaterialPlateIdentifier` varchar(255) DEFAULT NULL,
  `BioMaterialPlateRow` varchar(255) DEFAULT NULL,
  `BioMaterialPlateCol` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ManufactureLIMS1` (`DataSetWID`),
  KEY `FK_ManufactureLIMS3` (`ArrayManufacture_FeatureLIMSs`),
  KEY `FK_ManufactureLIMS4` (`Feature`),
  KEY `FK_ManufactureLIMS5` (`BioMaterial`),
  CONSTRAINT `FK_ManufactureLIMS1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ManufactureLIMS3` FOREIGN KEY (`ArrayManufacture_FeatureLIMSs`) REFERENCES `arraymanufacture` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ManufactureLIMS4` FOREIGN KEY (`Feature`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ManufactureLIMS5` FOREIGN KEY (`BioMaterial`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class manufacturelims: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property MAGEClass As String
    <DatabaseField("ArrayManufacture_FeatureLIMSs"), DataType(MySqlDbType.Int64, "20")> Public Property ArrayManufacture_FeatureLIMSs As Long
    <DatabaseField("Quality"), DataType(MySqlDbType.VarChar, "255")> Public Property Quality As String
    <DatabaseField("Feature"), DataType(MySqlDbType.Int64, "20")> Public Property Feature As Long
    <DatabaseField("BioMaterial"), DataType(MySqlDbType.Int64, "20")> Public Property BioMaterial As Long
    <DatabaseField("ManufactureLIMS_IdentifierLIMS"), DataType(MySqlDbType.Int64, "20")> Public Property ManufactureLIMS_IdentifierLIMS As Long
    <DatabaseField("BioMaterialPlateIdentifier"), DataType(MySqlDbType.VarChar, "255")> Public Property BioMaterialPlateIdentifier As String
    <DatabaseField("BioMaterialPlateRow"), DataType(MySqlDbType.VarChar, "255")> Public Property BioMaterialPlateRow As String
    <DatabaseField("BioMaterialPlateCol"), DataType(MySqlDbType.VarChar, "255")> Public Property BioMaterialPlateCol As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `manufacturelims` (`WID`, `DataSetWID`, `MAGEClass`, `ArrayManufacture_FeatureLIMSs`, `Quality`, `Feature`, `BioMaterial`, `ManufactureLIMS_IdentifierLIMS`, `BioMaterialPlateIdentifier`, `BioMaterialPlateRow`, `BioMaterialPlateCol`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `manufacturelims` (`WID`, `DataSetWID`, `MAGEClass`, `ArrayManufacture_FeatureLIMSs`, `Quality`, `Feature`, `BioMaterial`, `ManufactureLIMS_IdentifierLIMS`, `BioMaterialPlateIdentifier`, `BioMaterialPlateRow`, `BioMaterialPlateCol`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `manufacturelims` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `manufacturelims` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `ArrayManufacture_FeatureLIMSs`='{3}', `Quality`='{4}', `Feature`='{5}', `BioMaterial`='{6}', `ManufactureLIMS_IdentifierLIMS`='{7}', `BioMaterialPlateIdentifier`='{8}', `BioMaterialPlateRow`='{9}', `BioMaterialPlateCol`='{10}' WHERE `WID` = '{11}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `manufacturelims` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `manufacturelims` (`WID`, `DataSetWID`, `MAGEClass`, `ArrayManufacture_FeatureLIMSs`, `Quality`, `Feature`, `BioMaterial`, `ManufactureLIMS_IdentifierLIMS`, `BioMaterialPlateIdentifier`, `BioMaterialPlateRow`, `BioMaterialPlateCol`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, ArrayManufacture_FeatureLIMSs, Quality, Feature, BioMaterial, ManufactureLIMS_IdentifierLIMS, BioMaterialPlateIdentifier, BioMaterialPlateRow, BioMaterialPlateCol)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{ArrayManufacture_FeatureLIMSs}', '{Quality}', '{Feature}', '{BioMaterial}', '{ManufactureLIMS_IdentifierLIMS}', '{BioMaterialPlateIdentifier}', '{BioMaterialPlateRow}', '{BioMaterialPlateCol}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `manufacturelims` (`WID`, `DataSetWID`, `MAGEClass`, `ArrayManufacture_FeatureLIMSs`, `Quality`, `Feature`, `BioMaterial`, `ManufactureLIMS_IdentifierLIMS`, `BioMaterialPlateIdentifier`, `BioMaterialPlateRow`, `BioMaterialPlateCol`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, ArrayManufacture_FeatureLIMSs, Quality, Feature, BioMaterial, ManufactureLIMS_IdentifierLIMS, BioMaterialPlateIdentifier, BioMaterialPlateRow, BioMaterialPlateCol)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `manufacturelims` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `ArrayManufacture_FeatureLIMSs`='{3}', `Quality`='{4}', `Feature`='{5}', `BioMaterial`='{6}', `ManufactureLIMS_IdentifierLIMS`='{7}', `BioMaterialPlateIdentifier`='{8}', `BioMaterialPlateRow`='{9}', `BioMaterialPlateCol`='{10}' WHERE `WID` = '{11}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, ArrayManufacture_FeatureLIMSs, Quality, Feature, BioMaterial, ManufactureLIMS_IdentifierLIMS, BioMaterialPlateIdentifier, BioMaterialPlateRow, BioMaterialPlateCol, WID)
    End Function
#End Region
End Class


End Namespace
