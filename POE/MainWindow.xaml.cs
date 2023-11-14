using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Budget budget = new Budget();
        //static VehicleLoan vehicleLoan = new VehicleLoan();
        //static Income income = new Income();
        //static Tax tax = new Tax();
        //static HomeLoan homeLoan = new HomeLoan();
        //static Rent rent = new Rent();
        //static Savings savings = new Savings();
        //char space = ';';
        public MainWindow()
        {
            InitializeComponent();
            //budget.AddMethod(new Budget.IncomeHandler(IncomeEvent));
        }

        //private async void WindowMainMenu_Loaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        using (var sr = new StreamReader("Userdata.txt"))
        //        {
        //            string input = await sr.ReadToEndAsync();
        //            if (input.Length != 0)
        //            {
        //                int position = input.IndexOf(space);
        //                string optionString = input.Substring(0, position);
        //                int optionNumber = Int16.Parse(optionString);
        //                string values = input.Substring(position + 1, input.Length - position - 1);
        //                switch (optionNumber)
        //                {
        //                    case 1:
        //                        ReadIncome(values);
        //                        break;
        //                    case 2:
        //                        ReadExpenses(values);
        //                        budget.CheckTotalExpenses();
        //                        break;
        //                    case 3:
        //                        ReadRent(values);
        //                        break;
        //                    case 4:
        //                        ReadHomeLoan(values);
        //                        break;
        //                    case 5:
        //                        ReadVehicleLoan(values);
        //                        break;
        //                    case 6:
        //                        ReadSavings(values);
        //                        break;
        //                }
        //            }

        //        }
        //    }
        //    catch (FileNotFoundException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //private void ReadIncome(string values)
        //{
        //    int position = values.IndexOf(';');
        //    double income = Double.Parse(values.Substring(0, position));
        //    double tax = Double.Parse(values.Substring(position + 1, values.Length - position - 1));
        //    budget.Income(income, tax);
        //}

        //private void ReadRent(string values)
        //{
        //    budget.RentInput(Int32.Parse(values));
        //}

        //private void ReadExpenses(string values)
        //{
        //    int position = values.IndexOf(';');
        //    Dictionary<string, Expense> expenses = new Dictionary<string, Expense>();
        //    int count = 0;
        //    string temp = "";


        //    while (position > -1)
        //    {
        //        temp = values.Substring(0, position);
        //        count++;
        //        switch (count)
        //        {
        //            case 1:
        //                expenses.Add("Groceries expense", new Groceries { Value = Double.Parse(temp) });
        //                break;
        //            case 2:
        //                expenses.Add("Water and Electricity expense", new WaterAndElectricity { Value = Double.Parse(temp) });
        //                break;
        //            case 3:
        //                expenses.Add("Travel cost expense", new Travel { Value = Double.Parse(temp) });
        //                break;
        //            case 4:
        //                expenses.Add("Cellphone expense", new CellPhone { Value = Double.Parse(temp) });
        //                break;
        //            case 5:
        //                expenses.Add("Other expense", new Other { Value = Double.Parse(temp) });
        //                break;
                       
        //        }
        //        values = values.Substring(position + 1, values.Length - position - 1);
        //        position = values.IndexOf(';');
        //    }
        //    budget.ExpenseInput(expenses);
        //}

        //private void ReadHomeLoan(string values)
        //{
        //    int position = values.IndexOf(';');
        //    int count = 0;
        //    string temp;
        //    int p = 0;
        //    double i = 0;
        //    int d = 0;
        //    double m = 0;

        //    while (position > -1)
        //    {
        //        temp = values.Substring(0, position);
        //        count++;
        //        switch (count)
        //        {
        //            case 1:
        //                p = Int32.Parse(temp);
        //                break;
        //            case 2:
        //                d = Int32.Parse(temp);
        //                break;
        //            case 3:
        //                i = Double.Parse(temp);
        //                break;
        //            case 4:
        //                m = Int32.Parse(temp);
        //                break;
        //            default:
        //                break;
        //        }
        //        values = values.Substring(position + 1, values.Length - position - 1);
        //        position = values.IndexOf(';');
        //    }
        //    budget.Property(p, i, d, m);
        //}

        //private void ReadVehicleLoan(string values)
        //{
        //    int position = values.IndexOf(';');
        //    int count = 0;
        //    string temp;
        //    string m = " ";
        //    double p = 0;
        //    double i = 0;
        //    double d = 0;
        //    double insurance = 0;
            

        //    while (position > -1)
        //    {
        //        temp = values.Substring(0, position);
        //        count++;
        //        switch (count)
        //        {
        //            case 1:
        //                m = temp;
        //                break;
        //            case 2:
        //                p = Double.Parse(temp);
        //                break;
        //            case 3:
        //                i = Double.Parse(temp);
        //                break;
        //            case 4:
        //                d = Double.Parse(temp);
        //                break;
        //            default:
        //                break;
        //        }
        //        values = values.Substring(position + 1, values.Length - position - 1);
        //        position = values.IndexOf(';');
        //    }
        //    budget.VehiclePayment(m, p, i, d, insurance);
        //}

        //private void ReadSavings(string values)
        //{
        //    int position = values.IndexOf(';');
        //    int count = 0;
        //    string temp;
        //    int f = 0;
        //    double i = 0;
        //    int y = 0;
            
        //    while (position > -1)
        //    {
        //        temp = values.Substring(0, position);
        //        count++;
        //        switch (count)
        //        {
        //            case 1:
        //                i = Double.Parse(temp);
        //                break;
        //            case 3:
        //                f = Int32.Parse(temp);
        //                break;
        //            case 4:
        //                y = Int32.Parse(temp);
        //                break;
        //            default:
        //                break;
        //        }
        //        values = values.Substring(position + 1, values.Length - position - 1);
        //        position = values.IndexOf(';');
        //    }
        //    budget.SavingsPayment(i, f, y);
        //}
        //private void IncomeEvent(string message)
        //{
        //    MessageBox.Show(message, "Alert! Your total expenses\n exceed 75% of your income.", MessageBoxButton.OK, MessageBoxImage.Warning);
        //}
        private void StartApplication(object sender, RoutedEventArgs e)
        {
            var win1 = new IncomeWindow();
            win1.Show();
            this.Hide();
        }

        
    }
}
