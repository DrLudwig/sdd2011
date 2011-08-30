using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDD11PayRollJJ
{

    public class ResponsibilityBonus
    {
        private int amount;
        private string amountText;


        public ResponsibilityBonus(int amount, string amountText)
        {
            this.amount = amount;
            this.amountText = amountText;
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string AmountText
        {
            get { return amountText; }
            set { amountText = value; }
        }

    }
}
