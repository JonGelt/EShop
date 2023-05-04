CREATE DATABASE SEBDB;

USE SEBDB;

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    Name VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(50),
    Price DECIMAL(10,2),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME,
    TotalPrice DECIMAL(10,2)
);

CREATE TABLE OrderDetails (
    OrderID INT,
    ProductID INT,
    Quantity INT,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Categories(CategoryID, Name) VALUES 
(1, 'Beverages'),
(2, 'Food'),
(3, 'Accessories');

INSERT INTO Products (ProductID, Name, Price, CategoryID) VALUES 
(1, 'Bottled water', 0.99, 1),
(2, 'Orange juice', 2.49, 1),
(3, 'Milk', 1.29, 1),
(4, 'Coca-Cola', 1.49, 1),
(5, 'Sprite', 1.49, 1),
(6, 'Soda', 5.99, 1),
(7, 'Energy drink', 1.99, 1),
(8, 'Juice', 2.49, 1),
(9, 'Lemonade', 3.29, 1),
(10, 'Iced tea', 6.99, 1),
(11, 'Bread', 2.99, 2),
(12, 'Pasta', 4.99, 2),
(13, 'Cereal', 3.99, 2),
(14, 'Butter', 2.00, 3),
(15, 'Jam', 2.50, 3),
(16, 'Sugar', 1.99, 3),
(17, 'Salt', 2.49, 3),
(18, 'Pepper', 1.49, 3);



SELECT Products.ProductID, Products.Name, Products.Price, Categories.Name AS Category
FROM Products
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID;

SELECT Name, CategoryID, COUNT(*) as Count FROM Categories GROUP BY CategoryID, Name