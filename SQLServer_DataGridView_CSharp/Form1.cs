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
        //declare the classes + the names of the objects
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public Form1()
        {
            //constructor
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonShowRecords_Click(object sender, EventArgs e)
        {
            //define the connection string
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0U8N3MS\\MSSQLSERVER2020;Initial Catalog=MagazinDb;Integrated Security=True");

            //the object instantiates the SqlDataAdapter class with arguments
            //specify which table (with the primary key) you will use as the first argument 
            //and the second argument is the connection string
            sda = new SqlDataAdapter("SELECT * FROM Table_Users", connection);

            //the object instantiates the DataTable class without arguments
            dt = new DataTable();

            //fill the data table
            sda.Fill(dt);

            //set the data source -> the dt object returns a data table
            dataGridView1.DataSource = dt;
        }

        private void buttonUpdateRecord_Click(object sender, EventArgs e)
        {
            //the object instantiates the SqlCommandBuilder class with argument(the sda object)
            scb = new SqlCommandBuilder(sda);

            //update the values in the database
            sda.Update(dt);
        }

    }
}
