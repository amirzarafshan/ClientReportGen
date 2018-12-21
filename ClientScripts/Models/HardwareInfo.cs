using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScripts.Models
{
    public sealed class HardwareInformation
    {
        //Hardware_Info
        public string BiosSerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double RAM { get; set; }
        public int CPU_Count { get; set; }
        public CPUInfo[] CPUInfo { get; set; }
        public LogicalDriveInfo[] LogicalDiskInfo { get; set; }
        public VideoControllerInfo[] VideoControllerInfo { get; set; }
        
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }

}
