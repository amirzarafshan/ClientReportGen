using ClientScripts.Models;
using System;

namespace ClientScripts.Extensions
{
    public static class MemoryUsageInfoExt
    {
        public static MemoryUsageInfo ToMemoryUsageInfo()
        {
            try
            {
                return new MemoryUsageInfo
                {
                    PagingFile = VirtualMemoryInfo.GetVirtulMemory().ToVirtulMemoryInfo(),
                    PCMHelper = PCMHelperInfo.GetResouceUsage().ToPCMHelperInfo(),
                    PCMClient = PCMClientInfo.GetResouceUsage().ToPCMClientInfo(),
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
