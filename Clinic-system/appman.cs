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
    public partial class appman : Form
    {
        int rowID;
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public appman()
        {
            InitializeComponent();
        }

        private void appman_Load(object sender, EventArgs e)
        {
            load();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dataGridView1.ClearSelection();
            //Load the doctors into the combobox
            string query = "SELECT First_Name,Last_Name FROM Doctors";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            try
            {


                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    comboBox2.Items.Add(sdr[0]).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            //Load the patients into the combobox
            string query2 = "SELECT First_Name,Last_Name FROM Patients";
            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand cmd2 = new SqlCommand(query2, con2);
         con2.Open();
            try
            {

               
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                    comboBox1.Items.Add(sdr2[0]).ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }con2.Close();
        }
                               
            

        

        private void load()
        {
            string query = "SELECT * FROM App";
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
       

        private void button1_Click(object sender, EventArgs e)
        {
            //add new appointment to the database 
            string query = "INSERT INTO App (Status, Location, Doctor, Patient, Date, Time) VALUES (@Status,@Location, @Doctor,@Patient,@Date,@Time)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Status", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Location", textBox1.Text);
            cmd.Parameters.AddWithValue("@Doctor", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Patient", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Text);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment added successfully");
              
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox1.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            load();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            clinicman c = new clinicman();
            c.Show();

        }

        private void appman_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            clinicman c = new clinicman();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete the selected appointment
            string query = "Delete From App Where App_id = @ID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", rowID);
            MessageBox.Show("Are you sure you want to delete this appointment?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
                MessageBox.Show("Appointment Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
          
            
                rowID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                comboBox3.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Text = row.Cells[5].Value.ToString();
                dateTimePicker2.Text = row.Cells[6].Value.ToString();
                //Do not have it selected when the form loads
                dataGridView1.ClearSelection();
            
        }
    }
}
