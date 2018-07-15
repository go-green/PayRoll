using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBandThree : TaxBase
    {
        public TaxBandThree()
        {
            this.RuleID = 3;
            this.LowerLimit = 37000;
            this.UpperLimit = 87000;
            this.FixedRate = 0.325M;
            this.FixedAmount = 3572;
            this.LimitDifference = UpperLimit - LowerLimit;
        }
    }
}
