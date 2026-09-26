USE master;
GO

IF DB_ID(N'LuongHuongTra2410900076_ExamDb') IS NULL
BEGIN
    CREATE DATABASE [LuongHuongTra2410900076_ExamDb];
END
GO

USE [LuongHuongTra2410900076_ExamDb];
GO

IF OBJECT_ID(N'dbo.LhtEmployee', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.LhtEmployee;
END
GO

CREATE TABLE dbo.LhtEmployee
(
    Id INT IDENTITY(1,1) NOT NULL,
    LhtName NVARCHAR(100) NOT NULL,
    LhtGender NVARCHAR(20) NULL,
    LhtBirthDay DATE NULL,
    LhtEmail NVARCHAR(150) NULL,
    LhtPhone NVARCHAR(20) NULL,
    LhtActive BIT NOT NULL DEFAULT (1),
    CONSTRAINT PK_LhtEmployee PRIMARY KEY (Id)
);
GO

INSERT INTO dbo.LhtEmployee
(
    LhtName,
    LhtGender,
    LhtBirthDay,
    LhtEmail,
    LhtPhone,
    LhtActive
)
VALUES
(
    N'Lương Hương Trà',
    N'Nữ',
    '2004-01-01',
    'tra@example.com',
    '0123456789',
    1
);
GO

SELECT
    Id,
    LhtName,
    LhtGender,
    LhtBirthDay,
    LhtEmail,
    LhtPhone,
    LhtActive
FROM dbo.LhtEmployee;
GO
