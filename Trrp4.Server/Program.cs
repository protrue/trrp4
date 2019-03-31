using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Shared.DispatcherServiceReference;

namespace Trrp4.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"0 - ChatServer{Environment.NewLine}1 - AuthServer");
            var mode = int.Parse(Console.ReadLine());

            ServiceMetadataBehavior serviceMetadataBehavior;
            ServiceHost serviceHost;

            switch (mode)
            {
                case 0:
                    Console.WriteLine("ChatServer: started");

                    var chatServer = new ChatServer();
                    chatServer.Start();
                    
                    serviceMetadataBehavior = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                    };
                    serviceHost = new ServiceHost(chatServer, new Uri("http://localhost:8085/chatservice"));
                    serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
                    serviceHost.AddServiceEndpoint(typeof(IChatService), new BasicHttpBinding(), string.Empty);
                    serviceHost.Open();

                    Console.WriteLine("ChatServer: service started");
                    Console.ReadKey();
                    serviceHost.Close();
                    chatServer.Stop();
                    break;
                case 1:
                    Console.WriteLine("AuthServer: started");

                    var authServer = new AuthServer();

                    serviceMetadataBehavior = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                    };
                    serviceHost = new ServiceHost(authServer, new Uri("http://localhost:8085/authservice"));
                    serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
                    serviceHost.AddServiceEndpoint(typeof(IAuthService), new BasicHttpBinding(), string.Empty);
                    serviceHost.Open();

                    Console.WriteLine("AuthServer: service started");
                    Console.ReadKey();
                    serviceHost.Close();
                    break;
            }
        }
    }
}
