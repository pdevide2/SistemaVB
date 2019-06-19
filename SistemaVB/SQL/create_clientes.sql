-- criar as tabelas
create table clientes (
id_cliente int primary key identity(1,1) not null,
nome varchar(60) not null,
sexo varchar(20) not null,
cpf varchar(30) not null,
endereco varchar(100)  null,
telefone varchar(30) null, 
email varchar(60) null,
data_cadastro datetime
)
go

-- criar os procedimentos
create procedure sp_salvarcli
@nome varchar(60),
@sexo varchar(20),
@cpf varchar(30),
@endereco varchar(100),
@telefone varchar(30),
@email varchar(60),
@data_cadastro datetime,
@mensagem varchar(100) output
as
begin

if exists(select 1 from clientes where cpf=@cpf)
	SET @MENSAGEM = 'Numero do CPF '+@cpf + ' já está registrado!'
else
begin
	insert into clientes values(@nome,@sexo,@cpf,@endereco,@telefone,@email,@data_cadastro)
	set @mensagem = 'Cliente registrado com sucesso!'
end

end
go

create procedure sp_editarcli
@nome varchar(60),
@sexo varchar(20),
@cpf varchar(30),
@endereco varchar(100),
@telefone varchar(30),
@email varchar(60),
@data_cadastro datetime,
@mensagem varchar(100) output
as
begin

	update clientes set
	nome = @nome,
	sexo = @sexo, 
	endereco = @endereco,
	telefone = @telefone,
	email = @email
	where cpf = @cpf

	set @mensagem = 'Dados atualizados com sucesso!'

end
go

create procedure sp_buscarcliNome
@nome varchar(60) 
as
begin
	select * from clientes
	where nome like @nome + '%'
end
go

create procedure sp_buscarcliCPF
@cpf varchar(30) 
as
begin
	select * from clientes
	where cpf like @cpf + '%'
end
go

create procedure sp_ExcluirCliPorCPF
@cpf varchar(30) ,
@mensagem varchar(100) output
as
begin
	Delete from clientes
	where cpf = @cpf 
	set @mensagem = 'Registro Excluído com sucesso!'
end
go



