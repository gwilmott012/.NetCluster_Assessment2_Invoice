﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment_One
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            new Form1().Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text=="lister" && txtPass.Text=="1472")
            {
                new Form1().Show();
            }
            else if (txtUser.Text=="" || txtPass.Text=="")
            {
                MessageBox.Show("Please enter a value");
            }
        }
    }
}
