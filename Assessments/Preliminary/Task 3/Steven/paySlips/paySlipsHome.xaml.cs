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
    /// Interaction logic for paySlipsHome.xaml
    /// </summary>
    public partial class paySlipsHome : Page
    {
        

        public paySlipsHome()
        {
            InitializeComponent();
           
        }

        private void nextWage_Click(object sender, RoutedEventArgs e)
        {
            paySlipsWage wage = new paySlipsWage();
            this.NavigationService.Navigate(wage);


        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       
    }
}
