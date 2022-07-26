CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS companies(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL

) default charset utf8;



CREATE TABLE IF NOT EXISTS contractors(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL

) default charset utf8;



CREATE TABLE IF NOT EXISTS jobs(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  contractorId INT NOT NULL,
  companyId INT NOT NULL

) default charset utf8;

/* SELECT * from jobs JOIN companies ON jobs.companyId = companies.id WHERE contractorId = 2 */