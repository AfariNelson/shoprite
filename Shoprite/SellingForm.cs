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
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aferi\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select ProdName, ProdQty from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdName.Text = ProdDGV1.SelectedRows[0].Cells[0].Value.ToString();
            ProdPrice.Text = ProdDGV1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            int Grdtotal = 0;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(OrderDGV);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = ProdName.Text;
            newRow.Cells[2].Value = ProdPrice.Text;
            newRow.Cells[3].Value = ProdQty.Text;
            newRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            OrderDGV.Rows.Add(newRow);
            int total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            Grdtotal = Grdtotal + total;
            Amtlbl.Text = "GHc" + Grdtotal;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
