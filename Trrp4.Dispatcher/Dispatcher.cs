using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Trrp4.Objects;
using Trrp4.Shared;

namespace Trrp4.Dispatcher
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Dispatcher : IDispatcherService
    {
        public const int BasePort = 7000;

        public IPEndPoint ObserverEndPoint { get; set; }
        public IPEndPoint ServiceEndPoint { get; set; }
        public Dictionary<int, IPEndPoint> ClientServerMap { get; set; }
        public Dictionary<IPEndPoint, int> AuthServersLoad { get; set; }
        public Dictionary<IPEndPoint, int> ChatServersLoad { get; set; }

        public Dictionary<IPEndPoint, DateTime> ServerResponses { get; set; }

        public Thread ObserverThread { get; set; }
        public System.Timers.Timer CleanUpTimer { get; }
        public int CleanUpPeriodMilliseconds { get; set; }
        public int ResponseTimeoutSeconds { get; set; }
        public bool IsObserverRunning { get; set; }

        public Dispatcher()
        {
            AuthServersLoad = new Dictionary<IPEndPoint, int>();
            ChatServersLoad = new Dictionary<IPEndPoint, int>();
            ClientServerMap = new Dictionary<int, IPEndPoint>();
            ServerResponses = new Dictionary<IPEndPoint, DateTime>();

            ResponseTimeoutSeconds = 10;
            CleanUpPeriodMilliseconds = 15000;
            IsObserverRunning = false;

            ObserverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort);
            ServiceEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort + 1);

            ObserverThread = new Thread(Observe);
            CleanUpTimer = new System.Timers.Timer();
            CleanUpTimer.Elapsed += RemoveNotRespondingServers;
            CleanUpTimer.Interval = CleanUpPeriodMilliseconds;
        }

        public void AutoSetupPorts()
        {
            bool isInUse;
            var currentPort = BasePort;
            do
            {
                isInUse = false;
                for (var i = 0; i < 2; i++)
                {
                    try
                    {
                        var udpClient = new UdpClient(new IPEndPoint(ObserverEndPoint.Address, currentPort));
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
                    currentPort += 2;
            } while (isInUse);

            ObserverEndPoint.Port = currentPort;
            ServiceEndPoint.Port = currentPort + 1;
        }

        public void StartObserving()
        {
            IsObserverRunning = true;
            ObserverThread.Start();
            CleanUpTimer.Start();
        }

        public void StopObserving()
        {
            IsObserverRunning = false;
            CleanUpTimer.Stop();
        }

        private void Observe()
        {
            var udpClient = new UdpClient(ObserverEndPoint);

            while (IsObserverRunning)
            {
                IPEndPoint remoteEndPoint = null;
                var serverResponse = udpClient.Receive(ref remoteEndPoint);
                if (serverResponse[0] == 0)
                    ChatServersLoad[remoteEndPoint] = serverResponse[1];
                else
                    AuthServersLoad[remoteEndPoint] = serverResponse[1];

                ServerResponses[remoteEndPoint] = DateTime.Now;

                Console.WriteLine($"Dispatcher: response from: {remoteEndPoint}, type: {serverResponse[0]}, load: {serverResponse[1]}");
            }
        }

        private void RemoveNotRespondingServers(object sender, ElapsedEventArgs e)
        {
            var serversToRemove = new List<IPEndPoint>();

            foreach (var serverResponse in ServerResponses)
            {
                if ((DateTime.Now - serverResponse.Value).Seconds > ResponseTimeoutSeconds)
                {
                    serversToRemove.Add(serverResponse.Key);
                    Console.WriteLine($"Dispatcher: {serverResponse.Key} timed out, marked as down");
                }
            }

            foreach (var server in serversToRemove)
            {
                ServerResponses.Remove(server);
                AuthServersLoad.Remove(server);
                ChatServersLoad.Remove(server);
            }
        }

        public IPEndPoint[] GetBestChatServers(int count)
        {
            return
                ChatServersLoad
                    .OrderBy(pair => pair.Value)
                    .Take(count)
                    .Select(pair => new IPEndPoint(pair.Key.Address, pair.Key.Port + 1))
                    .ToArray();
        }

        public IPEndPoint[] GetBestAuthServers(int count)
        {
            return
                AuthServersLoad
                    .OrderBy((pair => pair.Value))
                    .Take(count)
                    .Select(pair => new IPEndPoint(pair.Key.Address, pair.Key.Port + 1))
                    .ToArray();

        }

        public IPEndPoint GetServerByClient(int clientId)
        {
            var notifierEndPoint = ClientServerMap[clientId];
            var serviceEndpoint = new IPEndPoint(notifierEndPoint.Address, notifierEndPoint.Port + 2);
            return serviceEndpoint;
        }
    }
}
