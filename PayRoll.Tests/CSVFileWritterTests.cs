using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayRoll.Core.DataAccess;

namespace PayRoll.Tests
{

    [TestClass]
    public class CSVFileWritterTests
    {
        [TestMethod]
        public void Can_Write_The_Collection_To_A_CSV_File()
        {
            #region Arrange
            Exception expectedExcetpion = null;
            var payDetails = new List<PayDetails>()
            {
                new PayDetails()
                {
                    Name = "David Rudd",
                    PayPeriod = "01 March – 31 March",
                    GrossIncome = 5004,
                    IncomeTax = 922,
                    NetIncome = 4082,
                    Super = 450
                },
                new PayDetails()
                {
                    Name = "Ryan Chen",
                    PayPeriod = "01 March – 31 March",
                    GrossIncome = 10000,
                    IncomeTax = 2669,
                    NetIncome = 7331,
                    Super = 1000
                }
            };


            #endregion

            var textWritter = File.CreateText($"PayDetails_{DateTime.Now.ToString("dd-MMM-yyyy")}");
            var csvFileWritter = new CSVFileWritter(textWritter);

            #region Act


            try
            {
                csvFileWritter.Write(payDetails);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }
            

            #endregion

            #region Assert

            Assert.IsNull(expectedExcetpion);

            #endregion
        }
    }
}
