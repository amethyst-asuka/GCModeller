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
''' DROP TABLE IF EXISTS `featuredimensionwidfeaturewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `featuredimensionwidfeaturewid` (
'''   `FeatureDimensionWID` bigint(20) NOT NULL,
'''   `FeatureWID` bigint(20) NOT NULL,
'''   KEY `FK_FeatureDimensionWIDFeatur1` (`FeatureDimensionWID`),
'''   KEY `FK_FeatureDimensionWIDFeatur2` (`FeatureWID`),
'''   CONSTRAINT `FK_FeatureDimensionWIDFeatur1` FOREIGN KEY (`FeatureDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FeatureDimensionWIDFeatur2` FOREIGN KEY (`FeatureWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("featuredimensionwidfeaturewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `featuredimensionwidfeaturewid` (
  `FeatureDimensionWID` bigint(20) NOT NULL,
  `FeatureWID` bigint(20) NOT NULL,
  KEY `FK_FeatureDimensionWIDFeatur1` (`FeatureDimensionWID`),
  KEY `FK_FeatureDimensionWIDFeatur2` (`FeatureWID`),
  CONSTRAINT `FK_FeatureDimensionWIDFeatur1` FOREIGN KEY (`FeatureDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FeatureDimensionWIDFeatur2` FOREIGN KEY (`FeatureWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class featuredimensionwidfeaturewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("FeatureDimensionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property FeatureDimensionWID As Long
    <DatabaseField("FeatureWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property FeatureWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `featuredimensionwidfeaturewid` (`FeatureDimensionWID`, `FeatureWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `featuredimensionwidfeaturewid` (`FeatureDimensionWID`, `FeatureWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `featuredimensionwidfeaturewid` WHERE `FeatureDimensionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `featuredimensionwidfeaturewid` SET `FeatureDimensionWID`='{0}', `FeatureWID`='{1}' WHERE `FeatureDimensionWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `featuredimensionwidfeaturewid` WHERE `FeatureDimensionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, FeatureDimensionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `featuredimensionwidfeaturewid` (`FeatureDimensionWID`, `FeatureWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, FeatureDimensionWID, FeatureWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{FeatureDimensionWID}', '{FeatureWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `featuredimensionwidfeaturewid` (`FeatureDimensionWID`, `FeatureWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, FeatureDimensionWID, FeatureWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `featuredimensionwidfeaturewid` SET `FeatureDimensionWID`='{0}', `FeatureWID`='{1}' WHERE `FeatureDimensionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, FeatureDimensionWID, FeatureWID, FeatureDimensionWID)
    End Function
#End Region
End Class


End Namespace
