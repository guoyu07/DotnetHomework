SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS  `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(45) NOT NULL,
  `ProductVersion` varchar(45) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `activity`;
CREATE TABLE `activity` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `society` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `time` datetime NOT NULL,
  `createtime` datetime DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(45) DEFAULT 'Pending',
  `reason` text,
  PRIMARY KEY (`id`),
  KEY `index_activity_society` (`society`) USING BTREE,
  CONSTRAINT `fk_activity_society_id` FOREIGN KEY (`society`) REFERENCES `society` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` varchar(255) DEFAULT NULL,
  `ClaimValue` varchar(255) DEFAULT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `ConcurrencyStamp` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `NormalizedName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` varchar(255) DEFAULT NULL,
  `ClaimValue` varchar(255) DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` varchar(255) DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  KEY `IX_AspNetUserRoles_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `NormalizedEmail` varchar(255) DEFAULT NULL,
  `NormalizedUserName` varchar(255) DEFAULT NULL,
  `PasswordHash` varchar(255) DEFAULT NULL,
  `PhoneNumber` varchar(255) DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` varchar(255) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `UserNameIndex` (`NormalizedUserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `member`;
CREATE TABLE `member` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(255) NOT NULL,
  `society` int(11) NOT NULL,
  `entrypost` text,
  `entrytime` datetime DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(32) DEFAULT 'Pending',
  PRIMARY KEY (`id`),
  KEY `index_member_society` (`society`) USING BTREE,
  KEY `index_member_user` (`user`) USING BTREE,
  CONSTRAINT `fk_member_aspnetusers_id` FOREIGN KEY (`user`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_member_society_id` FOREIGN KEY (`society`) REFERENCES `society` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `society`;
CREATE TABLE `society` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `category` int(11) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `creator` varchar(255) NOT NULL,
  `createtime` datetime DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(45) DEFAULT 'Pending',
  `reason` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `index_society_name` (`name`) USING HASH,
  KEY `index_society_category` (`category`) USING BTREE,
  KEY `index_society_creator` (`creator`) USING BTREE,
  CONSTRAINT `fk_society_aspnetusers_id` FOREIGN KEY (`creator`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_society_societycategory_id` FOREIGN KEY (`category`) REFERENCES `societycategory` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `societycategory`;
CREATE TABLE `societycategory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `index_societycategory_name` (`name`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS  `takepart`;
CREATE TABLE `takepart` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(255) NOT NULL,
  `activity` int(45) NOT NULL,
  `time` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `index_take_part_activity` (`activity`) USING BTREE,
  KEY `index_take_part_user` (`user`) USING BTREE,
  CONSTRAINT `fk_takepart_activity_id` FOREIGN KEY (`activity`) REFERENCES `activity` (`id`),
  CONSTRAINT `fk_takepart_aspnetusers_id` FOREIGN KEY (`user`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

SET FOREIGN_KEY_CHECKS = 1;

/* VIEWS */;
DROP VIEW IF EXISTS `vactivityinfo`;
CREATE VIEW `vactivityinfo` AS select `activity`.`id` AS `id`,`activity`.`society` AS `societyid`,`activity`.`name` AS `name`,`activity`.`description` AS `description`,`activity`.`time` AS `time`,`activity`.`createtime` AS `createtime`,`activity`.`status` AS `status`,`activity`.`reason` AS `reason`,`society`.`name` AS `societyname`,`society`.`description` AS `societydescription` from (`activity` left join `society` on((`activity`.`society` = `society`.`id`)));

DROP VIEW IF EXISTS `vmemberinfo`;
CREATE VIEW `vmemberinfo` AS select `member`.`id` AS `id`,`member`.`user` AS `userid`,`aspnetusers`.`UserName` AS `username`,`member`.`society` AS `societyid`,`member`.`entrytime` AS `entrytime`,`member`.`entrypost` AS `entrypost`,`member`.`status` AS `status`,`society`.`name` AS `societyname`,`society`.`description` AS `societydescription` from ((`member` left join `aspnetusers` on((`member`.`user` = `aspnetusers`.`Id`))) left join `society` on((`member`.`society` = `society`.`id`)));

DROP VIEW IF EXISTS `vsocietyinfo`;
CREATE VIEW `vsocietyinfo` AS select `society`.`id` AS `id`,`society`.`name` AS `name`,`societycategory`.`id` AS `categoryid`,`societycategory`.`name` AS `categoryname`,`society`.`description` AS `description`,`society`.`createtime` AS `createtime`,coalesce(`vsocietymembercount`.`membercount`,0) AS `membercount`,`aspnetusers`.`Id` AS `creatorid`,`aspnetusers`.`UserName` AS `creatorname`,`society`.`status` AS `status`,`society`.`reason` AS `reason` from (((`society` left join `vsocietymembercount` on((`society`.`id` = `vsocietymembercount`.`id`))) left join `societycategory` on((`society`.`category` = `societycategory`.`id`))) left join `aspnetusers` on((`society`.`creator` = `aspnetusers`.`Id`)));

DROP VIEW IF EXISTS `vsocietymembercount`;
CREATE VIEW `vsocietymembercount` AS select `member`.`society` AS `id`,count(`member`.`society`) AS `membercount` from `member` where (`member`.`status` = 'Accept') group by `member`.`society`;

DROP VIEW IF EXISTS `vtakepartinfo`;
CREATE VIEW `vtakepartinfo` AS select `takepart`.`id` AS `id`,`takepart`.`user` AS `userid`,`takepart`.`activity` AS `activityid`,`takepart`.`time` AS `applicationperiod`,`aspnetusers`.`UserName` AS `username`,`activity`.`society` AS `societyid`,`activity`.`name` AS `activityname`,`activity`.`description` AS `activitydescription`,`activity`.`time` AS `activitytime`,`activity`.`status` AS `activitystatus`,`society`.`name` AS `societyname` from (((`takepart` left join `aspnetusers` on((`takepart`.`user` = `aspnetusers`.`Id`))) left join `activity` on((`takepart`.`activity` = `activity`.`id`))) left join `society` on((`activity`.`society` = `society`.`id`)));

/* FUNCTIONS */;
DROP FUNCTION IF EXISTS `f_CountOfSocietiesIJoined`;
DELIMITER $$
CREATE FUNCTION `f_CountOfSocietiesIJoined`(
		in_userId VARCHAR(255)
) RETURNS int(11)
    DETERMINISTIC
    COMMENT '获取我加入的社团数量'
BEGIN
DECLARE cnt INT ;
	SELECT COUNT(*) INTO cnt
  FROM `member`
 WHERE `user`= in_userId
   AND `status`= "Accept"; 
	RETURN cnt;
END
$$
DELIMITER ;

