using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoprite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (usernametb.Text == "" || passwordtb.Text == "")
            {
                MessageBox.Show("Enter the Username and Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {

                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {
                        if (usernametb.Text == "Admin" && passwordtb.Text == "Admin") ;
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                    }
                    else

                    {
                        MessageBox.Show("Correct Admin Password is Required");
                    }
                    }
                

                else
                {
                    MessageBox.Show("Select a Role");
                }
                }
            }
        }
    }

