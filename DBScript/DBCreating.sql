create database PizzaOrdingUsingMVC

use pizzaordingUsingmvc

create table UserDetails(
userId varchar(30) primary key,
password varchar(30),
UserName varchar(30),
UserPhone varchar(15),
UserAge int,
UserAddress varchar(90)
)
insert into UserDetails values('A123','1234','Arshad','897812345',21,'4-143,asif nagar,Ap,52327'),('B123','1234','Mathi','8978123423',21,'4-143,asif nagar,Ap,52327')
create table PizzaDetails(
PizzaId int identity(1,1) primary key,
PizzaName varchar(30) unique ,
PizzaPrice int ,
PizzaDiscription varchar(1000),
PizzaImage varchar(100),
pizzaType varchar(20) 
)
insert into PizzaDetails values('Margherita',524,'A classic delight with 100% Real mozzarella cheese','/images/Margarita.jfif','VEG')

insert into PizzaDetails values('Veggie Paradise',479,'The awesome foursome! Golden corn, black olives, capsicum, red paprika','/images/VeggieParadise.jfif','VEG')
insert into PizzaDetails values('Farmhouse',499,'Delightful combination of onion, capsicum, tomato & grilled mushroom','/images/Farmhouse.jfif','VEG')
insert into PizzaDetails values('The Cheese Dominator',579,'Loaded with 1 Pound of Mozzarella and gooey Liquid Cheese on a Classic Large Pizza topped with a generous helping of herb sprinkly','/images/CheeseDominator.jfif','VEG')
insert into PizzaDetails values('The Unthinkable Pizza',534,'Loaded with Plant Based Protein topping along with Black Olives & Red Paprika enjoy this unique 100% chicken like tast','/images/Unthinkable.jfif','VEG')

insert into PizzaDetails values('Chicken Golden Delight',579,'Double pepper barbecue chicken, golden corn and extra cheese, true delight','/images/GoldenDelight.jfif','NON-VEG')
insert into PizzaDetails values('Non Veg Supreme',534,'Supreme combination of black olives, onion, capsicum, grilled mushroom, pepper barbecue chicken','/images/NonVegSupreme.jfif','NON-VEG')
insert into PizzaDetails values('Chicken Pepperoni',579,'A classic American taste! Relish the delectable flavor of Chicken Pepperoni, topped with extra cheese','/images/ChickenPepperoni.jfif','NON-VEG')
insert into PizzaDetails values('Creamy Tomato Pasta Pizza',399,'Loaded with a delicious creamy tomato pasta topping, BBQ pepper chicken, green capsicum, crunchy red and yellow bell peper','/images/CreamyTomatoPastaPizza.jfif','NON-VEG')
insert into PizzaDetails values('Moroccan Spice Pasta Pizza',399,'A pizza loaded with a spicy combination of Harissa sauce, Peri Peri chicken chunks and delicious pasta.','/images/MoroccanSpicePastaPizza.jfif','NON-VEG')

create table ToppingDetails(
ToppingId int identity(1,1) primary key,
ToppingName varchar(30) unique ,
ToppingPrice float
)
insert into ToppingDetails values('ONION',60)
insert into ToppingDetails values('CRISP CAPSICUM',60)
insert into ToppingDetails values('GRILLED MUSHROOM',60)


create table Orders(
OrderId int identity(1,1) primary key,
UserId varchar(30) foreign key references UserDetails(userId),
DeliveryCharges float ,
TotalBill float ,
Quatity int,
OrderStatus varchar(20)
)

create table OrderDetails(
ItemId int identity(1,1) primary key,
PizzaId int foreign key references PizzaDetails(pizzaId),
OrderId int foreign key references Orders(orderId)
)

create table OrderToppingDetails(
itemId int foreign key references OrderDetails(itemId),
toppingId int foreign key references ToppingDetails(toppingId),
primary key(itemId,toppingId)
)

