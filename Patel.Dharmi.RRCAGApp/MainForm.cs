/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-11-03
 * Updated: 2023-12-4 (Assignment 7)
 */

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
    /// Represents the startup Form for the application.
    /// </summary>
    public partial class MainForm : Form
    {
        private VehicleDataForm vehicleDataForm;

        /// <summary>
        /// Initializes an instance of the MainForm class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.mnuFileOpenSalesQuote.Click += MnuFileOpenSalesQuote_Click;
            this.mnuFileOpenCarWash.Click += MnuFileOpenCarWash_Click;
            this.mnuFileExit.Click += MnuFileExit_Click;
            this.mnuDataVehicles.Click += MnuDataVehicles_Click;
            this.mnuHelpAbout.Click += MnuHelpAbout_Click;
            this.FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// handles the Form Closing event of the Main form.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check if any mdi child forms are open.
            if (this.MdiChildren.Length > 0)
            {
                //if any forms are open, prevent the Main form from closing display a message box.
                e.Cancel = true;

                string message = "Please close all child forms before exiting.",
                       caption = "Child Forms Open";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon, MessageBoxDefaultButton.Button1);
            }
            else
            {
                // if no forms are open, close the Main form.
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Handles the click event of the About menu item.
        /// </summary>
        private void MnuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the click event of the Vehicle Data menu item.
        /// </summary>
        private void MnuDataVehicles_Click(object sender, EventArgs e)
        {
            if (vehicleDataForm != null)
            {
                vehicleDataForm.Activate();
            }
            else
            {
                VehicleDataForm vehicleDataForm = new VehicleDataForm();
                vehicleDataForm.MdiParent = this;
                vehicleDataForm.Show();
            }
        }

        /// <summary>
        /// Handles the click event of the Exit menu item.
        /// </summary>
        private void MnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the Open Car Wash menu item.
        /// </summary>
        private void MnuFileOpenCarWash_Click(object sender, EventArgs e)
        {
            CarWashForm carWashForm = new CarWashForm();
            carWashForm.MdiParent = this;
            carWashForm.Show();
        }

        /// <summary>
        /// Handles the click event of the Open Sales Quote menu item.
        /// </summary>
        private void MnuFileOpenSalesQuote_Click(object sender, EventArgs e)
        {
            VehicleSalesQuoteForm salesQuoteForm = new VehicleSalesQuoteForm();
            salesQuoteForm.MdiParent = this;
            salesQuoteForm.Show();
        }
    }
}
