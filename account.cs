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
    public partial class account : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public account()
        {
            InitializeComponent();
           
            da = new SqlDataAdapter("select*  from account", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "account_number";
            comboBox1.ValueMember = "account_number";
            txtanum.Clear();
            txtbalance.Clear();
            txtbname.Clear();
        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("select account_number,branch_name,balance from account where account_number='" + comboBox1.Text + "'", Con);
            Con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            txtanum.Text = dr["account_number"].ToString();
            txtbname.Text = dr["branch_name"].ToString();
            txtbalance.Text = dr["balance"].ToString();
         
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
        { try { 
            cmd = new SqlCommand("insert into account values('"+txtanum.Text+"','" + txtbname.Text + "'," + txtbalance.Text + ")", Con);
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
        try { 

            cmd = new SqlCommand("update employee set branch_name='" + txtbname.Text + "',account_number='" + txtanum.Text + "',balance=" + txtbalance.Text + " where account_number='" + comboBox1.Text + "'", Con);
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
        try { 
            cmd = new SqlCommand("Delete from account where account_number='" + comboBox1.Text + "'", Con);
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
            da = new SqlDataAdapter("select*  from account", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "account_number";
            comboBox1.ValueMember = "account_number";
            txtanum.Clear();
            txtbalance.Clear();
            txtbname.Clear();
        }
    }
}
