using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Trrp4.Objects;
using Trrp4.Shared;

namespace Trrp4.Server
{
    public class ChatServer : IChatService
    {
        public IPEndPoint LocalEndPoint { get; set; }
        public IPEndPoint DispatcherEndPoint { get; set; }

        public BinaryFormatter BinaryFormatter { get; set; }
        public List<AccessKey> AccessKeys { get; set; }
        public Dictionary<int, TcpClient> ConnectedClients { get; set; }
        public Dictionary<int, IPEndPoint> AddresseeRoutes { get; set; }

        public int DispatcherNotifyPeriodMilliseconds { get; set; }
        public Timer DispatcherNotifierTimer { get; set; }

        public ChatServer()
        {
            ConnectedClients = new Dictionary<int, TcpClient>();
            AddresseeRoutes = new Dictionary<int, IPEndPoint>();
            BinaryFormatter = new BinaryFormatter();

            DispatcherNotifyPeriodMilliseconds = 1000;
            DispatcherNotifierTimer = new Timer(1);
            DispatcherNotifierTimer.Elapsed += NotifyDispatcher;
        }

        private void NotifyDispatcher(object sender, ElapsedEventArgs e)
        {
            var udp = new UdpClient(LocalEndPoint);
            udp.Send(new byte[] { 0, (byte)ConnectedClients.Count }, 2, DispatcherEndPoint);
        }

        public void Start(string ip, int port)
        {
            var tcp = new TcpListener(IPAddress.Parse(ip), port);

            var tcpClient = tcp.AcceptTcpClient();
            var networkStream = tcpClient.GetStream();

            var dataObject = BinaryFormatter.Deserialize(networkStream);

            if (dataObject is AccessKey accessKey)
            {
                if (AccessKeys.Contains(accessKey))
                    ConnectedClients[accessKey.UserId] = tcpClient;
                else
                    tcpClient.Close();
            }

            if (dataObject is Message message)
            {
                if (!ConnectedClients.ContainsKey(message.Sender) && !ConnectedClients.ContainsKey(message.Addressee))
                    tcpClient.Close();

                var chatContext = new ChatContext();
                chatContext.Messages.Add(message);

                if (ConnectedClients.ContainsKey(message.Addressee))
                {
                    var addresseeStream = ConnectedClients[message.Addressee].GetStream();
                    BinaryFormatter.Serialize(addresseeStream, message);
                    message.IsDelivered = true;
                }
                else
                {
                    var dispatcherServiceClient = new Shared.DispatcherServiceReference.DispatcherServiceClient(
                        new BasicHttpBinding(BasicHttpSecurityMode.None),
                        new EndpointAddress("http://localhost:8080/dispatcher"));
                    var targetServerEndPoint = dispatcherServiceClient.GetServerByClient(message.Addressee);
                    
                }

            }

        }

        public void RedirectMessage(Message message)
        {
            var addresseeStream = ConnectedClients[message.Addressee].GetStream();
            BinaryFormatter.Serialize(addresseeStream, message);

            message.IsDelivered = true;

            var chatContext = new ChatContext();
            chatContext.Messages.Add(message);
            chatContext.SaveChanges();
            chatContext.Dispose();
        }

        public void AddAccessKey(AccessKey accessKey)
        {
            AccessKeys.Add(accessKey);
        }

        public void RevokeAccessKey(AccessKey accessKey)
        {
            AccessKeys.Remove(accessKey);
        }
    }
}
