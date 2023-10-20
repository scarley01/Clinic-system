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
    public partial class Login : Form
    {
       
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string query = "SELECT * FROM Login WHERE username = '" + uname.Text.Trim() + "' AND password = '" + pword.Text.Trim() + "'";
            DataTable dt = new DataTable();
            
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            string query2 = "Select Status from Login WHERE username = '" + uname.Text.Trim() + "' AND password = '" + pword.Text.Trim() + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            con.Open();
            query2 = cmd2.ExecuteScalar().ToString();
            con.Close();
         
            if (dt.Rows.Count == 1 && query2 == "Admin")
            {
                Admin main = new Admin();
                
                main.Show();
                this.Hide();
                
                
            }
            else if(dt.Rows.Count == 1 && query2 == "Staff")
            {
                clinicman clinicman = new clinicman();
                clinicman.Show();
                this.Hide();
            }
            else
            {
               
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
      
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
