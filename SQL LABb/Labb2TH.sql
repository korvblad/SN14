USE AdventureWorks2012;

--4.0--

BACKUP DATABASE AdventureWorks2012
TO DISK = 'C:\MyBackups\AW_BU.bak'


--4.1--

SELECT Lastname
FROM Person.Person

BEGIN TRANSACTION


UPDATE Person.person Set LastName = 'hult'
SELECT @@TRANCOUNT AS ActiveTransactions

ROLLBACK TRANSACTION


--4.2--

CREATE TABLE [dbo].[TempCustomers]
(
	[ContactID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[City] [nvarchar](30) NULL,
	[StateProvince] [nvarchar](50) NULL
)
GO

INSERT INTO TempCustomers (ContactID, FirstName, LastName, City, StateProvince)
VALUES (1, 'Kalen', 'Delaney', 'Vislands', 'korn'),
	 (2, 'Herrman', 'Karlsson', 'Vislanda', 'Kronoberg');


	INSERT INTO TempCustomers (ContactID, FirstName, LastName, City)
VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan')
	, (4, 'Charlie', 'Carpenter', 'Tappström');

SELECT ContactID
	, FirstName
	, LastName
	, City
	, StateProvince
FROM dbo.TempCustomers,

--4.3--
SELECT Name
FROM Production.Product

	INSERT INTO Production.Product (Name, ProductNumber, SafetyStockLevel , ReorderPoint, ListPrice, StandardCost, DaysToManufacture, SellStartDate)
VALUES ('Racing Gizmo', 4000, 200, 8000, 666, 700, 3, 2000)

--4.4--
--BEGIN TRANSACTION

INSERT INTO dbo.TempCustomers (ContactID, FirstName, LastName, City, StateProvince)


SELECT P.BusinessEntityID
		, P.FirstName
		, P.LastName
		, PA.City 
		, SP.Name

FROM Person.Person AS P
	JOIN Person.BusinessEntity AS BE
			ON P.BusinessEntityID=BE.BusinessEntityID
	JOIN Person.BusinessEntityAddress AS BEA
			ON BE.BusinessEntityID = BEA.BusinessEntityID
	JOIN Person.Address PA
			ON BEA.AddressID=PA.AddressID
	JOIN Person.StateProvince AS SP
			ON PA.StateProvinceID = SP.StateProvinceID


--4.5--

--BEGIN TRANSACTION

-- Töm tabellen
-- och töm buffer och cache
TRUNCATE TABLE dbo.TempCustomers
GO
  
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
GO
-- Lägg till data och mät tiden
DECLARE @Start DATETIME2, @Stop DATETIME2
SELECT @Start = SYSDATETIME()
INSERT INTO dbo.TempCustomers
 (ContactID, FirstName, LastName)
SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
SELECT @Stop = SYSDATETIME()
SELECT DATEDIFF(ms,@Start,@Stop) as MilliSeconds

CREATE UNIQUE CLUSTERED INDEX [Unique_Clustered]
ON [dbo].[TempCustomers]
( [ContactID] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_LName]
ON [dbo].[TempCustomers]
( [LastName] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_FName]
ON [dbo].[TempCustomers]
( [FirstName] ASC )

--Försök 1 för en tom cache tog 407 MS att exekvera
--Försök 2 med trunkerad tabell tog 210 MS
--Försök 3 bara exekverad tog 230 MS
--Försök 4 bara exekverad tog 446 MS
--Försök 5 bara exekverad tog 373 MS
--Försök 6 bara exekverad tog 503 MS
--Försök 7 för en tom cache tog 820 MS att exekvera 
-- Efter skapandet av index
--Försök 1 tom cache tog 2101 MS
--Försök 2 trunkerad tabell tog 1612 MS
--Försök 3 trunkerad tabell tog 443 MS
--Försök 4 trunkerad tabell tog 410 MS
--Försök 5 tunkerad tabell tog 705 MS
--Försök 6 trunkerad tabell tog 488 MS
--Försök 7 Trunkerad tabell tog 754 MS

-- Den största skillnaden jag kan lägga mörke till är att del 2 av uppgiften inte har lika jämn responstid,


--4.6--



SELECT BusinessEntityID
	, PersonType
	, FirstName
	, LastName
	, Title
	, EmailPromotion

INTO #TempTab
FROM Person.Person
WHERE LastName IN ('Achong', 'Acevedo')

SELECT * FROM #TempTab

INSERT INTO Person.Person(BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion)
	SELECT BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion
	FROM #TempTab

	--4.6-2--

	UPDATE #TempTab
SET BusinessEntityID =
	(
	SELECT MAX(PP.BusinessEntityID) + 1 
	FROM Person.Person AS PP
	)

	INSERT INTO Person.Person(BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion)
	SELECT BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion
	FROM #TempTab


	--4.6-3--

	-- Exekvera följande två gånger
INSERT INTO Person.BusinessEntity
VALUES (DEFAULT, DEFAULT)

DROP TABLE #TempTab

SELECT FirstName, BusinessEntityID, ModifiedDate
FROM Person.Person 
WHERE ModifiedDate > '2015-03-10'

--Uppgift 4.7
UPDATE Person.Person
SET FirstName = 'Gurra', LastName = 'Tjong'
WHERE BusinessEntityID IN
	(
	SELECT BusinessEntityID
	FROM Person.Person
	WHERE LastName IN ('Achong', 'Acevedo')
	)
SELECT FirstName
	, LastName
FROM Person.Person
WHERE FirstName = 'Gurra' AND LastName = 'Tjong'

--Uppgift 4.8
SELECT PP.Name
	, PP.ListPrice * 1.1 AS NotOnSale
FROM Production.Product AS PP
	INNER JOIN Production.ProductSubcategory AS PS ON PS.ProductSubcategoryID = PP.ProductSubcategoryID
WHERE PS.Name = 'Gloves'

--Uppgift 4.9
DELETE FROM TempCustomers
WHERE LastName = 'Smith'

SELECT LastName
FROM TempCustomers
WHERE LastName LIKE 'SM%'
