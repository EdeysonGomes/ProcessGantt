'Representa o algoritmo de escalonamento
Public Interface Algoritmo
    'Descricao() Retorna uma string descrevendo o algoritmo
    'Exemplo; FIFO, SJF, SJFP, Round Robin
    Property Descricao() As String

    'Atributos() Retorna a lista de atributos necessárias ao algoritmo
    'A lista deverá ser criada mesmo que não existam atributos
    'retornando, neste caso, uma lista vazia.
    'Se houver atributos, estes deverão estar previamente inicializados com valores padrões
    ReadOnly Property Atributos() As Atributos

    'Inicia a execução do algoritmo
    Sub Executar()

    'Para a execução do algoritmo
    Sub Parar()

    'Define e retorna o intervalo clock em milissegundos
    'Cada algoritmo deverá ter um timer interno
    Property Intervalo() As Integer

    'Esta função recebe uma lista de processos
    Function Processar(ByVal Processos As Processos) As Processos
End Interface
