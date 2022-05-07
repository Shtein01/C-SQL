using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private SqlConnection SqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            SqlConnection.Open();

            /*if (SqlConnection.State == ConnectionState.Open)
	        {
                MessageBox.Show("Подключение установлено!");
	        } */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                "insert into [department] (id, name) values (@id, @name)",
                SqlConnection );
            command.Parameters.AddWithValue("id", textBox1.Text);
            command.Parameters.AddWithValue("name", textBox2.Text);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DataAdapter = new SqlDataAdapter(
                "select d.name, sum(e.salary) as summa from department as d, employee as e where d.Id = e.department_id group by d.name",
                SqlConnection);
            DataSet dataSet = new DataSet();
            DataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DataAdapter1_2 = new SqlDataAdapter(
                    "select d.name, sum(e.salary) as summa, e.chief_id from department as d, employee as e where d.Id = e.department_id group by d.name, e.chief_id",
                    SqlConnection);
            DataSet dataSet1_2 = new DataSet();
            DataAdapter1_2.Fill(dataSet1_2);
            dataGridView2.DataSource = dataSet1_2.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DataAdapter1_2 = new SqlDataAdapter(
                    "select d.name from department as d, employee as e where d.Id = e.department_id and e.salary = (select max(salary) from employee)",
                    SqlConnection);
            DataSet dataSet1_2 = new DataSet();
            DataAdapter1_2.Fill(dataSet1_2);
            dataGridView3.DataSource = dataSet1_2.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DataAdapter1_2 = new SqlDataAdapter(
                    "select name, salary from employee where id in (select distinct(chief_id) from employee where chief_id is not null) order by salary desc",
                    SqlConnection);
            DataSet dataSet1_2 = new DataSet();
            DataAdapter1_2.Fill(dataSet1_2);
            dataGridView4.DataSource = dataSet1_2.Tables[0];
        }
    }
}
