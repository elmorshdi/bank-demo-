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
    public partial class customer : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        public customer()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select*  from customer ", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "customer_id";
            comboBox1.ValueMember = "customer_id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            cmd = new SqlCommand("select customer_name,customer_id,customer_city,customer_street from customer where customer_id='" + comboBox1.Text + "'", Con);
            Con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            txtcname.Text = dr["customer_name"].ToString();
            txtid.Text = dr["customer_id"].ToString();
            txtcity.Text = dr["customer_city"].ToString();
            txtstreet.Text = dr["customer_street"].ToString();
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
        try { 
            cmd = new SqlCommand("insert into customer values('" + txtid.Text + "','" + txtcname.Text + "','" + txtcity.Text + "','"+txtstreet.Text+"')", Con);
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
            cmd = new SqlCommand("update customer set  customer_name='" + txtcname.Text + "',customer_city='" + txtcity.Text + "',customer_street='" + txtstreet.Text + "' where customer_id='" + comboBox1.Text + "'", Con);
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
            cmd = new SqlCommand("Delete from customer where customer_id='" + comboBox1.Text + "'", Con);
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

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        try { 
            dt.Clear();
            da = new SqlDataAdapter("select*  from customer", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "customer_id";
            comboBox1.ValueMember = "customer_id";
            txtcity.Clear();
            txtcname.Clear();
            txtid.Clear();
            txtstreet.Clear();
        }
            catch (SqlException ex)
            {
                MessageBox.Show("Erorr!" + "\n" + ex.Message);
            }
           
        }
    }
}
