'Define uma lista de processos
Public Class Processos
    Inherits System.Collections.Generic.List(Of Processo)

    'Copia todos os processos a partir de uma lista de processos
    'mantendo os tipos originais
    Public Sub Copiar(ByVal ListaOriginal As Processos)
        Me.Clear()
        For Each Item As Processo In ListaOriginal
            Me.Add(Item)
        Next
    End Sub

    'Copia todos os processos a partir de uma lista de processos
    'Criando objetos do tipo ProcessoEmMemoria
    Public Sub CopiarEmMemoria(ByVal ListaOriginal As Processos)
        Me.Clear()
        For Each Item As Processo In ListaOriginal
            Me.Add(New ProcessoEmMemoria(Item))
        Next
    End Sub

    'Devolve o tempo total dos processos armazenados
    Public ReadOnly Property TempoTotal() As Integer
        Get
            Dim Soma As Integer = 0
            For Each P As Processo In Me
                Soma += P.Tempo
            Next
            Return Soma
        End Get
    End Property

    'Verifica se existe na lista um processo com o ID especificado
    Public Function Contem(ByVal Id As Integer) As Boolean
        For Each Item As Processo In Me
            If Item.id = Id Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
