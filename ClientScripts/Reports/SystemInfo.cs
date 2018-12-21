using System.Windows.Forms;
using ClientScripts.Models;

namespace ClientScripts.Reports
{
    public sealed class SystemInfo : ReportBase
    {
        public OSInformation OSInfo { get; set; }
        public HardwareInformation HardwareInfo { get; set; }
        public NetworkInfo NetworkInformation { get; set; }

    }
}
