﻿using ClientScripts.Models;
using Newtonsoft.Json;

namespace ClientScripts.Reports
{
    public sealed class ScreenReport : ReportBase
    {
        
        //public ClientParams ClientParams { get; set; }
        //public DisplayInfo[] Displays { get; set; }


        public ScreenReportData Data { get; set; }
        // public override string ToCSV(char c = ',')
        //{
        //    return string.Join(c.ToString(),
        //         ReportName, ReportVersion, CreatedAt, ClientParams.bLockAppWindow, Displays.Length);
        // }

    }

    
}   
