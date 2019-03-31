using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Objects;

namespace Trrp4.Server
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void RedirectMessage(Message message);

        [OperationContract]
        void AddAccessKey(AccessKey accessKey);

        [OperationContract]
        void RevokeAccessKey(AccessKey accessKey);
    }
}
