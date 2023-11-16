create database QuanLyBanCaffe
go

use QuanLybanCaffe;

create table Catagory (
	catagoryId bigint primary key identity(1,1),
	name varchar(255),
	active bit default 1
);

create table Product (
	productId bigint primary key identity(1,1),
	catagoryId bigint references Catagory(catagoryId),
	name varchar(255),
	price money default 0,
	quantity int default 0,
	sold int default 0,
	active bit default 1
);

create table [User] (
	userId bigint primary key identity(1,1),
	email varchar(255) NOT NULL unique,
	username varchar(255) NOT NULL,
	phone varchar(10),
	address text,
	role varchar(255) CHECK (role IN ('NHAN VIEN', 'QUAN LY')) default 'NHAN VIEN' NOT NULL,
	password varchar(255) default 123 NOT NULL,
	active bit default 1
);

create table Bill (
	billId bigint primary key identity(1,1),
	userId bigint references [User](userId),
	quantity int default 0,
	total money default 0,
	receive money default 0,
	change money default 0,
	createdDate datetime default GETDATE(),
	status varchar(255) CHECK (status IN ('DA HUY', 'DA THANH TOAN', 'CHUA THANH TOAN')) default 'CHUA THANH TOAN'
)
