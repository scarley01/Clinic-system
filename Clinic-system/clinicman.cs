using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_system
{
    public partial class clinicman : Form
    {
        public clinicman()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clinicman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();    
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            appman app = new appman();  
            app.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patman pat = new patman();
            pat.Show();
            this.Hide();
        }
    }
}
