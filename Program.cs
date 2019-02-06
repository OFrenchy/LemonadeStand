using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        //public Game Game
        //{
        //    get => default(Game);
        //    set
        //    {
        //    }
        //}

        static void Main(string[] args)
        {
            do
            {
                Game Game = new Game();
                Game.playGame();
            }
            while (UserInterface.promptForYesNoInput("Do you want to add another player? Enter y or n:").ToString() == "y");
        }
    }
}
