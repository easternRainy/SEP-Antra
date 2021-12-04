-- 1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.

CREATE VIEW view_product_order_Zhou
AS
SELECT ProductID, SUM(Quantity) AS SumQuant
FROM [Order Details]
GROUP BY ProductID
ORDER BY SumQuant

-- 2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.

CREATE PROC sp_product_order_quantity_Zhou
@PID INT,
@SQ INT OUT
AS
BEGIN
SELECT @SQ = SumQuant
FROM (
	SELECT ProductID, SUM(Quantity) AS SumQuant
	FROM [Order Details]
	GROUP BY ProductID
) AS sq 
WHERE ProductID = @PID
END

-- 3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.

CREATE PROC sp_product_order_city_Zhou
@PName VARCHAR(20)
AS
BEGIN

SELECT TOP 5
	c.City, Sum(od.Quantity) AS SumQuant
FROM Orders o 
JOIN [Order Details] od 
ON o.OrderID = od.OrderID 
JOIN Customers c 
ON c.CustomerID = o.CustomerID 
JOIN Products p 
ON p.ProductID = o.ProductID
WHERE p.ProductName = @PName
GROUP BY p.ProductName, c.City 
ORDER BY Sum(od.Quantity) DESC

END

-- 4. 

CREATE TABLE city_Zhou (
	Id INT PRIMARY KEY,
	City VARCHAR(20) NOT NULL
)

CREATE TABLE people_Zhou (
	Id INT PRIMARY KEY,
	Name VARCHAR(20),
	City INT FOREIGN KEY REFERENCES city_Zhou(Id) ON DELETE SET 3
)

INSERT INTO city_Zhou VALUES (1, 'Seattle')
INSERT INTO city_Zhou VALUES (2, 'Green Bay')

INSERT INTO people_Zhou VALUES (1, 'Aaron Rodgers', 2)
INSERT INTO people_Zhou VALUES (2, 'Russel Wilson', 1)
INSERT INTO people_Zhou VALUES (3, 'Jody Nelson', 2)

INSERT INTO city_Zhou Values (3, 'Madison')

-- Delete 'Seattle'
DELETE FROM city_Zhou
WHERE id = 1

CREATE VIEW Packers_Zhou 
AS 
SELECT p.Name
FROM people_Zhou p 
JOIN city_Zhou c 
ON p.City = c.Id 
WHERE c.City = 'Green Bay'


-- 5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
CREAE PROC sp_birthday_employees_Zhou
AS
BEGIN
SELECT LastName, FirstName, BirthDate
FROM Employees 
WHERE MONTH(BirthDate) = 2
END


-- 6. How do you make sure two tables have the same data?
---- Which two table?
SELECT CHECKSUM_AGG(BINARY_CHECKSUM(*))
FROM Table1
UNION
SELECT CHECKSUM_AGG(BINARY_CHECKSUM(*))
FROM Table2

-- Compare if the hashes are the same.



