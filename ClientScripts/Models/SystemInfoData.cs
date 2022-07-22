using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientScripts.Models
{
    public sealed class SystemInfoData
    {
        public ClientInfo ClientInfo { get; set; }
        public OSInformation OSInfo { get; set; }
        public HardwareInformation HardwareInfo { get; set; }
        public NetworkInfo NetworkInformation { get; set; }
        public PortInfo PortInformation { get; set; }
        public RemoteDesktopServiceInfo[] RemoteDesktopServiceInformation { get; set; }
        public TVInformation[] TeamViewerInformation { get; set; }
        public MemoryUsageInfo MemoryUsage { get; set; }
    }
}
