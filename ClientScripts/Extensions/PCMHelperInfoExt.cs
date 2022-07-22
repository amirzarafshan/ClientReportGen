using ClientScripts.Models;

namespace ClientScripts.Extensions
{
   public static class PCMHelperInfoExt
    {
        public static PCMHelperSvc ToPCMHelperInfo(this PCMHelperInfo pcmHelperInfo)
        {
            try
            {
                return new PCMHelperSvc
                {
                    Version = pcmHelperInfo.Version,
                    RamUsage = pcmHelperInfo.RamUsage,
                    WorkingSet = pcmHelperInfo.WorkingSet,
                    PeakWorkingSet = pcmHelperInfo.PeakWorkingSet,
                    CommitSize = pcmHelperInfo.CommitSize,
                    PagedPool = pcmHelperInfo.PagedPool,
                    NonPagedPool =  pcmHelperInfo.NonPagedPool,
                    Handles = pcmHelperInfo.Handles,
                    Threads=pcmHelperInfo.Threads,
                    GDIObject=pcmHelperInfo.GDIObject,
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
