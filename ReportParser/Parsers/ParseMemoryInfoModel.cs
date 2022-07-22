using ClientScripts.Models;
using ClientScripts.Reports;
using ReportParser.Models;

namespace ReportParser.Parsers
{
    public class ParseMemoryInfoModel
    {
        public static MemoryInfoModel ToMemInfoModel(Client client, SystemInfo sysinfo)
        {
            try
            {
                return new MemoryInfoModel
                {
                    
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, sysinfo),
                    /*
                    Report_Name = nameof(MemoryUsageInfo),
                    Operating_System = sysinfo.OSInfo.OperatingSystem,
                    Application_Name = nameof(PCMHelperSvc),
                    Build = sysinfo.MemoryUsage.PCMHelper.Version,
                    Paging_File = string.IsNullOrEmpty(sysinfo.MemoryUsage.PagingFile.Size) ? "" : sysinfo.MemoryUsage.PagingFile.Size.ToString(),
                    Ram_Usage = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.RamUsage) ? "" : sysinfo.MemoryUsage.PCMHelper.RamUsage.ToString(),
                    Working_Set = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.WorkingSet) ? "" : sysinfo.MemoryUsage.PCMHelper.WorkingSet.ToString(),
                    Peak_WorkingSet = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.PeakWorkingSet) ? "" : sysinfo.MemoryUsage.PCMHelper.PeakWorkingSet.ToString(),
                    CommitSize = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.CommitSize) ? "" : sysinfo.MemoryUsage.PCMHelper.CommitSize.ToString(),
                    Paged_Pool = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.PagedPool) ? "" : sysinfo.MemoryUsage.PCMHelper.PagedPool.ToString(),
                    Non_Paged_Pool = string.IsNullOrEmpty(sysinfo.MemoryUsage.PCMHelper.NonPagedPool) ? "" : sysinfo.MemoryUsage.PCMHelper.NonPagedPool.ToString(),
                    Handles = sysinfo.MemoryUsage.PCMHelper.Handles,
                    Threads = sysinfo.MemoryUsage.PCMHelper.Threads,
                    GDI_Object = sysinfo.MemoryUsage.PCMHelper.GDIObject,
                    */
                };
            }
            catch
            {
                //found no memory information//
                return new MemoryInfoModel
                {
                 //   ModelBase = ParseBaseModel.ToModelBaseInfo(client,sysinfo),
                };
            }
        }
    }
}
