Imports System.Data.SqlClient
Module Conexao

    Public servidor As String = ".\SQL2017DEV"
    'Public conn As New SqlConnection("Server = .\DEVELOPER; Database=dbSistemaVB; Trusted_Connection=True")
    Public conn As New SqlConnection("Server = " & servidor & "; Database=dbSistemaVB; Trusted_Connection=True")
    Sub abrir()
        If conn.State = 0 Then
            conn.Open()
        End If
    End Sub
    Sub fechar()
        If conn.State = 1 Then
            conn.Close()
        End If
    End Sub
End Module
