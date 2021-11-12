'Classe para controle de temporiza��o dos processos
Public Class Temporizador
    'vari�vel para manuten��o do instante corrente
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
