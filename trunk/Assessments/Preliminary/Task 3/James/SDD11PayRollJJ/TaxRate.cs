using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDD11PayRollJJ
{

    public class TaxRate
    {
        private int hour;
        private int wage;
        private int overTime;
        private int holidays;
        private int bonus;

        private double gross;
        private double nett;
        private double tax;


        public TaxRate(int hour, int wage, int overTime = 0, int holidays = 0, int bonus = 0)
        {
            this.hour = hour;
            this.wage = wage;
            this.overTime = overTime;
            this.holidays = holidays;
            this.bonus = bonus;
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public int Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public int OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }

        public int Holidays
        {
            get { return holidays; }
            set { holidays = value; }
        }

        public int Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public double Gross
        {
            get { return gross; }
            set { gross = value; }
        }

        public double Nett
        {
            get { return nett; }
            set { nett = value; }
        }

        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public void Calculate()
        {
            /// calculate wage first
            this.gross = 0;
            if (this.hour > 0)
            {
                this.gross = this.hour * this.wage;
            }
            if (this.overTime > 0)
            {
                this.gross += this.overTime * this.wage * 1.5;
            }
            if (this.bonus > 0)
            {
                this.gross += this.bonus;
            }
            if (holidays > 0)
            {
                this.gross += 2 * this.wage * this.holidays;
            }

            /// calculate tax values
            double annual = this.gross * 52;
            this.tax = 0;
            if (annual >= 180001)
            {
                this.tax += (annual - 180000) * 0.45;
                this.tax += 54550;
            }
            else if (annual >= 80001)
            {
                this.tax += (annual - 80000) * 0.37;
                this.tax += 17550;
            }
            else if (annual >= 37001)
            {
                this.tax += (annual - 37000) * 0.30;
                this.tax += 4650;
            }
            else if (annual >= 6001)
            {
                this.tax += (annual - 6000) * 0.15;
            }
            this.tax = this.tax / 52;
            this.nett = this.gross - this.tax;

            // convert to 2 decimal places
            //int tmp = (int)(this.tax * 100);
            //this.tax = tmp;

            //tmp = (int)(this.nett * 100);
            //this.nett = tmp;

            //tmp = (int)(this.gross * 100);
            //this.gross = tmp;
        }
    }
}
