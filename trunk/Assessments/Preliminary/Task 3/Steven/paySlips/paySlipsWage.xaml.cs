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
    /// Interaction logic for paySlipsWage.xaml
    /// </summary>
    public partial class paySlipsWage : Page
    {
        int result;
        
        public paySlipsWage()
        {
            InitializeComponent();

            
        }

        

        private void nextButton1_Click(object sender, RoutedEventArgs e)
        {
            overTimePublic over = new overTimePublic();
            this.NavigationService.Navigate(over);
        }

        private void wage10_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton wage1 = (RadioButton)wage10;
            result = int.Parse((string)wage1.Content);
            globals.wage = result;
            wageHoursBox.IsEnabled = true;
            hoursSubmit.IsEnabled = true;
            
        }

        private void wage15_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton wage2 = (RadioButton)wage15;
            result = int.Parse((string)wage2.Content);
            globals.wage = result;
            wageHoursBox.IsEnabled = true;
            hoursSubmit.IsEnabled = true;
        }

        private void wage20_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton wage3 = (RadioButton)wage20;
            result = int.Parse((string)wage3.Content);
            globals.wage = result;
            wageHoursBox.IsEnabled = true;
            hoursSubmit.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void hoursSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isHour;
            int i;
            string hours;
            hours = wageHoursBox.Text;

            isHour = int.TryParse(hours, out i);

            if (isHour == true && i != 0 && i <=50)
            {

                
                TextBox wageHour = (TextBox)wageHoursBox;
                result = int.Parse((string)wageHour.Text);
                globals.wageHours = result;
                correctEnter.Visibility = System.Windows.Visibility.Visible;
                nextOver.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("The value entered is not valid");
            }
        }

        

        

        

        
    }
}
