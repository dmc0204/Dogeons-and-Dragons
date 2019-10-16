-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 35.231.30.58    Database: dnd
-- ------------------------------------------------------
-- Server version	5.7.14-google-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '17b76ade-e259-11e9-b339-42010a8e0093:1-1267884';

--
-- Table structure for table `BONES`
--

DROP TABLE IF EXISTS `BONES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `BONES` (
  `BONE_ID` int(42) NOT NULL AUTO_INCREMENT,
  `COMMON_BONES` int(42) NOT NULL,
  `PREMIUM_BONES` int(42) NOT NULL,
  `PLAYER_ID` int(42) DEFAULT NULL,
  PRIMARY KEY (`BONE_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `BONES_ibfk_1` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BONES`
--

LOCK TABLES `BONES` WRITE;
/*!40000 ALTER TABLE `BONES` DISABLE KEYS */;
/*!40000 ALTER TABLE `BONES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CHEWABLES`
--

DROP TABLE IF EXISTS `CHEWABLES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CHEWABLES` (
  `CHEWABLE_ID` int(42) NOT NULL AUTO_INCREMENT,
  `AFFECT_VALUE` int(42) NOT NULL,
  `CHEW_IMAGE` varchar(42) NOT NULL,
  `CHEWABLE_NAME` varchar(255) NOT NULL,
  PRIMARY KEY (`CHEWABLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CHEWABLES`
--

LOCK TABLES `CHEWABLES` WRITE;
/*!40000 ALTER TABLE `CHEWABLES` DISABLE KEYS */;
/*!40000 ALTER TABLE `CHEWABLES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EQUIPMENT`
--

DROP TABLE IF EXISTS `EQUIPMENT`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EQUIPMENT` (
  `EQUIPMENT_ID` int(42) NOT NULL AUTO_INCREMENT,
  `AFFECT_VALUE` int(42) NOT NULL,
  `TYPE` varchar(255) NOT NULL,
  `EQUIP_IMAGE` varchar(42) NOT NULL,
  `EQUIPMENT_NAME` varchar(255) NOT NULL,
  PRIMARY KEY (`EQUIPMENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EQUIPMENT`
--

LOCK TABLES `EQUIPMENT` WRITE;
/*!40000 ALTER TABLE `EQUIPMENT` DISABLE KEYS */;
/*!40000 ALTER TABLE `EQUIPMENT` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EQ_CHEW`
--

DROP TABLE IF EXISTS `EQ_CHEW`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EQ_CHEW` (
  `EQ_CHEW_ID` int(42) NOT NULL AUTO_INCREMENT,
  `CHEWABLE_ID` int(42) NOT NULL,
  `QUANTITY` int(42) NOT NULL,
  `PLAYER_ID` int(42) NOT NULL,
  PRIMARY KEY (`EQ_CHEW_ID`),
  KEY `CHEWABLE_ID` (`CHEWABLE_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `EQ_CHEW_ibfk_1` FOREIGN KEY (`CHEWABLE_ID`) REFERENCES `CHEWABLES` (`CHEWABLE_ID`) ON DELETE CASCADE,
  CONSTRAINT `EQ_CHEW_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EQ_CHEW`
--

LOCK TABLES `EQ_CHEW` WRITE;
/*!40000 ALTER TABLE `EQ_CHEW` DISABLE KEYS */;
/*!40000 ALTER TABLE `EQ_CHEW` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EQ_EQUIP`
--

DROP TABLE IF EXISTS `EQ_EQUIP`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EQ_EQUIP` (
  `EQ_EQ_ID` int(42) NOT NULL AUTO_INCREMENT,
  `UNIT_ID` int(42) NOT NULL,
  `PLAYER_ID` int(42) NOT NULL,
  `EQUIPMENT_ID` int(42) NOT NULL,
  PRIMARY KEY (`EQ_EQ_ID`),
  KEY `EQUIPMENT_ID` (`EQUIPMENT_ID`),
  KEY `UNIT_ID` (`UNIT_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `EQ_EQUIP_ibfk_1` FOREIGN KEY (`EQUIPMENT_ID`) REFERENCES `EQUIPMENT` (`EQUIPMENT_ID`) ON DELETE CASCADE,
  CONSTRAINT `EQ_EQUIP_ibfk_2` FOREIGN KEY (`UNIT_ID`) REFERENCES `UNITS` (`UNIT_ID`) ON DELETE CASCADE,
  CONSTRAINT `EQ_EQUIP_ibfk_3` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EQ_EQUIP`
--

LOCK TABLES `EQ_EQUIP` WRITE;
/*!40000 ALTER TABLE `EQ_EQUIP` DISABLE KEYS */;
/*!40000 ALTER TABLE `EQ_EQUIP` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EQ_UNITS`
--

DROP TABLE IF EXISTS `EQ_UNITS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EQ_UNITS` (
  `EQ_UNITS_ID` int(42) NOT NULL AUTO_INCREMENT,
  `PLAYER_ID` int(42) DEFAULT NULL,
  `UNIT_ID` int(42) NOT NULL,
  PRIMARY KEY (`EQ_UNITS_ID`),
  KEY `UNIT_ID` (`UNIT_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `EQ_UNITS_ibfk_1` FOREIGN KEY (`UNIT_ID`) REFERENCES `UNITS` (`UNIT_ID`) ON DELETE CASCADE,
  CONSTRAINT `EQ_UNITS_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EQ_UNITS`
--

LOCK TABLES `EQ_UNITS` WRITE;
/*!40000 ALTER TABLE `EQ_UNITS` DISABLE KEYS */;
/*!40000 ALTER TABLE `EQ_UNITS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FLOORS`
--

DROP TABLE IF EXISTS `FLOORS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FLOORS` (
  `FLOOR_ID` int(42) NOT NULL AUTO_INCREMENT,
  `UNIT_ID` int(42) NOT NULL,
  `NUMBER` int(42) NOT NULL,
  `FLOOR_IMAGE` varchar(42) NOT NULL,
  PRIMARY KEY (`FLOOR_ID`),
  KEY `UNIT_ID` (`UNIT_ID`),
  CONSTRAINT `FLOORS_ibfk_1` FOREIGN KEY (`UNIT_ID`) REFERENCES `UNITS` (`UNIT_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FLOORS`
--

LOCK TABLES `FLOORS` WRITE;
/*!40000 ALTER TABLE `FLOORS` DISABLE KEYS */;
/*!40000 ALTER TABLE `FLOORS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `INV_CHEW`
--

DROP TABLE IF EXISTS `INV_CHEW`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `INV_CHEW` (
  `INV_CHEW_ID` int(42) NOT NULL AUTO_INCREMENT,
  `CHEWABLE_ID` int(42) NOT NULL,
  `QUANTITY` int(42) NOT NULL,
  `PLAYER_ID` int(42) NOT NULL,
  PRIMARY KEY (`INV_CHEW_ID`),
  KEY `CHEWABLE_ID` (`CHEWABLE_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `INV_CHEW_ibfk_1` FOREIGN KEY (`CHEWABLE_ID`) REFERENCES `CHEWABLES` (`CHEWABLE_ID`) ON DELETE CASCADE,
  CONSTRAINT `INV_CHEW_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `INV_CHEW`
--

LOCK TABLES `INV_CHEW` WRITE;
/*!40000 ALTER TABLE `INV_CHEW` DISABLE KEYS */;
/*!40000 ALTER TABLE `INV_CHEW` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `INV_EQUIP`
--

DROP TABLE IF EXISTS `INV_EQUIP`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `INV_EQUIP` (
  `INV_EQ_ID` int(42) NOT NULL AUTO_INCREMENT,
  `PLAYER_ID` int(42) NOT NULL,
  `EQUIPMENT_ID` int(42) NOT NULL,
  PRIMARY KEY (`INV_EQ_ID`),
  KEY `EQUIPMENT_ID` (`EQUIPMENT_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `INV_EQUIP_ibfk_1` FOREIGN KEY (`EQUIPMENT_ID`) REFERENCES `EQUIPMENT` (`EQUIPMENT_ID`) ON DELETE CASCADE,
  CONSTRAINT `INV_EQUIP_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `INV_EQUIP`
--

LOCK TABLES `INV_EQUIP` WRITE;
/*!40000 ALTER TABLE `INV_EQUIP` DISABLE KEYS */;
/*!40000 ALTER TABLE `INV_EQUIP` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `INV_UNITS`
--

DROP TABLE IF EXISTS `INV_UNITS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `INV_UNITS` (
  `INV_UNITS_ID` int(42) NOT NULL AUTO_INCREMENT,
  `PLAYER_ID` int(42) DEFAULT NULL,
  `UNIT_ID` int(42) NOT NULL,
  PRIMARY KEY (`INV_UNITS_ID`),
  KEY `UNIT_ID` (`UNIT_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `INV_UNITS_ibfk_1` FOREIGN KEY (`UNIT_ID`) REFERENCES `UNITS` (`UNIT_ID`) ON DELETE CASCADE,
  CONSTRAINT `INV_UNITS_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `INV_UNITS`
--

LOCK TABLES `INV_UNITS` WRITE;
/*!40000 ALTER TABLE `INV_UNITS` DISABLE KEYS */;
/*!40000 ALTER TABLE `INV_UNITS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PLAYERS`
--

DROP TABLE IF EXISTS `PLAYERS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PLAYERS` (
  `PLAYER_ID` int(42) NOT NULL AUTO_INCREMENT,
  `GOOGLE_ID` int(255) NOT NULL,
  `PLAYER_NAME` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`PLAYER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PLAYERS`
--

LOCK TABLES `PLAYERS` WRITE;
/*!40000 ALTER TABLE `PLAYERS` DISABLE KEYS */;
INSERT INTO `PLAYERS` VALUES (1,1234,'Test');
/*!40000 ALTER TABLE `PLAYERS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PROGRESS`
--

DROP TABLE IF EXISTS `PROGRESS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PROGRESS` (
  `PROGRESS_ID` int(42) NOT NULL AUTO_INCREMENT,
  `FLOOR_ID` int(42) NOT NULL,
  `PLAYER_ID` int(42) NOT NULL,
  `SCORE` int(42) NOT NULL,
  PRIMARY KEY (`PROGRESS_ID`),
  KEY `FLOOR_ID` (`FLOOR_ID`),
  KEY `PLAYER_ID` (`PLAYER_ID`),
  CONSTRAINT `PROGRESS_ibfk_1` FOREIGN KEY (`FLOOR_ID`) REFERENCES `FLOORS` (`FLOOR_ID`) ON DELETE CASCADE,
  CONSTRAINT `PROGRESS_ibfk_2` FOREIGN KEY (`PLAYER_ID`) REFERENCES `PLAYERS` (`PLAYER_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PROGRESS`
--

LOCK TABLES `PROGRESS` WRITE;
/*!40000 ALTER TABLE `PROGRESS` DISABLE KEYS */;
/*!40000 ALTER TABLE `PROGRESS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TUTORIALS`
--

DROP TABLE IF EXISTS `TUTORIALS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TUTORIALS` (
  `TUTORIAL_ID` int(42) NOT NULL AUTO_INCREMENT,
  `TUTORIAL` varchar(3000) DEFAULT NULL,
  `TITLE` varchar(255) NOT NULL,
  PRIMARY KEY (`TUTORIAL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TUTORIALS`
--

LOCK TABLES `TUTORIALS` WRITE;
/*!40000 ALTER TABLE `TUTORIALS` DISABLE KEYS */;
/*!40000 ALTER TABLE `TUTORIALS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UNITS`
--

DROP TABLE IF EXISTS `UNITS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UNITS` (
  `UNIT_ID` int(42) NOT NULL AUTO_INCREMENT,
  `TYPE` int(42) NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `HP` int(42) NOT NULL,
  `ATTACK` int(42) NOT NULL,
  `DEFENSE` int(42) NOT NULL,
  `UNIT_STORY` varchar(3000) DEFAULT NULL,
  `UNIT_IMAGE` varchar(42) NOT NULL,
  `SPEED` int(42) NOT NULL,
  PRIMARY KEY (`UNIT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UNITS`
--

LOCK TABLES `UNITS` WRITE;
/*!40000 ALTER TABLE `UNITS` DISABLE KEYS */;
/*!40000 ALTER TABLE `UNITS` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-13 16:00:23
