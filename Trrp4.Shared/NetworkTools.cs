using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Shared
{
    public static class NetworkTools
    {
        public static bool IsPortInUse(int port)
        {
            var isInUse = false;

            var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            var ipEndPoints = ipProperties.GetActiveTcpListeners();
            
            foreach (var endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    isInUse = true;
                    break;
                }
            }
            
            return isInUse;
        }
    }
}
