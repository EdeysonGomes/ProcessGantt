Public MustInherit Class Algoritmo
    Implements IAlgoritmo

    Protected _atributos As New Atributos
    Protected _descricao As String = "FIFO/FCFS"
    Protected _intervalo As Integer

    Protected timerInterno As New Temporizador
    Protected filaDeInicio As New FilaDeProcessos
    Protected filaPronto As New FilaDeProcessos
    Public ReadOnly Property atributos() As Atributos Implements IAlgoritmo.atributos
        Get
            Return _atributos
        End Get
    End Property
    Public Property descricao() As String Implements IAlgoritmo.descricao
        Get
            Return _descricao
        End Get
        Set(ByVal descricao As String)
            _descricao = descricao
        End Set
    End Property

    Public Property intervalo() As Integer Implements IAlgoritmo.intervalo
        Get
            Return _intervalo
        End Get
        Set(ByVal intervalo As Integer)
            _intervalo = intervalo
        End Set
    End Property
    Public MustOverride Function processar(Processos As Processos) As Processos Implements IAlgoritmo.processar
End Class
