'Componente visual do tipo UserControl que implementa o gráfico de gantt
Public Class Gantt
    'Representação interna dos atributos
    Dim LocProcessos As Processos = Nothing
    Dim locTamanhoDoInstante As Integer = 15
    'Lista de cores usadas para representação de cada processo
    'criada dinamicamente
    Dim Cores As New System.Collections.Generic.Dictionary(Of Integer, System.Drawing.Brush)
    'Margens esquerda e superior do componente
    Const MargemEsquerda As Integer = 10
    Const MargemSuperior As Integer = 10
    'Altura padrão da representação gráfica do processo
    Const Altura As Integer = 40
    'Altura da haste que liga o proceso ao seu rótulo de tempo
    Const HasteDeRotulo As Integer = 10

    'Define ou retorna a lista de processos a ser representada
    Public Property Processos() As Processos
        Get
            Return Me.LocProcessos
        End Get
        Set(ByVal NovoValor As Processos)
            Me.LocProcessos = NovoValor
            Atualizar()
        End Set
    End Property

    'Defiine o tamnho em pixels de cada instante
    Public Property TamanhoDoInstante() As Integer
        Get
            Return Me.locTamanhoDoInstante
        End Get
        Set(ByVal NovoValor As Integer)
            Me.locTamanhoDoInstante = NovoValor
            Atualizar()
        End Set
    End Property

    'Redimensiona automaticamente o componente e força a atualização
    Public Sub Atualizar()
        'Força uma atualização da tela
        Redimensionar()
        Me.Refresh()
    End Sub

    'É chamado sempre que uma nova área da tela é exposta ou o método refresh é chamado
    Private Sub Gantt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Requisita a atualização do gráfico passando como parâmetro a lista de processos e a área gráfica do componente
        PintarGrafico(LocProcessos, e.Graphics)
    End Sub

    'Repinta o gráfico na tela
    Private Sub PintarGrafico(ByVal Processos As Processos, ByVal G As System.Drawing.Graphics)
        'Desenha a linha que demarca o instante inicial
        G.DrawLine(Pens.Black, MargemEsquerda, MargemSuperior, MargemEsquerda, MargemSuperior + Altura + HasteDeRotulo)
        'Cria uma fonte, área de desenho e formatação de string
        Dim FontePadrao As New Font("Arial", 10)
        Dim Retangulo As New RectangleF(MargemEsquerda - 8, MargemSuperior + Altura + HasteDeRotulo + 1, 16, 40)
        Dim Formato As New StringFormat
        'Centraliza o texto 
        Formato.Alignment = StringAlignment.Center
        Formato.LineAlignment = StringAlignment.Center
        'Orienta o texto verticalmente
        Formato.FormatFlags = StringFormatFlags.DirectionVertical
        'Desenha aborda do rótulo de tempo
        G.DrawRectangle(Pens.Black, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
        'Coloca o texto sobre o rótulo
        G.DrawString("0", FontePadrao, Brushes.Black, Retangulo, Formato)
        'Se existe uma lista de processos
        If Not LocProcessos Is Nothing Then
            'Para cada processo da lista
            For Each P As Processo In Processos
                'Obtém o pincel para coloração do rótulo e do processo, criando um novo se necessário
                Dim Pincel As System.Drawing.Brush = ObterPrincel(P.id)
                'Coordenada X inicial
                Dim X As Integer = P.Inicio * locTamanhoDoInstante + MargemEsquerda
                'Coordenada Y inicial
                Dim Y As Integer = MargemSuperior
                'Largura da representação gráfica do processo
                Dim L As Integer = P.Tempo * locTamanhoDoInstante
                'Altura da representação gráfica do processo
                Dim TmpAltura As Integer = Altura
                'Distância entre o topo da representação gráfica do processo até
                'a extremidade inferior da haste que liga esta representação ao rótulo de tempo
                Dim TmpAltura2 As Integer = Altura + HasteDeRotulo
                'Pinta a área do processo
                G.FillRectangle(Pincel, X, Y, L, TmpAltura)
                'Desenha a borda na cor preta
                G.DrawRectangle(Pens.Black, X, Y, L, TmpAltura)
                'Desenha a haste que liga ao rótulo de tempo
                G.DrawLine(Pens.Black, X + L, Y, X + L, Y + TmpAltura2)
                'Cria o retângulo referente ao rótulo de tempo do processo
                Retangulo = New RectangleF(X + L - 8, Y + TmpAltura2 + 1, 16, 40)
                'Confirura a orientação do texto na vertical, centralizando-o usado para desenhá-lo
                Formato = New StringFormat
                Formato.Alignment = StringAlignment.Center
                Formato.LineAlignment = StringAlignment.Center
                Formato.FormatFlags = StringFormatFlags.DirectionVertical
                'Imprime rótulos dos instantes com o mesmo preenchimento do processo
                G.FillRectangle(Pincel, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
                G.DrawRectangle(Pens.Black, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
                'Imprime o instante de encerramento do processo
                G.DrawString((P.Inicio + P.Tempo).ToString, FontePadrao, Brushes.Black, Retangulo, Formato)
                'Cria o retângulo referente ao rótulo de identificação do processo
                Retangulo = New RectangleF(X, Y, L, TmpAltura)
                'Imprime a identificação dos processos
                G.DrawString("P" & P.id.ToString, FontePadrao, Brushes.Black, Retangulo, Formato)
            Next
        End If
    End Sub

    'Sempre que o componente for redimensionado
    Private Sub Gantt_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Força o tamanho conforme o conteúdo
        Redimensionar()
    End Sub

    'Ajusta o tamanho do componete conforme o ocnteúdo
    Private Sub Redimensionar()
        'Assume a largura padrão igual a zero
        Dim L As Integer = 0
        'Assume a altura padrão (fixa conforme contantes definidas)
        Dim A As Integer = Altura + HasteDeRotulo * 2 + MargemSuperior * 2 + 40
        'Se houver uma lista de processos
        If Not IsNothing(LocProcessos) Then
            'Assume o tamanho pelo conteúdo
            L = LocProcessos.TempoTotal * locTamanhoDoInstante
        End If
        'Se não foi definido um tamanho
        If L < 1 Then
            'Assume um valor fixo
            L = 100
        Else 'Caso contrário
            'Adiciona as margens e um espaço extra
            L += (MargemEsquerda * 3)
        End If
        'Define o tamanho automaticamente
        Me.Size = New Size(L, A)
    End Sub

    'Gera pincéis a artir de componentes RGB produzidos aleatoriamente
    Private Function PincelAleatorio() As Brush
        Dim R As Integer = 0
        Dim G As Integer = 0
        Dim B As Integer = 0
        Const Limite As Integer = 191
        'Este loop garante que será gerada uma cor clara
        While R < Limite And G < Limite And B < Limite
            R = Rnd() * 255 'Componente R
            G = Rnd() * 255 'Componente G
            B = Rnd() * 255 'Componente B
        End While
        'Gera uma "caneta" a partir da cor obtida
        Dim Pen As New Pen(System.Drawing.Color.FromArgb(R, G, B))
        'Devolve o "pincel" correspondente
        Return Pen.Brush
    End Function

    'Retorna o pincel associado a um ID, criando um se ainha não houuver uma associação
    Private Function ObterPrincel(ByVal Id As Integer) As Brush
        'Se ainda não contém o ID
        If Not Cores.ContainsKey(Id) Then
            'Cria um novo pincel aleatório
            Dim Pincel As Brush = PincelAleatorio()
            'Adiciona à lista
            Cores.Add(Id, Pincel)
        End If
        'Retorna o pincel associado ao ID
        Return Cores(Id)
    End Function

    Private Sub Gantt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
