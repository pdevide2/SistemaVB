Public Class frmRelVendas
    Private Sub FrmRelVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VendasDataSet.RelVendas' table. You can move, or remove it, as needed.
        AtualizarRelatorio()

    End Sub

    Private Sub DtData_ValueChanged(sender As Object, e As EventArgs) Handles dtData.ValueChanged
        AtualizarRelatorio()

    End Sub

    Private Sub AtualizarRelatorio()
        Me.RelVendasTableAdapter.Fill(Me.VendasDataSet.RelVendas, dtData.Value.ToString("yyyyMMdd"))
        Me.ReportViewer2.RefreshReport()
    End Sub
End Class