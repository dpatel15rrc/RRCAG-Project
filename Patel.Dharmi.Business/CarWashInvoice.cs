/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-16
 * Updated: 2023-10-17 (assignment 4)
 */

using System;

namespace Patel.Dharmi.Business
{
    /// <summary>
    /// This class contains functionality that supports the business process of creating an invoice for the car wash department. 
    /// The CarWashInvoice class derives from the Invoice class.
    /// </summary>
    public class CarWashInvoice : Invoice
    {
        private decimal packageCost;
        private decimal fragranceCost;

        /// <summary>
        /// Occurs when the package cost changes.
        /// </summary>
        public event EventHandler PackageCostChanged;

        /// <summary>
        /// Occurs when the fragrance cost changes.
        /// </summary>
        public event EventHandler FragranceCostChanged;

        /// <summary>
        /// Gets and sets the amount charged for the chosen package.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the property is set to less than 0. </exception>
        public decimal PackageCost
        {
            get
            {
                return packageCost;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");

                if(value != this.packageCost)
                {
                    this.packageCost = value;
                    OnPackageCostChanged();
                }
            }
        }

        /// <summary>
        /// Raises the PackageCostChanged event.
        /// </summary>
        protected virtual void OnPackageCostChanged()
        {
            if (PackageCostChanged != null)
                PackageCostChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen fragrance.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the property is set to less than 0. </exception>
        public decimal FragranceCost
        {
            get
            {
                return fragranceCost;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");

                if(value != this.fragranceCost)
                {
                    this.fragranceCost = value;
                    OnFragranceCostChanged();
                }
            }
        }

        /// <summary>
        /// Raises the FragranceCostChanged event.
        /// </summary>
        protected virtual void OnFragranceCostChanged()
        {
            if (FragranceCostChanged != null)
                FragranceCostChanged(this, new EventArgs());
        }

        /// <summary>
        ///  Gets the amount of provincial sales tax charged to the customer. 
        ///  No provincial sales tax is charged for a car wash.
        /// </summary>
        public override decimal ProvincialSalesTaxCharged
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// The tax is calculated by multiplying the tax rate by the subtotal.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return Math.Round(GoodsAndServicesTaxRate * SubTotal, 2);
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice. 
        /// The subtotal is the sum of the package and fragrance cost.
        /// </summary>
        public override decimal SubTotal
        {
            get
            {
                return PackageCost + FragranceCost;
            }
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods, services tax rate, package cost and fragrance cost.
        /// </summary>
        /// <param name="provincialSalesTaxRate"> The rate of provincial tax charged to a customer. </param>
        /// <param name="goodsAndServicesTaxRate"> The rate of goods and services tax charged to a customer. </param>
        /// <param name="packageCost"> The cost of the chosen package. </param>
        /// <param name="fragranceCost"> The cost of the chosen fragrance. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the provincial sales tax rate is less than 0, or when the provincial sales tax rate is greater than 1, or when the goods and services tax rate is less than 0, or when the goods and services tax rate is greater than 1, or when the package cost is less than 0, or when the fragrance cost is less than 0. </exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate, decimal packageCost, decimal fragranceCost)
            : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            PackageCost = packageCost;
            FragranceCost = fragranceCost;
        }

        /// <summary>
        ///  Initializes an instance of CarWashInvoice with a provincial and goods and services tax rates. 
        ///  The package cost and fragrance cost are zero.
        /// </summary>
        /// <param name="provincialSalesTaxRate"> The rate of provincial tax charged to a customer. </param>
        /// <param name="goodsAndServicesTaxRate"> The rate of goods and services tax charged to a customer. </param>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
            : this(provincialSalesTaxRate, goodsAndServicesTaxRate, 0 , 0)
        {

        }

    }

}
