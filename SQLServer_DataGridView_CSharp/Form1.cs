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
using System.Net.Configuration;

namespace SQLServer_DataGridView_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetPersonsList();
        }

        private DataTable GetPersonsList()
        {
            DataTable dtPersons = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;


            using (SqlConnection objConnection = new SqlConnection(conString))
            {
                using (SqlCommand objCommand = new SqlCommand("SELECT * FROM Table_Users", objConnection))
                {
                    objConnection.Open();

                    SqlDataReader reader = objCommand.ExecuteReader();

                    dtPersons.Load(reader);
                }
            }

            return dtPersons;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
