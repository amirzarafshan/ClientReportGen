using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClientScripts.Models
{
    public sealed class TcpClientPort
    {
        public int PortNumber { get; set; }
        public string Status { get; set; }

        public TcpClientPort(int portnumber, string status)
        {
            PortNumber = portnumber;
            Status = status;
        }

        public static string GetPortStatus(string localHostIP, int portNumber)
        {
            using (TcpClient tcpclient = new TcpClient())
            {
                try
                {
                    tcpclient.Connect(localHostIP, portNumber);
                    return "LISTENING";
                }
                catch
                {
                    return "NOTLISTENING";
                }

            }
        }
    }
}
