select * from PizzaDetails

select * from Orders
select * from OrderDetails
select * from OrderToppingDetails

DELETE FROM Orders  WHERE OrderId between 21 and 46;
DELETE FROM OrderDetails  WHERE OrderId between 21 and 46;
DELETE FROM OrderToppingDetails  WHERE toppingId=3;