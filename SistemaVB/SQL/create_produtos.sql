-- criar as tabelas
create table Produtos (
id_produto int primary key identity(1,1) not null,
nome varchar(60) not null,
descricao varchar(50) not null,
quantidade int not null,
valor decimal(10,2)  null,
data_cadastro datetime
)
go

-- criar os procedimentos
create procedure sp_salvarpro
@id_produto int,
@nome varchar(60),
@descricao varchar(50),
@quantidade int,
@valor decimal(10,2),
@data_cadastro datetime,
@mensagem varchar(100) output
as
begin
	insert into Produtos values(@nome,@descricao,@quantidade,@valor,@data_cadastro)
	set @mensagem = 'Produto registrado com sucesso!'
end
go

create procedure sp_editarpro
@id_produto int,
@nome varchar(60),
@descricao varchar(50),
@quantidade int,
@valor decimal(10,2),
@data_cadastro datetime,
@mensagem varchar(100) output
as
begin

	update Produtos set
	nome = @nome,
	descricao = @descricao, 
	quantidade = @quantidade,
	valor = @valor,
	data_cadastro = @data_cadastro
	where id_produto = @id_produto

	set @mensagem = 'Dados atualizados com sucesso!'

end
go

create procedure sp_buscarproNome
@nome varchar(60) 
as
begin
	select * from Produtos
	where nome like @nome + '%'
end
go


create procedure sp_ExcluirproPorId
@id_produto int,
@mensagem varchar(100) output
as
begin
	Delete from Produtos
	where id_produto = @id_produto
	set @mensagem = 'Registro Excluído com sucesso!'
end
go



