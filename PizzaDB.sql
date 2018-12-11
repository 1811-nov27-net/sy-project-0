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

CREATE TABLE Pizza.Users
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL
);

-- Inventory needs to be reworked
CREATE TABLE Pizza.Inventory
(
	-- no numerical ID since each ingredient is unique in itself
	IngredientName NVARCHAR(100) NOT NULL PRIMARY KEY, -- '' (empty) represents no topping, has 0 cost
	Price Money
);

-- need to change to accommodate pizza order (maybe)
CREATE TABLE Pizza.TransactionOrder
(
	PizzaId INT IDENTITY(10,10) NOT NULL PRIMARY KEY,
	Size NVARCHAR(50) NOT NULL,
	Topping1 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping2 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping3 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping4 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Topping5 NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(IngredientName),
	Cost MONEY NOT NULL
);

-- Store possibly needs to be reworked with Inventory
-- using this one, Inventory needs to be reworked so that ingredients and prices are unique
-- predefined total stock of items in store, decreases no matter what kind of ingredient
CREATE TABLE Pizza.Store
(
	--StoreId INT IDENTITY(100,100) NOT NULL PRIMARY KEY, -- we don't even need this, the name should be unique and serve as the primary key
	Name NVARCHAR(100) NOT NULL PRIMARY KEY,
	OrderId INT NULL FOREIGN KEY REFERENCES Pizza.TransactionOrder(PizzaId), -- set to NULL so we can declare a store with no orders
	-- InventoryId INT IDENTITY(100,100) NOT NULL FOREIGN KEY REFERENCES Pizza.Inventory(Id), -- not even necessary since Inventory only supplies 
	-- ingredient name and price
	Stock INT NULL
);

-- need to change, as one transaction can have a max of 12 pizzas
-- this method, (PizzaId) allows for multiple pizza id's for the same OrderId
CREATE TABLE Pizza.Transactions
(
	OrderId INT IDENTITY(10,10) NOT NULL, -- we don't want it to be unique since each OrderId will have different PizzaId's
	PizzaId INT NOT NULL FOREIGN KEY REFERENCES Pizza.TransactionOrder(PizzaId),
	UserId INT NOT NULL FOREIGN KEY REFERENCES Pizza.Users(Id),
	StoreName NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Pizza.Store(Name),
	OrderTime datetime2 NOT NULL
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
INSERT INTO Pizza.Inventory (IngredientName, Price) VALUES
	('Pepperoni', 3),
	('Sausage', 3),
	('Chicken', 3),
	('Mushrooms', 2),
	('Black Olives', 2),
	('Jalapenos', 2),
	('Bell Peppers', 2),
	('Onions', 2),
	('Pineapple', 1),
	('Extra Cheese', 4),
	('',0); -- represents no topping, with 0 cost
SELECT * FROM Pizza.Inventory;

-- create an order
-- sizes are L ($40), M($35), S($30)
-- why are these pizzas so expensive? because user can order max 12 pizzas, however cost must not exceed $500
-- "Cost" should be a function that will automatically take the cost of ingredients and add them
INSERT INTO Pizza.TransactionOrder (Size, Topping1, Topping2, Topping3, Topping4, Topping5, Cost) VALUES
	('L', 'Pepperoni', 'Mushrooms', 'Black Olives', 'Jalapenos', 'Onions', 51); -- has ID of 10
SELECT * FROM Pizza.TransactionOrder;

-- create a pizza store
-- has a total aggregate of 50 ingredients, decreases anytime an ingredient is added
INSERT INTO Pizza.Store (Name, OrderId, Stock) VALUES
	('Pizza Hut', 10, 50); -- we put 10 as the ID since we created an order beforehand
SELECT * FROM Pizza.Store;

-- create a transaction (link between store, user, and pizza transaction order
INSERT INTO Pizza.Transactions (PizzaId, UserId, StoreName, OrderTime) VALUES
	(10, 1, 'Pizza Hut', GETDATE()); -- pizzaID = 10, userID = 1, store = Pizza Hut, get current date and time
SELECT * FROM Pizza.Transactions;