/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-10-02
 * Updated: 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Patel.Dharmi.Business;
using System.Net;

namespace Patel.Dharmi.Business.Testing
{
    [TestClass]
    public class CarWashInvoiceTests
    {
        /*
         * CarWashInvoice(decimal, decimal, decimal, decimal) tests.
         */
        #region CarWashInvoice(decimal, decimal, decimal, decimal)  [16 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_PSTBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = -0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        public void Constructor1_PSTEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_PSTEqualsOne_Result()
        {
            decimal provincialSalesTaxRate = 1m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_PSTAboveOne_Exception()
        {
            decimal provincialSalesTaxRate = 1.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        public void Constructor1_GSTEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_GSTEqualsOne_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 1m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_GSTBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = -0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_GSTAboveOne_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 1.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_PackageCostBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = -50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        public void Constructor1_PackageCostEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 0m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("packageCost"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor1_FragranceCostBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = -75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);
        }

        [TestMethod]
        public void Constructor1_FragranceCostEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 0m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("fragranceCost"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_PST_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 0.03m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_GST_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 0.04m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_PackageCost_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("packageCost"),
                    expected = 50m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_FragranceCost_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("fragranceCost"),
                    expected = 75m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * CarWashInvoice(decimal, decimal) tests.
         */
        #region CarWashInvoice(decimal, decimal)  [10 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_PSTBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = -0.03m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);
        }

        [TestMethod]
        public void Constructor2_PSTEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_PSTEqualsOne_Result()
        {
            decimal provincialSalesTaxRate = 1m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_PSTAboveOne_Exception()
        {
            decimal provincialSalesTaxRate = 1.03m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);
        }

        [TestMethod]
        public void Constructor2_GSTEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_GSTEqualsOne_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 1m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 1m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_GSTBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = -0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor2_GSTAboveOne_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 1.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);
        }

        [TestMethod]
        public void Constructor2_PST_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("provincialSalesTaxRate"),
                    expected = 0.03m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_GST_Initialize()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate);

            PrivateObject target = new PrivateObject(invoice, new PrivateType(typeof(Invoice)));

            decimal actual = (decimal)target.GetField("goodsAndServicesTaxRate"),
                    expected = 0.04m;

            Assert.AreEqual(expected, actual);
        }


        #endregion


        /*
         * PackageCost : decimal tests.
         */
        #region PackageCost : decimal  [5 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PackageCost_SetBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.PackageCost = -50;
        }

        [TestMethod]
        public void PackageCost_SetInvalidValue_StateUnchanged()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            try
            {
                invoice.PackageCost = -50m;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(invoice);

                decimal actual = (decimal)target.GetField("packageCost"),
                        expected = 50m;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PackageCost_SetEqualsZero_result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.PackageCost = 0m;

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("packageCost"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void PackageCost_SetValidValue_UpdateState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.PackageCost = 60m;

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("packageCost"),
                    expected = 60m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PackageCost_Get_ReturnState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            decimal actual = invoice.PackageCost,
                    expected = 50m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * FragranceCost : decimal
         */
        #region FragranceCost : decimal  [5 tests]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FragranceCost_SetBelowZero_Exception()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.FragranceCost = -75;
        }

        [TestMethod]
        public void FragranceCost_SetInvalidValue_StateUnchanged()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            try
            {
                invoice.FragranceCost = -50m;

                Assert.Fail("The Exception was not thrown");
            }
            catch
            {
                PrivateObject target = new PrivateObject(invoice);

                decimal actual = (decimal)target.GetField("fragranceCost"),
                        expected = 75m;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void FragranceCost_SetEqualsZero_Result()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.FragranceCost = 0m;

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("fragranceCost"),
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FragranceCost_SetValidValue_UpdateState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.FragranceCost = 80m;

            PrivateObject target = new PrivateObject(invoice);

            decimal actual = (decimal)target.GetField("fragranceCost"),
                    expected = 80m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FragranceCost_Get_ReturnState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            decimal actual = invoice.FragranceCost,
                    expected = 75m;

            Assert.AreEqual(expected, actual);
        }
        #endregion


        /*
         * ProvincialSalesTaxCharged : decimal tests
         */
        #region ProvincialSalesTaxCharged : decimal  [1 tests]
        [TestMethod]
        public void ProvincialSalesTaxCharged_Get_ReturnState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            decimal actual = invoice.ProvincialSalesTaxCharged,
                    expected = 0m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * GoodsAndServicesTaxCharged : decimal tests.
         */
        #region GoodsAndServicesTaxCharged : decimal  [1 tests]
        [TestMethod]
        public void GoodsAndServicesTaxCharged_Get_ReturnState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            decimal actual = invoice.GoodsAndServicesTaxCharged,
                    expected = (50m + 75m) * 0.04m;

            Assert.AreEqual(expected, actual);
        }

        #endregion


        /*
         * SubTotal : decimal tests.
         */
        #region SubTotal : decimal  [1 tests]
        [TestMethod]
        public void SubTotal_Get_ReturnState()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            decimal actual = invoice.SubTotal,
                    expected = 50m + 75m;

            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}
