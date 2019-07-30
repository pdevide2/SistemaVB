﻿Imports System.Data.SqlClient
Module Conexao

    'Public servidor As String = ".\SQL2017DEV"
    Public servidor As String = ".\DEVELOPER"

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

    Public Function PesquisarFkListaBLL(ByVal cmdSQL As String) As ArrayList

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim myArrList As New ArrayList()

        Try
            abrir()
            da = New SqlDataAdapter(cmdSQL, conn)
            da.Fill(dt)

            For Each datarow As DataRow In dt.Rows

                myArrList.Add(datarow)

            Next

            Return myArrList
        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
            Return myArrList
        Finally
            fechar()
        End Try



    End Function

End Module
