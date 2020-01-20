using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClientScripts.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClientScripts.Extensions;

namespace ClientScripts.Models
{
    class Stations
    {
        public static readonly string stations_Folder = @"\\nl0\pcmserver\Stations\";
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

        private static SystemInfo GetLatestSysInfoStatFile(Client client)
        {
            try
            {
                if (IsValidStation(client))
                {
                    string source_path = Path.Combine(stations_Folder, client.Name);
                    var pcmstat_files = Directory.GetFiles(source_path, extension);

                    var reports_SysInfo = new List<SystemInfo>();

                    foreach (var file in pcmstat_files)
                        //try
                        //{
                            if (ReportParser.ReportReader.IsValidType<SystemInfo>(file))
                            {
                                var report_sysInfo = ReportParser.ReportReader.ReadSystemInfoFromFile(file);
                                reports_SysInfo.Add(report_sysInfo);
                            }
                        //}
                        //catch { throw new FileNotFoundException("systemInfo File Not Found!"); }
                    return reports_SysInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                }
            }
            catch {
                throw new FileNotFoundException("station is not valid!"); }
            return null;
          
        }

        private static ScreenReport GetLatestScreenInfoStatFile(Client client)
        {
            try
            {
                if (IsValidStation(client))
                {
                    string source_path = Path.Combine(stations_Folder, client.Name);
                    var pcmstat_files = Directory.GetFiles(source_path, extension);

                    var reports_ScreenInfo = new List<ScreenReport>();

                    foreach (var file in pcmstat_files)
                        //try
                        //{
                            if (ReportParser.ReportReader.IsValidType<ScreenReport>(file))
                            {
                                var report_screenInfo = ReportParser.ReportReader.ReadScreenReportFromFile(file);
                                reports_ScreenInfo.Add(report_screenInfo);
                            }

                        //}
                        //catch { throw new FileNotFoundException("screenReport File Not Found!"); }
                    return reports_ScreenInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                }
            }
            catch { throw new FileNotFoundException("station is not valid!"); }
            return null;

        }


        public static void SendSystemInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvSysInfo = new StreamWriter(csvPath, true))
            try
            {
                //using (StreamWriter csvSysInfo = new StreamWriter(csvPath, true))
                {
                    GetLatestSysInfoStatFile(client);
                    csvSysInfo.WriteLine(SystemInformation(client, GetLatestSysInfoStatFile(client)));
                    csvSysInfo.Close();
                }
            }
            catch
            {
               csvSysInfo.WriteLine (string.Join(",", client.Name, "systemreport not found!"));
               csvSysInfo.Close();
                    //throw new FileNotFoundException("systemInfo File Not Found!"); }
            }
        }

        public static void SendScreenInfoToCSV(Client client, string csvPath)
        {
            using (StreamWriter csvScreenInfo = new StreamWriter(csvPath, true))
            try
            {
                //using (StreamWriter csvScreenInfo = new StreamWriter(csvPath, true))
                //{
                    GetLatestSysInfoStatFile(client);
                    csvScreenInfo.WriteLine(ScreenInformation(client, GetLatestScreenInfoStatFile(client)));
                    csvScreenInfo.Close();
               // }
            }
            catch
            {
                    csvScreenInfo.WriteLine(string.Join(",", client.Name, "screenreport not found!"));
                    csvScreenInfo.Close();
                    //throw new FileNotFoundException("systemInfo File Not Found!"); }
            }
        }


      /*  public static void SendScreenInfoToCSV(Client client,string csvPath)
        {
            try
            {
                using (StreamWriter csvFile = new StreamWriter(csvPath, true))
                {
                    if (IsValidStation(client))
                    {
                        string source_path = Path.Combine(stations_Folder, client.Name);
                        var pcmstat_files = Directory.GetFiles(source_path, extension);

                        var reports = new List<ScreenReport>();
                        //var reports_SysInfo = new List<SystemInfo>();

                        {
                            foreach (var file in pcmstat_files)
                                try
                                { 
                                  if (ReportParser.ReportReader.IsValidType<ScreenReport>(file))
                                    {
                                        var report = ReportParser.ReportReader.ReadScreenReportFromFile(file);
                                        reports.Add(report);
                                    } 

                                    //System info
                                    if (ReportParser.ReportReader.IsValidType<SystemInfo>(file))
                                    {
                                        //var report_sysInfo = ReportParser.ReportReader.ReadSystemInfoFromFile(file);
                                        //reports_SysInfo.Add(report_sysInfo);
                                    }
                                }
                                catch { throw new FileNotFoundException("screenReport File Not Found!"); }
                            //ScreenInfo
                            //var latest = reports.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                            //csvFile.WriteLine(ScreenInformation(client, latest));
                            //csvFile.Close();

                            //SystemInfo
                            //var SysInfoLatest = reports_SysInfo.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                            //csvFile.WriteLine(SystemInformation(client, SysInfoLatest));
                           //csvFile.Close();
                        }
                    } else { csvFile.WriteLine(client.Name + ",station not found!"); }
                }
            }
            catch
            {
                throw new FileNotFoundException("no *.pcmstat file found!");
            }     
        }
        */
        public static string ScreenInformation(Client client, ScreenReport info)
        {

            //try
            //{
                return string.Join(",", client.Name, info.ReportName, info.ReportVersion, info.Displays.Length,
                        info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Width,
                        info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Height,
                        info.ClientParams.bLockAppWindow,
                        info.ClientParams.iPosX,
                        info.ClientParams.iPosY,
                        info.CreatedAt,
                        String.Join("\" ", JsonConvert.SerializeObject(info.Displays, Formatting.None).ToLowerInvariant().Split(','))
                        );         
 
        }

       
        public static string  SystemInformation(Client client, SystemInfo sysinfor)
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
       
                return string.Join(",", client.Name, sysinfor.ReportName, sysinfor.ReportVersion, sysinfor.CreatedAt, sysinfor.OSInfo.ComputerSystem,
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
    
        }
    }
}
