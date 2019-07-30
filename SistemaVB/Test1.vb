Public Class Test1
    Private _coluna_filtro As String
    Public Property ColunaFiltro() As String
        Get
            Return _coluna_filtro
        End Get
        Set(ByVal value As String)
            _coluna_filtro = value
        End Set
    End Property

    Private _filtro As String
    Public Property Filtro() As String
        Get
            Return _filtro
        End Get
        Set(ByVal value As String)
            _filtro = value
        End Set
    End Property

    Private _comando As String
    Public Property Comando() As String
        Get
            Return _comando
        End Get
        Set(ByVal value As String)
            _comando = value
        End Set
    End Property

    Private Sub Test1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carregar()

    End Sub

    Private Sub Carregar()
        Dim sql As String
        sql = "select pedido, produto, qtde, valor, status_pedido "
        sql += " , case status_pedido "
        sql += " 	when 1 then cast(1 as bit ) "
        sql += " 	else cast(0 as bit ) "
        sql += " 	end as VerDepois "
        sql += " , case status_pedido "
        sql += " 	when 2 then cast(1 as bit ) "
        sql += " 	else cast(0 as bit ) "
        sql += " 	end as Aprovar "
        sql += " , case status_pedido "
        sql += " 	when 3 then cast(1 as bit ) "
        sql += " 	else cast(0 as bit ) "
        sql += " 	end as Reprovar "
        sql += " from pedido_item "

        Me.Comando = sql
        'Me.ColunaFiltro = "ID_OS"
        'Me.Filtro = " WHERE " & Me.ColunaFiltro & " = '" & txtCodigo.Text.ToString & "'"

        Dim colPedido As DataGridViewTextBoxColumn
        Dim colProduto As DataGridViewTextBoxColumn
        Dim colQtde As DataGridViewTextBoxColumn
        Dim colValor As DataGridViewTextBoxColumn
        Dim colStatus_Pedido As DataGridViewTextBoxColumn
        Dim colAprovar As DataGridViewCheckBoxColumn
        Dim colReprovar As DataGridViewCheckBoxColumn
        Dim colVerDepois As DataGridViewCheckBoxColumn

        colPedido = New DataGridViewTextBoxColumn
        colPedido.HeaderText = "Pedido nº"
        colPedido.Name = "pedido"

        colProduto = New DataGridViewTextBoxColumn
        colProduto.HeaderText = "Produto"
        colProduto.Name = "produto"

        colQtde = New DataGridViewTextBoxColumn
        colQtde.HeaderText = "Qtde"
        colQtde.Name = "qtde"

        colValor = New DataGridViewTextBoxColumn
        colValor.HeaderText = "Valor"
        colValor.Name = "valor"

        colStatus_Pedido = New DataGridViewTextBoxColumn
        colStatus_Pedido.HeaderText = "Status"
        colStatus_Pedido.Name = "status_pedido"

        colAprovar = New DataGridViewCheckBoxColumn
        colAprovar.HeaderText = "Ver Depois"
        colAprovar.Name = "VerDepois"

        colReprovar = New DataGridViewCheckBoxColumn
        colReprovar.HeaderText = "Aprovar"
        colReprovar.Name = "aprovar"

        colVerDepois = New DataGridViewCheckBoxColumn
        colVerDepois.HeaderText = "Reprovar"
        colVerDepois.Name = "reprovar"


        dgvDados.DataSource = Nothing
        dgvDados.Rows.Clear()
        'Reset nas colunas do Grid
        dgvDados.ColumnCount = 0
        'Modifica o Default de AutoGenerate de True para False (Montagem Manual de Colunas)
        dgvDados.AutoGenerateColumns = False


        'Adicionar estas colunas para a coleçao do DataGridView
        dgvDados.Columns.AddRange(New DataGridViewColumn() {colPedido, colProduto, colQtde, colValor,
                                                            colStatus_Pedido, colAprovar,
                                                            colReprovar, colVerDepois})
        'dgvDados.DataSource = myRow
        Popula_Grid()

        'dgvDados.Columns(0).ReadOnly = False ' coluna do Botão
        For ixx = 0 To 7
            dgvDados.Columns(ixx).ReadOnly = True 'Todas as colunas Textbox são ReadOnly
        Next

        dgvDados.AllowUserToAddRows = False     'bloqueia adição de novas linhas
        dgvDados.AllowUserToDeleteRows = False  'bloqueia exclusão de linhas
        dgvDados.AutoResizeColumns()            'Autofit nas colunas para Exibição

        dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvDados.MultiSelect = False
        dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDados.AllowUserToResizeColumns = False
        dgvDados.EnableHeadersVisualStyles = False

        'Alinhamento dos dados nas colunas do Grid
        dgvDados.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDados.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDados.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDados.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDados.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDados.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDados.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    End Sub

    Private Sub Popula_Grid()
        'Faz a Query no banco e retorna uma Lista de Array do Comando SQL
        Dim myRow As ArrayList
        'myRow = BLL.GlobalBLL.PesquisarFkListaBLL(Me.Comando & Me.Filtro)

        myRow = PesquisarFkListaBLL(Comando)
        Dim ixx As Integer
        Dim strLinha As String() 'declara um array de Strings que vai armazenar uma linha de registro toda
        For ixx = 0 To myRow.Count - 1

            'Le os dados da lista de array e converte tudo para String, coluna por coluna e 
            'armazena no array de Strings strLinha, que posteriormente será adicionado no Grid
            strLinha = {myRow(ixx)(0).ToString,
                        myRow(ixx)(1).ToString,
                        myRow(ixx)(2).ToString,
                        myRow(ixx)(3).ToString,
                        myRow(ixx)(4).ToString,
                        myRow(ixx)(5).ToString,
                        myRow(ixx)(6).ToString,
                        myRow(ixx)(7).ToString}

            dgvDados.Rows.Add(strLinha)

        Next

    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles rbVerDepois.Click
        MudaFonteRadioButton(1)
        MudaCorFonteRadioButton(1)
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles rbAprovar.Click
        MudaFonteRadioButton(2)
        MudaCorFonteRadioButton(2)
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles rbReprovar.Click
        MudaFonteRadioButton(3)
        MudaCorFonteRadioButton(3)
    End Sub

    Private Sub MudaFonteRadioButton(intOption As Integer)
        If intOption = 1 Then
            rbVerDepois.Font = New Font(rbVerDepois.Font, FontStyle.Bold)
            rbAprovar.Font = New Font(rbAprovar.Font, FontStyle.Regular)
            rbReprovar.Font = New Font(rbReprovar.Font, FontStyle.Regular)
        End If
        If intOption = 2 Then
            rbVerDepois.Font = New Font(rbVerDepois.Font, FontStyle.Regular)
            rbAprovar.Font = New Font(rbAprovar.Font, FontStyle.Bold)
            rbReprovar.Font = New Font(rbReprovar.Font, FontStyle.Regular)
        End If
        If intOption = 3 Then
            rbVerDepois.Font = New Font(rbVerDepois.Font, FontStyle.Regular)
            rbAprovar.Font = New Font(rbAprovar.Font, FontStyle.Regular)
            rbReprovar.Font = New Font(rbReprovar.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub MudaCorFonteRadioButton(intOption As Integer)
        If intOption = 1 Then
            rbVerDepois.BackColor = Color.DarkGray
            rbAprovar.BackColor = Color.White
            rbReprovar.BackColor = Color.White
        End If
        If intOption = 2 Then
            rbVerDepois.BackColor = Color.White
            rbAprovar.BackColor = Color.DarkGray
            rbReprovar.BackColor = Color.White
        End If
        If intOption = 3 Then
            rbVerDepois.BackColor = Color.White
            rbAprovar.BackColor = Color.White
            rbReprovar.BackColor = Color.DarkGray
        End If
    End Sub

    Private Sub DgvDados_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDados.CellEnter

        txtPedido.Text = dgvDados.CurrentRow.Cells("pedido").Value
        txtProduto.Text = dgvDados.CurrentRow.Cells("produto").Value
        txtQuantidade.Text = dgvDados.CurrentRow.Cells("qtde").Value
        txtValor.Text = dgvDados.CurrentRow.Cells("valor").Value
        rbVerDepois.Checked = IIf(CInt(dgvDados.CurrentRow.Cells("status_pedido").Value) = 1, True, False)
        rbAprovar.Checked = IIf(CInt(dgvDados.CurrentRow.Cells("status_pedido").Value) = 2, True, False)
        rbReprovar.Checked = IIf(CInt(dgvDados.CurrentRow.Cells("status_pedido").Value) = 3, True, False)

        MudaFonteRadioButton(CInt(dgvDados.CurrentRow.Cells("status_pedido").Value))
        MudaCorFonteRadioButton(CInt(dgvDados.CurrentRow.Cells("status_pedido").Value))

    End Sub


End Class