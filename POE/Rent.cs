using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Rent : Expense
    {
        public Rent()
        {

        }
        public override string ToString()
        {
            return $"*** RENT ***\n Monthly Rental Amount is: R{Value}";
        }
    }
}
