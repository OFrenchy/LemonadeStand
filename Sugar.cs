using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Sugar : Item
    {
        public Sugar(string name = "sugar", int quantity = 1)
            :base(name, quantity)
        {
        }
    }
}