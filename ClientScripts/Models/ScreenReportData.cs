using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientScripts.Models
{
    public sealed class ScreenReportData
    {
        public ClientParams ClientParams { get; set; }
        public DisplayInfo[] Displays { get; set; }

    }
}
