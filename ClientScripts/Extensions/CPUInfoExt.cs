using System.Collections.Generic;
using ClientScripts.Models;
using System.Management;
using System.IO;

namespace ClientScripts.Extensions
{
    public static class CPUInfoExt
    {
        public static CPUInfo ToCPUInfo(this ProcessorInfo cpuInfo)
        {
            return new CPUInfo
            {
                Name = cpuInfo.Name.Trim()
            };
        }
    }
}
