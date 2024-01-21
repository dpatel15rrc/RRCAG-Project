using Patel.Dharmi.Business;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patel.Dharmi.RRCAGTests
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            TestSalesQuoteConstructor();
            TestSetTradeInAmountMethod();
            TestGetExteriorFinishCostMethod();
            TestGetTotalMethod();

            Console.ReadKey();

        }

        /// <summary>
        /// Testing the SalesQuote(decimal, decimal, decimal) constructor.
        /// </summary>
        static void TestSalesQuoteConstructor()
        {
            Console.WriteLine("\nTesting SalesQuote(decimal, decimal, decimal) constructor. \n");

            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.08m;

            SalesQuote target = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            decimal expectedVehicleSalePrice = 10000m,
                    actualVehicleSalePrice = target.GetVehicleSalePrice();

            decimal expectedTradeInAmount = 5000m,
                    actualTradeInAmount = target.GetTradeInAmount();

            decimal expectedSalesTax = 10000m * 0.08m,
                    actualSalesTax = target.GetSalesTax();

            Console.WriteLine("Test 1");

            Console.WriteLine("Expected VehicleSalePrice : {0}\nActual VehicleSalePrice : {1}\n", expectedVehicleSalePrice, actualVehicleSalePrice);

            Console.WriteLine("Expected TradeInAmount : {0}\nActual TradeInAmount : {1}\n", expectedTradeInAmount, actualTradeInAmount);

            Console.WriteLine("Expected SalesTax : {0}\nActual SalesTax : {1}\n", expectedSalesTax, actualSalesTax);

        }

        /// <summary>
        /// Testing SetTradeInAmount(decimal) : void method.
        /// </summary>
        static void TestSetTradeInAmountMethod()
        {
            Console.WriteLine("\nTesting SetTradeInAmount(decimal) : void method. \n");

            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.08m;

            SalesQuote target = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
            target.SetTradeInAmount(6000m);

            decimal expectedTradeInAmount = 6000m,
                    actualTradeInAmount = target.GetTradeInAmount();

            Console.WriteLine("Test 1");

            Console.WriteLine("Expected TradeInAmount : {0}\nActual TradeInAmount : {1}\n", expectedTradeInAmount, actualTradeInAmount);

        }

        /// <summary>
        /// Testing GetExteriorFinishCost() : decimal method.
        /// </summary>
        static void TestGetExteriorFinishCostMethod()
        {
            Console.WriteLine("\nTesting GetExteriorFinishCost() : decimal method. \n");

            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.08m;
            Accessories accessoriesChosen = Accessories.None;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote target = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal expectedCost = 202.02m,
                    actualCost = target.GetExteriorFinishCost();

            Console.WriteLine("Test 1");

            Console.WriteLine("Expected ExteriorFinishCost : {0}\nActual ExteriorFinishCost : {1}\n", expectedCost, actualCost);

        }

        /// <summary>
        /// Testing GetTotal() : decimal method.
        /// </summary>
        static void TestGetTotalMethod()
        {
            Console.WriteLine("\nTesting GetTotal() : decimal method. \n");

            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.08m;
            Accessories accessoriesChosen = Accessories.All;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote target = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
            decimal expectedTotal = 14290.91m, //10000 + (505.05 + 1010.10 + 1515.15) + 202.02 + (10000 + (505.05 + 1010.10 + 1515.15) + 202.02) * 0.08
                    actualTotal = target.GetTotal();

            Console.WriteLine("Test 1");

            Console.WriteLine("Expected TotalCost : {0}\nActual TotalCost : {1}\n", expectedTotal, actualTotal);

        }

    }

}