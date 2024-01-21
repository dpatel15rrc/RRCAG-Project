/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-16
 * Updated: 2023-10-17 (assignment 4)
 */

using System;
using System.Diagnostics.Contracts;

namespace Patel.Dharmi.Business
{
    /// <summary>
    /// Contains functionality that supports the business process of creating an invoice.
    /// </summary>
    public abstract class Invoice
    {
        private decimal provincialSalesTaxRate;
        private decimal goodsAndServicesTaxRate;

        /// <summary>
        /// Occurs when the provincial sales tax rate of the Invoice changes.
        /// </summary>
        public event EventHandler ProvincialSalesTaxRateChanged;

        /// <summary>
        /// Occurs when the goods and services tax rate of the Invoice changes.
        /// </summary>
        public event EventHandler GoodsAndServicesTaxRateChanged;

        /// <summary>
        /// Gets and sets the provincial sales tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the property is set to less than 0, or when the property is set to greater than 1. </exception>
        public decimal ProvincialSalesTaxRate
        {
            get
            {
                return provincialSalesTaxRate;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");

                if (value > 1)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");

                if(value != this.provincialSalesTaxRate)
                {
                    this.provincialSalesTaxRate = value;
                    OnProvincialSalesTaxRateChanged();
                }
            }
        }

        /// <summary>
        /// Raises the ProvincialSalesTaxRateChanged event.
        /// </summary>
        protected virtual void OnProvincialSalesTaxRateChanged()
        {
            if (ProvincialSalesTaxRateChanged != null)
                ProvincialSalesTaxRateChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets and sets the goods and services tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the property is set to less than 0, or when the property is set to greater than 1. </exception>
        public decimal GoodsAndServicesTaxRate
        {
            get
            {
                return goodsAndServicesTaxRate;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");

                if (value > 1)
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");

                if(value != this.goodsAndServicesTaxRate)
                {
                    this.goodsAndServicesTaxRate = value;
                    OnGoodsAndServicesTaxRateChanged();
                }
            }
        }

        /// <summary>
        ///  Raises the GoodsAndServicesTaxRateChanged event.
        /// </summary>
        protected virtual void OnGoodsAndServicesTaxRateChanged()
        {
            if (GoodsAndServicesTaxRateChanged != null)
               GoodsAndServicesTaxRateChanged(this, new EventArgs());
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer.
        /// </summary>
        public abstract decimal ProvincialSalesTaxCharged
        {
            get;
        }

        /// <summary>
        ///  Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public abstract decimal GoodsAndServicesTaxCharged
        {
            get;
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public abstract decimal SubTotal
        {
            get;
        }

        /// <summary>
        /// Gets the total of the Invoice. The total is the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                return Math.Round(SubTotal + ProvincialSalesTaxCharged + GoodsAndServicesTaxCharged, 2);
            }
        }

        /// <summary>
        /// Initializes an instance of Invoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTax"> The rate of provincial tax charged to a customer. </param>
        /// <param name="goodsAndServicesTaxRate"> The rate of goods and services tax charged to a customer. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the provincial sales tax rate is less than 0, or when the provincial sales tax rate is greater than 1, or when the goods and services tax rate is less than 0, or when the goods and services tax rate is greater than 1. </exception>
        public Invoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
        {
            this.ProvincialSalesTaxRate = provincialSalesTaxRate;
            this.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;
        }

    }

}