namespace Clinic_system
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.doctors = new System.Windows.Forms.Button();
            this.accounts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // doctors
            // 
            this.doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.doctors.Location = new System.Drawing.Point(412, 12);
            this.doctors.Name = "doctors";
            this.doctors.Size = new System.Drawing.Size(172, 59);
            this.doctors.TabIndex = 1;
            this.doctors.Text = "Manage Doctors";
            this.doctors.UseVisualStyleBackColor = true;
            this.doctors.Click += new System.EventHandler(this.doctors_Click);
            // 
            // accounts
            // 
            this.accounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.accounts.Location = new System.Drawing.Point(412, 77);
            this.accounts.Name = "accounts";
            this.accounts.Size = new System.Drawing.Size(172, 59);
            this.accounts.TabIndex = 2;
            this.accounts.Text = "Manage Accounts";
            this.accounts.UseVisualStyleBackColor = true;
            this.accounts.Click += new System.EventHandler(this.accounts_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(412, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.Location = new System.Drawing.Point(412, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 384);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.accounts);
            this.Controls.Add(this.doctors);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Admin";
            this.Text = "Admin Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button doctors;
        private System.Windows.Forms.Button accounts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}