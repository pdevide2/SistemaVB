create table vendas 
(
id_vendas int primary key not null Identity (1,1),
num_vendas int not null,
id_produto int not null,
id_cliente int not null,
funcionario varchar(50) null,
quantidade int not null,
valor decimal(18,2) not null,
data_venda datetime not null default (convert(varchar,getdate(),112)),
constraint FK_Vendas_Produtos foreign key (id_produto) references Produtos (id_produto),
constraint FK_Vendas_Clientes foreign key (id_cliente) references Clientes (id_cliente)
)
go

-- criar os procedimentos
create procedure sp_salvarvenda

@id_vendas int,
@num_vendas int,
@id_produto int,
@id_cliente int,
@funcionario varchar(50),
@quantidade int ,
@valor decimal(18,2) ,
@mensagem varchar(100) output

as
begin
	insert into vendas (num_vendas,id_produto,id_cliente,funcionario,quantidade,valor)
	values(@num_vendas,@id_produto,@id_cliente,@funcionario,@quantidade,@valor)
	set @mensagem = 'Venda registrada com sucesso!'
end
go

create procedure sp_editarvenda
@id_vendas int,
@num_vendas int,
@id_produto int,
@id_cliente int,
@funcionario varchar(50),
@quantidade int ,
@valor decimal(18,2) ,
@mensagem varchar(100) output
as
begin

	update vendas 
		set num_vendas = @num_vendas,
		id_produto = @id_produto,
		id_cliente = @id_cliente,
		funcionario = @funcionario,
		quantidade = @quantidade,
		valor = @valor
	where id_vendas=@id_vendas

	set @mensagem = 'Dados atualizados com sucesso!'

end
go

create procedure sp_buscarvenda
@num_vendas int
as
begin
	SELECT * FROM VW_VENDAS 
	where num_vendas = @num_vendas 
	order by num_vendas
end
go


create procedure sp_ExcluirVendaPorId
@id_vendas int,
@mensagem varchar(100) output
as
begin
	Delete from Vendas
	where id_vendas = @id_vendas
	set @mensagem = 'Registro Excluído com sucesso!'
end
go

create procedure buscarValorProd
@id_produto int,
@valor decimal(18,2) output,
@quant int output
as
begin
	select @valor=valor, @quant = quantidade from Produtos where id_produto = @id_produto
end
go

create view VW_VENDAS
AS
SELECT dbo.vendas.id_vendas, 
       dbo.vendas.num_vendas, 
       dbo.vendas.id_produto, 
       dbo.produtos.nome, 
       dbo.vendas.id_cliente, 
       dbo.clientes.nome AS Nome_Cliente, 
       dbo.vendas.funcionario, 
       dbo.vendas.quantidade, 
       dbo.vendas.valor, 
	   (dbo.vendas.quantidade*dbo.vendas.valor) as venda_total,
       dbo.vendas.data_venda,
	   dbo.produtos.quantidade as estoque
FROM   dbo.vendas 
       INNER JOIN dbo.produtos 
               ON dbo.vendas.id_produto = dbo.produtos.id_produto 
       INNER JOIN dbo.clientes 
               ON dbo.vendas.id_cliente = dbo.clientes.id_cliente 
GO

/*
SELECT 'dg.Columns('+CHAR(34)+NAME+CHAR(34)+').HeaderText = "'+name+'"' FROM SYSCOLUMNS WHERE ID=OBJECT_ID('VW_VENDAS') ORDER BY COLID


        dg.Columns(0).HeaderText = "ID"
        dg.Columns(1).HeaderText = "Nome"
        dg.Columns(2).HeaderText = "Descrição"
        dg.Columns(2).Width = 200
        dg.Columns(3).HeaderText = "Quantidade"
        dg.Columns(3).Visible = True
        dg.Columns(4).HeaderText = "Valor R$"
        dg.Columns(5).HeaderText = "Data de Cadastro"
*/


SELECT * FROM VW_VENDAS where num_vendas = (select max(num_vendas) from vendas) order by num_vendas


select * from produtos