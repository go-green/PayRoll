using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using PayRoll.Core.DataAccess;
using PayRoll.Core.Tax;

namespace PayRoll.Program
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            var textWritter = File.CreateText($"PayDetails_{DateTime.Now:dd-MMM-yyyy}");
            Bind<IFileWritter>().To<CSVFileWritter>().WithConstructorArgument("textWriter", textWritter);

            var textReader = File.OpenText(@"SampleData\EmployeeDetails.csv");
            Bind<IFileReader>().To<CSVFileReader>().WithConstructorArgument("textReader",textReader);

            Bind<IFileProcessor>().To<TaxCalculationService>();
        }
    }
}
