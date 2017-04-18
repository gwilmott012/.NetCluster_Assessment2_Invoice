﻿using Assessment_One.DataEntities;
using Assessment_One.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Assessment_One
{
    public partial class Form1 : Form
    {


        //Arrays to store Customers and Invoices
        Customer[] customerStorage = new Customer[1];
        Invoice[] invoiceStorage = new Invoice[1];


        //Key varibales for searching
        int selected_customer_id;
        string selected_customer_Name;
        int invoice_id;


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
            Invoice[] filteredInvoices = InvoiceHelper.FilterByCustomerId(invoiceStorage, selected_customer_id);
            invoiceGridView.DataSource = filteredInvoices;

            UpdateInvoiceLabels();
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


            txtCustomerId.Text = CustomerHelpers.GetNextId(customerStorage).ToString();

            txtInvoiceId.Text = InvoiceHelper.GetNextId(invoiceStorage).ToString();

            dtpInvoiceDate.Value = DateTime.Now.AddDays(14).Date;

        }

        private void InitializeInvoices()
        {
            invoiceStorage = InvoiceHelper.Add(invoiceStorage, new Invoice()
            {
                Id = 1,
                Customer_Id = 1,
                Costs = 23.5,
                Description = "Lots of stuff",
                Payment_Date = DateTime.Now.AddDays(14).Date
            });

            invoiceStorage = InvoiceHelper.Add(invoiceStorage, new Invoice()
            {
                Id = 2,
                Customer_Id = 1,
                Costs = 200,
                Description = "Other things",
                Payment_Date = DateTime.Now.AddDays(12).Date
            });

            invoiceStorage = InvoiceHelper.Add(invoiceStorage, new Invoice()
            {
                Id = 3,
                Customer_Id = 2,
                Costs = 1000,
                Description = "Fruit and things",
                Payment_Date = DateTime.Now.AddDays(7).Date
            });

            invoiceStorage = InvoiceHelper.Add(invoiceStorage, new Invoice()
            {
                Id = 4,
                Customer_Id = 3,
                Costs = 2000,
                Description = "Clothes and other boring stuff",
                Payment_Date = DateTime.Now.AddDays(3).Date
            });

            invoiceGridView.DataSource = invoiceStorage;
        }

        private void InitializeCustomers()
        {


            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = 1,
                Customer_Name = "Bruce",
                Customer_Address = "12 Long St"
            });

            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = 2,
                Customer_Name = "Martha",
                Customer_Address = "23 Short St"
            });

            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = 3,
                Customer_Name = "Helen",
                Customer_Address = "21 Tall St"
            });

            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = 4,
                Customer_Name = "Maria",
                Customer_Address = "49 Windy St"
            });


            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = 5,
                Customer_Name = "Peter Smith",
                Customer_Address = "49 High St"
            });


         


           customerGridView.DataSource = customerStorage;
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

            //customerBindingSource.Add(new Customer() { Id = customer_id, Customer_Name = txtCustomerName.Text, Customer_Address = txtCustomerAddress.Text });
            customerStorage = CustomerHelpers.AddOrUpdate(customerStorage, new Customer()
            {
                Id = customer_id,
                Customer_Name = txtCustomerName.Text,
                Customer_Address = txtCustomerAddress.Text
            });

            customerGridView.DataSource = customerBindingSource.DataSource;
            customerGridView.DataSource = customerStorage;
            
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerId.Text = CustomerHelpers.GetNextId(customerStorage).ToString();

            btnAddCustomer.Text = "Add";
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



            if (stringToIntConversionSuccess == true && stringToDoubleConversionSuccess == true)
            {
                invoiceStorage = InvoiceHelper.Add(invoiceStorage ,new Invoice() { Id = invoice_id, Customer_Id = selected_customer_id, Description = txtInvoiceDescription.Text, Costs = invoice_cost, Payment_Date = dtpInvoiceDate.Value });
            }
            txtCost.Text = "$";
            txtInvoiceDescription.Text = "";
            txtInvoiceId.Text = (invoice_id + 1).ToString();

            //invoiceGridView.DataSource = invoiceStorage;
            ViewInvoicesForCustomer();
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
            Application.Exit();
        }


        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            string customerSearchText = txtCustomerSearch.Text;

            if (customerSearchText == string.Empty)
            {
                MessageBox.Show("You knobhead enter a name");
            }
            else
            {
                Customer[] filteredCustomers = CustomerHelpers.FilterByName(customerStorage, customerSearchText);
                FilteredCustomers(filteredCustomers);
            }
        }

        private void SearchForCustomerById()
        {
            Customer[] filteredCustomers = CustomerHelpers.FilterByCustomerId(customerStorage, selected_customer_id);
            FilteredCustomers(filteredCustomers);
        }

        private void FilteredCustomers(Customer[] filteredCustomers)
        {

            if (filteredCustomers.Length > 0)
            {

                selected_customer_id = filteredCustomers[0].Id;
                selected_customer_Name = filteredCustomers[0].Customer_Name;

                UpdateInvoiceLabels();

            }

            customerGridView.DataSource = filteredCustomers;
        }

        private void btnInvoiceSearch_Click(object sender, EventArgs e)
        {

            int result = 0;

            Invoice[] FilteredInvoices;

            if (int.TryParse(txtInvoiceSearch.Text, out result))
            {
                FilteredInvoices = InvoiceHelper.FilterByInvoiceId(invoiceStorage, result);

                if (FilteredInvoices.Length > 0)
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
    }
}
