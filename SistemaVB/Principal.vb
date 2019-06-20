Public Class Principal
    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub FuncionáriosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncionáriosToolStripMenuItem.Click
        Dim form = New funcionarios
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim form = New Clientes
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdutosToolStripMenuItem.Click
        Dim form = New Produtos
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblUsuario.Text = usuarioNome
        'lblDataSistema.Text = DateTime.Now.Date
        lblHoraSistema.Text = DateTime.Now.ToLocalTime


    End Sub

    Private Sub RegistrarVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVendaToolStripMenuItem.Click
        Dim form = New Vendas
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class