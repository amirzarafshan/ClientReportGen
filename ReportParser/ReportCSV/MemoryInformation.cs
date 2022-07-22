using ClientScripts.Models;
using ReportParser.Models;
using ReportParser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ReportParser.ReportCSV
{
    public static class MemoryInformation
    {
        public static void GenerateMemoryInformationCSVReport(string unitList)
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("MemoryUsageInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            CsvParserService cps = new CsvParserService();

            cps.WriteToCsvFile(reportPath, ParseMemoryInfoModel(unitList));
        }

        private static IEnumerable<MemoryInfoModel> ParseMemoryInfoModel(string unitList)
        {
            IList<MemoryInfoModel> mim = new List<MemoryInfoModel>();
            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { mim.Add(ClientReport.ClientMemoryInfoReport(unit)); Thread.Sleep(200); });

            return mim;
        }
    }
}
