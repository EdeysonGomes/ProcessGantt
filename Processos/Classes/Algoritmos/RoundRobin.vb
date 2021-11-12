'Implementa o algor�timo de escalonamento Round Robin, a partir da interface algoritmo
Public Class RoundRobin
    Inherits Algoritmo


    Public Sub New()
        Dim Atributo As New Atributo("Quantum", PrjProcessos.Atributo.TiposDeAtributos.taInteiro)
        Atributo.Valor = 4
        Me.atributos.Add(Atributo.Nome, Atributo)
    End Sub

    'Recebe uma lista de processo e devolve outra lista com a representa��o do fluxo destes processos na mem�ria
    Public Overrides Function processar(ByVal Processos As Processos) As Processos
        'Cria uma lista padronizada para devolu��o dos processos conforme evolu��o na mem�ria
        Dim Ret As New Processos
        'Prepara a fila de in�cio com os processos a serem executados
        filaDeInicio.CopiarEmMemoria(Processos)
        'Ordena a fila de in�cio conforme o instante de entrada em execu��o
        filaDeInicio.ordenar()
        'Reinicia o temporizador para o instante 0
        timerInterno.Reiniciar()
        'Assume que n�o h� nenhum processo em execu��o
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        Dim QuantumRestante As Integer = 0
        'Enquanto houver algum processo para executar, na fila de pronto ou em execu��o...
        Do While filaDeInicio.Count > 0 Or filaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            'Se h� algum processo para executar no instante atual
            While filaDeInicio.ProcessosPendentes(timerInterno.Instante)
                'Pega o processo pendente
                Dim NovoProcesso As ProcessoEmMemoria = filaDeInicio.ProximoProcesso
                'Coloca na fila de pronto
                filaPronto.Add(NovoProcesso)
                'E muda seu estado para Pronto
                NovoProcesso.Iniciar()
            End While
            'Se n�o h� nenhum processo executando
            If IsNothing(ProcessoEmExecucao) Then
                'Coloca o pr�ximo processo da fila de pronto em execu��o
                ProcessoEmExecucao = filaPronto.ProximoProcesso()
                'Se h� um processo em execu��o
                If Not IsNothing(ProcessoEmExecucao) Then
                    'Muda seu estado e define o instante de entrada para execu��o
                    ProcessoEmExecucao.Executar(timerInterno.Instante)
                End If
                QuantumRestante = Me.atributos("Quantum").Valor
            Else
                QuantumRestante -= 1
                'Incrementa o timer
                timerInterno.Incrementar()
                'Gera para o processo uma interrup��o do timer
                ProcessoEmExecucao.Temporizacao()
                'Verifica se o processo foi conclu�do
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    'Coloca o processo na fila de retorno
                    With ProcessoEmExecucao
                        Ret.Add(New Processo(.id, .Inicio, timerInterno.Instante - .Inicio))
                    End With
                    'Ret.Add(ProcessoEmExecucao)
                    'Remove o processo conclu�do da mem�ria
                    ProcessoEmExecucao = Nothing
                ElseIf QuantumRestante < 1 Then
                    With ProcessoEmExecucao
                        'Adiciona um novo �tem � sa�da
                        Ret.Add(New Processo(.id, .Inicio, timerInterno.Instante - .Inicio))
                    End With
                    'Devolve o processo em execu��o � fila de pronto
                    filaPronto.Add(ProcessoEmExecucao)
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

End Class
