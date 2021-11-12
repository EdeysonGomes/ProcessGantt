'Implementa a subclasse da lista Processos, implementando funcionalidades
'específicas para gerenciamento do processo na memória
Public Class FilaDeProcessos
    Inherits Processos

    Private comparador As IComparer(Of Processo)

    Public Sub New(comparador As IComparer(Of Processo))
        Me.comparador = comparador
    End Sub

    Public Sub New()

    End Sub

    Public Sub ordenar()
        Me.Sort(Me.comparador)
    End Sub


    'Ordena por tempo usando a classe de negócio específica
    'Public Sub OrdenarPorTempo()
    '    MyBase.Sort(New ComparadorDeTempo)
    'End Sub

    'Ordena por instante de início usando a classe de negócio específica
    'Public Sub OrdenarPorPrioridadeInicio()
    '    MyBase.Sort(New ComparadorDePrioridadeInicio)
    'End Sub
    'Ordena por instante de início usando a classe de negócio específica
    'Public Sub OrdenarPorInicioPrioridade()
    '    MyBase.Sort(New ComparadorDeInicioPrioridade)
    'End Sub

    'Ordena por instante de início usando a classe de negócio específica
    'Public Sub OrdenarPorInicio()
    '    MyBase.Sort(New ComparadorDeInicio)
    'End Sub

    'Ordena por tempo restante usando a classe de negócio específica
    'Public Sub OrdenarPorTempoRestante()
    '    MyBase.Sort(New ComparadorDeTempoRestante)
    'End Sub

    'Ordena por prioridade usando a classe de negócio específica
    'Public Sub OrdenarPorPrioridade()
    '    MyBase.Sort(New ComparadorDePrioridade)
    'End Sub

    'Retorna a lista de processos com instante de início correspondente ao
    'instante passado como parâmetro
    Public Function ProcessosPendentes(ByVal Instante As Integer) As Integer
        Dim Ret As Integer = 0
        If Me.Count > 0 Then
            For Each P As Processo In Me
                If P.Inicio = Instante Then
                    Ret += 1
                End If
            Next
        End If
        Return Ret
    End Function

    'Retorna o primeiro elemento da lista e devolve-o ao requisitante
    Public Function ProximoProcesso() As ProcessoEmMemoria
        Dim Ret As ProcessoEmMemoria = Nothing
        If Me.Count > 0 Then
            Ret = Me.Item(0)
            Me.Remove(Ret)
        End If
        Return Ret
    End Function

End Class
