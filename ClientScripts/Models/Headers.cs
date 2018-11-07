using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientScripts.Models
{
    public class Headers
    {
        public static string GetCSVHeaders()
        {
            string Client = "Station_Name";
            string Name = "Report_Name";
            string Version = "Report_Version";
            string Monitors_Count = "Monitors";
            string Width = "Screen_Width";
            string Height = "Screen_Height";
            string BlockAppWindow = "bLockAppWindow";
            string PosX = "iPosX";
            string PosY = "iPosY";
            string Create_Date = "Date_Created";

            return String.Join(",", Client, Name, Version, Monitors_Count, Width, Height, BlockAppWindow, PosX, PosY, Create_Date);

        }
    }
}
