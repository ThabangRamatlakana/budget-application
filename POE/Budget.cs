using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace POE
{
    class Budget
    {
        // here I instantiate objects of the classes that I created so that I can use the classes here in this class
        static VehicleLoan vehicleLoan = new VehicleLoan();
        static Income income = new Income();
        static Tax tax = new Tax();
        static HomeLoan homeLoan = new HomeLoan();
        static Rent rent = new Rent();
        static Savings savings = new Savings();
        
        // The generic collection that I used is a dictionary to store the expenses
        static Dictionary<string, Expense> dictExpenses = new Dictionary<string, Expense>();

        public bool IsOver75 { get; set; }

        //Troelsen and Japikse (2021, page 59) used an example for delegates using a car that is accelerating
        // a delegate is defined
        public delegate void IncomeHandler(string message);
        // a member variable of the delegate is defined
        private IncomeHandler incomeHandler;

        public void AddMethod(IncomeHandler methodToCall)
        {
            incomeHandler = methodToCall;
        }

        public void CheckTotalExpenses()
        {
            double newIncome = income.Value * 0.75;
            if (GetExpensesAndLoansTotal() > newIncome)
                IsOver75 = true;

            if (IsOver75)
                incomeHandler?.Invoke("You total expenses is larger than 75 % of your income! ");
        }

        public bool IsHomeLoan { get; set; }
        public bool IsVehicle { get; set; }
        public bool IsSavings { get; set; }
        private double GetExpensesAndLoansTotal()
        {
            double result = GetTotalExpenses();
            if (IsHomeLoan)
                result += homeLoan.Value; 

            if (IsVehicle)
                result += vehicleLoan.Value;

            return result;
        }

        
        public double NetIncome { get; set; }

        private void SetNetIncome()
        {
            NetIncome = income.Value - GetTotalExpenses();

            if (IsHomeLoan)
                NetIncome -= homeLoan.Value; //monthly payment amount

            if (IsVehicle)
                NetIncome -= vehicleLoan.Value; //monthly payment amount
        }

        private void VehicleLoanCalculation()
        {
            vehicleLoan.SetVehiclePay();
            vehicleLoan.SetTotalVehExpense();
        }

        private void MonthlySavingsCalcluation()
        {
            savings.SetPrinciple();
            savings.SetMontlhySavingsAmount();
        }

        public string CalculationHelper()
        {
            StringBuilder result = new StringBuilder("");
            if (IsHomeLoan)
            result.Append(HomeLoanCalculation());

            if (IsVehicle)
                VehicleLoanCalculation();

            if (IsSavings)
            {
                MonthlySavingsCalcluation();
            }

            CheckTotalExpenses();
            SetNetIncome();
            return result.ToString();


        }

        public override string ToString()
        {
            // Microsoft Docs(2022) has a guideline that says cooncatination of strings in loops should be done using a string builder 
            StringBuilder result = new StringBuilder();
            result.Append("*** YOUR INCOME IS AS FOLLOWS: ***\n");
            result.Append(income.ToString() + "\n");
            result.Append(tax.ToString() + "\n\n");
            result.Append(DisplayExpenses() + "\n");
            if (IsHomeLoan)
                result.Append(homeLoan.ToString() + "\n");
            if (IsVehicle)
                result.Append(vehicleLoan.ToString() + "\n");
            if (IsSavings)
                result.Append(savings.ToString() + "\n");
            result.Append("*** YOUR NET INCOME IS AS FOLLOWS: ***\n");
            result.Append($"Your net income after all deductions is R{Math.Round(NetIncome)}");
            return result.ToString();
        }

        public void Income(double GUIincome, double GUItax)
        {
            income.Value = GUIincome;
            tax.Value1 = GUItax;
        }
       

        public void RentInput(double GUIrent)
        {
            rent.Value = GUIrent;
        }

        public void Property(int GUIpurchase, double GUIinterest, int GUIdeposit, double GUImonths)
        {
            homeLoan.PurchasePrice = GUIpurchase;
             homeLoan.PurchasePrice -= GUIdeposit;
            homeLoan.Interest = GUIinterest;
            homeLoan.Months = GUImonths;
        }

        public void SavingsPayment(double GUIint, int GUIfinal, int GUIyears)
        {
            savings.Interest = GUIint;
            savings.Years = GUIyears;
            savings.FinalAmount = GUIfinal;
        }

        public  void VehiclePayment(string GUImodel, double GUIp, double GUIi, double GUIdep, double GUIinsurance)
        {

            vehicleLoan.Model = GUImodel;
            vehicleLoan.PurchasePrice = GUIp;
            vehicleLoan.Deposit = GUIdep;
            vehicleLoan.InterestRate = GUIi;
            vehicleLoan.InsurancePremium = GUIinsurance;
            vehicleLoan.SetVehiclePay();
        }

        public void ExpenseInput(Dictionary<String, Expense> expenses)
        {
            dictExpenses = expenses;
        }

        private void ExpenseInput(Groceries groceries, WaterAndElectricity waterAndElectricity, Travel travel, CellPhone cell, Other other)
        {
           dictExpenses.Add("Groceries", groceries);
           dictExpenses.Add("Water and Electricity", waterAndElectricity);
           dictExpenses.Add("Travel Costs", travel);
           dictExpenses.Add("Cellphone and Telephone expenses", cell);
           dictExpenses.Add("Other expenses", other);
        }


        // this method will get the expenses and display it
        public string DisplayExpenses()
        {
            // using a linq it will display the expenses that were stored in a dictionery in descending value.
            var sortedExpenses = from exp in dictExpenses
                                 orderby exp.Value.Value descending
                                 select exp;
            StringBuilder result = new StringBuilder();
            result.Append("*** YOUR EXPENSES ARE AS FOLLOWS: ***\n");
            foreach (var item in sortedExpenses)
                result.Append(item.Value + "\n");
            if (!IsHomeLoan)
                result.Append(rent.ToString() + "\n");
            return result.ToString();
        }

        // this method will get the expenses and calculate the total expenses
        private double GetTotalExpenses()
        {
            double total = 0;
            total += tax.Value1;
            foreach (var item in dictExpenses)
                total += item.Value.Value;
            if (!IsHomeLoan)
                total += rent.Value;
            return total;
        }
        // this is a target for the event
        public void IncomeEvent(string message)
        {
            Console.WriteLine($"Alert! {message}");
        }

        // this method is used to check if the number of months that the user inserted is between 240 and 360
        // it will then also check if the user is eligible for a home loan or not
        private string HomeLoanCalculation()
        {
            homeLoan.GetAccumulatedAmount();
            homeLoan.SetFinalAmount();
            const double A_THIRD = 1.00 / 3;
            double tempIncome = income.Value;
            tempIncome *= A_THIRD;
            StringBuilder result = new StringBuilder("HOME LOAN ELIGIBILITY\n");

            if (homeLoan.IsValid())
            {
                result.Append($"Income: R {income.Value}\n");
                result.Append($"A third of income: R {tempIncome}\n");
                result.Append($"Monthly Repayment: R {homeLoan.Value}\n");
                if(homeLoan.Value > A_THIRD * income.Value)
                    result.Append("You are not eligible for a home loan.\n");
                else
                {
                  result.Append("You are eligible for a home loan.\n");
                }
                    
            }
            else
            {
              result.Append("You entered an invalid number of months.\n");
            }
            return result.ToString();
        }


    }
}
