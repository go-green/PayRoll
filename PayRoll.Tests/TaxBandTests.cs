using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayRoll.Core.DataAccess;
using PayRoll.Core.Tax;

namespace PayRoll.Tests
{
    [TestClass]
    public class TaxBandTests
    {
        [TestMethod]
        public void Check_Tax_Band_One_Pay_Amount_Over_LowerLimit()
        {
            #region Arrange

            var bandOne = new TaxBandOne();

            #endregion

            #region Act

            var amount1 = bandOne.GetPayAmountOverLowerLimit(0);
            var amount2 = bandOne.GetPayAmountOverLowerLimit(1);
            var amount3 = bandOne.GetPayAmountOverLowerLimit(18200);
            var amount4 = bandOne.GetPayAmountOverLowerLimit(18201);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(1, amount2);
            Assert.AreEqual(18200, amount3);
            Assert.AreEqual(18200, amount4);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_One_Income_Tax()
        {
            #region Arrange

            var bandOne = new TaxBandOne();

            #endregion

            #region Act

            var amount1 = bandOne.Calculate(0);
            var amount2 = bandOne.Calculate(18200);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(0, amount2);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Two_Pay_Amount_Over_LowerLimit()
        {
            #region Arrange

            var bandTwo = new TaxBandTwo();

            #endregion

            #region Act

            var amount1 = bandTwo.GetPayAmountOverLowerLimit(18200);
            var amount2 = bandTwo.GetPayAmountOverLowerLimit(18201);
            var amount3 = bandTwo.GetPayAmountOverLowerLimit(37000);
            var amount4 = bandTwo.GetPayAmountOverLowerLimit(37001);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(1, amount2);
            Assert.AreEqual(18800, amount3);
            Assert.AreEqual(18800, amount4);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Two_Income_Tax()
        {
            #region Arrange

            var bandTwo = new TaxBandTwo();

            #endregion

            #region Act

            var amount1 = bandTwo.Calculate(18200);
            var amount2 = bandTwo.Calculate(18201);
            var amount3 = bandTwo.Calculate(18203);
            var amount4 = bandTwo.Calculate(37000);
            var amount5 = bandTwo.Calculate(37001);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(0, amount2);
            Assert.AreEqual(0, amount3);
            Assert.AreEqual(298, amount4);
            Assert.AreEqual(298, amount5);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Three_Pay_Amount_Over_LowerLimit()
        {
            #region Arrange

            var bandThree = new TaxBandThree();

            #endregion

            #region Act

            var amount1 = bandThree.GetPayAmountOverLowerLimit(37000);
            var amount2 = bandThree.GetPayAmountOverLowerLimit(37001);
            var amount3 = bandThree.GetPayAmountOverLowerLimit(87000);
            var amount4 = bandThree.GetPayAmountOverLowerLimit(87001);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(1, amount2);
            Assert.AreEqual(50000, amount3);
            Assert.AreEqual(50000, amount4);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Three_Income_Tax()
        {
            #region Arrange

            var bandThree = new TaxBandThree();

            #endregion

            #region Act

            var amount1 = bandThree.Calculate(37000);
            var amount2 = bandThree.Calculate(37001);
            var amount3 = bandThree.Calculate(87000);
            var amount4 = bandThree.Calculate(87001); 
            var amount5 = bandThree.Calculate(60050);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(298, amount2);
            Assert.AreEqual(1652, amount3);
            Assert.AreEqual(1652, amount4);
            Assert.AreEqual(922, amount5);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Four_Pay_Amount_Over_LowerLimit()
        {
            #region Arrange

            var bandFour = new TaxBandFour();

            #endregion

            #region Act

            var amount1 = bandFour.GetPayAmountOverLowerLimit(87000);
            var amount2 = bandFour.GetPayAmountOverLowerLimit(87001);
            var amount3 = bandFour.GetPayAmountOverLowerLimit(180000);
            var amount4 = bandFour.GetPayAmountOverLowerLimit(180001);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(1, amount2);
            Assert.AreEqual(93000, amount3);
            Assert.AreEqual(93000, amount4);

            #endregion
        }


        [TestMethod]
        public void Check_Tax_Band_Four_Income_Tax()
        {
            #region Arrange

            var bandFour = new TaxBandFour();

            #endregion

            #region Act

            var amount1 = bandFour.Calculate(87000);
            var amount2 = bandFour.Calculate(87001);
            var amount3 = bandFour.Calculate(87100);
            var amount4 = bandFour.Calculate(180000);
            var amount5 = bandFour.Calculate(180001);

            #endregion

            #region Assert

            Assert.AreEqual(0, amount1);
            Assert.AreEqual(1652, amount2);
            Assert.AreEqual(1655, amount3);
            Assert.AreEqual(4519, amount4);
            Assert.AreEqual(4519, amount5);

            #endregion
        }

    }
}
