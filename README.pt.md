# ProcessGantt 

[![contributions welcome](https://img.shields.io/static/v1.svg?label=Contributions&message=Welcome&color=0059b3&style=flat-square)](https://github.com/TheAlgorithms/C/blob/master/CONTRIBUTING.md)

Precisamos de contribuições para a internacionalização do software e a implementação de novos algoritmos de escalonamento.

# Introdução

Um **escalonador de processos** (tarefas) é responsável por decidir a ordem de execução das tarefas prontas (qual o próximo processo deve executar no processador quando este estiver livre).

O algoritmo utilizado no escalonador de processos impacta na eficiência de ocupação do processador e nos tempos de execução e espera de processos.

Uma forma didática de compreender como os algoritmos de escalonamento se diferenciam, apresentando visualmente a ocupação do processador em função do tempo, é através da construção de um **Diagrama de Gantt**. 

O objetivo do **Diagramador de Escalonamento de Processos** é apresentar o *Diagrama de Gantt* correspondente à execução de um conjunto de processos e calcular seus tempos de espera (*waiting time*) e execução (*turnaround time*).

# Algoritmos

Os algoritmos de escalonamento suportados são: 
1. FCFS/FIFO - First Come, First Served / First In, First Out
2. SJF (Shortest Job First)
3. SRTF (Shortest Remaining Time First)
4. Round Robin
5. Prioridade Cooperativo;
6. Prioridade Preemptivo

Para a ilustrar o funcionamento de cada algoritmo via diagrama de Gantt, considera-se que:
1. O sistema é **monoprocessado**;
2. Há um conjunto hipotético de processos (p<sub>1</sub> ... p<sub>n</sub>) na fila de processos prontos do sistema operacional, descritos na Tabela 1 a seguir.

|Processo   | p1 | p2 | p3 | p4 | p5 |
|-----------|----|----|----|----|----|
|Submissão  | 0  | 0  | 1  | 3  | 5  |
|Duração    | 5  | 2  | 4  | 1  | 2  |
|Prioridade | 2  | 3  | 1  | 4  | 5  |

Tabela 1: Processos na fila de prontos.

Cada processo tem uma registro de tempo de submissão (instante em que o processo foi criado no sistema), uma duração
(tempo de processamento que necessita para realizar sua execução) e uma prioridade (usada pelos algoritmos com prioridades).

Para simplificar a análise dos algoritmos, assumem-se algumas premissas:
1. Todos os processos são intensivamente consumidores de CPU (*CPU Bound*), ou seja, não param para realizar operações de entrada/saída (E/S). A premissa dos processos não fazerem *E/S* é requerida para focar exclusivamente no tempo de CPU.
2. Os tempos das possíveis trocas de contexto serão desprezados.
3. Os valores de prioridade, quando usados, são considerados em uma escala positiva, ou seja, valores numéricos maiores indicam maior prioridade.

# Arquivo de Configuração

Para cada conjunto hipotético de processos (p<sub>1</sub> ... p<sub>n</sub>) precisa-se de um arquivo texto de configuração, com extensão **.INI**, segundo o modelo a seguir:

### Seção que define a quantidade n de Processos 
    [Processos]
    Quantidade = n

### Seção que define cada processo. 
    [Processoi] 
    PID = i         
    Inicio = 0 
    Tempo = 5      
    Prioridade = 2  

O nome da seção deve ser composto por **"Processo" + i**, onde **i** é um número que identifica cada processo **(n <= i <= 1)**.

Os elementos desta seção são:
1. PID - determina o ID do processo para o Escalonador.
2. Inicio - determina o tempo de **submissão** do processo.
3. Tempo - especifica quanto tempo de CPU o processo necessita.
4. Prioridade - atribui uma prioridade ao processo e é usado caso o algoritmo requeira uma.


# Exemplo de uso

O arquivo INI correspondente aos processos descritos na Tabela 1 está em [Exemplo 01](https://github.com/EdeysonGomes/ProcessGantt/blob/master/Examples/Exemplo01_(Livro_Mazieiro).txt)


O primeiro passo para o uso do Escalonador é "Selecionar o arquivo de entrada", conforme Figura 1.

![Selecionando arquivo de entrada!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_01.png "Figura 1")

O segundo passo é escolher o algoritmo de escalonamento e, em seguida, executar o escalonador. Caso o algoritmo selecionado seja o Round Robin, deve-se informar, como atributo, o tamanho do Quantum. Como resultado, obtém-se o Diagrama de Gantt do escalonamento dos processos e seus tempos de espera e execução, além dos tempos médios, conforme apresenta a Figura 2.

![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_02.png "Figura 2")

No diretório **Examples** estão os arquivos .INI que correspondem às questões 5 e 6 do Capítulo 6 do livro referenciado em [2], transcritas aqui:

### Questão 5) A tabela a seguir representa um conjunto de tarefas prontas para utilizar um processador:

|Processo   | p1 | p2 | p3 | p4 | p5 |
|-----------|----|----|----|----|----|
|Submissão  | 0  | 0  | 3  | 5  | 7  |
|Duração    | 5  | 4  | 5  | 6  | 4  |
|Prioridade | 2  | 3  | 5  | 9  | 6  |

Represente graficamente a sequência de execução das tarefas (processos) e calcule os tempos médios de vida (*tournaround time*) e de espera (*waiting time*), para as políticas de escalonamento a seguir:

    (a) FCFS cooperativa
    (b) SJF cooperativa
    (c) SJF preemptiva (SRTF)
    (d) PRIO cooperativa
    (e) PRIO preemptiva
    (f) RR com Quantum = 2, sem envelhecimento

Considerações: todas as tarefas são orientadas a processamento; as trocas de contexto têm duração nula; em eventuais empates (idade, prioridade, duração,
etc), a tarefa ti com menor i prevalece; valores maiores de prioridade indicam maior prioridade.

### Questão 6) Idem, para as tarefas da tabela a seguir:

|Processo   | p1 | p2 | p3 | p4 | p5 |
|-----------|----|----|----|----|----|
|Submissão  | 0  | 0  | 1  | 7  | 11 |
|Duração    | 5  | 6  | 2  | 6  | 4  |
|Prioridade | 2  | 3  | 4  | 7  | 9  |


# Histórico

O **Diagramador de Escalonamento de Processos** é fruto de um desafio feito a meus alunos do curso de Ciência da Computação da Universidade Salvador (UNIFACS) em 2007. 
O grupo que integrou este projeto, em sua primeira versão, foi: 
1. Alunos: Jorge Calmon Moniz de Bittencourt Neto, Luis Henrique da Hora Nascimento e Milena Kelly de Santana Lima.
2. Orientador: Edeyson Andrade Gomes

A evolução atual do Escalonador visa transformá-lo num **Recurso Educacional Aberto com Licença Creative Commons CC-BY-AS**.

# Referências

1. Tanenbaum, A. S. (2015). Modern operating systems. Fourth edition ed. Boston: Pearson.
2. Maziero, C. A. (2019). Sistemas operacionais: conceitos e mecanismos. Curitiba : DINF - UFPR, 2019.
