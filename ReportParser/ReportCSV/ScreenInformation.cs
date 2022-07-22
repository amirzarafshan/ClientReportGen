using ClientScripts.Models;
using ReportParser.Models;
using ReportParser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ReportParser.ReportCSV
{
    public class ScreenInformation
    {
        public static void GenerateScreenInformationCSVReport(string unitList)
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("ScreenInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            CsvParserService cps = new CsvParserService();

            cps.WriteToCsvFile(reportPath, ParseScreenInfoModel(unitList));

        }

        private static IEnumerable<ScreenInfoModel> ParseScreenInfoModel(string unitList)
        {
            IList<ScreenInfoModel> scim = new List<ScreenInfoModel>();
            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { scim.Add(ClientReport.ClientSceenInfoReport(unit)); Thread.Sleep(200); });

            return scim;
        }
    }
}
