using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Travel : Expense
    {
        public Travel()
        {

        }
        public override string ToString()
        {
            return $"Travel Costs: R{Value}";
        }
    }
}
