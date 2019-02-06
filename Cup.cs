using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Cup : Item
    {
        public Cup(string name = "cup", int quantity = 1)
            :base(name, quantity)
        {

        }
    }
}