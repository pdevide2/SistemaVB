Public Class frmRelProdutos
    Private Sub FrmRelProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProdutosDataSet.Produtos' table. You can move, or remove it, as needed.
        Me.ProdutosTableAdapter.Fill(Me.ProdutosDataSet.Produtos)
        CarregaRelatorio()

        Me.ReportViewer2.RefreshReport
    End Sub

    Private Sub CarregaRelatorio()
        '    Try
        '        Dim strReportPath As String
        '        ReportPath = "E:\Workspace\SistemaVB\SistemaVB\Rel\RelProdutos.rdlc"
        '        'ReportViewer1.LocalReport.ReportPath = strReportPath
        '        ReportViewer1.LocalReport.ReportEmbeddedResource = "SistemaVB.SistemaVB.RelProdutos.rdlc"
        '        Dim MyReportDataSource As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("ProdutosDataSet")
        '        'ReportViewer1.LocalReport.DataSources.Add(MyReportDataSource)
        '        ReportViewer1.RefreshReport()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '    End Try
    End Sub
End Class