using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trrp4.Client.Resources;

namespace Trrp4.Client
{
    public partial class AuthorizationForm : Form
    {
        DispatherConnection DispatherConnection;
        AuthorizationServerConection AuthorizationServerConection;
        ChatServerConnection ChatServerConnection;

        public AuthorizationForm()
        {
            InitializeComponent();
            try
            {
                DispatherConnection = new DispatherConnection();
                AuthorizationServerConection = new AuthorizationServerConection(DispatherConnection.GetAuthorizationServerAddress(1));
                ChatServerConnection = new ChatServerConnection(DispatherConnection.GetChatServerAddress(2));
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно подключиться к северу\n\n Текст ошибки: " + e.ToString());
                Close();
            }
        }

        private void registrationLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var regForm = new RegistrationFrom(DispatherConnection, AuthorizationServerConection);
            if(regForm.ShowDialog() == DialogResult.OK)
            {
                loginTB.Text = regForm.Login;
                regForm.Dispose();
            }
        }

        private void authBtn_Click(object sender, EventArgs e)
        {
            var token = AuthorizationServerConection.Authenticate(loginTB.Text, passwordTB.Text, ChatServerConnection.ServerAddresses[0]);
            var form = new MainForm(DispatherConnection, AuthorizationServerConection, ChatServerConnection, token, loginTB.Text);
            Hide();    
            form.ShowDialog();
            Close();
        }

        private void some_TextChanged(object sender, EventArgs e)
        {
            if (loginTB.Text != string.Empty && passwordTB.Text != string.Empty)
            {
                authBtn.Enabled = true;
            }
            else
            {
                authBtn.Enabled = false;
            }
        }
    }
}
