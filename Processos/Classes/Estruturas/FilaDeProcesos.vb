'Implementa a subclasse da lista Processos, implementando funcionalidades
'espec�ficas para gerenciamento do processo na mem�ria
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


    'Ordena por tempo usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorTempo()
    '    MyBase.Sort(New ComparadorDeTempo)
    'End Sub

    'Ordena por instante de in�cio usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorPrioridadeInicio()
    '    MyBase.Sort(New ComparadorDePrioridadeInicio)
    'End Sub
    'Ordena por instante de in�cio usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorInicioPrioridade()
    '    MyBase.Sort(New ComparadorDeInicioPrioridade)
    'End Sub

    'Ordena por instante de in�cio usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorInicio()
    '    MyBase.Sort(New ComparadorDeInicio)
    'End Sub

    'Ordena por tempo restante usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorTempoRestante()
    '    MyBase.Sort(New ComparadorDeTempoRestante)
    'End Sub

    'Ordena por prioridade usando a classe de neg�cio espec�fica
    'Public Sub OrdenarPorPrioridade()
    '    MyBase.Sort(New ComparadorDePrioridade)
    'End Sub

    'Retorna a lista de processos com instante de in�cio correspondente ao
    'instante passado como par�metro
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
