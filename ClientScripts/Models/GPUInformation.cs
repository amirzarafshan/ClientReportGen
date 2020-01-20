using System;
using System.Collections.Generic;
using System.Management;

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
            const int mb = 1048576;
            try
            {
                var graphicsCard = new List<GPUInformation>();
                using (var graphicInfo = new ManagementClass("Win32_VideoController"))
                {
                    lock (graphicInfo.GetInstances().SyncRoot)
                        foreach (var o in graphicInfo.GetInstances())
                        {
                            var m = (ManagementObject)o;
                            graphicsCard.Add(new GPUInformation(m["Description"].ToString().Trim(), Convert.ToInt64(m["AdapterRAM"]) / mb));
                        }

                    return graphicsCard.ToArray();
                }
            }
            catch
            {
                return null;
            }

        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
