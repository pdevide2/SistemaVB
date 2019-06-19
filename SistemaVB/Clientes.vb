Imports System.Data.SqlClient


Public Class Clientes
    Private intOperacao As Integer = Operacao.Consulta
    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)

        StatusBotoes(intOperacao)


        txtBuscaCPF.Visible = False
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
            da = New SqlDataAdapter("select * from Clientes", conn)
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
        dg.Columns(0).Visible = False
        dg.Columns(1).HeaderText = "Nome"
        dg.Columns(2).HeaderText = "Sexo"
        dg.Columns(2).Width = 70
        dg.Columns(3).HeaderText = "CPF"
        dg.Columns(3).Visible = False
        dg.Columns(4).HeaderText = "Endereço"
        dg.Columns(5).HeaderText = "Telefone"
        dg.Columns(6).HeaderText = "E-mail"
        dg.Columns(6).Width = 130
        dg.Columns(7).HeaderText = "Turno"
        dg.Columns(7).Width = 70
        dg.Columns(8).HeaderText = "Data Cadastro"


    End Sub

    Private Sub HabilitarCampos(_operacao As Integer)
        Dim blnMode As Boolean
        Select Case intOperacao
            Case Operacao.Consulta, Operacao.Exclusao
                blnMode = False
            Case Operacao.Novo, Operacao.Edicao
                blnMode = True
        End Select

        txtNome.Enabled = blnMode
        txtCPF.Enabled = blnMode
        txtEndereco.Enabled = blnMode
        txtNome.Enabled = blnMode
        txtTelefone.Enabled = blnMode
        cbSexo.Enabled = blnMode
        'cbTurno.Enabled = blnMode
        dtData.Enabled = blnMode
        txtEmail.Enabled = blnMode

    End Sub

    Private Sub Limpar()
        txtNome.Text = ""
        txtCPF.Text = ""
        txtEndereco.Text = ""
        txtNome.Text = ""
        txtTelefone.Text = ""
        cbSexo.Text = ""
        'cbTurno.Text = ""
        dtData.Value = DateTime.Now

    End Sub

    Private Sub RbNome_CheckedChanged(sender As Object, e As EventArgs) Handles rbNome.CheckedChanged

        txtBuscaCPF.Text = ""
        txtBuscar.Text = ""
        txtBuscar.Visible = True
        txtBuscaCPF.Visible = False
        txtBuscar.Focus()

    End Sub

    Private Sub RbCPF_CheckedChanged(sender As Object, e As EventArgs) Handles rbCPF.CheckedChanged

        txtBuscaCPF.Top = 7
        txtBuscaCPF.Text = ""
        txtBuscar.Text = ""
        txtBuscar.Visible = False
        txtBuscaCPF.Visible = True
        txtBuscaCPF.Focus()

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
                    cmd = New SqlCommand("sp_salvarcli", conn)
                Else
                    cmd = New SqlCommand("sp_editarcli", conn)
                End If

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nome", txtNome.Text)
                cmd.Parameters.AddWithValue("@sexo", cbSexo.Text)
                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text)
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text)
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                'cmd.Parameters.AddWithValue("@turno", cbTurno.Text)
                cmd.Parameters.AddWithValue("@data_cadastro", CDate(dtData.Text))
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
        If txtCPF.Text = "" Or txtNome.Text = "" Then
            ValidaCampos = True
        End If
    End Function

    Private Sub Dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick

        btnNovo.Enabled = True
        btnEditar.Enabled = True
        btnExcluir.Enabled = True

        txtCPF.Enabled = False
        txtNome.Text = dg.CurrentRow.Cells(1).Value
        cbSexo.Text = dg.CurrentRow.Cells(2).Value
        txtCPF.Text = dg.CurrentRow.Cells(3).Value
        txtEndereco.Text = dg.CurrentRow.Cells(4).Value
        txtTelefone.Text = dg.CurrentRow.Cells(5).Value
        txtEmail.Text = dg.CurrentRow.Cells(6).Value
        'cbTurno.Text = dg.CurrentRow.Cells(7).Value
        dtData.Value = dg.CurrentRow.Cells(8).Value


    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If MessageBox.Show("Confirma exclusão", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmd As SqlCommand
            intOperacao = Operacao.Exclusao
            HabilitarCampos(intOperacao)
            StatusBotoes(intOperacao)

            Try
                abrir()
                cmd = New SqlCommand("sp_ExcluircliPorCPF", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text)
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

    Private Sub TxtBuscaCPF_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaCPF.TextChanged
        If dg.Rows.Count > 0 Then

            If txtBuscaCPF.Text.Equals("   ,   ,   -  ") Then

                Listar()

            Else

                BuscarPorCPF()

            End If

        End If
    End Sub

    Private Sub BuscarPorCPF()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("sp_buscarcliCPF", conn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@cpf", txtBuscaCPF.Text)
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

    Private Sub ContarLinhas()
        Try
            Dim intTotal As Integer = dg.Rows.Count '- 1
            lblTotalReg.Text = CInt(intTotal)

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
            da = New SqlDataAdapter("sp_buscarcliNome", conn)
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