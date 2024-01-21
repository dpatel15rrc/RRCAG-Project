/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-15
 * Updated: 2023-09-28 (assignment 2 corrections)
 * Updated: 2023-10-17 (assignment 4)
 */

using System;
using System.ComponentModel;

namespace Patel.Dharmi.Business
{
    /// <summary>
    /// Represents a sales quote.
    /// </summary>
    public class SalesQuote
    {
        private decimal vehicleSalePrice;
        private decimal tradeInAmount;
        private decimal salesTaxRate;
        private Accessories accessoriesChosen;
        private const decimal STEREO_COST = 505.05m;
        private const decimal LEATHER_COST = 1010.10m;
        private const decimal COMPUTER_NAVIGATION_COST = 1515.15m;
        private ExteriorFinish exteriorFinishChosen;
        private const decimal STANDARD_COST = 202.02m;
        private const decimal PEARLIZED_COST = 404.04m;
        private const decimal CUSTOM_COST = 606.06m;

        /// <summary>
        /// Occurs when the price of the vehicle being quoted on changes.
        /// </summary>
        public event EventHandler VehicleSalePriceChanged;

        /// <summary>
        /// Occurs when the amount for the trade in vehicle changes.
        /// </summary>
        public event EventHandler TradeInAmountChanged;

        /// <summary>
        /// Occurs when the chosen accessories change.
        /// </summary>
        public event EventHandler AccessoriesChosenChanged;

        /// <summary>
        /// Occurs when the chosen exterior finish changes.
        /// </summary>
        public event EventHandler ExteriorFinishChosenChanged;

        /// <summary>
        /// Gets and sets the sale price of the vehicle.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the property is set to less than 0.</exception>
        public decimal VehicleSalePrice
        {
            get
            {
                return vehicleSalePrice;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than or equal to 0.");

                if (value != this.vehicleSalePrice)
                {
                    this.vehicleSalePrice = value;
                    OnVehicleSalePriceChanged();
                }
            }
        }

        /// <summary>
        /// Raises the VehiclePriceChanged event.
        /// </summary>
        protected virtual void OnVehicleSalePriceChanged()
        {
            if(VehicleSalePriceChanged != null)
                VehicleSalePriceChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets and sets the trade in amount.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the property is set to less than 0.</exception>
        public decimal TradeInAmount
        {
            get
            {
                return tradeInAmount;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                
                if(value != this.tradeInAmount)
                {
                    this.tradeInAmount = value;
                    OnTradeInAmountChanged();
                }
            }
        }

        /// <summary>
        /// Raises the TradeInAmountChanged event.
        /// </summary>
        protected virtual void OnTradeInAmountChanged()
        {
            if (TradeInAmountChanged != null)
                TradeInAmountChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets and sets the accessories that were chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the property is set to an invalid value.</exception>
        public Accessories AccessoriesChosen
        {
            get
            {
                return accessoriesChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(Accessories), value))
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");

                if(value != this.accessoriesChosen)
                {
                    this.accessoriesChosen = value;
                    OnAccessoriesChosenChanged();
                }
            }
        }

        /// <summary>
        /// Raises the AccessoriesChosenChanged event.
        /// </summary>
        protected virtual void OnAccessoriesChosenChanged()
        {
            if (AccessoriesChosenChanged != null)
                AccessoriesChosenChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets and sets the exterior finish that was chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the property is set to an invalid value.</exception>
        public ExteriorFinish ExteriorFinishChosen
        {
            get
            {
                return exteriorFinishChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(ExteriorFinish), value))
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");

                if(value != this.exteriorFinishChosen)
                {
                    this.exteriorFinishChosen = value;
                    OnExteriorFinishChosenChanged();
                }
            }
        }

