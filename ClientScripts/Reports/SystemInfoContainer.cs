using ClientScripts.Database;
using ClientScripts.Extensions;
using ClientScripts.Models;
using System.Linq;

namespace ClientScripts.Reports
{
    public static class SystemInfoContainer
    {
        private static readonly DBProviderBase DBProvider = new DBProviderBase(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PCMClient\pcmclient.mdb;Jet OLEDB:Database Password=PCMusic321;");
        public static readonly int portNumber = 3389;

        public static SystemInfoData ToSystemInfo()
        {
            return new SystemInfoData
            {
                ClientInfo = PCMClientParams.GetStationName(DBProvider),
                OSInfo = OSInforExt.GetOSInfo(),
                HardwareInfo = HardwareInfoExt.ToHardwareInfo(),
                NetworkInformation = NetworkInfoExt.GetNetworkInfo(),
                PortInformation = TcpPortInfoExt.GetPortStatusInfo(portNumber),
                RemoteDesktopServiceInformation = RemoteDesktopServices.GetRunningRemoteServices().Select(sc => sc.ToRemoteDesktopService()).ToArray(),
                TeamViewerInformation = TVInfo.GetTVInfo().Select(x => x.ToTeamViewerInfo()).ToArray(),
                MemoryUsage = MemoryUsageInfoExt.ToMemoryUsageInfo(),
            };
        }
    }
}
