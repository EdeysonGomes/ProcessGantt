# ProcessGantt - Exemplo de Uso

Para ilustrar o **Diagramador de Escalonamento de Processos**, selecionamos um dos exercícios do capítulo 6 do livro referenciado em [2], descrito a seguir:

**Questão 5)** A tabela a seguir representa um conjunto de tarefas prontas para utilizar um processador:

|Tarefa     | t1 | t2 | t3 | t4 | t5 |
|-----------|----|----|----|----|----|
|ingresso   | 0  | 0  | 3  | 5  | 7  |
|duração    | 5  | 4  | 5  | 6  | 4  |
|prioridade | 2  | 3  | 5  | 9  | 6  |

Represente graficamente a sequência de execução das tarefas (processos) e calcule os tempos médios de vida (*tournaround time*) e de espera (*waiting time*), para as políticas de escalonamento a seguir:

    (a) FCFS cooperativa
    (b) SJF cooperativa
    (c) SJF preemptiva (SRTF)
    (d) PRIO cooperativa
    (e) PRIO preemptiva
    (f) RR com Quantum = 2, sem envelhecimento

Considerações: todas as tarefas são orientadas a processamento; as trocas de contexto têm duração nula; em eventuais empates (idade, prioridade, duração, etc), a tarefa **ti** com menor **i** prevalece; valores maiores de prioridade indicam maior prioridade.


# Arquivo de configuração (.INI)

O arquivo INI correspondente ao processo descrito na Tabela está em [Livro Mazieiro Q6.5](https://github.com/EdeysonGomes/ProcessGantt/blob/master/Examples/Exemplo04_(Livro_Mazieiro_Q6.5).txt)


O primeiro passo para o uso do Escalonador é "Selecionar o arquivo de entrada", conforme Figura 1.

![Selecionando arquivo de entrada!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_01.png "Figura 1")

O segundo passo é escolher o algoritmo de escalonamento e, em seguida, executar o escalonador. Caso o algoritmo selecionado seja o Round Robin, deve-se informar, como atributo, o tamanho do Quantum. Como resultado, obtém-se o Diagrama de Gantt do escalonamento dos processos e seus tempos de espera e execução, além dos tempos médios, conforme apresenta a Figura 2.

![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_02.png "Figura 2")

No diretório **Examples** estão os arquivos .INI que correspondem às questões 5 e 6 do Capítulo 6 do livro referenciado em [2], transcritas aqui:



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
