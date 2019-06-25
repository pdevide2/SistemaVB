Imports System.Data.SqlClient


Public Class Vendas
    Private intOperacao As Integer = Operacao.Consulta
    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)

        StatusBotoes(intOperacao)
        Listar()
        CarregarProdutos()
        CarregarClientes()
    End Sub

    Private Sub StatusBotoes(intOperacao As Integer)
        Select Case intOperacao
            Case Operacao.Consulta
                btnNovo.Enabled = True
                btnSalvar.Enabled = False
                btnUndo.Enabled = False
                btnEditar.Enabled = False
                btnExcluir.Enabled = False
            Case Operacao.Novo, Operacao.Edicao
                btnNovo.Enabled = False
                btnSalvar.Enabled = True
                btnUndo.Enabled = True
                btnEditar.Enabled = False
                btnExcluir.Enabled = False
            Case Operacao.Exclusao
                btnNovo.Enabled = False
                btnSalvar.Enabled = False
                btnUndo.Enabled = False
                btnEditar.Enabled = False
                btnExcluir.Enabled = False

        End Select
    End Sub

    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM VW_VENDAS where num_vendas = (select max(num_vendas) from vendas) order by num_vendas", conn)
            da.Fill(dt)
            dg.DataSource = dt

            ContarLinhas()
            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
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

    Private Sub HabilitarCampos(_operacao As Integer)
        Dim blnMode As Boolean
        Select Case intOperacao
            Case Operacao.Consulta, Operacao.Exclusao
                blnMode = False
            Case Operacao.Novo, Operacao.Edicao
                blnMode = True
        End Select
        txtID.Enabled = False
        txtQuantidade.Enabled = blnMode
        'txtValor.Enabled = blnMode
        txtDataVenda.Enabled = blnMode
        txtNum.Enabled = blnMode
        cbCliente.Enabled = blnMode
        cbProduto.Enabled = blnMode


    End Sub

    Private Sub Limpar()
        txtID.Text = 0
        txtQuantidade.Text = ""
        txtValor.Text = ""
        txtDataVenda.Text = ""
        txtNum.Text = ""
        cbCliente.Text = ""
        cbProduto.Text = ""
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        intOperacao = Operacao.Edicao
        HabilitarCampos(intOperacao)
        StatusBotoes(intOperacao)


    End Sub

    Private Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        intOperacao = Operacao.Novo
        HabilitarCampos(intOperacao)
        Limpar()
        StatusBotoes(intOperacao)

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim cmd As SqlCommand

        If Not ValidaCampos() Then

            Try
                abrir()
                If intOperacao = Operacao.Novo Then
                    cmd = New SqlCommand("sp_salvarvenda", conn)
                Else
                    cmd = New SqlCommand("sp_editarvenda", conn)
                End If
                Dim pID As Integer
                If txtID.Text.Equals("") Then
                    pID = 0
                Else
                    pID = CInt(txtID.Text)
                End If
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@id_vendas", pID)
                cmd.Parameters.AddWithValue("@num_vendas", CInt(txtNum.Text))
                cmd.Parameters.AddWithValue("@id_produto", CInt(cbProduto.SelectedValue))
                cmd.Parameters.AddWithValue("@id_cliente", CInt(cbCliente.SelectedValue))
                cmd.Parameters.AddWithValue("@funcionario", usuarioNome)
                cmd.Parameters.AddWithValue("@quantidade", CInt(txtQuantidade.Text))
                cmd.Parameters.AddWithValue("valor", CDbl(txtValor.Text))
                'cmd.Parameters.AddWithValue("@data_venda", DateTime.Now.Date)
                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2




                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Listar()
                totalizar()
                PreencheControles()
                'Limpar()

            Catch ex As Exception
                MessageBox.Show("Erro ao salvar os dados " + ex.Message)
            Finally
                fechar()
                intOperacao = Operacao.Consulta
                HabilitarCampos(intOperacao)
                StatusBotoes(intOperacao)



            End Try
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        ValidaCampos = False
        If txtNum.Text = "" Then
            ValidaCampos = True
        End If
        Dim intEstoque As Integer = txtEstoque.Text
        Dim intQuant As Integer = txtQuantidade.Text
        Dim intResult As Integer = (intEstoque - intQuant)
        If intResult < 0 Then
            MessageBox.Show("Quantidade em estoque insuficiente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ValidaCampos = True
        End If
    End Function

    Private Sub Dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick

        btnNovo.Enabled = True
        btnEditar.Enabled = True
        btnExcluir.Enabled = True

        PreencheControles()

    End Sub

    Private Sub PreencheControles()

        If dg.Rows.Count > 0 Then
            txtID.Text = CInt(dg.CurrentRow.Cells(0).Value)
            txtQuantidade.Text = dg.CurrentRow.Cells("quantidade").Value
            txtValor.Text = dg.CurrentRow.Cells("valor").Value
            txtDataVenda.Text = dg.CurrentRow.Cells("data_venda").Value
            txtNum.Text = dg.CurrentRow.Cells("num_vendas").Value
            cbCliente.SelectedValue = dg.CurrentRow.Cells("id_cliente").Value
            cbProduto.SelectedValue = dg.CurrentRow.Cells("id_produto").Value
            txtEstoque.Text = dg.CurrentRow.Cells("estoque").Value
        End If

    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If MessageBox.Show("Confirma exclusão", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmd As SqlCommand
            intOperacao = Operacao.Exclusao
            HabilitarCampos(intOperacao)
            StatusBotoes(intOperacao)

            Try
                abrir()
                cmd = New SqlCommand("sp_ExcluirVendaPorId", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@id_vendas", txtID.Text)
                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Catch ex As Exception
                MessageBox.Show("Erro ao excluir os dados " + ex.Message)
            Finally
                fechar()
                intOperacao = Operacao.Consulta
                HabilitarCampos(intOperacao)
                StatusBotoes(intOperacao)

                Listar()

            End Try

        End If

    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click

        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)
        StatusBotoes(intOperacao)
        Limpar()

    End Sub

    Private Sub ContarLinhas()
        Try
            If dg.Rows.Count > 0 Then

                Dim intTotal As Integer = dg.Rows.Count '- 1
                lblTotalVenda.Text = CInt(intTotal)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        LocalizarVenda()

    End Sub

    Private Sub LocalizarVenda()
        If dg.Rows.Count > 0 Then

            If txtBuscar.Text.Equals("") Then

                Listar()

            Else

                BuscarPorNome()

            End If
        Else

            Listar()

        End If
        PreencheControles()
        totalizar()
    End Sub

    Private Sub BuscarPorNome()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("sp_buscarvenda", conn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@num_vendas", txtBuscar.Text)
            da.Fill(dt)
            dg.DataSource = dt

            ContarLinhas()
            FormatarDG()
        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
            fechar()
        End Try

    End Sub

    Sub CarregarProdutos()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM produtos", conn)
            DA.Fill(DT)
            cbProduto.DisplayMember = "nome"
            cbProduto.ValueMember = "id_produto"
            cbProduto.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        fechar()
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

    Private Sub CbProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduto.SelectedIndexChanged
        Dim cmd As New SqlCommand("buscarValorProd", conn)
        Try
            abrir()
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
            cmd.Parameters.Add("@valor", SqlDbType.Decimal).Direction = 2
            cmd.Parameters.Add("@quant", SqlDbType.Int).Direction = 2
            cmd.ExecuteNonQuery()

            Dim valor As Decimal = cmd.Parameters("@valor").Value
            txtValor.Text = CStr(valor)

            Dim quant As Int32 = cmd.Parameters("@quant").Value
            txtEstoque.Text = CStr(quant)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        fechar()
    End Sub

    Private Sub totalizar()
        Dim total As Decimal
        For Each lin As DataGridViewRow In dg.Rows
            total = total + lin.Cells("venda_total").Value
        Next

        lblTotalVenda.Text = total
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LocalizarVenda()
    End Sub

    Private Sub BtnRecibo_Click(sender As Object, e As EventArgs) Handles btnRecibo.Click
        Dim form As New ReciboVenda
        form.Num_venda = txtNum.Text
        form.Show()
    End Sub
End Class