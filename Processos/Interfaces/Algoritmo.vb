'Representa o algoritmo de escalonamento
Public Interface Algoritmo
    'Descricao() Retorna uma string descrevendo o algoritmo
    'Exemplo; FIFO, SJF, SJFP, Round Robin
    Property Descricao() As String

    'Atributos() Retorna a lista de atributos necess�rias ao algoritmo
    'A lista dever� ser criada mesmo que n�o existam atributos
    'retornando, neste caso, uma lista vazia.
    'Se houver atributos, estes dever�o estar previamente inicializados com valores padr�es
    ReadOnly Property Atributos() As Atributos

    'Inicia a execu��o do algoritmo
    Sub Executar()

    'Para a execu��o do algoritmo
    Sub Parar()

    'Define e retorna o intervalo clock em milissegundos
    'Cada algoritmo dever� ter um timer interno
    Property Intervalo() As Integer

    'Esta fun��o recebe uma lista de processos
    Function Processar(ByVal Processos As Processos) As Processos
End Interface
