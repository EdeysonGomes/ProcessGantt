'Representa o algoritmo de escalonamento
Public Interface IAlgoritmo
    'Descricao() Retorna uma string descrevendo o algoritmo
    'Exemplo; FIFO, SJF, SJFP, Round Robin
    Property descricao() As String

    'Atributos() Retorna a lista de atributos necessárias ao algoritmo
    'A lista deverá ser criada mesmo que não existam atributos retornando, neste caso, uma lista vazia.
    'Se houver atributos, estes deverão estar previamente inicializados com valores padrões
    ReadOnly Property atributos() As Atributos

    'Define e retorna o intervalo clock em milissegundos
    'Cada algoritmo deverá ter um timer interno
    Property intervalo() As Integer

    'Esta função recebe uma lista de processos
    Function processar(ByVal Processos As Processos) As Processos
End Interface
