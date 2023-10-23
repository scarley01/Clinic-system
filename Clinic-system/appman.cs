using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Clinic_system
{
    public partial class appman : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public appman()
        {
            InitializeComponent();
        }

        private void appman_Load(object sender, EventArgs e)
        {

        }
        private void load()
        {
            string query = "SELECT * FROM Doctors";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
