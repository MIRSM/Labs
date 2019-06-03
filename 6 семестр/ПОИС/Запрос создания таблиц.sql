USE Warehause
CREATE TABLE Clients(
	[ID_Client] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL CHECK ([Name]>='À' AND [Name]<='ÿ'),
	[Addres] [varchar](50) NOT NULL CHECK ([Addres]>='À' AND [Addres]<='ÿ' OR [Addres]=' ' OR [Addres]>='0' AND [Addres]<='9' OR [Addres]=',' OR [Addres]='.'),
	[Phone_number] [nchar](11) NOT NULL UNIQUE CHECK([Phone_number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
	)
	
CREATE TABLE Members(
	[ID_Member] [int] IDENTITY(1,1) PRIMARY KEY,
	[First_name] [nchar](30) NOT NULL CHECK ([First_name]>='À' AND [First_name]<='ÿ' OR [First_name]=' '),
	[Second_name] [nchar](30) NULL CHECK ([Second_name]>='À' AND [Second_name]<='ÿ'),
	[Surname] [nchar](30) NOT NULL CHECK ([Surname]>='À' AND [Surname]<='ÿ') ,
	[Birthday] [date] NOT NULL CHECK([Birthday]>='1940-01-01' AND [Birthday]<='2040-01-01'),
	[Addres] [nchar](50) NOT NULL CHECK ([Addres]>='À' AND [Addres]<='ÿ' OR [Addres]=' ' OR [Addres]>='0' AND [Addres]<='9' OR [Addres]=',' OR [Addres]='.'),
	[Phone_number] [nchar](11) NOT NULL UNIQUE CHECK([Phone_number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[Passport] [varchar](10) UNIQUE NULL CHECK([Passport] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
	)

CREATE TABLE Providers(
	[ID_Provider] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL CHECK ([Name]>='À' AND [Name]<='ÿ' OR [Name]=' ' OR [Name]>='A' AND [Name]<='z'),
	[Addres] [varchar](50) NOT NULL CHECK ([Addres]>='À' AND [Addres]<='ÿ' OR [Addres]=' ' OR [Addres]>='0' AND [Addres]<='9' OR [Addres]=',' OR [Addres]='.'),
	[Phone_number] [nchar](11) NOT NULL UNIQUE CHECK(Phone_number like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
	)

CREATE TABLE Types(
	[ID_Type] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL UNIQUE CHECK  ([Name]>='À' AND [Name]<='ÿ' OR [Name]=' ')
	)
CREATE TABLE Products(
	[ID_Product] [int] IDENTITY(1,1) PRIMARY KEY,
	[ID_Type] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL CHECK ([Name]>='À' AND [Name]<='ÿ' OR [Name]=' ' OR [Name]>='A' AND [Name]<='z' OR [Name]>='0' AND [Name]<='9'),
	[ID_Provider] [int] NOT NULL,
	FOREIGN KEY (ID_Type) REFERENCES Types (ID_Type),
	FOREIGN KEY (ID_Provider) REFERENCES Providers (ID_Provider)
	)
	CREATE TABLE Storage(
	[ID_Storage] [int] IDENTITY(1,1) PRIMARY KEY,
	[ID_Product] [int] NOT NULL,
	[ID_Client] [int] NOT NULL,
	[ID_Member] [int] NOT NULL,
	[Date_of_arrival] [date] NOT NULL CHECK(Date_of_arrival<=CONVERT(date,GETDATE())),
	[Date_of_order] [date] NOT NULL CHECK (Date_of_order >='01-01-1940'),
	[Volume] [int] NOT NULL CHECK(Volume > 0),
	[Price] [int] NOT NULL CHECK(Price > 0),
	FOREIGN KEY (ID_Product) REFERENCES Products (ID_Product),
	FOREIGN KEY (ID_Client) REFERENCES Clients (ID_Client),
	FOREIGN KEY (ID_Member) REFERENCES Members (ID_Member),
	CONSTRAINT DATECONS CHECK(Date_of_order <= Date_of_arrival)
	)