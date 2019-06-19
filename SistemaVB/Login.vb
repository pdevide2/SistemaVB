Imports System.Data.SqlClient

Public Class Login
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If Not ValidaSenha(txtUsuario.Text, txtSenha.Text) Then
            MessageBox.Show("Dados Incorretos - autenticação inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUsuario.Text = ""
            txtSenha.Text = ""
            txtUsuario.Focus()
        Else
            Me.Hide()
            Dim form = New Principal
            form.ShowDialog()
        End If

    End Sub

    Private Function ValidaSenha(_usuario As String, _senha As String) As Boolean
        ValidaSenha = False
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = "select nome, convert(varchar(100),DecryptByPassPhrase('key', senha )) senha2 from funcionarios " &
            "where nome = '" & Trim(_usuario) & "' and convert(varchar(100),DecryptByPassPhrase('key', senha )) = '" & Trim(_senha) & "'; "
        Try
            abrir()
            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ValidaSenha = True
                MessageBox.Show("Bem vindo " & _usuario, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
            fechar()
        End Try

    End Function
End Class
