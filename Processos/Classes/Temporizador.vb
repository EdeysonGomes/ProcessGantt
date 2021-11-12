'Classe para controle de temporização dos processos
Public Class Temporizador
    'variável para manutenção do instante corrente
    Dim LocInstante As Integer = 0

    'Zera o temporizador
    Public Sub Reiniciar()
        LocInstante = 0
    End Sub

    'Incrementa o temporizador
    Public Sub Incrementar()
        LocInstante += 1
    End Sub

    'Retorna o instante atual
    Public ReadOnly Property Instante() As Integer
        Get
            Return LocInstante
        End Get
    End Property
End Class
