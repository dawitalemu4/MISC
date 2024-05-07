/* Create the database */
CREATE DATABASE IF NOT EXISTS labs_db;
USE labs_db;

-- Create a user and grant privileges
CREATE USER IF NOT EXISTS 'wp_user'@'%' IDENTIFIED BY 'password';
GRANT ALL PRIVILEGES ON labs_db.* TO 'wp_user'@'%';
FLUSH PRIVILEGES;

CREATE TABLE requests (
    id INT AUTO_INCREMENT PRIMARY KEY,
    firstName VARCHAR(30) NOT NULL,
    lastName VARCHAR(30) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone INT UNSIGNED NOT NULL,
    campus VARCHAR(255) NOT NULL,
    workshop VARCHAR(255) NULL,
    completed BOOLEAN DEFAULT FALSE,
    submitted_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- -- Create a sample table
-- CREATE TABLE IF NOT EXISTS users (
--     id INT AUTO_INCREMENT PRIMARY KEY,
--     firstName VARCHAR(30) NOT NULL,
--     lastName VARCHAR(30) NOT NULL,
--     billingAddress TEXT NOT NULL,
--     deliveryAddress TEXT NOT NULL,
--     username VARCHAR(30) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     reg_date TIMESTAMP
-- );