REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `secondary_structure_image`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `secondary_structure_image` (
'''   `rfam_acc` varchar(7) NOT NULL,
'''   `type` enum('cons','dist','ent','fcbp','cov','disttruc','maxcm','norm','rchie','species','ss','rscape','rscape-cyk') DEFAULT NULL,
'''   `image` longblob,
'''   KEY `fk_secondary_structure_images_family1_idx` (`rfam_acc`),
'''   KEY `secondatStructureTypeIdx` (`type`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("secondary_structure_image", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `secondary_structure_image` (
  `rfam_acc` varchar(7) NOT NULL,
  `type` enum('cons','dist','ent','fcbp','cov','disttruc','maxcm','norm','rchie','species','ss','rscape','rscape-cyk') DEFAULT NULL,
  `image` longblob,
  KEY `fk_secondary_structure_images_family1_idx` (`rfam_acc`),
  KEY `secondatStructureTypeIdx` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class secondary_structure_image: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property rfam_acc As String
    <DatabaseField("type"), DataType(MySqlDbType.String)> Public Property type As String
    <DatabaseField("image"), DataType(MySqlDbType.Blob)> Public Property image As Byte()
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `secondary_structure_image` (`rfam_acc`, `type`, `image`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `secondary_structure_image` (`rfam_acc`, `type`, `image`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `secondary_structure_image` WHERE `rfam_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `secondary_structure_image` SET `rfam_acc`='{0}', `type`='{1}', `image`='{2}' WHERE `rfam_acc` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `secondary_structure_image` WHERE `rfam_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `secondary_structure_image` (`rfam_acc`, `type`, `image`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_acc, type, image)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{rfam_acc}', '{type}', '{image}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `secondary_structure_image` (`rfam_acc`, `type`, `image`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_acc, type, image)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `secondary_structure_image` SET `rfam_acc`='{0}', `type`='{1}', `image`='{2}' WHERE `rfam_acc` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_acc, type, image, rfam_acc)
    End Function
#End Region
End Class


End Namespace
