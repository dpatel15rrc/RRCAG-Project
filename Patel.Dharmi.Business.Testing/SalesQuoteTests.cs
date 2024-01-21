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
using System.ComponentModel;

namespace Patel.Dharmi.Business.Testing
{
    [TestClass]
    public class SalesQuoteTests
    {
        /*
         * SalesQuote(decimal, decimal, decimal, Accessories, ExteriorFinish) tests.
         */
        #region  SalesQuote(decimal, decimal, decimal, Accessories, ExteriorFinish)  [15 tests]

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_VehicleSalePriceBelowZero_Exception()
        {
            decimal vehicleSalePrice = -10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_VehicleSalePriceEqualsZero_Exception()
        {
            decimal vehicleSalePrice = 0m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_TradeInAmountBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = -5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        public void Constructor1_TradeInAmountEqualsZero_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 0m,
            salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_SalesTaxRateBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = -0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        public void Constructor1_SalesTaxRateEqualsZero_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 0m,
            salesTaxRate = 0m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_SalesTaxRateEqualsOne_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 5000m,
            salesTaxRate = 1m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_SalesTaxRateAboveOne_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 1.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        public void Constructor1_InvalidAccessory_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = (Accessories)8;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        public void Constructor1_InvalidExteriorFinish_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = (Accessories)1;
            ExteriorFinish exteriorFinishChosen = (ExteriorFinish)4;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);
        }

        [TestMethod]
        public void Constructor1_VehicleSalePrice_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("vehicleSalePrice"),
                    expected = 10000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_TradeInAmount_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 5000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_SalesTaxRate_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"),
                    expected = 0.5m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_AccessoriesChosen_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            Accessories actual = (Accessories)target.GetField("accessoriesChosen"),
                        expected = Accessories.StereoSystem;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_ExteriorFinishChosen_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            PrivateObject target = new PrivateObject(quote);

            ExteriorFinish actual = (ExteriorFinish)target.GetField("exteriorFinishChosen"),
                           expected = ExteriorFinish.Standard;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        /*
         * SalesQuote(decimal, decimal, decimal) tests.
         */
        #region SalesQuote(decimal, decimal, decimal)  [11 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_VehicleSalePriceBelowZero_Exception()
        {
            decimal vehicleSalePrice = -10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_VehicleSalePriceEqualsZero_Exception()
        {
            decimal vehicleSalePrice = 0m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_TradeInAmountBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = -5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
        }

        [TestMethod]
        public void Constructor2_TradeInAmountEqualsZero_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 0m,
            salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_SalesTaxRateBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = -0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
        }

