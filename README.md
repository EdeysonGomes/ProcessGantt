# ProcessGantt 

[![contributions welcome](https://img.shields.io/static/v1.svg?label=Contributions&message=Welcome&color=0059b3&style=flat-square)](https://github.com/TheAlgorithms/C/blob/master/CONTRIBUTING.md)

# Introdução

Um **escalonador de processos** (tarefas) é responsável por decidir a ordem de execução das tarefas prontas (qual o próximo processo deve executar no processador quando este estiver livre).

O algoritmo utilizado no escalonador de processos impacta na eficiência de ocupação do processador e nos tempos de execução e espera de processos.

Uma forma didática de compreender como os algoritmos de escalonamento se diferenciam é através da construção do correspondente **Diagrama de Gantt**.

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
1. O sistema é **monoprocessado**
2. Há um conjunto hipotético de processos (p<sub>1</sub> ... p<sub>n</sub>) na fila de processos prontos do sistema operacional, descritos na Tabela 1 a seguir.

|Processo   | p1 | p2 | p3 | p4 | p5 |
|-----------|----|----|----|----|----|
|Submissão  | 0  | 0  | 1  | 3  | 5  |
|Duração    | 5  | 2  | 4  | 1  | 2  |
|Prioridade | 2  | 3  | 1  | 4  | 5  |

Tabela 1: Processos na fila de prontoas.

Cada processo tem uma registro de tempo de submissão (instante em que o processo foi criado no sistema), uma duração
(tempo de processamento que necessita para realizar sua execução) e uma prioridade (usada pelos algoritmos com prioridades).

Para simplificar a análise dos algoritmos, assumem-se algumas premissas:
1. Todos os processos são intensivamente consumidores de CPU (*CPU Bound*), ou seja, não param para realizar operações de entrada/saída (E/S). A premissa dos processos não fazerem *E/S* é requerida para focar exclusivamente no tempo de CPU.
2. Os tempos das possíveis trocas de contexto serão desprezados.


# Histórico

O **Diagramador de Escalonamento de Processos** é fruto de um desafio feito a meus alunos do curso de Ciência da Computação da Universidade Salvador (UNIFACS) em 2007. 
O grupo que integrou este projeto, em sua primeira versão, foi: 
1. Alunos: Jorge Calmon Moniz de Bittencourt Neto, Luis Henrique da Hora Nascimento e Milena Kelly de Santana Lima.
2. Orientador: Edeyson Andrade Gomes

A evolução atual do Escalonador visa transformá-lo num **Recurso Educacional Aberto com Licença Creative Commons CC-BY-AS**.

