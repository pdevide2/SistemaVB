<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaVendas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.rbClente = New System.Windows.Forms.RadioButton()
        Me.rbFuncionario = New System.Windows.Forms.RadioButton()
        Me.rbData = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.cbFuncionario = New System.Windows.Forms.ComboBox()
        Me.dtData = New System.Windows.Forms.DateTimePicker()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.BackgroundColor = System.Drawing.Color.White
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(12, 103)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(986, 335)
        Me.dg.TabIndex = 0
        '
        'rbClente
        '
        Me.rbClente.AutoSize = True
        Me.rbClente.Checked = True
        Me.rbClente.Location = New System.Drawing.Point(575, 18)
        Me.rbClente.Name = "rbClente"
        Me.rbClente.Size = New System.Drawing.Size(57, 17)
        Me.rbClente.TabIndex = 1
        Me.rbClente.TabStop = True
        Me.rbClente.Text = "Cliente"
        Me.rbClente.UseVisualStyleBackColor = True
        '
        'rbFuncionario
        '
        Me.rbFuncionario.AutoSize = True
        Me.rbFuncionario.Location = New System.Drawing.Point(659, 18)
        Me.rbFuncionario.Name = "rbFuncionario"
        Me.rbFuncionario.Size = New System.Drawing.Size(80, 17)
        Me.rbFuncionario.TabIndex = 2
        Me.rbFuncionario.Text = "Funcionário"
        Me.rbFuncionario.UseVisualStyleBackColor = True
        '
        'rbData
        '
        Me.rbData.AutoSize = True
        Me.rbData.Location = New System.Drawing.Point(766, 18)
        Me.rbData.Name = "rbData"
        Me.rbData.Size = New System.Drawing.Size(48, 17)
        Me.rbData.TabIndex = 3
        Me.rbData.Text = "Data"
        Me.rbData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(514, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Buscar"
        '
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(863, 12)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(135, 21)
        Me.cbCliente.TabIndex = 6
        '
        'cbFuncionario
        '
        Me.cbFuncionario.FormattingEnabled = True
        Me.cbFuncionario.Location = New System.Drawing.Point(863, 39)
        Me.cbFuncionario.Name = "cbFuncionario"
        Me.cbFuncionario.Size = New System.Drawing.Size(135, 21)
        Me.cbFuncionario.TabIndex = 7
        '
        'dtData
        '
        Me.dtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtData.Location = New System.Drawing.Point(863, 68)
        Me.dtData.Name = "dtData"
        Me.dtData.Size = New System.Drawing.Size(137, 20)
        Me.dtData.TabIndex = 8
        '
        'ListaVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1010, 450)
        Me.Controls.Add(Me.dtData)
        Me.Controls.Add(Me.cbFuncionario)
        Me.Controls.Add(Me.cbCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rbData)
        Me.Controls.Add(Me.rbFuncionario)
        Me.Controls.Add(Me.rbClente)
        Me.Controls.Add(Me.dg)
        Me.Name = "ListaVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ListaVendas"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg As DataGridView
    Friend WithEvents rbClente As RadioButton
    Friend WithEvents rbFuncionario As RadioButton
    Friend WithEvents rbData As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents cbFuncionario As ComboBox
    Friend WithEvents dtData As DateTimePicker
End Class
