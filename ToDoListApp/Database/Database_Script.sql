-- 1. TẠO DATABASE
CREATE DATABASE TodoAppDB;
GO
USE TodoAppDB;
GO


-- PHẦN 1: TẠO CÁC BẢNG (TABLES)

-- Bảng 1: Thông tin người dùng
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY, 
    TotalPoints INT DEFAULT 0,
    TotalEXP INT DEFAULT 0,
    CurrentLevel INT DEFAULT 1,
    CurrentStreak INT DEFAULT 0,
    PomoWorkTime INT DEFAULT 25,
    PomoBreakTime INT DEFAULT 5
);

-- Bảng 2: Danh mục công việc (Category)
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    ColorHex VARCHAR(7) DEFAULT '#FFFFFF'
);

-- Bảng 3: Công việc (Tasks)
CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT,
    Title NVARCHAR(255) NOT NULL,
    Priority INT DEFAULT 1, 
    DueDate DATETIME,
    IsCompleted BIT DEFAULT 0, 
    CompletedDate DATETIME NULL,
    RewardPoints INT DEFAULT 10,
    RewardEXP INT DEFAULT 10,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Bảng 4: Lịch sử tập trung (PomodoroSessions)
CREATE TABLE PomodoroSessions (
    SessionID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT,
    StartTime DATETIME DEFAULT GETDATE(),
    Duration INT NOT NULL, 
    FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID)
);

-- Bảng 5: Cửa hàng vật phẩm (StoreItems)
CREATE TABLE StoreItems (
    ItemID INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(100) NOT NULL,
    ItemType VARCHAR(50), 
    PricePoints INT NOT NULL,
    RequiredLevel INT DEFAULT 1
);

-- Bảng 6: Lịch sử đổi quà 
CREATE TABLE Item_Traded (
    TradeID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    ItemID INT,
    RedeemedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ItemID) REFERENCES StoreItems(ItemID)
);
GO


-- PHẦN 2: THÊM DỮ LIỆU MẪU (INSERT) ĐỂ TEST UI


INSERT INTO Users (TotalPoints, TotalEXP, CurrentLevel, CurrentStreak) 
VALUES (150, 500, 2, 3);

INSERT INTO Categories (CategoryName, ColorHex) VALUES 
(N'Học tập', '#FF5733'),
(N'Đồ án WinForms', '#3380FF'),
(N'Cá nhân', '#33FF57');

INSERT INTO Tasks (CategoryID, Title, Priority, DueDate, IsCompleted, CompletedDate, RewardPoints) VALUES 
(2, N'Thiết kế giao diện Bunifu', 3, GETDATE(), 0, NULL, 50),
(1, N'Học SQL Server cơ bản', 2, GETDATE()-1, 1, GETDATE()-1, 20),
(3, N'Chạy bộ 30 phút', 1, GETDATE(), 1, GETDATE(), 15);

INSERT INTO StoreItems (ItemName, ItemType, PricePoints, RequiredLevel) VALUES 
(N'Theme Dark Mode', 'THEME', 100, 2),
(N'Trà sữa (Tự thưởng)', 'GIFT', 300, 1),
(N'Avatar Vàng', 'GIFT', 500, 5);

INSERT INTO Item_Traded (UserID, ItemID, RedeemedDate) VALUES 
(1, 1, GETDATE()-2);

INSERT INTO PomodoroSessions (TaskID, StartTime, Duration) 
VALUES 
(2, GETDATE()-1, 25), 
(1, GETDATE(), 50);