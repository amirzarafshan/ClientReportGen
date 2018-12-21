using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace ClientScripts.Models
{
    public sealed class GPUInformation
    {
        public string Name { get; set; }
        public long AdapterRAM { get; set; }

        public GPUInformation(string gpuInfo, long adapterRAM)
        {
            Name = gpuInfo;
            AdapterRAM = adapterRAM;
        }

        public static GPUInformation[] AllGraphicCards()
        {
            const int ToMB = 1048576;
            List<GPUInformation> graphicsCard = new List<GPUInformation>();
            ManagementClass graphicInfo = new ManagementClass("Win32_VideoController");
            foreach (ManagementObject m in graphicInfo.GetInstances())
                graphicsCard.Add(new GPUInformation(m["Description"].ToString().Trim(), Convert.ToInt32(m["AdapterRAM"]) / ToMB));

            return graphicsCard.ToArray();
           
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
