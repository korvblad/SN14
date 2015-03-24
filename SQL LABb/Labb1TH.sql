USE AdventureWorks2012;
--*** LABB 1 ***--

--1.1--

SELECT ProductID
	,	Name
	,	Color
	,	ListPrice

FROM Production.Product;


--1.2--

SELECT ProductID
	,	Name
	,	Color
	,	ListPrice

FROM Production.Product
WHERE ListPrice > 0;

--1.3--

SELECT ProductID
	,	Name
	,	Color
	,	ListPrice

FROM Production.Product
WHERE Color IS NULL;

--1.4--

SELECT ProductID
	,	Name
	,	Color
	,	ListPrice

FROM Production.Product
WHERE Color IS NOT NULL;

--1.5--

SELECT ProductID
	,	Name
	,	Color
	,	ListPrice

FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0;

--1.6--

SELECT ProductID 
	,	Name  + ' ' + Color AS 'Name and Color'
	,	ListPrice

FROM Production.Product
WHERE Color IS NOT NULL;

--1.7--

SELECT ProductID 
	,	'NAME:' + ' ' + Name + ' -- ' + 'COLOR:' + ' ' + Color 
	,	ListPrice

FROM Production.Product
WHERE Color IS NOT NULL;

--1.8--

SELECT ProductID
	, Name

FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500;

--1.9--

SELECT ProductID
	, Name
	, Color

FROM Production.Product
WHERE Color = 'Blue' OR Color = 'Black';

--1.10--

SELECT Name
	, ListPrice

FROM Production.Product
WHERE Name LIKE 'S%';

--1.11--

SELECT Name
	, ListPrice

FROM Production.Product
WHERE Name LIKE 'S%' OR Name LIKE 'A%'

--1.12--
SELECT Name
	, ListPrice

FROM Production.Product
WHERE Name LIKE 'SPO[^k]%' 

--1.13--

SELECT DISTINCT Color

FROM Production.Product
WHERE Color IS NOT NULL
ORDER BY Color;

--1.14--

SELECT ProductSubcategoryID
	, Color

FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL AND Color IS NOT NULL
ORDER BY ProductSubcategoryID ASC
, Color DESC;


--1.15--

SELECT ProductSubCategoryID
 , LEFT([Name],35) AS [Name]
 , Color, ListPrice
FROM Production.Product
WHERE Color IN ('Red','Black')
 AND ListPrice BETWEEN 1000 AND 2000
 AND ProductSubCategoryID = 1
ORDER BY ProductID;

--1.16--


SELECT Name
	,  ISNULL(Color, 'Unknown') AS Color
	, ListPrice

FROM Production.Product;



--2.1--
SELECT SUM(ProductID) AS 'ANTAL PRODUKTER'
FROM Production.Product ;

--2.2--

SELECT COUNT(ProductSubcategoryID) AS 'Antal subprodukter'
FROM Production.Product 



--2.3--

SELECT ProductSubcategoryID, COUNT(*) AS 'Antal produkter i subkategorier'
FROM Production.Product
GROUP BY ProductSubcategoryID

--2.4--


SELECT COUNT(*) - COUNT(ProductSubcategoryId) AS 'Antal produkter som inte ingår i subkategorier'	
FROM Production.Product 
SELECT COUNT(ProductID) AS 'Antal produkter som inte ingår i subkategorier'
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

--2.5--

SELECT ProductID
	, SUM(Quantity) AS 'Antal produkter'
FROM Production.ProductInventory
GROUP BY ProductID;

--2.6--

SELECT ProductID
	, SUM(Quantity) AS 'Antal produkter'
FROM Production.ProductInventory
WHERE LocationID = 40 --AND Quantity < 100
GROUP BY ProductID, Quantity
HAVING Quantity < 100;

--2.7--
SELECT ProductID
	, SUM(Quantity) AS 'Antal produkter'
	, Shelf AS 'Hyllplan'
FROM Production.ProductInventory
WHERE LocationID = 40 --AND Quantity < 100
GROUP BY ProductID, Quantity, Shelf
HAVING Quantity < 100;

