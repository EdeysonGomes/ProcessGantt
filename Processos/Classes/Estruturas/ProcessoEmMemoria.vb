'Classe herdeira de processo que representa um processo em tr�nsito na mem�ria
Public Class ProcessoEmMemoria
    Inherits Processo
    'Vari�veis para tratamento de atributos espec�ficos
    Dim LocTempoRestante As Integer = 0
    Dim locEstado As EstadoDoProcesso

    'Enumera��o de estados suportados
    Public Enum EstadoDoProcesso
        epIniciando
        epPronto
        epExecutando
        epTerminado
        epBloqueado
        epSuspenso
    End Enum

    'Retorna o tempo restante do processo
    Public ReadOnly Property TempoRestante() As Integer
        Get
            Return Me.LocTempoRestante
        End Get
    End Property

    'Cria uma c�pia do processo orignal na mem�ria, no estado Iniciando,
    'inicializando o tempo restante com o mesmo valor do tempo inicial
    Public Sub New(ByVal ProcessoOriginal As Processo)
        MyBase.New(ProcessoOriginal.id, ProcessoOriginal.Inicio, ProcessoOriginal.Tempo, ProcessoOriginal.Prioridade)
        Me.locEstado = EstadoDoProcesso.epIniciando
        Me.LocTempoRestante = ProcessoOriginal.Tempo
    End Sub

    'Passa o processo para o estado Pronto
    Public Sub Iniciar()
        Me.locEstado = EstadoDoProcesso.epPronto
    End Sub

    'Define o momento de in�cio da execu��o do processo, mudando seu estado
    'para executando
    Public Sub Executar(ByVal Instante As Integer)
        Me.locInicio = Instante
        Me.locEstado = EstadoDoProcesso.epExecutando
    End Sub

    'Muda o estado do processo para Bloqueado
    Public Sub Bloquear()
        Me.locEstado = EstadoDoProcesso.epBloqueado
    End Sub

    'Muda o estado do processo para suspenso
    Public Sub Suspender()
        Me.locEstado = EstadoDoProcesso.epSuspenso
    End Sub

    'Gera para o processo uma interrup��o de tempo, atualizando seu tempo restante
    Public Sub Temporizacao()
        LocTempoRestante -= 1
        If LocTempoRestante < 1 Then
            Me.locEstado = EstadoDoProcesso.epTerminado
        End If
    End Sub

    'Retorna o estado atual do processo
    Public ReadOnly Property Estado() As EstadoDoProcesso
        Get
            Return Me.locEstado
        End Get
    End Property
End Class
