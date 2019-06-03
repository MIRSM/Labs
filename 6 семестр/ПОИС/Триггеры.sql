USE Warehause
Go
/*
create trigger LenovoGift
on Storage FOR INSERT
as
declare @idproduct int
declare @price int
declare @idclient int
declare @idmember int
declare @datearrival date
declare @dateorder date
select @idproduct=ID_Product from inserted
select @price=Price from inserted
select @idclient=ID_Client from inserted
select @idmember=ID_Member from inserted
select @datearrival=Date_of_arrival from inserted
select @dateorder=Date_of_order from inserted
if(@idproduct=1 AND @price>0)
Begin
 INSERT INTO Storage VALUES(@idproduct,@idclient,@idmember,@datearrival,@dateorder,1,0)
end
*/
/*
create trigger DeleteStorageRecord
on Clients FOR DELETE
as
declare @idclient int
select @idclient=ID_Client from deleted 
DELETE FROM Storage WHERE (Storage.ID_Client=@idclient)
*/
/*
create trigger ChangePrice
on Storage For Update
as
declare @oldVolume int
declare @newVolume int
declare @discont int
select @oldVolume=Volume from deleted
select @newVolume=Volume from inserted
if(Update(Volume))
begin
	if(@oldVolume<>@newVolume)
	begin
	SET @discont=@newVolume-@oldVolume
		if(@discont>20)
			SET @discont=20
		if(@discont<-20)
			SET @discont=-20
		Update Storage Set Price=Price-(Price*@discont/100) where ID_Storage IN(select ID_Storage from inserted)
	end 
end 
*/