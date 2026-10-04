IF DB_ID(N'LHTLesson14DB') IS NULL
BEGIN
    CREATE DATABASE LHTLesson14DB;
END
GO
USE LHTLesson14DB;
GO

IF OBJECT_ID(N'dbo.PRODUCT', N'U') IS NOT NULL DROP TABLE dbo.PRODUCT;
IF OBJECT_ID(N'dbo.CATEGORY', N'U') IS NOT NULL DROP TABLE dbo.CATEGORY;
IF OBJECT_ID(N'dbo.BANNER', N'U') IS NOT NULL DROP TABLE dbo.BANNER;
IF OBJECT_ID(N'dbo.BLOG', N'U') IS NOT NULL DROP TABLE dbo.BLOG;
GO

CREATE TABLE dbo.CATEGORY
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Status TINYINT NOT NULL DEFAULT 1,
    CreatedDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    Image NVARCHAR(255) NULL,
    Description NVARCHAR(500) NULL
);

CREATE TABLE dbo.PRODUCT
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Price DECIMAL(18,2) NOT NULL DEFAULT 0,
    SalePrice DECIMAL(18,2) NOT NULL DEFAULT 0,
    Status TINYINT NOT NULL DEFAULT 1,
    CategoryId INT NOT NULL,
    CreatedDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    Image NVARCHAR(255) NULL,
    Description NVARCHAR(500) NULL,
    CONSTRAINT FK_PRODUCT_CATEGORY FOREIGN KEY(CategoryId)
        REFERENCES dbo.CATEGORY(Id)
        ON DELETE NO ACTION
);

CREATE TABLE dbo.BANNER
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Status TINYINT NOT NULL DEFAULT 1,
    Priority INT NOT NULL DEFAULT 0,
    Image NVARCHAR(255) NULL,
    Description NVARCHAR(500) NULL
);

CREATE TABLE dbo.BLOG
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Status TINYINT NOT NULL DEFAULT 1,
    CreatedDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    Image NVARCHAR(255) NULL,
    Description NVARCHAR(500) NULL
);
GO

INSERT INTO dbo.CATEGORY(Name, Status, Description) VALUES
(N'Bánh kem',1,N'Bánh kem thông minh chính hãng'),
(N'Bánh sinh nhật',1,N'Bánh sinh nhật học tập, văn phòng và gaming'),
(N'Bánh mousse',1,N'Bánh mousse không dây và có dây'),
(N'Bánh mini',1,N'Bánh mini bánh kem tiện ích');

INSERT INTO dbo.PRODUCT(Name,Price,SalePrice,Status,CategoryId,Image,Description)
SELECT N'iPhone 15',18990000,17990000,1,Id,N'iphone15.jpg',N'Thiết kế hiện đại, hiệu năng mạnh mẽ và camera chất lượng cao.' FROM dbo.CATEGORY WHERE Name=N'Bánh kem'
UNION ALL SELECT N'Samsung Galaxy S24',16990000,15990000,1,Id,N's24.jpg',N'Bánh kem cao cấp cao cấp với màn hình đẹp và hiệu năng mạnh.' FROM dbo.CATEGORY WHERE Name=N'Bánh kem'
UNION ALL SELECT N'Xiaomi 14',14990000,13990000,1,Id,N'xiaomi14.jpg',N'Cấu hình mạnh, camera nổi bật và thiết kế nhỏ gọn.' FROM dbo.CATEGORY WHERE Name=N'Bánh kem'
UNION ALL SELECT N'OPPO Reno 12',11990000,10990000,1,Id,N'opporeno12.jpg',N'Thiết kế thời trang, camera đẹp và trải nghiệm mượt mà.' FROM dbo.CATEGORY WHERE Name=N'Bánh kem'
UNION ALL SELECT N'MacBook Air M3',25990000,24990000,1,Id,N'macbookairm3.jpg',N'Bánh sinh nhật mỏng nhẹ, hiệu năng cao và thời lượng pin tốt.' FROM dbo.CATEGORY WHERE Name=N'Bánh sinh nhật'
UNION ALL SELECT N'Dell Inspiron 15',17990000,16990000,1,Id,N'dellinspiron15.jpg',N'Bánh sinh nhật bền bỉ, phù hợp học tập và làm việc.' FROM dbo.CATEGORY WHERE Name=N'Bánh sinh nhật'
UNION ALL SELECT N'ROG Strix G16',32990000,31990000,1,Id,N'rogstrixg16.jpg',N'Bánh sinh nhật gaming hiệu năng cao cho học tập và giải trí.' FROM dbo.CATEGORY WHERE Name=N'Bánh sinh nhật'
UNION ALL SELECT N'AirPods Pro 2',5990000,5490000,1,Id,N'airpodspro2.jpg',N'Bánh mousse không dây cao cấp, chống ồn chủ động.' FROM dbo.CATEGORY WHERE Name=N'Bánh mousse'
UNION ALL SELECT N'Galaxy Buds 3',4990000,4590000,1,Id,N'galaxybuds3.jpg',N'Bánh mousse Bluetooth nhỏ gọn với âm thanh chất lượng.' FROM dbo.CATEGORY WHERE Name=N'Bánh mousse'
UNION ALL SELECT N'Anker 737',1200000,1090000,1,Id,N'anker737.jpg',N'Pin sạc dự phòng dung lượng cao, tiện dụng.' FROM dbo.CATEGORY WHERE Name=N'Bánh mini'
UNION ALL SELECT N'iPad Air M2',18990000,17990000,1,Id,N'ipadairm2.jpg',N'Máy tính bảng mỏng nhẹ, phù hợp học tập và giải trí.' FROM dbo.CATEGORY WHERE Name=N'Bánh mini';

INSERT INTO dbo.BANNER(Name,Status,Priority,Image,Description) VALUES
(N'Khuyến mãi bánh kem',1,1,N'trangchu.jpg',N'Ưu đãi sản phẩm bánh kem'),
(N'Sản phẩm mới',1,2,N'iphone15.jpg',N'Khám phá sản phẩm mới');

INSERT INTO dbo.BLOG(Name,Status,Description) VALUES
(N'Xu hướng bánh kem 2026',1,N'Những sản phẩm bánh kem nổi bật năm 2026.'),
(N'Kinh nghiệm chọn bánh sinh nhật',1,N'Một số tiêu chí chọn bánh sinh nhật phù hợp nhu cầu.');
GO
