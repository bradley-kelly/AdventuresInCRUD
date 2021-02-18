using System;
using System.Windows.Forms;

namespace AdventuresInCRUD
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void BtnProducts_Click(object sender, EventArgs e)
        {
            var product = new Products();
            this.Hide();
            product.Show();
        }
        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            var customer = new Customers();
            this.Hide();
            customer.Show();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}