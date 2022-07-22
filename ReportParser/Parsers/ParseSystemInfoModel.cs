using ClientScripts.Models;
using ReportParser.Models;
using ClientScripts.Reports;
using System.Linq;
using System.Collections.Generic;

namespace ReportParser.Parsers
{
    public class ParseSystemInfoModel
    {
        public static SystemInformationModel ToSystemInfoInfoModel(Client client, SystemInfo sysinfo)
        {
            try
            {
                /*var cpu_info = sysinfo.HardwareInfo.CPUInfo.Select(c => string.Join("|", "{" + c.Name + "}")).ToList();
                var drivers = sysinfo.HardwareInfo.LogicalDiskInfo.Select(d => string.Join("|", "{" + d.DriveName, d.SerialNumber, d.FileSystem, d.Size, d.FreeSpace + "}")).ToList();
                var gpuInfo = sysinfo.HardwareInfo.VideoControllerInfo.Select(g => string.Join("|", "{" + g.Description, g.AdapterRAM + "}")).ToList();
                var portInformation = "{" + sysinfo.PortInformation.PortNumber + "|" + sysinfo.PortInformation.Status + "}";
                var remoteDesktopServices = sysinfo.RemoteDesktopServiceInformation.Select(sv => string.Join("|", "{" + sv.ServiceName + "}")).ToList();
                */
                return new SystemInformationModel
                {
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, sysinfo),
                    /*
                    Report_Name = nameof(SystemInfo),
                    Computer_System = string.IsNullOrEmpty(sysinfo.OSInfo.ComputerSystem) ? "" :  sysinfo.OSInfo.ComputerSystem,
                    Operating_System = string.IsNullOrEmpty(sysinfo.OSInfo.OperatingSystem) ? "" : sysinfo.OSInfo.OperatingSystem,
                    OS_Version = string.IsNullOrEmpty(sysinfo.OSInfo.OperatingSystemVersion) ? "" : sysinfo.OSInfo.OperatingSystemVersion,
                    BIOS = string.IsNullOrEmpty(sysinfo.HardwareInfo.BiosSerialNumber) ? "" : sysinfo.HardwareInfo.BiosSerialNumber,
                    Manufacturer = string.IsNullOrEmpty(sysinfo.HardwareInfo.Manufacturer) ? "" : sysinfo.HardwareInfo.Manufacturer,
                    Model = string.IsNullOrEmpty(sysinfo.HardwareInfo.Model) ? "" : sysinfo.HardwareInfo.Model,
                    RAM = sysinfo.HardwareInfo.RAM,
                    CPU_COUNT = sysinfo.HardwareInfo.CPU_Count,
                    CPU_Info = string.Join(" ", cpu_info),
                    HDD = string.Join(" ", drivers),
                    Video_Controllers = string.Join(" ", gpuInfo),
                    IP_Address = string.IsNullOrEmpty(sysinfo.NetworkInformation.IPAddress) ? "" : sysinfo.NetworkInformation.IPAddress,
                    Dot_NET_Ver = string.IsNullOrEmpty(sysinfo.NetworkInformation.DotNETVersion) ? "" : sysinfo.NetworkInformation.DotNETVersion,
                    IE_Ver = string.IsNullOrEmpty(sysinfo.NetworkInformation.IEVersion) ? "" : sysinfo.NetworkInformation.IEVersion,
                    Port_No = string.Join(" ", portInformation),
                    RDS = string.Join(" ", remoteDesktopServices), 
                    //TeamViewer = string.Join(" ", GetTeamViewerInfo(sysinfo)),
                    */
                };
            }
            catch
            {
                return new SystemInformationModel
                {
                   // ModelBase = ParseBaseModel.ToModelBaseInfo(client, sysinfo),
                };
            }
        }

        private static IEnumerable<string> GetTeamViewerInfo (SystemInfoData sysinfo)
        {
            var TeamViewerInfo = new List<string>();
            try { return sysinfo.TeamViewerInformation.Where(t => t != null).Select(t => string.Join("|", "{" + t.ClientId, t.Version + "}")).ToList(); 
            }
            catch { return null; }
        }
    }
}
