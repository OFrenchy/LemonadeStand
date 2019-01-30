using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScizzorsLizardSpock
{
    class AI : Player
    {
        // class - … Is A …
        // member variables - … Has A …

        // constructor … Spawns A …
        public AI(string name)
            : base(name, false)
        {
            this.name = name;
            this.isHuman = false;
            this.score = 0;
        }
        // member methods - … Can Do …
        public override int MakeSelection(int rangeZeroBased)
        {
            // prompt for selection
            string message = name + "'s turn: Please make a selection, enter 1 for Rock, 2 for Paper, " +
                "3 for Scissors, 4 for Lizard, or 5 for Spock: ";
            currentSelection = Convert.ToInt32(UserInterface.pickWholeNumberOneThrough(5, message, true) - 1);
            // since this player is not human, write its selection to the window
            Console.WriteLine(currentSelection + 1);
            return currentSelection;
        }
    }
}
