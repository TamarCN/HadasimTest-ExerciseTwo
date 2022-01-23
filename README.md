# HadasimTest-ExerciseTwo

## Table of contents
* [Description](#Description)
* [Example](#Example)
* [Setup](#setup)
* [Running](#Running)

## Description
This project is a MineSweepwe game.
At the beginning the player enters the level of the game, and the system builds the board of the game.
The system builds two matrices, the first one includes the mines and the empty cells, and the neighbors of the mines. The secound matrix stored the cells that had been already opened.
The player chooses any cell in the board, and the system shows him the result of his choise.

## Example
The player needs to choose the difficulty level to start the game. In each turn he needs to enter the coordinate of the cell:
```
Welcome to MineSweeper Game!! =]
Choose the difficulty level of the game:
beginner-1 * intermediate-2 * export-3
>>>your input
=======================Let's start!=======================
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
 -  -  -  -  -  -  -  -  -
==========================================================
Choose a cell!
-Enter number of the row:
>>>your input
-Enter number of the column:
>>>your input
```
The output in case of failure:
```
You lost, the game is over =[
 0  0  0  0  0  0  1  2  2
 0  0  0  0  1  2  3  *  *
 0  1  1  1  1  *  *  4  2
 1  2  *  1  2  4  *  2  0
 1  *  2  1  1  *  2  1  0
 1  1  1  0  1  1  1  0  0
 0  0  0  0  0  1  2  2  1
 0  0  0  0  0  1  *  *  1
 0  0  0  0  0  1  2  2  1
Do you want to play again? yes/no

```
	
## Setup
visaul studio 2017 and up.

## Running
Downloaded the project.
Open MineSweeper.sln and run it.
