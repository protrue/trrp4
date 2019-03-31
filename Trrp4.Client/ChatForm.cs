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
    public partial class ChatForm : Form
    {
        public Chat Chat;

        public ChatForm(Chat _chat)
        {
            InitializeComponent();
            Chat = _chat;
        }
    }
}
