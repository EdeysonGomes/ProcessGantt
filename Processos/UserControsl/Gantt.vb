'Componente visual do tipo UserControl que implementa o gr�fico de gantt
Public Class Gantt
    'Representa��o interna dos atributos
    Dim LocProcessos As Processos = Nothing
    Dim locTamanhoDoInstante As Integer = 15
    'Lista de cores usadas para representa��o de cada processo
    'criada dinamicamente
    Dim Cores As New System.Collections.Generic.Dictionary(Of Integer, System.Drawing.Brush)
    'Margens esquerda e superior do componente
    Const MargemEsquerda As Integer = 10
    Const MargemSuperior As Integer = 10
    'Altura padr�o da representa��o gr�fica do processo
    Const Altura As Integer = 40
    'Altura da haste que liga o proceso ao seu r�tulo de tempo
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

    'Redimensiona automaticamente o componente e for�a a atualiza��o
    Public Sub Atualizar()
        'For�a uma atualiza��o da tela
        Redimensionar()
        Me.Refresh()
    End Sub

    '� chamado sempre que uma nova �rea da tela � exposta ou o m�todo refresh � chamado
    Private Sub Gantt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Requisita a atualiza��o do gr�fico passando como par�metro a lista de processos e a �rea gr�fica do componente
        PintarGrafico(LocProcessos, e.Graphics)
    End Sub

    'Repinta o gr�fico na tela
    Private Sub PintarGrafico(ByVal Processos As Processos, ByVal G As System.Drawing.Graphics)
        'Desenha a linha que demarca o instante inicial
        G.DrawLine(Pens.Black, MargemEsquerda, MargemSuperior, MargemEsquerda, MargemSuperior + Altura + HasteDeRotulo)
        'Cria uma fonte, �rea de desenho e formata��o de string
        Dim FontePadrao As New Font("Arial", 10)
        Dim Retangulo As New RectangleF(MargemEsquerda - 8, MargemSuperior + Altura + HasteDeRotulo + 1, 16, 40)
        Dim Formato As New StringFormat
        'Centraliza o texto 
        Formato.Alignment = StringAlignment.Center
        Formato.LineAlignment = StringAlignment.Center
        'Orienta o texto verticalmente
        Formato.FormatFlags = StringFormatFlags.DirectionVertical
        'Desenha aborda do r�tulo de tempo
        G.DrawRectangle(Pens.Black, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
        'Coloca o texto sobre o r�tulo
        G.DrawString("0", FontePadrao, Brushes.Black, Retangulo, Formato)
        'Se existe uma lista de processos
        If Not LocProcessos Is Nothing Then
            'Para cada processo da lista
            For Each P As Processo In Processos
                'Obt�m o pincel para colora��o do r�tulo e do processo, criando um novo se necess�rio
                Dim Pincel As System.Drawing.Brush = ObterPrincel(P.id)
                'Coordenada X inicial
                Dim X As Integer = P.Inicio * locTamanhoDoInstante + MargemEsquerda
                'Coordenada Y inicial
                Dim Y As Integer = MargemSuperior
                'Largura da representa��o gr�fica do processo
                Dim L As Integer = P.Tempo * locTamanhoDoInstante
                'Altura da representa��o gr�fica do processo
                Dim TmpAltura As Integer = Altura
                'Dist�ncia entre o topo da representa��o gr�fica do processo at�
                'a extremidade inferior da haste que liga esta representa��o ao r�tulo de tempo
                Dim TmpAltura2 As Integer = Altura + HasteDeRotulo
                'Pinta a �rea do processo
                G.FillRectangle(Pincel, X, Y, L, TmpAltura)
                'Desenha a borda na cor preta
                G.DrawRectangle(Pens.Black, X, Y, L, TmpAltura)
                'Desenha a haste que liga ao r�tulo de tempo
                G.DrawLine(Pens.Black, X + L, Y, X + L, Y + TmpAltura2)
                'Cria o ret�ngulo referente ao r�tulo de tempo do processo
                Retangulo = New RectangleF(X + L - 8, Y + TmpAltura2 + 1, 16, 40)
                'Confirura a orienta��o do texto na vertical, centralizando-o usado para desenh�-lo
                Formato = New StringFormat
                Formato.Alignment = StringAlignment.Center
                Formato.LineAlignment = StringAlignment.Center
                Formato.FormatFlags = StringFormatFlags.DirectionVertical
                'Imprime r�tulos dos instantes com o mesmo preenchimento do processo
                G.FillRectangle(Pincel, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
                G.DrawRectangle(Pens.Black, Retangulo.X, Retangulo.Y, Retangulo.Width, Retangulo.Height)
                'Imprime o instante de encerramento do processo
                G.DrawString((P.Inicio + P.Tempo).ToString, FontePadrao, Brushes.Black, Retangulo, Formato)
                'Cria o ret�ngulo referente ao r�tulo de identifica��o do processo
                Retangulo = New RectangleF(X, Y, L, TmpAltura)
                'Imprime a identifica��o dos processos
                G.DrawString("P" & P.id.ToString, FontePadrao, Brushes.Black, Retangulo, Formato)
            Next
        End If
    End Sub

    'Sempre que o componente for redimensionado
    Private Sub Gantt_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'For�a o tamanho conforme o conte�do
        Redimensionar()
    End Sub

    'Ajusta o tamanho do componete conforme o ocnte�do
    Private Sub Redimensionar()
        'Assume a largura padr�o igual a zero
        Dim L As Integer = 0
        'Assume a altura padr�o (fixa conforme contantes definidas)
        Dim A As Integer = Altura + HasteDeRotulo * 2 + MargemSuperior * 2 + 40
        'Se houver uma lista de processos
        If Not IsNothing(LocProcessos) Then
            'Assume o tamanho pelo conte�do
            L = LocProcessos.TempoTotal * locTamanhoDoInstante
        End If
        'Se n�o foi definido um tamanho
        If L < 1 Then
            'Assume um valor fixo
            L = 100
        Else 'Caso contr�rio
            'Adiciona as margens e um espa�o extra
            L += (MargemEsquerda * 3)
        End If
        'Define o tamanho automaticamente
        Me.Size = New Size(L, A)
    End Sub

    'Gera pinc�is a artir de componentes RGB produzidos aleatoriamente
    Private Function PincelAleatorio() As Brush
        Dim R As Integer = 0
        Dim G As Integer = 0
        Dim B As Integer = 0
        Const Limite As Integer = 191
        'Este loop garante que ser� gerada uma cor clara
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

    'Retorna o pincel associado a um ID, criando um se ainha n�o houuver uma associa��o
    Private Function ObterPrincel(ByVal Id As Integer) As Brush
        'Se ainda n�o cont�m o ID
        If Not Cores.ContainsKey(Id) Then
            'Cria um novo pincel aleat�rio
            Dim Pincel As Brush = PincelAleatorio()
            'Adiciona � lista
            Cores.Add(Id, Pincel)
        End If
        'Retorna o pincel associado ao ID
        Return Cores(Id)
    End Function

    Private Sub Gantt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
