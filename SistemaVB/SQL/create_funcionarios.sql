-- criar as tabelas
create table funcionarios (
id_func int primary key identity(1,1) not null,
nome varchar(60) not null,
sexo varchar(20) not null,
cpf varchar(30) not null,
endereco varchar(100)  null,
telefone varchar(30) null, 
email varchar(60) null,
turno varchar(30) null,
data_contratado datetime
)
go

-- criar os procedimentos
create procedure sp_salvarfunc
@nome varchar(60),
@sexo varchar(20),
@cpf varchar(30),
@endereco varchar(100),
@telefone varchar(30),
@email varchar(60),
@turno varchar(30),
@data_contratado datetime,
@mensagem varchar(100) output
as
begin

if exists(select 1 from funcionarios where cpf=@cpf)
	SET @MENSAGEM = 'Numero do CPF '+@cpf + ' já está registrado!'
else
begin
	insert into funcionarios values(@nome,@sexo,@cpf,@endereco,@telefone,@email,@turno,@data_contratado)
	set @mensagem = 'Funcionario registrado com sucesso!'
end

end
go

create procedure sp_editarfunc
@nome varchar(60),
@sexo varchar(20),
@cpf varchar(30),
@endereco varchar(100),
@telefone varchar(30),
@email varchar(60),
@turno varchar(30),
@data_contratado datetime,
@mensagem varchar(100) output
as
begin

	update funcionarios set
	nome = @nome,
	sexo = @sexo, 
	endereco = @endereco,
	telefone = @telefone,
	email = @email,
	turno = @turno,
	data_contratado = @data_contratado
	where cpf = @cpf

	set @mensagem = 'Dados atualizados com sucesso!'

end
go

create procedure sp_buscarFuncNome
@nome varchar(60) 
as
begin
	select * from funcionarios
	where nome like @nome + '%'
end
go

create procedure sp_buscarFuncCPF
@cpf varchar(30) 
as
begin
	select * from funcionarios
	where cpf like @cpf + '%'
end
go

create procedure sp_ExcluirFuncPorCPF
@cpf varchar(30) ,
@mensagem varchar(100) output
as
begin
	Delete from funcionarios
	where cpf = @cpf 
	set @mensagem = 'Registro Excluído com sucesso!'
end
go


--insert inicial
insert into funcionarios values('Admin','Masculino','000.000.000-00','Rua X','(00) 00000-0000','Admin@hotmail.com','Manhã',getdate())
go

select * from funcionarios

go

alter table funcionarios 
add senha varbinary(200) not null default(EncryptByPassPhrase('key', '1234' ))
go


/* Rotina para comparar senha */
declare @encrypt varbinary(200) 
select @encrypt = EncryptByPassPhrase('key', '12w09i12w23eAgoraOBichoVaiPegar' )
select @encrypt 
 
select convert(varchar(100),DecryptByPassPhrase('key', @encrypt ))

select nome, convert(varchar(100),DecryptByPassPhrase('key', senha )) senha2 from funcionarios
