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
using Trrp4.Objects;

namespace Trrp4.Client
{
    public partial class MainForm : Form
    {
        DispatherConnection DispatherConnection;
        AuthorizationServerConection AuthorizationServerConection;
        ChatServerConnection ChatServerConnection;
        Member UserInfo;
        Member CurrentMember;
        List<Chat> Chats;
        List<Member> Members;

        public MainForm(DispatherConnection dispatherConnection, AuthorizationServerConection authorizationServerConection,
            ChatServerConnection chatServerConnection, AccessKey token, string login)
        {
            InitializeComponent();
            AuthorizationServerConection = authorizationServerConection;
            DispatherConnection = dispatherConnection;
            ChatServerConnection = chatServerConnection;
            Members = authorizationServerConection.GetMemberList();
            UserInfo = new Member(Members.Find(x => x.Name == login).Id, login);
            var messages = ChatServerConnection.InsertKey(token);
            GetChats(messages);
        }

        private void GetChats(Objects.Message[] messages)
        { 
            foreach(var message in messages)
            {
                var index = Chats.FindIndex(x => x.Member.Id == message.Addressee || x.Member.Id == message.Sender);
                if(index < 0)
                {
                    var chat = new Chat(UserInfo, Members.Find(x => (x.Id == message.Sender && x.Id != UserInfo.Id) ||
                     (x.Id == message.Addressee && x.Id != UserInfo.Id)), "last");
                    Chats.Add(chat);
                    index = Chats.Count - 1;
                    var item = new ListViewItem("1");
                    item.Tag = chat;
                    chatsLV.Items.Add(item);
                }
                Chats[index].Messages.Add(new ChatMessage(Members.Find(x => x.Id == message.Sender),
                        Members.Find(x => x.Id == message.Addressee), message.Text));
            }
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            var item = new ListViewItem(CurrentMember.Name + "\t" + "");
            var chat = new Chat(UserInfo, CurrentMember, "");
            item.Tag = chat;
            chatsLV.Items.Add(item);
            var newChatForm = new ChatForm(chat);
        }

        private void nextMemberBtn_Click(object sender, EventArgs e)
        {
            Members.RemoveAt(0);
            if(Members.Count < 1)
            {
                MessageBox.Show("Пользователей больше нет");
            }
            else
            {
                CurrentMember = Members[0];
                if (Members.Count == 1)
                    nextMemberBtn.Enabled = false;
            }
        }

        private void chatsLV_DoubleClick(object sender, EventArgs e)
        {
            if(chatsLV.SelectedItems.Count > 0)
            {
                var newChatForm = new ChatForm(chatsLV.SelectedItems[0].Tag as Chat);
            }
        }
    }
}
