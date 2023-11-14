using System;
using System.Collections.Generic;
using System.Text;

namespace POE
{
    class VehicleLoan : Expense
    {
        public VehicleLoan()
        {
            Years = 5;
        }

        public VehicleLoan(string model, double purchaseAmount, double deposit, double interestRate, double premium)
        {
            this.model = model;
            this.purchasePR = purchaseAmount;
            this.deposit = deposit;
            this.interest = interestRate;
            this.premium = premium;
        }

        public bool _IsVehicle
        {
            get { return _IsVehicle; }
            set { _IsVehicle = value; }
        }
        
       
        private string  model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double purchasePR;

        public double PurchasePrice
        {
            get { return purchasePR; }
            set { purchasePR = value; }
        }

        private double deposit;

        public double Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }

        private double interest;

        public double InterestRate
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

        private double years;

        public double Years
        {
            get { return years; }
            set { years = 5; }
        }


        public double FinalAmount { get; set; }

        private double premium;

        public double InsurancePremium
        {
            get { return premium; }
            set { premium = value; }
        }


        // this method with calculate the final amount by taking the purchase price and multiplying it by 1 plus interest rate times the 
        // number of years wich is 5. That answer will now be the final amount 
        public void SetVehiclePay()
        {
            FinalAmount = (PurchasePrice - Deposit) * (1 + InterestRate * 5);
        }

        // this method will take the final amount and divide it by the 5 years and multiply it by 12 and add the insurance premium
        public double GetTotalVehicleExpense()
        {
            return FinalAmount/ (Years *12 ) + InsurancePremium;
        }

        public double FinalVehichleExpense { get; set; }

        public override string ToString()
        {
            return $" *** YOUR VEHICLE LOAN INFORMATION IS AS FOLLOWS: ***\n" +
                $"Vehicle model: {Model} \n" + $"Vehicle purchase price: R{purchasePR} \n" + $"Vehicle deposit: R{deposit} \n" +
                $"Vehicle interest: {InterestRate} \n" + $"Vehicle insurance premium: R{InsurancePremium} \n" +
                $"Accumulated Vehicle Loan Amount after 5 years: R{Math.Round(FinalAmount, 2)}\n" +
                  $"Monthly Vehicle Repayment Amount: R{Math.Round(Value, 2)}\n";
        }

        public void SetTotalVehExpense()
        {
            Value = FinalAmount / (Years * 12) + InsurancePremium;
        }





    }
}
