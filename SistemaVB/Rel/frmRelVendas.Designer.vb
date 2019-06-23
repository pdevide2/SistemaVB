<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelVendas
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtData = New System.Windows.Forms.DateTimePicker()
        Me.RelVendasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendasDataSet = New SistemaVB.VendasDataSet()
        Me.RelVendasTableAdapter = New SistemaVB.VendasDataSetTableAdapters.RelVendasTableAdapter()
        CType(Me.RelVendasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(396, 246)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.RelVendasBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "SistemaVB.RelVenda.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 38)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.ServerReport.BearerToken = Nothing
        Me.ReportViewer2.Size = New System.Drawing.Size(870, 514)
        Me.ReportViewer2.TabIndex = 0
        '
        'dtData
        '
        Me.dtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtData.Location = New System.Drawing.Point(764, 12)
        Me.dtData.Name = "dtData"
        Me.dtData.Size = New System.Drawing.Size(104, 20)
        Me.dtData.TabIndex = 1
        '
        'RelVendasBindingSource
        '
        Me.RelVendasBindingSource.DataMember = "RelVendas"
        Me.RelVendasBindingSource.DataSource = Me.VendasDataSet
        '
        'VendasDataSet
        '
        Me.VendasDataSet.DataSetName = "VendasDataSet"
        Me.VendasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RelVendasTableAdapter
        '
        Me.RelVendasTableAdapter.ClearBeforeFill = True
        '
        'frmRelVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 552)
        Me.Controls.Add(Me.dtData)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Name = "frmRelVendas"
        Me.Text = "frmRelVendas"
        CType(Me.RelVendasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RelVendasBindingSource As BindingSource
    Friend WithEvents VendasDataSet As VendasDataSet
    Friend WithEvents RelVendasTableAdapter As VendasDataSetTableAdapters.RelVendasTableAdapter
    Friend WithEvents dtData As DateTimePicker
End Class
