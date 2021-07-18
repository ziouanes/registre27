create database lawsuits

drop database lawsuits

go

use lawsuits


create table Person(id int primary key  identity(1,1), nom ntext)

create table Mahkama(id int primary key  identity(1,1),mahkama ntext )

create table hokm(id int primary key identity(1,1),mahkama ntext )


create table atachement(id int primary key identity(1,1) ,_name ntext   , cas int )


create table cas(id int  identity(1,1) , numero ntext  , date_cas date , _description ntext , prix varchar(30) , note ntext ,  afterhokm ntext ,   Person_id int foreign key references Person(id) on delete cascade on update cascade , mahkama int foreign key references Mahkama(id) on delete cascade on update cascade ,  hokm int foreign key references hokm(id) on delete cascade on update cascade , deleted int default 0  )



insert into atachement values('ddd', 2)


 USE master;
GO
ALTER DATABASE lawsuits
COLLATE Arabic_CI_AI;
GO


ALTER DATABASE lawsuits SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

GO

ALTER DATABASE lawsuits COLLATE ARABIC_CI_AS;

GO

ALTER DATABASE lawsuits SET MULTI_USER;

GO

INSERT INTO Mahkama(mahkama) values(N'ااا')
