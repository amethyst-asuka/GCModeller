REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @5/26/2017 10:50:32 PM


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MaxMind.geolite

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `geolite_city`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `geolite_city` (
'''   `locID` int(11) NOT NULL,
'''   `country` varchar(8) NOT NULL,
'''   `region` varchar(45) DEFAULT NULL,
'''   `city` tinytext,
'''   `postalCode` varchar(45) DEFAULT NULL,
'''   `latitude` double DEFAULT NULL,
'''   `longitude` double DEFAULT NULL,
'''   `metroCode` varchar(45) DEFAULT NULL,
'''   `areaCode` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`locID`),
'''   UNIQUE KEY `locID_UNIQUE` (`locID`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'maxmind_geolite'
''' --
''' 
''' --
''' -- Dumping routines for database 'maxmind_geolite'
''' --
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2017-05-26 22:45:55
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("geolite_city", Database:="maxmind_geolite", SchemaSQL:="
CREATE TABLE `geolite_city` (
  `locID` int(11) NOT NULL,
  `country` varchar(8) NOT NULL,
  `region` varchar(45) DEFAULT NULL,
  `city` tinytext,
  `postalCode` varchar(45) DEFAULT NULL,
  `latitude` double DEFAULT NULL,
  `longitude` double DEFAULT NULL,
  `metroCode` varchar(45) DEFAULT NULL,
  `areaCode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`locID`),
  UNIQUE KEY `locID_UNIQUE` (`locID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class geolite_city: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("locID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="locID")> Public Property locID As Long
    <DatabaseField("country"), NotNull, DataType(MySqlDbType.VarChar, "8"), Column(Name:="country")> Public Property country As String
    <DatabaseField("region"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="region")> Public Property region As String
    <DatabaseField("city"), DataType(MySqlDbType.Text), Column(Name:="city")> Public Property city As String
    <DatabaseField("postalCode"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="postalCode")> Public Property postalCode As String
    <DatabaseField("latitude"), DataType(MySqlDbType.Double), Column(Name:="latitude")> Public Property latitude As Double
    <DatabaseField("longitude"), DataType(MySqlDbType.Double), Column(Name:="longitude")> Public Property longitude As Double
    <DatabaseField("metroCode"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="metroCode")> Public Property metroCode As String
    <DatabaseField("areaCode"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="areaCode")> Public Property areaCode As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `geolite_city` (`locID`, `country`, `region`, `city`, `postalCode`, `latitude`, `longitude`, `metroCode`, `areaCode`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `geolite_city` (`locID`, `country`, `region`, `city`, `postalCode`, `latitude`, `longitude`, `metroCode`, `areaCode`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `geolite_city` WHERE `locID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `geolite_city` SET `locID`='{0}', `country`='{1}', `region`='{2}', `city`='{3}', `postalCode`='{4}', `latitude`='{5}', `longitude`='{6}', `metroCode`='{7}', `areaCode`='{8}' WHERE `locID` = '{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `geolite_city` WHERE `locID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, locID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `geolite_city` (`locID`, `country`, `region`, `city`, `postalCode`, `latitude`, `longitude`, `metroCode`, `areaCode`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, locID, country, region, city, postalCode, latitude, longitude, metroCode, areaCode)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{locID}', '{country}', '{region}', '{city}', '{postalCode}', '{latitude}', '{longitude}', '{metroCode}', '{areaCode}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `geolite_city` (`locID`, `country`, `region`, `city`, `postalCode`, `latitude`, `longitude`, `metroCode`, `areaCode`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, locID, country, region, city, postalCode, latitude, longitude, metroCode, areaCode)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `geolite_city` SET `locID`='{0}', `country`='{1}', `region`='{2}', `city`='{3}', `postalCode`='{4}', `latitude`='{5}', `longitude`='{6}', `metroCode`='{7}', `areaCode`='{8}' WHERE `locID` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, locID, country, region, city, postalCode, latitude, longitude, metroCode, areaCode, locID)
    End Function
#End Region
Public Function Clone() As geolite_city
                  Return DirectCast(MyClass.MemberwiseClone, geolite_city)
              End Function
End Class


End Namespace
