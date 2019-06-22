Imports System.Data.SqlClient

Public Class ListaVendas
    Private Sub ListaVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarClientes()
        CarregarFuncionarios()
        Listar()
    End Sub

    Private Sub RbClente_CheckedChanged(sender As Object, e As EventArgs) Handles rbClente.CheckedChanged
        cbCliente.Visible = True
        cbCliente.Top = 16
        cbFuncionario.Visible = False
        dtData.Visible = False

    End Sub

    Private Sub RbFuncionario_CheckedChanged(sender As Object, e As EventArgs) Handles rbFuncionario.CheckedChanged
        cbFuncionario.Visible = True
        cbFuncionario.Top = 16
        cbCliente.Visible = False
        dtData.Visible = False

    End Sub

    Private Sub RbData_CheckedChanged(sender As Object, e As EventArgs) Handles rbData.CheckedChanged
        cbFuncionario.Visible = False
        dtData.Top = 16
        cbCliente.Visible = False
        dtData.Visible = True

    End Sub
    Sub CarregarClientes()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM clientes", conn)
            DA.Fill(DT)
            cbCliente.DisplayMember = "nome"
            cbCliente.ValueMember = "id_cliente"
            cbCliente.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        fechar()
    End Sub
    Sub CarregarFuncionarios()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM funcionarios", conn)
            DA.Fill(DT)
            cbFuncionario.DisplayMember = "nome"
            cbFuncionario.ValueMember = "nome"
            cbFuncionario.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        fechar()
    End Sub
    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim cmd As SqlCommand

        Try
            abrir()
            cmd = New SqlCommand("select * from VW_VENDAS where data_venda =  @data and funcionario = @funcionario order by num_vendas desc", conn)
            cmd.Parameters.AddWithValue("@data", Now.Date())
            cmd.Parameters.AddWithValue("@funcionario", usuarioNome)
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
            dg.DataSource = dt


            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar" + ex.Message)
            fechar()
        End Try

    End Sub
    Private Sub Listar(sql As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)
            dg.DataSource = dt


            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar" + ex.Message)
            fechar()
        End Try

    End Sub
    Private Sub FormatarDG()


        dg.Columns("id_vendas").HeaderText = "id_vendas"
        dg.Columns("id_vendas").Visible = False
        dg.Columns("num_vendas").HeaderText = "num_vendas"
        dg.Columns("id_produto").HeaderText = "id_produto"
        dg.Columns("id_produto").Visible = False
        dg.Columns("nome").HeaderText = "nome"
        dg.Columns("id_cliente").HeaderText = "id_cliente"
        dg.Columns("id_cliente").Visible = False
        dg.Columns("Nome_Cliente").HeaderText = "Nome_Cliente"
        dg.Columns("funcionario").HeaderText = "funcionario"
        dg.Columns("quantidade").HeaderText = "quantidade"
        dg.Columns("valor").HeaderText = "valor"
        dg.Columns("venda_total").HeaderText = "venda_total"
        dg.Columns("data_venda").HeaderText = "data_venda"
        dg.Columns("estoque").HeaderText = "Estoque"


    End Sub

    Private Sub CbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCliente.SelectedIndexChanged
        Dim sql As String
        sql = "select * from VW_VENDAS where id_cliente = " & cbCliente.SelectedValue & " order by num_vendas desc"
        Listar(sql)
    End Sub

    Private Sub CbFuncionario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFuncionario.SelectedIndexChanged
        Dim sql As String
        sql = "select * from VW_VENDAS where funcionario = '" & cbFuncionario.Text & "' order by num_vendas desc"
        Listar(sql)
    End Sub

    Private Sub DtData_ValueChanged(sender As Object, e As EventArgs) Handles dtData.ValueChanged
        Dim sql As String
        sql = "select * from VW_VENDAS where DATA_VENDA = '" & dtData.Value.ToString("yyyyMMdd") & "' order by num_vendas desc"
        Listar(sql)
    End Sub
End Class