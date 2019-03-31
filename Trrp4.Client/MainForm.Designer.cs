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
            this.memberPhotoPB = new System.Windows.Forms.PictureBox();
            this.chatBtn = new System.Windows.Forms.Button();
            this.profilePage = new System.Windows.Forms.TabControl();
            this.viewPage = new System.Windows.Forms.TabPage();
            this.nextMemberBtn = new System.Windows.Forms.Button();
            this.memberInfoLbl = new System.Windows.Forms.Label();
            this.chatPage = new System.Windows.Forms.TabPage();
            this.chatsLV = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.changePhotoBtn = new System.Windows.Forms.Button();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userPhotoPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.memberPhotoPB)).BeginInit();
            this.profilePage.SuspendLayout();
            this.viewPage.SuspendLayout();
            this.chatPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPB)).BeginInit();
            this.SuspendLayout();
            // 
            // memberPhotoPB
            // 
            this.memberPhotoPB.Location = new System.Drawing.Point(8, 6);
            this.memberPhotoPB.Name = "memberPhotoPB";
            this.memberPhotoPB.Size = new System.Drawing.Size(292, 219);
            this.memberPhotoPB.TabIndex = 0;
            this.memberPhotoPB.TabStop = false;
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
            // profilePage
            // 
            this.profilePage.Controls.Add(this.viewPage);
            this.profilePage.Controls.Add(this.chatPage);
            this.profilePage.Controls.Add(this.tabPage3);
            this.profilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePage.Location = new System.Drawing.Point(0, 0);
            this.profilePage.Name = "profilePage";
            this.profilePage.SelectedIndex = 0;
            this.profilePage.Size = new System.Drawing.Size(316, 366);
            this.profilePage.TabIndex = 4;
            // 
            // viewPage
            // 
            this.viewPage.Controls.Add(this.nextMemberBtn);
            this.viewPage.Controls.Add(this.memberInfoLbl);
            this.viewPage.Controls.Add(this.memberPhotoPB);
            this.viewPage.Controls.Add(this.chatBtn);
            this.viewPage.Location = new System.Drawing.Point(4, 22);
            this.viewPage.Name = "viewPage";
            this.viewPage.Padding = new System.Windows.Forms.Padding(3);
            this.viewPage.Size = new System.Drawing.Size(308, 340);
            this.viewPage.TabIndex = 0;
            this.viewPage.Text = "Просмотр анкет";
            this.viewPage.UseVisualStyleBackColor = true;
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
            // memberInfoLbl
            // 
            this.memberInfoLbl.AutoSize = true;
            this.memberInfoLbl.Location = new System.Drawing.Point(8, 238);
            this.memberInfoLbl.Name = "memberInfoLbl";
            this.memberInfoLbl.Size = new System.Drawing.Size(64, 39);
            this.memberInfoLbl.TabIndex = 4;
            this.memberInfoLbl.Text = "Имя\r\nВозраст\r\nЧто-то еще";
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.changePhotoBtn);
            this.tabPage3.Controls.Add(this.saveChangesBtn);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.userPhotoPB);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(308, 340);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Мой профиль";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // changePhotoBtn
            // 
            this.changePhotoBtn.Location = new System.Drawing.Point(225, 231);
            this.changePhotoBtn.Name = "changePhotoBtn";
            this.changePhotoBtn.Size = new System.Drawing.Size(75, 23);
            this.changePhotoBtn.TabIndex = 4;
            this.changePhotoBtn.Text = "Изменить";
            this.changePhotoBtn.UseVisualStyleBackColor = true;
            this.changePhotoBtn.Click += new System.EventHandler(this.changePhotoBtn_Click);
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Location = new System.Drawing.Point(225, 309);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(75, 23);
            this.saveChangesBtn.TabIndex = 3;
            this.saveChangesBtn.Text = "Сохранить";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тут должны быть текстбоксы \r\nпо колличеству полей пользователя";
            // 
            // userPhotoPB
            // 
            this.userPhotoPB.Location = new System.Drawing.Point(8, 6);
            this.userPhotoPB.Name = "userPhotoPB";
            this.userPhotoPB.Size = new System.Drawing.Size(292, 219);
            this.userPhotoPB.TabIndex = 1;
            this.userPhotoPB.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 366);
            this.Controls.Add(this.profilePage);
            this.Name = "MainForm";
            this.Text = "Окно знакомств";
            ((System.ComponentModel.ISupportInitialize)(this.memberPhotoPB)).EndInit();
            this.profilePage.ResumeLayout(false);
            this.viewPage.ResumeLayout(false);
            this.viewPage.PerformLayout();
            this.chatPage.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox memberPhotoPB;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.TabControl profilePage;
        private System.Windows.Forms.TabPage viewPage;
        private System.Windows.Forms.TabPage chatPage;
        private System.Windows.Forms.ListView chatsLV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label memberInfoLbl;
        private System.Windows.Forms.PictureBox userPhotoPB;
        private System.Windows.Forms.Button changePhotoBtn;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextMemberBtn;
    }
}