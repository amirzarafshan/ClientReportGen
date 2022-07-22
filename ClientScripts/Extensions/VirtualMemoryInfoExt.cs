using ClientScripts.Models;
using System;

namespace ClientScripts.Extensions
{
    public static class VirtualMemoryInfoExt
    {
        public static VirtualMemory ToVirtulMemoryInfo(this VirtualMemoryInfo virtalMemoryinfo)
        {
            try
            {
                return new VirtualMemory
                {
                    Size = virtalMemoryinfo.Size
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
