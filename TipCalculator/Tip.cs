using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator
{
    class Tip
    {
        public double tipAmount { get; set; }
        public double billAmount { get; set; }
        public double totalAmount { get; set; }
        public Tip()
        {
            this.billAmount = 0.00;
            this.tipAmount = 0.00;
            this.totalAmount = 0.00;
        }
        public void calTip(double billAmount, double percent)
        {
            this.billAmount = billAmount;
            this.tipAmount = billAmount * percent;
            this.totalAmount = this.billAmount + this.tipAmount;
        }
    }
}
