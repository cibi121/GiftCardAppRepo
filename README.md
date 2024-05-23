Below are the tables used for the DB structure

Idea is to create 5 tables

-- Users Table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    Address NVARCHAR(200) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- DeliveryOptions Table
CREATE TABLE DeliveryOptions (
    DeliveryOptionID INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryType NVARCHAR(50) NOT NULL,
    Cost DECIMAL(10, 2) NOT NULL
);

-- Orders Table
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    DeliveryOptionID INT NOT NULL,
    DeliveryAddress NVARCHAR(200) NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CreditCardSurcharge DECIMAL(10, 2) NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (DeliveryOptionID) REFERENCES DeliveryOptions(DeliveryOptionID)
);

-- GiftCards Table
CREATE TABLE GiftCards (
    GiftCardID INT IDENTITY(1,1) PRIMARY KEY,
    FaceValue DECIMAL(10, 2) NOT NULL CHECK (FaceValue BETWEEN 10 AND 200),
    Message NVARCHAR(200),
    ServiceCost DECIMAL(10, 2) NOT NULL DEFAULT 2.95
);

-- OrderGiftCards Table
CREATE TABLE OrderGiftCards (
    OrderGiftCardID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    GiftCardID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (GiftCardID) REFERENCES GiftCards(GiftCardID)
);
