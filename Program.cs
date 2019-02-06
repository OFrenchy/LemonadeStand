using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameReturn = true;
            do
            {
                Game Game = new Game();
                gameReturn = Game.playGame();
            }
            while (gameReturn && UserInterface.promptForYesNoInput("Do you want to play again? Enter y or n:").ToString() == "y");
        }
    }
}
