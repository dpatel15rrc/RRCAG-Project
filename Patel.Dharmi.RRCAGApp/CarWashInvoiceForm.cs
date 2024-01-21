/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-11-23
 * Updated: 
 */

using ACE.BIT.ADEV.Forms;
using Patel.Dharmi.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patel.Dharmi.RRCAGApp
{
    /// <summary>
    /// Represents a Car Wash Invoice Form.
    /// </summary>
    public partial class CarWashInvoiceForm : ACE.BIT.ADEV.Forms.CarWashInvoiceForm
    {
        private CarWashInvoice invoice;
        private BindingSource invoiceSource;

        /// <summary>
        /// Initializes an instance of the CarWashInvoiceForm class.
        /// </summary>
        public CarWashInvoiceForm()
        {
            InitializeComponent();

            this.invoiceSource = new BindingSource();
            this.invoiceSource.DataSource = typeof(CarWashInvoice);
        }

        /// <summary>
        /// Transfer the data from CarWashForm.
        /// </summary>
        public CarWashInvoice InvoiceData
        {
            //access the data from car wash form.
            get
            {
                return invoice;
            }

            //set the data for this form.
            set
            {
                this.invoice = value;
                BindInvoiceData();
            }
        }

        /// <summary>
        /// Sets the data bindings for the form.
        /// </summary>
        private void BindInvoiceData()
        {
            //set the data source to transferred data.
            this.invoiceSource.DataSource = this.InvoiceData;

            //check is the data source is not null before binding.
            if (InvoiceData != null)
            {
                //bind package cost to label.
                Binding pkgPriceBind = new Binding("Text", this.invoiceSource, "PackageCost");
                pkgPriceBind.FormattingEnabled = true;
                pkgPriceBind.FormatString = "C";
                this.lblPackagePrice.DataBindings.Add(pkgPriceBind);

                //bind fragrance cost to label.
                Binding frgPriceBind = new Binding("Text", this.invoiceSource, "FragranceCost");
                frgPriceBind.FormattingEnabled = true;
                frgPriceBind.FormatString = "0.00";
                this.lblFragrancePrice.DataBindings.Add(frgPriceBind);

                //bind subtotal to label.
                Binding subtotalBind = new Binding("Text", this.invoiceSource, "Subtotal");
                subtotalBind.FormattingEnabled = true;
                subtotalBind.FormatString = "C";
                this.lblSubtotal.DataBindings.Add(subtotalBind);

                //bind PST charges to label.
                Binding PSTBind = new Binding("Text", this.invoiceSource, "ProvincialSalesTaxCharged");
                PSTBind.FormattingEnabled = true;
                PSTBind.FormatString = "0.00";
                this.lblProvincialSalesTax.DataBindings.Add(PSTBind);

                //bind GST charges to label.
                Binding GSTBind = new Binding("Text", this.invoiceSource, "GoodsAndServicesTaxCharged");
                GSTBind.FormattingEnabled = true;
                GSTBind.FormatString = "0.00";
                this.lblGoodsAndServicesTax.DataBindings.Add(GSTBind);

                //bind total cost to label.
                Binding totalBind = new Binding("Text", this.invoiceSource, "total");
                totalBind.FormattingEnabled = true;
                totalBind.FormatString = "C";
                this.lblTotal.DataBindings.Add(totalBind);
            }
        }
    }
}
