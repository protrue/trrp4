using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Trrp4.Objects;

namespace Trrp4.Client.Resources
{
    public class ChatServerConnection
    {
        //public int ChatId { get; }
        public IPEndPoint[] ServerAddresses { get; }
        public IPEndPoint ConectedAddress { get; }
        private AccessKey Token { get; set; }
        private BinaryFormatter BinaryFormatter;
        private TcpClient TcpClient;

        public ChatServerConnection(IPEndPoint[] _addresses)
        {
            ServerAddresses = _addresses;
            ConectedAddress = ServerAddresses[0];
            TcpClient = new TcpClient(ConectedAddress);
            BinaryFormatter = new BinaryFormatter();
        }

        public Message[] InsertKey(AccessKey token)
        {
            Token = token;
            BinaryFormatter.Serialize(TcpClient.GetStream(), Token);
            var data = BinaryFormatter.Deserialize(TcpClient.GetStream());
            return data as Message[];
        }

        public void SendMessage(ChatMessage chatMessage)
        {
            Message message = new Message() { Text = chatMessage.Text, Sender = chatMessage.Sender.Id, Addressee = chatMessage.Reciver.Id, IsDelivered = false };
            BinaryFormatter.Serialize(TcpClient.GetStream(), message);
        }

        public List<Chat> GetChats()
        {
            var chats = new List<Chat>();
            return chats;
        }
    }
}
