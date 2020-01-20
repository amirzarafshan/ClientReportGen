using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClientScripts.Database;
using ClientScripts.Extensions;
using ClientScripts.Models;
using ClientScripts.Reports;

namespace ClientScripts
{
    internal class Program
    {
        private static readonly DBProviderBase DBProvider = new DBProviderBase(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PCMClient\pcmclient.mdb;Jet OLEDB:Database Password=PCMusic321;");       
        public static readonly int portNumber = 3389;

        private static void Main(string[] args)
        {
            try
            {
                        var screenreport = CreateScreenReport();
                        WriteReport(screenreport);
     
                        var systeminforeport = CreateOSInformationReport();
                        WriteReport(systeminforeport);
             
            }
            catch (Exception ex)
            {
                WriteExceptionReport(ex);
            }
        }

        private static void WriteReport(ReportBase reportBase)
        {
            using (var file = File.CreateText(reportBase.ReportName + ".pcmstat"))
            {
                file.Write(reportBase);
            }
        }

        private static ScreenReport CreateScreenReport()
        {
            return new ScreenReport
            {
                ClientParams = PCMClientParams.GetPCMClientPosition(DBProvider),
                Displays = Screen.AllScreens.Select(x => x.ToDisplayInfo()).ToArray(),
                Status = Status.Success
            };
        }

        private static SystemInfo CreateOSInformationReport()
        {
            try
            {
                return new SystemInfo
                {
                    ClientInfo = PCMClientParams.GetStationName(DBProvider),
                    OSInfo = OSInforExt.GetOSInfo(),
                    HardwareInfo = HardwareInfoExt.ToHardwareInfo(),
                    NetworkInformation = NetworkInfoExt.GetNetworkInfo(),
                    PortInformation = TcpPortInfoExt.GetPortStatusInfo(portNumber),
                    RemoteDesktopServiceInformation = RemoteDesktopServices.GetRunningRemoteServices().Select(sc =>sc.ToRemoteDesktopService()).ToArray(),
                    TeamViewerInformation = TVInfo.GetTVInfo().Select(x => x.ToTeamViewerInfo()).ToArray(),
                    Status = Status.Success
                };
            }
            catch
            {
                return new SystemInfo
                {
                    ClientInfo = PCMClientParams.GetStationName(DBProvider),
                    OSInfo = OSInforExt.GetOSInfo(),
                    HardwareInfo = HardwareInfoExt.ToHardwareInfo(),
                    NetworkInformation = NetworkInfoExt.GetNetworkInfo(),
                    PortInformation = TcpPortInfoExt.GetPortStatusInfo(portNumber),
                    RemoteDesktopServiceInformation = RemoteDesktopServices.GetRunningRemoteServices().Select(sc =>sc.ToRemoteDesktopService()).ToArray(),
                    Status = Status.Success
                };

            }

        }
        private static void WriteExceptionReport(Exception ex)
        {
            try
            {
                var report = new ErrorReport
                {
                    Exception = ex,
                    Status = Status.Failure
                };
                WriteReport(report);
            }
            catch
            {
                //ignore;
            }
        }

    }
}
