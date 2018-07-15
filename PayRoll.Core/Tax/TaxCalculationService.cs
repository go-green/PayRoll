using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NLog;
using PayRoll.Core.DataAccess;
using PayRoll.Core.Tax;

namespace PayRoll.Core.Tax
{
    public class TaxCalculationService : IFileProcessor
    {
        private readonly IList<ITaxBase> _taxBands = new List<ITaxBase>();
        private readonly IReader _reader;
        private readonly IWritter _writter;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TaxCalculationService(IReader reader, IWritter writter)
        {
            _reader = reader;
            _writter = writter;
            _taxBands.Add(new TaxBandOne());
            _taxBands.Add(new TaxBandTwo());
            _taxBands.Add(new TaxBandThree());
            _taxBands.Add(new TaxBandFour());
            _taxBands.Add(new TaxBandFive());
        }


        private IEnumerable<EmployeeDetails> GetEmployeeReords()
        {
            return _reader.Read();
        }

        public bool Process()
        {
            try
            {
                var employeeDetails = GetEmployeeReords();
                var payDetails = employeeDetails.Select(employee => new PayDetails()
                    {
                        Name = $"{employee.FirstName} {employee.LastName}",
                        PayPeriod = employee.PaymentStartDate,
                        GrossIncome = GetGrossIncome(employee.AnnualSalary),
                        IncomeTax = GetIncomeTax(employee.AnnualSalary),
                        NetIncome = GetNetIncome(employee.AnnualSalary),
                        Super = GetSuper(employee.AnnualSalary, GetSuperRate(employee.SuperRate))
                    })
                    .ToList();
                _writter.Write(payDetails);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private int GetSuperRate(string superRate)
        {
            int processedRate = 0;
            try
            {
                if (superRate == null)
                {
                    throw new FormatException($"Super Rate is null and not supported");
                }
                var stringRate = superRate.Replace(@"%", string.Empty);
                var hasConverted = int.TryParse(stringRate, out processedRate);
                if (!hasConverted)
                {
                    throw new FormatException($"Given Super Rate {stringRate} is not supported");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return processedRate;
        }

        private uint GetSuper(uint employeeAnnualSalary, int superRate)
        {
            var rawSuperAmount = GetGrossIncome(employeeAnnualSalary) * superRate;
            return Helper.GetRoundedAmount(rawSuperAmount);
        }

        private uint GetNetIncome(uint employeeAnnualSalary)
        {
            return GetGrossIncome(employeeAnnualSalary) - GetIncomeTax(employeeAnnualSalary);
        }

        private uint GetGrossIncome(uint employeeAnnualSalary)
        {
            var rawMonthlySalary = employeeAnnualSalary / 12;
            return Helper.GetRoundedAmount(rawMonthlySalary);
        }

        private uint GetIncomeTax(uint employeeAnnualSalary)
        {
            return (uint)_taxBands.OrderBy(band => band.RuleID).Sum(band => band.Calculate(employeeAnnualSalary));
        }
    }
}

