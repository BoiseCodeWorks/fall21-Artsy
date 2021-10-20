CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS artists(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  name varchar(255) comment 'Artists Full Name',
  era varchar(32) comment 'The era the artist is from',
  country varchar(8) comment '3 digit country code',
  skill int NOT NULL DEFAULT 1 comment 'Skill between 1-10',
  type varchar(16) comment 'What do I even do',
  isAlive TINYINT NOT NULL DEFAULT 1
) default charset utf8 comment '';
CREATE TABLE IF NOT EXISTS works(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  title varchar(255) comment 'Masterpiece Title',
  artistId int NOT NULL,
  FOREIGN KEY (artistId) REFERENCES artists(id) ON DELETE CASCADE
) default charset utf8 comment 'COOL PIECES WORTH DIMENTIONNING';


INSERT INTO works (title, artistId)
VALUES ("Da Sewagé Chapél", 1);


SELECT * FROM works;

SELECT 
  * 
FROM works w
JOIN artists a 
ON a.id = w.artistId; 