using CsvHelper.Configuration.Attributes;
using System.Collections;

namespace ReportParser.Models
{
    public class SystemInformationModel
    {
        public ModelBase ModelBase { get; set; }
        public string Report_Name { get; set; }
        public string Computer_System { get; set; }
        public string Operating_System { get; set; }
        public string OS_Version { get; set; }
        public string BIOS { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double? RAM { get; set; }
        public int? CPU_COUNT { get; set; }
        public string CPU_Info { get; set; }

        [Name("HDD_ID|Serial_Number|File_System|Total_Space|Free_Space")]
        public string HDD { get; set; }

        public string Video_Controllers { get; set; }
        public string IP_Address { get; set; }
        public string Dot_NET_Ver { get; set; }
        public string IE_Ver { get; set; }

        [Name("Port_Number|Status")]
        public string Port_No { get; set; }

        [Name("RemoteDesktopService|Status::Running")]
        public string RDS { get; set; }

        [Name("TeamVierer_ID|Version")]
        public string TeamViewer { get; set; }
    }
}