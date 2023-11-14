using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Other : Expense
    {
        public Other()
        {

        }
        public override string ToString()
        {
            return $"Other Expenses: R{Value}";
        }
    }
}
