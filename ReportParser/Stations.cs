using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClientScripts.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public static void SendScreenInfoToCSV(Client client,string csvPath)
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
                        {
                            foreach (var file in pcmstat_files)
                                try
                                { 
                                    if (ReportParser.ReportReader.IsValidType<ScreenReport>(file))
                                    {
                                        var report = ReportParser.ReportReader.ReadScreenReportFromFile(file);
                                        reports.Add(report);
                                    }
                                }
                                catch { throw new FileNotFoundException("screenReport File Not Found!"); }

                            var latest = reports.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                            csvFile.WriteLine(ScreenInformation(client, latest));
                            csvFile.Close();
                        }
                    } else { csvFile.WriteLine(client.Name + ",station not found!"); }
                }
            }
            catch
            {
                throw new FileNotFoundException("no *.pcmstat file found!");
            }     
        }

        static string ScreenInformation(Client client, ScreenReport info)
        {

            try
            {
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
            catch
            {
                return string.Join(",", client.Name, "screenreport not found!");
            }
        }
    }
}
