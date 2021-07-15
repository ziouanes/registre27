create database lawsuits

go

drop table Person 

use lawsuits

create table Person(id int primary key  identity(1,1), nom ntext)

create table Mahkama(id int primary key  identity(1,1),mahkama ntext )

create table hokm(id int primary key identity(1,1),mahkama ntext )


create table atachement(id int primary key identity(1,1) ,_name ntext   , cas int )


create table cas(id int  identity(1,1) , numero nvarchar(30)  , date_cas date , _description ntext , prix varchar(30) , note ntext ,  afterhokm nvarchar(50) ,   Person_id int foreign key references Person(id) on delete cascade on update cascade , mahkama int foreign key references Mahkama(id) on delete cascade on update cascade ,  hokm int foreign key references hokm(id) on delete cascade on update cascade )


select c.id ,  c.numero , p.nom ,  c.date_cas , m.mahkama , c._description , c.prix , c.afterhokm , c.note , h.mahkama as 'hokm'   from cas c inner join Person p on c.Person_id = p.id inner join Mahkama m on m.id = c.mahkama  inner join hokm h on h.id = c.hokm

 
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

select id , nom from Person