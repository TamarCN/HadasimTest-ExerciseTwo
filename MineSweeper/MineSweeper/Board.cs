using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Board
    {
        #region data members

        private readonly int rows;//The size of the board
        private readonly int columns;
        private readonly int mines;//The number of the mines
        private int cellsToDiscover; //the number of the cells that have to be dicovered
        private string[,] realBoard;//The board of the game
        private int[,] myBoard;//This board shows which cells had been already selected

        #endregion

        #region properties
        public int Rows
        {
            get { return rows; }

        }

        public int Columns
        {
            get { return columns; }

        }

        public int Mines
        {
            get { return mines; }

        }
        public int CellsToDiscover

        {
            get { return cellsToDiscover; }
            set { cellsToDiscover = value; }
        }

        public string[,] RealBoard
        {
            get { return realBoard; }
            set { realBoard = value; }
        }

        public int[,] MyBoard
        {
            get { return myBoard; }
            set { myBoard = value; }
        }

        #endregion

        #region constractor
        public Board(int rows,int columns, int mines)
        {
            this.rows = rows;
            this.columns = columns;
            this.mines = mines;
            this.cellsToDiscover = 0;
            this.realBoard = new string[this.rows,this.columns];
            this.myBoard = new int[this.rows, this.columns];
            
        }

        #endregion

        #region functions
        //This function builds the board
        public void BuildBoard()
        {
            int i, j;
            //Initialize the board
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    realBoard[i, j] = "0";
                }

            }
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    myBoard[i, j] = 0;
                }

            }
            //calculate number of the cells that have to be dicovered
            cellsToDiscover = rows * columns - mines;
            //Random the postion of the mine
            Random rnd = new Random();
            int count = mines;
            while (count > 0)
            {
                i = rnd.Next(1, rows);
                j = rnd.Next(1, columns);
                if (!realBoard[i, j].Equals("*"))
                {
                    realBoard[i, j] = "*";
                    CountAdjacentMines(i, j);
                    count--;
                }

            }
            

        }

        //This function finds for each cell in the board the number of the adjacent mines
        private  void CountAdjacentMines(int i, int j)
        {
            int num = 0;
            //Above the cell
            if (i > 0)
            {
                if (!IsMine(i - 1, j))
                {
                    num = Int32.Parse(realBoard[i - 1, j]);
                    num++;
                    realBoard[i - 1, j] = num.ToString();
                }
            }
            //Under the cell
            if (0 < i && i < rows - 1)
            {
                if (!IsMine(i + 1, j))
                {
                    num = Int32.Parse(realBoard[i + 1, j]);
                    num++;
                    realBoard[i + 1, j] = num.ToString();
                }
            }
            //The column on the right side
            if (j > 0)
            {
                if (!IsMine(i, j - 1))
                {
                    num = Int32.Parse(realBoard[i, j - 1]);
                    num++;
                    realBoard[i, j - 1] = num.ToString();
                }
                if (i > 0)
                {
                    if (!IsMine(i - 1, j - 1))
                    {
                        num = Int32.Parse(realBoard[i - 1, j - 1]);
                        num++;
                        realBoard[i - 1, j - 1] = num.ToString();
                    }
                }
                if (i < rows - 1)
                {
                    if (!IsMine(i + 1, j - 1))
                    {
                        num = Int32.Parse(realBoard[i + 1, j - 1]);
                        num++;
                        realBoard[i + 1, j - 1] = num.ToString();
                    }
                }
            }
            //The column on the left side
            if (j < columns - 1)
            {
                if (!IsMine(i, j + 1))
                {
                    num = Int32.Parse(realBoard[i, j + 1]);
                    num++;
                    realBoard[i, j + 1] = num.ToString();
                }
                if (i > 0)
                {
                    if (!IsMine(i - 1, j + 1))
                    {
                        num = Int32.Parse(realBoard[i - 1, j + 1]);
                        num++;
                        realBoard[i - 1, j + 1] = num.ToString();
                    }
                }
                if (i < rows - 1)
                {
                    if (!IsMine(i + 1, j + 1))
                    {
                        num = Int32.Parse(realBoard[i + 1, j + 1]);
                        num++;
                        realBoard[i + 1, j + 1] = num.ToString();
                    }
                }
            }

        }

        //Checking if the cell is valid or not
        public Boolean IsValid(int i, int j)
        {
            if (i >= 0 && i < rows && j >= 0 && j < columns)
                return true;
            return false;
        }

        //Checking if the cell is a digit or not
        public Boolean IsDigit(int i, int j)
        {
            if (!realBoard[i, j].Equals("0") && !realBoard[i, j].Equals("*"))
                return true;
            return false;
        }


        //Checking if the cell is a mine or not
        public Boolean IsMine(int i, int j)
        {
            if (realBoard[i, j].Equals("*"))
                return true;
            return false;
        }

        //Print the realBoard to the player
        public void PrintRealBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(" "+realBoard[i, j] + " ");


                }
                Console.WriteLine();

            }
        }

        //Prints for each player's choice the board with all the cells he had revealed so far
        public void PrintBoardToPlayer()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (myBoard[i, j] == 1)
                        Console.Write(" " + realBoard[i, j] + " ");
                    else
                        Console.Write(" - ");

                }
                Console.WriteLine();

            }
            Console.WriteLine("==========================================================");
        }

        #endregion
    }


}
