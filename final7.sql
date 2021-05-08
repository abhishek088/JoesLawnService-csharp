create database LawnService

go

use LawnService

create table customers (
	id int primary key not null identity,
	name nvarchar(max) not null,
	postalCode nvarchar(6) not null,
	phone nvarchar(10) not null,
	lawn DECIMAL NOT NULL,
	type VARCHAR(50) NOT NULL,
	date VARCHAR(50) NOT NULL
)

create table serviceTypes (
	id int primary key not null identity,
	description nvarchar(max) not null,
	ratePerSqMeter decimal(18,2) not null
)

create table appointments (
	id int primary key not null identity,
	serviceDate datetime not null,
	lawnSize decimal(18,2) not null,
	customerId int references customers(id),
	serviceTypeId int references serviceTypes(id)
)

select * from customers