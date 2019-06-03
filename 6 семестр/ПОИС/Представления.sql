
/*
Create View HighCostPr 
AS Select ID_Storage,ID_Product,ID_Client,ID_Member,Volume,Price FROM Warehause..Storage WHERE Price>11000;*/

/*
Create View MembersWithClients (MemberSurname,Count)AS Select Members.Surname,COUNT(Storage.ID_Client) FROM Storage, Members, Clients WHERE Storage.ID_Member=Members.ID_Member AND Storage.ID_Client=Clients.ID_Client GROUP BY Members.Surname;
*/

/*
Create View AvgProductPrice AS Select Products.ID_Product As ProductId,Products.Name AS Name, AVG(Storage.Price) AS AvgPrice From Storage,Products Where Products.ID_Product=Storage.ID_Product Group By Products.Name,Products.ID_Product;
*/
