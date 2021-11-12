'Implementa o algor�timo de escalonamento SJFP, a partir da interface algoritmo
Public Class SJFP
    Implements IAlgoritmo
    Dim locAtributos As New Atributos
    Dim locDescricao As String = "SJF Preemptivo"
    Dim locTimerInterno As New Temporizador
    Dim locIntervalo As Integer

    Dim FilaDeInicio As New FilaDeProcessos(New Estrat�giaCompara��oInicio)
    Dim FilaPronto As New FilaDeProcessos(New Estrat�giaCompara��oTempoRestante)
    'Dim FilaDeIo As New FilaDeProcesos

    'Permite a leitura dos atributos do algoritmo, caso haja algum
    'Esses atributos ser�o usados apenas pela interface
    Public ReadOnly Property Atributos() As Atributos Implements IAlgoritmo.Atributos
        Get
            Return locAtributos
        End Get
    End Property

    'Retorna um texto descrevendo o algoritmo, � meramente um r�tulo
    Public Property Descricao() As String Implements IAlgoritmo.Descricao
        Get
            Return locDescricao
        End Get
        Set(ByVal NovoValor As String)
            locDescricao = NovoValor
        End Set
    End Property

    'Define ou retorna o intervalo de temporiza��o
    'N�o aplic�vel nesta vers�o do trabalho
    Public Property Intervalo() As Integer Implements IAlgoritmo.Intervalo
        Get
            Return locIntervalo
        End Get
        Set(ByVal NovoValor As Integer)
            locIntervalo = NovoValor
        End Set
    End Property

    'Recebe uma lista de processo e devolve outra lista com a representa��o do fluxo destes processos na mem�ria
    Public Function processar(ByVal Processos As Processos) As Processos Implements IAlgoritmo.processar
        'Cria uma lista padronizada para devolu��o dos processos conforme evolu��o na mem�ria
        Dim Ret As New Processos
        'Prepara a fila de in�cio com os processos a serem executados
        FilaDeInicio.CopiarEmMemoria(Processos)
        'Ordena a fila de in�cio conforme o instante de entrada em execu��o
        FilaDeInicio.ordenar()
        'Reinicia o temporizador para o instante 0
        locTimerInterno.Reiniciar()
        'Assume que n�o h� nenhum processo em execu��o
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        'Enquanto houver algum processo para executar, na fila de pronto ou em execu��o...
        Do While FilaDeInicio.Count > 0 Or FilaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se h� algum processo para executar no instante atual
            While FilaDeInicio.ProcessosPendentes(locTimerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = FilaDeInicio.ProximoProcesso
                'Coloca na fila de pronto
                FilaPronto.Add(NovoProcesso)
                'Se existe um processo em execu��o
                If Not IsNothing(ProcessoEmExecucao) Then
                    'Se houver um tempo restante menor que  o tempo restante do processo em execu��o
                    If ProcessoEmExecucao.TempoRestante > ObterMenorTempoRestante(FilaPronto) Then
                        With ProcessoEmExecucao
                            Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                        End With
                        FilaPronto.Add(ProcessoEmExecucao)
                        ProcessoEmExecucao.Iniciar()
                        ProcessoEmExecucao = Nothing
                    End If
                End If
                'E muda seu estado para Pronto
                NovoProcesso.Iniciar()
            End While
            'Se n�o h� nenhum processo executando
            If IsNothing(ProcessoEmExecucao) Then
                'Coloca o pr�ximo processo da fila de pronto em execu��o
                FilaPronto.ordenar()
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
                    With ProcessoEmExecucao
                        'Adiciona um novo �tem � sa�da
                        Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                    End With
                    'Coloca o processo na fila de retorno
                    'Ret.Add(ProcessoEmExecucao)
                    'Remove o processo conclu�do da mem�ria
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        'Devolve a lista de sa�da
        Return Ret
    End Function


    Public Function ObterMenorTempoRestante(ByVal filaPronto As FilaDeProcessos) As Integer
        If filaPronto.Count Then
            filaPronto.ordenar()
            Dim Item As ProcessoEmMemoria = filaPronto.Item(0)
            Return Item.TempoRestante
        End If
        Return 0
    End Function
End Class
