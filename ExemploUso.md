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
    (f) RR com Quantum = 2, 4 e 10, sem envelhecimento

**Considerações:**
1. Todas as tarefas são orientadas a processamento; 
2. As trocas de contexto têm duração nula; 
3. Em eventuais empates (idade, prioridade, duração, etc), a tarefa **ti** com menor **i** prevalece; 
4. Valores maiores de prioridade indicam maior prioridade.
5. Adicionamos os *quanta* 2 e 10 ao item f.


# Arquivo de configuração (.INI)

O arquivo INI correspondente aos processos descritos na tabela está em [Livro Mazieiro Q6.5](https://github.com/EdeysonGomes/ProcessGantt/blob/master/Examples/Exemplo04_(Livro_Mazieiro_Q6.5).txt)

O primeiro passo para o uso do Escalonador é "Selecionar o arquivo de entrada", conforme Figura 1. Ressalta-se que é um arquivo texto contendo a estrutura (INI) descrita no arquivo Readme.md.

![Selecionando arquivo de entrada!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_01.png "Figura 1")

O segundo passo é escolher o algoritmo de escalonamento e, em seguida, executar o escalonador. Caso o algoritmo selecionado seja o Round Robin, deve-se informar, como atributo, o tamanho do Quantum. Como resultado, obtém-se o Diagrama de Gantt do escalonamento dos processos e seus tempos de espera e execução, além dos tempos médios.

### FCFS cooperativa 
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_FCFS.jpg "FCFS")

### SJF cooperativa
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_SJF.jpg "SJF")

### SJF preemptiva (SRTF)
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_SRTF.jpg "SRTF")

### PRIO cooperativa
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_PrioC.jpg "PRIO C")

### PRIO preemptiva
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_PrioP.jpg "PRIO P")

### RR com Quantum = 2, sem envelhecimento
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_RR_Q2.jpg "Round Robin Quantum = 2")

### RR com Quantum = 4, sem envelhecimento
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_RR_Q4.jpg "Round Robin Quantum = 4")

### RR com Quantum = 10, sem envelhecimento
![Executando o escalonador!](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Q6.5_RR_Q10.jpg "Round Robin Quantum = 10")

# Referências

1. Tanenbaum, A. S. (2015). Modern operating systems. Fourth edition ed. Boston: Pearson.
2. Maziero, C. A. (2019). Sistemas operacionais: conceitos e mecanismos. Curitiba : DINF - UFPR, 2019.
