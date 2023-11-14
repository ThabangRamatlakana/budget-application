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
    /// Interaction logic for AccomodationWindow.xaml
    /// </summary>
    public partial class AccomodationWindow : Window
    {
        Budget budget = new Budget();
        double p;
        double d;
        double i;
        int m;
        double rent;
        char space = ';';
        bool isHomeLoan = false;
        string writeToFile;
        bool isValid = false;
        bool isComplete = true;
        public AccomodationWindow()
        {
            InitializeComponent();
        }

        private void RadioButtonRenting_Checked(object sender, RoutedEventArgs e)
        {
            LabelRent.Visibility = Visibility.Visible;
            TextBoxRent.Visibility = Visibility.Visible;

            LabelPrincipleHomeLoan.Visibility = Visibility.Collapsed;
            TextBoxPrincipleHomeLoan.Visibility = Visibility.Collapsed;
            LabelDepositHomeLoan.Visibility = Visibility.Collapsed;
            TextBoxDepositHomeLoan.Visibility = Visibility.Collapsed;
            LabelInterestHomeLoan.Visibility = Visibility.Collapsed;
            TextBoxInterestHomeLoan.Visibility = Visibility.Collapsed;
            LabelMonthsHomeLoan.Visibility = Visibility.Collapsed;
            TextBoxMonthsHomeLoan.Visibility = Visibility.Collapsed;
            isHomeLoan = false;
        }

        private void RadioButtonBuying_Checked(object sender, RoutedEventArgs e)
        {
            LabelPrincipleHomeLoan.Visibility = Visibility.Visible;
            TextBoxPrincipleHomeLoan.Visibility = Visibility.Visible;
            LabelDepositHomeLoan.Visibility = Visibility.Visible;
            TextBoxDepositHomeLoan.Visibility = Visibility.Visible;
            LabelInterestHomeLoan.Visibility = Visibility.Visible;
            TextBoxInterestHomeLoan.Visibility = Visibility.Visible;
            LabelMonthsHomeLoan.Visibility = Visibility.Visible;
            TextBoxMonthsHomeLoan.Visibility = Visibility.Visible;

            LabelRent.Visibility = Visibility.Collapsed;
            TextBoxRent.Visibility = Visibility.Collapsed;
            isHomeLoan = true;

        }
        private void ButtonSaveAccommodation_Click(object sender, RoutedEventArgs e)
        {
            checkHomeLoan();
            //CheckRentInfo();
            //CheckHomeLoanInfo();
            if (isValid)
            {
                try
                {
                    // this streamwriter is used to send the values to the text file 
                    using (StreamWriter writer = new StreamWriter("Userdata.txt", true))
                    {
                        writer.WriteLine($"{writeToFile}");
                    }
                    MessageBox.Show("Your accomodation information has been saved", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void checkHomeLoan()
        {
            try
            {
                if (!RadioButtonRenting.IsChecked.Value && !RadioButtonBuying.IsChecked.Value)
                {
                    MessageBox.Show("You must choose an accommodation option.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (isHomeLoan)
                {
                    CheckHomeLoanInfo();
                    if(isValid)
                    {
                        p = Double.Parse(TextBoxPrincipleHomeLoan.Text.Trim());
                        d = Double.Parse(TextBoxDepositHomeLoan.Text.Trim());
                        i = Double.Parse(TextBoxInterestHomeLoan.Text.Trim());
                        m = Int32.Parse(TextBoxMonthsHomeLoan.Text.Trim());
                        writeToFile = $"4;{p}{space}{d}{space}{i}{space}{m}{space}";
                    }
                   
                }
                else
                {
                    CheckRentInfo();
                    if(isValid)
                    {
                       rent = Double.Parse(TextBoxRent.Text.Trim());
                       writeToFile = $"3;{rent}";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // this method will check if the text boxes for home loanare not empty and if they are, it will send a warning to the user to
        // make sure
        // that they enter the values
        public void CheckHomeLoanInfo()
        {
            if (!TextBoxPrincipleHomeLoan.Text.Trim().Equals("") && !TextBoxDepositHomeLoan.Text.Trim().Equals("") &&
                        !TextBoxInterestHomeLoan.Text.Trim().Equals("") && !TextBoxMonthsHomeLoan.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
        }

        // this method will check if the text box for rent is not empty and if they are, it will send a warning to the user to make sure
        // that they enter the value
        public void CheckRentInfo()
        {

            if (!TextBoxRent.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
        }

        private void NextAccomodation(object sender, RoutedEventArgs e)
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

        public void CheckForInfoButton()
        {
            if (!RadioButtonRenting.IsChecked.Value && !RadioButtonBuying.IsChecked.Value)
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isComplete = true;
            }

            else
            {
                isComplete = false;
                VehicleWindow win3 = new VehicleWindow();
                win3.Show();
                this.Close();
            }
        }
    }
}
