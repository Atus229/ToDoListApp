CREATE DATABASE TodoGameDB;
GO
USE TodoGameDB;

-- 1. Bảng lưu trữ nhiệm vụ
CREATE TABLE Quests (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TaskName NVARCHAR(255) NOT NULL,
    BaseExp INT,
    BaseCoin INT,
    Deadline DATETIME,
    PriorityColor VARCHAR(20),
    IsDone BIT DEFAULT 0
);

-- 2. Bảng lưu trữ chỉ số người chơi (Chỉ cần 1 dòng duy nhất)
CREATE TABLE PlayerStats (
    Id INT PRIMARY KEY,
    TotalExp INT DEFAULT 0,
    TotalCoin INT DEFAULT 0
);

-- Khởi tạo dữ liệu người chơi ban đầu
INSERT INTO PlayerStats (Id, TotalExp, TotalCoin) VALUES (1, 0, 0);

USE TodoGameDB;
GO

-- 1. Bảng vật phẩm có trong Cửa hàng (Danh mục gốc)
CREATE TABLE StoreItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100) NOT NULL,
    Price INT NOT NULL,
    ImageName VARCHAR(100), -- Tên ảnh trong Resources (ví dụ: 'img_pet_food')
    Category NVARCHAR(50)   -- 'Food', 'Clothes', 'Decor'
);

-- 2. Bảng Túi đồ (Những món người dùng ĐÃ MUA)
-- Đây là bảng trung gian thể hiện người chơi sở hữu cái gì
CREATE TABLE Inventory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ItemId INT FOREIGN KEY REFERENCES StoreItems(Id),
    Quantity INT DEFAULT 1,
    PurchasedAt DATETIME DEFAULT GETDATE()
);

-- CHÈN DỮ LIỆU MẪU CHO CỬA HÀNG
INSERT INTO StoreItems (ItemName, Price, ImageName, Category) VALUES 
(N'Cá hồi thượng hạng', 50, 'item_fish', 'Food'),
(N'Nón cao bồi', 150, 'item_hat', 'Clothes'),
(N'Sữa dâu tăng lực', 30, 'item_milk', 'Food');