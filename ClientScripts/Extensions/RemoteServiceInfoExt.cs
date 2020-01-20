using ClientScripts.Models;
using System;

namespace ClientScripts.Extensions
{
    public static class RemoteServiceInfoExt
    {
        public static RemoteDesktopServiceInfo ToRemoteDesktopService(this RemoteDesktopServices rsdInfo)
        {
            if (rsdInfo == null)
               throw new ArgumentNullException(nameof(rsdInfo));

            return new RemoteDesktopServiceInfo
            {
               ServiceName = rsdInfo.ServiceName,
               Status = rsdInfo.Status
            };
        }

    }
}
