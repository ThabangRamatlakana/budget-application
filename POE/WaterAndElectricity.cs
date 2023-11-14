using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class WaterAndElectricity : Expense
    {
        public WaterAndElectricity()
        {

        }
        public override string ToString()
        {
            return $"Water and Electricity Amount: R{Value}";
        }
    }
}
