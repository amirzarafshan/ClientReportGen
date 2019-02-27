using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using ClientScripts.Models;


namespace ClientScripts.Extensions
{
    public static class NetworkInfoExt
    {
        public static NetworkInfo ToNetworkInfo()
        {

            return new NetworkInfo
            {
                IPAddress = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString().Trim(),
                DotNETVersion = Environment.Version.ToString().Trim(),
                IEVersion = InternetExplorerVersion().Trim()

            };
        }


        public static string InternetExplorerVersion()
        {
           
            string IEVer = String.Empty;
            Thread t = new Thread(() =>
            {
                using (WebBrowser webBrowser = new WebBrowser())
                { IEVer = webBrowser.Version.ToString();}

            });
            
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            return IEVer;
        } 
    }
}
