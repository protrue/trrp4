using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.DebugCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var udp = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081));
            udp.Send(new byte[] { 0, 100 }, 2, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080));
        }
    }
}
