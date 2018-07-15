using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class TaxBase : ITaxBase
    {
        protected int LowerLimit { get; set; }
        protected int UpperLimit { get; set; }
        protected int LimitDifference { get; set; }
        protected int FixedAmount { get; set; }
        protected decimal FixedRate { get; set; }
        public int RuleID { get; set; }
        public virtual uint Calculate(uint amount)
        {
            if (!FallsUnderCurrentBand(amount)) return 0;
            var payAmountOverLowerLimit = GetPayAmountOverLowerLimit(amount);
            var rawIncomeTax = (FixedAmount + (payAmountOverLowerLimit * FixedRate)) / 12;
            return Helper.GetRoundedAmount(rawIncomeTax);
        }

        protected bool FallsUnderCurrentBand(uint amount)
        {
            return amount > LowerLimit;
        }

        public int GetPayAmountOverLowerLimit(uint amount)
        {
            if (!FallsUnderCurrentBand(amount)) return 0;
            return amount >= UpperLimit ? LimitDifference : Convert.ToInt32(amount - LowerLimit);
        }
    }
}
