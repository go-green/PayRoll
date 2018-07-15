using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using PayRoll.Core.Tax;

namespace PayRoll.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new StandardKernel();
            container.Load(Assembly.GetExecutingAssembly());
            var employeePayRollFileProcessor = container.Get<IFileProcessor>();

            var hasProcessed = employeePayRollFileProcessor.Process();

            if (hasProcessed)
            {
                Console.WriteLine("File Processed Successfully!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error Processing the file! Check the log file for more details");
                Console.ReadLine();
            }
        }
    }
}
