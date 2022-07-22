using ClientScripts.Models;
using ReportParser.Models;
using ReportParser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ReportParser.ReportCSV
{
    public class ErrorInformation
    {
        public static void GenerateErrorInformationCSVReport(string unitList)
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("ErrorInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            CsvParserService cps = new CsvParserService();

            cps.WriteToCsvFile(reportPath, ParseScreenInfoModel(unitList));

        }

        private static IEnumerable<ErrorModel> ParseScreenInfoModel(string unitList)
        {
            IList<ErrorModel> em = new List<ErrorModel>();
            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { em.Add(ClientReport.ClientErrorInfoReport(unit)); Thread.Sleep(200); });

            return em;
        }
    }
}
