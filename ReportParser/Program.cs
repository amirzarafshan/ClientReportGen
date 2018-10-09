using System;
using ClientScripts.Reports;

namespace ReportParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = ReportReader.IsValidType<ScreenReport>("screenreport.pcmstat");
            Console.WriteLine(test);
            Console.ReadKey();
        }
    }
}
