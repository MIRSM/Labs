/*1) ����� ������, ������� ������� � ���� ������*/
SELECT Name FROM Warehause..Products WHERE ID_Product IN (SELECT ID_Product FROM Warehause..Storage WHERE Date_of_arrival=Date_of_order);

/*2) ������� ������� ���������, ���� �������� ������� �������� � �������� �� 01.01.1990 �� 01.01.2000*/
SELECT Surname FROM Warehause..Members WHERE Birthday BETWEEN '01-01-1990' AND '01-01-2000';

/*3) ������� ������ ��������� � ������ ��������, ������� ����� ������*/
SELECT Addres,Phone_number FROM Warehause..Clients WHERE Name='������';

/*4) ����� ���� ���������, ������� ������� ����� ����������� �������*/
SELECT * FROM Warehause..Members WHERE ID_Member IN (SELECT ID_Member FROM Warehause..Storage WHERE ID_Client IN (SELECT ID_Client FROM Warehause..Clients WHERE Name='������'));

/*5) ������� � ��������������� ������� ��� ���������, ������� ����� �������.*/
SELECT First_Name,Second_name,Surname FROM Warehause..Members WHERE First_name='�������' ORDER BY Surname ;

/*6) ������� �������� �������, ��� ��������, ���� ��������, ���� ������, ����� � ���� �������*/
SELECT Name,Surname,First_name,Second_name,Date_of_arrival,Date_of_order,Volume,Price FROM Warehause..Products JOIN Warehause..Storage ON Storage.ID_Product=Products.ID_Product JOIN Warehause..Members ON Storage.ID_Member=Members.ID_Member;

/*--------- 7)������� ����������� ���� ������ ������� ���� -------*/
/*SELECT Name FROM Warehause..Clients WHERE ID_Client IN (SELECT ID_Client FROM Warehause..Storage WHERE ID_Product 
IN(SELECT ID_Product FROM Warehause..Products WHERE ID_Type IN 
(SELECT ID_Type FROM Warehause..Types WHERE Name='�������' )) 
AND EXISTS(SELECT ID_Client FROM Warehause..Storage WHERE ID_Product IN
(SELECT ID_Product FROM Warehause..Products WHERE ID_Type IN 
(SELECT ID_Type FROM Warehause..Types WHERE Name='��������' ))));*/

SELECT DISTINCT[s1].ID_Type,s1.Name,Storage.Price FROM Warehause..Products s1 INNER JOIN Warehause..Storage 
ON s1.ID_Product=Storage.ID_Product
 INNER JOIN
(SELECT ID_Type, MIN(Storage.Price) AS price FROM Warehause..Products INNER JOIN Warehause..Storage 
ON Products.ID_Product=Storage.ID_Product GROUP BY ID_Type)
AS s2 ON s1.ID_Type=s2.ID_Type AND Storage.Price=s2.price

/*8) ������� ��� ������ � ��� �������� */
SELECT Types.Name, Products.Name FROM Warehause..Products INNER JOIN 
	Warehause..Types ON Products.ID_Type=Types.ID_Type

/*9) ������� ����� � ������� ���� ���������, ������� ������� ��������*/
SELECT First_Name, Surname FROM Warehause..Members WHERE ID_Member IN (SELECT ID_Member FROM Warehause..Storage WHERE ID_Product IN (SELECT ID_Product FROM Warehause..Products WHERE ID_Type IN (SELECT ID_Type FROM Warehause..Types WHERE Name='�������')))

/*10) ������� ����� ���� ��������, ������� ������ ���������, � �������� ������� ���� �����*/
SELECT Clients.Name,Products.Name FROM Warehause..Clients INNER JOIN
	Warehause..Storage ON Clients.ID_Client=Storage.ID_Client INNER JOIN Warehause..Products ON Storage.ID_Product=Products.ID_Product WHERE Products.Name like '%[0-9]%'