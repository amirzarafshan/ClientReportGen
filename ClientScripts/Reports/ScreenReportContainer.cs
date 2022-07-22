
using ClientScripts.Database;
using ClientScripts.Extensions;
using ClientScripts.Models;
using System.Linq;
using System.Windows.Forms;

namespace ClientScripts.Reports
{
    public static class ScreenReportContainer
    {
        private static readonly DBProviderBase DBProvider = new DBProviderBase(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PCMClient\pcmclient.mdb;Jet OLEDB:Database Password=PCMusic321;");

        public static ScreenReportData ToScreenReport()
        {
            return new ScreenReportData
            {
                ClientParams = PCMClientParams.GetPCMClientPosition(DBProvider),
                Displays = Screen.AllScreens.Select(x => x.ToDisplayInfo()).ToArray()
            };
          
        }
    }
}
