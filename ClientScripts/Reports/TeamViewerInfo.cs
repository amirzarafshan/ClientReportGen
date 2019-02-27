using ClientScripts.Models;

namespace ClientScripts.Reports
{
    public sealed class TeamViewerInfo : ReportBase
    {
        public string ComputerName { get; set; }
        public TVInfo TeamViewer { get; set; }
    }
}
