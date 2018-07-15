using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using NLog;

namespace PayRoll.Core.DataAccess
{
    public class CsvReader : IReader
    {
        private readonly TextReader _textReader;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public CsvReader(TextReader textReader)
        {
            _textReader = textReader;
        }
        public IEnumerable<EmployeeDetails> Read()
        {
            var records = new List<EmployeeDetails>();
            try
            {
                using (var csvReader = new CsvHelper.CsvReader(_textReader))
                {
                    csvReader.Configuration.HasHeaderRecord = true;
                    records = csvReader.GetRecords<EmployeeDetails>().ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return records;
        }
    }
}
