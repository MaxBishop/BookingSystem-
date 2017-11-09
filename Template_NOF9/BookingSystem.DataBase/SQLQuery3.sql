select Id , ProductName
From OrderLines, Orders, Products
where OrderLines.Order_Id = Orders.Id and OrderLines.ProductID = Products.ProductID 

