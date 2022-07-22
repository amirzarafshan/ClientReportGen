using System;
using ClientScripts.Models;
using System.Threading;
using System.IO;
using ReportParser.Services;
using ReportParser.Models;
using ReportParser.ReportCSV;
using System.Collections.Generic;

namespace ReportParser
{
    public static class Report
    {
        private static readonly string unitList = @"@units.txt";

        public static void GenerateFullReport()
        {
            ReportTypeForm.GenerateReportB.Click += CustomizeReport;
        }

        public static void CustomizeReport(object sender, EventArgs e)
        {
            ReportTypeForm.DisplayProgressInitiatedMessage();
            if (IsScreenReportChecked())
            {
                //GenerateScreenInfoReport();
                ScreenInformation.GenerateScreenInformationCSVReport(unitList);
            }
            else if (IsSystemReportChecked())
            {
                //GenerateSystemInfoReport();
                SystemInformation.GenerateSystemInformationCSVReport(unitList);
            }
            else if (IsMemoryReportChecked())
            {
                MemoryInformation.GenerateMemoryInformationCSVReport(unitList);
                //GenerateMemoryInformationReport_2();
            }
            else if (IsErrorReportChecked())
            {
                ErrorInformation.GenerateErrorInformationCSVReport(unitList);
                //GenerateErrorInformationReport();
            }
            ReportTypeForm.DisplayProgessCompletedMessage();
        }

        private static bool IsSystemReportChecked()
        {
            return ReportTypeForm.SystemReportB.Checked;
        }

        private static bool IsScreenReportChecked()
        {
            return ReportTypeForm.ScreenReportB.Checked;
        }

        private static bool IsMemoryReportChecked()
        {
            return ReportTypeForm.MemoryReportB.Checked;
        }

        private static bool IsErrorReportChecked()
        {
            return ReportTypeForm.ErrorReportB.Checked;
        }

       /* public static void GenerateScreenInfoReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("ScreenInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();
            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetCSVHeaders());
                file.WriteLine();
                file.Close();
            }

            Client.ReadClientsFromText(unitList)
               .ForEach(unit => { Stations.SendScreenInfoToCSV(unit, reportPath); Thread.Sleep(1000); });
        } */

       /* public static void GenerateSystemInfoReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("SysInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();
            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetSysInfoCSVHeaders());
                file.WriteLine();
                file.Close();
            }

            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { Stations.SendSystemInfoToCSV(unit, reportPath); Thread.Sleep(1000); });
        }*/

       /* public static void GenerateMemoryInformationReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("MemoryUsageInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();
            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetMemoryInfoCSVHeaders());
                file.WriteLine();
                file.Close();
            }

            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { Stations.SendMemoryInfoToCSV(unit, reportPath); Thread.Sleep(1000); });
        }*/

        //--------------------------------------------------

        /*public static void GenerateMemoryInformationReport_2()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("MemoryUsageInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            CsvParserService cps = new CsvParserService();

            cps.WriteToCsvFile(reportPath, FinalMemoryInfoModel());

        }*/

        /*public static IEnumerable<MemoryInfoModel> FinalMemoryInfoModel()
        {
            IList<MemoryInfoModel> mim = new List<MemoryInfoModel>();
            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { mim.Add(Stations.ClientMemoryInfoReport(unit)); Thread.Sleep(200); });

            return mim;
        }*/

        //---------------
        /* public static void GenerateErrorInformationReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("ErrorInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();
            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetErrorInfoCSVHeaders());
                file.WriteLine();
                file.Close();
            }

            Client.ReadClientsFromText(unitList)
                .ForEach(unit => { Stations.SendErrorInfoToCSV(unit, reportPath); Thread.Sleep(1000); });
        }  */
    }
}
