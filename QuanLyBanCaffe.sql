create database QuanLyBanCaffe
go

use QuanLybanCaffe;

create table Catagory (
	catagoryId bigint primary key identity(1,1),
	name varchar(255) UNIQUE NOT NULL,
	active bit default 1
);

create table Product (
	productId bigint primary key identity(1,1),
	catagoryId bigint references Catagory(catagoryId),
	name varchar(255) UNIQUE NOT NULL,
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
	role varchar(255) CHECK (role IN ('STAFF', 'ADMIN')) default 'STAFF' NOT NULL,
	password varchar(255) default 123 NOT NULL,
	active bit default 1
);

create table [Table] (
	tableId bigint primary key identity(1, 1),
	name varchar(255) UNIQUE NOT NULL,
	status varchar(5) CHECK (status IN ('EMPTY', 'FULL')) default 'EMPTY' NOT NULL,
	active bit default 1
)

create table Bill (
	billId bigint primary key identity(1,1),
	userId bigint references [User](userId),
	tableId bigint references [Table](tableId),
	quantity int default 0,
	total money default 0,
	discount int CHECK (discount BETWEEN 0 AND 100) default 0,
	final money default 0,
	receive money default 0,
	change money default 0,
	createdDate datetime default GETDATE(),
	status varchar(255) CHECK (status IN ('CANCELLED', 'PAID', 'PENDING')) default 'PENDING'
)

create table BillDetails (
	billId bigint references Bill(billId),
	productId bigint references Product(productId),
	quantity int default 0,
	total money default 0
	PRIMARY KEY (billId, productId)
)


