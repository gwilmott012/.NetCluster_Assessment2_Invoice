
using Assessment_One.Helpers;
using InvoiceDAL.Models;
using InvoiceDAL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Assessment_One
{
    public partial class Form1 : Form
    {


        //Arrays to store Customers and Invoices
        //Customer[] customerStorage = new Customer[1];
        //Invoice[] invoiceStorage = new Invoice[1];


        //Key varibales for searching
        int selected_customer_id;
        string selected_customer_Name;
        int invoice_id;
        IInvoiceService invoiceService = new InvoiceService();
        ICustomerService customerService = new CustomerService();


        public Form1()
        {
            InitializeComponent();
        }



        private void ViewInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerGridView.Columns[e.ColumnIndex].Name == "Invoice")
            {
                btnAddInvoice.Enabled = true;
                selected_customer_id = (int)customerGridView.Rows[e.RowIndex].Cells[0].Value;
                selected_customer_Name = (string)customerGridView.Rows[e.RowIndex].Cells[1].Value;

                ViewInvoicesForCustomer();
            }
            else if (customerGridView.Columns[e.ColumnIndex].Name == "Edit")
            {

                txtCustomerId.Text = customerGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCustomerName.Text = customerGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCustomerAddress.Text = customerGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnAddCustomer.Text = "Update";
            }
        }


        private void ViewInvoicesForCustomer()
        {
            try
            {
                lblErrorReport.Text = string.Empty;
                List<Invoice> invoiceList = invoiceService.GetCustomerInvoices(selected_customer_id);
                invoiceGridView.DataSource = invoiceList;
            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }

        }

        private void UpdateInvoiceLabels()
        {
            lblInvoiceList.Text = "Invoices for " + selected_customer_Name;
            lblNewInvoice.Text = "New invoice for " + selected_customer_Name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCustomers();

            InitializeInvoices();

            lblErrorReport.Text = string.Empty;

            try
            {
                lblErrorReport.Text = string.Empty;
                txtCustomerId.Text = customerService.GetMaxCustomerId().ToString();

                txtInvoiceId.Text = invoiceService.GetMaxInvoiceId().ToString();
            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }

            dtpInvoiceDate.Value = DateTime.Now.AddDays(14).Date;

        }

        private void InitializeInvoices()
        {
            
        }

        private void InitializeCustomers()
        {
            try
            {
                lblErrorReport.Text = string.Empty;
                List<Customer> customerList = customerService.GetCustomers();
                customerGridView.DataSource = customerList;

            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            int customer_id = 0;
            int.TryParse(txtCustomerId.Text, out customer_id);




            if (string.IsNullOrEmpty(txtCustomerName.Text) || string.IsNullOrEmpty(txtCustomerAddress.Text))
            {
                string message = "Please enter an Address";

                if (string.IsNullOrEmpty(txtCustomerName.Text) && string.IsNullOrEmpty(txtCustomerAddress.Text))
                {
                    message = "Please enter a Name and Address";
                }
                else if (string.IsNullOrEmpty(txtCustomerName.Text))
                {
                    message = "Please enter a Name";
                }

                MessageBox.Show(message);
                return;
            }


            try
            {
                lblErrorReport.Text = string.Empty;
                if (btnAddCustomer.Text == "Update")
                {
                    Customer customer = new Customer() { Id = customer_id, Customer_Name = txtCustomerName.Text, Customer_Address = txtCustomerAddress.Text, CreateOrUpdate = false };
                    List<Customer> customerList = customerService.CreateOrUpdateCustomer(customer);
                    customerGridView.DataSource = customerList;
                }
                else
                {
                    Customer customer = new Customer() { Id = customer_id, Customer_Name = txtCustomerName.Text, Customer_Address = txtCustomerAddress.Text, CreateOrUpdate = true };
                    List<Customer> customerList = customerService.CreateOrUpdateCustomer(customer);
                    customerGridView.DataSource = customerList;
                }




                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtCustomerId.Text = customerService.GetMaxCustomerId().ToString();

                btnAddCustomer.Text = "Add";
            }
            catch (Exception ex)
            {
                //In here we should catch the exception
                lblErrorReport.Text = ex.Message;

            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            int invoice_id = 0;
            bool stringToIntConversionSuccess = false;
            stringToIntConversionSuccess = int.TryParse(txtInvoiceId.Text, out invoice_id);

            double invoice_cost = 0;
            bool stringToDoubleConversionSuccess = false;
            stringToDoubleConversionSuccess = double.TryParse(txtCost.Text.Replace("$", ""), out invoice_cost);

            if (stringToDoubleConversionSuccess == false || string.IsNullOrEmpty(txtInvoiceDescription.Text))
            {
                string message = "Please enter a Cost value";

                if (stringToDoubleConversionSuccess == false && string.IsNullOrEmpty(txtInvoiceDescription.Text))
                {
                    message = "Please enter a Description and a Cost";
                }
                else if (string.IsNullOrEmpty(txtInvoiceDescription.Text))
                {
                    message = "Please enter a Description";
                }


                MessageBox.Show(message);
                return;

            }

            try
            {
                lblErrorReport.Text = string.Empty;
                if (stringToIntConversionSuccess == true && stringToDoubleConversionSuccess == true && btnAddInvoice.Text == "Add")
                {
                    Invoice invoice = new Invoice() { Id = invoice_id, Customer_Id = selected_customer_id, Description = txtInvoiceDescription.Text, Costs = invoice_cost, Payment_Date = dtpInvoiceDate.Value.Date, CreateOrUpdate = true };
                    List<Invoice> invoiceList = invoiceService.CreateOrUpdateInvoice(invoice);
                    invoiceGridView.DataSource = invoiceList;
                }
                else if (stringToIntConversionSuccess == true && stringToDoubleConversionSuccess == true && btnAddInvoice.Text == "Update")
                {
                    Invoice invoice = new Invoice() { Id = invoice_id, Customer_Id = selected_customer_id, Description = txtInvoiceDescription.Text, Costs = invoice_cost, Payment_Date = dtpInvoiceDate.Value.Date, CreateOrUpdate = false };
                    List<Invoice> invoiceList = invoiceService.CreateOrUpdateInvoice(invoice);
                    invoiceGridView.DataSource = invoiceList;
                }

                txtCost.Text = "$";
                txtInvoiceDescription.Text = "";

                ViewInvoicesForCustomer();

                txtInvoiceId.Text = invoiceService.GetMaxInvoiceId().ToString();

                btnAddInvoice.Text = "Add";

            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }
        }

       

        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(Application.StartupPath + @"\Images\images.jpg");
            this.BackgroundImage = myimage;
        }

        private void image2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image myimage2 = new Bitmap(Application.StartupPath + @"\Images\image2.jpg");
            this.BackgroundImage = myimage2;
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }


        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorReport.Text = string.Empty;
                string customerSearchText = txtCustomerSearch.Text;

                if (customerSearchText == string.Empty)
                {
                    MessageBox.Show("Please search a valid customer");
                }
                else
                {
                    //Customer[] filteredCustomers = CustomerHelpers.FilterByName(customerStorage, customerSearchText);
                    //FilteredCustomers(filteredCustomers);

                    List<Customer> customerList = customerService.GetCustomer(customerSearchText);
                    customerGridView.DataSource = customerList;

                }
            }

            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }
        }

        private void SearchForCustomerById()
        {
            try
            {
                lblErrorReport.Text = string.Empty;
                List<Customer> filteredCustomers = customerService.GetCustomerById(selected_customer_id);
                FilteredCustomer(filteredCustomers);

            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }
        }

        private void FilteredCustomer(List<Customer> filteredCustomer)
        {

            if (filteredCustomer.Count > 0)
            {

                selected_customer_id = filteredCustomer[0].Id;
                selected_customer_Name = filteredCustomer[0].Customer_Name;

                UpdateInvoiceLabels();

            }

            customerGridView.DataSource = filteredCustomer;
        }

        private void btnInvoiceSearch_Click(object sender, EventArgs e)
        {

            try
            {
                lblErrorReport.Text = string.Empty;
                int result = 0;

                List<Invoice> FilteredInvoices;

                if (int.TryParse(txtInvoiceSearch.Text, out result))
                {
                    FilteredInvoices = invoiceService.GetInvoicesById(result);
                    //FilteredInvoices = InvoiceHelper.FilterByInvoiceId(invoiceStorage, result);

                    if (FilteredInvoices.Count > 0)
                    {
                        invoice_id = FilteredInvoices[0].Id;
                        selected_customer_id = FilteredInvoices[0].Customer_Id;
                        selected_customer_Name = string.Empty;

                        SearchForCustomerById();

                    }

                    invoiceGridView.DataSource = FilteredInvoices;
                }
                else
                {
                    MessageBox.Show("enter an integer");
                }

            }
            catch (Exception ex)
            {
                lblErrorReport.Text = ex.Message;
            }


        }

        private void invoiceGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (invoiceGridView.Columns[e.ColumnIndex].Name == "EditInvoice")
            {

                txtInvoiceId.Text = invoiceGridView.Rows[e.RowIndex].Cells[0].Value.ToString();                
                txtInvoiceDescription.Text = invoiceGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCost.Text = invoiceGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpInvoiceDate.Value = (DateTime)invoiceGridView.Rows[e.RowIndex].Cells[4].Value;
                btnAddInvoice.Text = "Update";
                btnAddInvoice.Enabled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
