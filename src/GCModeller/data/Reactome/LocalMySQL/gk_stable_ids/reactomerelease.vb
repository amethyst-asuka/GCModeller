REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:31 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_stable_ids

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `reactomerelease`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reactomerelease` (
'''   `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
'''   `release_num` int(12) NOT NULL,
'''   `database_name` text NOT NULL,
'''   PRIMARY KEY (`DB_ID`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=869251 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reactomerelease", Database:="gk_stable_ids", SchemaSQL:="
CREATE TABLE `reactomerelease` (
  `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
  `release_num` int(12) NOT NULL,
  `database_name` text NOT NULL,
  PRIMARY KEY (`DB_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=869251 DEFAULT CHARSET=latin1;")>
Public Class reactomerelease: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "12")> Public Property DB_ID As Long
    <DatabaseField("release_num"), NotNull, DataType(MySqlDbType.Int64, "12")> Public Property release_num As Long
    <DatabaseField("database_name"), NotNull, DataType(MySqlDbType.Text)> Public Property database_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reactomerelease` (`release_num`, `database_name`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reactomerelease` (`release_num`, `database_name`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reactomerelease` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reactomerelease` SET `DB_ID`='{0}', `release_num`='{1}', `database_name`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reactomerelease` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reactomerelease` (`release_num`, `database_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, release_num, database_name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{release_num}', '{database_name}', '{2}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reactomerelease` (`release_num`, `database_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, release_num, database_name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reactomerelease` SET `DB_ID`='{0}', `release_num`='{1}', `database_name`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, release_num, database_name, DB_ID)
    End Function
#End Region
End Class


End Namespace
