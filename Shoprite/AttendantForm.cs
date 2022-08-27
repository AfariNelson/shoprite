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
    public partial class AttendantForm : Form
    {
        public AttendantForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aferi\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from AttendantTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AttendantDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (AttendantId.Text == "")
                {
                    MessageBox.Show("Select The Attendant To Remove");
                }
                else
                {
                    Con.Open();
                    string query = "Delete from AttendantTbl where Attendantid=" + AttendantId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendant Removed Successfully");
                    Con.Close();
                    populate();
                    AttendantId.Text = "";
                    AttendantName.Text = "";
                    AttendantPhone.Text = "";
                    AttendantAge.Text = "";
                    AttendantPass.Text = "";



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AttendantDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
                                                            
        }

        private void AttendantForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                String query = "insert into AttendantTbl values('" + AttendantId.Text + "','" + AttendantName.Text + "','" + AttendantAge.Text + "', '"+ AttendantPhone.Text + "', '"+ AttendantPass.Text +"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendant Added Successfully");
                Con.Close();
                populate();
                AttendantId.Text = "";
                AttendantName.Text = "";
                AttendantPhone.Text = "";
                AttendantAge.Text = "";
                AttendantPass.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AttendantDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            AttendantId.Text = AttendantDGV.SelectedRows[0].Cells[0].Value.ToString();
            AttendantName.Text = AttendantDGV.SelectedRows[0].Cells[1].Value.ToString();
            AttendantAge.Text = AttendantDGV.SelectedRows[0].Cells[2].Value.ToString();
            AttendantPhone.Text = AttendantDGV.SelectedRows[0].Cells[3].Value.ToString();
            AttendantPass.Text = AttendantDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (AttendantId.Text == "" || AttendantName.Text == "" || AttendantPhone.Text == "" || AttendantAge.Text == "" || AttendantPass.Text == "" )
                {
                    MessageBox.Show("Input New Data");
                }
                else
                {
                    Con.Open();
                    string query = "Update AttendantTbl set AttendantName = '" + AttendantName.Text + "', AttendantId = '" + AttendantId.Text +"' , AttendantAge = '" + AttendantAge.Text+ "' , AttendantPass = '" + AttendantPass.Text + "', AttendantPhone= '" + AttendantPhone.Text + "' where AttendantId = '" + AttendantId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendant Details Updated Successfully");
                    Con.Close();
                    populate();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
