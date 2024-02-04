using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MiniSqlDerleyici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {

                MessageBox.Show("Sorgunuzu kontrol edin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;

            connection.Open();
            SqlCommand komut = new SqlCommand(sorgu,connection);
            komut.ExecuteNonQuery();
            connection.Close();

            SqlDataAdapter da1 = new SqlDataAdapter("Select * From TBLDERS", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
           dataGridView1.DataSource= dt1;


        }
    }
}