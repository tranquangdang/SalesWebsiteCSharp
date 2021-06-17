Create database TranQuangDangDB

Create table UserAccount 
(
	ID int not null identity(1,1) primary key,
	UserName varchar(255) not null,
	Password varchar(255) not null,
	Status varchar(255) not null
)
go

Create table Category 
(
	ID int not null identity(1,1) primary key,
	Name nvarchar(255) not null,
	Description nvarchar(max) not null
)

Create table Product
(
	ID int not null identity(1,1) primary key,
	CategoryNo int not null foreign key references Category(ID) ON DELETE CASCADE,
	Name nvarchar(1000) not null,
	UnitCost int not null,
	Quantity int not null,
	Image nvarchar(max),
	Description nvarchar(max),
	Status int not null
)
go