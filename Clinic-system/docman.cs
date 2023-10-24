using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Clinic_system
{
    public partial class docman : Form
    {
        int rowID;
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public docman()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //add doctors to the database and the table name is Doctors
            string query = "INSERT INTO Doctors(First_Name, Last_Name, Phone, Specialty) VALUES(@Fname, @Lname, @Phone, @Special)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Special", textBox4.Text);
            //Check if the textboxes are empty or not
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor added successfully");
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
        private void exit_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            //Do not have it selected when the form loads
            dataGridView1.ClearSelection();

          
        }

        private void docman_Load(object sender, EventArgs e)
        {
            load();
            //when load do not have a row selected
            dataGridView1.ClearSelection();
            //clear the text boxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();


        }

        private void docman_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Doctors SET First_Name=@Fname, Last_Name=@Lname, Phone=@Phone, Specialty=@Special WHERE Doctor_ID=@ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", rowID);
            cmd.Parameters.AddWithValue("@Fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Special", textBox4.Text);
         
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor updated successfully");
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

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete the selected row
            string query = "DELETE FROM Doctors WHERE Doctor_ID=@ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", rowID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor deleted successfully");
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
