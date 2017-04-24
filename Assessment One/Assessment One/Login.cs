using System;
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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "lister" && txtPass.Text == "1472")
            {
                MessageBox.Show("Welcome");
                this.Hide();
                new Form1().Show();

            }
            else
            {
                string message = "Try again";
                MessageBox.Show(message);
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
            }
        }
    }
}
