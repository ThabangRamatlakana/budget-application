using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class Income
    {
        public double Value { get; set; }

        public override string ToString()
        {
            string result = "";
            result += $"Your monthly income is: R{Value}";
            return result;
        }
    }
}
