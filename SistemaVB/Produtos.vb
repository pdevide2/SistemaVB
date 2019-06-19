Imports System.Data.SqlClient


Public Class Produtos
    Private intOperacao As Integer = Operacao.Consulta
    Private Sub Produtos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)

        StatusBotoes(intOperacao)
        Listar()
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
            da = New SqlDataAdapter("select * from Produtos", conn)
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
        dg.Columns(0).HeaderText = "ID"
        dg.Columns(1).HeaderText = "Nome"
        dg.Columns(2).HeaderText = "Descrição"
        dg.Columns(2).Width = 200
        dg.Columns(3).HeaderText = "Quantidade"
        dg.Columns(3).Visible = True
        dg.Columns(4).HeaderText = "Valor R$"
        dg.Columns(5).HeaderText = "Data de Cadastro"


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
        txtNome.Enabled = blnMode
        txtDescricao.Enabled = blnMode
        txtNome.Enabled = blnMode
        txtQuantidade.Enabled = blnMode
        txtValor.Enabled = blnMode

    End Sub

    Private Sub Limpar()
        txtNome.Text = ""
        txtDescricao.Text = ""
        txtQuantidade.Text = ""
        txtID.Text = 0
        txtValor.Text = ""
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
                    cmd = New SqlCommand("sp_salvarpro", conn)
                Else
                    cmd = New SqlCommand("sp_editarpro", conn)
                End If
                Dim pID As Integer
                If txtID.Text.Equals("") Then
                    pID = 0
                Else
                    pID = CInt(txtID.Text)
                End If
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID_PRODUTO", pID)
                cmd.Parameters.AddWithValue("@nome", txtNome.Text)
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text)
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text)
                cmd.Parameters.AddWithValue("valor", CDbl(txtValor.Text))
                cmd.Parameters.AddWithValue("@data_cadastro", DateTime.Now.Date)
                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2

                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Listar()
                Limpar()

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
        If txtNome.Text = "" Or txtDescricao.Text = "" Then
            ValidaCampos = True
        End If
    End Function

    Private Sub Dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick

        btnNovo.Enabled = True
        btnEditar.Enabled = True
        btnExcluir.Enabled = True
        txtID.Text = dg.CurrentRow.Cells(0).Value
        txtNome.Text = dg.CurrentRow.Cells(1).Value
        txtDescricao.Text = dg.CurrentRow.Cells(2).Value
        txtQuantidade.Text = dg.CurrentRow.Cells(3).Value
        txtValor.Text = dg.CurrentRow.Cells(4).Value


    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If MessageBox.Show("Confirma exclusão", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmd As SqlCommand
            intOperacao = Operacao.Exclusao
            HabilitarCampos(intOperacao)
            StatusBotoes(intOperacao)

            Try
                abrir()
                cmd = New SqlCommand("sp_ExcluirproPorId", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@id_produto", txtID.Text)
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
                lblTotalReg.Text = CInt(intTotal)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If dg.Rows.Count > 0 Then

            If txtBuscar.Text.Equals("") Then

                Listar()

            Else

                BuscarPorNome()

            End If

        End If

    End Sub

    Private Sub BuscarPorNome()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("sp_buscarproNome", conn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@nome", txtBuscar.Text)
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


End Class