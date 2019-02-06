using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class CustomerTightwadOrGenerous : Customer
    {
        public bool isTightWad = false;
        public bool isGenerous = false;
        public int predispositionToBuy = 0;

        public CustomerTightwadOrGenerous(bool isTightWad = false, bool isGenerous = false)
        {
            this.isTightWad = isTightWad;
            this.isGenerous = isGenerous;
            if (isTightWad)
            {
                predispositionToBuy--;
            }
            else if (isGenerous)
            {
                predispositionToBuy++;
            }
        }
    }
}