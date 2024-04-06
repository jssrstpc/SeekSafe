ALTER AUTHORIZATION ON DATABASE::SeekSafe TO [sa];

CREATE DATABASE SeekSafe;
USE SeekSafe;

-- Create UserRole table
CREATE TABLE UserRole (
    roleID INT PRIMARY KEY,
    roleName NVARCHAR(50) NOT NULL
);

-- Inserting data into UserRoles table
INSERT INTO UserRole (roleID, roleName) VALUES
(1, N'Admin'),
(2, N'User');

-- Create Department table
CREATE TABLE Department (
    departmentID INT PRIMARY KEY,
    departmentName NVARCHAR(100) NOT NULL
);

-- Inserting data into Department table
INSERT INTO Department (departmentID, departmentName) VALUES
(1, N'Elementary'),
(2, N'Junior High School'),
(3, N'Senior High School'),
(4, N'College');

-- Create UserAccount table
CREATE TABLE UserAccount (
    userID INT IDENTITY(1,1) PRIMARY KEY,
    userIDNum NVARCHAR(20) UNIQUE NOT NULL,
    username NVARCHAR(50) UNIQUE NOT NULL,
    [password] NVARCHAR(50) NOT NULL,
    roleID INT,
    FOREIGN KEY (roleID) REFERENCES UserRole(roleID)
);

-- Create UserInfo table
CREATE TABLE UserInfo (
    userInfoID INT IDENTITY(1,1) PRIMARY KEY,
    userIDNum NVARCHAR(20) UNIQUE NOT NULL,
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    departmentID INT,
    contactNo NVARCHAR(20),
    email NVARCHAR(100),
    registrationDate DATE,
    FOREIGN KEY (userIDNum) REFERENCES UserAccount(userIDNum),
    FOREIGN KEY (departmentID) REFERENCES Department(departmentID)
);

-- Create ItemLocations table
CREATE TABLE ItemLocation (
    locationID INT IDENTITY(1,1) PRIMARY KEY,
    locationName NVARCHAR(100)
);

-- Create Item table
CREATE TABLE Item (
    itemID INT IDENTITY(1,1) PRIMARY KEY,
    userIDNum NVARCHAR(20),
    itemName NVARCHAR(100) NOT NULL,
    itemType NVARCHAR(50),
    itemStatus NVARCHAR(50),
    itemDescription NVARCHAR(255),
    locationFound INT,
    dateFound DATE,
    ImageURL NVARCHAR(255),
    FOREIGN KEY (userIDNum) REFERENCES UserAccount(userIDNum),
    FOREIGN KEY (locationFound) REFERENCES ItemLocation(locationID)
);

-- Create TransactionHistory table
CREATE TABLE TransactionHistory (
    transactionID INT IDENTITY(1,1) PRIMARY KEY,
    userIDNum NVARCHAR(20),
    otherUserIDNum NVARCHAR(20),
    itemID INT,
    transactionDate DATE,
    transactionType NVARCHAR(50),
    FOREIGN KEY (userIDNum) REFERENCES UserAccount(userIDNum),
    FOREIGN KEY (otherUserIDNum) REFERENCES UserAccount(userIDNum),
    FOREIGN KEY (itemID) REFERENCES Item(itemID)
);

-- Create Notification_Message table
CREATE TABLE Notification_Message (
    notificationID INT IDENTITY(1,1) PRIMARY KEY,
    userIDNum NVARCHAR(20),
    messageNotif NVARCHAR(255),
    dateReceive DATE,
    FOREIGN KEY (userIDNum) REFERENCES UserAccount(userIDNum)
);

-- Create Categories table
CREATE TABLE Category (
    categoryID INT IDENTITY(1,1) PRIMARY KEY,
    categoryName NVARCHAR(100)
);

-- Insert data into Categories table
INSERT INTO Category (categoryName) VALUES 
('Electronic'),
('Clothing'),
('Jewelry'),
('Book');

-- Create Tag table
CREATE TABLE Tag (
    tagID INT IDENTITY(1,1) PRIMARY KEY,
    tagName NVARCHAR(100)
);

-- Insert data into Tags table
INSERT INTO Tag (tagName) VALUES 
('Lost'),
('Found'),
('Identified'),
('Unidentified');
