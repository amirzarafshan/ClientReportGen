using System;

namespace ClientScripts.Reports
{
    public sealed class ErrorReport : ReportBase
    {
        public Exception Exception { get; set; }

        //public override string ToCSV(char c = ',')
        //{
        //    throw new NotImplementedException();
       // }
    }
}
