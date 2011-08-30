using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace paySlips
{
    /// <summary>
    /// Interaction logic for paySlipsResponse.xaml
    /// </summary>
    public partial class paySlipsResponse : Page
    {
        
        int responsibilityResult;
        public paySlipsResponse()
        {
            InitializeComponent();
        }

       

        private void nextTax_Click(object sender, RoutedEventArgs e)
        {
            paySlipsTax tax = new paySlipsTax();
            this.NavigationService.Navigate(tax);
        }

        private void response50_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton res50 = (RadioButton)response50;
            responsibilityResult = int.Parse((string)res50.Content);
            globals.response = responsibilityResult;
            nextTax.IsEnabled = true;
            
        }

        private void response80_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton res80 = (RadioButton)response80;
            responsibilityResult = int.Parse((string)res80.Content);
            globals.response = responsibilityResult;
            nextTax.IsEnabled = true;
            
        }

        private void response100_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton res100 = (RadioButton)response100;
            responsibilityResult = int.Parse((string)res100.Content);
            globals.response = responsibilityResult;
            nextTax.IsEnabled = true;
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void uncheck50(object sender, RoutedEventArgs e)
        {
            nextTax.IsEnabled = false;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
                      
            nextTax.IsEnabled = true;
        }

        private void bonusLabel4_Checked(object sender, RoutedEventArgs e)
        {
            globals.response = 0;
            nextTax.IsEnabled = true;
        }

        
    }
}  
