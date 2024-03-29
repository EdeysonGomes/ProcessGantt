Imports System.Text
'Conjunto de elementos do tipo análise
'Passa a cada um dos elementos contidos a resposnsabilidade de analisar
'cada processo do conjunto de entrada, recebendo destes pareceres
'individuais que são concatenados e entreques ao solicitante
Public Class Analises
    'Esta classe implementa uma superclasse, definida genericamente,
    'que representa um alista de itens ordenada pela chave
    Inherits System.Collections.Generic.SortedList(Of Integer, Analise)

    Public Sub MontarAnalise(ByVal ListaOriginal As Processos, ByVal ListaDeSaida As Processos)
        'Esvazia quaisquer análises anteriores
        Me.Clear()
        'Cria elementos do tipo análise para cada processo da lista original,
        For Each Item As Processo In ListaOriginal
            Dim Analise As New Analise(Item)
            'passando a estes a lista de saída para ser analisada
            Analise.Analisar(ListaDeSaida)
            'Armazenando o resultado para futura emissão do parecer
            Me.Add(Item.id, Analise)
        Next
    End Sub

    'Solicita os pereceres individuais, concatena-os  e devolve um sumário
    Public Function ObterParecer() As String
        'Simplifica e trata de forma mais eficiente a concatenação de strings 
        Dim Ret As New StringBuilder

        'Variáveis para cálculo das médias
        Dim EsperaMedia As Single = 0
        Dim SaidaMedia As Single = 0
        Dim SurtoMedio As Single = 0

        'Para cada análise armazenada
        For Each Item As Analise In Me.Values
            'Obtém o parecer
            Ret.Append(Item.ObterParecer)
            'Acumula os totais
            EsperaMedia += Item.TempoDeEspera
            SaidaMedia += Item.TempoDeSaida
            SurtoMedio += Item.TempoDeSurto
        Next
        'Calcula as médias
        EsperaMedia /= Me.Count
        SaidaMedia /= Me.Count
        SurtoMedio /= Me.Count

        'Gera o sumário
        Ret.AppendLine("╔" & New String("═", 33) & "╗")
        Ret.AppendLine("║" & LSet("Sumário:", 33) & "║")
        Ret.AppendLine("╠" & New String("═", 33) & "╣")
        Ret.AppendLine("║" & LSet("Tempo médio de espera   : " & RSet(Format(EsperaMedia, "0.00"), 6), 33) & "║")
        Ret.AppendLine("║" & LSet("Tempo médio de execução : " & RSet(Format(SaidaMedia, "0.00"), 6), 33) & "║")
        'Ret.AppendLine("║" & LSet("Tempo médio de surto : " & RSet(Format(SurtoMedio, "0.00"), 6), 30) & "║")
        Ret.AppendLine("╚" & New String("═", 33) & "╝")

        'Devolve o resultado
        Return Ret.ToString
    End Function
End Class
