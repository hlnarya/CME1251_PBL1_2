# CME1251_PBL1_2
Matching Number Game
Project:   11 22 33
 

The aim of the project is to develop a one-player number matching game.
The player will try to get the highest score by matching the same numbers side by side.
When two identical numbers come together, they disappear and the player gets 10 points. 


Game Playing Rules

1. The game is played on a 3x30 board.

2. In the beginning, the board is randomly filled with 30 random numbers which are 1, 2 and 3. 

3. The arrow keys on the keyboard are used to move the cursor and WASD keys are used to move the number under the cursor.

4. WASD keys can move only the single numbers (the left and right side of the number should be empty). 
W : Moves the number one square up. 
S : Moves the number one square down. 
A : Moves the number to the left as much as it can go.
D : Moves the number to the right as much as it can go.

5. If two identical numbers come together on the same line (by player moves or randomly), 
•	Matching numbers are deleted from the board 
•	The player's score increases by 10 points. 
•	New two random numbers are generated and randomly placed on the board 



Sample Screens 

+--------------------------------+      Score = 30
|    3 1321   1 3 3  1      1 21 |
|  1    323  3 31     2       23 |
| 123            2       121   3 |
+--------------------------------+


+--------------------------------+      Score = 40
|    3 13211    3 3  1      1 21 |
|  1    323  3 31     2       23 |
| 123            2       121   3 |
+--------------------------------+


+--------------------------------+      Score = 40
| 1  3 132      3 3 31      1 21 |
|  1    323  3 31     2       23 |
| 123            2       121   3 |
+--------------------------------+



+--------------------------------+      Score = 40
| 1  3 132      3 3 31      1 21 |
|  1    323  3 31     2       23 |
| 123            2       121   3 |
+--------------------------------+


+--------------------------------+      Score = 40
| 1  3 132      3 3 31        21 |
|  1    323  3 31     2     1 23 |
| 123            2       121   3 |
+--------------------------------+


+--------------------------------+      Score = 50
| 1  3 132      3 3 31        21 |
|  1    323  3 31     2       23 |
| 123            2       1211  3 |
+--------------------------------+


+--------------------------------+      Score = 60
| 1  3 132      3 3 31       121 |
|  1    323  3 31     22      23 |
| 123            2       12    3 |
+--------------------------------+


+--------------------------------+      Score = 60
| 1  3 132 2    3 3 31       121 |
|  1    323  3 31             23 |
| 123    1       2       12    3 |
+--------------------------------+



