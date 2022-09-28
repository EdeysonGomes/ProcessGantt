'Implementa o algor�timo de escalonamento Round Robin, a partir da interface algoritmo
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
        FilaDeInicio.CopiarEmMemoria(Processos)
        'Ordena a fila de in�cio conforme o instante de entrada em execu��o
        FilaDeInicio.OrdenarPorInicio()
        'Reinicia o temporizador para o instante 0
        locTimerInterno.Reiniciar()
        'Assume que n�o h� nenhum processo em execu��o
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        Dim QuantumRestante As Integer = 0
        'Enquanto houver algum processo para executar, na fila de pronto ou em execu��o...
        Do While FilaDeInicio.Count > 0 Or FilaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se h� algum processo para executar no instante atual
            While FilaDeInicio.ProcessosPendentes(locTimerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = FilaDeInicio.ProximoProcesso
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
                QuantumRestante = Me.locAtributos("Quantum").Valor
            Else
                QuantumRestante -= 1
                'Incrementa o timer
                locTimerInterno.Incrementar()
                'Gera para o processo uma interrup��o do timer
                ProcessoEmExecucao.Temporizacao()
                'Verifica se o processo foi conclu�do
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    'Coloca o processo na fila de retorno
                    With ProcessoEmExecucao
                        Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                    End With
                    'Ret.Add(ProcessoEmExecucao)
                    'Remove o processo conclu�do da mem�ria
                    ProcessoEmExecucao = Nothing
                ElseIf QuantumRestante < 1 Then
                    With ProcessoEmExecucao
                        'Adiciona um novo �tem � sa�da
                        Ret.Add(New Processo(.id, .Inicio, locTimerInterno.Instante - .Inicio))
                    End With
                    'Devolve o processo em execu��o � fila de pronto
                    FilaPronto.Add(ProcessoEmExecucao)
                    'Coloca o processo no estado Pronto
                    ProcessoEmExecucao.Iniciar()
                    'Remove o processo em execucao do processador
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        'Devolve a lista de sa�da
        Return Ret
    End Function

    'Public Function Processar(ByVal Processos As Processos) As Processos Implements Algoritmo.Processar
    '    'P�ra qualquer processo em execu��o
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
