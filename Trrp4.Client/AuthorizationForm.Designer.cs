namespace Trrp4.Client
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.registrationLL = new System.Windows.Forms.LinkLabel();
            this.authBtn = new System.Windows.Forms.Button();
            this.errorString = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTB
            // 
            this.loginTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginTB.Location = new System.Drawing.Point(3, 16);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(214, 20);
            this.loginTB.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loginTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordTB);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 46);
            this.groupBox2.TabIndex = 2;
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
            // 
            // registrationLL
            // 
            this.registrationLL.AutoSize = true;
            this.registrationLL.Location = new System.Drawing.Point(12, 148);
            this.registrationLL.Name = "registrationLL";
            this.registrationLL.Size = new System.Drawing.Size(72, 13);
            this.registrationLL.TabIndex = 3;
            this.registrationLL.TabStop = true;
            this.registrationLL.Text = "Регистрация";
            this.registrationLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registrationLL_LinkClicked);
            // 
            // authBtn
            // 
            this.authBtn.Location = new System.Drawing.Point(138, 133);
            this.authBtn.Name = "authBtn";
            this.authBtn.Size = new System.Drawing.Size(94, 28);
            this.authBtn.TabIndex = 4;
            this.authBtn.Text = "Авторизция";
            this.authBtn.UseVisualStyleBackColor = true;
            this.authBtn.Click += new System.EventHandler(this.authBtn_Click);
            // 
            // errorString
            // 
            this.errorString.AutoSize = true;
            this.errorString.ForeColor = System.Drawing.Color.Red;
            this.errorString.Location = new System.Drawing.Point(12, 113);
            this.errorString.Name = "errorString";
            this.errorString.Size = new System.Drawing.Size(0, 13);
            this.errorString.TabIndex = 5;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 167);
            this.Controls.Add(this.errorString);
            this.Controls.Add(this.authBtn);
            this.Controls.Add(this.registrationLL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AuthorizationForm";
            this.Text = "Авторизация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.LinkLabel registrationLL;
        private System.Windows.Forms.Button authBtn;
        private System.Windows.Forms.Label errorString;
    }
}

