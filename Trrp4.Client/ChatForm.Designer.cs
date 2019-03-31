namespace Trrp4.Client
{
    partial class ChatForm
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
            this.messagesLV = new System.Windows.Forms.ListView();
            this.messageTB = new System.Windows.Forms.TextBox();
            this.messageSendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messagesLV
            // 
            this.messagesLV.Dock = System.Windows.Forms.DockStyle.Top;
            this.messagesLV.Location = new System.Drawing.Point(0, 0);
            this.messagesLV.Name = "messagesLV";
            this.messagesLV.Size = new System.Drawing.Size(345, 376);
            this.messagesLV.TabIndex = 0;
            this.messagesLV.UseCompatibleStateImageBehavior = false;
            // 
            // messageTB
            // 
            this.messageTB.Dock = System.Windows.Forms.DockStyle.Left;
            this.messageTB.Location = new System.Drawing.Point(0, 376);
            this.messageTB.Multiline = true;
            this.messageTB.Name = "messageTB";
            this.messageTB.Size = new System.Drawing.Size(271, 74);
            this.messageTB.TabIndex = 1;
            // 
            // messageSendBtn
            // 
            this.messageSendBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageSendBtn.Location = new System.Drawing.Point(271, 376);
            this.messageSendBtn.Name = "messageSendBtn";
            this.messageSendBtn.Size = new System.Drawing.Size(74, 74);
            this.messageSendBtn.TabIndex = 2;
            this.messageSendBtn.Text = "Отправить";
            this.messageSendBtn.UseVisualStyleBackColor = true;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 450);
            this.Controls.Add(this.messageSendBtn);
            this.Controls.Add(this.messageTB);
            this.Controls.Add(this.messagesLV);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView messagesLV;
        private System.Windows.Forms.TextBox messageTB;
        private System.Windows.Forms.Button messageSendBtn;
    }
}