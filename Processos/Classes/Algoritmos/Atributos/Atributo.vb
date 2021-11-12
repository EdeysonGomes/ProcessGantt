'Classe que permite a defini��o de processo gen�ricoscom n�mero indefinido de atributos
Public Class Atributo
    'vari�veis internas para armazenamento de atributos
    Dim locNome As String
    Dim locValor As Object = Nothing
    Public locTipo As TiposDeAtributos

    'Enumera��o de tipos de atributos suportados
    Public Enum TiposDeAtributos
        taPontoFlutuante
        taInteiro
        taString
    End Enum

    'Construtor da classe
    Public Sub New(ByVal Nome As String, ByVal Tipo As TiposDeAtributos)
        Me.locNome = Nome
        Me.locTipo = Tipo
    End Sub

    'Retorna o nome do atributo tal como aparecer� para o usu�rio
    Public ReadOnly Property Nome() As String
        Get
            Return Me.locNome
        End Get
    End Property

    'Retorna ou define o valor do atributo
    Public Property Valor() As Object
        Get
            Return locValor
        End Get
        Set(ByVal NovoValor As Object)
            Me.locValor = NovoValor
        End Set
    End Property

    'Retorna o tipo de valor esperado. Caso o tipo errado seja usado na propriedade
    'valor isto poder� gerar um erro que dever� ser interceptado e tratado pelo
    'consumidor final da classe
    Public ReadOnly Property Tipo() As TiposDeAtributos
        Get
            Return locTipo
        End Get
    End Property
End Class
