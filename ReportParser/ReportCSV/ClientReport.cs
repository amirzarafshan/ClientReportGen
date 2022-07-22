using ClientScripts.Models;
using ReportParser.Models;
using ReportParser.Parsers;

namespace ReportParser.ReportCSV
{
    public class ClientReport
    {
        public static MemoryInfoModel ClientMemoryInfoReport(Client client)
        {         
            return ParseMemoryInfoModel.ToMemInfoModel(client, Stations.GetLatestSysInfoStatFile(client));       
        }

        public static ScreenInfoModel ClientSceenInfoReport(Client client)
        {      
            return ParseScreenInfoModel.ToScreenInfoModel(client, Stations.GetLatestScreenInfoStatFile(client));
        }

        public static SystemInformationModel ClientSystemInfoReport(Client client)
        {
            return ParseSystemInfoModel.ToSystemInfoInfoModel(client, Stations.GetLatestSysInfoStatFile(client));
        }

        public static ErrorModel ClientErrorInfoReport (Client client)
        {
            return ParseErrorModel.ToErrorModel(client, Stations.GetErrorReport(client));
        }
    }
}
