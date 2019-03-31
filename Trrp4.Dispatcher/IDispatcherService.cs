using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Objects;

namespace Trrp4.Dispatcher
{
    [ServiceContract]
    public interface IDispatcherService
    {
        [OperationContract]
        IPEndPoint[] GetBestChatServers(int count);

        [OperationContract]
        IPEndPoint[] GetBestAuthServers(int count);

        [OperationContract]
        IPEndPoint GetServerByClient(int clientId);
    }
}
