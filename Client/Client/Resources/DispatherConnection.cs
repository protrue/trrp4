﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client.Resources
{
    public class DispatherConnection
    {
        public Socket Socket { get; }
        public string Address { get; }

        public DispatherConnection()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Address = Properties.Settings.Default.PropertyValues["dispatcherID"].PropertyValue.ToString();
            System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(Address);
            System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 3456);
            Socket.Bind(new IPEndPoint(IPAddress.Any, 3456));
            Socket.Connect(remoteEP);
        }

        public void SendMessage(string message)
        {
            var data = ObjectToByteArray(message);
            Socket.Send(data);
        }

        private static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}
