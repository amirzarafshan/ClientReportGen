using System;
using ClientScripts.Models;
using Microsoft.VisualBasic.Devices;

namespace ClientScripts.Extensions
{
    public static class OSInforExt
    {
        public static OSInformation GetOSInfo()
        {
            try
            {
                var ci = new ComputerInfo();
                return new OSInformation
                {
                    ComputerSystem = Environment.MachineName.Trim(),
                    OperatingSystem = ci.OSFullName.Trim(),
                    OperatingSystemVersion = ci.OSVersion.Trim()
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
