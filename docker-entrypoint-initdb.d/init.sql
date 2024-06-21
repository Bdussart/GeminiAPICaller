
CREATE DATABASE IF NOT EXISTS db;
USE db;
CREATE TABLE IF NOT EXISTS users (id TINYINT PRIMARY KEY auto_increment, login CHAR(20) UNIQUE NOT NULL, pswd CHAR(100) NOT NULL, creation_date DATE NOT NULL, last_login_date DATE);
INSERT INTO users (login, pswd, creation_date)
VALUES ("toto", "12345678", "2024-06-20");
INSERT INTO users (login, pswd, creation_date)
VALUES ("tata", "abcdefgh", "2024-06-20");
