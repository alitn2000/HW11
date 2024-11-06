select p.Name , p.Price
from Products p
where p.Price >500
------------------
select YEAR(o.OrderDate) as Year, SUM(o.TotalAmount) as year_sales
from Orders o
group by Year(o.OrderDate)

------------------
SELECT 
    c.Name AS CategoryName,
    SUM(o.TotalAmount) AS TotalSales
FROM 
    Orders o
JOIN 
    Products p ON o.ProductId = p.Id
JOIN 
    Categories c ON p.CategoryId = c.Id
GROUP BY 
    c.Name

select p.Name , p.Price
from Products p order by p.Price desc 

------------------
SELECT 
    c.Name AS CustomerName,
    COUNT(o.Id) AS OrderCount
FROM 
    Customers c
JOIN 
    Orders o ON c.Id = o.CustomerId
GROUP BY 
    c.Name

------------------
SELECT 
    c.Name AS CategoryName,
    AVG(p.Price) AS AveragePrice
FROM 
    Products p
JOIN 
    Categories c ON p.CategoryId = c.Id
GROUP BY 
    c.Name

------------------
SELECT 
    p.Name AS ProductName,
    c.Name AS CategoryName
FROM 
    Products p
JOIN 
    Categories c ON p.CategoryId = c.Id
ORDER BY 
    p.Name ASC,c.Name ASC

------------------
SELECT 
    c.Name AS CategoryName,
    SUM(o.TotalAmount) AS TotalSales
FROM 
    Orders o
JOIN 
    Products p ON o.ProductId = p.Id
JOIN 
    Categories c ON p.CategoryId = c.Id
WHERE 
    YEAR(o.OrderDate) = 2023
GROUP BY 
    c.Name

------------------
SELECT 
    c.Name AS CategoryName,
    SUM(o.TotalAmount) AS TotalSales
FROM 
    Orders o
JOIN 
    Products p ON o.ProductId = p.Id
JOIN 
    Categories c ON p.CategoryId = c.Id
WHERE 
    YEAR(o.OrderDate) = 2023
GROUP BY 
    c.Name;

------------------
SELECT 
    MONTH(o.OrderDate) AS OrderMonth,
    COUNT(o.Id) AS OrderCount
FROM 
    Orders o
GROUP BY 
    MONTH(o.OrderDate)
ORDER BY 
    OrderMonth

------------------
SELECT 
    c.Name AS CustomerName,
    SUM(o.TotalAmount) AS TotalSales
FROM 
    Customers c
JOIN 
    Orders o ON c.Id = o.CustomerId
GROUP BY 
    c.Name

------------------
SELECT 
    c.Name AS CategoryName,
    COUNT(o.Id) AS OrderCount
FROM 
    Orders o
JOIN 
    Products p ON o.ProductId = p.Id
JOIN 
    Categories c ON p.CategoryId = c.Id
GROUP BY 
    c.Name

------------------
SELECT 
    c.Name AS CustomerName,
    COUNT(o.Id) AS OrderCount
FROM 
    Customers c
JOIN 
    Orders o ON c.Id = o.CustomerId
GROUP BY 
    c.Name
ORDER BY 
    OrderCount DESC

------------------
SELECT 
    YEAR(o.OrderDate) AS OrderYear,
    COUNT(o.Id) AS OrderCount
FROM 
    Orders o
GROUP BY 
    YEAR(o.OrderDate)
ORDER BY 
    OrderYear
------------------
SELECT 
    p.Name AS ProductName,
    COUNT(DISTINCT o.CustomerId) AS BuyerCount
FROM 
    Products p
JOIN 
    Orders o ON p.Id = o.ProductId
GROUP BY 
    p.Name
ORDER BY 
    BuyerCount DESC;