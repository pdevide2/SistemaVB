<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvDados = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbVerDepois = New System.Windows.Forms.RadioButton()
        Me.rbAprovar = New System.Windows.Forms.RadioButton()
        Me.rbReprovar = New System.Windows.Forms.RadioButton()
        CType(Me.dgvDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDados
        '
        Me.dgvDados.AllowUserToAddRows = False
        Me.dgvDados.AllowUserToDeleteRows = False
        Me.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDados.Location = New System.Drawing.Point(12, 38)
        Me.dgvDados.Name = "dgvDados"
        Me.dgvDados.Size = New System.Drawing.Size(725, 153)
        Me.dgvDados.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtValor)
        Me.Panel1.Controls.Add(Me.txtQuantidade)
        Me.Panel1.Controls.Add(Me.txtProduto)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtPedido)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 213)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 225)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pedido"
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(69, 10)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtPedido.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Produto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(346, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Qtde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(540, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Valor"
        '
        'txtProduto
        '
        Me.txtProduto.Location = New System.Drawing.Point(69, 40)
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(246, 20)
        Me.txtProduto.TabIndex = 5
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(391, 40)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantidade.TabIndex = 6
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(585, 40)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(100, 20)
        Me.txtValor.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbReprovar)
        Me.GroupBox1.Controls.Add(Me.rbAprovar)
        Me.GroupBox1.Controls.Add(Me.rbVerDepois)
        Me.GroupBox1.Location = New System.Drawing.Point(544, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 139)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status Aprovação"
        '
        'rbVerDepois
        '
        Me.rbVerDepois.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbVerDepois.Location = New System.Drawing.Point(7, 24)
        Me.rbVerDepois.Name = "rbVerDepois"
        Me.rbVerDepois.Size = New System.Drawing.Size(127, 35)
        Me.rbVerDepois.TabIndex = 0
        Me.rbVerDepois.TabStop = True
        Me.rbVerDepois.Text = "Ver Depois"
        Me.rbVerDepois.UseVisualStyleBackColor = True
        '
        'rbAprovar
        '
        Me.rbAprovar.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAprovar.Location = New System.Drawing.Point(7, 59)
        Me.rbAprovar.Name = "rbAprovar"
        Me.rbAprovar.Size = New System.Drawing.Size(127, 35)
        Me.rbAprovar.TabIndex = 1
        Me.rbAprovar.TabStop = True
        Me.rbAprovar.Text = "Aprovar este item"
        Me.rbAprovar.UseVisualStyleBackColor = True
        '
        'rbReprovar
        '
        Me.rbReprovar.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbReprovar.Location = New System.Drawing.Point(7, 94)
        Me.rbReprovar.Name = "rbReprovar"
        Me.rbReprovar.Size = New System.Drawing.Size(127, 35)
        Me.rbReprovar.TabIndex = 2
        Me.rbReprovar.TabStop = True
        Me.rbReprovar.Text = "Reprovar este item"
        Me.rbReprovar.UseVisualStyleBackColor = True
        '
        'Test1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvDados)
        Me.Name = "Test1"
        Me.Text = "Test1"
        CType(Me.dgvDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDados As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtValor As TextBox
    Friend WithEvents txtQuantidade As TextBox
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPedido As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbReprovar As RadioButton
    Friend WithEvents rbAprovar As RadioButton
    Friend WithEvents rbVerDepois As RadioButton
End Class
