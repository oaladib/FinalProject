
# LogiTest

This project is an educational tool to extend the basic command-line verification functionality in  [Logisim](http://www.cburch.com/logisim/) 
This will allow easier interface with the software and better enhanced interaction between instructor and his students.

## Main intended features:
- Student's groups management
- Auto assement for assignments in combinational and squential circuits.
- Easier interface for assignment offering and submitting
- Automated marking with immediate feedback to students
- Assignments deadline with penalty for late submitions
- Bulk import/export of data using CSV format
- Simple plagiarism checker using statistial analysis.


## Logisim Command-Line Verification

### Simple Example
More examples to show how to use automated assessment in sequential circuits are to be shown later

* The instructor asks the students to desin a circuit that implement the following true-table

```bash
a   b   c   d
--------------
0	0	0	0
1	0	0	1
0	1	0	1
1	1	0	1
0	0	1	0
1	0	1	0
0	1	1	0
1	1	1	0
```
* Using Logisim, one solution with minimized number of gates is implemented as follows

![Teacher Solution](/docs/images/teacher_solution.png)

* Teacher also design and implement another circuit that inculde the previous solution. The new circuit generate test cases to be appleid to the previous solution.

Sample test case generator as follows

![Test Case Generator](/docs/images/test_generator.png)

The following Command line show how to get the output for the genrated test cases
```
java -jar logisim.jar test_generator.circ -tty table
```
expected correct output
```

0	0	0	0
1	0	0	1
0	1	0	1
1	1	0	1
0	0	1	0
1	0	1	0
0	1	1	0
1	1	1	0

```
* Student is asked to submit his solution the previous question. Suppose the student solution was as follows:

![Student Solution](/docs/images/student_solution.png)

* Now we can re-run the test generator circuit after substituting the teacher' solution with the student's one.

```bash 
java -jar logisim.jar test_generator.circ -tty table -sub teacher_solution.circ student_solution.circ
```
Student solution output is

```0	0	0	0
1	0	0	0
0	1	0	1
1	1	0	1
0	0	1	0
1	0	1	1
0	1	1	0
1	1	1	1
```

* We can spot the diferences between the two solutions. This can be caught using another digital circuits as in [substituting libraries in Logisim](http://www.cburch.com/logisim/docs/2.7/en/html/guide/verify/sub.html) or it can be caught more easily using script code developed in this project.
