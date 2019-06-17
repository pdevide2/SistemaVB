Imports System.Data.SqlClient
Module Conexao
    Public conexao As New SqlConnection("Server = .\DEVELOPER; Database=dbSistemaVB; Trusted_Connection=True")

    Sub abrir()
        If conexao.State = 0 Then
            conexao.Open()
        End If
    End Sub
    Sub fechar()
        If conexao.State = 1 Then
            conexao.Close()
        End If
    End Sub
End Module
