namespace Assessment_One
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblCustomerList = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvoice = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Payment_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceGridView = new System.Windows.Forms.DataGridView();
            this.txtInvoiceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInvoiceDescription = new System.Windows.Forms.Label();
            this.txtInvoiceDescription = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInvoiceList = new System.Windows.Forms.Label();
            this.lblNewInvoice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoiceSearch = new System.Windows.Forms.TextBox();
            this.btnInvoiceSearch = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.AllowUserToAddRows = false;
            this.customerGridView.AutoGenerateColumns = false;
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Customer_Name,
            this.customerAddressDataGridViewTextBoxColumn,
            this.Invoice,
            this.Edit});
            this.customerGridView.DataSource = this.customerBindingSource;
            this.customerGridView.Location = new System.Drawing.Point(182, 63);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.Size = new System.Drawing.Size(634, 150);
            this.customerGridView.TabIndex = 0;
            this.customerGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewInvoices_CellContentClick);
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Invoice
            // 
            this.Invoice.HeaderText = "";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            this.Invoice.Text = "View Invoices";
            this.Invoice.UseColumnTextForButtonValue = true;
            this.Invoice.Width = 125;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 125;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(227, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer Id";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(220, 252);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerId.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(326, 252);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(152, 20);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(484, 252);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(136, 20);
            this.txtCustomerAddress.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(333, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Customer Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(494, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer Address";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(637, 252);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 27);
            this.btnAddCustomer.TabIndex = 14;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblCustomerList
            // 
            this.lblCustomerList.AutoSize = true;
            this.lblCustomerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerList.Location = new System.Drawing.Point(179, 28);
            this.lblCustomerList.Name = "lblCustomerList";
            this.lblCustomerList.Size = new System.Drawing.Size(83, 13);
            this.lblCustomerList.TabIndex = 22;
            this.lblCustomerList.Text = "Customer List";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Search for Customers by Name";
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(348, 42);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(136, 20);
            this.txtCustomerSearch.TabIndex = 4;
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(490, 39);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerSearch.TabIndex = 22;
            this.btnCustomerSearch.Text = "Search";
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.image1ToolStripMenuItem,
            this.image2ToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.exitToolStripMenuItem.Text = "Background";
            // 
            // image1ToolStripMenuItem
            // 
            this.image1ToolStripMenuItem.Name = "image1ToolStripMenuItem";
            this.image1ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.image1ToolStripMenuItem.Text = "Image 1";
            this.image1ToolStripMenuItem.Click += new System.EventHandler(this.image1ToolStripMenuItem_Click);
            // 
            // image2ToolStripMenuItem
            // 
            this.image2ToolStripMenuItem.Name = "image2ToolStripMenuItem";
            this.image2ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.image2ToolStripMenuItem.Text = "Image 2";
            this.image2ToolStripMenuItem.Click += new System.EventHandler(this.image2ToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // EditInvoice
            // 
            this.EditInvoice.HeaderText = "";
            this.EditInvoice.Name = "EditInvoice";
            this.EditInvoice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditInvoice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditInvoice.Text = "Edit";
            // 
            // Payment_Date
            // 
            this.Payment_Date.DataPropertyName = "Payment_Date";
            this.Payment_Date.HeaderText = "Payment Date";
            this.Payment_Date.Name = "Payment_Date";
            this.Payment_Date.Width = 80;
            // 
            // invoiceGridView
            // 
            this.invoiceGridView.AllowUserToAddRows = false;
            this.invoiceGridView.AutoGenerateColumns = false;
            this.invoiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoiceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.customerIdDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.costsDataGridViewTextBoxColumn,
            this.Payment_Date,
            this.EditInvoice});
            this.invoiceGridView.DataSource = this.invoiceBindingSource;
            this.invoiceGridView.Location = new System.Drawing.Point(182, 319);
            this.invoiceGridView.Name = "invoiceGridView";
            this.invoiceGridView.Size = new System.Drawing.Size(634, 150);
            this.invoiceGridView.TabIndex = 1;
            this.invoiceGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoiceGridView_CellContentClick);
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Location = new System.Drawing.Point(220, 534);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.ReadOnly = true;
            this.txtInvoiceId.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(227, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Invoice Id";
            // 
            // lblInvoiceDescription
            // 
            this.lblInvoiceDescription.Location = new System.Drawing.Point(333, 509);
            this.lblInvoiceDescription.Name = "lblInvoiceDescription";
            this.lblInvoiceDescription.Size = new System.Drawing.Size(100, 23);
            this.lblInvoiceDescription.TabIndex = 10;
            this.lblInvoiceDescription.Text = "Description";
            // 
            // txtInvoiceDescription
            // 
            this.txtInvoiceDescription.Location = new System.Drawing.Point(326, 534);
            this.txtInvoiceDescription.Name = "txtInvoiceDescription";
            this.txtInvoiceDescription.Size = new System.Drawing.Size(152, 20);
            this.txtInvoiceDescription.TabIndex = 11;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(484, 534);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(92, 20);
            this.txtCost.TabIndex = 12;
            this.txtCost.Text = "$";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(494, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cost";
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Enabled = false;
            this.btnAddInvoice.Location = new System.Drawing.Point(706, 530);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(75, 26);
            this.btnAddInvoice.TabIndex = 15;
            this.btnAddInvoice.Text = "Add";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(603, 534);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(87, 20);
            this.dtpInvoiceDate.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Payment Date";
            // 
            // lblInvoiceList
            // 
            this.lblInvoiceList.AutoSize = true;
            this.lblInvoiceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceList.Location = new System.Drawing.Point(179, 289);
            this.lblInvoiceList.Name = "lblInvoiceList";
            this.lblInvoiceList.Size = new System.Drawing.Size(0, 13);
            this.lblInvoiceList.TabIndex = 19;
            // 
            // lblNewInvoice
            // 
            this.lblNewInvoice.AutoSize = true;
            this.lblNewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewInvoice.Location = new System.Drawing.Point(179, 490);
            this.lblNewInvoice.Name = "lblNewInvoice";
            this.lblNewInvoice.Size = new System.Drawing.Size(0, 13);
            this.lblNewInvoice.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Search for Invoices by Id";
            // 
            // txtInvoiceSearch
            // 
            this.txtInvoiceSearch.Location = new System.Drawing.Point(348, 296);
            this.txtInvoiceSearch.Name = "txtInvoiceSearch";
            this.txtInvoiceSearch.Size = new System.Drawing.Size(136, 20);
            this.txtInvoiceSearch.TabIndex = 24;
            // 
            // btnInvoiceSearch
            // 
            this.btnInvoiceSearch.Location = new System.Drawing.Point(490, 294);
            this.btnInvoiceSearch.Name = "btnInvoiceSearch";
            this.btnInvoiceSearch.Size = new System.Drawing.Size(75, 23);
            this.btnInvoiceSearch.TabIndex = 25;
            this.btnInvoiceSearch.Text = "Search";
            this.btnInvoiceSearch.UseVisualStyleBackColor = true;
            this.btnInvoiceSearch.Click += new System.EventHandler(this.btnInvoiceSearch_Click);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Invoice Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "Customer_Id";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "Customer Id";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Width = 75;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // costsDataGridViewTextBoxColumn
            // 
            this.costsDataGridViewTextBoxColumn.DataPropertyName = "Costs";
            this.costsDataGridViewTextBoxColumn.HeaderText = "Costs";
            this.costsDataGridViewTextBoxColumn.Name = "costsDataGridViewTextBoxColumn";
            this.costsDataGridViewTextBoxColumn.Width = 50;
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataSource = typeof(Assessment_One.DataEntities.Invoice);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Customer Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 75;
            // 
            // customerAddressDataGridViewTextBoxColumn
            // 
            this.customerAddressDataGridViewTextBoxColumn.DataPropertyName = "Customer_Address";
            this.customerAddressDataGridViewTextBoxColumn.HeaderText = "Customer Address";
            this.customerAddressDataGridViewTextBoxColumn.Name = "customerAddressDataGridViewTextBoxColumn";
            this.customerAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerAddressDataGridViewTextBoxColumn.Width = 150;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(Assessment_One.DataEntities.Customer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 601);
            this.Controls.Add(this.btnInvoiceSearch);
            this.Controls.Add(this.txtInvoiceSearch);
            this.Controls.Add(this.btnCustomerSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNewInvoice);
            this.Controls.Add(this.lblInvoiceList);
            this.Controls.Add(this.lblCustomerList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtInvoiceDescription);
            this.Controls.Add(this.lblInvoiceDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvoiceId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.txtCustomerSearch);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoiceGridView);
            this.Controls.Add(this.customerGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label lblCustomerList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem image1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem image2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Invoice;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn EditInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn costsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView invoiceGridView;
        private System.Windows.Forms.TextBox txtInvoiceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInvoiceDescription;
        private System.Windows.Forms.TextBox txtInvoiceDescription;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInvoiceList;
        private System.Windows.Forms.Label lblNewInvoice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceSearch;
        private System.Windows.Forms.Button btnInvoiceSearch;
    }
}

