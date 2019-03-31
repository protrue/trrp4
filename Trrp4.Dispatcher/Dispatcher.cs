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

namespace Trrp4.Dispatcher
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Dispatcher : IDispatcherService
    {
        public IPEndPoint LocalEndPoint { get; set; }
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

            ResponseTimeoutSeconds = 3;
            CleanUpPeriodMilliseconds = 5000;
            IsObserverRunning = false;

            LocalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            ObserverThread = new Thread(Observe);
            CleanUpTimer = new System.Timers.Timer();
            CleanUpTimer.Elapsed += RemoveNotRespondingServers;
            CleanUpTimer.Interval = CleanUpPeriodMilliseconds;
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
            var udpClient = new UdpClient(LocalEndPoint);
            
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

        private void RemoveNotRespondingServers(object state)
        {
            Console.WriteLine("Cleanup started");

            var serverResponses = (Dictionary<IPEndPoint, DateTime>)state;

            foreach (var serverResponse in serverResponses)
            {
                if ((DateTime.Now - serverResponse.Value).Seconds > ResponseTimeoutSeconds)
                {
                    ChatServersLoad.Remove(serverResponse.Key);
                    Console.WriteLine($"{serverResponse.Key} removed");
                }
            }

            serverResponses.Clear();
        }

        public IPEndPoint[] GetBestChatServers(int count)
        {
            return
                ChatServersLoad
                    .OrderBy((pair => pair.Value))
                    .Take(count)
                    .Select(pair => pair.Key)
                    .ToArray();
        }

        public IPEndPoint[] GetBestAuthServers(int count)
        {
            return
                AuthServersLoad
                    .OrderBy((pair => pair.Value))
                    .Take(count)
                    .Select(pair => pair.Key)
                    .ToArray();
        }

        public IPEndPoint GetServerByClient(int clientId)
        {
            return ClientServerMap[clientId];
        }
    }
}
