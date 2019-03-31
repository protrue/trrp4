﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Client.Resources
{
    public class Chat
    {
        public Member Member { get; }
        public string LastMessage { get; }
        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();
        
        public Chat(Member _member, string _lastMessage)
        {
            //ChatConnection = new ChatConnection();
            Member = _member;
            LastMessage = _lastMessage;
        }

        public void AddMessage(ChatMessage message)
        {
            Messages.Add(message);
        }
    }
}
