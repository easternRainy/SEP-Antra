USE AdventureWorks2019
GO

-- 1. How many products can you find in the Production.Product table?
SELECT COUNT(ProductID) AS PdtNum
FROM Production.Product

-- 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductSubcategoryID) AS SubNum
FROM Production.Product

-- 3. How many Products reside in each SubCategory? 
SELECT ProductSubcategoryID, COUNT(ProductID) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID

-- 4. How many products that do not have a product subcategory. 
SELECT COUNT(ProductID) AS NoSubNum
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS SumQuant
FROM Production.ProductInventory

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

-- 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID 
HAVING SUM(Quantity) < 100


-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductSubcategoryID

-- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf

-- 10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg 
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf


-- 11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*) AS TheCOUNT, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class


-- 12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. 
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion AS c 
JOIN Person.StateProvince AS s 
ON c.CountryRegionCode = s.CountryRegionCode

-- 13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion AS c 
JOIN Person.StateProvince AS s 
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')


USE Northwind
GO 

-- 14. List all Products that has been sold at least once in last 25 years.
SELECT DISTINCT p.ProductID, p.ProductName
FROM Orders o 
JOIN [Order Details] d 
ON o.OrderID = d.OrderId
JOIN Products p 
ON p.ProductID = d.ProductID 
WHERE DATEDIFF(YEAR, o.OrderDate, GETDATE()) < 25


-- 15. List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS OrderNum
FROM Orders o 
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY ShipPostalCode
ORDER BY OrderNum DESC

-- 16. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS OrderNum
FROM Orders o 
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
WHERE 
	o.ShipPostalCode IS NOT NULL AND  
	DATEDIFF(YEAR, o.OrderDate, GETDATE()) < 25
GROUP BY ShipPostalCode
ORDER BY OrderNum DESC


-- 17. List all city names and number of customers in that city.
SELECT City, COUNT(CustomerID) AS NumCus
FROM Customers
WHERE City IS NOT NULL
GROUP BY City

-- 18. List city names which have more than 2 customers, and number of customers in that city 
SELECT City, COUNT(CustomerID) AS NumCus
FROM Customers
WHERE City IS NOT NULL
GROUP BY City
HAVING COUNT(CustomerID) > 2

-- 19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName
FROM Customers c 
JOIN Orders o 
ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'


-- 20. List the names of all customers with most recent order dates 
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c 
JOIN Orders o 
ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName


-- 21. Display the names of all customers  along with the  count of products they bought 

SELECT c.ContactName, SUM(ISNULL(od.Quantity, 0)) AS PdtCount
FROM Customers c 
LEFT JOIN Orders o 
ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od 
ON od.OrderID = o.OrderID
GROUP BY c.ContactName



-- 22. Display the customer ids who bought more than 100 Products with count of products.

SELECT c.CustomerID
FROM Customers c 
LEFT JOIN Orders o 
ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od 
ON od.OrderID = o.OrderID
GROUP BY c.CustomerID
HAVING SUM(ISNULL(od.Quantity, 0)) > 100

-- 23. List all of the possible ways that suppliers can ship their products.

SELECT 
	su.CompanyName AS [Supplier Company Name],
	sh.CompanyName AS [Shipping Company Name]
FROM Orders o 
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
JOIN Products p 
ON p.ProductID = od.ProductID 
JOIN Suppliers su  
ON p.SupplierID = su.SupplierID 
JOIN Shippers sh  
ON o.ShipVia = sh.ShipperID


-- 24. Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o 
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
JOIN Products p 
ON p.ProductID = od.ProductID 
GROUP BY o.OrderDate, p.ProductName

-- 25. Displays pairs of employees who have the same job title
SELECT 
	e1.LastName + ' ' + e1.FirstName AS Name1,
	e2.LastName + ' ' + e2.LastName AS Name2
FROM Employees e1 
JOIN Employees e2 
ON 
	e1.EmployeeId != e2.EmployeeId AND
	e1.Title = e2.Title


-- 26. Display all the Managers who have more than 2 employees reporting to them.

SELECT m.EmployeeID, m.LastName, m.FirstName, e.ReportsTo, COUNT(e.ReportsTo) AS NumRep
FROM Employees m
JOIN Employees e 
ON e.ReportsTo = m.EmployeeID
WHERE e.ReportsTo IS NOT NULL 
GROUP BY m.EmployeeID, m.LastName, m.FirstName, e.ReportsTo
HAVING COUNT(e.ReportsTo) > 2

-- 27. Display the customers and suppliers by city. The results should have the following columns

SELECT
	c.City, c.CompanyName, c.ContactName AS Name, 'Customer' AS Type
FROM Customers c 
UNION (
	SELECT
		s.City, s.CompanyName, s.ContactName AS Name, 'Supplier' AS Type
	FROM Suppliers s
)
