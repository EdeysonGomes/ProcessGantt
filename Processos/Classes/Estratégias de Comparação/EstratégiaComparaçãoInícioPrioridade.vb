'Classe que implementa a regra de negócio para permitir à lista de processos
'comparar processos usando como critério o instante de início

'Alteração em 12/19 - caso os processos tenham mesmo tempo de entreda, serão ordenados por ID.
Public Class EstratégiaComparaçãoInícioPrioridade
    Implements System.Collections.Generic.IComparer(Of Processo)

    Public Function Compare(ByVal x As Processo, ByVal y As Processo) As Integer Implements System.Collections.Generic.IComparer(Of Processo).Compare
        Select Case True
            Case x.Inicio > y.Inicio
                Return 1
            Case x.Inicio < y.Inicio
                Return -1
            Case Else
                If (x.Prioridade > y.Prioridade) Then
                    Return -1
                Else
                    Return 1
                End If
        End Select
    End Function
End Class
