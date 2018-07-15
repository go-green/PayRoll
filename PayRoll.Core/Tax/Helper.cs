using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Tax
{
    public class Helper
    {
        public static uint GetRoundedAmount(decimal rawIncomeTax)
        {
            var roundedIncomeTax = Math.Round(rawIncomeTax, MidpointRounding.AwayFromZero);
            return Convert.ToUInt32(roundedIncomeTax);
        }
    }
}
