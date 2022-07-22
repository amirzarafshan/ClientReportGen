using ClientScripts.Models;
using ReportParser.Models;
using ReportParser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace ReportParser.ReportCSV
{
    public class SystemInformation
    {
        public static void GenerateSystemInformationCSVReport(string unitList)
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("SystemInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            CsvParserService cps = new CsvParserService();

            cps.WriteToCsvFile(reportPath, ParseSystemInfoModel(unitList));

        }

        private static IEnumerable<SystemInformationModel> ParseSystemInfoModel(string unitList)
        {
            IList<SystemInformationModel> sim = new List<SystemInformationModel>();
            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { sim.Add(ClientReport.ClientSystemInfoReport(unit)); Thread.Sleep(200); });

            return sim;
        }
    }
}
