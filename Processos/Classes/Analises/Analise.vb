Imports System.Text
'Elemento do tipo análise
'Interpreta individualmente um processo específico, emitindo parecer sobre este
Public Class Analise
    'Processo a ser analisado
    Dim locProcessoBase As Processo
    'variáveis privadas para os atributos
    Dim locTempoDeEspera As Integer
    Dim locTempoDeSurto As Integer
    Dim locTempoDeSaida As Integer

    'Atributo tempo de espera
    Public ReadOnly Property TempoDeEspera() As Integer
        Get
            Return locTempoDeEspera
        End Get
    End Property

    'Atributo tempo de surto
    Public ReadOnly Property TempoDeSurto() As Integer
        Get
            Return locTempoDeSurto
        End Get
    End Property

    'Atributo tempo de saída
    Public ReadOnly Property TempoDeSaida() As Integer
        Get
            Return locTempoDeSaida
        End Get
    End Property

    'Atributo ID, obtido do processo base
    Public ReadOnly Property ID() As Integer
        Get
            Return Me.locProcessoBase.id
        End Get
    End Property

    'Analisa a lista de processos de saída atualizando os atributos
    'com o tempo de espera, tempo de surto e tempo de saída do processo
    Public Sub Analisar(ByVal ListaDeSaida As Processos)
        'Inicialmente zera os atributos
        Me.locTempoDeEspera = 0
        Me.locTempoDeSurto = 0
        Me.locTempoDeSaida = 0
        'se existe um processo base trata a list de saída
        If Not IsNothing(Me.locProcessoBase) Then
            'cria uma fila temporária para armazenar os itens
            'correspondentes ao processo base
            Dim Fila As New FilaDeProcessos
            'Para cada item da lista de sída
            For Each Item As Processo In ListaDeSaida
                'se o item for relativo o processo base
                If Item.id = Me.ID Then
                    'adiciona na fila
                    Fila.Add(Item)
                    'acumula o tempo de surto
                    Me.locTempoDeSurto += Item.Tempo
                End If
            Next

            'se existe algo na fila
            If Fila.Count > 0 Then
                'ordena pelo instante de inicio
                Fila.OrdenarPorInicio()
                'pega o último item da fila
                Dim UltimoItem As Processo = Fila.Item(Fila.Count - 1)
                'para calcular o tempo de saída
                Me.locTempoDeSaida = UltimoItem.Inicio + UltimoItem.Tempo - Me.locProcessoBase.Inicio
            End If
        End If
        'calcula o tempo de espera
        Me.locTempoDeEspera = locTempoDeSaida - locTempoDeSurto
    End Sub

    'construtor
    Public Sub New(ByVal ProcessoBase As Processo)
        'inicializa o processo base
        Me.locProcessoBase = ProcessoBase
    End Sub

    'formata os dados de forma apresentável para o usuário
    Public Function ObterParecer() As String
        Dim Ret As New StringBuilder
        Dim strTempoEspera = "Tempo de espera   : "
        Dim strTempoExecucao = "Tempo de execução : "

        Ret.AppendLine("╔" & New String("═", 30) & "╗")
        Ret.AppendLine("║" & LSet("Processo: P" & Me.ID, 30) & "║")
        Ret.AppendLine("╟" & New String("─", 30) & "╢")
        Ret.AppendLine("║" & LSet(strTempoEspera & RSet(Format(Me.locTempoDeEspera, "0"), 9), 30) & "║")
        Ret.AppendLine("║" & LSet(strTempoExecucao & RSet(Format(Me.locTempoDeSaida, "0"), 9), 30) & "║")
        'Ret.AppendLine("║" & LSet("Tempo de surto : " & RSet(Format(Me.locTempoDeSurto, "0"), 12), 30) & "║")
        Ret.AppendLine("╚" & New String("═", 30) & "╝")
        Return Ret.ToString
    End Function
End Class
