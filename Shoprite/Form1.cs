using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shoprite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string Attendantname = "";
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aferi\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

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
                        // MessageBox.Show("Correct Admin Password is Required");
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(8) from AttendantTbl where AttendantName='" + usernametb.Text + "'and AttendantPass='" + passwordtb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Attendantname = usernametb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();

                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                        }
                        Con.Close();
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

