create table funcionarios (
id_func int primary key not null,
nome varchar(60) not null,
sexo varchar(20) not null,
cpf varchar(30) not null,
endereco varchar(100)  null,
telefone varchar(30) null,
email varchar(60) null,
turno varchar(30) null,
data_contratado datetime
)
