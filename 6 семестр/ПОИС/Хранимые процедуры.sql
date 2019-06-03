USE Warehause;
/*
GO
CREATE PROCEDURE DeleteSlowArrival 
AS
BEGIN
	DELETE From Storage Where YEAR(Storage.Date_of_arrival)-YEAR(Storage.Date_of_order)=0 AND MONTH(Storage.Date_of_arrival)-MONTH(Storage.Date_of_order)=0 AND DAY(Storage.Date_of_arrival)-DAY(Storage.Date_of_order)=2;
END
GO

CREATE PROCEDURE IncreasePrice (@percent int) 
AS
BEGIN
	UPDATE Storage SET Price=Price+Price*(@percent/100);
END
GO
*/

/*
CREATE PROCEDURE CountClients
AS
BEGIN
	Select COUNT(Distinct(Storage.ID_Client)) From Storage;
END
GO
*/

/*
CREATE PROCEDURE EmptySell
AS
BEGIN
	INSERT INTO Storage VALUES (14,1,1,GETDATE(),GETDATE(),1,0);
END
GO
*/
