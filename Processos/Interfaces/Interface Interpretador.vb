'Define os métodos necessários para leitura de um processo em dispositivo de armazenamento
Public Interface Interpretador
    'Método para leitura de processos
    Function LerArquivo() As Processos
    'Método para gravação de processos
    Sub GravarArquivo(ByVal Itens As Processos)
End Interface
