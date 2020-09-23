using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank
{
    public partial class credit_card : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        public credit_card()
        {
            try
            {
                InitializeComponent();
                dt.Clear();
                da = new SqlDataAdapter("select*  from credit_card", Con);
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "credit_card_number";
                comboBox1.ValueMember = "credit_card_number";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select credit_card_number,customer_id,account_number,limit from credit_card where credit_card_number=" + comboBox1.Text + "", Con);
                Con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                txtid.Text = dr["customer_id"].ToString();
                txtcnum.Text = dr["credit_card_number"].ToString();
                txtanum.Text = dr["account_number"].ToString();
                txtlimit.Text = dr["limit"].ToString();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
            finally
            {
                dr.Close();
                Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("insert into credit_card values(" + txtcnum.Text + "," + txtid.Text + ",'" + txtanum.Text + "'," + txtlimit.Text + ")", Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("add Done!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update credit_card set limit=" + txtlimit.Text + ",customer_id=" + txtid.Text + " ,account_number='" + txtanum.Text + "' where credit_card_number=" + comboBox1.Text + "", Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("update Done!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Delete from credit_card where credit_card_number=" + comboBox1.Text + "", Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("row deleted!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt.Clear();
            da = new SqlDataAdapter("select*  from credit_card", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "credit_card_number";
            comboBox1.ValueMember = "credit_card_number";
            txtid.Clear();
            txtlimit.Clear();
            txtcnum.Clear();
            txtanum.Clear();

        }

        private void credit_card_Load(object sender, EventArgs e)
        {

        }
    }
}
