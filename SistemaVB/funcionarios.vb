Public Class funcionarios
    Private Sub Funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HabilitarCampos(False)

    End Sub

    Private Sub HabilitarCampos(blnMode As Boolean)

        txtNome.Enabled = blnMode
        txtCPF.Enabled = blnMode
        txtEndereco.Enabled = blnMode
        txtNome.Enabled = blnMode
        txtTelefone.Enabled = blnMode
        cbSexo.Enabled = blnMode
        cbTurno.Enabled = blnMode
        dtData.Enabled = blnMode

    End Sub

    Private Sub Limpar()
        txtNome.Text = ""
        txtCPF.Text = ""
        txtEndereco.Text = ""
        txtNome.Text = ""
        txtTelefone.Text = ""
        cbSexo.Text = ""
        cbTurno.Text = ""
        dtData.Value = DateTime.Now

    End Sub
End Class