/*
    SecureVault Database Setup Script (Module 7 Refinement)
    Run this script in SQL Server Management Studio (SSMS)
*/

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SecureVaultDB')
BEGIN
    CREATE DATABASE SecureVaultDB;
END
GO

USE SecureVaultDB;
GO

-- 1. Users Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserID INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(100) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(MAX) NOT NULL,
        Salt NVARCHAR(MAX) NOT NULL, -- Essential for security
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END
GO

-- 2. Files Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Files')
BEGIN
    CREATE TABLE Files (
        FileID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL,
        FileName NVARCHAR(255) NOT NULL, -- Original name
        EncryptedData NVARCHAR(MAX) NOT NULL, -- Path to encrypted file (as per requirement)
        FileSize BIGINT,
        UploadDate DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Files_Users FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
    );
END
GO

-- 3. Logs Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Logs')
BEGIN
    CREATE TABLE Logs (
        LogID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NULL,
        EventType NVARCHAR(100) NOT NULL,
        Description NVARCHAR(MAX),
        Timestamp DATETIME DEFAULT GETDATE(),
        IsSuspicious BIT DEFAULT 0,
        CONSTRAINT FK_Logs_Users FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE SET NULL
    );
END
GO

-- 4. UserKeys Table (Module 3 requirement)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserKeys')
BEGIN
    CREATE TABLE UserKeys (
        KeyId INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL,
        KeyType NVARCHAR(50) NOT NULL,
        EncryptedKey NVARCHAR(MAX) NOT NULL,
        IV NVARCHAR(MAX) NOT NULL,
        CreatedAt DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_UserKeys_Users FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
    );
END
GO
