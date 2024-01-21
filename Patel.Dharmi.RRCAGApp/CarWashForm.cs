/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-11-03
 * Updated: 2023-11-20 (Assignment 6)
 */

using ACE.BIT.ADEV.CarWash;
using ACE.BIT.ADEV.Forms;
using Patel.Dharmi.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patel.Dharmi.RRCAGApp
{
    /// <summary>
    /// Represents the Car Wash Form.
    /// </summary>
    public partial class CarWashForm : ACE.BIT.ADEV.Forms.CarWashForm
    {
        private BindingList<Package> packages;
        private BindingSource packageSource;

        private BindingList<CarWashItem> fragrances;
        private BindingSource fragranceSource;

        private CarWashInvoice invoice;
        private BindingSource invoiceSource;

        /// <summary>
        /// Initializes an instance of the CarWashForm class.
        /// </summary>
        public CarWashForm()
        {
            InitializeComponent();

            InitializeData();
            BindControls();
            ResetForm();

            this.cboPackage.TextChanged += CboPackage_TextChanged;
            this.cboFragrance.TextChanged += CboPackage_TextChanged;
            this.mnuToolsGenerateInvoice.Click += MnuToolsGenerateInvoice_Click;
            this.mnuFileClose.Click += MnuFileClose_Click;
        }

        /// <summary>
        /// Initializes the Packages and Fragrances lists.
        /// </summary>
        private void InitializeData()
        {
            PackageInitialization();
            this.packageSource = new BindingSource();
            this.packageSource.DataSource = this.packages;

            FragranceInitialization();
            this.fragranceSource = new BindingSource();
            this.fragranceSource.DataSource = fragrances;

            this.invoiceSource = new BindingSource();
            this.invoiceSource.DataSource = typeof(CarWashInvoice);
        }

        /// <summary>
        /// 
        /// </summary>
        private void PackageInitialization()
        {

            this.packages = new BindingList<Package>();

            //initialize the packages.
            Package standardPackage = new Package("Standard", 7.50m, new List<String> { }, new List<String> { "Hand Wash" });
            Package deluxePackage = new Package("Deluxe", 15.00m, new List<String> { "Shampoo Carpets" }, new List<String> { "Hand Wash", "Hand Wax" });
            Package executivePackage = new Package("Executive", 35.00m,
                                                    new List<String> { "Shampoo Carpets", "Shampoo Upholstery" },
                                                    new List<String> { "Hand Wash", "Hand Wax", "Wheel Polish" });
            Package LuxuryPackage = new Package("Luxury", 55.00m,
                                                new List<String> { "Shampoo Carpets", "Shampoo Upholstery", "Interior Protection Coat" },
                                                new List<String> { "Hand Wash", "Hand Wax", "Wheel Polish", "Detail Engine Compartment" });

            //populate the Packages list.
            this.packages.Add(standardPackage);
            this.packages.Add(deluxePackage);
            this.packages.Add(executivePackage);
            this.packages.Add(LuxuryPackage);
        }

        /// <summary>
        /// Read the data from the file and parse it into a list.
        /// </summary>
        private void FragranceInitialization()
        {
            fragrances = new BindingList<CarWashItem>();
            fragrances.Add(new CarWashItem("Pine", 0.00m));

            try
            {
                string filepath = "fragrances.txt";

                //determine if the file actually exists.
                if (File.Exists(filepath))
                {
                    //read all the lines and parse the values into description and prices.
                    //add the parsed data to the list.
                    string[] lines = File.ReadAllLines(filepath);
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 2)
                        {
                            string description = data[0].Trim();
                            decimal price = decimal.Parse(data[1].Trim());
                            fragrances.Add(new CarWashItem(description, price));
                        }
                    }
                    //sort list items alphabetically.
                    fragrances = new BindingList<CarWashItem>(fragrances.OrderBy(x => x.Description).ToList());
                }
                else
                {
                    string message1 = "Fragrances data file not found.",
                           caption1 = "Data File Error";
                    MessageBoxButtons button1 = MessageBoxButtons.OK;
                    MessageBoxIcon icon1 = MessageBoxIcon.Error;
                    DialogResult result1;

                    result1 = MessageBox.Show(message1, caption1, button1, icon1);
                }
            }
            catch (Exception ex)
            {
                string message2 = "An error occurred while reading the data file.",
                       caption2 = "Data File Error";
                MessageBoxButtons button2 = MessageBoxButtons.OK;
                MessageBoxIcon icon2 = MessageBoxIcon.Error;
                DialogResult result2;

                result2 = MessageBox.Show(message2, caption2, button2, icon2);
            }
        }

        /// <summary>
        /// Sets the data bindings for the form.
        /// </summary>
        private void BindControls()
        {
            //bind package list to combo box.
            this.cboPackage.DataSource = this.packageSource;

            //bind fragrance list to combo box.
            this.cboFragrance.DataSource = this.fragranceSource;
            this.cboFragrance.DisplayMember = "Description";
            this.cboFragrance.ValueMember = "Price";

            //bind interior and exterior items to the list boxes.
            this.lstInterior.DisplayMember = "InteriorServices";
            this.lstExterior.DisplayMember = "ExteriorServices";

            //bind subtotal to label and format it as currency.
            Binding subtotalBind = new Binding("Text", this.invoiceSource, "SubTotal");
            subtotalBind.FormattingEnabled = true;
            subtotalBind.FormatString = "C";
            this.lblSubtotal.DataBindings.Add(subtotalBind);

            //bind PST charged to label and format it as decimal(0.00).
            Binding PSTBind = new Binding("Text", this.invoiceSource, "ProvincialSalesTaxCharged");
            PSTBind.FormattingEnabled = true;
            PSTBind.FormatString = "0.00";
            this.lblProvincialSalesTax.DataBindings.Add(PSTBind);

            //bind GST charged to label and format it as decimal(0.00).
            Binding GSTBind = new Binding("Text", this.invoiceSource, "GoodsAndServicesTaxCharged");
            GSTBind.FormattingEnabled = true;
            GSTBind.FormatString = "0.00";
            this.lblGoodsAndServicesTax.DataBindings.Add(GSTBind);

            //bind total to label and format it as currency.
            Binding totalBind = new Binding("Text", this.invoiceSource, "Total");
            totalBind.FormattingEnabled = true;
            totalBind.FormatString = "C";
            this.lblTotal.DataBindings.Add(totalBind);
        }

        /// <summary>
        /// Handles the TextChanged event of the Package and/or Fragrance combo box.
        /// </summary>
        private void CboPackage_TextChanged(object sender, EventArgs e)
        {
            UpdateInvoice();
        }

        /// <summary>
        /// Updates the listboxes and calculates the subtotal,total, PST and GST.
        /// </summary>
        private void UpdateInvoice()
        {
            decimal pstRate = 0.07m,
                    gstRate = 0.05m,
                    packageCost = 0,
                    fragranceCost = 0;

            // check if the package is selected.
            if (cboPackage.SelectedIndex != -1)
            {
                //create lists to hold the interior and exterior items.
                Package selectedPackage = (Package)this.cboPackage.SelectedItem;
                List<string> interiorServices = new List<string>();
                List<string> exteriorServices = new List<string>();

                //determine the package selection and add corresponding interior and exterior services based on the selection.
                if (selectedPackage != null)
                {
                    interiorServices.Add($"Fragrance - {cboFragrance.Text}");
                    interiorServices.AddRange(selectedPackage.InteriorServices);
                    exteriorServices.AddRange(selectedPackage.ExteriorServices);
                }

                this.lstInterior.DataSource = interiorServices;
                this.lstExterior.DataSource = exteriorServices;

                //determine the cost of the package selected.
                packageCost = selectedPackage.Price;

                //determine the cost of the fragrance selected.
                fragranceCost = (decimal)this.cboFragrance.SelectedValue;

                //create a new car wash invoice using the selected items.
                this.invoice = new CarWashInvoice(pstRate, gstRate, packageCost, fragranceCost);
                this.invoiceSource.DataSource = this.invoice;

                //enable the generate invoice menu item.
                this.mnuToolsGenerateInvoice.Enabled = true;
            }

        }

        /// <summary>
        /// Handles the click event of the Close menu item.
        /// </summary>
        private void MnuFileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the Generate Invoice menu item.
        /// </summary>
        private void MnuToolsGenerateInvoice_Click(object sender, EventArgs e)
        {
            CarWashInvoiceForm invoiceForm = new CarWashInvoiceForm();
            
            //transfer the data from CarWashForm to CarWashInvoiveForm.
            invoiceForm.InvoiceData = this.invoice;

            invoiceForm.FormClosed += InvoiceForm_FormClosed;
            invoiceForm.ShowDialog();   
        }

        /// <summary>
        /// Handles the closing of the CarWashInvoiceForm form.
        /// </summary>
        private void InvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetForm();
        }
        
        /// <summary>
        /// Sets the Initial form state.
        /// </summary>
        private void ResetForm()
        {
            //package combo box has no item selected.
            //fragrances combo box has "Pine" selected.
            this.cboPackage.SelectedIndex = -1;
            this.cboFragrance.Text = "Pine";

            //clear out the labels and list boxes.
            this.lblSubtotal.Text = null;
            this.lblProvincialSalesTax.Text = string.Empty;
            this.lblGoodsAndServicesTax.Text = string.Empty;
            this.lblTotal.Text = string.Empty;

            List<string> emptyList = new List<string>();
            this.lstInterior.DataSource = emptyList;
            this.lstExterior.DataSource = emptyList;

            //disable the generate invoice menu item.
            mnuToolsGenerateInvoice.Enabled = false;
        }
    }
}
