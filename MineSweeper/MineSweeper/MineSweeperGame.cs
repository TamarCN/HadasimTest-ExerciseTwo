using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class MineSweeperGame
    {
        #region const
        //The size of the board, and the number of the mines for each level
        public const int beginnerNumMines = 10;
        public const int beginnerRows = 9;
        public const int beginnerColumns = 9;

        public const int intermediateNumMines = 40;
        public const int intermediateRows = 16;
        public const int intermediateColumns = 16;

        public const int expertNumMines = 80;
        public const int expertRows = 16;
        public const int expertColumns = 30;

        #endregion

        #region data members

        private Board board;
        

        #endregion

        #region properties
        public Board Board
        {
            get { return board; }
        }
        

        #endregion

        #region constractor
        //This function build the board according to the choise of the player
        public MineSweeperGame(int level)
        {
            switch (level)
            {
                case 1:
                    this.board = new Board(beginnerRows, beginnerColumns, beginnerNumMines);
                    break;
                case 2:
                    this.board = new Board(intermediateRows, intermediateColumns, intermediateNumMines);
                    break;
                case 3:
                    this.board = new Board(expertRows, expertColumns, expertNumMines);
                    break;
            }
            
            
        }
        #endregion

        #region functions
        //the main function of the game
        public void PlayMineSweeper()
        {
            
            Boolean win;//True - the player won, False - the player lost
            string playAgain = "yes";
            while(playAgain.Equals("yes"))
            {
                board.BuildBoard();
               
                win = TheGame();
                if (win)
                {
                    Console.WriteLine("You win!!! =] ");
                    board.PrintBoardToPlayer();
                }
                else
                {
                    Console.WriteLine("You lost, the game is over =[ ");
                    board.PrintRealBoard();
                }
                //Asks the player whether to continue for another game or not
                Console.WriteLine("Do you want to play again? yes/no");
                playAgain = Console.ReadLine();
                while (!playAgain.Equals("yes") && !playAgain.Equals("no"))
                {
                    Console.WriteLine("please write yes/no");
                    playAgain = Console.ReadLine();
                }
                
            }
            Console.WriteLine("Goodbye");
            return;
                       
        }
        //The game
        private Boolean TheGame()
        {
            //the choices of the player
            Console.WriteLine("=======================Let's start!=======================");
            board.PrintBoardToPlayer();
            int x, y;
            int []ch;
            while(board.CellsToDiscover > 0)
            {
                ch = PlayerChoosing();
                x = ch[0];
                y = ch[1];
                if (board.IsMine(x, y))
                    return false;
                if (!board.IsDigit(x, y))
                {
                    OpenTheEmptyCells(x, y);
                    board.PrintBoardToPlayer();
                }
                else
                {
                    board.MyBoard[x, y] = 1;
                    board.CellsToDiscover--;
                    board.PrintBoardToPlayer();

                }
               
            }
            return true;


        }
        //A recursive function that opens all the cells around the cell that was pressed 
        private void OpenTheEmptyCells(int i,int j)
        {
            if (board.IsValid(i, j) == false || board.MyBoard[i, j] == 1 || board.IsMine(i, j) == true)
                return;
            board.MyBoard[i, j] = 1;
            board.CellsToDiscover--;
            if (board.IsDigit(i, j) == true)
                return;
            OpenTheEmptyCells(i - 1, j - 1);
            OpenTheEmptyCells(i - 1, j);
            OpenTheEmptyCells(i - 1, j + 1);
            OpenTheEmptyCells(i, j - 1);
            OpenTheEmptyCells(i, j + 1);
            OpenTheEmptyCells(i + 1, j - 1);
            OpenTheEmptyCells(i + 1, j);
            OpenTheEmptyCells(i + 1, j + 1);



        }

        //This function gets the number of the row and the number of the column and check if it's correct
        private int[] PlayerChoosing()
        {
            while(true)
            {
                int[] ch = new int[2];
                string s1, s2;
                Console.WriteLine("Choose a cell!");
                Console.WriteLine("-Enter number of the row:");
                s1 = Console.ReadLine();
                Console.WriteLine("-Enter number of the column:");
                s2 = Console.ReadLine();
                if (!int.TryParse(s1, out int n1) || !int.TryParse(s2, out int n2))
                {
                    Console.WriteLine("please write a number");
                    continue;
                }
                else
                {
                    ch[0] = Convert.ToInt32(s1);
                    ch[1] = Convert.ToInt32(s2);
                }
                if (ch[0] < 0 || ch[0] > board.Rows - 1 || ch[1] < 0 || ch[1] > board.Columns - 1)
                {
                    Console.WriteLine("The position of the cell is out of the range");
                    continue;
                }
                if (board.MyBoard[ch[0], ch[1]] == 1)
                {
                    Console.WriteLine("This cell had been already selected, please select another cell");
                    continue;
                }
                return ch;

            }

        }

        #endregion


    }
}
