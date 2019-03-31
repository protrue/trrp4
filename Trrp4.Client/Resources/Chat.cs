using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources
{
    public class Chat
    {
        ChatConnection ChatConnection { get; }
        
        public Member Member { get; }
        public string LastMessage { get; }
        
        public Chat(int _id, Member _member, string _lastMessage)
        {
            ChatConnection = new ChatConnection(_id);
            Member = _member;
            LastMessage = _lastMessage;
        }
    }
}
