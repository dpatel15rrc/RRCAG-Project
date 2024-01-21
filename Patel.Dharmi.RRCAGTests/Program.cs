/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-10-18
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patel.Dharmi.Business;

namespace Patel.Dharmi.RRCAGTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event Handling for SalesQuote Class.");
            SalesQuoteEvents();

            Console.WriteLine("\nEvent Handling for CarWashInvoice Class.");
            CarWashInvoiceEvents();

            Console.ReadKey();
        }

        static void SalesQuoteEvents()
        {
            decimal vehicleSalePrice = 10000m,
                    tradeInAmount = 5000m,
                    salesTaxRate = 0.05m;
            Accessories accessoriesChosen = Accessories.StereoSystem;
            ExteriorFinish exteriorFinishChosen = ExteriorFinish.Standard;

            SalesQuote quote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

            quote.VehicleSalePriceChanged += HandleVehicleSalePriceChanged;
            quote.VehicleSalePrice = 15000m;

            quote.TradeInAmountChanged += HandleTradeInAmountChanged;
            quote.TradeInAmount = 7500m;

            quote.AccessoriesChosenChanged += HandleAccessoriesChosenChanged;
            quote.AccessoriesChosen = Accessories.ComputerNavigation;

            quote.ExteriorFinishChosenChanged += HandleExteriorFinishChosenChanged;
            quote.ExteriorFinishChosen = ExteriorFinish.Pearlized;

        }

        static void CarWashInvoiceEvents()
        {
            decimal provincialSalesTaxRate = 0.03m,
                    goodsAndServicesTaxRate = 0.04m,
                    packageCost = 50m,
                    fragranceCost = 75m;

            CarWashInvoice invoice = new CarWashInvoice(provincialSalesTaxRate, goodsAndServicesTaxRate, packageCost, fragranceCost);

            invoice.ProvincialSalesTaxRateChanged += HandleProvincialSalesTaxRateChanged;
            invoice.ProvincialSalesTaxRate = 0.05m;

            invoice.GoodsAndServicesTaxRateChanged += HandleGoodsAndServicesTaxRateChanged;
            invoice.GoodsAndServicesTaxRate = 0.05m;

            invoice.PackageCostChanged += HandlePackageCostChanged;
            invoice.PackageCost = 60m;

            invoice.FragranceCostChanged += HandleFragranceCostChanged;
            invoice.FragranceCost = 60m;
        }

        /// <summary>
        /// Handles the VehicleSalePriceChanged event of the SalesQuote.
        /// </summary>
        private static void HandleVehicleSalePriceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Vehicle Sale Price was changed.");
        }

        /// <summary>
        /// Handles the TradeInAmountChanged event of the SalesQuote.
        /// </summary>
        private static void HandleTradeInAmountChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Trade In Amount was changed.");
        }

        /// <summary>
        /// Handles the AccessoriesChosenChanged event of the SalesQuote.
        /// </summary>
        private static void HandleAccessoriesChosenChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Accessories Chosen was changed.");
        }

        /// <summary>
        /// Handles the ExteriorFinishChosenChanged event of the SalesQuote.
        /// </summary>
        private static void HandleExteriorFinishChosenChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Exterior Finish Chosen was changed.");
        }

        /// <summary>
        ///  Handles ProvincialSalesTaxRateChanged event of the Invoice.
        /// </summary>
        private static void HandleProvincialSalesTaxRateChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Provincial Sales Tax Rate was changed.");
        }

        /// <summary>
        /// Handles GoodsAndServicesTaxRateChanged event of the Invoice.
        /// </summary>
        private static void HandleGoodsAndServicesTaxRateChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Goods and Services Tax Rate was changed.");
        }

        /// <summary>
        /// Handles PackageCostChanged event of the CarWashInvoice.
        /// </summary>
        private static void HandlePackageCostChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Package Cost was changed.");
        }

        /// <summary>
        /// Handles FragranceCostChanged event of the CarWashInvoice.
        /// </summary>
        private static void HandleFragranceCostChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Fragrance Cost was changed.");
        }
    }
}
