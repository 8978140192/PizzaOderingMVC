create database PizzaOrdingMVC

use pizzaordingmvc

create table UserDetails(
userId varchar(30) primary key,
password varchar(30),
UserName varchar(30),
UserPhone varchar(15),
UserAge int,
UserAddress varchar(90)
)

create table PizzaDetails(
pizzaId int identity(1,1) primary key,
pizzaName varchar(30) unique ,
pizzaPrice int ,
pizzaType varchar(20) 
)

create table ToppingDetails(
toppingId int identity(1,1) primary key,
toppingName varchar(30) unique ,
toppingPrice float
)

create table Orders(
orderId int identity(1,1) primary key,
userId varchar(30) foreign key references UserDetails(userId),
deliveryCharges float ,
totalBill float ,
orderStatus varchar(20)
)

create table OrderDetails(
itemId int identity(1,1) primary key,
pizzaId int foreign key references PizzaDetails(pizzaId),
orderId int foreign key references Orders(orderId)
)

create table OrderToppingDetails(
itemId int foreign key references OrderDetails(itemId),
toppingId int foreign key references ToppingDetails(toppingId),
primary key(itemId,toppingId)
)

ALTER TABLE Orders
ADD QTY int;

