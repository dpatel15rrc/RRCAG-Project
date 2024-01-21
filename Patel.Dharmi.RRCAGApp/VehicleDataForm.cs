/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-11-03
 * Updated: 2023-12-02 (Assignment 7)
 */

using ACE.BIT.ADEV.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patel.Dharmi.RRCAGApp
{
    /// <summary>
    /// Represents the Vehicle Data Form
    /// </summary>
    public partial class VehicleDataForm : ACE.BIT.ADEV.Forms.VehicleDataForm
    {
        private OleDbConnection connection;
        private OleDbDataAdapter adapter;
        private OleDbCommandBuilder builder;
        private DataSet dataset;
        private BindingSource bindingSource;

        /// <summary>
        /// Initializes an instance of the CarWashForm class.
        /// </summary>
        public VehicleDataForm()
        {
            InitializeComponent();

            this.bindingSource = new BindingSource();
            this.connection = new OleDbConnection();

            this.Load += VehicleDataForm_Load;
        }

        /// <summary>
        /// Handles the Form load event.
        /// </summary>
        private void VehicleDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                RetrieveDataFromTheDatabase();

                //Set the binding source’s data source to the “VehicleStock” table in the dataset.
                bindingSource.DataSource = dataset.Tables["VehicleStock"];
                //Set the data grid view’s data source to the binding source object.
                this.dgvVehicles.DataSource = bindingSource;

                // Hide the ID and SoldBy columns.
                this.dgvVehicles.Columns["ID"].Visible = false;
                this.dgvVehicles.Columns["SoldBy"].Visible = false;

                FormInitialState();
                BindControls();

                this.mnuFileSave.Click += MnuFileSave_Click;
                this.mnuFileClose.Click += MnuFileClose_Click;
                this.mnuEditRemove.Click += MnuEditRemove_Click;

                this.dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
                this.dgvVehicles.CellValueChanged += DgvVehicles_CellValueChanged;
                this.dgvVehicles.RowsAdded += DgvVehicles_RowsAdded;
            }
            // if there is an error when initializing the Form, display a message box.
            catch (Exception ex)
            {
                string message = "Unable to load vehicle data.",
                       caption = "Data Load Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon);
            }
        }

        /// <summary>
        /// Handles the Rows Added event of the Vehicle Stock table.
        /// </summary>
        private void DgvVehicles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        { 
            // check if the dgvtable contains the SoldBy column.
            if (dgvVehicles.Columns.Contains("SoldBy"))
            {
                // loop through the added rows and set the SoldBy column value to zero
                for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
                {
                    dgvVehicles.Rows[i].Cells["SoldBy"].Value = 0;
                }
            }
        }

        /// <summary>
        /// Handles the Cell Value Changed event of the Vehicle Stock table.
        /// </summary>
        private void DgvVehicles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //when cell value is changed, change the form text to "* Vehicle Data" and enable save menu item.
            this.Text = "* Vehicle Data";
            this.mnuFileSave.Enabled = true;

            if (dataset.HasChanges())
            {
                //end the edit process and save the changes to the database.
                this.dgvVehicles.EndEdit();
                SaveChangesToDatabase();
            }
        }

        /// <summary>
        /// Handles the Selection Changed event of the Vehicle Stock table.
        /// </summary>
        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            //check if the area selected is a single row and is not a new row.
            if (dgvVehicles.CurrentRow != null && !dgvVehicles.CurrentRow.IsNewRow && dgvVehicles.SelectedRows.Count == 1)
            {
                //if true, enable the remove button.
                this.mnuEditRemove.Enabled = true;
            }
            else
            {
                //if false, disable the remove button.
                this.mnuEditRemove.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the Remove menu item.
        /// </summary>
        private void MnuEditRemove_Click(object sender, EventArgs e)
        {
            // check if a row is selected and it is not a new row.
            if (dgvVehicles.CurrentRow != null && !dgvVehicles.CurrentRow.IsNewRow)
            {
                string stockItem = dgvVehicles.CurrentRow.Cells["StockNumber"].Value.ToString();
                string message = $"Remove stock item {stockItem}?",
                       caption = "Remove Stock Item";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    //if the dialog box result is yes, remove the selected row.
                    dgvVehicles.Rows.RemoveAt(dgvVehicles.SelectedCells[0].RowIndex);

                    this.Text = "* Vehicle Data";
                    this.mnuFileSave.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Close menu item.
        /// </summary>
        private void MnuFileClose_Click(object sender, EventArgs e)
        {
            // check if the dataset has changes or the save menu item is enabled (i.e, there are unsaved changes)
            if (dataset.HasChanges() || this.mnuFileSave.Enabled == true)
            {
                string message = "Do you wish to save the changes?",
                       caption = "Save";
                MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon, MessageBoxDefaultButton.Button3);

                switch (result)
                {
                    //if the dialog box result is Yes, attempt to save changes.
                    case DialogResult.Yes: 
                        SaveChangesOnClose();
                        break;
                    //if the dialog box result is No, close the form.
                    case DialogResult.No:
                        this.Close();
                        break;
                }
            }
            else
            {
                //close the Form if there are no changes to save.
                this.Close();
            }
        }

        /// <summary>
        /// Saves the changes to database when the form is closed.
        /// </summary>
        private void SaveChangesOnClose() {
            try
            {
                //if the dialog box result is yes, save the changes to database and close the form.
                SaveChangesToDatabase();
                this.Close();
            }
            //display a message box in case an error occurs while saving changes.
            catch (Exception ex)
            {
                string message1 = "An error occurred while saving the changes. Do you still wish to close?",
                       caption1 = "Save Error";
                MessageBoxButtons button1 = MessageBoxButtons.YesNo;
                MessageBoxIcon icon1 = MessageBoxIcon.Error;
                DialogResult result1;

                result1 = MessageBox.Show(message1, caption1, button1, icon1, MessageBoxDefaultButton.Button2);

                if (result1 == DialogResult.Yes)
                {
                    //if the dialog box result is yes, close the form.
                    this.Close();
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the Save menu item.
        /// </summary>
        private void MnuFileSave_Click(object sender, EventArgs e)
        {
            SaveChangesToDatabase();
        }

        /// <summary>
        /// Updates and Saves changes to the database.
        /// </summary>
        private void SaveChangesToDatabase()
        {
            try
            {
                // update the "VehicleStock" table with changes. Change the form text back to "Vehicle Data" and disable the save button.
                adapter.Update(dataset.Tables["VehicleStock"]);
                this.Text = "Vehicle Data";
                this.mnuFileSave.Enabled = false;
            }
            // display a message box in case an error occurs while saving data.
            catch (Exception ex)
            {
                string message = "An error occurred while saving the changes to the vehicle data.",
                       caption = "Save Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon);
            }
        }

        /// <summary>
        /// Retrieves the data from Vehicle Stock table to populate the Form.
        /// </summary>
        private void RetrieveDataFromTheDatabase()
        {
            //connect the database.
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AMDatabase.mdb";
            connection.Open();

            OleDbCommand commands = new OleDbCommand();
            // Query all rows and columns from the VehicleStock table.
            commands.CommandText = "SELECT * FROM VehicleStock";
            commands.Connection = connection;

            this.adapter = new OleDbDataAdapter();
            this.adapter.SelectCommand = commands;

            dataset = new DataSet();
            // Fill the dataset and give the table "VehicleStock" name.
            this.adapter.Fill(dataset, "VehicleStock");

            builder = new OleDbCommandBuilder();
            builder.DataAdapter = this.adapter;
            builder.ConflictOption = ConflictOption.OverwriteChanges;

            this.adapter.DeleteCommand = this.builder.GetDeleteCommand();
            this.adapter.UpdateCommand = this.builder.GetUpdateCommand();
            this.adapter.InsertCommand = this.builder.GetInsertCommand();
        }

        /// <summary>
        /// Sets the initial state of the Vehicle Data form.
        /// </summary>
        private void FormInitialState()
        {
            this.WindowState = FormWindowState.Maximized;
            this.mnuFileSave.Enabled = false;
            this.mnuEditRemove.Enabled = false;

            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeColumns = false;
            this.dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.MultiSelect = false;
        }

        /// <summary>
        /// Binds the data from the VehicleStock table to the Vehicle Data form.
        /// </summary>
        private void BindControls()
        {
            this.Load += new System.EventHandler(this.VehicleDataForm_Load);
        }
    }
}
