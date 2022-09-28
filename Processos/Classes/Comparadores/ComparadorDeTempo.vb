'Classe que implementa a regra de negócio para permitir à lista de processos
'comparar processos usando como critério o instante de início e o tempo de execução
Public Class ComparadorDeTempo
    Implements System.Collections.Generic.IComparer(Of Processo)

    Public Function Compare(ByVal x As Processo, ByVal y As Processo) As Integer Implements System.Collections.Generic.IComparer(Of Processo).Compare
        Select Case True
            Case x.Inicio > y.Inicio
                Return 1
            Case x.Inicio < y.Inicio
                Return -1
            Case Else
                Select Case True
                    Case x.Tempo > y.Tempo
                        Return -1
                    Case x.Tempo < y.Tempo
                        Return 1
                    Case Else
                        Return 0
                End Select
        End Select
    End Function
End Class
