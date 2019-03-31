using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Client.Resources
{
    public class AuthorizationServerConection
    {
        public string Address { get; }

        public AuthorizationServerConection(string address)
        {
            Address = address;
        }

        public void Authenticate(string login, string password)
        {

        }

        public void Registrate(string login, string password)
        {

        }
    }
}
