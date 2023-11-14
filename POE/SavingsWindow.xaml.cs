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
    /// Interaction logic for SavingsWindow.xaml
    /// </summary>
    public partial class SavingsWindow : Window
    {
        Budget budget = new Budget();
        bool isSavings = true;
        char space = ';';
        string writeToFile;
        bool isValid = false;
        public SavingsWindow()
        {
            InitializeComponent();
        }

        private void CheckBoxSavings_Checked(object sender, RoutedEventArgs e)
        {
            budget.IsSavings = true;
            LabelSavings.Visibility = Visibility.Visible;
            TextBoxFinalAmountSavings.Visibility = Visibility.Visible;
            LabelInterestSavings.Visibility = Visibility.Visible;
            TextBoxInterestSavings.Visibility = Visibility.Visible;
            LabelYearsSavings.Visibility = Visibility.Visible;
            TextBoxYearsSavings.Visibility = Visibility.Visible;
            ButtonSaveSavings.Visibility = Visibility.Visible;
            isValid = true;
        }

        private void CheckBoxSavings_Unchecked(object sender, RoutedEventArgs e)
        {
            budget.IsSavings = false;
            LabelSavings.Visibility = Visibility.Collapsed;
            TextBoxFinalAmountSavings.Visibility = Visibility.Collapsed;
            LabelInterestSavings.Visibility = Visibility.Collapsed;
            TextBoxInterestSavings.Visibility = Visibility.Collapsed;
            LabelYearsSavings.Visibility = Visibility.Collapsed;
            TextBoxYearsSavings.Visibility = Visibility.Collapsed;
            ButtonSaveSavings.Visibility = Visibility.Collapsed;
            isValid = false;
        }

        private void ButtonSaveSavings_Click(object sender, RoutedEventArgs e)
        {
            CheckSavings();
            if(isSavings)
            {
                if(isValid)
                {
                    try
                    {
                        // this streamwriter is used to send the values to the text file 
                        using (StreamWriter writer = new StreamWriter("Userdata.txt", true))
                    {
                         writer.WriteLine($"{writeToFile}");
                    }
                        MessageBox.Show("Your savings information has been saved", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
            
        }

        public void CheckSavings()
        {
            try
            {
                if (isSavings)
                {
                    CheckInfo();
                    if(isValid)
                    {
                        double i = Double.Parse(TextBoxInterestSavings.Text.Trim().ToString());
                        int f = Int32.Parse(TextBoxFinalAmountSavings.Text.Trim().ToString());
                        int y = Int32.Parse(TextBoxYearsSavings.Text.Trim().ToString());
                        writeToFile = $"6;{f}{space}{i}{space}{y}{space}";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // this method will check if the text boxes are not empty and if they are, it will send a warning to the user to make sure
        // that they enter the values
        public void CheckInfo()
        {

            if (!TextBoxInterestSavings.Text.Trim().Equals("") && !TextBoxFinalAmountSavings.Text.Trim().Equals("") &&
                        !TextBoxYearsSavings.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
        }


        private void Next(object sender, RoutedEventArgs e)
        {
            CalculateWindow win5 = new CalculateWindow();
            win5.Show();
            this.Hide();

        }


    }
}
