using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bank
{
    public partial class branch : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        public branch()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select*  from branch", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "branch_name";
            comboBox1.ValueMember = "branch_name";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void branch_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("select branch_name,branch_city,assets from branch where branch_name='" + comboBox1.Text+"'", Con);
            Con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            txtname.Text = dr["branch_name"].ToString();
            txtcity.Text= dr["branch_city"].ToString();
            textBox1.Text = dr["assets"].ToString();
            
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

        private void button3_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("update branch set branch_city='"+ txtcity.Text + "',assets="+textBox1.Text+" where branch_name='" + comboBox1.Text + "'", Con);
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
            }        }
        private void button2_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("insert into branch values('" + txtname.Text + "','"+ txtcity.Text + "',"+textBox1.Text+")", Con);
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

        private void button4_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("Delete from branch where branch_name='" + comboBox1.Text + "'", Con);
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

            da = new SqlDataAdapter("select*  from branch", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "branch_name";
            comboBox1.ValueMember = "branch_name";
            txtcity.Clear();
            textBox1.Clear();
            txtname.Clear();
        }
    }
}
