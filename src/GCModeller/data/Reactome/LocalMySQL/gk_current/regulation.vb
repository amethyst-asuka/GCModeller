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
''' DROP TABLE IF EXISTS `regulation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulation` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `authored` int(10) unsigned DEFAULT NULL,
'''   `authored_class` varchar(64) DEFAULT NULL,
'''   `regulatedEntity` int(10) unsigned DEFAULT NULL,
'''   `regulatedEntity_class` varchar(64) DEFAULT NULL,
'''   `regulationType` int(10) unsigned DEFAULT NULL,
'''   `regulationType_class` varchar(64) DEFAULT NULL,
'''   `regulator` int(10) unsigned DEFAULT NULL,
'''   `regulator_class` varchar(64) DEFAULT NULL,
'''   `releaseDate` date DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `authored` (`authored`),
'''   KEY `regulatedEntity` (`regulatedEntity`),
'''   KEY `regulationType` (`regulationType`),
'''   KEY `regulator` (`regulator`),
'''   KEY `releaseDate` (`releaseDate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulation", Database:="gk_current", SchemaSQL:="
CREATE TABLE `regulation` (
  `DB_ID` int(10) unsigned NOT NULL,
  `authored` int(10) unsigned DEFAULT NULL,
  `authored_class` varchar(64) DEFAULT NULL,
  `regulatedEntity` int(10) unsigned DEFAULT NULL,
  `regulatedEntity_class` varchar(64) DEFAULT NULL,
  `regulationType` int(10) unsigned DEFAULT NULL,
  `regulationType_class` varchar(64) DEFAULT NULL,
  `regulator` int(10) unsigned DEFAULT NULL,
  `regulator_class` varchar(64) DEFAULT NULL,
  `releaseDate` date DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `authored` (`authored`),
  KEY `regulatedEntity` (`regulatedEntity`),
  KEY `regulationType` (`regulationType`),
  KEY `regulator` (`regulator`),
  KEY `releaseDate` (`releaseDate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class regulation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("authored"), DataType(MySqlDbType.Int64, "10")> Public Property authored As Long
    <DatabaseField("authored_class"), DataType(MySqlDbType.VarChar, "64")> Public Property authored_class As String
    <DatabaseField("regulatedEntity"), DataType(MySqlDbType.Int64, "10")> Public Property regulatedEntity As Long
    <DatabaseField("regulatedEntity_class"), DataType(MySqlDbType.VarChar, "64")> Public Property regulatedEntity_class As String
    <DatabaseField("regulationType"), DataType(MySqlDbType.Int64, "10")> Public Property regulationType As Long
    <DatabaseField("regulationType_class"), DataType(MySqlDbType.VarChar, "64")> Public Property regulationType_class As String
    <DatabaseField("regulator"), DataType(MySqlDbType.Int64, "10")> Public Property regulator As Long
    <DatabaseField("regulator_class"), DataType(MySqlDbType.VarChar, "64")> Public Property regulator_class As String
    <DatabaseField("releaseDate"), DataType(MySqlDbType.DateTime)> Public Property releaseDate As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulation` (`DB_ID`, `authored`, `authored_class`, `regulatedEntity`, `regulatedEntity_class`, `regulationType`, `regulationType_class`, `regulator`, `regulator_class`, `releaseDate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulation` (`DB_ID`, `authored`, `authored_class`, `regulatedEntity`, `regulatedEntity_class`, `regulationType`, `regulationType_class`, `regulator`, `regulator_class`, `releaseDate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulation` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulation` SET `DB_ID`='{0}', `authored`='{1}', `authored_class`='{2}', `regulatedEntity`='{3}', `regulatedEntity_class`='{4}', `regulationType`='{5}', `regulationType_class`='{6}', `regulator`='{7}', `regulator_class`='{8}', `releaseDate`='{9}' WHERE `DB_ID` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulation` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulation` (`DB_ID`, `authored`, `authored_class`, `regulatedEntity`, `regulatedEntity_class`, `regulationType`, `regulationType_class`, `regulator`, `regulator_class`, `releaseDate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, authored, authored_class, regulatedEntity, regulatedEntity_class, regulationType, regulationType_class, regulator, regulator_class, DataType.ToMySqlDateTimeString(releaseDate))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{authored}', '{authored_class}', '{regulatedEntity}', '{regulatedEntity_class}', '{regulationType}', '{regulationType_class}', '{regulator}', '{regulator_class}', '{releaseDate}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulation` (`DB_ID`, `authored`, `authored_class`, `regulatedEntity`, `regulatedEntity_class`, `regulationType`, `regulationType_class`, `regulator`, `regulator_class`, `releaseDate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, authored, authored_class, regulatedEntity, regulatedEntity_class, regulationType, regulationType_class, regulator, regulator_class, DataType.ToMySqlDateTimeString(releaseDate))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulation` SET `DB_ID`='{0}', `authored`='{1}', `authored_class`='{2}', `regulatedEntity`='{3}', `regulatedEntity_class`='{4}', `regulationType`='{5}', `regulationType_class`='{6}', `regulator`='{7}', `regulator_class`='{8}', `releaseDate`='{9}' WHERE `DB_ID` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, authored, authored_class, regulatedEntity, regulatedEntity_class, regulationType, regulationType_class, regulator, regulator_class, DataType.ToMySqlDateTimeString(releaseDate), DB_ID)
    End Function
#End Region
End Class


End Namespace
