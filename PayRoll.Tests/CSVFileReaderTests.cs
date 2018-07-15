using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayRoll.Core.DataAccess;

namespace PayRoll.Tests
{
    [TestClass]
    public class CSVFileReaderTests
    {
        [TestMethod]
        public void Can_Get_The_Collection_Form_A_CSVFile()
        {
            #region Arrange

            var csvData = "FirstName,LastName,AnnualSalary,SuperRate,PaymentStartDate\r" +
                          "\nDavid,Rudd,60050,9%,01 March – 31 March\r" +
                          "\nRyan,Chen,120000,10%,01 March – 31 March\r" +
                          "\n";

            #endregion

            #region Act

            var csvFileReader = new CsvReader(new StringReader(csvData));
            var records = csvFileReader.Read();

            #endregion

            #region Assert

            Assert.AreEqual(2, records.Count());

            #endregion
        }


        [TestMethod]
        public void CSVData_Integrity_Has_Not_Been_Compromised()
        {
            #region Arrange

            var csvData = "FirstName,LastName,AnnualSalary,SuperRate,PaymentStartDate\r" +
                          "\nDavid,Rudd,60050,9%,01 March – 31 March\r" +
                          "\nRyan,Chen,120000,10%,01 March – 31 March\r" +
                          "\n";

            #endregion

            #region Act

            var csvFileReader = new CsvReader(new StringReader(csvData));
            var records = csvFileReader.Read();

            #endregion

            #region Assert

            Assert.AreEqual("David", records.First().FirstName);
            Assert.AreEqual("Rudd", records.First().LastName);
            Assert.AreEqual((uint) 60050, records.First().AnnualSalary);
            Assert.AreEqual("9%", records.First().SuperRate);
            Assert.AreEqual("01 March – 31 March", records.First().PaymentStartDate);

            #endregion
        }


        [TestMethod]
        public void Throws_An_Exception_When_Data_Format_Is_Invalid()
        {
            #region Arrange

            var csvData = "FirstName,LastName,AnnualSalary,SuperRate,PaymentStartDate\r" +
                          "\nDavid,Rudd,Hello,9%,01 March – 31 March\r" +
                          "\n";
            Exception expectedExcetpion = null;

            #endregion

            #region Act

            var csvFileReader = new CsvReader(new StringReader(csvData));
            try
            {
                csvFileReader.Read();
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            #endregion

            #region Assert


            Assert.IsNotNull(expectedExcetpion);

            #endregion
        }


        [TestMethod]
        public void Negative_Annual_Salary_Amount_Is_Not_Allowed()
        {
            #region Arrange

            var csvData = "FirstName,LastName,AnnualSalary,SuperRate,PaymentStartDate\r" +
                          "\nDavid,Rudd,-1,9%,01 March – 31 March\r" +
                          "\n";
            Exception expectedExcetpion = null;

            #endregion

            #region Act

            var csvFileReader = new CsvReader(new StringReader(csvData));
            try
            {
                csvFileReader.Read();
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            #endregion

            #region Assert


            Assert.IsNotNull(expectedExcetpion);

            #endregion
        }

        [TestMethod]
        public void Annual_Salary_Amount_Must_Be_A_Positive_Integer()
        {
            #region Arrange

            var csvData = "FirstName,LastName,AnnualSalary,SuperRate,PaymentStartDate\r" +
                          "\nDavid,Rudd,1000.00,9%,01 March – 31 March\r" +
                          "\n";
            Exception expectedExcetpion = null;

            #endregion

            #region Act

            var csvFileReader = new CsvReader(new StringReader(csvData));
            try
            {
                csvFileReader.Read();
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            #endregion

            #region Assert


            Assert.IsNotNull(expectedExcetpion);

            #endregion
        }
    }
}