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

namespace WageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        int hourlyWage = 0;
        string hours = "0";
        string overtimeHours = "0";
        string holidayHours = "0";
        int weeklyBonus = 0;
        double grossWeeklyPay = 0;
        double grossYearlyPay = 0;
        double nettWeeklyPay = 0;
        double tax;

        private void wageSelect10_Checked(object sender, RoutedEventArgs e)
        {
            hourlyWage = 10;
        }

        private void wageSelect15_Checked(object sender, RoutedEventArgs e)
        {
            hourlyWage = 15;
        }

        private void wageSelect20_Checked(object sender, RoutedEventArgs e)
        {
            hourlyWage = 20;
        }

        private void enterHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            hours = enterHours.Text;
        }

        private void enterOT_TextChanged(object sender, TextChangedEventArgs e)
        {
            overtimeHours = enterOT.Text;
        }

        private void enterHoliday_TextChanged(object sender, TextChangedEventArgs e)
        {
            holidayHours = enterHoliday.Text;
        }

        private void bonusSelect50_Checked(object sender, RoutedEventArgs e)
        {
            weeklyBonus = 50;
        }

        private void bonusSelect80_Checked(object sender, RoutedEventArgs e)
        {
            weeklyBonus = 80;
        }

        private void bonusSelect100_Checked(object sender, RoutedEventArgs e)
        {
            weeklyBonus = 100;
        }


        private void bonusSelect0_Checked(object sender, RoutedEventArgs e)
        {
            weeklyBonus = 0;
        }


        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            bool TestOTEntry = int.TryParse(overtimeHours, out i);
            bool TestHolidayEntry = int.TryParse(holidayHours, out j);
            bool TestHoursEntry = int.TryParse(hours, out k);

            if (TestHolidayEntry == false)
            {
                errorMessage.Content = "* Error: must enter a numerical value in Holiday Hours Field";
            }
            
            else
            {
                if (TestOTEntry == false)
                {
                    errorMessage.Content = "* Error: must enter a numerical value in Overtime Hours Field";
                }
                else
                {
                    if (TestHoursEntry == false)
                    {
                        errorMessage.Content = "* Error: must enter a numerical value in Hours Field";
                    }
                    else
                    {
                        if (int.Parse(overtimeHours) > 3)
                        {
                            errorMessage.Content = "* Error: maximum of 3 overtime hours per week";
                        }

                        else
                        {
                            grossWeeklyPay = hourlyWage * (int.Parse(hours)) + (int.Parse(overtimeHours)) * hourlyWage * 1.5 + (int.Parse(holidayHours)) * hourlyWage * 2 + weeklyBonus;
                            displayGross.Text = (Math.Round(grossWeeklyPay, 2)).ToString();
                            errorMessage.Content = "";
                            grossYearlyPay = 52 * grossWeeklyPay;
                            if (grossYearlyPay <= 6000)
                            {
                                tax = 0;
                            }
                            if (grossYearlyPay > 6000 && grossYearlyPay <= 37000)
                            {
                                tax = (grossYearlyPay - 6000) * 0.15;
                            }
                            if (grossYearlyPay > 37000 && grossYearlyPay <= 80000)
                            {
                                tax = 4650 + ((grossYearlyPay - 37000) * 0.3);
                            }
                            if (grossYearlyPay > 80000 && grossYearlyPay <= 180000)
                            {
                                tax = 17550 + ((grossYearlyPay - 80000) * 0.37);
                            }
                            if (grossYearlyPay > 180000)
                            {
                                tax = 54550 + ((grossYearlyPay - 180000) * 0.45);
                            }
                            nettWeeklyPay = (grossYearlyPay - tax) / 52;
                            displayNett.Text = (Math.Round(nettWeeklyPay, 2)).ToString();

                        }
                    }
                }
            }
        }

   
             
     }
}
