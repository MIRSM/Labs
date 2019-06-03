USE Warehause
ALTER TABLE Clients 
	ADD SomeColumn int;
ALTER TABLE Clients
	ALTER COLUMN SomeColumn char(2);	
ALTER TABLE Clients
	DROP COLUMN SomeColumn;
