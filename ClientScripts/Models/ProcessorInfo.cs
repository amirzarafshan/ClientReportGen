using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace ClientScripts.Models
{
    public sealed class ProcessorInfo
    {
        public string Name { get; set; }

        public ProcessorInfo (string cpuName)
        {
            Name = cpuName;
        }

        public static ProcessorInfo[] CPUsInfo()
        {
            List<ProcessorInfo> processorsList = new List<ProcessorInfo>();
            ManagementClass mc = new ManagementClass("Win32_Processor");
            foreach (ManagementObject processor in mc.GetInstances())
                processorsList.Add(new ProcessorInfo(processor["Name"].ToString()));

            return processorsList.ToArray();
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }

    }
}
