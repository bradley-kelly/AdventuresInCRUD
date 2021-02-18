using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdventuresInCRUD
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            ProductData();
        }
        private void ProductData()
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetProd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource binding = new BindingSource();
                binding.DataSource = dt;
                productGridView.DataSource = dt;
            }
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            var home = new Home();
            this.Hide();
            home.Show();
        }
        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            var customer = new Customers();
            this.Hide();
            customer.Show();
        }
    }
}