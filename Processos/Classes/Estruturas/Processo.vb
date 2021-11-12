'Classe básica para representação do processo
Public Class Processo
    'Variáveis internas para armazenamento dos atributos
    Dim locId As Integer
    Protected locInicio As Integer
    Dim locTempo As Integer
    Dim locPrioridade As Integer
    Dim PrioridadeOriginal As Integer = 0
    Dim PrioridadeAtual As Integer = 0

    'Construtor sobrecarregado para definição de processos sem prioridade
    Public Sub New(ByVal Id As Integer, ByVal Inicio As Integer, ByVal Tempo As Integer)
        Me.new(Id, Inicio, Tempo, 0)
    End Sub

    'Construtor básico para definição de processos com prioridade
    Public Sub New(ByVal Id As Integer, ByVal Inicio As Integer, ByVal Tempo As Integer, ByVal PrioridadeInicial As Integer)
        Me.locId = Id
        Me.locInicio = Inicio
        Me.locTempo = Tempo
        Me.PrioridadeOriginal = PrioridadeInicial
        Me.PrioridadeAtual = PrioridadeInicial
    End Sub

    'Retorna o ID do processo
    Public ReadOnly Property id() As Integer
        Get
            Return Me.locId
        End Get
    End Property

    'Retorna o instante de início do processo
    Public ReadOnly Property Inicio() As Integer
        Get
            Return Me.locInicio
        End Get
    End Property

    'Retorna o tempo total de execução do processo
    Public ReadOnly Property Tempo() As Integer
        Get
            Return Me.locTempo
        End Get
    End Property

    'Retorna a prioridade do processo
    Public ReadOnly Property Prioridade() As Integer
        Get
            Return PrioridadeAtual
        End Get
    End Property

    'Método que incrementa a prioridade do processo do processo
    Public Sub IncrementarPrioridade(Optional ByVal Incremento As Integer = 1)
        PrioridadeAtual += Incremento
    End Sub

    'Método que devolve ao processo sua prioridade inicial
    Public Sub RedefinirPrioridade()
        PrioridadeAtual = PrioridadeOriginal
    End Sub
End Class