        /// <summary>
        /// Raises the ExteriorFinishChosenChanged event.
        /// </summary>
        protected virtual void OnExteriorFinishChosenChanged()
        {
            if (ExteriorFinishChosenChanged != null)
                ExteriorFinishChosenChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets the cost of accessories chosen.
        /// </summary>
        public decimal AccessoryCost
        {
            get
            {
                decimal totalAccessoryCost = 0m;

                switch (accessoriesChosen)
                {
                    case Accessories.StereoSystem:
                        totalAccessoryCost += STEREO_COST;
                        break;

                    case Accessories.LeatherInterior:
                        totalAccessoryCost += LEATHER_COST;
                        break;

                    case Accessories.ComputerNavigation:
                        totalAccessoryCost += COMPUTER_NAVIGATION_COST;
                        break;

                    case Accessories.StereoAndLeather:
                        totalAccessoryCost += (STEREO_COST + LEATHER_COST);
                        break;

                    case Accessories.StereoAndNavigation:
                        totalAccessoryCost += (STEREO_COST + COMPUTER_NAVIGATION_COST);
                        break;

                    case Accessories.LeatherAndNavigation:
                        totalAccessoryCost += (LEATHER_COST + COMPUTER_NAVIGATION_COST);
                        break;

                    case Accessories.All:
                        totalAccessoryCost += (STEREO_COST + LEATHER_COST + COMPUTER_NAVIGATION_COST);
                        break;

                }

                return totalAccessoryCost;
            }
        }

        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal FinishCost
        {
            get
            {
                decimal totalExteriorFinishCost = 0m;

                switch (exteriorFinishChosen)
                {
                    case ExteriorFinish.Standard:
                        totalExteriorFinishCost = STANDARD_COST;
                        break;

                    case ExteriorFinish.Pearlized:
                        totalExteriorFinishCost = PEARLIZED_COST;
                        break;

                    case ExteriorFinish.Custom:
                        totalExteriorFinishCost = CUSTOM_COST;
                        break;

                }

                return totalExteriorFinishCost;
            }
        }

        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal TotalOptions
        {
            get
            {
                return Math.Round(AccessoryCost + FinishCost, 2);
            }
        }

        /// <summary>
        /// Gets the sum of the vehicle’s sale price and the Accessory and Finish Cost
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return Math.Round(VehicleSalePrice + TotalOptions, 2);
            }
        }

        /// <summary>
        /// Gets the amount of tax to charge based on the subtotal 
        /// </summary>
        public decimal SalesTax
        {
            get
            {
                return Math.Round(SubTotal * salesTaxRate, 2);
            }
        }

        /// <summary>
        /// Gets the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                return Math.Round(SubTotal + SalesTax, 2);
            }
        }

        /// <summary>
        /// Gets the result of subtracting the trade-in amount from the total.
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                return Math.Round(Total - TradeInAmount, 2);
            }
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in value, 
        /// sales tax rate, accessories chosen and exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice"> The selling price of the vehicle being sold. </param>
        /// <param name="tradeInAmount"> The amount offered to the customer for the trade in of their vehicle. </param>
        /// <param name="salesTaxRate"> The tax rate applied to the sale of a vehicle. </param>
        /// <param name="accessoriesChosen"> The value of the chosen accessories. </param>
        /// <param name="exteriorFinishChosen"> The value of the chosen exterior finish.  </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the vehicle sale price is less than or equal to 0, or when the trade in amount is less than 0, or when the sales tax rate is less than 0, or when the sales tax rate is greater than 1.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown when the accessories chosen is an invalid argument, or when when the exterior finish chosen is an invalid argument. </exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate, Accessories accessoriesChosen, ExteriorFinish exteriorFinishChosen)
        {
            if (salesTaxRate < 0)
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be less than 0.");

            if (salesTaxRate > 1)
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be greater than 1.");

            VehicleSalePrice = vehicleSalePrice;
            TradeInAmount = tradeInAmount;
            this.salesTaxRate = salesTaxRate;
            AccessoriesChosen = accessoriesChosen;
            ExteriorFinishChosen = exteriorFinishChosen;
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in amount, sales tax rate, 
        /// no accessories chosen and no exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice"> The selling price of the vehicle being sold. </param>
        /// <param name="tradeInAmount"> The amount offered to the customer for the trade in of their vehicle. </param>
        /// <param name="salesTaxRate"> The tax rate applied to the sale of a vehicle. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the vehicle sale price is less than or equal to 0, or when the trade in amount is less than 0, or when the sales tax rate is less than 0, or when the sales tax rate is greater than 1.</exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate)
            : this(vehicleSalePrice, tradeInAmount, salesTaxRate, Accessories.None, ExteriorFinish.None)
        {

        }

    }

}