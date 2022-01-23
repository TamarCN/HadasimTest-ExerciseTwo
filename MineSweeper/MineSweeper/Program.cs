using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //The beginning of the game
                Console.WriteLine("Welcome to MineSweeper Game!! =] ");
                Console.WriteLine("Choose the difficulty level of the game:");
                //The player choose the level of the game
                Console.WriteLine("beginner-1 * intermediate-2 * export-3");
                int level;
                MineSweeperGame mineSweeper;
                level = Convert.ToInt32(Console.ReadLine());
                while(level != 1 && level != 2 && level != 3)
                {
                    Console.WriteLine("Please enter correct level");
                    level = Convert.ToInt32(Console.ReadLine());
                }
                mineSweeper = new MineSweeperGame(level);
                mineSweeper.PlayMineSweeper();
               

                //Clean resource
                mineSweeper = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            finally { }

                    


        }
    }
}
