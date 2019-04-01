using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Objects
{
    [DataContract]
    public class AccessKey
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public DateTime Expires { get; set; }

        public static implicit operator AccessKey(Shared.AuthServiceReference.AccessKey accessKeyFromReference) 
        {
            var accessKey = new AccessKey
            {
                UserId = accessKeyFromReference.UserId,
                Key = accessKeyFromReference.Key,
                Expires = accessKeyFromReference.Expires
            };
            return accessKey;
        }
    }
}
