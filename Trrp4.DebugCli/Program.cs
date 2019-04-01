using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Trrp4.DebugCli
{
    class Program
    {
        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        static void Main(string[] args)
        {
            //var dispatcherServiceClient = new DispatcherServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None),
            //    new EndpointAddress($"http://127.0.0.1:7001/dispatcher"));
            //var bestAuthServer = dispatcherServiceClient.GetBestAuthServers(1).First();
            //var bestChatServer = dispatcherServiceClient.GetBestChatServers(1).First();

            //var authServiceClient = new AuthServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None),
            //    new EndpointAddress($"http://{bestAuthServer.Address}:{bestAuthServer.Port}/authservice"));

            //var userInfo = new UserInfo() { Login = "protrue", Password = "1234" };

            //authServiceClient.Register(userInfo);

            //var accessKey = authServiceClient.Auth(userInfo, bestChatServer);

            //var users = authServiceClient.GetUsers();

            //var tcpClient = new TcpClient();
            //tcpClient.Connect(bestChatServer);
            //var networkStream = tcpClient.GetStream();
            //var binaryFormatter = new BinaryFormatter();

            //binaryFormatter.Serialize(networkStream, accessKey);

            //var message = new Message() { Addressee = users[0].Id, Sender = accessKey.UserId, Text = "Hello"};

            //binaryFormatter.Serialize(networkStream, message);

            //var undelivered = (Message[])binaryFormatter.Deserialize(networkStream);

            //Console.WriteLine(undelivered.Length);
            //foreach (var m in undelivered)
            //    Console.WriteLine(m.Text);

            //var received = (Message)binaryFormatter.Deserialize(networkStream);

            //Console.WriteLine(received.Text);

            //tcpClient.Close();

            var uri = "https://data.gov.ru/api/json/dataset/7703771271-typesportobjects/version/20150923T130412/content/?access_token=1dbe5669474f6a2c5704256eb5eb7711";
            var response = Get(uri);

            dynamic json = JsonConvert.DeserializeObject(response);
            var jobj = JArray.Parse(response);



            //Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
