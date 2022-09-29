<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Gantt1 = New PrjProcessos.Gantt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanAtributos = New System.Windows.Forms.Panel()
        Me.CmdSobre = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdExecutar = New System.Windows.Forms.Button()
        Me.CmdAbrir = New System.Windows.Forms.Button()
        Me.TxtArquivoEntrada = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LstAlgoritmo = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtRelatorio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Gantt1)
        Me.Panel1.Location = New System.Drawing.Point(12, 226)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(755, 131)
        Me.Panel1.TabIndex = 1
        '
        'Gantt1
        '
        Me.Gantt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Gantt1.Location = New System.Drawing.Point(8, 8)
        Me.Gantt1.Margin = New System.Windows.Forms.Padding(4)
        Me.Gantt1.Name = "Gantt1"
        Me.Gantt1.Processos = Nothing
        Me.Gantt1.Size = New System.Drawing.Size(100, 120)
        Me.Gantt1.TabIndex = 0
        Me.Gantt1.TamanhoDoInstante = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PanAtributos)
        Me.GroupBox1.Controls.Add(Me.CmdSobre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmdExecutar)
        Me.GroupBox1.Controls.Add(Me.CmdAbrir)
        Me.GroupBox1.Controls.Add(Me.TxtArquivoEntrada)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LstAlgoritmo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(755, 195)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configurações"
        '
        'PanAtributos
        '
        Me.PanAtributos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanAtributos.AutoScroll = True
        Me.PanAtributos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanAtributos.Location = New System.Drawing.Point(216, 33)
        Me.PanAtributos.Name = "PanAtributos"
        Me.PanAtributos.Size = New System.Drawing.Size(527, 54)
        Me.PanAtributos.TabIndex = 10
        '
        'CmdSobre
        '
        Me.CmdSobre.Image = Global.PrjProcessos.My.Resources.Resources.Help
        Me.CmdSobre.Location = New System.Drawing.Point(118, 139)
        Me.CmdSobre.Name = "CmdSobre"
        Me.CmdSobre.Size = New System.Drawing.Size(48, 48)
        Me.CmdSobre.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdSobre, "Sobre o programa...")
        Me.CmdSobre.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.Info
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label3.Location = New System.Drawing.Point(172, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(572, 46)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'CmdExecutar
        '
        Me.CmdExecutar.Image = Global.PrjProcessos.My.Resources.Resources.Executar
        Me.CmdExecutar.Location = New System.Drawing.Point(66, 138)
        Me.CmdExecutar.Name = "CmdExecutar"
        Me.CmdExecutar.Size = New System.Drawing.Size(48, 48)
        Me.CmdExecutar.TabIndex = 7
        Me.CmdExecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.CmdExecutar, "Simular Algoritmo")
        Me.CmdExecutar.UseVisualStyleBackColor = True
        '
        'CmdAbrir
        '
        Me.CmdAbrir.Image = Global.PrjProcessos.My.Resources.Resources.Abrir
        Me.CmdAbrir.Location = New System.Drawing.Point(12, 138)
        Me.CmdAbrir.Name = "CmdAbrir"
        Me.CmdAbrir.Size = New System.Drawing.Size(48, 48)
        Me.CmdAbrir.TabIndex = 7
        Me.CmdAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.CmdAbrir, "Selecionar arquivo de entrada")
        Me.CmdAbrir.UseVisualStyleBackColor = True
        '
        'TxtArquivoEntrada
        '
        Me.TxtArquivoEntrada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtArquivoEntrada.Location = New System.Drawing.Point(12, 112)
        Me.TxtArquivoEntrada.Name = "TxtArquivoEntrada"
        Me.TxtArquivoEntrada.Size = New System.Drawing.Size(732, 20)
        Me.TxtArquivoEntrada.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Arquivo de entrada:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Atributos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Algoritmo:"
        '
        'LstAlgoritmo
        '
        Me.LstAlgoritmo.FormattingEnabled = True
        Me.LstAlgoritmo.Items.AddRange(New Object() {"First Come, First Served (FCFS)", "Shortest Job First (SJF)", "Shortest Remaining Time First (SRTF)", "Round Robin", "Prioridade Cooperativo", "Prioridade Preemptivo"})
        Me.LstAlgoritmo.Location = New System.Drawing.Point(9, 32)
        Me.LstAlgoritmo.Name = "LstAlgoritmo"
        Me.LstAlgoritmo.Size = New System.Drawing.Size(202, 56)
        Me.LstAlgoritmo.TabIndex = 3
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TxtRelatorio)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 361)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(755, 223)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Relatório:"
        '
        'TxtRelatorio
        '
        Me.TxtRelatorio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRelatorio.Font = New System.Drawing.Font("Lucida Console", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRelatorio.Location = New System.Drawing.Point(12, 19)
        Me.TxtRelatorio.Multiline = True
        Me.TxtRelatorio.Name = "TxtRelatorio"
        Me.TxtRelatorio.ReadOnly = True
        Me.TxtRelatorio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtRelatorio.Size = New System.Drawing.Size(732, 199)
        Me.TxtRelatorio.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 205)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Diagrama de Gantt"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 587)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(522, 457)
        Me.Name = "FrmPrincipal"
        Me.Text = "Diagramador de Escalonamento de Processos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gantt1 As Gantt
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LstAlgoritmo As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtArquivoEntrada As System.Windows.Forms.TextBox
    Friend WithEvents CmdAbrir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdExecutar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRelatorio As System.Windows.Forms.TextBox
    Friend WithEvents CmdSobre As System.Windows.Forms.Button
    Friend WithEvents PanAtributos As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As Label
End Class
