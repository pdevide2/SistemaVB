Public Class Login
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim form = New Principal
        form.ShowDialog()

    End Sub
End Class
