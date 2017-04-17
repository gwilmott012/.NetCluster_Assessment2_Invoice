using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assessment_One.DataEntities;
using System.Collections;
using Assessment_One.Helpers;

namespace Assessment_One
{
    public partial class Form1 : Form
    {
        List<Invoice> invoiceList = new List<Invoice>();
        List<Invoice> invoiceListBackup = new List<Invoice>();

        List<Customer> customerList = new List<Customer>();

        int selected_customer_id;
        string selected_customer_Name;

        public Form1()
        {
            InitializeComponent(); 
        }

        private string GetNextCustomerId()
        {
            return (customerList.Count + 1).ToString();
        }

        private string GetNextInvoiceId()
        {
            return (invoiceList.Count + 1).ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerGridView.Columns[e.ColumnIndex].Name == "Invoice")
            {
                btnAddInvoice.Enabled = true;
                selected_customer_id = (int)customerGridView.Rows[e.RowIndex].Cells[0].Value;
                selected_customer_Name = (string)customerGridView.Rows[e.RowIndex].Cells[1].Value;

                FilterInvoicesForCustomer(selected_customer_id);

                invoiceBindingSource.DataSource = invoiceList;

                lblInvoiceList.Text = "Invoices for " + selected_customer_Name;
                lblNewInvoice.Text = "New invoice for " + selected_customer_Name;
            }
        }

        private void BackupInvoices()
        {
            foreach (var invoice in invoiceList)
            {
                if (!invoiceListBackup.Contains(invoice))
                {
                    invoiceListBackup.Add(invoice);
                }
            }
        }

        private void RestoreInvoices()
        {
            foreach (var invoice in invoiceListBackup)
            {
                if (!invoiceList.Contains(invoice))
                {
                    invoiceList.Add(invoice);
                }
            }
        }


        private void FilterInvoicesForCustomer(int customer_Id)
        {
            //First we need to back up invoiceList. This adds any new invoices to the backup.
            BackupInvoices();

            //Now we have to retore all the invoices from the backup to invoiceList so there is a complete list to filter.
            RestoreInvoices();

            List<Invoice> tmpInvoiceList = new List<Invoice>();

            foreach (var invoice in invoiceList)
            {
                if (invoice.Customer_Id == customer_Id)
                {
                    tmpInvoiceList.Add(invoice);
                }
            }

            invoiceList = tmpInvoiceList;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCustomers();

            InitializeInvoices();



            customerBindingSource.DataSource = customerList;

            txtCustomerId.Text = GetNextCustomerId();

            txtInvoiceId.Text = GetNextInvoiceId();

            dtpInvoiceDate.Value = DateTime.Now.AddDays(14).Date;

        }

        private void InitializeInvoices()
        {
            

            invoiceList.Add(new Invoice() { Id = 1, Customer_Id = 1, Costs = 23.5, Description = "Lots of stuff", Payment_Date = DateTime.Now.AddDays(14).Date });
            invoiceList.Add(new Invoice() { Id = 2, Customer_Id = 1, Costs = 200, Description = "Other things", Payment_Date = DateTime.Now.AddDays(12).Date });
            invoiceList.Add(new Invoice() { Id = 3, Customer_Id = 2, Costs = 1000, Description = "Fruit and things", Payment_Date = DateTime.Now.AddDays(7).Date });
            invoiceList.Add(new Invoice() { Id = 4, Customer_Id = 3, Costs = 2000, Description = "Clothes and other boring stuff", Payment_Date = DateTime.Now.AddDays(3).Date });
        }

        private void InitializeCustomers()
        {
            Customer[] customerStorage = new Customer[5];

            customerStorage = CustomerHelpers.Add(customerStorage, new Customer() { Id = 1, Customer_Name = "Bruce",
                Customer_Address = "12 Long St" });

            customerStorage = CustomerHelpers.Add(customerStorage, new Customer() { Id = 2, Customer_Name = "Maria",
                Customer_Address = "23 Short St" });

            customerStorage = CustomerHelpers.Add(customerStorage, new Customer() { Id = 3, Customer_Name = "Helen",
                Customer_Address = "21 Tall St" });

            customerStorage = CustomerHelpers.Add(customerStorage, new Customer() { Id = 4, Customer_Name = "Maria",
                Customer_Address = "49 Windy St" });


            customerStorage = CustomerHelpers.Add(customerStorage, new Customer()
            {
                Id = 5,
                Customer_Name = "Peter Smith",
                Customer_Address = "49 High St"
            });
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

            customerBindingSource.Add(new Customer() { Id = customer_id, Customer_Name = txtCustomerName.Text, Customer_Address = txtCustomerAddress.Text });

            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerId.Text = GetNextCustomerId();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
  

            int invoice_id = 0;
            bool stringToIntConversionSuccess = false;
            stringToIntConversionSuccess = int.TryParse(txtInvoiceId.Text, out invoice_id);

            double invoice_cost = 0;
            bool stringToDoubleConversionSuccess = false;
            stringToDoubleConversionSuccess = double.TryParse(txtCost.Text.Replace("$",""), out invoice_cost);

            if (stringToDoubleConversionSuccess == false || string.IsNullOrEmpty(txtInvoiceDescription.Text))
            {
                string message = "Please enter a Cost value";

                if (stringToDoubleConversionSuccess == false && string.IsNullOrEmpty(txtInvoiceDescription.Text))
                {
                    message = "Please enter a Description and a Cost";
                } else if (string.IsNullOrEmpty(txtInvoiceDescription.Text))
                {
                    message = "Please enter a Description";
                }


                MessageBox.Show(message);
                return;

            }



            if (stringToIntConversionSuccess == true && stringToDoubleConversionSuccess == true)
            {
               invoiceBindingSource.Add(new Invoice() { Id = invoice_id, Customer_Id = selected_customer_id, Description = txtInvoiceDescription.Text, Costs = invoice_cost, Payment_Date = dtpInvoiceDate.Value});  
            }
            txtCost.Text = "$";
            txtInvoiceDescription.Text = "";
            txtInvoiceId.Text = (invoice_id+1).ToString();
        }
    }
}
