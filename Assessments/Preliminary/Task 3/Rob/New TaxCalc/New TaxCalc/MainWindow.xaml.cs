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

namespace WpfApplication1
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


        private void startMain_Click_1(object sender, RoutedEventArgs e)
        {
            tenOption.IsChecked = true;
            zeroOvertime.IsChecked = true;
            noBonus.IsChecked = true;

            inputPHolidayHours.Text = "";
            normalHourInput.Text = "";

            hourlyWage.Visibility = System.Windows.Visibility.Visible;
            startMain.Visibility = System.Windows.Visibility.Hidden;
        }

        private void backToMain_Click(object sender, RoutedEventArgs e)
        {
            startMain.Visibility = System.Windows.Visibility.Visible;
            hourlyWage.Visibility = System.Windows.Visibility.Hidden;
        }

        private void toOvertime_Click(object sender, RoutedEventArgs e)
        {
            int normalHoursWorked = 0;
            if (int.TryParse(normalHourInput.Text, out normalHoursWorked) == false)
            {
                MessageBox.Show("Insert a valid value for number of normal hours worked", "Error!");
                normalHourInput.Text = "";
            }
            else
            {
                hourlyWage.Visibility = System.Windows.Visibility.Hidden;
                overtime.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void backToHourlyWage_Click(object sender, RoutedEventArgs e)
        {
            overtime.Visibility = System.Windows.Visibility.Hidden;
            hourlyWage.Visibility = System.Windows.Visibility.Visible;
        }

        private void toPHoliday_Click(object sender, RoutedEventArgs e)
        {
            overtime.Visibility = System.Windows.Visibility.Hidden;
            publicHoliday.Visibility = System.Windows.Visibility.Visible;
        }

        private void backToOvertime_Click(object sender, RoutedEventArgs e)
        {
            publicHoliday.Visibility = System.Windows.Visibility.Hidden;
            overtime.Visibility = System.Windows.Visibility.Visible;
        }

        private void toBonus_Click(object sender, RoutedEventArgs e)
        {
            int publicHolidayHours = 0;

            if (int.TryParse(inputPHolidayHours.Text, out publicHolidayHours) == false)
            {
                MessageBox.Show("Insert a valid value for number of public holiday hours worked", "Error!");
                inputPHolidayHours.Text = "";
            }
            else
            {
                publicHoliday.Visibility = System.Windows.Visibility.Hidden;
                bonus.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void backToPHoliday_Click(object sender, RoutedEventArgs e)
        {
            bonus.Visibility = System.Windows.Visibility.Hidden;
            publicHoliday.Visibility = System.Windows.Visibility.Visible;
        }

        private void toTaxResults_Click(object sender, RoutedEventArgs e)
        {
            int bonusPayPerWeek = 0;
            if (noBonus.IsChecked == true)
            {
                bonusPayPerWeek = 0;
            }
            else
                if (fiftyBonus.IsChecked == true)
                {
                    bonusPayPerWeek = 50;
                }
                else if (eightyBonus.IsChecked == true)
                {
                    bonusPayPerWeek = 80;
                }
                else
                {
                    bonusPayPerWeek = 100;
                }

            double grossIncome = 0;
            double nettIncome = 0;
            double tax = 0;

            //normal hours
            grossIncome = hourlyRate() * int.Parse(normalHourInput.Text);

            //add overtime hours
            grossIncome = grossIncome + (numOvertimeHours() * (hourlyRate() * 1.5));

            //add public holiday hours
            grossIncome = grossIncome + ((int.Parse(inputPHolidayHours.Text) * (hourlyRate() * 2)));

            //add bonus
            grossIncome = grossIncome + bonusPayPerWeek;

            //now calculate tax
            double annualIncome = grossIncome * 52;

            if (annualIncome < 6001)
            {
                tax = 0;
            }
            else
                if (annualIncome < 37001)
                {
                    tax = (annualIncome - 6000) * 0.15;
                }
                else
                    if (annualIncome < 80001)
                    {
                        tax = 4650 + ((annualIncome - 37000) * 0.30);
                    }
                    else
                        if (annualIncome < 180001)
                        {
                            tax = 17550 + ((annualIncome - 80000) * 0.37);
                        }
                        else
                        {
                            tax = 54550 + ((annualIncome - 180000) * 0.45);
                        }

            tax = tax / 52;
            nettIncome = grossIncome - tax;

            grossPayAns.Text = Math.Round(grossIncome, 2).ToString();
            taxAns.Text = Math.Round(tax, 2).ToString();
            nettPayAns.Text = Math.Round(nettIncome, 2).ToString();

            bonus.Visibility = System.Windows.Visibility.Hidden;
            taxResults.Visibility = System.Windows.Visibility.Visible;
        }

        private void backToBonus_Click(object sender, RoutedEventArgs e)
        {
            taxResults.Visibility = System.Windows.Visibility.Hidden;
            bonus.Visibility = System.Windows.Visibility.Visible;
        }

        private void backToStartButton_Click(object sender, RoutedEventArgs e)
        {
            taxResults.Visibility = System.Windows.Visibility.Hidden;
            startMain.Visibility = System.Windows.Visibility.Visible;
        }
         public int hourlyRate()
        {
            if (tenOption.IsChecked == true)
            {
                return 10;
            }
            else
                if (fifteenOption.IsChecked == true)
                {
                    return 15;
                }
                else
                {
                    return 20;
                }

        }
        public int numOvertimeHours()
        {
            if (zeroOvertime.IsChecked == true)
            {
                return  0;
            }
            else
                if (oneOvertime.IsChecked == true)
                {
                    return 1;
                }
                else if (twoOvertime.IsChecked == true)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
        }

    }
}


