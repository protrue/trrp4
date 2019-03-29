using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trrp4.LocalApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Thread(() =>
            {
                Console.WriteLine("Dispatcher thread started");

                Dispatcher.Program.Main(new string[0]);

                Console.WriteLine("Dispatcher thread stopped");
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine("AuthServer thread started");

                AuthServer.Program.Main(new string[0]);

                Console.WriteLine("Dispatcher thread stopped");
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine("ChatServer thread started");

                ChatServer.Program.Main(new string[0]);

                Console.WriteLine("Dispatcher thread stopped");
            }).Start();

            var clientThread = new Thread(() =>
            {
                Console.WriteLine("Client thread started");

                Client.Program.Main();

                Console.WriteLine("Dispatcher thread stopped");
            });
            clientThread.SetApartmentState(ApartmentState.STA);
            clientThread.Start();
        }
    }
}
