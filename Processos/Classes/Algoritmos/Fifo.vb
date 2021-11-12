'Implementa o algoritimo de escalonamento FIFO a partir da interface algoritmo
Public Class Fifo
    Inherits Algoritmo

    Public Sub New()
        Me.descricao = "FIFO/FCFS"
    End Sub


    Public Overrides Function processar(ByVal Processos As Processos) As Processos
        Dim Ret As New Processos
        filaDeInicio.CopiarEmMemoria(Processos)

        timerInterno.Reiniciar()
        Dim ProcessoEmExecucao As ProcessoEmMemoria = Nothing
        Do While filaDeInicio.Count > 0 Or filaPronto.Count > 0 Or Not IsNothing(ProcessoEmExecucao)
            While filaDeInicio.ProcessosPendentes(timerInterno.Instante)
                Dim NovoProcesso As ProcessoEmMemoria = filaDeInicio.ProximoProcesso
                filaPronto.Add(NovoProcesso)
                NovoProcesso.Iniciar()
            End While
            If IsNothing(ProcessoEmExecucao) Then
                ProcessoEmExecucao = filaPronto.ProximoProcesso()
                If Not IsNothing(ProcessoEmExecucao) Then
                    ProcessoEmExecucao.Executar(timerInterno.Instante)
                End If
            Else
                timerInterno.Incrementar()
                ProcessoEmExecucao.Temporizacao()
                If ProcessoEmExecucao.Estado = ProcessoEmMemoria.EstadoDoProcesso.epTerminado Then
                    Ret.Add(ProcessoEmExecucao)
                    ProcessoEmExecucao = Nothing
                End If
            End If
        Loop
        Return Ret
    End Function
End Class