--2.8--
SELECT LocationID AS 'PlatsID'
	, AVG(Quantity) AS 'Medelantal'
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY LocationID;

--2.9--
SELECT ROW_NUMBER ()
	OVER( ORDER BY Name) AS 'Radnummer'
	, Name as 'Kategori'	
FROM Production.ProductCategory

 
 --3.1--
 SELECT CNTR.Name AS 'Country'
	, PRVNS.Name AS 'Province'
FROM Person.CountryRegion AS CNTR
	INNER JOIN Person.StateProvince AS PRVNS
	ON CNTR.CountryRegionCode = PRVNS.CountryRegionCode
ORDER BY CNTR.Name, PRVNS.Name ASC;

--3.2--
 SELECT PCR.Name AS 'Country'
	, PSP.Name AS 'Province'
FROM Person.CountryRegion AS PCR
	INNER JOIN Person.StateProvince AS PSP
	ON PCR.CountryRegionCode = PSP.CountryRegionCode
WHERE PCR.Name IN ('Germany', 'Canada')
ORDER BY PCR.Name, PSP.Name ASC;

--3.3--

SELECT SalesOrderId 'Sales Order'
	, OrderDate 'Datum'
	, SalesPersonID AS ' PersonID'
	, BusinessEntityID AS 'PersonID'
	, Bonus AS 'Bonus'
	, SalesYTD AS 'Sålt för detta år'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP
	ON SP.BusinessEntityID = SOH.SalesPersonID;

--3.4--
SELECT SalesOrderId 'Sales Order'
	, OrderDate 'Datum'
	, Bonus AS 'Bonus'
	, SalesYTD AS 'Sålt för detta år'
	, JobTitle AS 'Jobbtitel'
	

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP
	ON SP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN HumanResources.Employee AS HR
	ON HR.BusinessEntityID = SP.BusinessEntityID;

--3.5--
SELECT SalesOrderId 'Sales Order'
	, OrderDate 'Datum'
	, Bonus AS 'Bonus'
	, FirstName AS 'Förnamn'
	, LastName AS 'Efternamn'
	
	

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP
	ON SP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN HumanResources.Employee AS HR
	ON HR.BusinessEntityID = SP.BusinessEntityID
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = HR.BusinessEntityID

--3.6--
SELECT SalesOrderId 'Sales Order'
	, OrderDate 'Datum'
	, Bonus AS 'Bonus'
	, FirstName AS 'Förnamn'
	, LastName AS 'Efternamn'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP
	ON SP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = SP.BusinessEntityID

--3.7--

SELECT SalesOrderId 'Sales Order'
	, OrderDate 'Datum'
	, FirstName AS 'Förnamn'
	, LastName AS 'Efternamn'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = SOH.SalesPersonID

--3.8--

SELECT SOH.SalesOrderID 'Sales Order'
	, OrderDate 'Datum'
	, FirstName + ' ' + LastName AS 'SalesPerson'
	, ProductID AS 'ProduktID'
	, OrderQty AS 'Antal ordrar'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN Sales.SalesOrderDetail AS SOD
	ON SOD.SalesOrderID = SOH.SalesOrderID
	ORDER BY OrderDate desc, SOH.SalesOrderID;

--3.9--
SELECT SOH.SalesOrderID 'Sales Order'
	, OrderDate 'Datum'
	, FirstName + ' ' + LastName AS 'SalesPerson'
	, Prod.Name AS 'Produkt'
	, OrderQty AS 'Antal ordrar'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN Sales.SalesOrderDetail AS SOD
	ON SOD.SalesOrderID = SOH.SalesOrderID
	INNER JOIN Production.Product AS Prod
	ON Prod.ProductID = SOD.ProductID
	ORDER BY OrderDate desc, SOH.SalesOrderID;

--3.10--
SELECT SOH.SalesOrderID 'Sales Order'
	, OrderDate 'Datum'
	, FirstName + ' ' + LastName AS 'SalesPerson'
	, Prod.Name AS 'Produkt'
	, OrderQty AS 'Antal ordrar'

FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = SOH.SalesPersonID
	INNER JOIN Sales.SalesOrderDetail AS SOD
	ON SOD.SalesOrderID = SOH.SalesOrderID
	INNER JOIN Production.Product AS Prod
	ON Prod.ProductID = SOD.ProductID

	WHERE SubTotal > 100000  AND OrderDate BETWEEN '2006' AND '2007'
	ORDER BY OrderDate DESC, SOH.SalesOrderID;

--3.11--
 SELECT CR.Name AS 'Country'
		, SP.Name AS 'Province'

FROM Person.CountryRegion AS CR
	FULL JOIN Person.StateProvince AS SP
		ON SP.CountryRegionCode = CR.CountryRegionCode
	ORDER BY CR.Name, SP.Name ASC;

--3.12--
SELECT CUST.CustomerID AS 'CustomerID'
FROM Sales.Customer AS CUST
	FULL JOIN Sales.SalesOrderHeader AS SOH
	ON SOH.CustomerID = CUST.CustomerID
	WHERE SOH.PurchaseOrderNumber IS NULL
	ORDER BY CustomerID ASC;

--3.13--

SELECT PP.Name AS 'Produktnamn'
	, PM.Name AS 'Modellnamn'
FROM  Production.Product AS PP
	FULL JOIN Production.ProductModel AS PM 
	ON PP.ProductModelID = PM.ProductModelID
WHERE PP.Name IS NULL OR PM.Name IS NULL

--3.14--

SELECT PP.FirstName + ' ' + PP.LastName  AS 'Namn'
	, SOH.SalesPersonID AS 'Sälj ID'
	, COUNT(SOH.SalesOrderID) AS 'Antal Ordrar'
	, SUM(SOH.SubTotal) AS 'Totalsumma'

FROM Sales.SalesPerson AS SP
	INNER JOIN HumanResources.Employee AS HRE
	ON HRE.BusinessEntityID = SP.BusinessEntityID
	INNER JOIN Person.Person AS PP
	ON PP.BusinessEntityID = HRE.BusinessEntityID 
	INNER JOIN Sales.SalesOrderHeader AS SOH
	ON SOH.SalesPersonID = SP.BusinessEntityID

GROUP BY SOH.SalesPersonID, PP.FirstName + ' ' + PP.LastName

--3.15--

SELECT ST.Name AS 'Region'
	, DATEPART(YEAR, SOH.OrderDate) AS 'År'
	, SUM(SOH.SubTotal) AS 'Totalsumma'


FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesTerritory AS ST
	ON ST.TerritoryID = SOH.TerritoryID
	
GROUP BY DATEPART(YEAR, SOH.OrderDate), ST.Name
ORDER BY DATEPART(YEAR, SOH.OrderDate), ST.Name

--3.16--

SELECT FirstName + ' ' + LastName AS 'Namn'
	, COUNT(EDH.DepartmentID) AS 'Antal Avdelningar'


FROM Person.Person AS PP
	INNER JOIN HumanResources.Employee AS HR
	ON HR.BusinessEntityID = PP.BusinessEntityID
	INNER JOIN HumanResources.EmployeeDepartmentHistory AS EDH
	ON EDH.BusinessEntityID = HR.BusinessEntityID
GROUP BY FirstName + ' ' + LastName
HAVING COUNT(EDH.DepartmentID) > 1

--3.17--

SELECT MIN(Subtotal) AS 'Lägsta'
FROM Sales.SalesOrderHeader

UNION

SELECT MAX(Subtotal) AS 'Högsta'
FROM Sales.SalesOrderHeader

UNION

SELECT AVG(Subtotal) AS 'Medelvärde'
FROM Sales.SalesOrderHeader

--3.18--
SELECT TOP 10(ListPrice) AS '10 Dyraste'
	, Name

FROM Production.Product
ORDER BY ListPrice DESC


--3.19--


SELECT TOP 1 PERCENT DaysToManufacture 

FROM Production.Product
ORDER BY DaysToManufacture DESC