        [TestMethod]
        public void Constructor2_SalesTaxRateEqualsZero_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 5000m,
            salesTaxRate = 0m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"), 
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_SalesTaxRateEqualsOne_Result()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 5000m,
            salesTaxRate = 1m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_SalesTaxRateAboveOne_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 1.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);
        }

        [TestMethod]
        public void Constructor2_VehicleSalePrice_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("vehicleSalePrice"),
                    expected = 10000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_TradeInAmount_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 5000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_SalesTaxRate_Initialize()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate);

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("salesTaxRate"),
                    expected = 0.5m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * VehicleSalePrice : decimal tests.
         */
        #region  VehicleSalePrice : decimal  [4 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VehicleSalePrice_SetBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.VehicleSalePrice = -10000m;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VehicleSalePrice_SetEqualsZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.VehicleSalePrice = 0m;
        }

        [TestMethod]
        public void VehicleSalePrice_SetInvalidValue_StateUnchanged()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            try
            {
                quote.VehicleSalePrice = -100000m;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(quote);

                decimal actual = (decimal)target.GetField("vehicleSalePrice"),
                        expected = 10000m;

                Assert.AreEqual(expected, actual);  
            }
        }

        [TestMethod]
        public void VehicleSalePrice_SetValidValue_UpdateState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.VehicleSalePrice = 15000m;

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("vehicleSalePrice"),
                    expected = 15000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VehicleSalePrice_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.VehicleSalePrice,
                    expected = 10000m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * TradeInAmount : decimal tests
         */
        #region TradeInAmount : decimal  [4 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TradeInAmount_SetBelowZero_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.TradeInAmount = -5000m;
        }

        [TestMethod]
        public void TradeInAmount_SetInvalidValue_StateUnchanged()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            try
            {
                quote.VehicleSalePrice = -100000m;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(quote);

                decimal actual = (decimal)target.GetField("vehicleSalePrice"),
                        expected = 10000m;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TradeInAmount_SetEqualsZero_UpdateState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.TradeInAmount = 0;

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TradeInAmount_SetValidValue_UpdateState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.TradeInAmount = 6000m;

            PrivateObject target = new PrivateObject(quote);

            decimal actual = (decimal)target.GetField("tradeInAmount"),
                    expected = 6000m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TradeInAmount_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.TradeInAmount,
                    expected = 5000m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * AccessoriesChosen : Accessories tests.
         */
        #region AccessoriesChosen : Accessories  [4 tests]
        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        public void AccessoriesChosen_SetInvalidAccessory_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.AccessoriesChosen = (Accessories)10;
        }

        [TestMethod]
        public void AccessoriesChosen_SetInvalidValue_StateUnchanged()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            try
            {
                quote.AccessoriesChosen = (Accessories)10;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(quote);

                Accessories actual = (Accessories)target.GetField("accessoriesChosen"),
                        expected = Accessories.StereoSystem;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void AccessoriesChosen_SetValidValue_UpdateState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.AccessoriesChosen = Accessories.LeatherInterior;

            PrivateObject target = new PrivateObject(quote);

            Accessories actual = (Accessories)target.GetField("accessoriesChosen"),
                        expected = Accessories.LeatherInterior;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AccessoriesChosen_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            Accessories actual = quote.AccessoriesChosen,
                        expected = Accessories.StereoSystem;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * ExteriorFinishChosen : ExteriorFinish tests
         */
        #region ExteriorFinishChosen : ExteriorFinish  [4 tests]
        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        public void ExteriorFinishChosen_SetInvalidValue_Exception()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.ExteriorFinishChosen = (ExteriorFinish)10;
        }

        [TestMethod]
        public void ExteriorFinishChosen_SetInvalidValue_StateUnchanged()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            try
            {
                quote.ExteriorFinishChosen = (ExteriorFinish)10;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(quote);

                ExteriorFinish actual = (ExteriorFinish)target.GetField("exteriorFinishChosen"),
                        expected = ExteriorFinish.Standard;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ExteriorFinishChosen_SetValidValue_UpdateState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.ExteriorFinishChosen = ExteriorFinish.Pearlized;

            PrivateObject target = new PrivateObject(quote);

            ExteriorFinish actual = (ExteriorFinish)target.GetField("exteriorFinishChosen"),
                           expected = ExteriorFinish.Pearlized;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExteriorFinishChosen_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
            tradeInAmount = 5000m,
            salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            ExteriorFinish actual = quote.ExteriorFinishChosen,
                           expected = ExteriorFinish.Standard;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * AccessoryCost : decimal tests.
         */
        #region AccessoryCost : decimal [1 test]
        [TestMethod]
        public void AccessoryCost_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.AccessoryCost,
                    expected = 505.05m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * FinishCost : decimal
         */
        #region FinishCost : decimal [1 test]
        [TestMethod]
        public void FinishCost_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.FinishCost,
                    expected = 202.02m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * TotalOptions : decimal tests.
         */
        #region TotalOptions : decimal [1 test]
        [TestMethod]
        public void TotalOptions_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.AccessoryCost + quote.FinishCost,
                    expected = 505.05m + 202.02m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * SubTotal : decimal tests.
         */
        #region SubTotal : decimal [1 test]
        [TestMethod]
        public void SubTotal_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.SubTotal,
                    expected = 10000m + 707.07m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * SalesTax : decimal tests.
         */
        #region SalesTax : decimal [1 test]
        [TestMethod]
        public void SalesTax_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.SalesTax,
                    expected = Math.Round((10000m + 707.07m) * 0.5m , 2);

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * Total : decimal tests.
         */
        #region Total : decimal [1 test]
        [TestMethod]
        public void Total_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.Total,
                    expected = Math.Round((10707.07m + 5353.54m), 2);

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * AmountDue : decimal
         */
        #region AmountDue : decimal [1 test]
        [TestMethod]
        public void AmountDue_Get_ReturnState()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.5m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            decimal actual = quote.AmountDue,
                    expected = Math.Round((16060.61m - 5000), 2);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    
    }
}
