using ClientScripts.Models;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace ReportParser
{
    public static class ReportTypeForm
    {
        public static RadioButton SystemReportB;
        public static RadioButton ScreenReportB;
        public static RadioButton MemoryReportB;
        public static RadioButton ErrorReportB;
        public static Button GenerateReportB;
        public static Label progress;

        public static void GenerateReport()
        {
            Size size = new Size(320, 200);
            Form inputBox = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = "Report Options"
            };

            SystemReportB = new RadioButton
            {
                Text = "System Info Report",
                Size = new Size(150, 30),
                Location = new Point(size.Width - 300, 10),
                Checked = true
            };
            inputBox.Controls.Add(SystemReportB);

            ScreenReportB = new RadioButton
            {
                Text = "Screen Info Report",
                Size = new Size(150, 30),
                Location = new Point(size.Width - 300, 50)
            };
            inputBox.Controls.Add(ScreenReportB);

            MemoryReportB = new RadioButton
            {
                Text = "Memory Usage Report",
                Size = new Size(160, 30),
                Location = new Point(size.Width - 140, 10)
            };
            inputBox.Controls.Add(MemoryReportB);

            ErrorReportB = new RadioButton
            {
                Text = "Error Report",
                Size = new Size(160, 30),
                Location = new Point(size.Width - 140, 50)
            };
            inputBox.Controls.Add(ErrorReportB);

            GenerateReportB = new Button
            {
                Text = "Generate Report",
                Size = new Size(100, 25),
                Location = new Point(size.Width - 180 - 80, 130)
            };
            inputBox.Controls.Add(GenerateReportB);

            Button Cancel = new Button
            {
                Text = "Close",
                Size = new Size(100, 25),
                Location = new Point(size.Width - 35 - 115, 130),
                DialogResult = DialogResult.Cancel
            };
            inputBox.Controls.Add(Cancel);

            progress = new Label
            {
                Width = 270,
                Location = new Point(size.Width - 260, 110)
            };
            progress.Font = new Font(progress.Font.Name, 8, FontStyle.Bold);
            inputBox.Controls.Add(progress);

            GenerateReportB.Click += Report.CustomizeReport;

            inputBox.ShowDialog();
        }
       
        private static bool IsSystemReportChecked()
        {
            return SystemReportB.Checked;
        }

        private static bool IsScreenReportChecked()
        {
            return ScreenReportB.Checked;
        }

        private static bool IsMemoryReportChecked()
        {
            return MemoryReportB.Checked;
        }

        public static void DisplayProgressInitiatedMessage()
        {
            progress.ForeColor = ColorTranslator.FromHtml("#a7182a");
            progress.Text = "Wait, collecting info is in progress ...";
            Thread.Sleep(500);
            Application.DoEvents();
        }

        public static void DisplayProgessCompletedMessage()
        {
            progress.ForeColor = ColorTranslator.FromHtml("#FF006400");
            progress.Text = "Done!";
        }
    }
}


