using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Client.Resources
{
    public class ChatMessage
    {
        public Member Reciver { get; }
        public string Text { get; }
        
        public ChatMessage(Member _reciver, string _text)
        {
            Reciver = _reciver;
            Text = _text;
        }
    }
}
