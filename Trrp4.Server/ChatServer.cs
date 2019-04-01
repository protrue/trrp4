﻿using System;
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
        public const int BasePort = 8000;

        public IPEndPoint NotifierEndPoint { get; set; }
        public IPEndPoint ListenerEndPoint { get; set; }
        public IPEndPoint DispatcherEndPoint { get; set; }
        public IPEndPoint ServiceEndPoint { get; set; }
        public DispatcherServiceClient DispatcherServiceClient { get; set; }

        public Thread ListenerThread { get; set; }
        public int ListenerBacklog { get; set; }

        public BinaryFormatter BinaryFormatter { get; set; }
        public List<AccessKey> AccessKeys { get; set; }
        public Dictionary<int, TcpClient> ConnectedClients { get; set; }
        public Dictionary<int, IPEndPoint> AddresseeRoutes { get; set; }

        public double DispatcherNotifyPeriodMilliseconds { get; set; }
        public Timer DispatcherNotifierTimer { get; set; }
        public UdpClient DispatcherNotifierUdpClient { get; set; }

        public ChatServer()
        {
            ConnectedClients = new Dictionary<int, TcpClient>();
            AddresseeRoutes = new Dictionary<int, IPEndPoint>();
            BinaryFormatter = new BinaryFormatter();

            NotifierEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort);
            ListenerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort + 1);
            ServiceEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort + 2);
            DispatcherEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);

            ListenerThread = new Thread(Listen);
            ListenerBacklog = 4;
            
            DispatcherServiceClient = new DispatcherServiceClient(
                new BasicHttpBinding(BasicHttpSecurityMode.None),
                new EndpointAddress($"http://{DispatcherEndPoint.Address}:{DispatcherEndPoint.Port}/dispatcher"));
            DispatcherServiceClient.Open();

            DispatcherNotifyPeriodMilliseconds = 3000;
            DispatcherNotifierTimer = new Timer(DispatcherNotifyPeriodMilliseconds);
            DispatcherNotifierTimer.Elapsed += NotifyDispatcher;
        }

        public void AutoSetupPorts()
        {
            bool isInUse;
            var currentPort = BasePort;
            do
            {
                isInUse = false;
                for (var i = 0; i < 3; i++)
                {
                    try
                    {
                        var udpClient = new UdpClient(new IPEndPoint(NotifierEndPoint.Address, currentPort));
                        udpClient.Close();
                    }
                    catch (SocketException socketException)
                    {
                        isInUse = true;
                    }

                    if (NetworkTools.IsPortInUse(currentPort + i))
                        isInUse = true;
                }
                if (isInUse)
                    currentPort += 3;
            } while (isInUse);

            NotifierEndPoint.Port = currentPort;
            ListenerEndPoint.Port = currentPort + 1;
            ServiceEndPoint.Port = currentPort + 2;
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
                    var chatContext = new ChatContext();

                    while (true)
                    {
                        var dataObject = BinaryFormatter.Deserialize(networkStream);

                        if (dataObject is AccessKey accessKey && !ConnectedClients.ContainsKey(accessKey.UserId))
                        {
                            if (AccessKeys.Contains(accessKey))
                            {
                                ConnectedClients[accessKey.UserId] = tcpClient;
                                var undeliveredMessages = chatContext.Messages.Where(m => m.Addressee == accessKey.UserId && !m.IsDelivered).ToArray();
                                BinaryFormatter.Serialize(networkStream, undeliveredMessages);
                            }
                            else
                                tcpClient.Close();

                            break;
                        }

                        if (dataObject is Message message)
                        {
                            if (!ConnectedClients.ContainsKey(message.Sender) &&
                                !ConnectedClients.ContainsKey(message.Addressee))
                            {
                                tcpClient.Close();
                                break;
                            }

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
                                chatServiceClient.RedirectMessage(new Shared.ChatServiceReference.Message()
                                {
                                    Addressee = message.Addressee,
                                    Sender = message.Sender,
                                    Id = message.Id,
                                    Text = message.Text,
                                    IsDelivered = message.IsDelivered
                                });
                            }

                            chatContext.SaveChanges();
                        }
                    }

                    chatContext.Dispose();
                });

                thread.Start();
            }
        }

        public void Start()
        {
            DispatcherNotifierUdpClient = new UdpClient(NotifierEndPoint);
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
            chatContext.Messages.Attach(message);
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