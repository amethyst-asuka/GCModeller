REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:28 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `referencesequence`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referencesequence` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `checksum` text,
'''   `isSequenceChanged` text,
'''   `sequenceLength` int(10) DEFAULT NULL,
'''   `species` int(10) unsigned DEFAULT NULL,
'''   `species_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `sequenceLength` (`sequenceLength`),
'''   KEY `species` (`species`),
'''   FULLTEXT KEY `checksum` (`checksum`),
'''   FULLTEXT KEY `isSequenceChanged` (`isSequenceChanged`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referencesequence", Database:="gk_current", SchemaSQL:="
CREATE TABLE `referencesequence` (
  `DB_ID` int(10) unsigned NOT NULL,
  `checksum` text,
  `isSequenceChanged` text,
  `sequenceLength` int(10) DEFAULT NULL,
  `species` int(10) unsigned DEFAULT NULL,
  `species_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `sequenceLength` (`sequenceLength`),
  KEY `species` (`species`),
  FULLTEXT KEY `checksum` (`checksum`),
  FULLTEXT KEY `isSequenceChanged` (`isSequenceChanged`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class referencesequence: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("checksum"), DataType(MySqlDbType.Text)> Public Property checksum As String
    <DatabaseField("isSequenceChanged"), DataType(MySqlDbType.Text)> Public Property isSequenceChanged As String
    <DatabaseField("sequenceLength"), DataType(MySqlDbType.Int64, "10")> Public Property sequenceLength As Long
    <DatabaseField("species"), DataType(MySqlDbType.Int64, "10")> Public Property species As Long
    <DatabaseField("species_class"), DataType(MySqlDbType.VarChar, "64")> Public Property species_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `referencesequence` (`DB_ID`, `checksum`, `isSequenceChanged`, `sequenceLength`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `referencesequence` (`DB_ID`, `checksum`, `isSequenceChanged`, `sequenceLength`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `referencesequence` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `referencesequence` SET `DB_ID`='{0}', `checksum`='{1}', `isSequenceChanged`='{2}', `sequenceLength`='{3}', `species`='{4}', `species_class`='{5}' WHERE `DB_ID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `referencesequence` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `referencesequence` (`DB_ID`, `checksum`, `isSequenceChanged`, `sequenceLength`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, checksum, isSequenceChanged, sequenceLength, species, species_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{checksum}', '{isSequenceChanged}', '{sequenceLength}', '{species}', '{species_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `referencesequence` (`DB_ID`, `checksum`, `isSequenceChanged`, `sequenceLength`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, checksum, isSequenceChanged, sequenceLength, species, species_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `referencesequence` SET `DB_ID`='{0}', `checksum`='{1}', `isSequenceChanged`='{2}', `sequenceLength`='{3}', `species`='{4}', `species_class`='{5}' WHERE `DB_ID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, checksum, isSequenceChanged, sequenceLength, species, species_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
