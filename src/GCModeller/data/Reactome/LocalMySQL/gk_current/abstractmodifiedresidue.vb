REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `abstractmodifiedresidue`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `abstractmodifiedresidue` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `referenceSequence` int(10) unsigned DEFAULT NULL,
'''   `referenceSequence_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `referenceSequence` (`referenceSequence`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("abstractmodifiedresidue", Database:="gk_current", SchemaSQL:="
CREATE TABLE `abstractmodifiedresidue` (
  `DB_ID` int(10) unsigned NOT NULL,
  `referenceSequence` int(10) unsigned DEFAULT NULL,
  `referenceSequence_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `referenceSequence` (`referenceSequence`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class abstractmodifiedresidue: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("referenceSequence"), DataType(MySqlDbType.Int64, "10")> Public Property referenceSequence As Long
    <DatabaseField("referenceSequence_class"), DataType(MySqlDbType.VarChar, "64")> Public Property referenceSequence_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `abstractmodifiedresidue` (`DB_ID`, `referenceSequence`, `referenceSequence_class`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `abstractmodifiedresidue` (`DB_ID`, `referenceSequence`, `referenceSequence_class`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `abstractmodifiedresidue` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `abstractmodifiedresidue` SET `DB_ID`='{0}', `referenceSequence`='{1}', `referenceSequence_class`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `abstractmodifiedresidue` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `abstractmodifiedresidue` (`DB_ID`, `referenceSequence`, `referenceSequence_class`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, referenceSequence, referenceSequence_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{referenceSequence}', '{referenceSequence_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `abstractmodifiedresidue` (`DB_ID`, `referenceSequence`, `referenceSequence_class`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, referenceSequence, referenceSequence_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `abstractmodifiedresidue` SET `DB_ID`='{0}', `referenceSequence`='{1}', `referenceSequence_class`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, referenceSequence, referenceSequence_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
