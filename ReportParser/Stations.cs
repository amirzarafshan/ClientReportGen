using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClientScripts.Reports;

namespace ClientScripts.Models
{
    public class Stations
    {
        public static readonly string stations_Folder = @"\\h5c0\pcmserver\Stations\";
        public static readonly string extension = "*.pcmstat";

        public static List<Client> AllStations()
        {
            try
            {
                var unitPaths = Directory.GetDirectories(stations_Folder);    
                List<Client> units = new List<Client>();
                foreach (var unit in unitPaths)
                {
                    units.Add(new Client(Path.GetFileName(unit)));       
                }
                return units; 
            }
            catch { throw new DirectoryNotFoundException("pcmserver\\stations folder not available!"); }
        }

        public static bool IsValidStation(Client client)
        {
            try { return AllStations().Exists(x => x.Name.Equals(client.Name, StringComparison.OrdinalIgnoreCase)); }
            catch { return false; }
        }

        public static SystemInfo GetLatestSysInfoStatFile(Client client)
        {
            try
            {
                if (IsValidStation(client))
                {
                    string source_path = Path.Combine(stations_Folder, client.Name);
                    var pcmstat_files = Directory.GetFiles(source_path, extension);
                    var reports_SysInfo = new List<SystemInfo>();
                    foreach (var file in pcmstat_files)
                        if (ReportParser.ReportReader.IsValidType<SystemInfo>(file))
                        {
                           var report_sysInfo = ReportParser.ReportReader.ReadSystemInfoFromFile(file);
                           reports_SysInfo.Add(report_sysInfo);
                        }
                    return reports_SysInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                }


            }
            catch {
                throw new FileNotFoundException("station is not valid!"); }
            return null;        
        }

        public static ScreenReport GetLatestScreenInfoStatFile(Client client)
        {
            try
            {
                if (IsValidStation(client))
                {
                    string source_path = Path.Combine(stations_Folder, client.Name);
                    var pcmstat_files = Directory.GetFiles(source_path, extension);
                    var reports_ScreenInfo = new List<ScreenReport>();
                    foreach (var file in pcmstat_files)
                        if (ReportParser.ReportReader.IsValidType<ScreenReport>(file))
                        {
                          var report_screenInfo = ReportParser.ReportReader.ReadScreenReportFromFile(file);
                          reports_ScreenInfo.Add(report_screenInfo);
                        }
                    return reports_ScreenInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                }
            }
            catch { throw new FileNotFoundException("station is not valid!"); }
            return null;
        }

        /*public static void SendSystemInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvSysInfo = new StreamWriter(csvPath, true))
            try
            {
                    GetLatestSysInfoStatFile(client);
                    csvSysInfo.WriteLine(SystemInformation(client, GetLatestSysInfoStatFile(client)));
                    csvSysInfo.Close();
            }
            catch
            {
                    csvSysInfo.WriteLine (string.Join(",", "\"" + client.Name + "\"", "systemreport not found!"));
                    csvSysInfo.Close();                  
            }
        } */
    
        //Error report//
       public static ErrorReport GetErrorReport(Client client)
        {
            try
            {
                if (IsValidStation(client))
                {
                    string source_path = Path.Combine(stations_Folder, client.Name);
                    var pcmstat_files = Directory.GetFiles(source_path, extension);
                    var reports_ErrorInfo = new List<ErrorReport>();
                    foreach (var file in pcmstat_files)
                        if (ReportParser.ReportReader.IsValidType<ErrorReport>(file))
                        {
                            var report_errInfo = ReportParser.ReportReader.ReadErrorReportFromFile(file);
                            reports_ErrorInfo.Add(report_errInfo);
                        }
                    return reports_ErrorInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                }
            }
            catch
            {
                throw new FileNotFoundException("station is not valid!");
            }
            return null;

        }

       /* public static void SendMemoryInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvMemoryInfo = new StreamWriter(csvPath, true))
               try
                {
                    GetLatestScreenInfoStatFile(client);
                    csvMemoryInfo.WriteLine(MemoryInfo(client, GetLatestSysInfoStatFile(client)));
                }
                catch
                {
                    csvMemoryInfo.WriteLine(string.Join(",", "\"" + client.Name + "\"", "memoryinformation not found!"));
                    csvMemoryInfo.Close();
                }

        } */







        ///------------------------
       

        //-------------------


        /*public static void SendScreenInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvScreenInfo = new StreamWriter(csvPath, true))
            try
            {
                    GetLatestScreenInfoStatFile(client);
                    csvScreenInfo.WriteLine(ScreenInformation(client, GetLatestScreenInfoStatFile(client)));
                    csvScreenInfo.Close();
            }
            catch
            {
                    csvScreenInfo.WriteLine(string.Join(",", "\"" + client.Name + "\"", "screenreport not found!"));
                    csvScreenInfo.Close();
            }
        } */

