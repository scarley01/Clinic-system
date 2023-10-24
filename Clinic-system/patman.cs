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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinic_system
{
    public partial class patman : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        int rowID;
        public patman()
        {
            InitializeComponent();
        }
        private void load()
        {
            string query = "SELECT * FROM Patients";
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

        private void patman_Load(object sender, EventArgs e)
        {
            load();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.Text = "";
            dateTimePicker1.Text = "";

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            dateTimePicker1.Text = row.Cells[7].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox4.Text = row.Cells[6].Value.ToString();
            //Do not have it selected when the form loads
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add new patient to database and refresh the datagridview

            string query = "Insert Into Patients(First_Name, Last_Name,Sex, Address, Zip, Phone, DOB) VALUES(@Fname, @Lname, @Sex, @Address, @Zip, @Phone, @DOB)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Sex", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Zip", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
            //check if the fields are empty
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
                MessageBox.Show("Patient Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            clinicman clinicman = new clinicman();
            clinicman.Show();
            
        }

        private void patman_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            clinicman clinicman = new clinicman();
            clinicman.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update Patient
            string query = "Update Patients Set First_Name = @Fname, Last_Name = @Lname, Sex = @sex, Address= @address, Zip = @zip, Phone = @phone, DOB = @DOB";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Sex", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Zip", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
            //check if the fields are empty
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
                MessageBox.Show("Patient Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete Patient from database and refresh the datagridview
            string query = "Delete From Patients Where Patient_ID = @ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);    
            cmd.Parameters.AddWithValue("@ID", rowID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
                MessageBox.Show("Patient Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }
    }
}
