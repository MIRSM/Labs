USE Warehause;
/*INSERT INTO Storage(ID_Product,ID_Client,ID_Member,Date_of_order,Date_of_arrival,Volume,Price) VALUES (2,1,1,'2019-03-14','2019-03-16',2,15000);
*/
/*Delete From Storage Where Price<12000;
*//*
UPDATE HighCostPr SET Price=24000 WHERE Price=23999;*/
/*
Select * From HighCostPr;
*/
/*UPDATE MembersWithClients SET MemberSurname='Иванов' WHERE MemberSurname=(Select Members.Surname From Members Where Members.ID_Member=(SELECT Storage.ID_Member From Storage GROUP BY Storage.ID_Member HAVING (COUNT(Storage.ID_Client)<2) ));
*/
/*Select * From MembersWithClients;
*/
Select * From AvgProductPrice;
Select * From Storage;