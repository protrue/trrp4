using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Resources;

namespace Client
{
    public partial class RegistrationFrom : Form
    {
        DispatherConnection DispatherConnection;
        AuthorizationServerConection AuthorizationServerConection;

        public string Login { get { return loginTB.Text; } }

        public RegistrationFrom(DispatherConnection _dispatherConnection, AuthorizationServerConection _authorizationServerConection)
        {
            InitializeComponent();
            registerBtn.Enabled = false;
            DispatherConnection = _dispatherConnection;
            AuthorizationServerConection = _authorizationServerConection;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            //Проверить соиденение с комутатором
                //Есть: получить адрес сервера авторизации, если еще не получен
                //Нет: сообщить о невозможности подключиться к серверу авторизации
            //Отправить через JRPC логин и пароль среверу авторизации (возможно в зашифрованном виде) для регистрации
            //Получить ответ (пока ответ не будет получен, все действия заблокированны)
                //Ответ положительный: открыть основное окно приложения
                //Ответ отрицательный: сообщить о неправильном логине и пароле
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void repitPasswordTB_TextChanged(object sender, EventArgs e)
        {
            if(repitPasswordTB.Text != passwordTB.Text)
            {
                errorString.Text = "Введенные пароли не совпадают";
                registerBtn.Enabled = false;
            }
            else
            {
                errorString.Text = "";
                registerBtn.Enabled = true;
            }
        }

        private void some_TextChanged(object sender, EventArgs e)
        {
            if(loginTB.Text != string.Empty && passwordTB.Text != string.Empty && repitPasswordTB.Text != string.Empty)
            {
                registerBtn.Enabled = true;
            }
            else
            {
                registerBtn.Enabled = false;
            }
        }
    }
}
