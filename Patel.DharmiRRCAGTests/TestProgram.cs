/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-18
 * Updated: 
 */

using Patel.Dharmi.Business;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patel.Dharmi.RRCAGTests
{
    /// <summary>
    /// Represents a test program to test GetPayment(decimal, int, decimal) method.
    /// </summary>
    class TestProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing GetPayment(decimal, int, decimal) method.");

            Console.WriteLine("\n\nTest cases for ' decimal rate ' parameter: \n");
            TestGetPayment_RateBelowZero_ExceptionThrown();
            TestGetPayment_RateEqualsZero();
            TestGetPayment_ValidRate();
            TestGetPayment_RateEqualsOne();
            TestGetPayment_RateAboveOne_ExceptionThrown();

            Console.WriteLine("\n\nTest cases for ' int paymentPeriods ' parameter: ");
            TestGetPayment_PmtPeriodsBelowZero_ExceptionThrown();
            TestGetPayment_PmtPeriodsEqualsZero_ExceptionThrown();
            TestGetPayment_ValidNumberOfPaymentPeriods();

            Console.WriteLine("\n\nTest cases for ' decimal presentValue ' parameter: ");
            TestGetPayment_PresentValueBelowZero_ExceptionThrown();
            TestGetPayment_PresentValueEqualsZero_ExceptionThrown();
            TestGetPayment_ValidPresentValue();

            Console.ReadKey();
        }

        /// <summary>
        /// Utility method to obtain only the message from an Exception object.
        /// </summary>
        /// <param name="exceptionMessage">The Exception's Message state.</param>
        /// <returns>The Exception's message with the parameter omitted.</returns>
        public static string GetExceptionMessage(string exceptionMessage)
        {
            return new System.IO.StringReader(exceptionMessage).ReadLine();
        }

        /// <summary>
        /// Testing the Rate parameter when its value is less zero.
        /// </summary>
        static void TestGetPayment_RateBelowZero_ExceptionThrown()
        {
            Console.WriteLine("TEST CASE 1: When rate < 0.");
            decimal result;
            decimal rate = -0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than 0. Parameter name: rate.");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be less than 0. Parameter name: rate");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName) );
            }
        }

        /// <summary>
        /// Testing the Rate parameter when its value is equal to zero.
        /// </summary>
        static void TestGetPayment_RateEqualsZero()
        {
            Console.WriteLine("\nTEST CASE 2: When rate = 0.00 .");
            decimal result;
            decimal rate = 0.00m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal expected = 833.33m;
            // 1000 / 12; 

            result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + result);
        }

        /// <summary>
        /// Testing the Rate parameter when its value is more than 0 but less than 1.
        /// </summary>
        static void TestGetPayment_ValidRate()
        {
            Console.WriteLine("\nTEST CASE 3: When  0 < rate < 1.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal expected = 1128.25m;
            //0.05m * (0 + 10000m * (decimal)Math.Pow((double)(1 + 0.05m), (double)12)) / (((decimal)Math.Pow((double)(1 + 0.05m), (double)12) - 1) * (1 + 0.05m * 0));

            result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + result);
        }

        /// <summary>
        /// Testing the Rate parameter when its value is more than 0 but less than 1.
        /// </summary>
        static void TestGetPayment_RateEqualsOne()
        {
            Console.WriteLine("\nTEST CASE 4: When rate = 1.");
            decimal result;
            decimal rate = 1.00m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal expected = 10002.44m;
            //1.00m * (0 + 10000m * (decimal)Math.Pow((double)(1 + 1.00m), (double)12)) / (((decimal)Math.Pow((double)(1 + 1.00m), (double)12) - 1) * (1 + 1.00m * 0));

            result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + result);
        }

        /// <summary>
        /// Testing the Rate parameter when its value is more than 1.
        /// </summary>
        static void TestGetPayment_RateAboveOne_ExceptionThrown()
        {
            Console.WriteLine("\nTEST CASE 5: When rate > 1.");
            decimal result;
            decimal rate = 1.5m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than 0. Parameter name: rate.");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be greater than 1. Parameter name: rate");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName) );
            }

        }

        /// <summary>
        /// Testing the numberOfPaymentPeriods parameter when its value is less than zero.
        /// </summary>
        static void TestGetPayment_PmtPeriodsBelowZero_ExceptionThrown()
        {
            Console.WriteLine("\nTEST CASE 6: When numberOfPaymentPeriods < 0.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = -1;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: numberOfPaymentPeriods");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: numberOfPaymentPeriods");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName));
            }

        }

        /// <summary>
        /// Testing the numberOfPaymentPeriods parameter when its value is equal to zero.
        /// </summary>
        static void TestGetPayment_PmtPeriodsEqualsZero_ExceptionThrown()
        {
            Console.WriteLine("\nTEST CASE 7: When numberOfPaymentPeriods = 0.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 0;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: numberOfPaymentPeriods");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: numberOfPaymentPeriods");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName));
            }

        }

        /// <summary>
        /// Testing the numberOfPaymentPeriods parameter when its value is more than zero.
        /// </summary>
        static void TestGetPayment_ValidNumberOfPaymentPeriods()
        {
            Console.WriteLine("\nTEST CASE 8: When numberOfPaymentPeriods > 0.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = 10000m;
            int numberOfPaymentPeriods = 12;

            decimal expected = 1128.25m;
            //0.05m * (0 + 10000m * (decimal)Math.Pow((double)(1 + 0.05m), (double)12)) / (((decimal)Math.Pow((double)(1 + 0.05m), (double)12) - 1) * (1 + 0.05m * 0));

            result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + result);
        }

        /// <summary>
        /// Testing the presentValue parameter when its value is below zero.
        /// </summary>
        static void TestGetPayment_PresentValueBelowZero_ExceptionThrown()
        {
            Console.WriteLine("\nTEST CASE 9: When presentValue < 0.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = -10000m;
            int numberOfPaymentPeriods = 12;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: presentValue");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: presentValue");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName));
            }

        }

        /// <summary>
        /// Testing the presentValue parameter when its value is equal to zero.
        /// </summary>
        static void TestGetPayment_PresentValueEqualsZero_ExceptionThrown()
        {
            Console.WriteLine("\nTEST CASE 10: When presentValue = 0.");
            decimal result;
            decimal rate = 0.05m,
                    presentValue = 0m;
            int numberOfPaymentPeriods = 12;

            try
            {
                result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: presentValue");
                Console.WriteLine("Actual: " + result);
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Expected: The argument cannot be less than or equal to 0. Parameter name: presentValue");
                Console.WriteLine("Actual: {0} Parameter name: {1}", GetExceptionMessage(exception.Message), (exception.ParamName));
            }

        }

        /// <summary>
        /// Testing the presentValue parameter when its value is more than zero.
        /// </summary>
        static void TestGetPayment_ValidPresentValue()
        {
            Console.WriteLine("\nTEST CASE 11: When presentValue > 0.");
            decimal result;
            decimal rate = 0.0575m,
                    presentValue = 19241.41m;
            int numberOfPaymentPeriods = 12;

            decimal expected = 1128.25m;
            //0.05m * (0 + 10000m * (decimal)Math.Pow((double)(1 + 0.05m), (double)12)) / (((decimal)Math.Pow((double)(1 + 0.05m), (double)12) - 1) * (1 + 0.05m * 0));

            result = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + result);
        }

    }

}
