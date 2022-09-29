'Implementa o algoritimo de escalonamento FIFO a partir da interface algoritmo
Public Class Fifo
    Implements Algoritmo
    Dim locAtributos As New Atributos
    Dim locDescricao As String = "FCFS/FIFO"
    Dim locTimerInterno As New Temporizador
    Dim locIntervalo As Integer

    Dim filaDeInicio As New FilaDeProcessos
    Dim filaPronto As New FilaDeProcessos
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
        filaDeInicio.CopiarEmMemoria(Processos)

        'Alteração em 12.19 - FIFO não sofre ordenação. O arquivo de entrada deve estar íntegro.
        'Ordena a fila de início conforme o instante de entrada em execução
        '        filaDeInicio.OrdenarPorInicio()
        'Reinicia o temporizador para o instante 0
        locTimerInterno.Reiniciar()
        'Assume que não há nenhum processo em execução
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        'Enquanto houver algum processo para executar, na fila de pronto ou em execução...
        Do While filaDeInicio.Count > 0 Or FilaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se há algum processo para executar no instante atual
            While filaDeInicio.ProcessosPendentes(locTimerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = filaDeInicio.ProximoProcesso
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
            Else
                'Incrementa o timer
                locTimerInterno.Incrementar()
                'Gera para o processo uma interrupção do timer
                ProcessoEmExecucao.Temporizacao()
                'Verifica se o processo foi concluído
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    'Coloca o processo na fila de retorno
                    Ret.Add(ProcessoEmExecucao)
                    'Remove o processo concluído da memória
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        'Devolve a lista de saída
        Return Ret
    End Function
End Class
