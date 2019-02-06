using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Ice : Item
    {
        public Ice(string name = "ice", int quantity = 1)
            :base(name, quantity)
        {

        }
    }
}