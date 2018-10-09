using System;

namespace ClientScripts.Reports
{
    public sealed class ErrorReport : ReportBase
    {
        public Exception Exception { get; set; }
    }
}
