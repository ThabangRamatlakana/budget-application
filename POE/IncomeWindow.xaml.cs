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
    /// Interaction logic for Income.xaml
    /// </summary>
    public partial class IncomeWindow : Window
    {
        Budget budget = new Budget();

        double income;
        double tax;

        bool isValid = false;
        bool isComplete = true;
        public IncomeWindow()
        {
            InitializeComponent();
        }

        private void ButtonSaveIncome_Click(object sender, RoutedEventArgs e)
        {
            CheckInfo();
            if(isValid)
            {
                char space = ';';
            try
            {
                income = Double.Parse(TextBoxIncome.Text.Trim());
                tax = Double.Parse(TextBoxTax.Text.Trim());

                    // this streamwriter is used to send the values to the text file 
                    using (StreamWriter outputFile = new StreamWriter("Userdata.txt", true))
                {
                    outputFile.WriteLine($"1{space}{income}{space}{tax}");
                }
                MessageBox.Show("Your income information was successfully saved", "Message", MessageBoxButton.OK,
                            MessageBoxImage.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }
  
        }

        private void NextIncome(object sender, RoutedEventArgs e)
        {
            if(isComplete)
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
        public void CheckInfo()
        {
            if (!TextBoxIncome.Text.Trim().Equals("") && !TextBoxTax.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                 isValid = false;
            }
        }

        public void CheckForInfoButton()
        {
            if (!TextBoxIncome.Text.Trim().Equals("") && !TextBoxTax.Text.Trim().Equals(""))
            {
                isComplete = false;
                ExpenseWindow win2 = new ExpenseWindow();
                win2.Show();
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
