using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScizzorsLizardSpock
{
    class Human : Player
    {
        // class - … Is A …
        // member variables - … Has A …

        // constructor … Spawns A …
        public Human(string name, bool isHuman)
            // works b4 huyman/ai class implementsation
            //: base()    //(name,isHuman )
            : base(name, isHuman)
        {
            this.name = name;
            this.isHuman = isHuman;
            this.score = 0;
        }
        // member methods - … Can Do …
        public override int MakeSelection(int rangeZeroBased)
        {
            // prompt for selection
            string message = name + "'s turn: Please make a selection, enter 1 for Rock, 2 for Paper, " +
                "3 for Scissors, 4 for Lizard, or 5 for Spock: ";
            currentSelection = Convert.ToInt32(UserInterface.pickWholeNumberOneThrough(5, message, false) - 1);
            return currentSelection;
        }
    }
}
