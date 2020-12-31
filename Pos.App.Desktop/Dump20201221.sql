-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: pos
-- ------------------------------------------------------
-- Server version	8.0.21

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

--
-- Table structure for table `ps_ac_account`
--
CREATE DATABASE pos;

use pos;

DROP TABLE IF EXISTS `ps_ac_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_ac_account` (
  `accountId` varchar(100) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `active` tinyint DEFAULT NULL,
  `typeId` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`accountId`),
  KEY `typeId_idx` (`typeId`),
  CONSTRAINT `typeId` FOREIGN KEY (`typeId`) REFERENCES `ps_gp_accounttype` (`typeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_ac_account`
--

LOCK TABLES `ps_ac_account` WRITE;
/*!40000 ALTER TABLE `ps_ac_account` DISABLE KEYS */;
INSERT INTO `ps_ac_account` VALUES ('1','INCOME',1,'1'),('2','EXPENSE',1,'2');
/*!40000 ALTER TABLE `ps_ac_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_ac_accounttransaction`
--

DROP TABLE IF EXISTS `ps_ac_accounttransaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_ac_accounttransaction` (
  `transactionId` varchar(100) NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `accountId` varchar(100) DEFAULT NULL,
  `invoiceId` varchar(100) DEFAULT NULL,
  `amount` double DEFAULT NULL,
  PRIMARY KEY (`transactionId`),
  KEY `accountId_idx` (`accountId`),
  CONSTRAINT `accountId` FOREIGN KEY (`accountId`) REFERENCES `ps_ac_account` (`accountId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_ac_accounttransaction`
--

LOCK TABLES `ps_ac_accounttransaction` WRITE;
/*!40000 ALTER TABLE `ps_ac_accounttransaction` DISABLE KEYS */;
INSERT INTO `ps_ac_accounttransaction` VALUES ('1','','2020-12-17 12:00:48','1','1',9000),('2','','2020-12-17 12:05:57','1','1',9000),('3','','2020-12-17 12:06:58','1','2',9000),('4','','2020-12-21 15:35:37','1','3',9000),('5','','2020-12-21 16:28:25','1','4',22400),('6','','2020-12-21 16:56:05','2','13',6030000);
/*!40000 ALTER TABLE `ps_ac_accounttransaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_ap_appmenu`
--

DROP TABLE IF EXISTS `ps_ap_appmenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_ap_appmenu` (
  `menuId` int NOT NULL,
  `title` varchar(150) DEFAULT NULL,
  `routerLink` varchar(150) DEFAULT NULL,
  `active` int DEFAULT NULL,
  `moduleId` int NOT NULL,
  PRIMARY KEY (`menuId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_ap_appmenu`
--

LOCK TABLES `ps_ap_appmenu` WRITE;
/*!40000 ALTER TABLE `ps_ap_appmenu` DISABLE KEYS */;
INSERT INTO `ps_ap_appmenu` VALUES (1,'Product','prd',1,0),(2,'Product Registration','prd_reg',1,1),(3,'Product Directory','prd_dir',0,1),(4,'Product Category','prd_cat',1,1),(5,'Product Purchase','prd_purc',1,1),(6,'Product Sale','prd_sal',1,1),(11,'Customer','cus',1,0),(12,'Customer Registration','cus_reg',1,11),(13,'Customer History','cus_dir',1,11),(21,'Users','us',1,0),(22,'Users Registration','us_reg',1,21),(23,'Users Roles','us_rol',1,21),(24,'Users Permissions','us_pr',1,21),(31,'Stock','st',1,0),(32,'Stock History','st_dir',1,31),(40,'Vendor','vn',1,0),(41,'Vendor Registration','vn_reg',1,40),(42,'Vendor History','vn_his',1,40);
/*!40000 ALTER TABLE `ps_ap_appmenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_ap_tuple_details`
--

DROP TABLE IF EXISTS `ps_ap_tuple_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_ap_tuple_details` (
  `tupleId` varchar(100) NOT NULL,
  `name` varchar(150) DEFAULT NULL,
  `count` double DEFAULT NULL,
  PRIMARY KEY (`tupleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_ap_tuple_details`
--

LOCK TABLES `ps_ap_tuple_details` WRITE;
/*!40000 ALTER TABLE `ps_ap_tuple_details` DISABLE KEYS */;
INSERT INTO `ps_ap_tuple_details` VALUES ('1','USER-PERMISSION',231),('2','VENDOR-INVOICE',13),('3','VENDOR-INVOICE-DETAILS',16),('4','CUSTOMER-INVOICE',4),('5','CUSTOMER-INVOICE-DETAILS',7),('6','ACCOUNT',2),('7','ACCOUNT-TRANSACTION',6);
/*!40000 ALTER TABLE `ps_ap_tuple_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_cus_customer`
--

DROP TABLE IF EXISTS `ps_cus_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_cus_customer` (
  `customerId` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `contact_number` varchar(100) NOT NULL,
  `addresss` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `Balance` double DEFAULT NULL,
  `active` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`customerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_cus_customer`
--

LOCK TABLES `ps_cus_customer` WRITE;
/*!40000 ALTER TABLE `ps_cus_customer` DISABLE KEYS */;
INSERT INTO `ps_cus_customer` VALUES ('c-01','ahmed','234','address','email@gmail.com',0,1),('c-02','ali asghar','234234','asdfasdf','adf@gmail.com',0,1),('c-03','khawar nadeem','293840234','address','khawar@gmail.com',0,1);
/*!40000 ALTER TABLE `ps_cus_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_cus_inovoice_details`
--

DROP TABLE IF EXISTS `ps_cus_inovoice_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_cus_inovoice_details` (
  `DetailId` varchar(100) NOT NULL,
  `InvoiceId` varchar(100) DEFAULT NULL,
  `productId` varchar(100) DEFAULT NULL,
  `amount` double NOT NULL,
  `qty` double NOT NULL,
  PRIMARY KEY (`DetailId`),
  KEY `invoiceId_idx` (`InvoiceId`),
  KEY `productId_idx` (`productId`),
  CONSTRAINT `invoiceId` FOREIGN KEY (`InvoiceId`) REFERENCES `ps_cus_invoice` (`InvoiceId`),
  CONSTRAINT `productId` FOREIGN KEY (`productId`) REFERENCES `ps_gp_products` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_cus_inovoice_details`
--

LOCK TABLES `ps_cus_inovoice_details` WRITE;
/*!40000 ALTER TABLE `ps_cus_inovoice_details` DISABLE KEYS */;
INSERT INTO `ps_cus_inovoice_details` VALUES ('1','1','pr-01',4200,2),('2','1','pr-02',4800,2),('3','2','pr-01',4200,2),('4','2','pr-02',4800,2),('5','3','pr-01',4200,2),('6','3','pr-02',4800,2),('7','4','pr-01',22400,4);
/*!40000 ALTER TABLE `ps_cus_inovoice_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_cus_invoice`
--

DROP TABLE IF EXISTS `ps_cus_invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_cus_invoice` (
  `InvoiceId` varchar(100) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `CustomerId` varchar(100) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `NoOfItemPurchased` double DEFAULT NULL,
  PRIMARY KEY (`InvoiceId`),
  KEY `customerId_idx` (`CustomerId`),
  CONSTRAINT `customerId` FOREIGN KEY (`CustomerId`) REFERENCES `ps_cus_customer` (`customerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_cus_invoice`
--

LOCK TABLES `ps_cus_invoice` WRITE;
/*!40000 ALTER TABLE `ps_cus_invoice` DISABLE KEYS */;
INSERT INTO `ps_cus_invoice` VALUES ('1','','c-01',9000,4),('2','','c-01',9000,4),('3','','c-03',9000,4),('4','','c-01',22400,4);
/*!40000 ALTER TABLE `ps_cus_invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_gp_accounttype`
--

DROP TABLE IF EXISTS `ps_gp_accounttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_gp_accounttype` (
  `typeId` varchar(100) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `active` tinyint DEFAULT NULL,
  PRIMARY KEY (`typeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_gp_accounttype`
--

LOCK TABLES `ps_gp_accounttype` WRITE;
/*!40000 ALTER TABLE `ps_gp_accounttype` DISABLE KEYS */;
INSERT INTO `ps_gp_accounttype` VALUES ('1','Income',1),('2','Expense',1);
/*!40000 ALTER TABLE `ps_gp_accounttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_gp_productcategory`
--

DROP TABLE IF EXISTS `ps_gp_productcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_gp_productcategory` (
  `categoryId` varchar(150) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `active` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`categoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_gp_productcategory`
--

LOCK TABLES `ps_gp_productcategory` WRITE;
/*!40000 ALTER TABLE `ps_gp_productcategory` DISABLE KEYS */;
INSERT INTO `ps_gp_productcategory` VALUES ('cat-01','Office Tools','1'),('cat-02','Development Tools','1'),('cat-03','Management Tools','1'),('cat-04','DevOps','1');
/*!40000 ALTER TABLE `ps_gp_productcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_gp_products`
--

DROP TABLE IF EXISTS `ps_gp_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_gp_products` (
  `productId` varchar(100) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `qty` int NOT NULL,
  `price` varchar(100) NOT NULL,
  `categoryid` varchar(150) NOT NULL,
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`productId`),
  KEY `categoryId_idx` (`categoryid`),
  CONSTRAINT `categoryId` FOREIGN KEY (`categoryid`) REFERENCES `ps_gp_productcategory` (`categoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_gp_products`
--

LOCK TABLES `ps_gp_products` WRITE;
/*!40000 ALTER TABLE `ps_gp_products` DISABLE KEYS */;
INSERT INTO `ps_gp_products` VALUES ('pr-01','Microsoft excel',6764,'900','cat-01',1),('pr-02','Microsoft PowerPoint',20,'5600','cat-01',1);
/*!40000 ALTER TABLE `ps_gp_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_gp_roles`
--

DROP TABLE IF EXISTS `ps_gp_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_gp_roles` (
  `roleId` varchar(100) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `Active` int DEFAULT NULL,
  PRIMARY KEY (`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_gp_roles`
--

LOCK TABLES `ps_gp_roles` WRITE;
/*!40000 ALTER TABLE `ps_gp_roles` DISABLE KEYS */;
INSERT INTO `ps_gp_roles` VALUES ('r-01','admin',1),('r-02','cashier',1),('r-03','manager',1),('r-04','owner',1),('r-05','Stock  Manager',1);
/*!40000 ALTER TABLE `ps_gp_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_us_userpermissions`
--

DROP TABLE IF EXISTS `ps_us_userpermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_us_userpermissions` (
  `userId` varchar(100) DEFAULT NULL,
  `menuId` int DEFAULT NULL,
  `permissionId` int NOT NULL,
  PRIMARY KEY (`permissionId`),
  KEY `userId_idx` (`userId`),
  KEY `menuId_idx` (`menuId`),
  CONSTRAINT `menuId` FOREIGN KEY (`menuId`) REFERENCES `ps_ap_appmenu` (`menuId`),
  CONSTRAINT `userId` FOREIGN KEY (`userId`) REFERENCES `ps_us_users` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_us_userpermissions`
--

LOCK TABLES `ps_us_userpermissions` WRITE;
/*!40000 ALTER TABLE `ps_us_userpermissions` DISABLE KEYS */;
INSERT INTO `ps_us_userpermissions` VALUES ('u-01',1,75),('u-01',2,76),('u-01',4,77),('u-01',11,78),('u-01',12,79),('u-01',13,80),('u-01',21,81),('u-01',22,82),('u-01',23,83),('u-01',24,84),('u-01',31,85),('u-01',32,86),('u-01',40,87),('u-01',41,88),('u-01',42,89),('u-01',5,90),('u-01',6,91),('jafer',1,178),('jafer',2,179),('jafer',4,180),('jafer',5,181),('jafer',6,182),('jafer',11,183),('jafer',12,184),('jafer',13,185),('jafer',21,186),('jafer',22,187),('jafer',23,188),('jafer',24,189),('jafer',31,190),('jafer',32,191),('jafer',40,192),('jafer',41,193),('jafer',42,194),('u-03',2,211),('u-03',4,212),('u-03',5,213),('u-03',6,214),('u-03',11,215),('u-03',12,216),('u-03',13,217),('u-03',21,218),('u-03',22,219),('u-03',23,220),('u-03',24,221),('u-03',31,222),('u-03',32,223),('u-03',40,224),('u-03',41,225),('u-03',42,226),('u-03',1,227),('u-02',1,228),('u-02',11,229),('u-02',31,230),('u-02',40,231);
/*!40000 ALTER TABLE `ps_us_userpermissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_us_users`
--

DROP TABLE IF EXISTS `ps_us_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_us_users` (
  `userId` varchar(150) NOT NULL,
  `name` varchar(150) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `active` tinyint DEFAULT NULL,
  `roleId` varchar(100) NOT NULL,
  PRIMARY KEY (`userId`),
  KEY `roleId_idx` (`roleId`),
  CONSTRAINT `roleId` FOREIGN KEY (`roleId`) REFERENCES `ps_gp_roles` (`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_us_users`
--

LOCK TABLES `ps_us_users` WRITE;
/*!40000 ALTER TABLE `ps_us_users` DISABLE KEYS */;
INSERT INTO `ps_us_users` VALUES ('jafer','jafer sadiq','1234567','asdf@gmail.com',1,'r-05'),('u-01','ittyab','12','ad@gmail.com',1,'r-01'),('u-02','Ahmed','12','ahmed@gmail.com',1,'r-02'),('u-03','ali asghar','12','aliasghar@gmail.com',1,'r-02'),('u-04','fayaaz ahmed','93849','fayaz@gmai.com',1,'r-04');
/*!40000 ALTER TABLE `ps_us_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_vn_invoice`
--

DROP TABLE IF EXISTS `ps_vn_invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_vn_invoice` (
  `InvoiceId` varchar(100) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `amount` double DEFAULT NULL,
  `noOfItems` int DEFAULT NULL,
  `vendorId` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`InvoiceId`),
  KEY `vendorId_idx` (`vendorId`),
  CONSTRAINT `vendorId` FOREIGN KEY (`vendorId`) REFERENCES `ps_vn_vendor` (`vendorId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_vn_invoice`
--

LOCK TABLES `ps_vn_invoice` WRITE;
/*!40000 ALTER TABLE `ps_vn_invoice` DISABLE KEYS */;
INSERT INTO `ps_vn_invoice` VALUES ('10','',112000,20,'V-01'),('11','',112000,20,'V-01'),('12','',224000,40,'V-01'),('13','',6030000,6700,'V-02'),('3','',50000,20,'V-01'),('4','',20000,100,'V-01'),('5','',20000,100,'V-01'),('6','',156000,20,'V-01'),('7','',156000,20,'V-01'),('8','',112000,20,'V-01'),('9','',112000,20,'V-01');
/*!40000 ALTER TABLE `ps_vn_invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_vn_invoice_details`
--

DROP TABLE IF EXISTS `ps_vn_invoice_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_vn_invoice_details` (
  `detailId` varchar(100) NOT NULL,
  `InvoiceId` varchar(100) DEFAULT NULL,
  `productId` varchar(100) DEFAULT NULL,
  `qty` double NOT NULL,
  `amount` double NOT NULL,
  `comments` varchar(150) NOT NULL,
  PRIMARY KEY (`detailId`),
  KEY `InvoiceId_idx` (`InvoiceId`),
  KEY `productId_idx` (`productId`),
  CONSTRAINT `inoviceId` FOREIGN KEY (`InvoiceId`) REFERENCES `ps_vn_invoice` (`InvoiceId`),
  CONSTRAINT `productId_idx` FOREIGN KEY (`productId`) REFERENCES `ps_gp_products` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_vn_invoice_details`
--

LOCK TABLES `ps_vn_invoice_details` WRITE;
/*!40000 ALTER TABLE `ps_vn_invoice_details` DISABLE KEYS */;
INSERT INTO `ps_vn_invoice_details` VALUES ('10','8','pr-01',20,112000,''),('11','9','pr-01',20,112000,''),('12','10','pr-01',20,112000,''),('13','11','pr-01',20,112000,''),('14','12','pr-01',20,112000,''),('15','12','pr-02',20,112000,''),('16','13','pr-01',6700,6030000,''),('5','3','pr-01',20,50000,''),('6','4','pr-01',100,20000,''),('7','5','pr-01',100,20000,''),('8','6','pr-02',20,156000,''),('9','7','pr-02',20,156000,'');
/*!40000 ALTER TABLE `ps_vn_invoice_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ps_vn_vendor`
--

DROP TABLE IF EXISTS `ps_vn_vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ps_vn_vendor` (
  `vendorId` varchar(100) NOT NULL,
  `name` varchar(45) NOT NULL,
  `contactNumber` varchar(45) NOT NULL,
  `regDate` date NOT NULL,
  `email` varchar(45) NOT NULL,
  `Balance` double DEFAULT NULL,
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`vendorId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ps_vn_vendor`
--

LOCK TABLES `ps_vn_vendor` WRITE;
/*!40000 ALTER TABLE `ps_vn_vendor` DISABLE KEYS */;
INSERT INTO `ps_vn_vendor` VALUES ('V-01','ALI','234324','2020-12-10','ALIF.GMAK@S.COM',0,1),('V-02','AHMED RAZA','2344444','2020-12-10','AJMED@CC.COM',0,1);
/*!40000 ALTER TABLE `ps_vn_vendor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-21 18:11:12
