
namespace ClientScripts.Models
{
    public sealed class PCMClient
    {
        public string Version { get; set; }
        public string RamUsage { get; set; }
        public string WorkingSet { get; set; }
        public string PeakWorkingSet { get; set; }
        public string CommitSize { get; set; }
        public string PagedPool { get; set; }
        public string NonPagedPool { get; set; }
        public string Handles { get; set; }
        public string Threads { get; set; }
        public string GDIObject { get; set; }
    }
}

