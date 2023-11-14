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
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {
        Budget budget = new Budget();
        bool isVehicle = true;
        char space = ';';
        string writeToFile;
        bool isValid = false;

        public VehicleWindow()
        {
            InitializeComponent();
        }

        private void CheckBoxVehicle_Checked(object sender, RoutedEventArgs e)
        {
            budget.IsVehicle = true;
            LabelModelAndMakeVehicleLoan.Visibility = Visibility.Visible;
            TextBoxModelAndMakeVehicleLoan.Visibility = Visibility.Visible;
            LabelPrincipleVehicleLoan.Visibility = Visibility.Visible;
            TextBoxPrincipleVehicleLoan.Visibility = Visibility.Visible;
            LabelDepositVehicleLoan.Visibility = Visibility.Visible;
            TextBoxDepositVehicleLoan.Visibility = Visibility.Visible;
            LabelInterestVehicleLoan.Visibility = Visibility.Visible;
            TextBoxInterestVehicleLoan.Visibility = Visibility.Visible;
            LabelInsuranceVehicleLoan.Visibility = Visibility.Visible;
            TextBoxInsuranceVehicleLoan.Visibility = Visibility.Visible;
            ButtonSaveVehicleLoan.Visibility = Visibility.Visible;
            isValid = true;
        }

        private void CheckBoxVehicle_Unchecked(object sender, RoutedEventArgs e)
        {
            budget.IsVehicle = false;
            LabelModelAndMakeVehicleLoan.Visibility = Visibility.Collapsed;
            TextBoxModelAndMakeVehicleLoan.Visibility = Visibility.Collapsed;
            LabelPrincipleVehicleLoan.Visibility = Visibility.Collapsed;
            TextBoxPrincipleVehicleLoan.Visibility = Visibility.Collapsed;
            LabelDepositVehicleLoan.Visibility = Visibility.Collapsed;
            TextBoxDepositVehicleLoan.Visibility = Visibility.Collapsed;
            LabelInterestVehicleLoan.Visibility = Visibility.Collapsed;
            TextBoxInterestVehicleLoan.Visibility = Visibility.Collapsed;
            LabelInsuranceVehicleLoan.Visibility = Visibility.Collapsed;
            TextBoxInsuranceVehicleLoan.Visibility = Visibility.Collapsed;
            ButtonSaveVehicleLoan.Visibility = Visibility.Collapsed;
            isValid = false;
        }

        private void ButtonSaveVehicleLoan_Click(object sender, RoutedEventArgs e)
        {
            CheckVehicleLoan();
            //CheckInfo();
            if(isValid)
            {
                try
                {
                    // this streamwriter is used to send the values to the text file 
                    using (StreamWriter writer = new StreamWriter("Userdata.txt", true))
                    {
                        writer.WriteLine($"{writeToFile}");
                    }
                    MessageBox.Show("Your vehicle information has been saved", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }   
            
        }

        public void CheckVehicleLoan()
        {
            try
            {
                if (isVehicle)
                {
                    CheckInfo();
                    if (isValid)
                    {
                      string m = TextBoxModelAndMakeVehicleLoan.Text.Trim().ToString();
                      double p = Double.Parse(TextBoxPrincipleVehicleLoan.Text.Trim().ToString());
                      double i = Double.Parse(TextBoxInterestVehicleLoan.Text.Trim().ToString());
                      double d = Double.Parse(TextBoxDepositVehicleLoan.Text.Trim().ToString());
                      double insurance = Double.Parse(TextBoxInsuranceVehicleLoan.Text.Trim().ToString());
                      writeToFile = $"5;{m}{space}{p}{space}{i}{space}{d}{space}{insurance}{space}";
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

            if (!TextBoxPrincipleVehicleLoan.Text.Trim().Equals("") && !TextBoxModelAndMakeVehicleLoan.Text.Trim().Equals("") &&
                !TextBoxInterestVehicleLoan.Text.Trim().Equals("") && !TextBoxDepositVehicleLoan.Text.Trim().Equals("") &&
                !TextBoxInsuranceVehicleLoan.Text.Trim().Equals(""))
                isValid = true;
            else
            {
                MessageBox.Show("Please enter all information required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
        }

        //this event will allw the user to move from the vehicle window to the savings window once they press the next button
        private void NextVehicle(object sender, RoutedEventArgs e)
        {
            SavingsWindow win4 = new SavingsWindow();
            win4.Show();
            this.Hide();
        }
    }
}
