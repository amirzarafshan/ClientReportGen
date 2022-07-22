using System;
using System.Management;

namespace ClientScripts.Models
{
    public sealed class LogicalDriveInfo
    {
        public string DriveName { get; set; }
        public string SerialNumber { get; set; }
        public string FileSystem { get; set; }
        public double Size { get; set; }
        public double FreeSpace { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