        //Send Error Report
        /*public static void SendErrorInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvErrInfo = new StreamWriter(csvPath, true))
                try
                {
                    GetSystemInfoErrorReport(client);
                    csvErrInfo.WriteLine(ErrorInformation(client, GetSystemInfoErrorReport(client)) +"\r\n");

                }
                catch
                {
                    csvErrInfo.WriteLine(string.Join(",", "\"" + client.Name + "\"", "ErrInfo not found!"));
                    csvErrInfo.Close();
                }

        }

        public static string ErrorInformation(Client client, ErrorReport err)
        {
            return string.Join(",", "\"" + client.Name + "\"", err.ReportName, err.ReportVersion, err.CreatedAt, err.Exception.Message, err.Exception.StackTrace);
        } */

       /* public static string ScreenInformation(Client client, ScreenReport info)
        {
            return string.Join(",", "\"" + client.Name + "\"", info.ReportName, info.ReportVersion, info.Displays.Length,
                        info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Width,
                        info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Height,
                        info.ClientParams.bLockAppWindow,
                        info.ClientParams.iPosX,
                        info.ClientParams.iPosY,
                        info.CreatedAt,
                        String.Join("\" ", JsonConvert.SerializeObject(info.Displays, Formatting.None).ToLowerInvariant().Split(','))
                        );         
        }*/

        /*public static string  SystemInformation(Client client, SystemInfo sysinfor)
        {
            var TeamViewerInfo = new List<string>();
            var CPUInfo = sysinfor.HardwareInfo.CPUInfo.Select(c => string.Join("|", "{" + c.Name + "}")).ToList();
            var driveInfo = sysinfor.HardwareInfo.LogicalDiskInfo
                            .Select(d => string.Join("|","{" + d.DriveName,d.SerialNumber,d.FileSystem,d.Size,d.FreeSpace +"}")).ToList();

            var GPUInfo = sysinfor.HardwareInfo.VideoControllerInfo
                          .Select(g => string.Join("|", "{" + g.Description,g.AdapterRAM + "}")).ToList();

            var PortInformation = "{" + sysinfor.PortInformation.PortNumber + "|" + sysinfor.PortInformation.Status + "}";

            var RemoteDesktopServices = sysinfor.RemoteDesktopServiceInformation
                                         .Select(sv => string.Join("|","{" + sv.ServiceName + "}")).ToList();
            try
            {
                TeamViewerInfo = sysinfor.TeamViewerInformation.Where(t => t != null)
                             .Select(t => string.Join("|", "{" + t.ClientId, t.Version + "}")).ToList();
            }
            catch {

                TeamViewerInfo.Clear();
            }
            return string.Join(",", "\"" + client.Name + "\"" , sysinfor.ReportName, sysinfor.ReportVersion, sysinfor.CreatedAt, sysinfor.OSInfo.ComputerSystem,
                       sysinfor.OSInfo.OperatingSystem, sysinfor.OSInfo.OperatingSystemVersion, sysinfor.HardwareInfo.BiosSerialNumber, sysinfor.HardwareInfo.Manufacturer,
                       sysinfor.HardwareInfo.Model,
                       sysinfor.HardwareInfo.RAM, sysinfor.HardwareInfo.CPU_Count,
                       string.Join(" ", CPUInfo),
                       string.Join(" ", driveInfo),
                       string.Join(" ", GPUInfo),
                       sysinfor.NetworkInformation.IPAddress,
                       sysinfor.NetworkInformation.DotNETVersion,
                       sysinfor.NetworkInformation.IEVersion,
                       PortInformation,
                       string.Join(" ",RemoteDesktopServices),
                       string.Join(" ",TeamViewerInfo));
        } */

        /*public static string MemoryInfo(Client client, SystemInfo sysinfo)
        {

            return string.Join(",", "\"" + client.Name + "\"", "memoryinfo", sysinfo.ReportVersion, sysinfo.CreatedAt, sysinfo.OSInfo.OperatingSystem, nameof(PCMHelperSvc),sysinfo.MemoryUsage.PCMHelper.Version,
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PagingFile.Size) ? "" : sysinfo.MemoryUsage.PagingFile.Size.ToString(),                   
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.RamUsage) ? "" : sysinfo.MemoryUsage.PCMHelper.RamUsage.ToString(),
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.WorkingSet) ? "" : sysinfo.MemoryUsage.PCMHelper.WorkingSet.ToString(),
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.PeakWorkingSet) ? "" : sysinfo.MemoryUsage.PCMHelper.PeakWorkingSet.ToString(),
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.CommitSize) ? "" : sysinfo.MemoryUsage.PCMHelper.CommitSize.ToString(),
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.PagedPool) ? "" : sysinfo.MemoryUsage.PCMHelper.PagedPool.ToString(),
                string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.NonPagedPool) ? "" : sysinfo.MemoryUsage.PCMHelper.NonPagedPool.ToString(),
                sysinfo.MemoryUsage.PCMHelper.Handles,
                sysinfo.MemoryUsage.PCMHelper.Threads,
                sysinfo.MemoryUsage.PCMHelper.GDIObject
                );
        } */
    }
    
}
