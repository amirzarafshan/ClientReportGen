using System;
using System.Collections.Generic;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace ClientScripts.Models
{
    public class ComputerSystemInfo
    {
        const int ToGB = 1000000000;

        private static string ComputerSystem(string propName)
        {
 
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            foreach (ManagementObject query in mc.GetInstances())
                    if (query.Properties.Count > 0)
                    {
                        return query[propName].ToString();
                    }    
            return null;
        }

        public static string Manufacturer()
        {
            return ComputerSystem("Manufacturer");
        }

        public static string Model()
        {
            return ComputerSystem("Model");
        }

        public static double PhysicalMemory()
        {
            ComputerInfo ci = new ComputerInfo();
            return Convert.ToDouble(ci.TotalPhysicalMemory/ToGB);
        }
    }
}
