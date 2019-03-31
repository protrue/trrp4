using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Trrp4.Objects;
using Trrp4.Shared;
using Trrp4.Shared.ChatServiceReference;
using Trrp4.Shared.DispatcherServiceReference;
using AccessKey = Trrp4.Objects.AccessKey;
using Message = Trrp4.Objects.Message;
using Timer = System.Timers.Timer;

namespace Trrp4.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatServer : IChatService, IDisposable
    {
        public IPEndPoint NotifierEndPoint { get; set; }
        public IPEndPoint ListenerEndPoint { get; set; }
        public IPEndPoint DispatcherEndPoint { get; set; }
        public DispatcherServiceClient DispatcherServiceClient { get; set; }

        public Thread ListenerThread { get; set; }

        public BinaryFormatter BinaryFormatter { get; set; }
        public List<AccessKey> AccessKeys { get; set; }
        public Dictionary<int, TcpClient> ConnectedClients { get; set; }
        public Dictionary<int, IPEndPoint> AddresseeRoutes { get; set; }

        public int DispatcherNotifyPeriodMilliseconds { get; set; }
        public Timer DispatcherNotifierTimer { get; set; }
        public UdpClient DispatcherNotifierUdpClient { get; set; }

        public ChatServer()
        {
            ConnectedClients = new Dictionary<int, TcpClient>();
            AddresseeRoutes = new Dictionary<int, IPEndPoint>();
            BinaryFormatter = new BinaryFormatter();

            NotifierEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8085);
            ListenerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8085);
            DispatcherEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            ListenerThread = new Thread(Listen);

            DispatcherNotifierUdpClient = new UdpClient(NotifierEndPoint);

            DispatcherServiceClient = new DispatcherServiceClient(
                new BasicHttpBinding(BasicHttpSecurityMode.None),
                new EndpointAddress($"http://{DispatcherEndPoint.Address}:{DispatcherEndPoint.Port}/dispatcher"));
            DispatcherServiceClient.Open();

            DispatcherNotifyPeriodMilliseconds = 1000;
            DispatcherNotifierTimer = new Timer(1);
            DispatcherNotifierTimer.Elapsed += NotifyDispatcher;
        }

        private void NotifyDispatcher(object sender, ElapsedEventArgs e)
        {
            DispatcherNotifierUdpClient.Send(new byte[] { 0, (byte)ConnectedClients.Count }, 2, DispatcherEndPoint);
        }

        public void Listen()
        {
            var tcpListener = new TcpListener(ListenerEndPoint);
            tcpListener.Start();

            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();

                var thread = new Thread(() =>
                {
                    var networkStream = tcpClient.GetStream();

                    while (true)
                    {
                        var dataObject = BinaryFormatter.Deserialize(networkStream);

                        if (dataObject is AccessKey accessKey)
                        {
                            if (AccessKeys.Contains(accessKey))
                                ConnectedClients[accessKey.UserId] = tcpClient;
                            else
                                tcpClient.Close();

                            break;
                        }

                        if (dataObject is Message message)
                        {
                            if (!ConnectedClients.ContainsKey(message.Sender) &&
                                !ConnectedClients.ContainsKey(message.Addressee))
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
                                var targetServerEndPoint = DispatcherServiceClient.GetServerByClient(message.Addressee);
                                var chatServiceClient = new ChatServiceClient(
                                    new BasicHttpBinding(BasicHttpSecurityMode.None),
                                    new EndpointAddress(
                                        $"http://{targetServerEndPoint.Address}:{targetServerEndPoint.Port}/chatservice"));
                            }
                        }
                    }
                });
            }
        }

        public void Start()
        {
            DispatcherNotifierTimer.Start();

            ListenerThread.Start();
        }

        public void Stop()
        {

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

        public void Dispose()
        {
            ((IDisposable)DispatcherServiceClient)?.Dispose();
            DispatcherNotifierTimer?.Dispose();
        }
    }
}