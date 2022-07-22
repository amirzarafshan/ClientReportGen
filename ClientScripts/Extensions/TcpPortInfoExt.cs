using ClientScripts.Models;
using System.Net.Sockets;
using System.Net;

namespace ClientScripts.Extensions
{
    public static class TcpPortInfoExt 
    {      
        public static PortInfo GetPortStatusInfo(int portnumber)
        {
            using (TcpClient tcpclient = new TcpClient())
            {
                try
                {
                    tcpclient.Connect(IPAddress.Loopback.ToString(), portnumber);

                    return new PortInfo
                    {
                        PortNumber = portnumber,
                        Status = "LISTENING"
                    };                   
                }
                catch
                {
                    return new PortInfo
                    {
                        PortNumber = portnumber,
                        Status = "NOTLISTENING"
                    };
                }
            }
        }

    }
}
