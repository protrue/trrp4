﻿using System;
using System.Windows.Forms;

namespace Trrp4.Client
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void registrationLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var regForm = new RegistrationFrom();
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
            var form = new WorkingForm();
            this.Hide();    
            form.ShowDialog();
            this.Close();
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
