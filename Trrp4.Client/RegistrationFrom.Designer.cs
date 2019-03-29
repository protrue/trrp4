namespace Trrp4.Client
{
    partial class RegistrationFrom
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loginTB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.repitPasswordTB = new System.Windows.Forms.TextBox();
            this.errorString = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(137, 181);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(94, 28);
            this.registerBtn.TabIndex = 8;
            this.registerBtn.Text = "Регистрация";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordTB);
            this.groupBox2.Location = new System.Drawing.Point(11, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 46);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
            // 
            // passwordTB
            // 
            this.passwordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordTB.Location = new System.Drawing.Point(3, 16);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(214, 20);
            this.passwordTB.TabIndex = 1;
            this.passwordTB.TextChanged += new System.EventHandler(this.some_TextChanged);
            this.passwordTB.TextChanged += new System.EventHandler(this.repitPasswordTB_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loginTB);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 46);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // loginTB
            // 
            this.loginTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginTB.Location = new System.Drawing.Point(3, 16);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(214, 20);
            this.loginTB.TabIndex = 0;
            this.loginTB.TextChanged += new System.EventHandler(this.some_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.repitPasswordTB);
            this.groupBox3.Location = new System.Drawing.Point(11, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 46);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подтверждение пароля";
            // 
            // repitPasswordTB
            // 
            this.repitPasswordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repitPasswordTB.Location = new System.Drawing.Point(3, 16);
            this.repitPasswordTB.Name = "repitPasswordTB";
            this.repitPasswordTB.PasswordChar = '*';
            this.repitPasswordTB.Size = new System.Drawing.Size(214, 20);
            this.repitPasswordTB.TabIndex = 1;
            this.repitPasswordTB.TextChanged += new System.EventHandler(this.some_TextChanged);
            this.repitPasswordTB.TextChanged += new System.EventHandler(this.repitPasswordTB_TextChanged);
            // 
            // errorString
            // 
            this.errorString.AutoSize = true;
            this.errorString.ForeColor = System.Drawing.Color.Red;
            this.errorString.Location = new System.Drawing.Point(12, 165);
            this.errorString.Name = "errorString";
            this.errorString.Size = new System.Drawing.Size(0, 13);
            this.errorString.TabIndex = 9;
            // 
            // RegistrationFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 214);
            this.Controls.Add(this.errorString);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrationFrom";
            this.Text = "Регистрация";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox repitPasswordTB;
        private System.Windows.Forms.Label errorString;
    }
}