INSERT INTO Warehause..Clients(Name,Addres,Phone_number) VALUES ('Дима','Пенза','88005553535');

INSERT INTO Warehause..Members (First_Name, Second_Name, Surname, Birthday, Addres, Phone_number, Passport) VALUES ('Никита','Сергеевич','Лялин','1999-02-07','Г. Пенза','88888888888','5618000001');

INSERT INTO Warehause..Types (Name) VALUES('Ноутбук');

INSERT INTO Warehause..Providers(Name,Addres,Phone_number) VALUES('Илон Маск','П. Земля','11111111111');

INSERT INTO Warehause..Products(Name,ID_Type,ID_Provider) VALUES('Lenovo',1,1);

INSERT INTO Warehause..Storage(ID_Product,ID_Client,ID_Member,Date_of_order,Date_of_arrival,Volume,Price) VALUES (1,1,1,'2019-03-10','2019-03-14',2,44999);

INSERT INTO Warehause..Clients(Name,Addres,Phone_number) VALUES ('Наташа','Пенза','88005553534');

INSERT INTO Warehause..Types (Name) VALUES('Смартфон');

INSERT INTO Warehause..Providers(Name,Addres,Phone_number) VALUES('Apple','Америка','99999999999');

INSERT INTO Warehause..Products(Name,ID_Type,ID_Provider) VALUES('IPhone 8 plus',2,2);

INSERT INTO Warehause..Storage(ID_Product,ID_Client,ID_Member,Date_of_order,Date_of_arrival,Volume,Price) VALUES (2,2,1,'2019-03-14','2019-03-14',1,55999);

DELETE FROM Warehause..Storage;

UPDATE Warehause..Storage SET Price=60000 WHERE Price=55999;
