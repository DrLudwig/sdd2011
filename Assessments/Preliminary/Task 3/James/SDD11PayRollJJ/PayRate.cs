using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDD11PayRollJJ
{

    public class PayRate
    {
        private int rate;
        private string rateText;


        public PayRate(int rate, string rateText)
        {
            this.rate = rate;
            this.rateText = rateText;
        }

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string RateText
        {
            get { return rateText; }
            set { rateText = value; }
        }

    }
}
