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
            string File = "Screens";

            return String.Join(",", Client, Name, Version, Monitors_Count, Width, Height, BlockAppWindow, PosX, PosY, Create_Date, File);

        }

        public static string GetSysInfoCSVHeaders()
        {
            string Client = "Station_Name";
            string Name = "Report_Name";
            string Version = "Report_Version";
            string Create_Date = "Date_Created";
            string Computer = "Computer_System";
            string OS = "Operating_System";
            string OSVer = "OS_Version";
            string BIOS = "BIOS";
            string Manufacturer = "Manufacturer";
            string Model = "Model";
            string Ram = "RAM";
            string CPU_count = "CPU_COUNT";
            string CPUInfo = "CPU_Info";
            string LogicalDisk = "HDD_ID|Serial_Number|File_System|Total_Space|Free_Space";
            string Graphics = "VideoControllers";
            string IP = "IP_address";
            string DotNet = ".NET_Ver";
            string IE = "IE_Ver";
            string PortInfo = "PortNumber|Status";
            string RemoteService = "RemoteDesktopService|Status::Running";
            string TVID_ver = "TeamVierer_ID|Version";

            return String.Join(",", Client, Name, Version, Create_Date, Computer, OS, OSVer, BIOS, Manufacturer, Model, Ram, CPU_count, CPUInfo, LogicalDisk, Graphics, IP, DotNet, IE, PortInfo, RemoteService, TVID_ver);

        }
    }
}
