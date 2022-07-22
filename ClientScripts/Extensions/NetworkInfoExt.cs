using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using ClientScripts.Models;
using Microsoft.Win32;

namespace ClientScripts.Extensions
{
    public static class NetworkInfoExt
    {
        public static NetworkInfo GetNetworkInfo()
        {
            var ip = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork)
                         ?.ToString().Trim() ?? "no found";
            return new NetworkInfo
            {
                IPAddress = ip,
                DotNETVersion = Environment.Version.ToString().Trim(),
                IEVersion = InternetExplorerVersion().Trim()              
            };
        }

        public static string InternetExplorerVersion()
        {
            return Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer")?.GetValue("Version").ToString();
        }
    }
}
