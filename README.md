# CRUD-AspNet
Crud feito em asp.net para cadastro de clientes em uma seguradora

<a href="https://ibb.co/LrR5dFs"><img src="https://i.ibb.co/r30s2jX/imagem-2022-04-09-152817.png" alt="imagem-2022-04-09-152817" border="0"></a>


## Script for database

CREATE DATABASE [ManagamentCustomer]

USE [ManagamentCustomer]

CREATE TABLE [dbo].[CustomerSituations] ( [Id] INT NOT NULL IDENTITY, [Name] VARCHAR (50) NOT NULL PRIMARY KEY ([Id]), );

CREATE TABLE [dbo].[CustomerTypes] ( [Id] INT NOT NULL IDENTITY, [Name] VARCHAR (50) NOT NULL PRIMARY KEY ([Id]), );

CREATE TABLE [dbo].[Customer] ( [CPF] CHAR (11) NOT NULL, [CustomerType] INT NULL, [Sex] CHAR (1) NULL, [CustomerSituation] INT NULL PRIMARY KEY ([CPF]), 
FOREIGN KEY ([CustomerType]) REFERENCES CustomerTypes([Id]), FOREIGN KEY ([CustomerSituation]) REFERENCES CustomerSituations([Id]) );

Stored Procedures

create procedure spInsertCustomer ( @CPF CHAR(11), @CustomerType INT, @Sex CHAR(1), @CustomerSituation int )
as begin insert into Customer (CPF, CustomerType, Sex, CustomerSituation) values (@CPF, @CustomerType, @Sex, @CustomerSituation) end

 create procedure spAlterCustomer 
 (
 @CPF CHAR(11),
 @oldCPF CHAR(11),
 @CustomerType INT, 
 @Sex CHAR(1), 
 @CustomerSituation int 
 ) 
as
begin
update Customer set
CustomerType = @CustomerType,
Sex = @Sex, 
CustomerSituation = @CustomerSituation
where CPF = @oldCPF end 

create procedure spDeleteCustomer ( @CPF CHAR(11) ) as begin delete Customer where CPF = @CPF end 

create procedure spQueryCustomer ( @CPF CHAR(11) ) as begin select * from Customer where CPF = @CPF end 

create procedure spListCustomers as begin select * from Customer end 

INSERT INTO CustomerSituations (Name)
VALUES ( 'Nivel1');

INSERT INTO CustomerSituations (Name)
VALUES ( 'Nivel2');

INSERT INTO CustomerSituations (Name)
VALUES ( 'Nivel3');

INSERT INTO CustomerSituations (Name)
VALUES ( 'Nivel4');


INSERT INTO CustomerTypes (Name)
VALUES ('Auto');

INSERT INTO CustomerTypes (Name)
VALUES ( 'Residência');

INSERT INTO CustomerTypes (Name)
VALUES ( 'Vida');

INSERT INTO CustomerTypes (Name)
VALUES ( 'Empresa');
