using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace POE
{
    /// <summary>
    /// Interaction logic for CalculateWindow.xaml
    /// </summary>
    /// 
    public partial class CalculateWindow : Window
    {
        Budget budget = new Budget();
        static VehicleLoan vehicleLoan = new VehicleLoan();
        static Income income = new Income();
        static Tax tax = new Tax();
        static HomeLoan homeLoan = new HomeLoan();
        static Rent rent = new Rent();
        static Savings savings = new Savings();
        char space = ';';

        public CalculateWindow()
        {
            InitializeComponent();
            budget.AddMethod(new Budget.IncomeHandler(IncomeEvent));
        }

        // this is used to read from the text file that i have created called UserData.txt
        // it reads all the values that the user has inserted 
        private async void CalculateWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var sr = new StreamReader("Userdata.txt"))
                {
                    string input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        int position = input.IndexOf(space);
                        string optionString = input.Substring(0, position);
                        int optionNumber = Int16.Parse(optionString);
                        string values = input.Substring(position + 1, input.Length - position - 1);
                        switch (optionNumber)
                        {
                            case 1:
                                ReadIncome(values);
                                break;
                            case 2:
                                ReadExpenses(values);
                                budget.CheckTotalExpenses();
                                break;
                            case 3:
                                ReadRent(values);
                                budget.IsHomeLoan = false;
                                break;
                            case 4:
                                ReadHomeLoan(values);
                                budget.IsHomeLoan = true;
                                break;
                            case 5:
                                ReadVehicleLoan(values);
                                budget.IsVehicle = true;
                                break;
                            case 6:
                                ReadSavings(values);
                                budget.IsSavings = true;
                                break;
                        }
                    }

                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // this method is used to read the income values the user entered 
        private void ReadIncome(string values)
        {
            int position = values.IndexOf(';');
            double income = Double.Parse(values.Substring(0, position));
            double tax = Double.Parse(values.Substring(position + 1, values.Length - position - 1));
            budget.Income(income, tax);
        }

        // this method is used to read the rent value the user entered if they want to rent
        private void ReadRent(string values)
        {
            budget.RentInput(Int32.Parse(values));
        }

        // this method is used to read the expense values the user entered 
        private void ReadExpenses(string values)
        {
            int position = values.IndexOf(';');
            Dictionary<string, Expense> expenses = new Dictionary<string, Expense>();
            int count = 0;
            string temp = "";


            while (position > -1)
            {
                temp = values.Substring(0, position);
                count++;
                switch (count)
                {
                    case 1:
                        expenses.Add("Groceries expense", new Groceries { Value = Double.Parse(temp) });
                        break;
                    case 2:
                        expenses.Add("Water and Electricity expense", new WaterAndElectricity { Value = Double.Parse(temp) });
                        break;
                    case 3:
                        expenses.Add("Travel cost expense", new Travel { Value = Double.Parse(temp) });
                        break;
                    case 4:
                        expenses.Add("Cellphone expense", new CellPhone { Value = Double.Parse(temp) });
                        break;
                    case 5:
                        expenses.Add("Other expense", new Other { Value = Double.Parse(temp) });
                        break;

                }
                values = values.Substring(position + 1, values.Length - position - 1);
                position = values.IndexOf(';');
            }
            budget.ExpenseInput(expenses);
        }

        // this method is used to read the home loan values the user entered if they would like to purchase a property
        private void ReadHomeLoan(string values)
        {
            int position = values.IndexOf(';');
            int count = 0;
            string temp;
            int p = 0;
            double i = 0;
            int d = 0;
            double m = 0;

            while (position > -1)
            {
                temp = values.Substring(0, position);
                count++;
                switch (count)
                {
                    case 1:
                        p = Int32.Parse(temp);
                        break;
                    case 2:
                        d = Int32.Parse(temp);
                        break;
                    case 3:
                        i = Double.Parse(temp);
                        break;
                    case 4:
                        m = Int32.Parse(temp);
                        break;
                    default:
                        break;
                }
                values = values.Substring(position + 1, values.Length - position - 1);
                position = values.IndexOf(';');
            }
            budget.Property(p, i, d, m);
        }

        // this method is used to read the vehicle information the user entered if they would like to purchase a vehicle
        private void ReadVehicleLoan(string values)
        {
            int position = values.IndexOf(';');
            int count = 0;
            string temp;
            string m = " ";
            double p = 0;
            double i = 0;
            double d = 0;
            double insurance = 0;


            while (position > -1)
            {
                temp = values.Substring(0, position);
                count++;
                switch (count)
                {
                    case 1:
                        m = temp;
                        break;
                    case 2:
                        p = Double.Parse(temp);
                        break;
                    case 3:
                        i = Double.Parse(temp);
                        break;
                    case 4:
                        d = Double.Parse(temp);
                        break;
                    case 5:
                        insurance = Double.Parse(temp);
                        break;
                    default:
                        break;
                }
                values = values.Substring(position + 1, values.Length - position - 1);
                position = values.IndexOf(';');
            }
            budget.VehiclePayment(m, p, i, d, insurance);
        }

        // this method is used to read the savings values the user entered if they want to see the monthly
        // amount for a certain savings goal they would like to reach
        private void ReadSavings(string values)
        {
            int position = values.IndexOf(';');
            int count = 0;
            string temp;
            int f = 0;
            double i = 0;
            int y = 0;

            while (position > -1)
            {
                temp = values.Substring(0, position);
                count++;
                switch (count)
                {
                    case 1:
                        f = Int32.Parse(temp);
                        break;
                    case 2:
                        i = Double.Parse(temp);
                        break;
                    case 3:
                        y = Int32.Parse(temp);
                        break;
                    default:
                        break;
                }
                values = values.Substring(position + 1, values.Length - position - 1);
                position = values.IndexOf(';');
            }
            budget.SavingsPayment(i, f, y);
        }
        private void IncomeEvent(string message)
        {
            MessageBox.Show(message, "Alert! Your total expenses\n exceed 75% of your income.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // this event will exit the application once the user presses the exit application
        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            // this will set the text file to being empty, once the user exits the application
            File.WriteAllText("UserData.txt", string.Empty);
            Environment.Exit(0);
        }

        // this will call the following methods from the budget class to display the information 
        // on the calculate window in the richtextbox
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxDisplayInfo.AppendText(budget.CalculationHelper());
            RichTextBoxDisplayInfo.AppendText(budget.ToString());
        }
    }

}
