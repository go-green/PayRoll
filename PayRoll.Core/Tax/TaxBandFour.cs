using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBandFour : TaxBase
    {
        public TaxBandFour()
        {
            this.RuleID = 4;
            this.LowerLimit = 87000;
            this.UpperLimit = 180000;
            this.FixedRate = 0.37M;
            this.FixedAmount = 19822;
            this.LimitDifference = UpperLimit - LowerLimit;
        }
    }
}
