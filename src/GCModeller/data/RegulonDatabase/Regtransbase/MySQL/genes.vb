REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 10:54:58 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `genes`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `genes` (
'''   `gene_guid` int(11) NOT NULL DEFAULT '0',
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(50) DEFAULT NULL,
'''   `fl_real_name` int(1) DEFAULT NULL,
'''   `genome_guid` int(11) DEFAULT NULL,
'''   `location` varchar(50) DEFAULT NULL,
'''   `ref_bank1` varchar(255) DEFAULT NULL,
'''   `ref_bank2` varchar(255) DEFAULT NULL,
'''   `ref_bank3` varchar(255) DEFAULT NULL,
'''   `ref_bank4` varchar(255) DEFAULT NULL,
'''   `signature` text,
'''   `metabol_path` varchar(100) DEFAULT NULL,
'''   `ferment_num` varchar(20) DEFAULT NULL,
'''   `gene_function` varchar(100) DEFAULT NULL,
'''   `descript` blob,
'''   `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`gene_guid`),
'''   KEY `FK_genes-pkg_guid` (`pkg_guid`),
'''   KEY `FK_genes-art_guid` (`art_guid`),
'''   KEY `FK_genes-genome_guid` (`genome_guid`),
'''   CONSTRAINT `FK_genes-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_genes-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
'''   CONSTRAINT `FK_genes-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("genes", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `genes` (
  `gene_guid` int(11) NOT NULL DEFAULT '0',
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `fl_real_name` int(1) DEFAULT NULL,
  `genome_guid` int(11) DEFAULT NULL,
  `location` varchar(50) DEFAULT NULL,
  `ref_bank1` varchar(255) DEFAULT NULL,
  `ref_bank2` varchar(255) DEFAULT NULL,
  `ref_bank3` varchar(255) DEFAULT NULL,
  `ref_bank4` varchar(255) DEFAULT NULL,
  `signature` text,
  `metabol_path` varchar(100) DEFAULT NULL,
  `ferment_num` varchar(20) DEFAULT NULL,
  `gene_function` varchar(100) DEFAULT NULL,
  `descript` blob,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`gene_guid`),
  KEY `FK_genes-pkg_guid` (`pkg_guid`),
  KEY `FK_genes-art_guid` (`art_guid`),
  KEY `FK_genes-genome_guid` (`genome_guid`),
  CONSTRAINT `FK_genes-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_genes-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
  CONSTRAINT `FK_genes-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class genes: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gene_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property gene_guid As Long
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property art_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "50")> Public Property name As String
    <DatabaseField("fl_real_name"), DataType(MySqlDbType.Int64, "1")> Public Property fl_real_name As Long
    <DatabaseField("genome_guid"), DataType(MySqlDbType.Int64, "11")> Public Property genome_guid As Long
    <DatabaseField("location"), DataType(MySqlDbType.VarChar, "50")> Public Property location As String
    <DatabaseField("ref_bank1"), DataType(MySqlDbType.VarChar, "255")> Public Property ref_bank1 As String
    <DatabaseField("ref_bank2"), DataType(MySqlDbType.VarChar, "255")> Public Property ref_bank2 As String
    <DatabaseField("ref_bank3"), DataType(MySqlDbType.VarChar, "255")> Public Property ref_bank3 As String
    <DatabaseField("ref_bank4"), DataType(MySqlDbType.VarChar, "255")> Public Property ref_bank4 As String
    <DatabaseField("signature"), DataType(MySqlDbType.Text)> Public Property signature As String
    <DatabaseField("metabol_path"), DataType(MySqlDbType.VarChar, "100")> Public Property metabol_path As String
    <DatabaseField("ferment_num"), DataType(MySqlDbType.VarChar, "20")> Public Property ferment_num As String
    <DatabaseField("gene_function"), DataType(MySqlDbType.VarChar, "100")> Public Property gene_function As String
    <DatabaseField("descript"), DataType(MySqlDbType.Blob)> Public Property descript As Byte()
    <DatabaseField("last_update"), NotNull, DataType(MySqlDbType.DateTime)> Public Property last_update As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `genes` (`gene_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `location`, `ref_bank1`, `ref_bank2`, `ref_bank3`, `ref_bank4`, `signature`, `metabol_path`, `ferment_num`, `gene_function`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `genes` (`gene_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `location`, `ref_bank1`, `ref_bank2`, `ref_bank3`, `ref_bank4`, `signature`, `metabol_path`, `ferment_num`, `gene_function`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `genes` WHERE `gene_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `genes` SET `gene_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `location`='{6}', `ref_bank1`='{7}', `ref_bank2`='{8}', `ref_bank3`='{9}', `ref_bank4`='{10}', `signature`='{11}', `metabol_path`='{12}', `ferment_num`='{13}', `gene_function`='{14}', `descript`='{15}', `last_update`='{16}' WHERE `gene_guid` = '{17}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `genes` WHERE `gene_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, gene_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `genes` (`gene_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `location`, `ref_bank1`, `ref_bank2`, `ref_bank3`, `ref_bank4`, `signature`, `metabol_path`, `ferment_num`, `gene_function`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gene_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, location, ref_bank1, ref_bank2, ref_bank3, ref_bank4, signature, metabol_path, ferment_num, gene_function, descript, DataType.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gene_guid}', '{pkg_guid}', '{art_guid}', '{name}', '{fl_real_name}', '{genome_guid}', '{location}', '{ref_bank1}', '{ref_bank2}', '{ref_bank3}', '{ref_bank4}', '{signature}', '{metabol_path}', '{ferment_num}', '{gene_function}', '{descript}', '{last_update}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `genes` (`gene_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `location`, `ref_bank1`, `ref_bank2`, `ref_bank3`, `ref_bank4`, `signature`, `metabol_path`, `ferment_num`, `gene_function`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gene_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, location, ref_bank1, ref_bank2, ref_bank3, ref_bank4, signature, metabol_path, ferment_num, gene_function, descript, DataType.ToMySqlDateTimeString(last_update))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `genes` SET `gene_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `location`='{6}', `ref_bank1`='{7}', `ref_bank2`='{8}', `ref_bank3`='{9}', `ref_bank4`='{10}', `signature`='{11}', `metabol_path`='{12}', `ferment_num`='{13}', `gene_function`='{14}', `descript`='{15}', `last_update`='{16}' WHERE `gene_guid` = '{17}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, gene_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, location, ref_bank1, ref_bank2, ref_bank3, ref_bank4, signature, metabol_path, ferment_num, gene_function, descript, DataType.ToMySqlDateTimeString(last_update), gene_guid)
    End Function
#End Region
End Class


End Namespace
