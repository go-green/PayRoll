using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBandFive : TaxBase
    {
        public TaxBandFive()
        {
            this.RuleID = 5;
            this.LowerLimit = 180000;
            this.UpperLimit = 999999999;
            this.FixedRate = 0.45M;
            this.FixedAmount = 54232;
            this.LimitDifference = UpperLimit - LowerLimit;
        }
    }
}
