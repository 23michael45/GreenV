/*
Navicat MySQL Data Transfer

Source Server         : Root
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : netcoreserver

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2018-12-15 18:04:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `app_groundtruthdata`
-- ----------------------------
DROP TABLE IF EXISTS `app_groundtruthdata`;
CREATE TABLE `app_groundtruthdata` (
  `Id` bigint(36) NOT NULL AUTO_INCREMENT,
  `createtime` datetime(6) NOT NULL,
  `device` longtext,
  `leftright` int(11) NOT NULL,
  `timestamp` varchar(64) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_groundtruthdata
-- ----------------------------
INSERT INTO `app_groundtruthdata` VALUES ('1', '2018-12-15 18:02:37.769356', '127.0.0.1', '2', '11:11:12');
INSERT INTO `app_groundtruthdata` VALUES ('2', '2018-12-15 18:02:41.347332', '127.0.0.1', '2', '11:11:12');

-- ----------------------------
-- Table structure for `app_sensordata`
-- ----------------------------
DROP TABLE IF EXISTS `app_sensordata`;
CREATE TABLE `app_sensordata` (
  `Id` char(36) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `device` longtext,
  `gain` smallint(6) NOT NULL,
  `rate` smallint(6) NOT NULL,
  `sensorvalue` longblob,
  `timestampms` int(11) NOT NULL,
  `timestamps` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_sensordata
-- ----------------------------

-- ----------------------------
-- Table structure for `departments`
-- ----------------------------
DROP TABLE IF EXISTS `departments`;
CREATE TABLE `departments` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `ContactNumber` longtext,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `IsDeleted` int(11) NOT NULL,
  `Manager` longtext,
  `Name` longtext,
  `ParentId` char(36) NOT NULL,
  `Remarks` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO `departments` VALUES ('24eb98c7-49a9-4c1f-b260-205474783133', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C321F1', '00000000-0000-0000-0000-000000000000', null);
INSERT INTO `departments` VALUES ('2ab9efb6-9987-48e3-90f9-fb12b5c93afd', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C215F1', '00000000-0000-0000-0000-000000000000', null);
INSERT INTO `departments` VALUES ('7e579f44-6496-4f51-9622-8448d861b140', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C320F1', '00000000-0000-0000-0000-000000000000', null);

-- ----------------------------
-- Table structure for `groundtruths`
-- ----------------------------
DROP TABLE IF EXISTS `groundtruths`;
CREATE TABLE `groundtruths` (
  `Id` char(36) NOT NULL,
  `DepartmentId` char(36) NOT NULL,
  `desc` longtext,
  `ip` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of groundtruths
-- ----------------------------

-- ----------------------------
-- Table structure for `menus`
-- ----------------------------
DROP TABLE IF EXISTS `menus`;
CREATE TABLE `menus` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `Icon` longtext,
  `Name` longtext,
  `ParentId` char(36) NOT NULL,
  `Remarks` longtext,
  `SerialNumber` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `Url` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of menus
-- ----------------------------
INSERT INTO `menus` VALUES ('08d551c2-ccd4-9290-a56c-f2cb1bbb7706', 'Home', 'fa fa-link', '首页', '00000000-0000-0000-0000-000000000000', null, '0', '0', 'Home/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-1ca3-be9d-02aa56447f0e', 'Terminal', 'fa fa-link', '控制传感器终端', '00000000-0000-0000-0000-000000000000', null, '1', '0', 'Terminal/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-1fda-4bc9-84339068aae0', 'GroundTruth', 'fa fa-link', 'GroundTruth管理', '00000000-0000-0000-0000-000000000000', null, '2', '0', 'GroundTruth/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-205e-7c07-2934ab361fae', 'App_SensorData', 'fa fa-link', '传感器数据', '00000000-0000-0000-0000-000000000000', null, '3', '0', 'App_SensorData/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-20fe-2f42-4c0025e8328f', 'App_GroundTruthData', 'fa fa-link', 'GroundTruth数据', '00000000-0000-0000-0000-000000000000', null, '4', '0', 'App_GroundTruthData/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-2161-2642-bda891d613e7', 'Map', 'fa fa-link', '设备地图', '00000000-0000-0000-0000-000000000000', null, '5', '0', 'Map/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-21c4-55df-0e65974bc4ad', 'User', 'fa fa-link', '用户管理', '00000000-0000-0000-0000-000000000000', null, '6', '0', 'User/Index');
INSERT INTO `menus` VALUES ('08d551c2-ccd5-223f-b2d0-07922d05e087', 'Department', 'fa fa-link', '楼层管理', '00000000-0000-0000-0000-000000000000', null, '7', '0', 'Department/Index');

-- ----------------------------
-- Table structure for `roles`
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `Name` longtext,
  `Remarks` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO `roles` VALUES ('08d551c2-ccd5-4566-72fe-fbd8103dfdf6', '管理员', null, '00000000-0000-0000-0000-000000000000', '管理员', '管理员');
INSERT INTO `roles` VALUES ('08d551c2-ccd5-e95b-f9b8-c9322ffd8de2', '一般用户', null, '00000000-0000-0000-0000-000000000000', '一般用户', '一般用户');

-- ----------------------------
-- Table structure for `terminals`
-- ----------------------------
DROP TABLE IF EXISTS `terminals`;
CREATE TABLE `terminals` (
  `Id` char(36) NOT NULL,
  `DepartmentId` char(36) NOT NULL,
  `PositionX` int(11) NOT NULL,
  `PositionY` int(11) NOT NULL,
  `desc` longtext,
  `ip` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of terminals
-- ----------------------------
INSERT INTO `terminals` VALUES ('08d658e9-a913-2497-bfe9-98c32ca5ffba', '24eb98c7-49a9-4c1f-b260-205474783133', '608', '608', 'Terminal:0 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.1');
INSERT INTO `terminals` VALUES ('08d658e9-a915-b6a8-b206-4e0b92d0e227', '24eb98c7-49a9-4c1f-b260-205474783133', '274', '274', 'Terminal:1 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.2');
INSERT INTO `terminals` VALUES ('08d658e9-a915-b99a-f0e2-0dc4a4e2d088', '24eb98c7-49a9-4c1f-b260-205474783133', '639', '671', 'Terminal:2 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.3');
INSERT INTO `terminals` VALUES ('08d658e9-a915-ba04-c974-847cd9994875', '24eb98c7-49a9-4c1f-b260-205474783133', '305', '399', 'Terminal:3 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.4');
INSERT INTO `terminals` VALUES ('08d658e9-a915-ba8b-6830-bbbbfe991c82', '24eb98c7-49a9-4c1f-b260-205474783133', '671', '159', 'Terminal:4 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.5');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bad5-65de-7d761186584f', '24eb98c7-49a9-4c1f-b260-205474783133', '336', '650', 'Terminal:5 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.6');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bb18-0c03-bd73a46711e8', '24eb98c7-49a9-4c1f-b260-205474783133', '702', '473', 'Terminal:6 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.7');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bbbf-61e0-82cecd734a83', '24eb98c7-49a9-4c1f-b260-205474783133', '368', '327', 'Terminal:7 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.8');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bc19-b9fa-20f3cd4e5f91', '24eb98c7-49a9-4c1f-b260-205474783133', '733', '213', 'Terminal:8 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.9');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bc5f-2c98-620c75c6fd3d', '24eb98c7-49a9-4c1f-b260-205474783133', '399', '129', 'Terminal:9 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.10');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bca3-8c4b-fbdbd17b764c', '24eb98c7-49a9-4c1f-b260-205474783133', '765', '778', 'Terminal:10 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.11');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bd39-486f-064a87238cb8', '24eb98c7-49a9-4c1f-b260-205474783133', '431', '757', 'Terminal:11 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.12');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bd83-ecf2-ffd146e21df5', '24eb98c7-49a9-4c1f-b260-205474783133', '796', '768', 'Terminal:12 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.13');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bdd3-02e2-b7878340cd67', '24eb98c7-49a9-4c1f-b260-205474783133', '462', '111', 'Terminal:13 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.14');
INSERT INTO `terminals` VALUES ('08d658e9-a915-be1a-91b3-fd425b09105a', '24eb98c7-49a9-4c1f-b260-205474783133', '128', '185', 'Terminal:14 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.15');
INSERT INTO `terminals` VALUES ('08d658e9-a915-be7d-d7a3-49a58c6a7be7', '24eb98c7-49a9-4c1f-b260-205474783133', '493', '290', 'Terminal:15 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.16');
INSERT INTO `terminals` VALUES ('08d658e9-a915-beeb-4c37-3ab88c3f023b', '24eb98c7-49a9-4c1f-b260-205474783133', '159', '426', 'Terminal:16 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.17');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bf35-a31e-7492c2d5a8c8', '24eb98c7-49a9-4c1f-b260-205474783133', '525', '595', 'Terminal:17 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.18');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bf9e-b358-c11ce8cb696f', '24eb98c7-49a9-4c1f-b260-205474783133', '190', '794', 'Terminal:18 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.19');
INSERT INTO `terminals` VALUES ('08d658e9-a915-bfe5-b7c8-69800748376b', '24eb98c7-49a9-4c1f-b260-205474783133', '556', '325', 'Terminal:19 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.20');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c028-32c1-bdc4efeac775', '24eb98c7-49a9-4c1f-b260-205474783133', '222', '587', 'Terminal:20 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.21');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c069-5b85-f625c36b29ec', '24eb98c7-49a9-4c1f-b260-205474783133', '588', '181', 'Terminal:21 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.22');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c0cf-2e4e-4bb780b2abf2', '24eb98c7-49a9-4c1f-b260-205474783133', '253', '506', 'Terminal:22 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.23');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c116-a100-e47b674b4242', '24eb98c7-49a9-4c1f-b260-205474783133', '619', '162', 'Terminal:23 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.24');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c159-d421-945ac6833a0b', '24eb98c7-49a9-4c1f-b260-205474783133', '285', '550', 'Terminal:24 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.25');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c19d-4a80-27586eacb0f3', '24eb98c7-49a9-4c1f-b260-205474783133', '650', '269', 'Terminal:25 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.26');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c200-6947-6c5826334357', '24eb98c7-49a9-4c1f-b260-205474783133', '316', '720', 'Terminal:26 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.27');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c24a-f7f9-0b46326fdb83', '24eb98c7-49a9-4c1f-b260-205474783133', '682', '502', 'Terminal:27 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.28');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c28d-97d7-7767e60a63ed', '24eb98c7-49a9-4c1f-b260-205474783133', '347', '315', 'Terminal:28 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.29');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c2d4-5cb4-91a58427cf86', '24eb98c7-49a9-4c1f-b260-205474783133', '713', '160', 'Terminal:29 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.30');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c33a-0f31-d5f75b8cf463', '24eb98c7-49a9-4c1f-b260-205474783133', '379', '736', 'Terminal:30 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.31');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c381-6515-bb496d329415', '24eb98c7-49a9-4c1f-b260-205474783133', '744', '643', 'Terminal:31 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.32');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c3c4-3329-e4646e798ea8', '24eb98c7-49a9-4c1f-b260-205474783133', '410', '582', 'Terminal:32 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.33');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c408-031b-9acf4c460648', '24eb98c7-49a9-4c1f-b260-205474783133', '776', '553', 'Terminal:33 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.34');
INSERT INTO `terminals` VALUES ('08d658e9-a915-c46e-7993-6de2988e917d', '24eb98c7-49a9-4c1f-b260-205474783133', '442', '554', 'Terminal:34 in Department:24eb98c7-49a9-4c1f-b260-205474783133', '192.168.31.35');
INSERT INTO `terminals` VALUES ('99b5a1fb-602d-4a3e-b459-ad01fea28b55', '24eb98c7-49a9-4c1f-b260-205474783133', '1', '1', '1', '127.0.0.1');

-- ----------------------------
-- Table structure for `userroles`
-- ----------------------------
DROP TABLE IF EXISTS `userroles`;
CREATE TABLE `userroles` (
  `UserId` char(36) NOT NULL,
  `RoleId` char(36) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_UserRoles_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRoles_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userroles
-- ----------------------------

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` char(36) NOT NULL,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `EMail` longtext,
  `IsDeleted` int(11) NOT NULL,
  `LastLoginTime` datetime(6) NOT NULL,
  `LoginTimes` int(11) NOT NULL,
  `MobileNumber` longtext,
  `Name` longtext,
  `Password` longtext,
  `Remarks` longtext,
  `UserName` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('08d551c2-ccd3-06bd-2f63-468eff3abc8a', null, '00000000-0000-0000-0000-000000000000', null, '0', '0001-01-01 00:00:00.000000', '0', null, 'super admin', 'admin', null, 'admin');

-- ----------------------------
-- Table structure for `__efmigrationshistory`
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20171229122042_gv', '2.0.1-rtm-125');
