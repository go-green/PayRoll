using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll.Core.DataAccess
{
    public interface IFileWritter
    {
        void Write(IEnumerable<PayDetails> payDetails);
    }
}
