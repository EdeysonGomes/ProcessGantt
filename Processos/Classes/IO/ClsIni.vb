'Classe para leitura e gravação de arquivos no formato INI
Public Class ClsIni
    'API do windows usadas para interpretação de arquivos INI
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal LpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFilename As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    'Armazena localmente o caminho e o nome do arquivo de entrada/saída
    Dim LocArquivo As String

    'Construtor da classe
    Public Sub New(ByVal Arquivo As String)
        Me.LocArquivo = Arquivo
    End Sub

    'Retorna o nome do arquivo definido na criação do objeto
    Public ReadOnly Property Arquivo() As String
        Get
            Return Me.LocArquivo
        End Get
    End Property

    'Grava dados no arquivo
    Public Sub Gravar(ByVal Secao As String, ByVal Chave As String, ByVal Dados As String)
        WritePrivateProfileString(Secao, Chave, Dados, LocArquivo)
    End Sub

    'Lê dados a partir do arquivo, permitindo ao usuário definir o valor padrão
    Public Function Ler(ByVal Secao As String, ByVal Chave As String, ByVal ValorPadrao As String)
        Dim Dados As String = New String(Chr(32), 2048)
        Dim Tamanho As Integer = Len(Dados)
        GetPrivateProfileString(Secao, Chave, ValorPadrao, Dados, Tamanho, LocArquivo)
        Tamanho = InStr(Dados, vbNullChar)
        Return Left(Dados, Tamanho - 1)
    End Function

    'Lê dados a partir do arquivo, usando uma string vazia como valor padrão
    Public Function Ler(ByVal Secao As String, ByVal Chave As String)
        Return Me.Ler(Secao, Chave, "")
    End Function
End Class
