'Implementa o algorítimo de escalonamento Round Robin, a partir da interface algoritmo
Public Class RoundRobin
    Implements Algoritmo
    Dim locAtributos As New Atributos
    Dim locDescricao As String = "Round Robin"
    Dim locTimerInterno As New Temporizador
    Dim locIntervalo As Integer

    Dim FilaDeInicio As New FilaDeProcessos
    Dim FilaPronto As New FilaDeProcessos
    'Dim FilaDeIo As New FilaDeProcesos

    'Permite a leitura dos atributos do algoritmo, caso haja algum
    'Esses atributos serão usados apenas pela interface
    Public ReadOnly Property Atributos() As Atributos Implements Algoritmo.Atributos
        Get
            Return locAtributos
        End Get
    End Property

    'Retorna um texto descrevendo o algoritmo, é meramente um rótulo
    Public Property Descricao() As String Implements Algoritmo.Descricao
        Get
            Return locDescricao
        End Get
        Set(ByVal NovoValor As String)
            locDescricao = NovoValor
        End Set
    End Property

    'Método não implementado para este trabalho
    Public Sub Executar() Implements Algoritmo.Executar

    End Sub

    'Define ou retorna o intervalo de temporização
    'Não aplicável nesta versão do trabalho
    Public Property Intervalo() As Integer Implements Algoritmo.Intervalo
        Get
            Return locIntervalo
        End Get
        Set(ByVal NovoValor As Integer)
            locIntervalo = NovoValor
        End Set
    End Property

    'Método não implementado para este trabalho
    Public Sub Parar() Implements Algoritmo.Parar

    End Sub

    'Recebe uma lista de processo e devolve outra lista com a representação do fluxo destes processos na memória
    Public Function Processar(ByVal Processos As Processos) As Processos Implements Algoritmo.Processar
        'Cria uma lista padronizada para devolução dos processos conforme evolução na memória
        Dim Ret As New Processos
        'Prepara a fila de início com os processos a serem executados
        FilaDeInicio.CopiarEmMemoria(Processos)
        'Ordena a fila de início conforme o instante de entrada em execução
        FilaDeInicio.OrdenarPorInicio()
        'Reinicia o temporizador para o instante 0
        locTimerInterno.Reiniciar()
        'Assume que não há nenhum processo em execução
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        Dim QuantumRestante As Integer = 0
        'Enquanto houver algum processo para executar, na fila de pronto ou em execução...
        Do While FilaDeInicio.Count > 0 Or FilaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se há algum processo para executar no instante atual
            While FilaDeInicio.ProcessosPendentes(locTimerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = FilaDeInicio.ProximoProcesso
                'Coloca na fila de pronto
                FilaPronto.Add(NovoProcesso)
                'E muda seu estado para Pronto
                NovoProcesso.Iniciar()
            End While
            'Se não há nenhum processo executando
            If IsNothing(ProcessoEmExecucao) Then
                'Coloca o próximo processo da fila de pronto em execução
                ProcessoEmExecucao = FilaPronto.ProximoProcesso()
                'Se há um processo em execução
                If Not IsNothing(ProcessoEmExecucao) Then
                    'Muda seu estado e define o instante de entrada para execução
                    ProcessoEmExecucao.Executar(locTimerInterno.Instante)
                End If
                QuantumRestante = Me.locAtributos("Quantum").Valor
            Else
                QuantumRestante -= 1
                'Incrementa o timer
                locTimerInterno.Incrementar()
                'Gera para o processo uma interrupção do timer
                ProcessoEmExecucao.Temporizacao()
                'Verifica se o processo foi concluído
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    'Coloca o processo na fila de retorno
                    With ProcessoEmExecucao
                        Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                    End With
                    'Ret.Add(ProcessoEmExecucao)
                    'Remove o processo concluído da memória
                    ProcessoEmExecucao = Nothing
                ElseIf QuantumRestante < 1 Then
                    With ProcessoEmExecucao
                        'Adiciona um novo ítem à saída
                        Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                    End With
                    'Devolve o processo em execução à fila de pronto
                    FilaPronto.Add(ProcessoEmExecucao)
                    'Coloca o processo no estado Pronto
                    ProcessoEmExecucao.Iniciar()
                    'Remove o processo em execucao do processador
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        'Devolve a lista de saída
        Return Ret
    End Function

    'Public Function Processar(ByVal Processos As Processos) As Processos Implements Algoritmo.Processar
    '    'Pára qualquer processo em execução
    '    Me.Parar()
    '    Me.LocProcessos = Processos.ObterCopia()
    '    Me.FilaDeInicio.Clear()
    '    Me.FilaDeIo.Clear()
    '    Me.FilaPronto.Clear()
    '    Me.RetProcessos = New Processos
    '    Dim ProcessoExecutando As ProcessoEmMemoria

    '    'Dim TempoTotal As Integer = Processos.TempoTotal

    '    While Me.LocTimer.Enabled
    '        Application.DoEvents()
    '    End While

    '    Return RetProcessos
    'End Function

    'Public Sub New()
    '    Me.LocTimer.Enabled = False
    '    Me.LocTimer.Interval = 10
    'End Sub

    Public Sub New()
        Dim Atributo As New Atributo("Quantum", PrjProcessos.Atributo.TiposDeAtributos.taInteiro)
        Atributo.Valor = 4
        Me.locAtributos.Add(Atributo.Nome, Atributo)
    End Sub
End Class
