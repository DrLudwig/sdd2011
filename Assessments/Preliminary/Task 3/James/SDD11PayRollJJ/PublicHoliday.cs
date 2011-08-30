using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDD11PayRollJJ
{

    public class PublicHoliday
    {
        private int count;
        private string countText;


        public PublicHoliday(int count, string countText)
        {
            this.count = count;
            this.countText = countText;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public string CountText
        {
            get { return countText; }
            set { countText = value; }
        }

    }
}
