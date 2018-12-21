using System;
using System.IO;
using System.Linq;
using ClientScripts.Models;
using System.Management;

namespace ClientScripts.Extensions
{
    public static class HardwareInfoExt
    {
        public static HardwareInformation ToHardwareInfo()
        {
            ManagementClass vc = new ManagementClass("Win32_VideoController");
            return new HardwareInformation
            {   
                BiosSerialNumber = BIOSInfo.SerialNumber(),
                Manufacturer = ComputerSystemInfo.Manufacturer(),
                Model = ComputerSystemInfo.Model(),
                RAM = ComputerSystemInfo.PhysicalMemory(),
                CPU_Count = Environment.ProcessorCount,
                CPUInfo = ProcessorInfo.CPUsInfo().Select(c => c.ToCPUInfo()).ToArray(),
                LogicalDiskInfo = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Fixed).Select(x => x.ToHDDInfo()).ToArray(),
                VideoControllerInfo = GPUInformation.AllGraphicCards().Select(y => y.ToVideoControllerInfo()).ToArray()        
            };
            
        }
    }
}
