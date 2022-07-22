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
            ReportTypeForm.GenerateReport();       
        }
    }
}
