using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDD11PayRollJJ
{

    public class WorkHour
    {
        private int hour;
        private string hourText;


        public WorkHour(int hour, string hourText)
        {
            this.hour = hour;
            this.hourText = hourText;
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public string HourText
        {
            get { return hourText; }
            set { hourText = value; }
        }

    }
}
