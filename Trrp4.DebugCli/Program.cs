using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Objects;
using Trrp4.Shared.AuthServiceReference;
using Trrp4.Shared.DispatcherServiceReference;

namespace Trrp4.DebugCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcherServiceClient = new DispatcherServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None),
                new EndpointAddress($"http://127.0.0.1:7001/dispatcher"));
            var bestAuthServer = dispatcherServiceClient.GetBestAuthServers(1).First();
            var bestChatServer = dispatcherServiceClient.GetBestChatServers(1).First();

            var authServiceClient = new AuthServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None),
                new EndpointAddress($"http://{bestAuthServer.Address}:{bestAuthServer.Port}/authservice"));

            var userInfo = new UserInfo() { Login = "protrue", Password = "1234" };

            authServiceClient.Register(userInfo);

            var accessKey = authServiceClient.Auth(userInfo, bestChatServer);

            var users = authServiceClient.GetUsers();

            var tcpClient = new TcpClient();
            tcpClient.Connect(bestChatServer);
            var networkStream = tcpClient.GetStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(networkStream, accessKey);

            var m = new Message() { Addressee = users[0].Id, Sender = accessKey.UserId };

            binaryFormatter.Serialize(networkStream, m);

            Console.ReadKey();
        }
    }
}
