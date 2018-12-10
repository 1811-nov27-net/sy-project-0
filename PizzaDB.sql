CREATE DATABASE PizzaDB;
GO

CREATE SCHEMA Pizza;
GO

-- TODO
-- left off at changing Pizza.Store's primary key to Name rather than an INT Id

DROP TABLE Pizza.Users;
DROP TABLE Pizza.Transactions;
DROP TABLE Pizza.TransactionOrder;
DROP TABLE Pizza.Store;
DROP TABLE Pizza.Inventory;
GO

DROP TABLE Pizza.Users;
CREATE TABLE Pizza.Users
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL
);

-- need to change, as one transaction can have a max of 12 pizzas
DROP TABLE Pizza.Transactions;
-- this method, (PizzaId) allows for multiple pizza id's for the same OrderId
CREATE TABLE Pizza.Transactions
(
	OrderId INT IDENTITY(10,10) NOT NULL, -- we don't want it to be unique since each OrderId will have different PizzaId's
	PizzaId INT NOT NULL FOREIGN KEY REFERENCES Pizza.TransactionOrder(Id),
	UserId INT NOT NULL FOREIGN KEY REFERENCES Pizza.Users(Id),
	StoreId INT NOT NULL FOREIGN KEY REFERENCES Pizza.Store(StoreId),
	OrderTime datetime2 NOT NULL
);

-- need to change to accommodate pizza order (maybe)
DROP TABLE Pizza.TransactionOrder;
CREATE TABLE Pizza.TransactionOrder
(
	Id INT IDENTITY(10,10) NOT NULL PRIMARY KEY,
	Size NVARCHAR(50) NOT NULL,
	Topping1 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping2 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping3 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping4 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping5 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Cost MONEY NOT NULL
);

-- Store possibly needs to be reworked with Inventory
DROP TABLE Pizza.Store;
-- using this one, Inventory needs to be reworked so that ingredients and prices are unique
-- predefined total stock of items in store, decreases no matter what kind of ingredient
CREATE TABLE Pizza.Store
(
	--StoreId INT IDENTITY(100,100) NOT NULL PRIMARY KEY, -- we don't even need this, the name should be unique and serve as the primary key
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Pizza.TransactionOrder(Id),
	Name NVARCHAR(100) NOT NULL,
	-- InventoryId INT IDENTITY(100,100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(Id), -- not even necessary since Inventory only supplies 
	-- ingredient name and price
	Stock INT NULL
);

-- Inventory needs to be reworked
DROP TABLE Pizza.Inventory;
CREATE TABLE Pizza.Inventory
(
	-- no numerical ID since each ingredient is unique in itself
	IngredientName NVARCHAR(100) NOT NULL PRIMARY KEY, -- '' (empty) represents no topping, has 0 cost
	Price Money
);

GO

-- input basic data here

-- first create default values for each table, i.e. default store, user, order(s) (for order history)
-- create a user
INSERT INTO Pizza.Users (FirstName, LastName) VALUES
	('John', 'Smith'); -- has ID of 1
SELECT * FROM Pizza.Users;

-- NEEDS TO BE REDONE, EACH INGREDIENT HAS A UNIQUE ID ********************************************************************
-- create an inventory for a pizza store
INSERT INTO Pizza.Inventory (IngredientName, Stock, Price) VALUES
	('Pepperoni', 25, 0.50),
	('Sausage', 25, 0.50),
	('Chicken', 25, 0.50),
	('Mushrooms', 25, 0.30),
	('Black Olives', 25, 0.30),
	('Jalapenos', 25, 0.30),
	('Bell Peppers', 25, 0.30),
	('Onions', 25, 0.30),
	('Pineapple', 25, 0.30); -- should have ID of 100
SELECT * FROM Pizza.Inventory;

-- create a pizza store
-- Id 100 is Pizza Hut
INSERT INTO Pizza.Store (Name, InventoryId) VALUES
	('Pizza Hut', 100); -- has ID of 100

-- create an order
-- sizes are L ($12), M($10), S($8)
INSERT INTO Pizza.TransactionOrder (Size, Topping1, Topping2, Topping3, Topping4, Topping5, Cost) VALUES
	('L', 'Pepperoni', 'Mushrooms', 'Black Olives', 'Jalapenos', 'Onions', 13.70); -- has ID of 10

-- create a transaction (link between store, user, and pizza transaction order
INSERT INTO Pizza.Transactions (UserId, StoreId, OrderTime) VALUES
	(1, 100, GETDATE());