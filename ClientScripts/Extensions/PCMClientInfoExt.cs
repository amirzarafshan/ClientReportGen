using ClientScripts.Models;
using System;

namespace ClientScripts.Extensions
{
    public static class PCMClientInfoExt
    {
        public static PCMClient ToPCMClientInfo(this PCMClientInfo pcmclientInfo)
        {
            try
            {
                return new PCMClient
                {
                    Version = pcmclientInfo.Version,
                    RamUsage = pcmclientInfo.RamUsage,
                    WorkingSet = pcmclientInfo.WorkingSet,            
                    PeakWorkingSet = pcmclientInfo.PeakWorkingSet,
                    CommitSize = pcmclientInfo.CommitSize,
                    PagedPool = pcmclientInfo.PagedPool,
                    NonPagedPool = pcmclientInfo.NonPagedPool,
                    Handles = pcmclientInfo.Handles,
                    Threads = pcmclientInfo.Threads,
                    GDIObject = pcmclientInfo.GDIObject,
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
