USE Northwind
GO
-- 1. List all cities that have both Employees and Customers.
SELECT DISTINCT City
FROM Customers
INTERSECT (
	SELECT DISTINCT City
	FROM Employees
)

-- 2. List all cities that have Customers but no Employee.
---- (a) Use Sub Query
SELECT DISTINCT City
FROM Customers
WHERE City NOT IN (
	SELECT DISTINCT City FROM Employees
	WHERE City IS NOT NULL
)

---- (b) Do not use Sub Query
SELECT DISTINCT City
FROM Customers
EXCEPT (
	SELECT DISTINCT City
	FROM Employees
)

-- 3. List all products and their total order quantities throughout all orders.
SELECT od.ProductId, p.ProductName, SUM(od.Quantity) AS SunQuant
FROM [Order Details] od 
JOIN [Products] p 
ON od.ProductID = p.ProductID
GROUP BY od.ProductID, p.ProductName

-- 4. List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS SumQuant
FROM [Order Details] od
JOIN [Orders] o
ON od.OrderID = o.OrderID
JOIN [Customers] c
ON c.CustomerID = o.CustomerID
GROUP BY c.City


-- 5. List all Customer Cities that have at least two customers.


---- (a) use UNION ?
SELECT City 
FROM Customers 
EXCEPT (
	SELECT City  
	FROM Customers  
	GROUP BY City  
	HAVING COUNT(*) = 1
	UNION (
		SELECT City 
		FROM Customers 
		GROUP BY City 
		HAVING COUNT(*) = 0
	)
)

---- (b) Use SubQuery
SELECT City 
FROM Customers 
GROUP BY City 
HAVING COUNT(*) >= 2

-- 6. List all Customer Cities that have ordered at least two different kinds of products.


SELECT c.City, COUNT(DISTINCT od.ProductID) AS NumPdt
FROM [Order Details] od
JOIN [Orders] o
ON od.OrderID = o.OrderID
JOIN [Customers] c
ON c.CustomerID = o.CustomerID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2


-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.CustomerID, c.ContactName 
FROM [Order Details] od
JOIN [Orders] o
ON od.OrderID = o.OrderID
JOIN [Customers] c
ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity


-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
--- a. not use CTE
SELECT TOP 5  
	ProductID,
	AVG(UnitPrice) AS AvgPrice, 
	(	
		SELECT TOP 1 City 
		FROM Customers c  
		JOIN Orders o 
		ON o.CustoemrID = c.CustomerID 
		JOIN [Order Details] od2 
		ON od2.OrderID = o.OrderID  
		WHERE od2.ProducID = od1.ProductID  
		GROUP BY City 
		ORDER BY SUM(Quantity) DESC

	) AS City
FROM [Order Details] od1 
GROPU BY ProductID
ORDER BY Sum(Quantity) DESC


--- b. use CTE
WITH join_table AS (
	SELECT DISTINCT
		od.ProductID, p.ProductName, p.UnitPrice, o.CustomerID, c.City
	FROM [Order Details] od
	JOIN [Orders] o
	ON od.OrderID = o.OrderID
	JOIN [Customers] c
	ON c.CustomerID = o.CustomerID
	JOIN Products p 
	ON p.ProductID = od.ProductID
),

product_count AS (
	SELECT ProductID, ProductName, COUNT(*) AS PdtCount
	FROM join_table
	GROUP BY ProductID, ProductName
	
),

avg_price AS (
	SELECT ProductID, ProductName, AVG(UnitPrice) AS AvgPrice
	FROM join_table
	GROUP BY ProductID, ProductName
),

city_order AS (
	SELECT 
		ProductId, ProductName, City, COUNT(*) AS CityCount
	FROM join_table
	GROUP BY ProductId, ProductName, City
),

most_city AS (
	SELECT DISTINCT
		ProductId, ProductName, 
		FIRST_VALUE(City) OVER (PARTITION BY ProductId, ProductName ORDER BY CityCount DESC) AS FirstCity
	FROM city_order
)

SELECT TOP 5 pc.ProductID, pc.ProductName, mc.FirstCity
FROM product_count pc
JOIN most_city mc
ON pc.ProductID = mc.ProductID AND pc.ProductName = mc.ProductName
ORDER BY pc.PdtCount DESC


-- 9. List all cities that have never ordered something but we have employees there.

--- a. not use CTE
SELECT DISTINCT City  
FROM Employees 
WHERE City NOT IN (
	SELECT ShipCity FROM Orders 
	WHERE ShipCity IS NOT NULL
)

---

SELECT DISTINCT City 
FROM Customers  
WHERE City IS NOT NULL 
EXCEPT (
	SELECT DISTINCT ShipCity 
	FROM Orders  
	WHERE ShipCity IS NOT NULL
)


-- 10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. 
-- ?

SELECT  
	(	
		SELECT TOP 1 City 
		FROM Orders o 
		JOIN [Order Details] od  
		ON o.OrderID = od.OrderID  
		JOIN Employees e  
		ON e.EmployeeID = o.EmployeeID  
		GROUP BY e.EmployeeID, e.City 
		ORDER BY COUNT(*) DESC
	) AS MostOrderedCity,
	(
		SELECT TOP 1 City 
		FROM Orders o 
		JOIN [Order Details] od  
		ON o.OrderID = od.OrderID  
		JOIN Employees e  
		ON e.EmployeeID = o.EmployeeID  
		GROUP BY e.EmployeeID, e.City 
		ORDER BY SUM(Quantity) DESC

	) AS MostQuantitySoldCity

-- 11. How do you remove the duplicates record of a table?

---- Use SELECT DISTINCT 
---- Use GROUP BY and COUNT(*) if COUNT(*) > 1 then delete the rows using sub query


-- 12.  Find employees who do not manage anybody.
SELECT 
	empid, mgrid, deptid, salary
FROM Employee 
WHERE empid NOT IN (
	SELECT mgrid FROM Employee
)

-- 13. Find departments that have maximum number of employees.

-- not use CTE
SELECT deptid  
FROM Employee  
GROUP BY deptid 
HAVING COUNT(*) = (
	SELECT TOP 1 COUNT(*)
	FROM Employee 
	GROUP BY deptid 
	ORDER BY COUNT(*) DESC
)

-- use CTE
WITH join_table AS (
	SELECT
		d.deptid, d.deptname, e.empid
	FROM Dept d 
	JOIN Employee e 
	ON d.deptid = e.deptid 
),

dept_count AS (
	SELECT deptid, deptname, COUNT(*) AS EmpCount
	FROM join_table
	GROUP BY deptid, deptname
),

dept_rank AS (
	SELECT 
		deptid, deptname, EmpCount, 
		RANK() OVER (ORDER BY EmpCount DESC) AS r 
	FROM dept_count
)

SELECT deptname, EmpCount
FROM dept_rank
WHERE r = 1
ORDER BY deptname

-- 14. Find top 3 employees (salary based) in every department. Result should have deptname, empid, salary sorted by deptname and then employee with high to low salary.


WITH join_table AS (
	SELECT
		d.deptid, d.deptname, e.empid, e.salary
	FROM Dept d 
	JOIN Employee e 
	ON d.deptid = e.deptid 
),

salary_rank AS (
	SELECT
		deptid, deptname, empid, salary,
		DENSE_RANK() OVER (PARTITION BY deptid, deptname ORDER BY salary DESC) AS r
	FROM join_table
)

SELECT deptname, empid, salary 
FROM salary_rank 
WHERE r <= 3 
ORDER BY deptname, salary DESC















