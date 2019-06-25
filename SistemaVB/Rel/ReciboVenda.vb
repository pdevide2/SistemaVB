Public Class ReciboVenda
    Public _num_venda As String
    Public Property Num_venda() As String
        Get
            Return _num_venda
        End Get
        Set(ByVal value As String)
            _num_venda = value
        End Set
    End Property
    Private Sub ReciboVenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta linha de código carrega dados na tabela 'VendasDataSet.ReciboVenda'. Você pode movê-la ou removê-la conforme necessário.
        Me.ReciboVendaTableAdapter.Fill(Me.VendasDataSet.ReciboVenda, Me.Num_venda)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class