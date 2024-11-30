
# ProcessGantt

[![contributions welcome](https://img.shields.io/static/v1.svg?label=Contributions&message=Welcome&color=0059b3&style=flat-square)](https://github.com/TheAlgorithms/C/blob/master/CONTRIBUTING.md)

We welcome contributions to the internationalization of the software and the implementation of new scheduling algorithms.

# Introduction

A **process scheduler** (task scheduler) is responsible for deciding the execution order of ready tasks (which process will run next on the processor when it is idle).

The algorithm used by the process scheduler impacts the efficiency of processor utilization as well as process execution and waiting times.

A didactic way to understand how scheduling algorithms differ, by visually presenting processor utilization over time, is through the creation of a **Gantt Chart**.

The goal of the **Process Scheduling Diagrammer** is to display the *Gantt Chart* corresponding to the execution of a set of processes and calculate their *waiting time* and *turnaround time*.

# Algorithms

The supported scheduling algorithms are:
1. FCFS/FIFO - First Come, First Served / First In, First Out
2. SJF (Shortest Job First)
3. SRTF (Shortest Remaining Time First)
4. Round Robin
5. Cooperative Priority
6. Preemptive Priority

To illustrate the behavior of each algorithm via a Gantt chart, the following considerations apply:
1. The system is **single-processor**.
2. A hypothetical set of processes (p<sub>1</sub> ... p<sub>n</sub>) is present in the operating system's ready queue, described in Table 1 below.

|Process   | p1 | p2 | p3 | p4 | p5 |
|----------|----|----|----|----|----|
|Arrival   | 0  | 0  | 1  | 3  | 5  |
|Duration  | 5  | 2  | 4  | 1  | 2  |
|Priority  | 2  | 3  | 1  | 4  | 5  |

Table 1: Processes in the ready queue.

Each process has an arrival time (when it was created in the system), a duration (CPU time required for its execution), and a priority (used by priority-based algorithms).

To simplify the analysis of the algorithms, the following assumptions are made:
1. All processes are CPU-bound, meaning they do not pause to perform input/output (I/O) operations. This assumption focuses exclusively on CPU time.
2. Context switch times are ignored.
3. Priority values, when used, are considered on a positive scale, meaning higher numerical values indicate higher priority.

# Configuration File

For each hypothetical set of processes (p<sub>1</sub> ... p<sub>n</sub>), a configuration text file with the **.INI** extension is required, following the model below:

### Section defining the number `n` of processes
```ini
[Processes]
Quantity = n
```

### Section defining each process
```ini
[Processi]
PID = i         
Start = 0 
Time = 5      
Priority = 2  
```

The section name must consist of **"Process" + i**, where **i** is a number identifying each process **(n >= i >= 1)**.

Elements of this section:
1. PID - Identifies the process for the Scheduler.
2. Start - Determines the process's **arrival time**.
3. Time - Specifies the CPU time required for execution.
4. Priority - Assigns a priority to the process, used if the algorithm requires one.

# Usage Example

The INI file corresponding to the processes described in Table 1 is available at [Example 01](https://github.com/EdeysonGomes/ProcessGantt/blob/master/Examples/Exemplo01_(Livro_Mazieiro).txt).

The first step in using the Scheduler is to "Select the input file," as shown in Figure 1.

![Selecting input file](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_01.png "Figure 1")

The second step is to choose the scheduling algorithm and then execute the scheduler. If the Round Robin algorithm is selected, the quantum size must be specified. The result includes the Gantt chart of process scheduling and the waiting and turnaround times, along with their averages, as shown in Figure 2.

![Running the scheduler](https://github.com/EdeysonGomes/ProcessGantt/blob/master/img/Tela_Escalonador_02.png "Figure 2")

The **Examples** directory contains .INI files corresponding to questions 5 and 6 from Chapter 6 of the referenced book [2], transcribed here:

### Question 5: The table below represents a set of tasks ready to use a processor:

|Process   | p1 | p2 | p3 | p4 | p5 |
|----------|----|----|----|----|----|
|Arrival   | 0  | 0  | 3  | 5  | 7  |
|Duration  | 5  | 4  | 5  | 6  | 4  |
|Priority  | 2  | 3  | 5  | 9  | 6  |

Graphically represent the task execution sequence (processes) and calculate the average turnaround time and waiting time for the following scheduling policies:

(a) Cooperative FCFS  
(b) Cooperative SJF  
(c) Preemptive SJF (SRTF)  
(d) Cooperative Priority  
(e) Preemptive Priority  
(f) Round Robin with Quantum = 2, no aging  

Considerations: All tasks are CPU-bound; context switch times are zero; in case of ties (arrival time, priority, duration, etc.), the task `ti` with the smallest `i` prevails; higher priority values indicate higher priority.

### Question 6: Same as above, for the tasks in the table below:

|Process   | p1 | p2 | p3 | p4 | p5 |
|----------|----|----|----|----|----|
|Arrival   | 0  | 0  | 1  | 7  | 11 |
|Duration  | 5  | 6  | 2  | 6  | 4  |
|Priority  | 2  | 3  | 4  | 7  | 9  |

# History

The **Process Scheduling Diagrammer** originated as a challenge given to students of the Computer Science program at Universidade Salvador (UNIFACS) in 2007.  
The group involved in the first version of this project included:  
1. Students: Jorge Calmon Moniz de Bittencourt Neto, Luis Henrique da Hora Nascimento, and Milena Kelly de Santana Lima.  
2. Advisor: Edeyson Andrade Gomes.

The current evolution of the Scheduler aims to transform it into an **Open Educational Resource with a Creative Commons CC-BY-SA License**.

# References

1. Tanenbaum, A. S. (2015). Modern operating systems. Fourth edition. Boston: Pearson.  
2. Maziero, C. A. (2019). Sistemas operacionais: conceitos e mecanismos. Curitiba: DINF - UFPR, 2019.
