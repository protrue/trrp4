using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.Runtime.Serialization.Formatters.Binary;
using Trrp4.Dispatcher  ;

namespace Trrp4.Client.Resources
{
    public class DispatherConnection
    {
        public string Address { get; } = "http://localhost:8000/MyService";
        private IDispatcherService Service;

        public DispatherConnection()
        {
            Uri tcpUri = new Uri(Address);
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IDispatcherService> factory = new ChannelFactory<IDispatcherService>(binding, address);
            Service = factory.CreateChannel();
        }

        public IPEndPoint[] GetAuthorizationServerAddress(int count)
        {
            var addreses = Service.GetBestAuthServers(count);
            return addreses;
        }

        public IPEndPoint[] GetChatServerAddress(int count)
        {
            var addreses = Service.GetBestAuthServers(count);
            return addreses;
        }

        //private static byte[] ObjectToByteArray(Object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    bf.Serialize(ms, obj);
        //    return ms.ToArray();
        //}
    }
}
