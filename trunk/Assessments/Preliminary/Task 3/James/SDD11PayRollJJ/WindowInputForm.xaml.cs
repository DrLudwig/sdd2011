using System;

using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
///using System.Windows.Forms;

namespace SDD11PayRollJJ
{
    /// <summary>
    /// Interaction logic for WindowInputForm.xaml
    /// </summary>
    public partial class WindowInputForm : Window
    {
        public WindowInputForm()
        {
            InitializeComponent();
            InitializeWorkHour();
            InitializePayRate();
            InitializeResponsibilityBonus();
            InitializeOverTime();
            InitializePublicHoliday();
        }

        private void bCalculate_Click(object sender, RoutedEventArgs e)
        {
            // get tehe value from the slections in the comboboxes
            int selectedIndex = cbPayRate.SelectedIndex;
            int selectedValPayRate = (int)cbPayRate.SelectedValue;
            //PayRate SelectedPayRate = (PayRate)cbPayRate.SelectedItem;

            selectedIndex = cbOverTimeHours.SelectedIndex;
            int selectedValOverTimeHours = (int)cbOverTimeHours.SelectedValue;

            selectedIndex = cbResponsibilityBonus.SelectedIndex;
            int selectedValResponsibilityBonus = (int)cbResponsibilityBonus.SelectedValue;

            selectedIndex = cbPublicHoliday.SelectedIndex;
            int selectedValPublicHoliday = (int)cbPublicHoliday.SelectedValue;

            selectedIndex = cbWorkHour.SelectedIndex;
            int selectedValWorkHour = (int)cbWorkHour.SelectedValue;

            if (bCheck(selectedValWorkHour,selectedValPublicHoliday))
            {
                TaxRate pay = new TaxRate(selectedValWorkHour, selectedValPayRate, selectedValOverTimeHours, selectedValPublicHoliday, selectedValResponsibilityBonus);
                pay.Calculate();
          
                // tempprary code to output the value so we can prove it works!
                // tbGrossPay.Text = String.Format("Index: [{0}] PayRate={1}; Value={2}", selectedIndex, selectedPayRate.RateText, selecteVal);
                // tbGross.Text = String.Format("{0}/{1}/{2}/{3}", selectedValPayRate, selectedValOverTimeHours, selectedValResponsibilityBonus, selectedValPublicHoliday);

               // note :C formats as currency including $
               tbGross.Text = String.Format("{0:C}", pay.Gross);
               tbNett.Text = String.Format("{0:C}", pay.Nett);
               tbTax.Text = String.Format("{0:C}", pay.Tax);
            }
        }

        private Boolean bCheck( int hours, int holidays)
        {
            tbMessage.Text = String.Format("");
            if (hours + holidays > 40)
            {
                tbMessage.Text = String.Format("Hours worked plus holidays hours must be 40 hours or less.");
                tbMessage.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            return true;
        }

        private void InitializePayRate()
        {
            /// create an array of PayRates
            ArrayList PayRates = new ArrayList();

            /// seed the array with 3 records
            PayRates.Add(new PayRate(10, "$10 per hour"));
            PayRates.Add(new PayRate(15, "$15 per hour"));
            PayRates.Add(new PayRate(20, "$20 per hour"));

            /// attach the data to the combobox on the window
            cbPayRate.ItemsSource = PayRates;
            cbPayRate.DisplayMemberPath = "RateText";
            cbPayRate.SelectedValuePath = "Rate";

            // select nothing to force the user to choose something
            cbPayRate.SelectedIndex = 0;
        }

        private void InitializeResponsibilityBonus()
        {
            /// create an array of ResponsibilityBonusRates
            ArrayList ResponsibilityBoni = new ArrayList();

            /// seed the array with 4 records
            ResponsibilityBoni.Add(new ResponsibilityBonus(0, "No Bonus"));
            ResponsibilityBoni.Add(new ResponsibilityBonus(50, "$50 per week"));
            ResponsibilityBoni.Add(new ResponsibilityBonus(80, "$80 per week"));
            ResponsibilityBoni.Add(new ResponsibilityBonus(100, "$100 per week"));

            /// attach the data to the combobox on the window
            cbResponsibilityBonus.ItemsSource = ResponsibilityBoni;
            cbResponsibilityBonus.DisplayMemberPath = "AmountText";
            cbResponsibilityBonus.SelectedValuePath = "Amount";

            // select nothing to force the user to choose something
            cbResponsibilityBonus.SelectedIndex = 0;
        }

        private void InitializeOverTime()
        {
            /// create an array of OverTime
            /// using combobox even though should be text because limitation of max 3 hours of overtime as business rule, combobox simplifies input and validation
            ArrayList OverTimes = new ArrayList();

            /// seed the array with 3 records
            OverTimes.Add(new OverTime(0, "No Overtime"));
            OverTimes.Add(new OverTime(1, "1 hour"));
            OverTimes.Add(new OverTime(2, "2 hours"));
            OverTimes.Add(new OverTime(3, "3 hours"));

            /// attach the data to the combobox on the window
            cbOverTimeHours.ItemsSource = OverTimes;
            cbOverTimeHours.DisplayMemberPath = "RateText";
            cbOverTimeHours.SelectedValuePath = "Rate";

            // select nothing to force the user to choose something
            cbOverTimeHours.SelectedIndex = 0;
        }

        private void InitializePublicHoliday()
        {
            /// create an array of OverTime
            /// using combobox even though should be text because limitation of max 3 hours of overtime as business rule, combobox simplifies input and validation
            ArrayList PublicHolidays = new ArrayList();

            /// seed the array with 5 records
            /// /// max of 4 public holidays in a week (christmas)
            PublicHolidays.Add(new PublicHoliday(0, "No Public Holidays"));
            for (int i = 1; i <= 40; i++)
            {
                PublicHolidays.Add(new PublicHoliday(i, String.Format("{0} hours", i)));
            }
            ///PublicHolidays.Add(new PublicHoliday(2, "2 day"));
            ///PublicHolidays.Add(new PublicHoliday(3, "3 day"));
            ///PublicHolidays.Add(new PublicHoliday(4, "4 day"));

            /// attach the data to the combobox on the window
            cbPublicHoliday.ItemsSource = PublicHolidays;
            cbPublicHoliday.DisplayMemberPath = "CountText";
            cbPublicHoliday.SelectedValuePath = "Count";

            // select nothing to force the user to choose something
            cbPublicHoliday.SelectedIndex = 0;
        }

        private void InitializeWorkHour()
        {
            /// create an array of OverTime
            /// using combobox even though should be text because limitation of max 3 hours of overtime as business rule, combobox simplifies input and validation
            ArrayList WorkHours = new ArrayList();

            /// seed the array with 5 records
            /// /// max of 4 public holidays in a week (christmas)
            WorkHours.Add(new WorkHour(0, "No Hours Worked"));
            for (int i = 1; i <= 40; i++)
            {
                WorkHours.Add(new WorkHour(i, String.Format("{0} hours", i)));
            }
            
            /// attach the data to the combobox on the window
            cbWorkHour.ItemsSource = WorkHours;
            cbWorkHour.DisplayMemberPath = "HourText";
            cbWorkHour.SelectedValuePath = "Hour";

            // select nothing to force the user to choose something
            cbWorkHour.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
