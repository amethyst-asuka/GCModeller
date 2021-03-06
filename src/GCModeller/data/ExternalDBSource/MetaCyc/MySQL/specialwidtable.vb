'REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
'REM  MYSQL Schema Mapper
'REM      for Microsoft VisualBasic.NET 1.0.0.0

'REM  Dump @3/29/2017 8:48:56 PM


'Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

'Namespace MetaCyc.MySQL

'    ''' <summary>
'    ''' ```SQL
'    ''' 
'    ''' --
'    ''' 
'    ''' DROP TABLE IF EXISTS `specialwidtable`;
'    ''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
'    ''' /*!40101 SET character_set_client = utf8 */;
'    ''' CREATE TABLE `specialwidtable` (
'    '''   `PreviousWID` bigint(20) NOT NULL AUTO_INCREMENT,
'    '''   PRIMARY KEY (`PreviousWID`)
'    ''' ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
'    ''' /*!40101 SET character_set_client = @saved_cs_client */;
'    ''' 
'    ''' --
'    ''' 
'    ''' ```
'    ''' </summary>
'    ''' <remarks></remarks>
'    <Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("specialwidtable", Database:="warehouse", SchemaSQL:="
'CREATE TABLE `specialwidtable` (
'  `PreviousWID` bigint(20) NOT NULL AUTO_INCREMENT,
'  PRIMARY KEY (`PreviousWID`)
') ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;")>
'    Public Class specialwidtable : Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
'#Region "Public Property Mapping To Database Fields"
'        <DatabaseField("PreviousWID"), PrimaryKey, AutoIncrement, NotNULL, DataType(MySqlDbType.Int64, "20")> Public Property PreviousWID As Long
'#End Region
'#Region "Public SQL Interface"
'#Region "Interface SQL"
'        Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `specialwidtable` () VALUES ('{0}');</SQL>
'        Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `specialwidtable` () VALUES ('{0}');</SQL>
'        Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `specialwidtable` WHERE `PreviousWID` = '{0}';</SQL>
'        Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `specialwidtable` SET `PreviousWID`='{0}' WHERE `PreviousWID` = '{1}';</SQL>
'#End Region
'        ''' <summary>
'        ''' ```SQL
'        ''' DELETE FROM `specialwidtable` WHERE `PreviousWID` = '{0}';
'        ''' ```
'        ''' </summary>
'        Public Overrides Function GetDeleteSQL() As String
'            Return String.Format(DELETE_SQL, PreviousWID)
'        End Function
'        ''' <summary>
'        ''' ```SQL
'        ''' INSERT INTO `specialwidtable` () VALUES ('{0}');
'        ''' ```
'        ''' </summary>
'        Public Overrides Function GetInsertSQL() As String
'            Return String.Format(INSERT_SQL, )
'        End Function

'        ''' <summary>
'        ''' <see cref="GetInsertSQL"/>
'        ''' </summary>
'        Public Overrides Function GetDumpInsertValue() As String
'            Return $"('{0}')"
'        End Function


'        ''' <summary>
'        ''' ```SQL
'        ''' REPLACE INTO `specialwidtable` () VALUES ('{0}');
'        ''' ```
'        ''' </summary>
'        Public Overrides Function GetReplaceSQL() As String
'            Return String.Format(REPLACE_SQL, )
'        End Function
'        ''' <summary>
'        ''' ```SQL
'        ''' UPDATE `specialwidtable` SET `PreviousWID`='{0}' WHERE `PreviousWID` = '{1}';
'        ''' ```
'        ''' </summary>
'        Public Overrides Function GetUpdateSQL() As String
'            Return String.Format(UPDATE_SQL, PreviousWID, PreviousWID)
'        End Function
'#End Region
'    End Class


'End Namespace
