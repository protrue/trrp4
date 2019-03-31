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
        Member CurrentMember;

        public MainForm(DispatherConnection dispatherConnection, AuthorizationServerConection authorizationServerConection)
        {
            InitializeComponent();
            AuthorizationServerConection = authorizationServerConection;
            //запросить у сервера авторизации все мои чаты и список народу
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            //Здесь должне создаваться новый чат
            //Сначала серверу посылается запрос на создание с возвратом id
            //Если успешно, то создается и открывается чат
            //Если нет, то вылетает ошибка
            var id = 1;
            var item = new ListViewItem("");
            var chat = new Chat(id, CurrentMember, "");
            item.Tag = chat;
            chatsLV.Items.Add(item);
            var newChatForm = new ChatForm(chat);
        }

        private void nextMemberBtn_Click(object sender, EventArgs e)
        {

        }

        private void changePhotoBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "*.png, *.jpg";
            dialog.ShowDialog();
            MessageBox.Show(dialog.FileName);
        }
    }
}
