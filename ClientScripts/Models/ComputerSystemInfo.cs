using System;
using System.Collections.Generic;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace ClientScripts.Models
{
    public class ComputerSystemInfo
    {
        const int ToMb = 1048576;

        private static string ComputerSystem(string propName)
        {
            try
            {
                using (var mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    lock (mc.GetInstances().SyncRoot)
                        foreach (var o in mc.GetInstances())
                        {
                            var query = (ManagementObject)o;
                            if (query?.Properties.Count > 0)
                            {
                                return query[propName].ToString();
                            }
                        }

                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
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
            var ci = new ComputerInfo();
            return Convert.ToDouble(ci.TotalPhysicalMemory/ToMb);
        }
    }
}
