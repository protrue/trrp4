using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources
{
    class ChatConnection
    {
        public int ChatId { get; }
        public string ServerAddress { get; }

        public ChatConnection(int _id)
        {
            ChatId = _id;
        }
    }
}
