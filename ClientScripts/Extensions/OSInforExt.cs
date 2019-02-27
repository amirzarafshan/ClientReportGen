using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientScripts.Models;
using Microsoft.VisualBasic.Devices;

namespace ClientScripts.Extensions
{
    public static class OSInforExt
    {
        public static OSInformation ToOSInformation(this ComputerInfo computerInfo)
        {
            if (computerInfo == null)
                throw new ArgumentNullException(nameof(computerInfo));

            return new OSInformation
            {
                ComputerSystem = Environment.MachineName.Trim(),
                OperatingSystem = computerInfo.OSFullName.Trim(),
                OperatingSystemVersion = computerInfo.OSVersion.Trim()
            };
        }
    }
}
