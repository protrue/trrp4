using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trrp4.Client.Resources;

namespace Trrp4.Client
{
    public partial class ChatForm : Form
    {
        Chat Chat;
        Member user;
        ChatServerConnection chatServerConnection;

        public ChatForm(Chat _chat, Member user, ChatServerConnection chatServerConnection)
        {
            InitializeComponent();
            Chat = _chat;
        }

        public void fillMessageList()
        {
            var messages = Chat.Messages;
            messages.Reverse();
            foreach(var message in messages)
            {
                var item = new ListViewItem("");
                item.Tag = message;
                messagesLV.Items.Add(item);
            }
        }

        private void messageSendBtn_Click(object sender, EventArgs e)
        {
            var message = new ChatMessage(user, messageTB.Text);
            Chat.AddMessage(message);
            var item = new ListViewItem(messageTB.Text);
            item.Tag = message;
            messagesLV.Items.Add(item);
        }

        private void messageTB_TextChanged(object sender, EventArgs e)
        {
            if(messageTB.Text == string.Empty)
            {
                messageSendBtn.Enabled = false;
            }
            else
            {
                messageSendBtn.Enabled = true;
            }
        }
    }
}
