using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Groceries : Expense
    {
        public override string ToString()
        {
            return $"Groceries Amount: R{Value}";
        }
    }
}
