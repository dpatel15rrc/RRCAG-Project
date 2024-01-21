/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-30
 * Updated: 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Patel.Dharmi.Business;

namespace Patel.Dharmi.Business.Testing
{
    [TestClass]
    public class FinancialTests
    {
        /*
         * GetPayment(decimal, int, decimal) tests.
         */
        #region GetPayment(decimal, int, decimal) [11 tests]

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_RateBelowZero_Exception()
        {
            decimal rate = -0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        public void GetPayment_RateEqualsZero_Result()
        {
            decimal rate = 0m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);

            decimal expected = 833.33m,
                    actual = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPayment_ValidRate_Result()
        {
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal actual = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue),
                    expected = 1128.25m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPayment_RateEqualsOne_Result()
        {
            decimal rate = 1.00m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal actual = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue),
                    expected = 10002.44m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_RateAboveOne_Exception()
        {
            decimal rate = 1.01m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_PmtPeriodsBelowZero_Exception()
        {
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = -1;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_PmtPeriodsEqualsZero_Exception()
        {
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 0;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        public void GetPayment_ValidPmtPeriods_Result()
        {
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal actual = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue),
                    expected = 1128.25m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_PresentValueBelowZero_Exception()
        {
            decimal rate = 0.05m,
                    presentValue = -10000m;
            int numberOfPaymentPeriods = 12;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPayment_PresentValueEqualsZero_Exception()
        {
            decimal rate = 0.05m,
                    presentValue = 0m;
            int numberOfPaymentPeriods = 12;

            Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
        }

        [TestMethod]
        public void GetPayment_ValidPresentValue_Result()
        {
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal actual = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue),
                    expected = 1128.25m;

            Assert.AreEqual(expected, actual);
        }

        #endregion
    
    }
}
