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
    /// Interaction logic for ExpenseWindow.xaml
    /// </summary>
    public partial class ExpenseWindow : Window
    {
        Budget budget = new Budget();
        Dictionary<string, Expense> expenses = new Dictionary<string, Expense>();
        bool isValid = false;
        bool isComplete = true;
        public ExpenseWindow()
        {
            InitializeComponent();
        }
        private void ButtonSaveExpenses_Click(object sender, RoutedEventArgs e)
        {
            CheckInfo();
            if (isValid)
            {
               
                try
                {
                    GetInputFromComponents();
                    WriteToFile();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Invalid amounts, Please try again", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void GetInputFromComponents()
        {
            expenses = new Dictionary<string, Expense>();
            expenses.Add("Groceries", new Groceries { Value = Double.Parse(TextBoxGroceries.Text.Trim().ToString()) });
            expenses.Add("Water and Electricity", new WaterAndElectricity { Value = Double.Parse(TextBoxWaterAndElectricity.Text.Trim().ToString()) }); ;
            expenses.Add("Travel Costs", new Travel { Value = Double.Parse(TextBoxTravel.Text.Trim().ToString()) });
            expenses.Add("Cellphone and Telephone", new CellPhone { Value = Double.Parse(TextBoxCellphone.Text.Trim().ToString()) });
            expenses.Add("Miscellaneous Costs", new Other { Value = Double.Parse(TextBoxOther.Text.Trim().ToString()) });
        }

        private void WriteToFile()
        {
            char space = ';';
            try
            {
                // this streamwriter is used to send the values to the text file 
                using (StreamWriter writer = new StreamWriter("Userdata.txt", true))
                {
                    writer.WriteLine($"2{space}{expenses["Groceries"].Value}{space}" +
                        $"{expenses["Water and Electricity"].Value}{space}" +
                        $"{expenses["Travel Costs"].Value}{space}" +
                        $"{expenses["Cellphone and Telephone"].Value}{space}" +
                        $"{expenses["Miscellaneous Costs"].Value}{space}");
                }
                MessageBox.Show("Your expense information has been saved", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CheckInfo()
        {
            if (!TextBoxGroceries.Text.Trim().Equals("") && !TextBoxWaterAndElectricity.Text.Trim().Equals("") && 
                !TextBoxTravel.Text.Trim().Equals("") && !TextBoxCellphone.Text.Trim().Equals("") &&
                !TextBoxOther.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
        }
        private void NextExpense(object sender, RoutedEventArgs e)
        {
            if (isComplete)
            {
                CheckForInfoButton();
            }
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // this method will check if the text boxes are not empty and if they are, it will send a warning to the user to make sure
        // that they enter the values
        public void CheckForInfoButton()
        {
            if (!TextBoxGroceries.Text.Trim().Equals("") && !TextBoxWaterAndElectricity.Text.Trim().Equals("") &&
                !TextBoxTravel.Text.Trim().Equals("") && !TextBoxCellphone.Text.Trim().Equals("") &&
                !TextBoxOther.Text.Trim().Equals(""))
            {
                isComplete = false;
                AccomodationWindow win3 = new AccomodationWindow();
                win3.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isComplete = true;
            }
        }
    }
}
