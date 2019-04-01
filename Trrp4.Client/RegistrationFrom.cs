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
            AuthorizationServerConection.Registrate(loginTB.Text, passwordTB.Text);
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
