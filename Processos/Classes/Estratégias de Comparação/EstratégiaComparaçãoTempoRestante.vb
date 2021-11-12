'Classe que implementa a regra de negócio para permitir à lista de processos
'comparar processos usando como critério o tempo restante para o fim do processamento
Public Class EstratégiaComparaçãoTempoRestante
    Implements System.Collections.Generic.IComparer(Of Processo)

    Public Function Compare(ByVal x As Processo, ByVal y As Processo) As Integer Implements System.Collections.Generic.IComparer(Of Processo).Compare
        Dim X1 As ProcessoEmMemoria = x
        Dim Y1 As ProcessoEmMemoria = y
        Select Case True
            Case X1.TempoRestante > Y1.TempoRestante
                Return 1
            Case X1.TempoRestante < Y1.TempoRestante
                Return -1
            Case Else
                If (x.id < y.id) Then
                    Return -1
                Else
                    Return 1
                End If
        End Select
    End Function
End Class
