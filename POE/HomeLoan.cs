using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    public class HomeLoan : Expense
    {
        private int income;

        public int Income
        {
            get { return income; }
            set { income = value; }
        }

        private double months;

        public double Months
        {
            get { return months; }
            set { months = value; }
        }

        private int tax;

        public int Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private int rent;

        public int Rent
        {
            get { return rent; }
            set { rent = value; }
        }

        private int purchasePrice;

        public int PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }



        public HomeLoan()
        {

        }

        public HomeLoan(int income, int tax,
           int rent, int purchasePrice, int interest, double months)
        {
            this.income = income;
            this.tax = tax;
            this.rent = rent;
            this.purchasePrice = purchasePrice;
            this.interest = interest;
            this.months = months;

        }

        private int years;

        public int Years
        {
            get { return years; }
            set { years = value; }
        }

        private int P;

        public int price
        {
            get { return P; }
            set { P = value; }
        }

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

        public double FinalAmount { get; set; }

        public bool IsValid()
        {
            bool valid = false;
            if (Months >= 240 && Months <= 360)
                valid = true;
            return valid;

        }

        //public double Value { get; set; }
        public void GetAccumulatedAmount()
        {
            double n = Months / 12; //the n represents the years as per the simple interest calculation A = P(1 + i.n)

            FinalAmount = PurchasePrice * (1 + Interest * n);

        }

        public void SetFinalAmount()
        {
            Value = FinalAmount / Months;
        }

        public override string ToString()
        {
            return $" *** YOUR HOME LOAN INFORMATION IS AS FOLLOWS: ***\n" +
                $"Accumulated Home Loan Amount after {Math.Round(Months/12)} months is: R{Math.Round(FinalAmount, 2)}\n"+ 
                $"Monthly Home Loan Repayment Amount: R{Math.Round(Value, 2)}\n";
        }
    }
}
