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
    'Esses atributos ser�o usados apenas pela interface
    Public ReadOnly Property Atributos() As Atributos Implements Algoritmo.Atributos
        Get
            Return locAtributos
        End Get
    End Property

    'Retorna um texto descrevendo o algoritmo, � meramente um r�tulo
    Public Property Descricao() As String Implements Algoritmo.Descricao
        Get
            Return locDescricao
        End Get
        Set(ByVal NovoValor As String)
            locDescricao = NovoValor
        End Set
    End Property

    'M�todo n�o implementado para este trabalho
    Public Sub Executar() Implements Algoritmo.Executar

    End Sub

    'Define ou retorna o intervalo de temporiza��o
    'N�o aplic�vel nesta vers�o do trabalho
    Public Property Intervalo() As Integer Implements Algoritmo.Intervalo
        Get
            Return locIntervalo
        End Get
        Set(ByVal NovoValor As Integer)
            locIntervalo = NovoValor
        End Set
    End Property

    'M�todo n�o implementado para este trabalho
    Public Sub Parar() Implements Algoritmo.Parar

    End Sub

    'Recebe uma lista de processo e devolve outra lista com a representa��o do fluxo destes processos na mem�ria
    Public Function Processar(ByVal Processos As Processos) As Processos Implements Algoritmo.Processar
        'Cria uma lista padronizada para devolu��o dos processos conforme evolu��o na mem�ria
        Dim Ret As New Processos
        'Prepara a fila de in�cio com os processos a serem executados
        filaDeInicio.CopiarEmMemoria(Processos)

        'Altera��o em 12.19 - FIFO n�o sofre ordena��o. O arquivo de entrada deve estar �ntegro.
        'Ordena a fila de in�cio conforme o instante de entrada em execu��o
        '        filaDeInicio.OrdenarPorInicio()
        'Reinicia o temporizador para o instante 0
        locTimerInterno.Reiniciar()
        'Assume que n�o h� nenhum processo em execu��o
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        'Enquanto houver algum processo para executar, na fila de pronto ou em execu��o...
        Do While filaDeInicio.Count > 0 Or FilaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se h� algum processo para executar no instante atual
            While filaDeInicio.ProcessosPendentes(locTimerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = filaDeInicio.ProximoProcesso
                'Coloca na fila de pronto
                FilaPronto.Add(NovoProcesso)
                'E muda seu estado para Pronto
                NovoProcesso.Iniciar()
            End While
            'Se n�o h� nenhum processo executando
            If IsNothing(ProcessoEmExecucao) Then
                'Coloca o pr�ximo processo da fila de pronto em execu��o
                ProcessoEmExecucao = FilaPronto.ProximoProcesso()
                'Se h� um processo em execu��o
                If Not IsNothing(ProcessoEmExecucao) Then
                    'Muda seu estado e define o instante de entrada para execu��o
                    ProcessoEmExecucao.Executar(locTimerInterno.Instante)
                End If
            Else
                'Incrementa o timer
                locTimerInterno.Incrementar()
                'Gera para o processo uma interrup��o do timer
                ProcessoEmExecucao.Temporizacao()
                'Verifica se o processo foi conclu�do
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    'Coloca o processo na fila de retorno
                    Ret.Add(ProcessoEmExecucao)
                    'Remove o processo conclu�do da mem�ria
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        'Devolve a lista de sa�da
        Return Ret
    End Function
End Class
