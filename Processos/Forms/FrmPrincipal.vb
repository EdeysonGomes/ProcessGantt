Imports System.Text
'Formulário que implementa a interface com o usuário
Public Class FrmPrincipal
    'Variável compartilhada para armazenamento do algoritmo em uso
    Shared Algoritmo As Algoritmo = Nothing

    'Retorna a asta a partir de onde o sistema está sendo executado
    'garante uma barra no final
    Private Function PastaDoSistema() As String
        Dim Ret() As String = Split(Application.ExecutablePath, "\")
        Ret(Ret.GetUpperBound(0)) = "\"
        Return Replace(Join(Ret, "\"), "\\", "\")
    End Function

    'Incialização do formulário
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Assume que o FIFO estará selecionado
        LstAlgoritmo.SelectedIndex = 0
        'Inicializa a caixa de texto de arquivo de entrada com um arquivo padrão
        TxtArquivoEntrada.Text = PastaDoSistema() & "Processos1.txt"
    End Sub

    'Botão Abrir
    Private Sub CmdAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAbrir.Click
        'Cria um diálogo Arquivo-Abrir padrão do sistema
        Dim F As New OpenFileDialog
        'Requer a existência do arquivo
        F.CheckFileExists = True
        'Assume arquivos do tipo TXT como entrada padrão
        F.Filter = "Arquivo Texto (*.txt)|*.txt"
        'Assume o arquivo atualmente selecionado como padrão
        F.FileName = TxtArquivoEntrada.Text
        'Mostra o diálogo e, caso haja sucesso...
        If F.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            'Passa o caminho e nome do arquivo para a caixa de texto específica
            TxtArquivoEntrada.Text = F.FileName
        End If
    End Sub

    'Executa o algorítimo selecionado
    Private Sub CmdExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExecutar.Click
        'Guarda o arquivo a ser aberto em uma variável, por medida de segurança
        Dim Arquivo As String = TxtArquivoEntrada.Text
        'Verifica se o arquivo existe
        If System.IO.File.Exists(Arquivo) Then
            'Cria a classe de leitura em formato INI
            Dim Entrada As Interpretador = New InterpretadorIni(Arquivo)
            'Carrega os processos de entrada
            Dim ProcessosEntrada As Processos = Entrada.LerArquivo
            'Define a variável para armazenar o resultado do processamento
            Dim ProcessosSaida As Processos = Nothing
            'Se não houver nenhum processo de entrada
            If ProcessosEntrada.Count < 1 Then
                'Notifica o usuário
                MsgBox("A simulação não pode prosseguir, pois os processos não puderam ser carregados. Verifiqe se o arquivo de entrada está no formato correto.")
            Else 'Caso contrário
                'Processa a lista de entrada com o algoritmo especificado
                ProcessosSaida = Algoritmo.Processar(ProcessosEntrada)
                'Passa o rsultado para o componente de processamento gráfico
                Gantt1.Processos = ProcessosSaida
                'Cria uma classe de análise
                Dim Analisador As New Analises
                'Passa as listas para serem analisadas
                Analisador.MontarAnalise(ProcessosEntrada, ProcessosSaida)
                'constoi o parecer e exibe ao usuário
                Dim Construtor As New StringBuilder
                Construtor.Append("Algoritmo usado: ")
                Construtor.AppendLine(Algoritmo.Descricao)
                If Algoritmo.Atributos.Count > 0 Then
                    Construtor.AppendLine(" Atributos:")
                    For Each Atributo As Atributo In Algoritmo.Atributos.Values
                        Construtor.Append("  - ")
                        Construtor.Append(Atributo.Nome)
                        Construtor.Append(" = ")
                        Construtor.AppendLine(Atributo.Valor.ToString)
                    Next
                End If
                Construtor.AppendLine()
                Construtor.Append(Analisador.ObterParecer)
                TxtRelatorio.Text = Construtor.ToString
            End If
        Else 'Caso contrário
            'Notifica ao usuário o problema
            MsgBox("O arquivo de entrada especificado não existe.", MsgBoxStyle.Critical)
        End If
    End Sub

    'Mostra informações sobre o programa
    Private Sub CmdSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSobre.Click
        Dim F As New FrmSobre
        F.ShowDialog()
        F.Dispose()
        F = Nothing
    End Sub

    'Quano o usuário selecionar um algoritmo
    Private Sub LstAlgoritmo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstAlgoritmo.SelectedIndexChanged
        'Identifica o algoritmo desejado e cria uma instância padrão deste
        Select Case LstAlgoritmo.Text
            Case "First Come, First Served (FCFS)"
                Algoritmo = New Fifo
            Case "Shortest Job First (SJF)"
                Algoritmo = New SJF
            Case "Shortest Remaining Time First (SRTF)"
                Algoritmo = New SJFP
            Case "Round Robin"
                Algoritmo = New RoundRobin
            Case "Prioridade Cooperativo"
                Algoritmo = New PrioridadeCooperativo
            Case "Prioridade Preemptivo"
                Algoritmo = New PrioridadePreemptivo
        End Select

        'Destrói as caixas de texto de atributos do algoritmo anterior e elimina
        'os handdles de eventos
        LimparTxt()
        'Verifica se existem atributos no novo algoritmo
        If Algoritmo.Atributos.Count > 0 Then
            'Posição da caixa de texto na ordem de visualização
            Dim Pos As Integer = 0
            'Para cada atributo encontrado
            For Each Atributo As Atributo In Algoritmo.Atributos.Values
                'Cria uma as caixa de texto de atributos define os handdles de eventos para esta
                IncluirTxt(Atributo.Nome, Pos, Atributo.Valor)
                'Incrementa a posição para a próxima caixa
                Pos += 1
            Next
        End If
    End Sub

    'Cria dinamicamente uma nova caixa de texto, em runtime, definindo handdles de eventos
    Private Sub IncluirTxt(ByVal Nome As String, ByVal Posicao As Integer, ByVal Valor As Object)
        'Cria a nova caixa e o novo rótulo
        Dim NovoTxt As New TextBox
        Dim NovoLbl As New Label
        'Posiciona o rótulo na tela e define seu tamanho e texto de exibição
        NovoLbl.Size = New Size(100, 15)
        NovoLbl.Location = New Point(Posicao * 110 + 10, 0)
        NovoLbl.Text = Nome
        'Adiciona o rótulo à lista de componentes do conteiner específico
        PanAtributos.Controls.Add(NovoLbl)

        'Posiciona a caixa de texto na tela e define seu tamanho, nome e valor padrão
        NovoTxt.Name = "txt" & Replace(Nome, " ", "_")
        NovoTxt.Tag = Nome
        NovoTxt.Size = New Size(100, 15)
        NovoTxt.Location = New Point(Posicao * 110 + 10, 15)
        NovoTxt.Text = Valor.ToString
        'Adiciona a caixa de texto à lista de componentes do conteiner específico
        PanAtributos.Controls.Add(NovoTxt)

        'Cria os handdles de eventos necessários
        AddHandler NovoTxt.KeyPress, AddressOf Txt_KeyPress
        AddHandler NovoTxt.LostFocus, AddressOf Txt_LostFocus
        AddHandler NovoTxt.GotFocus, AddressOf Txt_GotFocus
    End Sub

    'Destroi componentes criados dinamicamente
    Private Sub LimparTxt()
        'para cada componente do conteiner específico
        For Each Controle As Control In PanAtributos.Controls
            'Verifica se é uma caixa de texto
            If TypeOf Controle Is TextBox Then
                'Armazena numa variável específica
                Dim Txt As TextBox = Controle
                'Remove os handdles de eventos
                RemoveHandler Txt.KeyPress, AddressOf Txt_KeyPress
                RemoveHandler Txt.LostFocus, AddressOf Txt_LostFocus
                RemoveHandler Txt.GotFocus, AddressOf Txt_GotFocus
            End If
        Next
        'Limpa completamente a lista de componenbtes
        PanAtributos.Controls.Clear()
    End Sub

    'Grava os dados de um atributo, representado na tela por uma caixa de texto
    Private Sub GravarTxt(ByVal Txt As TextBox)
        Try
            'Conforme o tipo de atributo, produz um valor válido
            Select Case Algoritmo.Atributos(Txt.Tag).Tipo
                Case Atributo.TiposDeAtributos.taString
                    Algoritmo.Atributos(Txt.Tag).Valor = Txt.Text
                Case Atributo.TiposDeAtributos.taInteiro
                    Algoritmo.Atributos(Txt.Tag).Valor = CInt(Txt.Text)
                Case Atributo.TiposDeAtributos.taPontoFlutuante
                    Algoritmo.Atributos(Txt.Tag).Valor = CDbl(Txt.Text)
            End Select
        Catch ex As Exception
            'Se não for possível obter um valor válido restaura o valor corrente e notifica o usuário
            Txt.Text = Algoritmo.Atributos(Txt.Tag).Valor.ToString
            Txt.SelectAll()
            Beep()
        End Try
    End Sub

    'Interceptador do evento de pressionamento de tecla
    Private Sub Txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Se for um enter
        If e.KeyChar = Chr(13) Then
            'Tenta gravar o valor
            GravarTxt(sender)
            'E ignora o evento para não ocorrer um bip do sistema
            e.Handled = True
        End If
    End Sub

    'Interceptador do evento de recebimento de foco do teclado
    Private Sub Txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Obtém o valor corrente do atributo
        Dim Txt As TextBox = sender
        Txt.Text = Algoritmo.Atributos(Txt.Tag).Valor.ToString
        Txt.SelectAll()
    End Sub

    'Interceptador do evento de perda de foco do teclado
    Private Sub Txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Tenta gravar o valor corrente
        GravarTxt(sender)
    End Sub
End Class
