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
    public partial class AuthorizationForm : Form
    {
        DispatherConnection DispatherConnection;
        AuthorizationServerConection AuthorizationServerConection;
       
        public AuthorizationForm()
        {
            InitializeComponent();
            try
            {
                DispatherConnection = new DispatherConnection();
                AuthorizationServerConection = new AuthorizationServerConection(DispatherConnection.GetAuthorizationServerAddress());
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
            //Проверить соиденение с комутатором
            //Есть: получить адрес сервера авторизации, если еще не получен
            //Нет: сообщить о невозможности подключиться к серверу авторизации
            //Отправить через JRPC логин и пароль среверу авторизации (возможно в зашифрованном виде)
            //Получить ответ (пока ответ не будет получен, все действия заблокированны)
            //Ответ положительный: открыть основное окно приложения
            //Ответ отрицательный: сообщить о неправильном логине и пароле
            
            AuthorizationServerConection.Authenticate(loginTB.Text, passwordTB.Text);
            //Это должно возвращать 
            var address = "адрес чат-сервера";
            var token = "токен для подключения";
            var chatServerConection = new ChatServerConnection(address, token);
            var form = new MainForm(DispatherConnection, AuthorizationServerConection, chatServerConection);
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
