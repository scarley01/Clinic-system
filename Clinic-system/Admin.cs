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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void doctors_Click(object sender, EventArgs e)
        {
            this.Hide();
            docman docman = new docman();
            docman.Show();
        }

        private void accounts_Click(object sender, EventArgs e)
        {
            this.Hide();
            accman accman = new accman();
            accman.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //logout 
            this.Hide();
            Login login = new Login();
            login.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
