using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Client.Resources
{
    public class ChatServerConnection
    {
        //public int ChatId { get; }
        public string ServerAddress { get; }
        private string Token { get; }

        public ChatServerConnection(/*int _id*/string _address, string _token)
        {
            //ChatId = _id;
            ServerAddress = _address;
            Token = _token;
        }

        public void SendMessage(ChatMessage message)
        {

        }

        public List<Chat> GetChats()
        {
            var chats = new List<Chat>();
            return chats;
        }
    }
}
