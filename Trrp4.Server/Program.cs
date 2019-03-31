using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Связаться с диспетчером, сказать ему свой адрес и тип

            var mode = int.Parse(Console.ReadLine());

            switch (mode)
            {
                case 0:
                    var chatServer = new ChatServer();

                    break;
                case 1:
                    break;
            }
        }
    }
}
