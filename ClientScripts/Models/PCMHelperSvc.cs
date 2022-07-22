
namespace ClientScripts.Models
{
        public sealed class PCMHelperSvc
        {
            public string Version { get; set; }
            public string RamUsage { get; set; }
            public string WorkingSet { get; set; }
            public string PeakWorkingSet { get; set; }
            public string CommitSize { get; set; }
            public string PagedPool { get; set; }
            public string NonPagedPool { get; set; }
            public int? Handles { get; set; }
            public int? Threads { get; set; }
            public int? GDIObject { get; set; }
        }
  
}
