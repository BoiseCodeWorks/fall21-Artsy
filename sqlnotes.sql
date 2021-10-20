-- REVIEW CREATE TABLE
CREATE TABLE IF NOT EXISTS artists(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  name varchar(255) comment 'Artists Full Name',
  era varchar(32) comment 'The era the artist is from',
  country varchar(8) comment '3 digit country code',
  skill int NOT NULL DEFAULT 1 comment 'Skill between 1-10',
  type varchar(16) comment 'What do I even do'
) default charset utf8 comment '';

-- ALTER A TABLE by adding a column
ALTER TABLE artists ADD COLUMN
  isAlive TINYINT NOT NULL DEFAULT 1;

-- ALTER A TABLE by removing a column
ALTER 
TABLE 
artists 
DROP COLUMN isAlive;


INSERT INTO artists(
    name,
    skill,
    country,
    type,
    era
)
VALUES (
    "Mike-A-langelow",
    8,
    "NYS",
    "Martial",
    "Pre-Brittany"
);
INSERT INTO artists(
    name,
    skill,
    country,
    type,
    era
)
VALUES (
    "Donny Tello",
    9,
    "NYS",
    "Martial",
    "Pre-Brittany"
);
INSERT INTO artists(
    name,
    skill,
    country,
    type,
    era
)
VALUES (
    "Leo",
    4,
    "NYS",
    "Martial",
    "Pre-Brittany"
);
INSERT INTO artists(
    name,
    skill,
    country,
    type,
    era
)
VALUES (
    "Ralph IL",
    10,
    "NYS",
    "Martial",
    "Pre-Brittany"
);


-- GET ALL
SELECT * FROM artists;
-- GET BY ID
SELECT * FROM artists WHERE id = 5;

-- EDIT A RECORD
UPDATE artists 
SET
    name = "Leo Nardo",
    skill = 5
WHERE id = 3;

-- DELETE A RECORD
DELETE FROM artists WHERE id = 3;





-- Deleting a table 
-- -- DROP TABLE artists;




