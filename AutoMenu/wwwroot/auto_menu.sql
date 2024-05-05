drop database if exists Automenu_DB;
create database Automenu_DB;
use Automenu_DB;

create table Address(
ID_Address int primary key auto_increment,
UF char(2) not null,
City varchar(100) not null,
District varchar(100) not null,
Street varchar(100) not null,
Number smallint unsigned not null,
Complement varchar(100) not null
)engine = InnoDB;

create table Restaurant(
ID_Restaurant int primary key not null auto_increment, 
CNPJ char(18) not null,
Name varchar(80) not null,
Email varchar(100) not null,
Password_Hash varchar(255) not null,
Fk_Address_Id int not null,
foreign key (Fk_Address_Id) references Address(ID_Address) on delete restrict
)engine = InnoDB;

create table static_menu(
id_static_menu int primary key not null auto_increment,
titulo varchar(50),
descricao varchar(200),
image_url varchar(200),
imagem blob
);
