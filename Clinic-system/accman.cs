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
    public partial class accman : Form
    {

        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        int rowID;
        public accman()
        {
            InitializeComponent();
        }
        private void load()
        {

            string query = "SELECT * FROM Login";
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


        private void accman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void accman_Load(object sender, EventArgs e)
        {
            load();

            dataGridView1.ClearSelection();
            //clear the textboxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "INSERT INTO Login(Username, Password, Status) VALUES(@Username, @Password, @Status)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            //Check if the textboxes are empty or not
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            load();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin admin = new Admin();
            admin.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "UPDATE Login SET Username=@Username, Password=@Password, Status=@Status WHERE Login_id=@ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ID", rowID);
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            load();
        }

        
        

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            rowID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Login WHERE Login_id=@ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", rowID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Login deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            load();
        }
    }
}
