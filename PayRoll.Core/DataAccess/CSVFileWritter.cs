using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using NLog;

namespace PayRoll.Core.DataAccess
{
    public class CSVFileWritter : IFileWritter
    {
        private readonly TextWriter _textWriter;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CSVFileWritter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }
        public void Write(IEnumerable<PayDetails> payDetails)
        {
            using (var writter = new CsvWriter(_textWriter))
            {
                try
                {
                    writter.WriteRecords(payDetails);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    throw;
                }
            }
        }
    }
}
