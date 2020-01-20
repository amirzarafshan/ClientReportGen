using ClientScripts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace ReportParser
{
    class ReportTypeForm
    {
        static string unitList = @"@units.txt";
        private static RadioButton SystemReportB;
        private static RadioButton ScreenReportB;
        private static Label process;
        //private static ProgressBar progress;
       

        public static DialogResult GenerateReport()
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 200);
            Form inputBox = new Form();
            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Report Options";

            SystemReportB = new RadioButton();
            SystemReportB.Text = "System Info Report";
            SystemReportB.Size = new System.Drawing.Size(150, 30);
            SystemReportB.Location = new System.Drawing.Point(size.Width - 280, 10);
            SystemReportB.Checked = true;
            inputBox.Controls.Add(SystemReportB);

            ScreenReportB = new RadioButton();
            ScreenReportB.Text = "Screen Info Report";
            ScreenReportB.Size = new System.Drawing.Size(150, 30);
            ScreenReportB.Location = new System.Drawing.Point(size.Width - 280, 50);
            inputBox.Controls.Add(ScreenReportB);

            Button GenerateReport = new Button();
            GenerateReport.Text = "Generate Report";
            GenerateReport.Size = new System.Drawing.Size(100, 25);
            GenerateReport.Location = new System.Drawing.Point(size.Width - 180 - 80, 100);
            inputBox.Controls.Add(GenerateReport);

            Button Cancel = new Button();
            Cancel.Text = "Close";
            Cancel.Size = new System.Drawing.Size(100, 25);
            Cancel.Location = new System.Drawing.Point(size.Width - 35 - 115, 100);
            Cancel.DialogResult = DialogResult.Cancel;
            inputBox.Controls.Add(Cancel);

            process = new Label();
            process.Width = 270;
            process.Location = new Point(size.Width - 260, 150);     
            process.Font= new Font(process.Font.Name, 8,FontStyle.Bold);
            inputBox.Controls.Add(process);

            GenerateReport.Click += GenerateReport_Click;

            return inputBox.ShowDialog();
        }

        private static bool IsSystemReportChecked()
        {
            return SystemReportB.Checked;
        }

        private static bool IsScreenReportChecked()
        {
            return ScreenReportB.Checked;
        }

        private static void GenerateReport_Click(object sender, EventArgs e)
        {
            process.ForeColor = ColorTranslator.FromHtml("#a7182a");
            process.Text = "Wait, collecting info is in progress ...";
            Thread.Sleep(500);
            Application.DoEvents();

            if (IsScreenReportChecked())
                {
                   GenerateScreenInfoReport();
                }
            else if (IsSystemReportChecked())
                {
                   
                   GenerateSystemInfoReport();

                }
            process.ForeColor = ColorTranslator.FromHtml("#FF006400");
            process.Text = "Done!";
        }

        private static void GenerateScreenInfoReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("ScreenInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();

            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetCSVHeaders());
                file.WriteLine();
                file.Close();
            }
            var units = Client.ReadClientsFromText(unitList);
            foreach (var unit in units)
                Stations.SendScreenInfoToCSV(unit, reportPath);
        }

        private static void GenerateSystemInfoReport()
        {
            string reportPath = Path.Combine(Environment.CurrentDirectory, String.Format("SysInfo{0:-yyyy-MM-dd_hh-mm-ss}.csv", DateTime.Now));
            File.Create(reportPath).Dispose();

            using (StreamWriter file = new StreamWriter(reportPath))
            {
                file.WriteLine(Headers.GetSysInfoCSVHeaders());
                file.WriteLine();
                file.Close();
            }
            var units = Client.ReadClientsFromText(unitList);
            foreach (var unit in units)
                 Stations.SendSystemInfoToCSV(unit, reportPath);
                 Thread.Sleep(1000);
        }
       
    }
}


