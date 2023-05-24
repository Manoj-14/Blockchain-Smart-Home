/*
SQLyog Ultimate v8.55 
MySQL - 5.1.36-community : Database - smartiot
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`smartiot` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `smartiot`;

/*Table structure for table `adminmaster` */

DROP TABLE IF EXISTS `adminmaster`;

CREATE TABLE `adminmaster` (
  `AdminId` varchar(10) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `adminmaster` */

insert  into `adminmaster`(`AdminId`,`Password`) values ('Admin','123');

/*Table structure for table `devicemaster` */

DROP TABLE IF EXISTS `devicemaster`;

CREATE TABLE `devicemaster` (
  `DeviceId` varchar(20) NOT NULL,
  `DeviceName` varchar(100) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`DeviceId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `devicemaster` */

insert  into `devicemaster`(`DeviceId`,`DeviceName`,`Description`) values ('D1','LED Light','LED Light'),('D2','LED Light 1','LED Light 1');

/*Table structure for table `userledger` */

DROP TABLE IF EXISTS `userledger`;

CREATE TABLE `userledger` (
  `UFPId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `FilePath` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`UFPId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `userledger` */

insert  into `userledger`(`UFPId`,`UserId`,`FilePath`) values (1,654321,'iotfilebc654321/guru654321.xml'),(2,943994,'iotfilebc943994/vishnu943994.xml');

/*Table structure for table `usermaster` */

DROP TABLE IF EXISTS `usermaster`;

CREATE TABLE `usermaster` (
  `UserId` varchar(10) NOT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  `IpAddress` varchar(100) DEFAULT NULL,
  `MACAddress` varchar(100) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(1000) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `usermaster` */

insert  into `usermaster`(`UserId`,`Password`,`UserName`,`IpAddress`,`MACAddress`,`MobileNo`,`EmailId`,`Address`,`Status`) values ('654321','123','Guru','192.168.1.240','E4B97A2C2A4C','9986337543','srinivaskarthik.v@gmail.com','Mysuru','Approve'),('943994','123','Vishnu','192.168.1.240','E4B97A2C2A4C','9986337543','srinivaskarthik.v@gmail.com','Mysuru','Approve');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
