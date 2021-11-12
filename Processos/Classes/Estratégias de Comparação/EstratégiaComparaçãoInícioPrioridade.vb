'Classe que implementa a regra de neg�cio para permitir � lista de processos
'comparar processos usando como crit�rio o instante de in�cio

'Altera��o em 12/19 - caso os processos tenham mesmo tempo de entreda, ser�o ordenados por ID.
Public Class Estrat�giaCompara��oIn�cioPrioridade
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
