using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll.Core.DataAccess
{
    public interface IReader
    {
        IEnumerable<EmployeeDetails> Read();
    }
}
