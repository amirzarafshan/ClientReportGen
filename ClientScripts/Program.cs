using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClientScripts.Database;
using ClientScripts.Extensions;
using ClientScripts.Models;
using ClientScripts.Reports;
using Microsoft.VisualBasic.Devices;

namespace ClientScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (args.Length == 0)
                //    return;

                //switch (args[0])
                //{
                    //case "screenreport":
                        var screenreport = CreateScreenReport();
                        WriteReport(screenreport);
                        //break;

                    //case "systeminfo":
                        var systeminforeport = CreateOSInformationReport();
                        WriteReport(systeminforeport);
                        //break;

                //}
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
                Displays = Screen.AllScreens.Select(x => x.ToDisplayInfo()).ToArray(),
                Status = Status.Success
            };
        }

        private static SystemInfo CreateOSInformationReport()
        {
            ComputerInfo ci = new ComputerInfo();

            return new SystemInfo
            {
                OSInfo = ci.ToOSInformation(),
                HardwareInfo = HardwareInfoExt.ToHardwareInfo(),
                NetworkInformation = NetworkInfoExt.ToNetworkInfo(),
                TeamViewerInformation = TVInfo.AllTeamViewerInfo().Select(x=> x.ToTeamViewerInfo()).ToArray(),
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
