using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBandOne : TaxBase
    {
        public TaxBandOne()
        {
            this.RuleID = 1;
            this.LowerLimit = 0;
            this.UpperLimit = 18200;
            this.FixedRate = 0;
            this.FixedAmount = 0;
            this.LimitDifference = UpperLimit - LowerLimit;
        }
    }
}
