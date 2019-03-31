using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Objects;

namespace Trrp4.Server
{
    public class AuthServer : IAuthService
    {
        public bool Register(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public AccessKey Auth(UserInfo userInfo, IPEndPoint chatServer)
        {
            throw new NotImplementedException();
        }
    }
}
