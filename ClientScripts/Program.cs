using System;
using System.IO;
using System.Windows.Forms;
using ClientScripts.Database;
using ClientScripts.Models;
using ClientScripts.Reports;

namespace ClientScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var report = CreateScreenReport();
                WriteReport(report);
               
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
                ClientParams = PCMClientParams.GetPCMClientPosition(),
                Screens = Screen.AllScreens,
                Status = Status.Success
            };
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
