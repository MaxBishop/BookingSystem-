select ProductName
from Products, OrderLines 
where Products.ProductID = OrderLines.ProductID order by OrderLines.Quantity 