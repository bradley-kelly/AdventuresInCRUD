using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdventuresInCRUD
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            CustomerData();
        }
        private void CustomerData()
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCust", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource binding = new BindingSource();
                binding.DataSource = dt;
                customerGridView.DataSource = dt;
            }
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            customerGridView.Rows[customerGridView.CurrentCell.RowIndex].Selected = true;
            string es = string.Empty;
            var customerID = customerGridView.SelectedRows[0].Cells[0].Value;
            var addressID = customerGridView.SelectedRows[0].Cells[12].Value;
            string title = es, fName = es, mName = es, lName = es, suffix = es, cName = es, sPerson = es, email = es, pNumber = es, pHash = es,
            pSalt = es, addID = es, addT = es, addL1 = es, addL2 = es, city = es, state = es, country = es, pCode = es, rowguid = es, mDate = es;
            var c = customerGridView.SelectedRows;
            foreach (DataGridViewRow cell in c)
            {
                title = cell.Cells[1].Value.ToString();
                fName = cell.Cells[2].Value.ToString();
                mName = cell.Cells[3].Value.ToString();
                lName = cell.Cells[4].Value.ToString();
                suffix = cell.Cells[5].Value.ToString();
                cName = cell.Cells[6].Value.ToString();
                sPerson = cell.Cells[7].Value.ToString();
                email = cell.Cells[8].Value.ToString();
                pNumber = cell.Cells[9].Value.ToString();
                pHash = cell.Cells[10].Value.ToString();
                pSalt = cell.Cells[11].Value.ToString();
                addID = cell.Cells[12].Value.ToString();
                addT = cell.Cells[13].Value.ToString();
                addL1 = cell.Cells[14].Value.ToString();
                addL2 = cell.Cells[15].Value.ToString();
                city = cell.Cells[16].Value.ToString();
                state = cell.Cells[17].Value.ToString();
                country = cell.Cells[18].Value.ToString();
                pCode = cell.Cells[19].Value.ToString();
                rowguid = cell.Cells[20].Value.ToString();
                mDate = cell.Cells[21].Value.ToString();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("CreateCust", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@firstName", fName);
                cmd.Parameters.AddWithValue("@lastName", lName);
                cmd.Parameters.AddWithValue("@middleName", mName);
                cmd.Parameters.AddWithValue("@suffix", suffix);
                cmd.Parameters.AddWithValue("@companyName", cName);
                cmd.Parameters.AddWithValue("@salesPerson", sPerson);
                cmd.Parameters.AddWithValue("@emailAddress", email);
                cmd.Parameters.AddWithValue("@phone", pNumber);
                cmd.Parameters.AddWithValue("@PasswordHash", pHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", pSalt);
                cmd.Parameters.AddWithValue("@modifydate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@addressLine1", addL1);
                cmd.Parameters.AddWithValue("@addressLine2", addL2);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@stateProvince", state);
                cmd.Parameters.AddWithValue("@countryRegion", country);
                cmd.Parameters.AddWithValue("@postalCode", pCode);
                cmd.Parameters.AddWithValue("@modifiedDate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCustID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                customerID = dr.GetInt32(0);
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetAddID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                addressID = dr.GetInt32(0);
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                customerGridView.SelectedRows[0].Cells[0].Value.ToString();
                SqlCommand cmd = new SqlCommand("InsertCustAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", customerID);
                cmd.Parameters.AddWithValue("@addID", addressID);
                cmd.Parameters.AddWithValue("@addressType", addT);
                cmd.Parameters.AddWithValue("@modifiedDate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            CustomerData();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            customerGridView.Rows[customerGridView.CurrentCell.RowIndex].Selected = true;
            string es = string.Empty;
            var customerID = customerGridView.SelectedRows[0].Cells[0].Value;
            var addressID = customerGridView.SelectedRows[0].Cells[12].Value;
            string title = es, fName = es, mName = es, lName = es, suffix = es, cName = es, sPerson = es, email = es, pNumber = es, pHash = es,
            pSalt = es, addID = es, addT = es, addL1 = es, addL2 = es, city = es, state = es, country = es, pCode = es, rowguid = es, mDate = es;
            var c = customerGridView.SelectedRows;
            foreach (DataGridViewRow cell in c)
            {
                title = cell.Cells[1].Value.ToString();
                fName = cell.Cells[2].Value.ToString();
                mName = cell.Cells[3].Value.ToString();
                lName = cell.Cells[4].Value.ToString();
                suffix = cell.Cells[5].Value.ToString();
                cName = cell.Cells[6].Value.ToString();
                sPerson = cell.Cells[7].Value.ToString();
                email = cell.Cells[8].Value.ToString();
                pNumber = cell.Cells[9].Value.ToString();
                pHash = cell.Cells[10].Value.ToString();
                pSalt = cell.Cells[11].Value.ToString();
                addID = cell.Cells[12].Value.ToString();
                addT = cell.Cells[13].Value.ToString();
                addL1 = cell.Cells[14].Value.ToString();
                addL2 = cell.Cells[15].Value.ToString();
                city = cell.Cells[16].Value.ToString();
                state = cell.Cells[17].Value.ToString();
                country = cell.Cells[18].Value.ToString();
                pCode = cell.Cells[19].Value.ToString();
                rowguid = cell.Cells[20].Value.ToString();
                mDate = cell.Cells[21].Value.ToString();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCust", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", customerID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@firstName", fName);
                cmd.Parameters.AddWithValue("@lastName", lName);
                cmd.Parameters.AddWithValue("@middleName", mName);
                cmd.Parameters.AddWithValue("@suffix", suffix);
                cmd.Parameters.AddWithValue("@companyName", cName);
                cmd.Parameters.AddWithValue("@salesPerson", sPerson);
                cmd.Parameters.AddWithValue("@emailAddress", email);
                cmd.Parameters.AddWithValue("@phone", pNumber);
                cmd.Parameters.AddWithValue("@PasswordHash", pHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", pSalt);
                cmd.Parameters.AddWithValue("@modifydate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCustAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Parameters.AddWithValue("@addressID", addID);
                cmd.Parameters.AddWithValue("@addressType", addT);
                cmd.Parameters.AddWithValue("@modifiedDate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@addressID", addID);
                cmd.Parameters.AddWithValue("@addressLine1", addL1);
                cmd.Parameters.AddWithValue("@addressLine2", addL2);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@stateProvince", state);
                cmd.Parameters.AddWithValue("@countryRegion", country);
                cmd.Parameters.AddWithValue("@postalCode", pCode);
                cmd.Parameters.AddWithValue("@modifiedDate", mDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            CustomerData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            customerGridView.Rows[customerGridView.CurrentCell.RowIndex].Selected = true;
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                var custID = customerGridView.SelectedRows[0].Cells[0].Value;
                var addID = customerGridView.SelectedRows[0].Cells[13].Value;
                SqlCommand cmd = new SqlCommand("DelCust", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@addressID", addID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            CustomerData();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            CustomerData();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            var home = new Home();
            this.Hide();
            home.Show();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            var product = new Products();
            this.Hide();
            product.Show();
        }
    }
}