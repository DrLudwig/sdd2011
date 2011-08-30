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
        private void Go_Click(object sender, RoutedEventArgs e)
        {
            int publicholidayhours;
            bool publicholidayhoursbool = int.TryParse(PublicHolidayTextBox.Text, out publicholidayhours);
            int normalhours;
            bool normalhoursbool = int.TryParse(NumberofHoursTextbox.Text, out normalhours);
            if (publicholidayhours > 40 || normalhours > 40 || (normalhours + publicholidayhours) > 40)
            {
                ToManyHours tomanyhours = new ToManyHours();
                tomanyhours.ShowDialog();
            }

            if (publicholidayhoursbool && normalhoursbool && publicholidayhours >= 0 && normalhours >= 0)
            {
                ComboBoxItem HourlyWage = (ComboBoxItem)HourlyWageCombobox.SelectedItem;
                ComboBoxItem OvertimeHours = (ComboBoxItem)OvertimeHoursCombobox.SelectedItem;
                ComboBoxItem RespoBonus = (ComboBoxItem)ResponsibilitiesBonusCombobox.SelectedItem;
                if (NumberofHoursTextbox.Text == "")
                {
                    NumberofHoursTextbox.Text = "0";
                }
                if (PublicHolidayTextBox.Text == "")
                {
                    PublicHolidayTextBox.Text = "0";
                }

                double OvertimeWage = int.Parse((string)OvertimeHours.Content) * int.Parse(((string)HourlyWage.Content).Substring(1, 2)) * 1.5;
                double WeeklyWage = int.Parse(((string)HourlyWage.Content).Substring(1, 2)) * int.Parse(NumberofHoursTextbox.Text);
                double PublicHolidayWage = int.Parse(((string)HourlyWage.Content).Substring(1, 2)) * int.Parse(PublicHolidayTextBox.Text) * 2;
                double TotalWage = WeeklyWage + OvertimeWage + int.Parse(((string)RespoBonus.Content).Substring(1, 3)) + PublicHolidayWage;
                double YearlyWage = TotalWage * 52;
                double tax = 0;
                if (YearlyWage > 0 && YearlyWage <= 6000)
                {
                    tax = 0;
                }
                else if (YearlyWage > 6000 && YearlyWage <= 37000)
                {
                    tax = (YearlyWage - 6000) * .15;
                }
                else if (YearlyWage > 37000 && YearlyWage <= 80000)
                {
                    tax = (YearlyWage - 37000) * .30 + 4650;
                }
                else if (YearlyWage > 80000 && YearlyWage <= 180000)
                {
                    tax = (YearlyWage - 80000) * .37 + 17550;
                }
                else if (YearlyWage > 180000)
                {
                    tax = (YearlyWage - 180000) * .45 + 54550;
                }
                tax = tax / 52;
                CalculateTax.Content = "$" + Math.Round(tax, 2);
                CalculateWeeklyWage.Content = "$" + WeeklyWage;
                CalculateTotalWage.Content = "$" + TotalWage;
                CalculateYearlyWage.Content = "$" + YearlyWage;
                WageAfterTax.Content = "$" + (TotalWage - Math.Round(tax, 2));
            }
            else if (!normalhoursbool && publicholidayhoursbool && publicholidayhours >= 0 && normalhours >= 0)
            {
                Error_NormalHours normalhourserror = new Error_NormalHours();
                normalhourserror.ShowDialog();
            }
            else if (normalhoursbool && !publicholidayhoursbool && publicholidayhours >= 0 && normalhours >= 0)
            {
                Error_PublicHolidaysHours publicholidayerror = new Error_PublicHolidaysHours();
                publicholidayerror.ShowDialog();
            }
            else if (publicholidayhours >= 0 && normalhours < 0)
            {
                Error_NormalHours normalhourserror = new Error_NormalHours();
                normalhourserror.ShowDialog();
            }
            else if (publicholidayhours < 0 && normalhours >= 0)
            {
                Error_PublicHolidaysHours publicholidayerror = new Error_PublicHolidaysHours();
                publicholidayerror.ShowDialog();
            }
            else
            {
                Error_NormalHours normalhourserror = new Error_NormalHours();
                normalhourserror.ShowDialog();
                Error_PublicHolidaysHours publicholidayerror = new Error_PublicHolidaysHours();
                publicholidayerror.ShowDialog();
            }
        }

        
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResponsibilitiesBonusCombobox.SelectedIndex = 0;
            OvertimeHoursCombobox.SelectedIndex = 0;
            HourlyWageCombobox.SelectedIndex = 0;
            NumberofHoursTextbox.Text = "0";
            PublicHolidayTextBox.Text = "0";
            CalculateWeeklyWage.Content = "";
            CalculateTotalWage.Content = "";
            CalculateTax.Content = "";
            WageAfterTax.Content = "";
            CalculateYearlyWage.Content = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
