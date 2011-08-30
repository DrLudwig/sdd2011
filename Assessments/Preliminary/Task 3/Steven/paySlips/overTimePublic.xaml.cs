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
    /// Interaction logic for overTimePublic.xaml
    /// </summary>
    public partial class overTimePublic : Page
    {
       
        
        public overTimePublic()
        {
            InitializeComponent();
            
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            listBoxOvertime.IsEnabled = true;
        }

        private void uncheckList(object sender, RoutedEventArgs e)
        {
            listBoxOvertime.IsEnabled = false;

            publicHourEnter.IsEnabled = false;
            submitHours.IsEnabled = false;
        }

        private void nextResponse_Click(object sender, RoutedEventArgs e)
        {
            paySlipsResponse response = new paySlipsResponse();
            this.NavigationService.Navigate(response);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem overtime = (ListBoxItem)over1;
            globals.overtime = int.Parse((string)overtime.Content);
            publicHourEnter.IsEnabled = true;
            submitHours.IsEnabled = true;
            
        }

        

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ListBoxItem overtime = (ListBoxItem)over2;
            globals.overtime = int.Parse((string)overtime.Content);
            publicHourEnter.IsEnabled = true;
            submitHours.IsEnabled = true;
             
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ListBoxItem overtime = (ListBoxItem)over3;
            globals.overtime = int.Parse((string)overtime.Content);
            publicHourEnter.IsEnabled = true;
            submitHours.IsEnabled = true;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        

        private void none1_Checked(object sender, RoutedEventArgs e)
        {
            overtimeCheck.IsEnabled = false;
            listBoxOvertime.IsEnabled = false;
            publicHourEnter.IsEnabled = true;
            submitHours.IsEnabled = true;
        }

        private void uncheckNone(object sender, RoutedEventArgs e)
        {
            overtimeCheck.IsEnabled = true;
            listBoxOvertime.IsEnabled = false;
            publicHourEnter.IsEnabled = false;
            submitHours.IsEnabled = false;
            
        }

        private void submitHours_Click(object sender, RoutedEventArgs e)
        {
            bool isHour;
            int i;
            string hours;
            hours = publicHourEnter.Text;
            int result;
            isHour = int.TryParse(hours, out i);

            if (isHour == true && i <=50)
            {
                TextBox publicHour = (TextBox)publicHourEnter;
                result = int.Parse((string)publicHour.Text);
                globals.publicHoliday = result;
                correctEnter.Visibility = System.Windows.Visibility.Visible;
                nextResponse.IsEnabled = true;
               

            }
            else
            {
                MessageBox.Show("The value is not valid");
            }
        }

        

        

        

       

        
    }
}
