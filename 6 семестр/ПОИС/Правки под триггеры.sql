/*
DROP trigger DeleteStorageRecord
*/

/* INSERT

Insert into Warehause..Storage VALUES (2,1,1,GETDATE(),GETDATE(),1,61900);
*/

/* DELETE

INSERT INTO Clients(Name,Addres,Phone_number) VALUES ('Дима','Пенза','88005553237');

INSERT INTO Storage VALUES(12,25,2,GETDATE(),GETDATE(),1,20000)
INSERT INTO Storage VALUES(13,25,2,GETDATE(),GETDATE(),1,18000)
DELETE FROM Clients WHERE Clients.ID_Client=2
*/

/* UPDATE
*/
Update Storage Set Volume=10 Where Volume=33 AND ID_Client=21


Select * from Storage;