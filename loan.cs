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
    public partial class loan : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public loan()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select*  from loan", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "loan_number";
            comboBox1.ValueMember = "loan_number";

        }

        private void loan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select loan_number,branch_name,amount from loan where loan_number='" + comboBox1.Text + "'", Con);
                Con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                txtanum.Text = dr["loan_number"].ToString();
                txtbname.Text = dr["branch_name"].ToString();
                txtbalance.Text = dr["amount"].ToString();

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
                    cmd = new SqlCommand("insert into loan values('" + txtanum.Text + "','" + txtbname.Text + "'," + txtbalance.Text + ")", Con);
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

                cmd = new SqlCommand("update loan set branch_name='" + txtbname.Text + "',loan_number='" + txtbname.Text + "',amount=" + txtbalance.Text + " where loan_number='" + comboBox1.Text + "'", Con);
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
                cmd = new SqlCommand("Delete from loan where loan_number='" + comboBox1.Text + "'", Con);
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
            da = new SqlDataAdapter("select*  from loan", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "loan_number";
            comboBox1.ValueMember = "loan_number";
            txtanum.Clear();
            txtbalance.Clear();
            txtbname.Clear();
        }
    }
}
