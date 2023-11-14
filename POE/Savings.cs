using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    
    public class Savings
    {
        //Value is the Monthly Saving Amount
        public double MonthlySavingsAmount { get; set; }

        private const int CONSTANT = 1;
        private const int MULTIPLIER = 12;

       public double Principle { get; set; }

        private double interest;

        public double Interest
        {
            get { return interest; }
            set
            {
                if (value < 1)
                    interest = value;
                else
                    interest = value / 100;
            }
        }

        public int Years { get; set; }

        public double FinalAmount { get; set; }

        public Savings()
        {

        }

        public void SetPrinciple()
        {
            Principle = FinalAmount / (CONSTANT + (Interest * Years));
        }

        public void SetMontlhySavingsAmount()
        {
            MonthlySavingsAmount = Principle / (Years * MULTIPLIER);
        }

        public override string ToString()
        {
            return $"*** SAVINGS ***\nYour Savings Goal is: R{FinalAmount} in {Years} years.\n And your Monthly Savings Amount is: R {Math.Round(MonthlySavingsAmount)}";
        }


    }
}
