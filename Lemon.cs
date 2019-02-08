using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Lemon : Item
    {
        public Lemon(string name = "lemon", int quantity = 1)
            :base(name, quantity)
        {
        }
    }
}