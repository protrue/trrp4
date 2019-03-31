using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Trrp4.Objects;

namespace Trrp4.Server
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool Register(UserInfo userInfo);

        [OperationContract]
        AccessKey Auth(UserInfo userInfo, IPEndPoint chatServer);

        [OperationContract]
        void Logout(AccessKey accessKey, IPEndPoint chatServer);
    }
}
