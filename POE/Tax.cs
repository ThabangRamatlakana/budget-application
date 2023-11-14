using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Tax : Expense
    {
        public double Value1 { get; set; }
        public override string ToString()
        {
            return $"Estimated Tax Deduction: R{Value1}";
        }
    }
}
