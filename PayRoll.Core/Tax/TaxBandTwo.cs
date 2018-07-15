using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBandTwo : TaxBase
    {
        public TaxBandTwo()
        {
            this.RuleID = 2;
            this.LowerLimit = 18200;
            this.UpperLimit = 37000;
            this.FixedRate = 0.19M;
            this.FixedAmount = 0;
            this.LimitDifference = UpperLimit - LowerLimit;
        }

        public override uint Calculate(uint amount)
        {
            if (!FallsUnderCurrentBand(amount)) return 0;
            var rawIncomeTax = (FixedRate * GetPayAmountOverLowerLimit(amount))/12;
            var roundedIncomeTax = Math.Round(rawIncomeTax, MidpointRounding.AwayFromZero);
            return Convert.ToUInt32(roundedIncomeTax);
        }          
    }
}
