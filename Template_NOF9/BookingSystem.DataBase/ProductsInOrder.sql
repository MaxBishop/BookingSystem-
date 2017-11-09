select Orders.Id , ProductName
From OrderLines, Orders, Products
where OrderLines.OrderID = Orders.Id and OrderLines.ProductID = Products.ProductID 