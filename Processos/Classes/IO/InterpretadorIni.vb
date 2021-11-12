'Classe que carrega uma lista de processo a aprtir de um arquivo INI
Public Class InterpretadorIni
    Implements Interpretador
    Dim ArquivoIni As ClsIni

    'Método para gravação de um arquivo INI
    'Não implementdo para este trabalho
    Public Sub GravarArquivo(ByVal Itens As Processos) Implements Interpretador.GravarArquivo
        Try
            System.IO.File.Delete(ArquivoIni.Arquivo)
        Catch ex As Exception
            'Desncessário tratamento
        End Try
    End Sub

    'Método que lê os processos em um arquivo INI e retorna uma lista de processos
    Public Function LerArquivo() As Processos Implements Interpretador.LerArquivo
        'Ignora possíveis erros
        On Error Resume Next
        'Cria uma lista vazia de retorno
        Dim Ret As New Processos
        'Número de itens a serem lidos no arquivo
        Dim Itens As Integer = 0
        'Obtém a quantidade de processos a serem executados
        Itens = ArquivoIni.Ler("Processos", "Quantidade", 0)

        'Loop para cada item a ser lido
        For Item As Integer = 1 To Itens
            'Variáveis para leitura do ID, instante de início e tempo total do processo
            Dim Id As Integer = 0
            Dim Inicio As Integer = 0
            Dim Tempo As Integer = 0
            Dim Prioridade As Integer = 0
            'leitura efetiva do ID, instante de início e tempo total do processo atual
            Id = ArquivoIni.Ler("Processo" & Item, "PID", 0)
            Inicio = ArquivoIni.Ler("Processo" & Item, "Inicio", 0)
            Tempo = ArquivoIni.Ler("Processo" & Item, "Tempo", 0)
            Prioridade = ArquivoIni.Ler("Processo" & Item, "Prioridade", 0)
            'Verifica as possibilidades de dados inválidos
            'Se um dado inválido for encontrado aborta a leitura
            'e devolve uma lista vazia
            If Inicio < 0 Then
                MsgBox("O instante de início especificado para o processo " & Item & " não é válido.", MsgBoxStyle.Critical)
                Return New Processos
            ElseIf Tempo < 1 Then
                MsgBox("O tempo de execução especificado para o processo " & Item & " não é válido.", MsgBoxStyle.Critical)
                Return New Processos
            ElseIf Prioridade < 1 Then
                MsgBox("A prioridade especificada para o processo " & Item & " não é válida.", MsgBoxStyle.Critical)
                Return New Processos
            ElseIf Ret.Contem(Id) Then
                MsgBox("O ID do processo " & Item & " já foi definido para outro processo.", MsgBoxStyle.Critical)
                Return New Processos
            Else
                'Se não teve dado inválido cria o processo e armazena
                Ret.Add(New Processo(Id, Inicio, Tempo, Prioridade))
            End If
        Next
        'Devolve a lista
        Return Ret
    End Function

    'Construtor único
    Public Sub New(ByVal Arquivo As String)
        ArquivoIni = New ClsIni(Arquivo)
    End Sub
End Class
