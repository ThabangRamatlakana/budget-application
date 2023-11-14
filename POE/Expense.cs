using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    // here i create an abstract class called Expenses that  other classes will inherit from. 
    public abstract class Expense
    {

        // default constructor of the Expense
        public Expense()
        {

        }
        protected double value;
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public double TotalExpenses { get; set; }

        public override abstract string ToString();
    }

}
