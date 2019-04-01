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
                    var chatServer = new ChatServer();
                    chatServer.AutoSetupPorts();
                    chatServer.Start();

                    Console.WriteLine($"ChatServer: started\n{chatServer.NotifierEndPoint}\n{chatServer.ListenerEndPoint}\n{chatServer.ServiceEndPoint}");

                    serviceMetadataBehavior = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                    };
                    serviceHost = new ServiceHost(chatServer, new Uri($"http://{chatServer.ServiceEndPoint.Address}:{chatServer.ServiceEndPoint.Port}/chatservice"));
                    serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
                    serviceHost.AddServiceEndpoint(typeof(IChatService), new BasicHttpBinding(), string.Empty);
                    serviceHost.Open();

                    Console.WriteLine("ChatServer: service started");
                    Console.ReadKey();
                    serviceHost.Close();
                    chatServer.Stop();
                    break;
                case 1:
                    var authServer = new AuthServer();
                    authServer.AutoSetupPorts();
                    authServer.Start();

                    Console.WriteLine($"AuthServer: started\n{authServer.NotifierEndPoint}\n{authServer.ServiceEndPoint}");

                    serviceMetadataBehavior = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                    };
                    serviceHost = new ServiceHost(authServer, new Uri($"http://{authServer.ServiceEndPoint.Address}:{authServer.ServiceEndPoint.Port}/authservice"));
                    serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
                    serviceHost.AddServiceEndpoint(typeof(IAuthService), new BasicHttpBinding(), string.Empty);
                    serviceHost.Open();

                    Console.WriteLine("AuthServer: service started");
                    Console.ReadKey();
                    serviceHost.Close();
                    authServer.Stop();
                    break;
            }
        }
    }
}
