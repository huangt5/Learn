use AdventureWorks2008R2

select 
--	top 100 
	* 
from Sales.SalesOrderHeader
where OrderDate between '2007-1-1' and '2007-12-31'
order by SalesOrderID desc


SELECT * FROM Sales.SalesOrderHeader
WHERE SalesOrderID IN (75134,48730)

SELECT * FROM Sales.SalesOrderDetail
WHERE SalesOrderID = 48730


SELECT TOP 100 * FROM Sales.SalesOrderDetail

SELECT TOP 100 * FROM Production.Product

SELECT TOP 100 * FROM Sales.SpecialOfferProduct

SELECT TOP 100 * FROM Sales.SpecialOffer

SELECT COUNT(1) FROM Production.Product

