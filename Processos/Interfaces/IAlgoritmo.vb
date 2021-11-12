'Representa o algoritmo de escalonamento
Public Interface IAlgoritmo
    'Descricao() Retorna uma string descrevendo o algoritmo
    'Exemplo; FIFO, SJF, SJFP, Round Robin
    Property descricao() As String

    'Atributos() Retorna a lista de atributos necess�rias ao algoritmo
    'A lista dever� ser criada mesmo que n�o existam atributos retornando, neste caso, uma lista vazia.
    'Se houver atributos, estes dever�o estar previamente inicializados com valores padr�es
    ReadOnly Property atributos() As Atributos

    'Define e retorna o intervalo clock em milissegundos
    'Cada algoritmo dever� ter um timer interno
    Property intervalo() As Integer

    'Esta fun��o recebe uma lista de processos
    Function processar(ByVal Processos As Processos) As Processos
End Interface
