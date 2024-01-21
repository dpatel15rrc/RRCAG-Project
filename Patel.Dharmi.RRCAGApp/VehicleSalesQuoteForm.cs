/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-11-03
 * Updated: 2023-11-15 (Assignment 5 Improvements)
 */

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
    /// Represents the
    /// </summary>
    public partial class VehicleSalesQuoteForm : Form
    {
        private SalesQuote salesQuote;

        /// <summary>
        /// Initializes an instance of the SalesQuoteForm class.
        /// </summary>
        public VehicleSalesQuoteForm()
        {
            InitializeComponent();

            this.btnCalculateQuote.Click += BtnCalculateQuote_Click;
            this.btnReset.Click += BtnReset_Click;
            this.txtVehicleSalePrice.TextChanged += TextBox_TextChanged;
            this.txtTradeInAmount.TextChanged += TextBox_TextChanged;
            this.chkStereoSystem.CheckedChanged += Options_CheckedChanged;
            this.chkLeatherInterior.CheckedChanged += Options_CheckedChanged;
            this.chkComputerNavigation.CheckedChanged += Options_CheckedChanged;
            this.radStandardFinish.CheckedChanged += Options_CheckedChanged;
            this.radPearlizedFinish.CheckedChanged += Options_CheckedChanged;
            this.radCustomizedDetailing.CheckedChanged += Options_CheckedChanged;
            this.nudNoOfYears.ValueChanged += Options_CheckedChanged;
            this.nudAnnualInterestRate.ValueChanged += Options_CheckedChanged;
        }

        /// <summary>
        /// Handles the click event of the Calculate Quote button.
        /// </summary>
        private void BtnCalculateQuote_Click(object sender, EventArgs e)
        {
            VehicleSalesQuoteCalculations();
        }

        /// <summary>
        /// Handles the Checked changed events for Accessories, Exterior Finish and financial selection.
        /// </summary>
        private void Options_CheckedChanged(object sender, EventArgs e)
        {
            if (salesQuote != null)
            {
                BtnCalculateQuote_Click(sender, e);
            }
        }

        /// <summary>
        /// Handles the Text Changed event for Vehicle Sale Price and Trade-In Amount.
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (salesQuote != null)
            {
                salesQuote = null;
                ClearOutputLabels();
            }
        }

        /// <summary>
        /// Handles the Click even for Reset button.
        /// </summary>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            string message = "Do you want to reset the form?",
                   caption = "Reset Form";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon, MessageBoxDefaultButton.Button2);

            switch (result)
            {
                case DialogResult.Yes:
                    this.FormInitialState();
                    break;
                case DialogResult.No:
                    this.txtVehicleSalePrice.Focus();
                    break;
            }
        }

        /// <summary>
        /// Calculates the values to display in the output labels.
        /// </summary>
        private void VehicleSalesQuoteCalculations()
        {
            decimal vehicleSalePrice = GetVehicleSalePrice();
            decimal tradeInAmount = GetTradeInAmount();

            // Check if vehicle sale price and trade-in amount are valid.
            if (this.errorProvider.GetError(txtVehicleSalePrice) == string.Empty &&
                this.errorProvider.GetError(txtTradeInAmount) == string.Empty)
            {
                // extract all the values from the form fields.
                vehicleSalePrice = Decimal.Parse(this.txtVehicleSalePrice.Text);
                tradeInAmount = Decimal.Parse(this.txtTradeInAmount.Text);
                decimal salesTaxRate = 0.12m;
                Accessories accessoriesChosen = GetAccessories();
                ExteriorFinish exteriorFinishChosen = GetExteriorFinish();

                // create a new instance of the SalesQuote with user inputs.
                salesQuote = new SalesQuote(vehicleSalePrice, tradeInAmount, salesTaxRate, accessoriesChosen, exteriorFinishChosen);

                // calculate monthly payments.
                decimal rate = ((this.nudAnnualInterestRate.Value)/12) / 100,
                        presentValue = salesQuote.AmountDue;
                int numberOfPaymentPeriods = ((int)nudNoOfYears.Value) * 12;
                decimal monthlyPayments = Financial.GetPayment(rate, numberOfPaymentPeriods, presentValue);

                // update the display labels with calculated values.
                UpdateOutputLabels(salesQuote, monthlyPayments);
            }
        }

        /// <summary>
        /// Gets the user input for vehicle sale price and checks for errors.
        /// </summary>
        /// <returns>Returns the valid Vehicle Sale Price entered by the user.</returns>
        private decimal GetVehicleSalePrice()
        {
            decimal vehicleSalePrice = 0;

            this.errorProvider.SetError(this.txtVehicleSalePrice, string.Empty);
            this.errorProvider.SetIconPadding(this.txtVehicleSalePrice, 3);

            if (string.IsNullOrWhiteSpace(this.txtVehicleSalePrice.Text))
            {
                this.errorProvider.SetError(this.txtVehicleSalePrice, "Vehicle Price is a required field");
            }
            else
            {
                try
                {
                    if (Decimal.Parse(this.txtVehicleSalePrice.Text) <= 0)
                    {
                        this.errorProvider.SetError(txtVehicleSalePrice, "Vehicle price cannot be less than or equal to 0.");
                    }

                    else
                    {
                        vehicleSalePrice = Decimal.Parse(this.txtVehicleSalePrice.Text);
                    }
                }
                catch (FormatException)
                {
                    this.errorProvider.SetError(txtVehicleSalePrice, "Vehicle price cannot contain letters or special characters.");
                }
            }
            return vehicleSalePrice;
        }

        /// <summary>
        /// Gets the user input for trade-in amount and checks for errors.
        /// </summary>
        /// <returns>Returns the valid Trade-in amount entered by the user.</returns>
        private decimal GetTradeInAmount()
        {
            decimal tradeInAmount = 0;

            this.errorProvider.SetError(this.txtTradeInAmount, string.Empty);
            this.errorProvider.SetIconPadding(this.txtTradeInAmount, 3);

            if (string.IsNullOrEmpty(this.txtTradeInAmount.Text))
            {
                this.errorProvider.SetError(this.txtTradeInAmount, "Trade-in value is a required field.");
            }
            else
            {
                try
                {
                    if (Decimal.Parse(this.txtTradeInAmount.Text) < 0)
                    {
                        this.errorProvider.SetError(this.txtTradeInAmount, "Trade-in value cannot be less than 0.");
                    }
                    else
                    {
                        tradeInAmount = Decimal.Parse(this.txtTradeInAmount.Text);
                    }
                }
                catch (FormatException)
                {
                    this.errorProvider.SetError(txtTradeInAmount, "Trade-in value cannot contain letters or special characters.");
                }
            }

            if ((this.errorProvider.GetError(this.txtVehicleSalePrice).Equals(string.Empty)) &&
                (this.errorProvider.GetError(this.txtTradeInAmount).Equals(string.Empty)))
            {
                if (Decimal.Parse(this.txtTradeInAmount.Text) > Decimal.Parse(this.txtVehicleSalePrice.Text))
                {
                    this.errorProvider.SetError(this.txtTradeInAmount, "Trade-in value cannot exceed the vehicle sale price.");
                }
            }
            return tradeInAmount;
        }

        /// <summary>
        /// Gets the chosen Accessories.
        /// </summary>
        /// <returns> Accessory/accessories chosen by the user.</returns>
        private Accessories GetAccessories()
        {
            // Arrays to hold Accessories check boxes and their corresponding enum values.
            CheckBox[] accessoriesCheckboxes = { chkStereoSystem, chkLeatherInterior, chkComputerNavigation };
            Accessories[] accessories = { Accessories.StereoSystem, Accessories.LeatherInterior, Accessories.ComputerNavigation };
            Accessories chosenAccessories = Accessories.None;

            // Find the Accessories from checked check boxes.
            // find the corresponding Accessory enum value and set bit flag in chosen accessory.
            // bitwise (|=) operator combines currently chosen accessory with newly chosen ones.
            for (int i = 0; i < accessoriesCheckboxes.Length; i++)
            {
                if (accessoriesCheckboxes[i].Checked)
                {
                    chosenAccessories |= accessories[i];
                }
            }
            return chosenAccessories;
        }

        /// <summary>
        /// Gets the chosen Exterior Finish.
        /// </summary>
        /// <returns>Exterior Finish chosen by the user.</returns>
        private ExteriorFinish GetExteriorFinish()
        {
            // Arrays to hold exterior finish radio buttons and corresponding enum values.
            RadioButton[] exteriorFinishRadios = { radStandardFinish, radPearlizedFinish, radCustomizedDetailing };
            ExteriorFinish[] finishes = { ExteriorFinish.Standard, ExteriorFinish.Pearlized, ExteriorFinish.Custom };
            ExteriorFinish chosenFinish = ExteriorFinish.None;

            // Find the selected exterior finish from checked radio buttons.
            // Assign the corresponding exterior finish enum value to chosenFinish
            for (int i = 0; i < exteriorFinishRadios.Length; i++)
            {
                if (exteriorFinishRadios[i].Checked)
                {
                    chosenFinish = finishes[i];
                }
            }
            return chosenFinish;
        }

        /// <summary>
        /// initializes VehicleSalesQuote form's initial state.
        /// </summary>
        private void FormInitialState()
        {
            this.txtVehicleSalePrice.Text = string.Empty;
            this.txtTradeInAmount.Text = "0";
            this.nudNoOfYears.Value = 1;
            this.nudAnnualInterestRate.Value = 5;
            this.radStandardFinish.Checked = true;
            this.radPearlizedFinish.Checked = false;
            this.radCustomizedDetailing.Checked = false;
            this.chkStereoSystem.Checked = false;
            this.chkLeatherInterior.Checked = false;
            this.chkComputerNavigation.Checked = false;
            salesQuote = null;
            ClearOutputLabels();
        }

        /// <summary>
        /// Clears the data from Output label fields.
        /// </summary>
        private void ClearOutputLabels()
        {
            this.lblVehicleSalePrice.Text = string.Empty;
            this.lblOptions.Text = string.Empty;
            this.lblSubtotal.Text = string.Empty;
            this.lblSalesTax.Text = string.Empty;
            this.lblTotal.Text = string.Empty;
            this.lblTradeIn.Text = string.Empty;
            this.lblAmountDue.Text = string.Empty;
            this.lblMonthlyPayment.Text = string.Empty;
        }

        /// <summary>
        /// Updates the Output label fields with calculated values.
        /// </summary>
        private void UpdateOutputLabels(SalesQuote salesQuote, decimal monthlyPayment)
        {
            this.lblVehicleSalePrice.Text = salesQuote.VehicleSalePrice.ToString("C");
            this.lblOptions.Text = salesQuote.TotalOptions.ToString("N");
            this.lblSubtotal.Text = salesQuote.SubTotal.ToString("C");
            this.lblSalesTax.Text = salesQuote.SalesTax.ToString("N");
            this.lblTotal.Text = salesQuote.Total.ToString("C");
            this.lblTradeIn.Text = (-salesQuote.TradeInAmount).ToString("N");
            this.lblAmountDue.Text = salesQuote.AmountDue.ToString("C");
            this.lblMonthlyPayment.Text = monthlyPayment.ToString("C");
        }
    }
}
