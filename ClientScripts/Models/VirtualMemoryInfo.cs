using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace ClientScripts.Models
{
    public sealed class VirtualMemoryInfo
    {
       
        public string Size { get; set; }

        public VirtualMemoryInfo(string size)
        {
            Size = size;
        }

        public static VirtualMemoryInfo GetVirtulMemory()
        {
            try { return new VirtualMemoryInfo(GetPagingFile()); }
            catch { return null; }
        }

        private static string GetPagingFile()
        {
            var ci = new ComputerInfo();
            float RAM = ci.TotalPhysicalMemory;

            try
            {
                var commitLimit = new PerformanceCounter("Memory", "Commit Limit", null);
                return Convert.ToInt64(commitLimit.RawValue - RAM) / (1024 * 1024) + " MB";
            }
            catch { return GetPagingFileUsingManagementObjectSearcher(); }
        }

        private static string GetPagingFileUsingManagementObjectSearcher()
        {
            try
            {
                var pagingfile = new ManagementObjectSearcher("SELECT AllocatedBaseSize FROM Win32_PageFileUsage").
                            Get().OfType<ManagementObject>().Select(obj => obj.GetPropertyValue("AllocatedBaseSize")).FirstOrDefault();
                return pagingfile.ToString() + " MB";
            }
            catch { return null; }

        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }

    }
}
