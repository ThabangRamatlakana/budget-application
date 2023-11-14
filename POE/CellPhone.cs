using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class CellPhone : Expense
    {
        public CellPhone()
        {

        }
        public override string ToString()
        {
            return $"Cellphone and Telephone Costs: R{Value}";
        }
    }
}
