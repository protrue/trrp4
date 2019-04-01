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
        Member resiver;
        ChatServerConnection chatServerConnection;

        public ChatForm(Chat chat)
        {
            Chat = chat;
        }

        public ChatForm(Chat _chat, Member _user, Member _reciver, ChatServerConnection chatServerConnection)
        {
            InitializeComponent();
            Chat = _chat;
            user = _user;
            resiver = _reciver;
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
            var message = new ChatMessage(user, resiver, messageTB.Text);
            Chat.AddMessage(message);
            var item = new ListViewItem(messageTB.Text);
            item.Tag = message;
            messagesLV.Items.Add(item);
            chatServerConnection.SendMessage(message);
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
