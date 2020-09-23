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
    public partial class employee : Form
    { 
    SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=ram_bank; Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
        SqlDataAdapter da;
       

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public employee()
        {
           
            InitializeComponent();
            da = new SqlDataAdapter("select*  from employee", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "employee_id";
            comboBox1.ValueMember = "employee_id";
            da = new SqlDataAdapter("select*  from branch", Con);
            da.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "branch_name";
            comboBox2.ValueMember = "branch_name";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("select employee_id,employee_name,branch_name,salary from employee where employee_id='" + comboBox1.Text + "'", Con);
            Con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
                txtid.Text = dr["employee_id"].ToString();
                txtename.Text = dr["employee_name"].ToString();
                comboBox2.DisplayMember=dr["branch_name"].ToString();
            txtsalary.Text = dr["salary"].ToString();
                
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

            dt2.Clear();
            da = new SqlDataAdapter("select  branch_name from employee where employee_id='" + comboBox1.Text + "'", Con);
            da.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "branch_name";
            comboBox2.ValueMember = "branch_name";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("insert into employee values('"+txtid.Text+"','" + txtename.Text+"','" + comboBox2.Text + "'," + txtsalary.Text + ")", Con);
            Con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("add Done!");
            
            }
            catch(SqlException ex) {
                MessageBox.Show("Erorr!"+"\n"+ex.Message);
            }
            finally 
            {
            Con.Close();
            }
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update employee set branch_name='"+comboBox2.Text+"',salary = "+txtsalary.Text+",employee_name = '"+txtename.Text+"' where employee_id = '"+comboBox1.Text+"'", Con);
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

        private void button4_Click_1(object sender, EventArgs e)
        {
        try { 
            cmd = new SqlCommand("Delete from employee where employee_id='" + comboBox1.Text + "'", Con);
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

        private void employee_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt.Clear();
            da = new SqlDataAdapter("select*  from employee", Con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "employee_id";
            comboBox1.ValueMember = "employee_id";
            dt2.Clear();
            da = new SqlDataAdapter("select*  from branch", Con);
            da.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "branch_name";
            comboBox2.ValueMember = "branch_name";
            txtename.Clear();
            txtsalary.Clear();
            txtid.Clear();

        }
    }
}
