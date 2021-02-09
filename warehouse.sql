-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: warehouse
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `warehouse`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `warehouse` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `warehouse`;

--
-- Table structure for table `future_deliveries`
--

DROP TABLE IF EXISTS `future_deliveries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `future_deliveries` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_production` int NOT NULL,
  `id_provider` int NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `future_deliveries_fk1` (`id_production`),
  KEY `future_deliveries_fk2` (`id_provider`),
  CONSTRAINT `future_deliveries_fk1` FOREIGN KEY (`id_production`) REFERENCES `production` (`id`),
  CONSTRAINT `future_deliveries_fk2` FOREIGN KEY (`id_provider`) REFERENCES `provider` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci PACK_KEYS=0;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `future_deliveries`
--

LOCK TABLES `future_deliveries` WRITE;
/*!40000 ALTER TABLE `future_deliveries` DISABLE KEYS */;
/*!40000 ALTER TABLE `future_deliveries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production`
--

DROP TABLE IF EXISTS `production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `id_production_type` int NOT NULL,
  `id_unit` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Relationship3` (`id_production_type`),
  KEY `IX_Relationship4` (`id_unit`),
  CONSTRAINT `production_type_production` FOREIGN KEY (`id_production_type`) REFERENCES `production_type` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `unit_production` FOREIGN KEY (`id_unit`) REFERENCES `unit` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production`
--

LOCK TABLES `production` WRITE;
/*!40000 ALTER TABLE `production` DISABLE KEYS */;
INSERT INTO `production` VALUES (1,'Стиральный порошок',49.50,2,1),(2,'Жидкость для мытья посуды',56.80,2,1),(3,'Универсальное чистящее средство',73.00,2,1),(5,'Губки ',5.50,2,1),(6,'Мусорные пакеты',1.50,2,1),(7,'Хозяйственные перчатки',15.60,2,1),(8,'Туалетная бумага',3.45,2,1),(9,'Салфетки ',0.15,2,1),(10,'Порошок или жидкость для промывания труб',109.60,2,1),(11,'Жидкое мыло',35.50,2,1),(12,'Мыло хозяйственное',4.10,2,1),(13,'Швабра',150.00,2,1),(14,'Веники',126.00,2,1),(15,'Ведро',209.00,2,1),(16,'Картофель',19.89,3,2),(17,'Капуста',26.70,3,2),(18,'Морковь',18.30,3,2),(19,'Помидоры',57.50,3,2),(20,'Огурцы',46.70,3,2),(21,'Лук',8.18,3,2),(22,'Свекла',19.20,3,2),(23,'Зелень',56.20,3,2),(24,'Яблоки',48.40,4,2),(25,'Бананы',56.70,4,2),(26,'Апельсины',51.50,4,2),(27,'Лимоны',34.50,4,2),(28,'Сливочное масло',860.00,5,2),(29,'Кефир',26.80,5,3),(30,'Молоко',32.00,5,3),(31,'Сметана',670.00,5,3),(32,'Творог',260.00,5,2),(33,'Сыр твердый',389.10,5,2),(34,'Сыр плавленый',290.00,5,2),(38,'Мясной набор для супа (курица. свинина)',189.11,6,2),(39,'Окорочка (бедрышки)',157.00,6,2),(40,'Свинина',216.00,6,2),(41,'Говядина',268.40,6,2),(42,'Минтай рыба',89.00,6,2),(43,'Фрикадельки',198.90,6,2),(44,'Котлеты',201.00,6,2),(45,'Шампиньоны свежие ',211.00,8,2),(46,'Тесто слоеное',89.11,8,2),(47,'Макароны',25.05,7,2),(48,'Спагетти',45.10,7,2),(49,'Гречка',68.00,7,2),(50,'Перловка',36.00,7,2),(51,'Рис',87.00,7,2),(52,'Геркулес',36.00,7,2),(53,'Кукурузная крупа',38.00,7,2),(54,'Горох',36.90,7,2),(55,'Томат',38.00,8,2),(56,'Мёд',360.00,8,3),(57,'Растительное масло',67.00,8,1),(58,'Яйца',4.50,8,1),(59,'Уксус',35.60,8,1),(60,'Маргарин',57.00,8,1),(61,'Мука',38.00,8,2),(62,'Дрожжи',51.00,8,1),(63,'Сахар',28.00,8,1),(64,'Соль',6.50,8,1),(65,'Сода',12.60,8,1),(66,'Лавровый лист',34.50,8,6),(67,'Какао',58.00,8,1),(68,'Чай',34.00,8,1);
/*!40000 ALTER TABLE `production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production_type`
--

DROP TABLE IF EXISTS `production_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production_type` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_type`
--

LOCK TABLES `production_type` WRITE;
/*!40000 ALTER TABLE `production_type` DISABLE KEYS */;
INSERT INTO `production_type` VALUES (2,'Хозяйственные'),(3,'Овощи'),(4,'Фрукты'),(5,'Молочные продукты'),(6,'Мясные/Рыбные продукты'),(7,'Гарнир'),(8,'Другие'),(9,'Канцтовары');
/*!40000 ALTER TABLE `production_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provider`
--

DROP TABLE IF EXISTS `provider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `provider` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `phone` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `address` varchar(250) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provider`
--

LOCK TABLES `provider` WRITE;
/*!40000 ALTER TABLE `provider` DISABLE KEYS */;
INSERT INTO `provider` VALUES (1,'ИП Власов К. М.','8 (904) 329-01-02','ул. Нижняя, д.6'),(3,'ООО Маяк','',''),(4,'Домашние продукты, ИП Краснова С. О.','89047821983',''),(5,'Все для дома, ИП Сергиевский С. М.','','');
/*!40000 ALTER TABLE `provider` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(25) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (1,'шт.'),(2,'кг.'),(3,'л.'),(4,'м.'),(6,'гр.'),(7,'см.');
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse`
--

DROP TABLE IF EXISTS `warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `warehouse` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_production` int NOT NULL,
  `id_waybill` int NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `shelf_life` datetime DEFAULT NULL,
  `is_defective` smallint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Relationship6` (`id_waybill`),
  KEY `IX_Relationship8` (`id_production`),
  CONSTRAINT `production_warehouse` FOREIGN KEY (`id_production`) REFERENCES `production` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `waybill_warehouse` FOREIGN KEY (`id_waybill`) REFERENCES `waybill` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse`
--

LOCK TABLES `warehouse` WRITE;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
INSERT INTO `warehouse` VALUES (2,30,1,55.00,NULL,0),(3,29,1,12.00,NULL,0),(4,34,1,12.60,NULL,0),(5,34,1,5.00,NULL,0),(8,40,5,10.00,'2020-05-06 00:00:00',0),(9,41,5,5.00,'2020-05-13 00:00:00',0),(10,44,5,10.00,'2020-05-15 00:00:00',0),(12,52,3,10.00,'2021-04-28 00:00:00',0),(13,29,3,5.00,'2020-07-28 00:00:00',0),(14,15,6,12.00,NULL,0),(15,14,6,5.00,NULL,1);
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `waybill`
--

DROP TABLE IF EXISTS `waybill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `waybill` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `id_provider` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Relationship5` (`id_provider`),
  CONSTRAINT `provider_waybill` FOREIGN KEY (`id_provider`) REFERENCES `provider` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `waybill`
--

LOCK TABLES `waybill` WRITE;
/*!40000 ALTER TABLE `waybill` DISABLE KEYS */;
INSERT INTO `waybill` VALUES (1,'2020-04-27 00:00:00',3),(3,'2020-04-28 00:00:00',1),(5,'2020-04-29 00:00:00',4),(6,'2020-05-20 00:00:00',5);
/*!40000 ALTER TABLE `waybill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'warehouse'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-10  9:24:57
