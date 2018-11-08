using System;
using ClientScripts.Models;
using System.Windows.Forms;
using System.IO;

using System.Linq;
using ClientScripts.Extensions;

namespace ReportParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            GenerateFullReport();
        }
        
        static void GenerateFullReport()
        {
            string unitList = @"@units.txt";
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("{0:yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();

            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetCSVHeaders());
                file.WriteLine();
                file.Close();
            }

            var units = Client.ReadClientsFromText(unitList);
            foreach (var unit in units)
                try { Stations.SendScreenInfoToCSV(unit, reportPath); }
                catch { throw new FileNotFoundException("@units.txt: station '" + unit.Name + "' not exists!"); }
        }
    }
}
