﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trrp4.Dispatcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            dispatcher.AutoSetupPorts();
            dispatcher.StartObserving();
            
            Console.WriteLine($"Dispatcher: observing\n{dispatcher.ObserverEndPoint}\n{dispatcher.ServiceEndPoint}");

            var serviceMetadataBehavior = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
            };
            var serviceHost = new ServiceHost(dispatcher,
                new Uri($"http://{dispatcher.ServiceEndPoint.Address}:{dispatcher.ServiceEndPoint.Port}/dispatcher"));
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            serviceHost.AddServiceEndpoint(typeof(IDispatcherService), new BasicHttpBinding(), string.Empty);
            serviceHost.Open();

            Console.WriteLine("Dispatcher: service started");
            Console.ReadKey();
            serviceHost.Close();
            dispatcher.StopObserving();
        }
    }
}
