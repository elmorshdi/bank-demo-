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
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=MOSTAFA\MYSQL; Initial Catalog=Bank; Integrated Security=True");
       
        public Form1()
        {
            InitializeComponent();
        }
     
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         branch frm = new branch();
         frm.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            credit_card frm = new credit_card();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            customer frm = new customer();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            account frm = new account();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loan frm = new loan();
            frm.Show();
        }
    }
}
