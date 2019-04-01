namespace Trrp4.Client
{
    partial class MainForm
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
            this.chatPage = new System.Windows.Forms.TabPage();
            this.chatsLV = new System.Windows.Forms.ListView();
            this.viewPage = new System.Windows.Forms.TabPage();
            this.chatBtn = new System.Windows.Forms.Button();
            this.memberInfoLbl = new System.Windows.Forms.Label();
            this.nextMemberBtn = new System.Windows.Forms.Button();
            this.profilePage = new System.Windows.Forms.TabControl();
            this.chatPage.SuspendLayout();
            this.viewPage.SuspendLayout();
            this.profilePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatPage
            // 
            this.chatPage.Controls.Add(this.chatsLV);
            this.chatPage.Location = new System.Drawing.Point(4, 22);
            this.chatPage.Name = "chatPage";
            this.chatPage.Padding = new System.Windows.Forms.Padding(3);
            this.chatPage.Size = new System.Drawing.Size(308, 340);
            this.chatPage.TabIndex = 1;
            this.chatPage.Text = "Мои чаты";
            this.chatPage.UseVisualStyleBackColor = true;
            // 
            // chatsLV
            // 
            this.chatsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatsLV.Location = new System.Drawing.Point(3, 3);
            this.chatsLV.MultiSelect = false;
            this.chatsLV.Name = "chatsLV";
            this.chatsLV.Size = new System.Drawing.Size(302, 334);
            this.chatsLV.TabIndex = 0;
            this.chatsLV.UseCompatibleStateImageBehavior = false;
            this.chatsLV.DoubleClick += new System.EventHandler(this.chatsLV_DoubleClick);
            // 
            // viewPage
            // 
            this.viewPage.Controls.Add(this.nextMemberBtn);
            this.viewPage.Controls.Add(this.memberInfoLbl);
            this.viewPage.Controls.Add(this.chatBtn);
            this.viewPage.Location = new System.Drawing.Point(4, 22);
            this.viewPage.Name = "viewPage";
            this.viewPage.Padding = new System.Windows.Forms.Padding(3);
            this.viewPage.Size = new System.Drawing.Size(308, 340);
            this.viewPage.TabIndex = 0;
            this.viewPage.Text = "Просмотр анкет";
            this.viewPage.UseVisualStyleBackColor = true;
            // 
            // chatBtn
            // 
            this.chatBtn.Location = new System.Drawing.Point(91, 288);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(130, 46);
            this.chatBtn.TabIndex = 3;
            this.chatBtn.Text = "Открыть чат";
            this.chatBtn.UseVisualStyleBackColor = true;
            this.chatBtn.Click += new System.EventHandler(this.chatBtn_Click);
            // 
            // memberInfoLbl
            // 
            this.memberInfoLbl.AutoSize = true;
            this.memberInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memberInfoLbl.Location = new System.Drawing.Point(85, 153);
            this.memberInfoLbl.Name = "memberInfoLbl";
            this.memberInfoLbl.Size = new System.Drawing.Size(135, 31);
            this.memberInfoLbl.TabIndex = 4;
            this.memberInfoLbl.Text = "Nickname";
            // 
            // nextMemberBtn
            // 
            this.nextMemberBtn.Location = new System.Drawing.Point(255, 288);
            this.nextMemberBtn.Name = "nextMemberBtn";
            this.nextMemberBtn.Size = new System.Drawing.Size(45, 46);
            this.nextMemberBtn.TabIndex = 5;
            this.nextMemberBtn.Text = ">";
            this.nextMemberBtn.UseVisualStyleBackColor = true;
            this.nextMemberBtn.Click += new System.EventHandler(this.nextMemberBtn_Click);
            // 
            // profilePage
            // 
            this.profilePage.Controls.Add(this.viewPage);
            this.profilePage.Controls.Add(this.chatPage);
            this.profilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePage.Location = new System.Drawing.Point(0, 0);
            this.profilePage.Name = "profilePage";
            this.profilePage.SelectedIndex = 0;
            this.profilePage.Size = new System.Drawing.Size(316, 366);
            this.profilePage.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 366);
            this.Controls.Add(this.profilePage);
            this.Name = "MainForm";
            this.Text = "Окно знакомств";
            this.chatPage.ResumeLayout(false);
            this.viewPage.ResumeLayout(false);
            this.viewPage.PerformLayout();
            this.profilePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage chatPage;
        private System.Windows.Forms.ListView chatsLV;
        private System.Windows.Forms.TabPage viewPage;
        private System.Windows.Forms.Button nextMemberBtn;
        private System.Windows.Forms.Label memberInfoLbl;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.TabControl profilePage;
    }
}