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
    /// Interaction logic for paySlipsTax.xaml
    /// </summary>
    public partial class paySlipsTax : Page
    {

        
        
        private delegate void NoArgDelegate();
        public static void Refresh(DependencyObject obj)
        {
            obj.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Loaded,
                (NoArgDelegate)delegate { });
        }

        double taxResult;
        double grossResult;
        double grossPayTaxCal;
        public double completeTax;
        int wage = globals.wage;
        double overtime = globals.overtime;
        double overResult;
        int responsibility = globals.response;
        int publicHoliday = globals.publicHoliday;
        
     
        public paySlipsTax()
        {
            
            InitializeComponent();
            
        }

        private void taxCalculate_Click(object sender, RoutedEventArgs e)
        {



            grossPayTaxCal = ((globals.wage * globals.wageHours) + ((globals.wage * 2) * globals.publicHoliday) + responsibility + ((globals.wage * 1.5) * globals.overtime)) * 52;
            

            if (grossPayTaxCal >= 6000)
            {
                if (grossPayTaxCal <= 37000 && grossPayTaxCal >= 6000)
                {
                    taxResult = grossPayTaxCal - 6000;

                    completeTax = (taxResult * .15) / 52;

                    

                    completeTax = Math.Round(completeTax, 2);
                }

                if (grossPayTaxCal >= 37001 && grossPayTaxCal <= 80000)
                {
                    taxResult = grossPayTaxCal - 37000;

                    completeTax = ((taxResult * .30) + 4650)/ 52;

                    

                    completeTax = Math.Round(completeTax, 2);

                }

                if (grossPayTaxCal >= 80001 && grossPayTaxCal <= 180000)
                {
                    taxResult = grossPayTaxCal - 80000;

                    completeTax = ((taxResult * .37) + 17550) / 52;

                   

                    completeTax = Math.Round(completeTax, 2);

                }

                if (grossPayTaxCal >= 180001)
                {
                    taxResult = grossPayTaxCal - 180000;

                    completeTax = ((taxResult * .45) + 54550) / 52;

                    

                    completeTax = Math.Round(completeTax, 2);

                }

                globals.tax = completeTax;
                taxLabel.Content = globals.tax;
                netBut.IsEnabled = true;
            }
            
        }

        

        private void finishPaySlips_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void netBut_Click(object sender, RoutedEventArgs e)
        {
            nettLabel.Content = (globals.grossResults) - (globals.tax);
        }

        private void grossCalBut_Click(object sender, RoutedEventArgs e)
        {
            Refresh(grossLabel);
            Refresh(wageLabel);
            Refresh(overLabel);
           
            Refresh(publicLabel);
            Refresh(responseLabel);

            wage = (globals.wage) * globals.wageHours;
            wageLabel.Content = wage;

            overResult = (globals.wage * 1.5) * overtime;
            overLabel.Content = overResult;


            if (overResult == 0)
            {
                dollar2.Content = "";
                overLabel.Content = "None";
            }

            responseLabel.Content = responsibility;

            if (responsibility == 0)
            {
                dollar3.Content = "";
                responseLabel.Content = "None";
            }

            publicHoliday = (globals.wage * 2) * globals.publicHoliday;
            publicLabel.Content = publicHoliday;

            if (publicHoliday == 0)
            {
                dollar4.Content = "";
                publicLabel.Content = "None";
            }

            grossResult = (globals.wage*globals.wageHours) + ((globals.wage * 2) * globals.publicHoliday) + responsibility + ((globals.wage * 1.5)*globals.overtime);
            globals.grossResults = grossResult;
            grossLabel.Content = globals.grossResults;
        }

        

        

        

       
    }
}
