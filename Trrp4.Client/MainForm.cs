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
            ChatServerConnection chatServerConnection)
        {
            InitializeComponent();
            AuthorizationServerConection = authorizationServerConection;
            DispatherConnection = dispatherConnection;
            ChatServerConnection = chatServerConnection;
            Members = authorizationServerConection.GetMemberList();
            GetChats();
            //запросить у сервера авторизации все мои чаты и список народу
        }

        private void GetChats()
        {
            Chats = ChatServerConnection.GetChats();
            foreach(var chat in Chats)
            {
                var item = new ListViewItem("1");
                item.Tag = chat;
                chatsLV.Items.Add(item);
            }
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            //Здесь должне создаваться новый чат
            //Сначала серверу посылается запрос на создание с возвратом id
            //Если успешно, то создается и открывается чат
            //Если нет, то вылетает ошибка
            var item = new ListViewItem("");
            var member = new Member(new Bitmap("dsf"), "name", "address", 10);
            var chat = new Chat(member, "last");
            item.Tag = chat;
            chatsLV.Items.Add(item);
            var newChatForm = new ChatForm(chat);
        }

        private void nextMemberBtn_Click(object sender, EventArgs e)
        {
            Members.RemoveAt(0);
            if(Members.Count < 1)
            {
                //как-то сказать что список закончился
            }
            else
            {
                CurrentMember = Members[0];
                if (Members.Count == 1)
                    nextMemberBtn.Enabled = false;
            }
        }

        private void changePhotoBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "*.png, *.jpg";
            dialog.ShowDialog();
            MessageBox.Show(dialog.FileName);
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
