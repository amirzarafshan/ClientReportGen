using System.Windows.Forms;
using ClientScripts.Models;

namespace ClientScripts.Reports
{
    public sealed class ScreenReport : ReportBase
    {
        public ClientParams ClientParams { get; set; }
        public Screen[] Screens { get; set; }
    }
}
