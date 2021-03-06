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
''' DROP TABLE IF EXISTS `reactionlikeevent_2_entityonothercell`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reactionlikeevent_2_entityonothercell` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell_rank` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `entityOnOtherCell` (`entityOnOtherCell`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reactionlikeevent_2_entityonothercell", Database:="gk_current", SchemaSQL:="
CREATE TABLE `reactionlikeevent_2_entityonothercell` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell_rank` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `entityOnOtherCell` (`entityOnOtherCell`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class reactionlikeevent_2_entityonothercell: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("entityOnOtherCell_rank"), DataType(MySqlDbType.Int64, "10")> Public Property entityOnOtherCell_rank As Long
    <DatabaseField("entityOnOtherCell"), DataType(MySqlDbType.Int64, "10")> Public Property entityOnOtherCell As Long
    <DatabaseField("entityOnOtherCell_class"), DataType(MySqlDbType.VarChar, "64")> Public Property entityOnOtherCell_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reactionlikeevent_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reactionlikeevent_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reactionlikeevent_2_entityonothercell` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reactionlikeevent_2_entityonothercell` SET `DB_ID`='{0}', `entityOnOtherCell_rank`='{1}', `entityOnOtherCell`='{2}', `entityOnOtherCell_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reactionlikeevent_2_entityonothercell` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reactionlikeevent_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{entityOnOtherCell_rank}', '{entityOnOtherCell}', '{entityOnOtherCell_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reactionlikeevent_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reactionlikeevent_2_entityonothercell` SET `DB_ID`='{0}', `entityOnOtherCell_rank`='{1}', `entityOnOtherCell`='{2}', `entityOnOtherCell_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
